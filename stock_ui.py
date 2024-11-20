from PyQt5 import uic
from PyQt5.QtWidgets import QMainWindow

class StockUI(QMainWindow):
    def __init__(self):
        super().__init__()
        uic.loadUi("stock_window.ui", self)  # stock_window.ui 로드

        self.table.setHorizontalHeaderLabels([" ","종목명", "매수가", "현재가", "보유수량", "가능수량", "수익률", "고점", "고점대비", "청산"])
