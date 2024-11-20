import sys
import FinanceDataReader as fdr
from PyQt5.QtWidgets import QApplication, QTableWidgetItem, QPushButton
from PyQt5.QtGui import QColor
from PyQt5.QtCore import Qt

# UI를 가져옵니다.
from stock_ui import StockUI

class StockApp(StockUI):
    def __init__(self):
        super().__init__()

        # 버튼 이벤트 연결
        self.btn_account.clicked.connect(self.on_button_click)
        self.btn_password.clicked.connect(self.on_button2_click)

        # 금융 데이터 로드
        self.kospi = fdr.DataReader('KS11')
        self.kosdaq = fdr.DataReader('KQ11')
        self.kospi_200 = fdr.DataReader('KS200')

    def on_button2_click(self):
        
        # 데이터 추가
        data = [
            ("대웅", "₩12,300", "₩12,200", 813, 0, -1.09, "₩12,200", -0.28),
            ("동방", "₩1,990", "₩2,030", 5025, 0, 1.72, "₩2,040", -0.76),
        ]

        for row, (name, buy_price, current_price, qty, avail_qty, profit, high_price, high_diff) in enumerate(data):
            # 체크박스 추가
            checkbox_item = QTableWidgetItem()
            checkbox_item.setFlags(Qt.ItemIsUserCheckable | Qt.ItemIsEnabled)
            checkbox_item.setCheckState(Qt.Unchecked)
            self.table.setItem(row, 0, checkbox_item)

            # 나머지 데이터 추가
            self.table.setItem(row, 1, QTableWidgetItem(name))
            self.table.setItem(row, 2, QTableWidgetItem(buy_price))
            self.table.setItem(row, 3, QTableWidgetItem(current_price))
            self.table.setItem(row, 4, QTableWidgetItem(str(qty)))
            self.table.setItem(row, 5, QTableWidgetItem(str(avail_qty)))

            # 수익률 색상 설정
            profit_item = QTableWidgetItem(f"{profit:.2f}%")
            profit_item.setForeground(QColor("red") if profit > 0 else QColor("blue"))
            self.table.setItem(row, 6, profit_item)

            self.table.setItem(row, 7, QTableWidgetItem(high_price))
            self.table.setItem(row, 8, QTableWidgetItem(f"{high_diff:.2f}%"))

            # 청산 버튼 추가
            button = QPushButton("✖")
            self.table.setCellWidget(row, 9, button)

        self.textEdit_log.append("주식 데이터 추가함.")

    def on_button_click(self):
        # 지수 데이터 처리
        kospi_current = self.kospi['Close'].iloc[-1]
        kosdaq_current = self.kosdaq['Close'].iloc[-1]
        kospi_200_current = self.kospi_200['Close'].iloc[-1]

        kospi_change = self.kospi['Change'].iloc[-1] * 100
        kosdaq_change = self.kosdaq['Change'].iloc[-1] * 100
        kospi_200_change = self.kospi_200['Change'].iloc[-1] * 100
        
        def Change_color(item):
            value = QTableWidgetItem(f"{item:.2f}%")
            value.setForeground(QColor("red") if item > 0 else QColor("blue"))
            return value

        self.table_market.setItem(0, 0, QTableWidgetItem(f"{kospi_current:.2f}"))
        self.table_market.setItem(1, 0, Change_color(kospi_change))
        self.table_market.setItem(0, 1, QTableWidgetItem(f"{kosdaq_current:.2f}"))
        self.table_market.setItem(1, 1, Change_color(kosdaq_change))
        self.table_market.setItem(0, 2, QTableWidgetItem(f"{kospi_200_current:.2f}"))
        self.table_market.setItem(1, 2, Change_color(kospi_200_change))
        
        self.textEdit_log.append("증시 데이터 추가함.")

# PyQt5 애플리케이션 실행 코드
if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = StockApp()
    window.show()
    sys.exit(app.exec_())
