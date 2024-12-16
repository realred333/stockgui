"""
QtDesigner로 만든 UI와 해당 UI의 위젯에서 발생하는 이벤트를 컨트롤하는 클래스

author: 서경동
last edit: 2017. 01. 18
"""


import sys, time
from PyQt5.QtWidgets import QApplication, QMainWindow, QMessageBox, QTableWidget, QTableWidgetItem
from PyQt5.QtCore import Qt, QTimer, QTime
from PyQt5 import uic
from Kiwoom import Kiwoom, ParameterTypeError, ParameterValueError, KiwoomProcessingError, KiwoomConnectError


# ui = uic.loadUiType("pytrader.ui")[0]
ui = uic.loadUiType("stock_window.ui")[0]
class MyWindow(QMainWindow, ui):

    def __init__(self):
        super().__init__()
        self.setupUi(self)
        self.show()

        self.kiwoom = Kiwoom()
        self.kiwoom.commConnect()

        self.server = self.kiwoom.getLoginInfo("GetServerGubun")

        if len(self.server) == 0 or self.server != "1":
            self.serverGubun = "실제운영"
        else:
            self.serverGubun = "모의투자"

        self.codeList = self.kiwoom.getCodeList("0")
    
        # 메인 타이머
        self.timer = QTimer(self)
        self.timer.start(1000)
        self.timer.timeout.connect(self.timeout)

        # 지수 타이머
        self.indextimer = QTimer(self)
        self.indextimer.start(1000)
        self.indextimer.timeout.connect(self.timeout)

        # 잔고 및 보유종목 조회 타이머
        self.inquiryTimer = QTimer(self)
        self.inquiryTimer.start(1000*10)
        self.inquiryTimer.timeout.connect(self.timeout)

        self.setAccountComboBox()
        self.codeLineEdit.textChanged.connect(self.setCodeName)
        self.orderBtn.clicked.connect(self.sendOrder)
        self.inquiryBtn.clicked.connect(self.inquiryBalance)
        self.btn_password.clicked.connect(self.open_password_dialog)
        self.condition_btn.clicked.connect(self.buyBasedOnCondition)
        self.sell_btn.clicked.connect(self.sell_all_stocks)

        # 자동 주문
        # 자동 주문을 활성화 하려면 True로 설정
        self.isAutomaticOrder = True

        # 자동 선정 종목 리스트 테이블 설정
        # self.setAutomatedStocks()
        
        # 조건식 콤보박스에 불러오기
        self.load_condition()
        
        # 최초 지수 데이터 요청
        self.fetch_index()
        
        # 매수 완료된 종목 리스트 초기화
        self.sell_plist = []

        self.balance_codes = []

    def buyBasedOnCondition(self):
        """조건식에 맞는 종목들을 매수하고 분할 매도 주문"""
        account = self.accountComboBox.currentText()

        try:
            # 현재 선택된 조건식 정보 가져오기
            condition_index = self.combo_condition.currentData()
            condition_name = self.combo_condition.currentText()
            
            if condition_index is None:
                self.showDialog('Warning', type('Error', (object,), {'msg': "조건식을 선택해주세요."}))
                return
            
            # 조건검색 요청(1회성 조회)
            self.kiwoom.sendCondition("0351", condition_name, condition_index, 0)
            # # 조건검색으로 나온 종목들에 대해 복수종목 조회
            # if hasattr(self.kiwoom, 'condition_codes') and self.kiwoom.condition_codes:
            #     codes = ";".join(self.kiwoom.condition_codes)
            #     self.kiwoom.commKwRqData(codes, 0, len(self.kiwoom.condition_codes), "CONDITION_STOCKS", "0101", 0)
                
            # # 보유종목 정보 조회
            # self.inquiryBalance()
            # print(self.kiwoom.opw00018Data)
            # 임시 리스트를 만들어 삭제할 코드들을 저장
            codes_to_remove = []
            
            for code in self.kiwoom.condition_codes:
                try:
                    print(code)
                    # 현재가 확인 (매수1호가 사용)
                    price = self.kiwoom.get_current_price(code)
                    time.sleep(0.2)
                    # 문자열을 정수로 변환
                    price = int(price) if price else 0
                    if price <= 0:
                        continue
                        
                    # 주문수량 계산 (10만원어치)
                    qty = int(100000 / price)
                    if qty < 1:
                        continue
                    # 매수 주문 실행
                    self.kiwoom.sendOrder(
                        "조건매수", 
                        "0101",
                        account,
                        1,  # 신규매수
                        code,
                        int(qty),
                        int(price),
                        "03",  # 지정가
                        ""
                    )
                    #self.kiwoom.sendOrder("자동매수주문", "0101", account, 1, code, int(qty), int(price), hogaTypeTable[hoga], "")

                    # 매수 주문 후 체결 확인을 위해 대기
                    time.sleep(1)
                    
                   
                    
                    # 매수 완료된 종목을 sell_plist에 추가하고 삭제 목록에 추가
                    self.sell_plist.append(code)
                    codes_to_remove.append(code)
                    
                    # 주문 후 잠시 대기 (초당 5회 주문 제한 고려)
                    time.sleep(0.2)
                    
                except Exception as e:
                    self.logTextEdit.append(f"주문 실패 ({code}): {str(e)}")
                    continue
            
            # 매수 완료된 종목들을 condition_codes에서 제거
            for code in codes_to_remove:
                self.kiwoom.condition_codes.remove(code)

            # 매도 주문 실행
                self.place_split_sell_orders(code, self.accountComboBox.currentText())
                
            # 잔고 및 보유종목 갱신
            self.inquiryBalance()
        except Exception as e:
            self.showDialog('Critical', type('Error', (object,), {'msg': str(e)}))

    def place_split_sell_orders(self, code, account):
        """매수 완료된 종목에 대해 분할 매도 주문 실행"""
        try:
            # 보유 종목 정보에서 현재가 찾기
            current_price = None
            for stock in self.balance_codes:
                if stock[0] == code:  # 종목코드 매칭
                    current_price = stock[4].replace(',', '')  # 현재가 (콤마 제거)
                    sellable_qty = int(stock[2].replace(',', ''))  # 매도가능수량 (콤마 제거)
                    break

            # 문자열을 정수로 변환
            current_price = int(current_price) if current_price else 0
            if current_price <= 0:
                return
            
            # 매도가능수량 조회
            if sellable_qty <= 0:
                return
            
            # 분할 수량 계산 (25%씩)
            split_qty = int(sellable_qty * 0.25)
            if split_qty < 1:
                return
            
            # 매도 가격 설정 (2%, 4%, 6%, 8% 위)
            profit_rates = [1.02, 1.04, 1.06, 1.08]
            
            # 각 가격대별로 매도 주문
            for rate in profit_rates:
                sell_price = int(current_price * rate)
                
                # 매도 주문 실행
                self.kiwoom.sendOrder(
                    "분할매도", 
                    "0101",
                    account,
                    2,  # 신규매도
                    code,
                    split_qty,
                    sell_price,
                    "00",  # 지정가
                    ""
                )
                
                # 주문 후 잠시 대기
                time.sleep(0.2)
                
        except Exception as e:
            self.logTextEdit.append(f"분할매도 주문 실패 ({code}): {str(e)}")

    def calculate_target_price(self, price, profit_rate):
        """호가단위를 고려한 목표가 계산"""
        target = price * profit_rate
        
        if target < 1000:
            return int(target + 0.999)
        elif target < 5000:
            return int(target + 4.999) // 5 * 5
        elif target < 10000:
            return int(target + 9.999) // 10 * 10
        elif target < 50000:
            return int(target + 49.999) // 50 * 50
        elif target < 100000:
            return int(target + 99.999) // 100 * 100
        elif target < 500000:
            return int(target + 499.999) // 500 * 500
        else:
            return int(target + 999.999) // 1000 * 1000

    def load_condition(self):
        """서버에 저장된 사용자 조건식을 가져와서 콤보박스에 추가"""
        try:
            # 조건식 목록 요청
            self.kiwoom.getConditionLoad()
            
            # 조건식 목록 가져오기
            conditions = self.kiwoom.condition
            
            # 콤보박스 초기화
            self.combo_condition.clear()
            
            # 조건식을 콤보박스에 추가
            for index, condition in conditions.items():
                self.combo_condition.addItem(condition, index)  # index는 사용자 데이터로 저장
                
        except Exception as e:
            error = type('Error', (object,), {'msg': str(e)})
            self.showDialog('Critical', error)


    def open_password_dialog(self):
        """시스템 트레이의 비밀번호 입력창을 실행"""
        try:
            # KOA Studio의 비밀번호 입력창 실행
            self.kiwoom.dynamicCall("KOA_Functions(QString, QString)", "ShowAccountWindow", "")
            
        except Exception as e:
            error = type('Error', (object,), {'msg': str(e)})
            self.showDialog('Critical', error)

    def timeout(self):
        """ 타임아웃 이벤트가 발생하면 호출되는 메서드 """

        # 어떤 타이머에 의해서 호출되었는지 확인
        sender = self.sender()

        # 메인 타이머
        if id(sender) == id(self.timer):
            currentTime = QTime.currentTime().toString("hh:mm:ss")
            automaticOrderTime = QTime.currentTime().toString("hhmm")

            # 상태바 설정
            state = ""

            if self.kiwoom.getConnectState() == 1:

                state = self.serverGubun + " 서버 연결중"
            else:
                state = "서버 미연결"

            self.statusbar.showMessage("현재시간: " + currentTime + " | " + state)

            # 자동 주문 실행
            # 1100은 11시 00분을 의미합니다.
            if self.isAutomaticOrder and int(automaticOrderTime) >= 1100:
                self.isAutomaticOrder = False
                self.automaticOrder()
                # self.setAutomatedStocks()

            # log
            if self.kiwoom.msg:
                self.logTextEdit.append(self.kiwoom.msg)
                self.kiwoom.msg = ""
            
        # 지수 조회 타이머    
        elif id(sender) == id(self.indextimer):
            self.fetch_index()
        # 실시간 조회 타이머
        else:
            if self.realtimeCheckBox.isChecked():
                self.inquiryBalance()

    def setCodeName(self):
        """ 종목코드에 해당하는 한글명을 codeNameLineEdit에 설정한다. """

        code = self.codeLineEdit.text()

        if code in self.codeList:
            codeName = self.kiwoom.getMasterCodeName(code)
            self.codeNameLineEdit.setText(codeName)

    def setAccountComboBox(self):
        """ accountComboBox에 계좌번호를 설정한다. """

        try:
            cnt = int(self.kiwoom.getLoginInfo("ACCOUNT_CNT"))
            accountList = self.kiwoom.getLoginInfo("ACCNO").split(';')
            self.accountComboBox.addItems(accountList[0:cnt])
        except (KiwoomConnectError, ParameterTypeError, ParameterValueError) as e:
            self.showDialog('Critical', e)

    def sendOrder(self):
        """ 키움서버로 주문정보를 전송한다. """

        orderTypeTable = {'신규매수': 1, '신규매도': 2, '매수취소': 3, '매도취소': 4}
        hogaTypeTable = {'지정가': "00", '시장가': "03"}

        account = self.accountComboBox.currentText()
        orderType = orderTypeTable[self.orderTypeComboBox.currentText()]
        code = self.codeLineEdit.text()
        hogaType = hogaTypeTable[self.hogaTypeComboBox.currentText()]
        qty = self.qtySpinBox.value()
        price = self.priceSpinBox.value()

        try:
            self.kiwoom.sendOrder("수동주문", "0101", account, orderType, code, qty, price, hogaType, "")

        except (ParameterTypeError, KiwoomProcessingError) as e:
            self.showDialog('Critical', e)

    def fetch_index(self):
        """업종지수 실시간 구독"""
        try:
            # opt20001Data가 초기화되어 있는지 확인
            if not hasattr(self.kiwoom, 'opt20001Data') or len(self.kiwoom.opt20001Data) != 6:
                self.kiwoom.opt20001Data = ["0"] * 6
            
            # 실시간 시세 등록 (처음 한 번만)
            if not hasattr(self, '_real_reg_done'):
                self.kiwoom.setRealReg("2001", "001", "10;12", "0")  # 코스피
                self.kiwoom.setRealReg("2002", "101", "10;12", "1")  # 코스닥
                self.kiwoom.setRealReg("2003", "201", "10;12", "1")  # 코스피200
                self._real_reg_done = True
            
            # 테이블 업데이트
            for col in range(3):  # 코스피, 코스닥, 코스피200 순서
                try:
                    # 지수 표시 (첫째 행)
                    index_value = str(self.kiwoom.opt20001Data[col*2]).replace('+','').replace('-','')
                    index_item = QTableWidgetItem(index_value)
                    index_item.setTextAlignment(Qt.AlignCenter)
                    
                    # 지수가 양수면 빨간색, 음수면 파란색으로 설정
                    if float(self.kiwoom.opt20001Data[col*2]) > 0:
                        index_item.setForeground(Qt.red)
                    elif float(self.kiwoom.opt20001Data[col*2]) < 0:
                        index_item.setForeground(Qt.blue)
                        
                    self.table_market.setItem(0, col, index_item)
                    
                    # 등락율 표시 (둘째 행)
                    rate_value = str(self.kiwoom.opt20001Data[col*2 + 1]).replace('+','').replace('-','')
                    rate_item = QTableWidgetItem(rate_value + "%")
                    rate_item.setTextAlignment(Qt.AlignCenter)
                    
                    # 등락율이 양수면 빨간색, 음수면 파란색으로 설정
                    if float(self.kiwoom.opt20001Data[col*2 + 1]) > 0:
                        rate_item.setForeground(Qt.red)
                    elif float(self.kiwoom.opt20001Data[col*2 + 1]) < 0:
                        rate_item.setForeground(Qt.blue)
                        
                    self.table_market.setItem(1, col, rate_item)
                except IndexError:
                    continue  # 데이터가 아직 준비되지 않았으면 건너뛰기
                
        except Exception as e:
            print(f"fetch_index error: {str(e)}")  # 에러 로깅

    def inquiryBalance(self):
        """ 예수금상세현황과 계좌평가잔고내역을 요청후 테이블에 출력한다. """
        
        # 타이머 일시 중지
        self.inquiryTimer.stop()
        self.indextimer.stop()

        try:
            # 예수금상세현황요청
            self.kiwoom.setInputValue("계좌번호", self.accountComboBox.currentText())
            self.kiwoom.setInputValue("비밀번호", "0000")
            self.kiwoom.commRqData("예수금상세현황요청", "opw00001", 0, "2000")

            # 계좌평가잔고내역요청 - opw00018 은 한번에 20개의 종목정보를 반환
            self.kiwoom.setInputValue("계좌번호", self.accountComboBox.currentText())
            self.kiwoom.setInputValue("비밀번호", "0000")
            self.kiwoom.commRqData("계좌평가잔고내역요청", "opw00018", 0, "2000")

            while self.kiwoom.inquiry == '2':
                time.sleep(0.2)

                self.kiwoom.setInputValue("계좌번호", self.accountComboBox.currentText())
                self.kiwoom.setInputValue("비밀번호", "0000")
                self.kiwoom.commRqData("계좌평가잔고내역요청", "opw00018", 2, "2")

        except (ParameterTypeError, ParameterValueError, KiwoomProcessingError) as e:
            self.showDialog('Critical', e)

        self.lineEdit_account.setText(self.kiwoom.opw00001Data)
        '''
        # accountEvaluationTable 테이블에 정보 출력
        item = QTableWidgetItem(self.kiwoom.opw00001Data)   # d+2추정예수금
        item.setTextAlignment(Qt.AlignVCenter | Qt.AlignRight)
        self.accountEvaluationTable.setItem(0, 0, item)

        for i in range(1, 6):
            item = QTableWidgetItem(self.kiwoom.opw00018Data['accountEvaluation'][i-1])
            item.setTextAlignment(Qt.AlignVCenter | Qt.AlignRight)
            self.accountEvaluationTable.setItem(0, i, item)

        self.accountEvaluationTable.resizeRowsToContents()
        '''

        # stocksTable 테이블에 정보 출력
        cnt = len(self.kiwoom.opw00018Data['stocks'])
        self.stocksTable.setRowCount(cnt)

        for i in range(cnt):
            row = self.kiwoom.opw00018Data['stocks'][i]

            for j in range(len(row)-1):
                item = QTableWidgetItem(row[j+1])
                item.setTextAlignment(Qt.AlignVCenter | Qt.AlignRight)
                self.stocksTable.setItem(i, j, item)

        self.stocksTable.resizeRowsToContents()
        self.balance_codes = self.kiwoom.opw00018Data['stocks']
        # 데이터 초기화
        self.kiwoom.opwDataReset()

        # inquiryTimer 재시작
        self.inquiryTimer.start(1000*10)
        self.indextimer.start(1000)

    # 경고창
    def showDialog(self, grade, error):
        gradeTable = {'Information': 1, 'Warning': 2, 'Critical': 3, 'Question': 4}

        dialog = QMessageBox()
        dialog.setIcon(gradeTable[grade])
        dialog.setText(error.msg)
        dialog.setWindowTitle(grade)
        dialog.setStandardButtons(QMessageBox.Ok)
        dialog.exec_()

    def setAutomatedStocks(self):
        fileList = ["buy_list.txt", "sell_list.txt"]
        automatedStocks = []

        try:
            for file in fileList:
                # utf-8로 작성된 파일을
                # cp949 환경에서 읽기위해서 encoding 지정
                with open(file, 'rt', encoding='utf-8') as f:
                    stocksList = f.readlines()
                    automatedStocks += stocksList
        except Exception as e:
            e.msg = "setAutomatedStocks() 에러"
            self.showDialog('Critical', e)
            return

        # 테이블 행수 설정
        cnt = len(automatedStocks)
        self.automatedStocksTable.setRowCount(cnt)

        # 테이블에 출력
        for i in range(cnt):
            stocks = automatedStocks[i].split(';')

            for j in range(len(stocks)):
                if j == 1:
                    name = self.kiwoom.getMasterCodeName(stocks[j].rstrip())
                    item = QTableWidgetItem(name)
                else:
                    item = QTableWidgetItem(stocks[j].rstrip())

                item.setTextAlignment(Qt.AlignVCenter | Qt.AlignCenter)
                self.automatedStocksTable.setItem(i, j, item)

        self.automatedStocksTable.resizeRowsToContents()

    def automaticOrder(self):
        fileList = ["buy_list.txt", "sell_list.txt"]
        hogaTypeTable = {'지정가': "00", '시장가': "03"}
        account = self.accountComboBox.currentText()
        automatedStocks = []

        # 파일읽기
        try:
            for file in fileList:
                # utf-8로 작성된 파일을
                # cp949 환경에서 읽기위해서 encoding 지���
                with open(file, 'rt', encoding='utf-8') as f:
                    stocksList = f.readlines()
                    automatedStocks += stocksList
        except Exception as e:
            e.msg = "automaticOrder() 에러"
            self.showDialog('Critical', e)
            return

        cnt = len(automatedStocks)

        # 주문하기
        buyResult = []
        sellResult = []

        for i in range(cnt):
            stocks = automatedStocks[i].split(';')

            code = stocks[1]
            hoga = stocks[2]
            qty = stocks[3]
            price = stocks[4]

            try:
                if stocks[5].rstrip() == '매수전':
                    self.kiwoom.sendOrder("자동매수주문", "0101", account, 1, code, int(qty), int(price), hogaTypeTable[hoga], "")

                    # 주문 접수시
                    if self.kiwoom.orderNo:
                        buyResult += automatedStocks[i].replace("매수전", "매수주문완료")
                        self.kiwoom.orderNo = ""
                    # 주문 미접수시
                    else:
                        buyResult += automatedStocks[i]

                # 참고: 해당 종목을 현재도 보유하고 있다고 가정함.
                elif stocks[5].rstrip() == '매도전':
                    self.kiwoom.sendOrder("자동매도주문", "0101", account, 2, code, int(qty), int(price), hogaTypeTable[hoga], "")

                    # 주문 접수시
                    if self.kiwoom.orderNo:
                        sellResult += automatedStocks[i].replace("매도전", "매도주문완료")
                        self.kiwoom.orderNo = ""
                    # 주문 미접수시
                    else:
                        sellResult += automatedStocks[i]

            except (ParameterTypeError, KiwoomProcessingError) as e:
                self.showDialog('Critical', e)

        # 잔고및 보유종목 디스플레이 갱신
        self.inquiryBalance()

        # 결과저장하기
        for file, result in zip(fileList, [buyResult, sellResult]):
            with open(file, 'wt', encoding='utf-8') as f:
                for data in result:
                    f.write(data)

    def closeEvent(self, event):
        """프로그램 종료 시 실행되는 메서드"""
        self.kiwoom.disconnectRealData("2001")  # 코스피 실시간 해제
        self.kiwoom.disconnectRealData("2002")  # 코스닥 실시간 해제
        self.kiwoom.disconnectRealData("2003")  # 코스피200 실시간 해제
        event.accept()

    def sell_all_stocks(self):
        """보유한 모든 종목에 대해 분할 매도 주문 실행"""
        try:
            # 계좌번호 가져오기
            account = self.accountComboBox.currentText()
            
            # 잔고 및 보유종목 갱신
            self.inquiryBalance()
            
            # 보유한 모든 종목에 대해 분할 매도 주문
            for stock in self.balance_codes:
                code = stock[0]  # 종목코드
                current_price = int(stock[4].replace(',', ''))  # 현재가
                sellable_qty = int(stock[2].replace(',', ''))  # 매도가능수량
                
                if sellable_qty <= 0:
                    continue
                    
                # 분할 수량 계산 (25%씩)
                split_qty = int(sellable_qty * 0.25)
                if split_qty < 1:
                    continue
                    
                # 매도 가격 설정 (2%, 4%, 6%, 8% 위)
                profit_rates = [1.02, 1.04, 1.06, 1.08]
                
                # 각 가격대별로 매도 주문
                for rate in profit_rates:
                    sell_price = self.calculate_target_price(current_price, rate)
                    
                    # 매도 주문 실행
                    self.kiwoom.sendOrder(
                        "일괄분할매도", 
                        "0101",
                        account,
                        2,  # 신규매도
                        code,
                        split_qty,
                        sell_price,
                        "00",  # 지정가
                        ""
                    )
                    
                    # 주문 후 잠시 대기
                    time.sleep(0.2)
                    
            # 잔고 및 보유종목 갱신
            self.inquiryBalance()
                
        except Exception as e:
            self.logTextEdit.append(f"일괄 분할매도 주문 실패: {str(e)}")


if __name__ == "__main__":
    app = QApplication(sys.argv)
    myWindow = MyWindow()
    sys.exit(app.exec_())
