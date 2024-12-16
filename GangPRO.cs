using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AxKHOpenAPILib;
using G_Code;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("GangPRO")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("GangPRO")]
[assembly: AssemblyCopyright("Copyright © Microsoft Corporation 2017")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("7a99fa68-18d3-4c57-8f7b-97a481750484")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework(".NETFramework,Version=v4.5", FrameworkDisplayName = ".NET Framework 4.5")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace G_Code
{
	public enum Log
	{
		로그창,
		체결장
	}
	internal class KOAErrorCode
	{
		public const int OP_ERR_NONE = 0;

		public const int OP_ERR_LOGIN = -100;

		public const int OP_ERR_CONNECT = -101;

		public const int OP_ERR_VERSION = -102;

		public const int OP_ERR_SISE_OVERFLOW = -200;

		public const int OP_ERR_RQ_STRUCT_FAIL = -201;

		public const int OP_ERR_RQ_STRING_FAIL = -202;

		public const int OP_ERR_ORD_WRONG_INPUT = -300;

		public const int OP_ERR_ORD_WRONG_ACCNO = -301;

		public const int OP_ERR_OTHER_ACC_USE = -302;

		public const int OP_ERR_MIS_2BILL_EXC = -303;

		public const int OP_ERR_MIS_5BILL_EXC = -304;

		public const int OP_ERR_MIS_1PER_EXC = -305;

		public const int OP_ERR_MID_3PER_EXC = -306;
	}
	public class GCode
	{
		public struct OrderRate
		{
			private int Code1;

			private string Name;

			public string name => Name;

			public int code1 => Code1;

			public OrderRate(int nCode1, string strName)
			{
				Name = strName;
				Code1 = nCode1;
			}
		}

		public struct Struct_Type_자동매수호가
		{
			public string Name;

			public int n복합도;

			public double n물량1;

			public double f매수가1;

			public double n물량2;

			public double f매수가2;

			public double n물량3;

			public double f매수가3;

			public double n물량4;

			public double f매수가4;

			public double n물량5;

			public double f매수가5;

			public Struct_Type_자동매수호가(string strName, int nCnt, double nOp1, double fOp1, double nOp2, double fOp2, double nOp3, double fOp3, double nOp4, double fOp4, double nOp5, double fOp5)
			{
				Name = strName;
				n복합도 = nCnt;
				n물량1 = nOp1;
				f매수가1 = fOp1;
				n물량2 = nOp2;
				f매수가2 = fOp2;
				n물량3 = nOp3;
				f매수가3 = fOp3;
				n물량4 = nOp4;
				f매수가4 = fOp4;
				n물량5 = nOp5;
				f매수가5 = fOp5;
			}
		}

		public struct Struct_Type_자동매수금액
		{
			private int Code1;

			private string Name;

			public string name => Name;

			public int code1 => Code1;

			public Struct_Type_자동매수금액(int nCode1, string strName)
			{
				Name = strName;
				Code1 = nCode1;
			}
		}

		public struct Struct_Type_예약매도물량
		{
			private int Code1;

			private string Name;

			public string name => Name;

			public int code1 => Code1;

			public Struct_Type_예약매도물량(int nCode1, string strName)
			{
				Name = strName;
				Code1 = nCode1;
			}
		}

		public struct Struct_Type_예약매도수익률
		{
			private double Code1;

			private string Name;

			public string name => Name;

			public double code1 => Code1;

			public Struct_Type_예약매도수익률(double nCode1, string strName)
			{
				Name = strName;
				Code1 = nCode1;
			}
		}

		public struct Struct_Type_예약매도복합
		{
			public string Name;

			public int n복합도;

			public double n물량1;

			public double f수익률1;

			public double n물량2;

			public double f수익률2;

			public double n물량3;

			public double f수익률3;

			public double n물량4;

			public double f수익률4;

			public Struct_Type_예약매도복합(string strName, int nCnt, double nOp1, double fOp1, double nOp2, double fOp2, double nOp3, double fOp3, double nOp4, double fOp4)
			{
				Name = strName;
				n복합도 = nCnt;
				n물량1 = nOp1;
				f수익률1 = fOp1;
				n물량2 = nOp2;
				f수익률2 = fOp2;
				n물량3 = nOp3;
				f수익률3 = fOp3;
				n물량4 = nOp4;
				f수익률4 = fOp4;
			}
		}

		public struct Struct_Type_계좌손절손실률
		{
			private double Code1;

			private string Name;

			public string name => Name;

			public double code1 => Code1;

			public Struct_Type_계좌손절손실률(double nCode1, string strName)
			{
				Name = strName;
				Code1 = nCode1;
			}
		}

		public struct Struct_Type_계좌일괄청산시간
		{
			private int Code1;

			private string Name;

			public string name => Name;

			public int code1 => Code1;

			public Struct_Type_계좌일괄청산시간(int nCode1, string strName)
			{
				Code1 = nCode1;
				Name = strName;
			}
		}

		public struct Struct_Type_조건동작시간
		{
			private int Code1;

			private string Name;

			public string name => Name;

			public int code1 => Code1;

			public Struct_Type_조건동작시간(int nCode1, string strName)
			{
				Code1 = nCode1;
				Name = strName;
			}
		}

		public struct Struct_Type_조건식매수종목수
		{
			private int Code1;

			private string Name;

			public string name => Name;

			public int code1 => Code1;

			public Struct_Type_조건식매수종목수(int nCode1, string strName)
			{
				Code1 = nCode1;
				Name = strName;
			}
		}

		public struct Struct_Type_리스트초기화시간
		{
			public int Value;

			public string Name;

			public Struct_Type_리스트초기화시간(int nCode1, string strName)
			{
				Value = nCode1;
				Name = strName;
			}
		}

		public struct Struct_Type_보유종목수제한
		{
			public int Value;

			public string Name;

			public Struct_Type_보유종목수제한(int nCode1, string strName)
			{
				Value = nCode1;
				Name = strName;
			}
		}

		public static readonly OrderRate[] Order반복주기;

		public static readonly Struct_Type_계좌손절손실률[] Struct_계좌손절손실률;

		public static readonly Struct_Type_계좌일괄청산시간[] Struct_계좌일괄청산시간;

		public static readonly Struct_Type_보유종목수제한[] Struct_보유종목수제한;

		public static readonly Struct_Type_자동매수호가[] Struct_자동매수호가;

		public static readonly Struct_Type_자동매수금액[] Struct_자동매수금액;

		public static readonly Struct_Type_예약매도물량[] Struct_예약매도물량;

		public static readonly Struct_Type_예약매도수익률[] Struct_예약매도수익률;

		public static readonly Struct_Type_예약매도복합[] Struct_예약매도복합;

		public static readonly Struct_Type_조건동작시간[] Struct_조건동작시간;

		public static readonly Struct_Type_조건식매수종목수[] Struct_조건식매수종목수;

		public static readonly Struct_Type_리스트초기화시간[] Struct_리스트초기화시간;

		static GCode()
		{
			Order반복주기 = new OrderRate[64];
			Struct_계좌손절손실률 = new Struct_Type_계좌손절손실률[64];
			Struct_계좌일괄청산시간 = new Struct_Type_계좌일괄청산시간[64];
			Struct_보유종목수제한 = new Struct_Type_보유종목수제한[64];
			Struct_자동매수호가 = new Struct_Type_자동매수호가[64];
			Struct_자동매수금액 = new Struct_Type_자동매수금액[64];
			Struct_예약매도물량 = new Struct_Type_예약매도물량[64];
			Struct_예약매도수익률 = new Struct_Type_예약매도수익률[64];
			Struct_예약매도복합 = new Struct_Type_예약매도복합[64];
			Struct_조건동작시간 = new Struct_Type_조건동작시간[64];
			Struct_조건식매수종목수 = new Struct_Type_조건식매수종목수[64];
			Struct_리스트초기화시간 = new Struct_Type_리스트초기화시간[64];
			Struct_계좌손절손실률[0] = new Struct_Type_계좌손절손실률(-1.0, "수익률 -1% 이하");
			Struct_계좌손절손실률[1] = new Struct_Type_계좌손절손실률(-2.0, "수익률 -2% 이하");
			Struct_계좌손절손실률[2] = new Struct_Type_계좌손절손실률(-3.0, "수익률 -3% 이하");
			Struct_계좌손절손실률[3] = new Struct_Type_계좌손절손실률(-4.0, "수익률 -4% 이하");
			Struct_계좌손절손실률[4] = new Struct_Type_계좌손절손실률(-5.0, "수익률 -5% 이하");
			Struct_계좌손절손실률[5] = new Struct_Type_계좌손절손실률(-10.0, "수익률 -10% 이하");
			Struct_계좌손절손실률[6] = new Struct_Type_계좌손절손실률(-103.0, "고점대비 -3% 이하");
			Struct_계좌손절손실률[7] = new Struct_Type_계좌손절손실률(-104.0, "고점대비 -4% 이하");
			Struct_계좌손절손실률[8] = new Struct_Type_계좌손절손실률(-105.0, "고점대비 -5% 이하");
			Struct_계좌일괄청산시간[0] = new Struct_Type_계좌일괄청산시간(-1, "지금!");
			Struct_계좌일괄청산시간[1] = new Struct_Type_계좌일괄청산시간(150000, "15시");
			Struct_계좌일괄청산시간[2] = new Struct_Type_계좌일괄청산시간(140000, "14시");
			Struct_계좌일괄청산시간[3] = new Struct_Type_계좌일괄청산시간(130000, "13시");
			Struct_계좌일괄청산시간[4] = new Struct_Type_계좌일괄청산시간(120000, "12시");
			Struct_계좌일괄청산시간[5] = new Struct_Type_계좌일괄청산시간(100000, "10시");
			Struct_계좌일괄청산시간[6] = new Struct_Type_계좌일괄청산시간(5700, "테스트");
			Struct_보유종목수제한[0] = new Struct_Type_보유종목수제한(3, "3개");
			Struct_보유종목수제한[1] = new Struct_Type_보유종목수제한(5, "5개");
			Struct_보유종목수제한[2] = new Struct_Type_보유종목수제한(7, "7개");
			Struct_보유종목수제한[3] = new Struct_Type_보유종목수제한(10, "10개");
			Struct_보유종목수제한[4] = new Struct_Type_보유종목수제한(15, "15개");
			Struct_보유종목수제한[5] = new Struct_Type_보유종목수제한(20, "20개");
			Struct_보유종목수제한[6] = new Struct_Type_보유종목수제한(10000, "무제한");
			Struct_자동매수호가[0] = new Struct_Type_자동매수호가("시장가", 1, 100.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[1] = new Struct_Type_자동매수호가("매도3호가", 1, 100.0, 13.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[2] = new Struct_Type_자동매수호가("매도2호가", 1, 100.0, 12.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[3] = new Struct_Type_자동매수호가("매도1호가", 1, 100.0, 11.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[4] = new Struct_Type_자동매수호가("매수1호가", 1, 100.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[5] = new Struct_Type_자동매수호가("매수2호가", 1, 100.0, 2.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[6] = new Struct_Type_자동매수호가("매수3호가", 1, 100.0, 3.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[7] = new Struct_Type_자동매수호가("매수4호가", 1, 100.0, 4.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[8] = new Struct_Type_자동매수호가("매수5호가", 1, 100.0, 5.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[9] = new Struct_Type_자동매수호가("시장가0.5%밑", 1, 100.0, -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[10] = new Struct_Type_자동매수호가("시장가1%밑", 1, 100.0, -1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[11] = new Struct_Type_자동매수호가("시장가1.5%밑", 1, 100.0, -1.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[12] = new Struct_Type_자동매수호가("시장가2%밑", 1, 100.0, -2.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[13] = new Struct_Type_자동매수호가("시장가2.5%밑", 1, 100.0, -2.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[14] = new Struct_Type_자동매수호가("시장가3%밑", 1, 100.0, -3.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[15] = new Struct_Type_자동매수호가("시장가4%밑", 1, 100.0, -4.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[16] = new Struct_Type_자동매수호가("시장가5%밑", 1, 100.0, -5.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[17] = new Struct_Type_자동매수호가("50%씩 시장가/매수1호가", 2, 50.0, 0.0, 50.0, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[18] = new Struct_Type_자동매수호가("50%씩 시장가/1%밑", 2, 50.0, 0.0, 50.0, -1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[19] = new Struct_Type_자동매수호가("50%씩 시장가/2%밑", 2, 50.0, 0.0, 50.0, -2.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[20] = new Struct_Type_자동매수호가("50%씩 시장가/3%밑", 2, 50.0, 0.0, 50.0, -3.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[21] = new Struct_Type_자동매수호가("50%씩 시장가/4%밑", 2, 50.0, 0.0, 50.0, -4.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[22] = new Struct_Type_자동매수호가("50%씩 시장가1%밑/2%밑", 2, 50.0, -1.0, 50.0, -2.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[23] = new Struct_Type_자동매수호가("50%씩 시장가1%밑/3%밑", 2, 50.0, -1.0, 50.0, -3.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[24] = new Struct_Type_자동매수호가("50%씩 시장가1%밑/4%밑", 2, 50.0, -1.0, 50.0, -4.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[25] = new Struct_Type_자동매수호가("50%씩 시장가1%밑/5%밑", 2, 50.0, -1.0, 50.0, -5.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[26] = new Struct_Type_자동매수호가("50% 시장가/25%씩 3%밑/6%밑", 3, 50.0, 0.0, 25.0, -3.0, 25.0, -6.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[27] = new Struct_Type_자동매수호가("50% 시장가/25%씩 4%밑/8%밑", 3, 50.0, 0.0, 25.0, -4.0, 25.0, -8.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[28] = new Struct_Type_자동매수호가("20%씩 매수1~5호가", 5, 20.0, 1.0, 20.0, 2.0, 20.0, 3.0, 20.0, 4.0, 20.0, 5.0);
			Struct_자동매수호가[29] = new Struct_Type_자동매수호가("50% 매수1호가/25%씩 3%밑/6%밑", 3, 50.0, 1.0, 25.0, -3.0, 25.0, -6.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수호가[30] = new Struct_Type_자동매수호가("50% 매수1호가/50% 3%밑", 2, 50.0, 1.0, 50.0, -3.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
			Struct_자동매수금액[0] = new Struct_Type_자동매수금액(10000, "10,000원");
			Struct_자동매수금액[1] = new Struct_Type_자동매수금액(50000, "50,000원");
			Struct_자동매수금액[2] = new Struct_Type_자동매수금액(100000, "100,000원");
			Struct_자동매수금액[3] = new Struct_Type_자동매수금액(200000, "200,000원");
			Struct_자동매수금액[4] = new Struct_Type_자동매수금액(300000, "300,000원");
			Struct_자동매수금액[5] = new Struct_Type_자동매수금액(400000, "400,000원");
			Struct_자동매수금액[6] = new Struct_Type_자동매수금액(500000, "500,000원");
			Struct_자동매수금액[7] = new Struct_Type_자동매수금액(600000, "600,000원");
			Struct_자동매수금액[8] = new Struct_Type_자동매수금액(700000, "700,000원");
			Struct_자동매수금액[9] = new Struct_Type_자동매수금액(800000, "800,000원");
			Struct_자동매수금액[10] = new Struct_Type_자동매수금액(900000, "900,000원");
			Struct_자동매수금액[11] = new Struct_Type_자동매수금액(1000000, "1,000,000원");
			Struct_자동매수금액[12] = new Struct_Type_자동매수금액(1500000, "1,500,000원");
			Struct_자동매수금액[13] = new Struct_Type_자동매수금액(2000000, "2,000,000원");
			Struct_자동매수금액[14] = new Struct_Type_자동매수금액(2500000, "2,500,000원");
			Struct_자동매수금액[15] = new Struct_Type_자동매수금액(3000000, "3,000,000원");
			Struct_자동매수금액[16] = new Struct_Type_자동매수금액(3500000, "3,500,000원");
			Struct_자동매수금액[17] = new Struct_Type_자동매수금액(4000000, "4,000,000원");
			Struct_자동매수금액[18] = new Struct_Type_자동매수금액(4500000, "4,500,000원");
			Struct_자동매수금액[19] = new Struct_Type_자동매수금액(5000000, "5,000,000원");
			Struct_자동매수금액[20] = new Struct_Type_자동매수금액(5500000, "5,500,000원");
			Struct_자동매수금액[21] = new Struct_Type_자동매수금액(6000000, "6,000,000원");
			Struct_자동매수금액[22] = new Struct_Type_자동매수금액(6500000, "6,500,000원");
			Struct_자동매수금액[23] = new Struct_Type_자동매수금액(7000000, "7,000,000원");
			Struct_자동매수금액[24] = new Struct_Type_자동매수금액(7500000, "7,500,000원");
			Struct_자동매수금액[25] = new Struct_Type_자동매수금액(8000000, "8,000,000원");
			Struct_자동매수금액[26] = new Struct_Type_자동매수금액(8500000, "8,500,000원");
			Struct_자동매수금액[27] = new Struct_Type_자동매수금액(9000000, "9,000,000원");
			Struct_자동매수금액[28] = new Struct_Type_자동매수금액(9500000, "9,500,000원");
			Struct_자동매수금액[29] = new Struct_Type_자동매수금액(10000000, "10,000,000원");
			Struct_예약매도물량[0] = new Struct_Type_예약매도물량(100, "100%");
			Struct_예약매도물량[1] = new Struct_Type_예약매도물량(90, "90%");
			Struct_예약매도물량[2] = new Struct_Type_예약매도물량(80, "80%");
			Struct_예약매도물량[3] = new Struct_Type_예약매도물량(70, "70%");
			Struct_예약매도물량[4] = new Struct_Type_예약매도물량(60, "60%");
			Struct_예약매도물량[5] = new Struct_Type_예약매도물량(50, "50%");
			Struct_예약매도물량[6] = new Struct_Type_예약매도물량(40, "40%");
			Struct_예약매도물량[7] = new Struct_Type_예약매도물량(30, "30%");
			Struct_예약매도물량[8] = new Struct_Type_예약매도물량(20, "20%");
			Struct_예약매도물량[9] = new Struct_Type_예약매도물량(10, "10%");
			Struct_예약매도수익률[0] = new Struct_Type_예약매도수익률(1.0, "1%");
			Struct_예약매도수익률[1] = new Struct_Type_예약매도수익률(1.5, "1.5%");
			Struct_예약매도수익률[2] = new Struct_Type_예약매도수익률(2.0, "2%");
			Struct_예약매도수익률[3] = new Struct_Type_예약매도수익률(2.5, "2.5%");
			Struct_예약매도수익률[4] = new Struct_Type_예약매도수익률(3.0, "3%");
			Struct_예약매도수익률[5] = new Struct_Type_예약매도수익률(4.0, "4%");
			Struct_예약매도수익률[6] = new Struct_Type_예약매도수익률(5.0, "5%");
			Struct_예약매도수익률[7] = new Struct_Type_예약매도수익률(7.0, "7%");
			Struct_예약매도수익률[8] = new Struct_Type_예약매도수익률(10.0, "10%");
			Struct_예약매도수익률[9] = new Struct_Type_예약매도수익률(12.0, "12%");
			Struct_예약매도수익률[10] = new Struct_Type_예약매도수익률(15.0, "15%");
			Struct_예약매도복합[0] = new Struct_Type_예약매도복합("70%-2%/30%-3%", 2, 70.0, 2.0, -1.0, 3.0, 0.0, 0.0, 0.0, 0.0);
			Struct_예약매도복합[1] = new Struct_Type_예약매도복합("50%-2%/50%-3%", 2, 50.0, 2.0, -1.0, 3.0, 0.0, 0.0, 0.0, 0.0);
			Struct_예약매도복합[2] = new Struct_Type_예약매도복합("50%-2%/25%-2.5%/25%-3%", 3, 50.0, 2.0, 25.0, 2.5, -1.0, 3.0, 0.0, 0.0);
			Struct_예약매도복합[3] = new Struct_Type_예약매도복합("25%씩-2%/2.5%/3%/3.5%", 4, 25.0, 2.0, 25.0, 2.5, 25.0, 3.0, -1.0, 3.5);
			Struct_예약매도복합[4] = new Struct_Type_예약매도복합("25%씩-2%/3%/4%/5%", 4, 25.0, 2.0, 25.0, 3.0, 25.0, 4.0, -1.0, 5.0);
			Struct_예약매도복합[5] = new Struct_Type_예약매도복합("25%씩-2%/4%/6%/8%", 4, 25.0, 2.0, 25.0, 4.0, 25.0, 6.0, -1.0, 8.0);
			Struct_예약매도복합[6] = new Struct_Type_예약매도복합("25%씩-3%/4%/5%/6%", 4, 25.0, 3.0, 25.0, 4.0, 25.0, 5.0, -1.0, 6.0);
			Struct_예약매도복합[7] = new Struct_Type_예약매도복합("25%씩-3%/5%/7%/9%", 4, 25.0, 3.0, 25.0, 5.0, 25.0, 7.0, -1.0, 9.0);
			Struct_예약매도복합[8] = new Struct_Type_예약매도복합("25%씩-2%/3.5%/5%/7%", 4, 25.0, 2.0, 25.0, 3.5, 25.0, 5.0, -1.0, 7.0);
			Struct_예약매도복합[9] = new Struct_Type_예약매도복합("25%씩-2%/3.5%/7%/10%", 4, 25.0, 2.0, 25.0, 3.5, 25.0, 7.0, -1.0, 10.0);
			Struct_예약매도복합[10] = new Struct_Type_예약매도복합("25%씩-4%/7%/10%/15%", 4, 25.0, 4.0, 25.0, 7.0, 25.0, 10.0, -1.0, 15.0);
			Struct_예약매도복합[11] = new Struct_Type_예약매도복합("25%씩-5%/10%/15%/20%", 4, 25.0, 5.0, 25.0, 10.0, 25.0, 15.0, -1.0, 20.0);
			Struct_예약매도복합[12] = new Struct_Type_예약매도복합("40%-2%/20%씩-4%,7%,10%", 4, 40.0, 2.0, 20.0, 4.0, 20.0, 7.0, -1.0, 10.0);
			Struct_조건동작시간[0] = new Struct_Type_조건동작시간(0, "장시작");
			Struct_조건동작시간[1] = new Struct_Type_조건동작시간(91000, "9시10분");
			Struct_조건동작시간[2] = new Struct_Type_조건동작시간(93000, "9시30분");
			Struct_조건동작시간[3] = new Struct_Type_조건동작시간(100000, "10시");
			Struct_조건동작시간[4] = new Struct_Type_조건동작시간(110000, "11시");
			Struct_조건동작시간[5] = new Struct_Type_조건동작시간(120000, "12시");
			Struct_조건동작시간[6] = new Struct_Type_조건동작시간(130000, "13시");
			Struct_조건동작시간[7] = new Struct_Type_조건동작시간(140000, "14시");
			Struct_조건동작시간[8] = new Struct_Type_조건동작시간(150000, "15시");
			Struct_조건동작시간[9] = new Struct_Type_조건동작시간(999999, "장마감");
			Struct_조건식매수종목수[0] = new Struct_Type_조건식매수종목수(1, "1개");
			Struct_조건식매수종목수[1] = new Struct_Type_조건식매수종목수(3, "3개");
			Struct_조건식매수종목수[2] = new Struct_Type_조건식매수종목수(5, "5개");
			Struct_조건식매수종목수[3] = new Struct_Type_조건식매수종목수(10, "10개");
			Struct_조건식매수종목수[4] = new Struct_Type_조건식매수종목수(15, "15개");
			Struct_조건식매수종목수[5] = new Struct_Type_조건식매수종목수(20, "20개");
			Struct_조건식매수종목수[6] = new Struct_Type_조건식매수종목수(99999, "무제한");
			Struct_리스트초기화시간[0] = new Struct_Type_리스트초기화시간(300, "5분");
			Struct_리스트초기화시간[1] = new Struct_Type_리스트초기화시간(600, "10분");
			Struct_리스트초기화시간[2] = new Struct_Type_리스트초기화시간(1800, "30분");
			Struct_리스트초기화시간[3] = new Struct_Type_리스트초기화시간(3600, "1시간");
			Struct_리스트초기화시간[4] = new Struct_Type_리스트초기화시간(7200, "2시간");
			Struct_리스트초기화시간[5] = new Struct_Type_리스트초기화시간(10800, "3시간");
		}
	}
	public class KOACode
	{
		public struct OrderType
		{
			private string Name;

			private int Code;

			public string name => Name;

			public int code => Code;

			public OrderType(int nCode, string strName)
			{
				Name = strName;
				Code = nCode;
			}
		}

		public struct HogaGb
		{
			private string Name;

			private string Code;

			public string name => Name;

			public string code => Code;

			public HogaGb(string strCode, string strName)
			{
				Code = strCode;
				Name = strName;
			}
		}

		public struct MarketCode
		{
			private string Name;

			private string Code;

			public string name => Name;

			public string code => Code;

			public MarketCode(string strCode, string strName)
			{
				Code = strCode;
				Name = strName;
			}
		}

		public static readonly OrderType[] orderType;

		public static readonly HogaGb[] hogaGb;

		public static readonly MarketCode[] marketCode;

		static KOACode()
		{
			orderType = new OrderType[6];
			hogaGb = new HogaGb[13];
			marketCode = new MarketCode[9];
			orderType[0] = new OrderType(1, "신규매수");
			orderType[1] = new OrderType(2, "신규매도");
			orderType[2] = new OrderType(3, "매수취소");
			orderType[3] = new OrderType(4, "매도취소");
			orderType[4] = new OrderType(5, "매수정정");
			orderType[5] = new OrderType(6, "매도정정");
			hogaGb[0] = new HogaGb("00", "지정가");
			hogaGb[1] = new HogaGb("03", "시장가");
			hogaGb[2] = new HogaGb("05", "조건부지정가");
			hogaGb[3] = new HogaGb("06", "최유리지정가");
			hogaGb[4] = new HogaGb("07", "최우선지정가");
			hogaGb[5] = new HogaGb("10", "지정가IOC");
			hogaGb[6] = new HogaGb("13", "시장가IOC");
			hogaGb[7] = new HogaGb("16", "최유리IOC");
			hogaGb[8] = new HogaGb("20", "지정가FOK");
			hogaGb[9] = new HogaGb("23", "시장가FOK");
			hogaGb[10] = new HogaGb("26", "최유리FOK");
			hogaGb[11] = new HogaGb("61", "시간외단일가매매");
			hogaGb[12] = new HogaGb("81", "시간외종가");
			marketCode[0] = new MarketCode("0", "장내");
			marketCode[1] = new MarketCode("3", "ELW");
			marketCode[2] = new MarketCode("4", "뮤추얼펀드");
			marketCode[3] = new MarketCode("5", "신주인수권");
			marketCode[4] = new MarketCode("6", "리츠");
			marketCode[5] = new MarketCode("8", "ETF");
			marketCode[6] = new MarketCode("9", "하이일드펀드");
			marketCode[7] = new MarketCode("10", "코스닥");
			marketCode[8] = new MarketCode("30", "제3시장");
		}
	}
	internal class Error
	{
		private static string errorMessage;

		private Error()
		{
			errorMessage = "";
		}

		~Error()
		{
			errorMessage = "";
		}

		public static string GetErrorMessage()
		{
			return errorMessage;
		}

		public static bool IsError(int nErrorCode)
		{
			bool result = false;
			switch (nErrorCode)
			{
			case 0:
				errorMessage = "[" + nErrorCode + "] :정상처리";
				result = true;
				break;
			case -100:
				errorMessage = "[" + nErrorCode + "] :사용자정보교환에 실패하였습니다. 잠시 후 다시 시작하여 주십시오.";
				break;
			case -101:
				errorMessage = "[" + nErrorCode + "] :서버 접속 실패";
				break;
			case -102:
				errorMessage = "[" + nErrorCode + "] :버전처리가 실패하였습니다";
				break;
			case -200:
				errorMessage = "[" + nErrorCode + "] :시세조회 과부하";
				break;
			case -201:
				errorMessage = "[" + nErrorCode + "] :REQUEST_INPUT_st Failed";
				break;
			case -202:
				errorMessage = "[" + nErrorCode + "] :요청 전문 작성 실패";
				break;
			case -300:
				errorMessage = "[" + nErrorCode + "] :주문 입력값 오류";
				break;
			case -301:
				errorMessage = "[" + nErrorCode + "] :계좌비밀번호를 입력하십시오.";
				break;
			case -302:
				errorMessage = "[" + nErrorCode + "] :타인계좌는 사용할 수 없습니다.";
				break;
			case -303:
				errorMessage = "[" + nErrorCode + "] :주문가격이 20억원을 초과합니다.";
				break;
			case -304:
				errorMessage = "[" + nErrorCode + "] :주문가격은 50억원을 초과할 수 없습니다.";
				break;
			case -305:
				errorMessage = "[" + nErrorCode + "] :주문수량이 총발행주수의 1%를 초과합니다.";
				break;
			case -306:
				errorMessage = "[" + nErrorCode + "] :주문수량은 총발행주수의 3%를 초과할 수 없습니다";
				break;
			default:
				errorMessage = "[" + nErrorCode + "] :알려지지 않은 오류입니다.";
				break;
			}
			return result;
		}
	}
}
namespace GangPRO
{
	public class Form1 : Form
	{
		public struct Struct_Type_보유종목
		{
			public string s종목코드;

			public string s종목명;

			public string s평가손익;

			public double f수익률;

			public int n매수가;

			public int n현재가;

			public int n보유수량;

			public int n가능수량;

			public bool b보호여부;

			public int n최고가;

			public double f최고가대비;

			public bool b청산여부;
		}

		public struct ConditionList
		{
			public string strConditionName;

			public int nIndex;
		}

		public struct Struct_Type_주문대기리스트
		{
			public int n주문구분;

			public string s종목코드;

			public string s종목명;

			public string s조건명;

			public int n조건인덱스;

			public double f매수호가;

			public int n매수금액;

			public int n매도수량;

			public int n매도단가;

			public string s주문번호;
		}

		public struct Struct_Type_조회대기리스트
		{
			public string sTR코드;

			public string s종목코드;

			public string s종목명;

			public string s계좌번호;
		}

		public struct Struct_Type_예약매도종목
		{
			public bool b예약매도;

			public string s종목코드;

			public int n매수요청량;

			public int n매수체결량;

			public int n매도기준량;

			public int n예약매도_수량;

			public int n예약매도_매도주문가격;
		}

		private delegate void dg시간();

		private delegate void dg종목코드(string s코드);

		private delegate void dg로그출력(string s내용);

		private bool b접속상태;

		private string s실시간등록 = "0";

		private int n계좌_보유종목임시;

		private int n계좌_보유종목수;

		private Struct_Type_보유종목[] Struct_보유종목 = new Struct_Type_보유종목[3000];

		private Struct_Type_보유종목[] Struct_보유종목_임시 = new Struct_Type_보유종목[3000];

		private bool b계좌_자동반복조회;

		private bool b계좌_자동손절;

		private double f계좌_자동손절손실율;

		private bool b계좌_일괄청산;

		private bool b계좌_일괄청산_시간만족;

		private int n일괄청산시간;

		private bool b매도주문단순조회;

		private int n계좌_보호종목수;

		private string[] s계좌_보호종목 = new string[1000];

		private string s현재계좌번호;

		private bool b리스트초기화;

		private int n리스트초기화주기;

		public int nAllStock_Cnt;

		public string[] sAllStock_Name;

		public string[] sAllStock_Code;

		private Struct_Type_Data_Path DataPath;

		public _Struct_GangPRO_Setup setup;

		private int _scrNum = 5000;

		public bool b등록시매수주문;

		public bool b등록시매수주문_자동;

		private IContainer components;

		private MenuStrip menuStrip;

		private ToolStripMenuItem 기본기능ToolStripMenuItem;

		private ToolStripMenuItem 로그인ToolStripMenuItem;

		private ToolStripMenuItem 접속상태ToolStripMenuItem;

		private ToolStripMenuItem 종료ToolStripMenuItem;

		private ToolStripMenuItem 조회기능ToolStripMenuItem;

		private AxKHOpenAPI axKHOpenAPI;

		private Label lbl이름;

		private Label lbl아이디;

		private ListBox lst로그창;

		private Label label_로그창;

		private ToolStripMenuItem 도움말ToolStripMenuItem;

		private ToolStripMenuItem helpToolStripMenuItem;

		private ToolStripMenuItem GangPROToolStripMenuItem;

		private ToolStripMenuItem 초기화ToolStripMenuItem;

		private ComboBox comboBox_계좌번호;

		private TextBox txt주문종목코드;

		private Label label31;

		private Label label32;

		private TextBox txt주문수량;

		private Label label33;

		private TextBox txt주문단가;

		private Label lbl주문종목명;

		private Button btn주문실행;

		private TextBox txt원주문번호;

		private Label label34;

		private Label label38;

		private Label label39;

		private ComboBox comboBox_주문유형;

		private ComboBox comboBox_호가유형;

		private DataGridView dgv호가창;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private Button btn종목조회;

		private Button btn계좌조회;

		private DataGridView dgv계좌;

		private ComboBox comboBox_키움조건식;

		private Label label40;

		private Label label41;

		private TextBox txt계좌잔액;

		private Label label42;

		private ListBox lst체결창;

		private Label label43;

		private OpenFileDialog openFileDialog_조건식;

		private SaveFileDialog saveFileDialog_조건식;

		private GroupBox groupBox_주문;

		private GroupBox groupBox_계좌;

		private GroupBox groupBox_종목정보;

		private Label label2;

		private Label lbl현재시간;

		private GroupBox groupBox_조건식;

		private Button btn조건식매수등록;

		private Button btn조건식매도등록;

		private DataGridView dgv조건식목록;

		private ToolStripMenuItem 종목리스트ToolStripMenuItem;

		private ToolStripMenuItem 종목리스트_지우기ToolStripMenuItem;

		private Label label1;

		private ComboBox comboBox_자동매수호가;

		private ComboBox comboBox_자동매수금액;

		private ComboBox comboBox_예약매도_수익비중;

		private Label label5;

		private ComboBox comboBox_예약매도_수익률;

		private ToolStripMenuItem 주식공동연구소ToolStripMenuItem;

		private Label label4;

		private Button btn계좌_자동손절;

		private Label lbl계좌_자동손절;

		private ComboBox comboBox_계좌손절손실률;

		private Label label6;

		private CheckBox checkBox_예약매도;

		private ComboBox comboBox_예약매도_복합옵션;

		private RadioButton radioButton_예약매도_복합;

		private RadioButton radioButton_예약매도_단순;

		private ToolStripMenuItem 로그ToolStripMenuItem;

		private ToolStripMenuItem 로그_매매로그확인ToolStripMenuItem;

		private Button btn_계좌_비밀번호입력창;

		private Label label3;

		private ComboBox comboBox_계좌일괄청산시간;

		private Label lbl계좌_일괄청산;

		private Label label7;

		private ComboBox comboBox_조건_동작시간_시작;

		private ComboBox comboBox_조건_동작시간_끝;

		private Label label8;

		private Label label9;

		private ComboBox comboBox_조건_매수종목수;

		private ToolStripMenuItem 기능_항상위ToolStripMenuItem;

		private DataGridView dgv조건만족종목;

		private ComboBox comboBox_리스트초기화주기;

		private Button btn리스트_초기화;

		private Label label10;

		private Label lbl리스트_초기화셋팅;

		private CheckBox checkBox_보유종목매수금지;

		private GroupBox groupBox_종목리스트;

		private Label lbl프로그램상태;

		private Label label11;

		private ComboBox comboBox_계좌_보유종목수제한;

		private Button button1;

		private CheckBox checkBox_동일종목주문금지;

		private ToolStripMenuItem 조건식셋팅저장ToolStripMenuItem;

		private ToolStripMenuItem 조건식셋팅로드ToolStripMenuItem;

		private Button btn계좌_분할매도;

		private Label label12;

		private ComboBox comboBox_계좌_분할옵션;

		private ComboBox comboBox_계좌_분할기준;

		private ToolStripMenuItem 로그아웃ToolStripMenuItem;

		private Label label13;

		private TextBox txt추가종목명;

		private Button btn계좌_일괄청산;

		private Button btn_종목리스트추가;

		private Button btn조건식조회등록;

		private DataGridView dgv지수정보;

		private DataGridViewTextBoxColumn Column27;

		private DataGridViewTextBoxColumn Column28;

		private DataGridViewTextBoxColumn Column29;

		private Label lbl오늘날짜;

		private DataGridViewTextBoxColumn Column24;

		private DataGridViewTextBoxColumn Column20;

		private DataGridViewTextBoxColumn Column21;

		private DataGridViewTextBoxColumn Column22;

		private DataGridViewTextBoxColumn Column23;

		private DataGridViewTextBoxColumn Column14;

		private DataGridViewTextBoxColumn Column12;

		private DataGridViewTextBoxColumn Column9;

		private DataGridViewTextBoxColumn Column13;

		private DataGridViewTextBoxColumn Column11;

		private DataGridViewTextBoxColumn Column26;

		private Button button2;

		private ToolStripMenuItem 유료신청방법ToolStripMenuItem;

		private Button btn유료신청방법;

		private CheckBox checkBox_등록시매수주문;

		private ToolStripMenuItem 사용자매뉴얼ToolStripMenuItem;

		private DataGridViewCheckBoxColumn Column16;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column10;

		private DataGridViewTextBoxColumn Column7;

		private DataGridViewTextBoxColumn Column19;

		private DataGridViewTextBoxColumn Column8;

		private DataGridViewTextBoxColumn Column17;

		private DataGridViewTextBoxColumn Column18;

		private DataGridViewTextBoxColumn Column15;

		private DataGridViewTextBoxColumn Column25;

		private Label label15;

		private TextBox txt보유종목누적수익률;

		private int[] n조건_인덱스 = new int[1000];

		private string[] s조건_조건명 = new string[1000];

		private int[] n조건_조회 = new int[1000];

		private string[] s조건_화면번호 = new string[1000];

		private int[] n조건_매수금액 = new int[1000];

		private int[] n조건_매수호가 = new int[1000];

		private double[,] f조건_매수_물량 = new double[1000, 10];

		private double[,] f조건_매수_가격 = new double[1000, 10];

		private int[] n조건_예약매도_수익 = new int[1000];

		private bool[] b조건_예약매도_손절 = new bool[1000];

		private double[,] f조건_예약매도_수익물량 = new double[1000, 10];

		private double[,] f조건_예약매도_수익률 = new double[1000, 10];

		private int[] n조건_동작시간예약_시작시간 = new int[1000];

		private int[] n조건_동작시간예약_마감시간 = new int[1000];

		private int[] n조건_매수주문수 = new int[1000];

		private int[] n조건_매수최대수 = new int[1000];

		private int[] n조건_현재상태 = new int[1000];

		private string[] s조건_전체옵션 = new string[1000];

		private int n조건식등록갯수;

		private bool b매도조건식등록여부;

		private int n매도조건식등록시간;

		private string s실서버모의서버;

		private int n지수Cnt;

		private string[] s지수값 = new string[4];

		private string[] s지수등락률 = new string[4];

		private bool b지수실시간;

		private long n쓰레드cnt;

		private int n주문대기수;

		private int n주문대기시작인덱스;

		private int n주문대기마지막인덱스;

		private Struct_Type_주문대기리스트[] Struct_주문대기리스트 = new Struct_Type_주문대기리스트[100000];

		private bool b조회가능상태;

		private int n조회대기수;

		private int n조회대기시작인덱스;

		private int n조회대기마지막인덱스;

		private Struct_Type_조회대기리스트[] Struct_조회대기리스트 = new Struct_Type_조회대기리스트[100000];

		private int n예약매도_숫자;

		private Struct_Type_예약매도종목[] struct_예약매도리스트 = new Struct_Type_예약매도종목[100000];

		private string s버전 = "V1.13";

		private string s상품구분 = "Free";

		private string s서비스날짜 = "20210630";

		private string s서비스사용자이름 = "공용";

		private int n옵션_계좌손절손실률;

		private int n옵션_계좌일괄청산시간;

		private int n옵션_계좌보유종목수제한;

		private int n옵션_자동매수호가;

		private int n옵션_매수금액;

		private int n옵션_조건식_예약매도비중;

		private int n옵션_단순수익률;

		private int n옵션_복합예약매도옵션;

		private int n옵션_조건식_동작시간;

		private int n옵션_조건_매수종목수;

		private int n옵션_리스트초기화주기;

		private int n조건식등록상한;

		private int n주문쓰레드주기 = 250;

		private string s오늘날짜;

		private string s오늘날짜서버;

		private string s로그저장경로_체결;

		private string s로그저장경로_로그;

		private int n로그Count;

		private string s로그저장경로_리스트;

		private StreamReader sr로그_리스트;

		private string s사용자ID;

		private string s사용자이름;

		private int n프로그램상태;

		private ulong n마지막정상카운트;

		private ushort n시간업데이트주기;

		private Thread TestThread1;

		private Thread Thread_주문대기;

		private int[] nMonth_Day = new int[12]
		{
			31, 28, 31, 30, 31, 30, 31, 31, 30, 31,
			30, 31
		};

		private int n서비스남은날짜;

		private string s호가창종목명;

		private int[] nHoga매도 = new int[11];

		private int[] nHoga매도잔량 = new int[11];

		private int[] nHoga매수 = new int[11];

		private int[] nHoga매수잔량 = new int[11];

		private void f보유종목(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			int repeatCnt = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
			for (int i = 0; i < repeatCnt; i++)
			{
				Struct_보유종목_임시[n계좌_보유종목임시 + i].s종목코드 = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "종목번호").Trim().Substring(1);
				Struct_보유종목_임시[n계좌_보유종목임시 + i].s종목명 = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "종목명").Trim();
				Struct_보유종목_임시[n계좌_보유종목임시 + i].s평가손익 = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "평가손익").Trim();
				Struct_보유종목_임시[n계좌_보유종목임시 + i].n매수가 = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "매입가").Trim());
				Struct_보유종목_임시[n계좌_보유종목임시 + i].n현재가 = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "현재가").Trim());
				Struct_보유종목_임시[n계좌_보유종목임시 + i].n보유수량 = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "보유수량").Trim());
				Struct_보유종목_임시[n계좌_보유종목임시 + i].n가능수량 = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "매매가능수량").Trim());
				Struct_보유종목_임시[n계좌_보유종목임시 + i].b보호여부 = false;
				Struct_보유종목_임시[n계좌_보유종목임시 + i].b청산여부 = false;
				Struct_보유종목_임시[n계좌_보유종목임시 + i].n최고가 = Struct_보유종목_임시[n계좌_보유종목임시 + i].n현재가;
				for (int j = 0; j < n계좌_보유종목수; j++)
				{
					if (Struct_보유종목_임시[n계좌_보유종목임시 + i].s종목코드 == Struct_보유종목[j].s종목코드)
					{
						Struct_보유종목_임시[n계좌_보유종목임시 + i].n최고가 = Struct_보유종목[j].n최고가;
						break;
					}
				}
			}
			n계좌_보유종목임시 += repeatCnt;
			if (e.sPrevNext == "2")
			{
				Add_조회("보유종목", "2", "", ((Control)comboBox_계좌번호).Text);
			}
			else
			{
				f종목리스트();
			}
		}

		private void f종목리스트()
		{
			bool flag = false;
			dgv계좌.Rows.Clear();
			axKHOpenAPI.SetRealRemove("5200", "ALL");
			s실시간등록 = "0";
			n계좌_보유종목수 = n계좌_보유종목임시;
			for (int i = 0; i < n계좌_보유종목수; i++)
			{
				Struct_보유종목[i] = Struct_보유종목_임시[i];
				flag = f보호종목여부체크(Struct_보유종목[i].s종목명);
				Struct_보유종목[i].b보호여부 = flag;
				long num = axKHOpenAPI.SetRealReg("5200", Struct_보유종목[i].s종목코드, "9001;10", s실시간등록);
				s실시간등록 = "1";
				if (num != 0L)
				{
					Logger(Log.로그창, "{0} 실시간 등록이 실패하였습니다", Struct_보유종목[i].s종목명);
				}
				Struct_보유종목[i].f수익률 = f종목수익률계산(Struct_보유종목[i].n매수가, Struct_보유종목[i].n현재가);
				Struct_보유종목[i].f최고가대비 = f종목수익률계산(Struct_보유종목[i].n최고가, Struct_보유종목[i].n현재가);
				dgv계좌.Rows.Add(new object[11]
				{
					flag,
					Struct_보유종목[i].s종목명,
					Struct_보유종목[i].n매수가,
					Struct_보유종목[i].n현재가,
					Struct_보유종목[i].n보유수량,
					Struct_보유종목[i].n가능수량,
					Struct_보유종목[i].f수익률 + "%",
					Struct_보유종목[i].n최고가,
					Struct_보유종목[i].f최고가대비 + "%",
					"ⓧ",
					Struct_보유종목[i].s종목코드
				});
				f수익률색상업데이트(i);
			}
			SetDoNotSort(dgv계좌);
			update보유종목수익률(n계좌_보유종목수, Struct_보유종목);
		}

		private void f주문취소와청산(bool b단순여부, string sCode, string sName, int n보유수량, int n가능수량, string sAcc, int nIndex)
		{
			if (!b단순여부)
			{
				Logger(Log.로그창, "{0} 청산합니다.", sName);
				Struct_보유종목[nIndex].b청산여부 = true;
				if (n보유수량 == n가능수량)
				{
					Add_주문(2, sCode, sName, "", 0, n보유수량, 0);
				}
				else
				{
					Add_조회("체결내역", sCode, "", sAcc);
				}
			}
			else if (n보유수량 != n가능수량)
			{
				Add_조회("체결내역", sCode, "단순", sAcc);
			}
		}

		private void f일괄청산()
		{
			for (int num = n계좌_보유종목수 - 1; num >= 0; num--)
			{
				if (!Struct_보유종목[num].b보호여부 && !Struct_보유종목[num].b청산여부)
				{
					f주문취소와청산(b단순여부: false, Struct_보유종목[num].s종목코드, Struct_보유종목[num].s종목명, Struct_보유종목[num].n보유수량, Struct_보유종목[num].n가능수량, s현재계좌번호, num);
				}
				else
				{
					Logger(Log.로그창, "보호종목 또는 청산 중 입니다.");
				}
			}
			if (!b계좌_자동손절)
			{
				((DataGridViewBand)dgv계좌.Columns[0]).ReadOnly = false;
				((DataGridViewBand)dgv계좌.Columns[0]).DefaultCellStyle.BackColor = Color.White;
				b계좌_자동반복조회 = false;
			}
			f계좌잠금체크();
		}

		private void f계좌별주문체결내역상세(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			int repeatCnt = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
			string[] array = new string[1000];
			string[] array2 = new string[1000];
			string[] array3 = new string[1000];
			string[] array4 = new string[1000];
			string[] array5 = new string[1000];
			int[] array6 = new int[1000];
			int[] array7 = new int[1000];
			int[] array8 = new int[1000];
			int[] array9 = new int[1000];
			string[] array10 = new string[1000];
			int[] array11 = new int[1000];
			int num = 0;
			string[] array12 = new string[100];
			string[] array13 = new string[100];
			string[] array14 = new string[100];
			int[] array15 = new int[100];
			int[] array16 = new int[100];
			bool flag = false;
			for (int i = 0; i < repeatCnt; i++)
			{
				array[i] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "주문번호").Trim();
				if (array[i].Length != 7)
				{
					continue;
				}
				array2[i] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "종목번호").Trim();
				array3[i] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "종목명").Trim();
				array4[i] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "매매구분").Trim();
				array5[i] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "주문구분").Trim();
				array6[i] = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "주문수량").Trim());
				array7[i] = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "확인수량").Trim());
				array8[i] = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "체결수량").Trim());
				array9[i] = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "주문잔량").Trim());
				array10[i] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "원주문").Trim();
				array11[i] = int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, i, "주문단가").Trim());
				string text = "";
				text = ((!(s실서버모의서버 == "모의투자")) ? array5[i].Substring(2, 2) : array5[i].Substring(0, 2));
				if (array9[i] > 0 && text == "매도" && array11[i] != 0)
				{
					if (!b매도주문단순조회)
					{
						string[] array17 = array2[i].Split(new char[1] { 'A' });
						flag = true;
						Add_주문(4, array17[1], array3[i], array[i], 0, array9[i], 0);
					}
					else
					{
						array12[num] = array[i];
						array13[num] = array2[i];
						array14[num] = array3[i];
						array15[num] = array11[i];
						array16[num] = array9[i];
						num++;
					}
				}
			}
			if (flag && !b매도주문단순조회)
			{
				string[] array18 = array2[0].Split(new char[1] { 'A' });
				int num2 = f계좌종목인덱스(array18[1]);
				Add_주문(2, array18[1], array3[0], "", 0, Struct_보유종목[num2].n보유수량, 0);
			}
			if (b매도주문단순조회)
			{
				b매도주문단순조회 = false;
				f보유종목정정취소(num, array12, array13, array14, array15, array16);
			}
			b조회가능상태 = true;
		}

		private int f계좌내종목잔량얻어오기(string s종목코드)
		{
			for (int i = 0; i < n계좌_보유종목수; i++)
			{
				if (Struct_보유종목[i].s종목코드 == s종목코드)
				{
					return Struct_보유종목[i].n가능수량;
				}
			}
			return -1;
		}

		public int f계좌내인덱스얻어오기(string s종목코드)
		{
			for (int i = 0; i < n계좌_보유종목수; i++)
			{
				if (Struct_보유종목[i].s종목코드 == s종목코드)
				{
					return i;
				}
			}
			return -1;
		}

		private void btn_계좌_비밀번호입력창_Click(object sender, EventArgs e)
		{
			if (b접속상태)
			{
				axKHOpenAPI.KOA_Functions("ShowAccountWindow", "");
			}
		}

		private void btn계좌조회_Click(object sender, EventArgs e)
		{
			if (b접속상태)
			{
				Add_조회("잔액", "", "", ((Control)comboBox_계좌번호).Text);
				if (!b계좌_일괄청산 && !b계좌_자동손절)
				{
					f보호종목셋팅();
				}
			}
		}

		private void btn계좌_자동손절_Click(object sender, EventArgs e)
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Invalid comparison between Unknown and I4
			if (!b접속상태)
			{
				return;
			}
			s현재계좌번호 = ((Control)comboBox_계좌번호).Text;
			if (!b계좌_자동손절)
			{
				if ((int)MessageBox.Show("정말 손절을 셋팅하겠습니까?", "주의!!!", (MessageBoxButtons)4) == 6)
				{
					b계좌_자동손절 = true;
					((Control)btn계좌_자동손절).Text = "손절취소";
					((Control)lbl계좌_자동손절).Text = "T";
					((Control)lbl계좌_자동손절).BackColor = Color.Green;
					((Control)comboBox_계좌손절손실률).Enabled = false;
					b계좌_자동반복조회 = true;
					((DataGridViewBand)dgv계좌.Columns[0]).ReadOnly = true;
					((DataGridViewBand)dgv계좌.Columns[0]).DefaultCellStyle.BackColor = Color.Gray;
					f보호종목셋팅();
					f계좌_자동손절손실율 = GCode.Struct_계좌손절손실률[((ListControl)comboBox_계좌손절손실률).SelectedIndex].code1;
					Logger(Log.로그창, "계좌-자동손절이 셋팅되었습니다.");
					((Control)comboBox_계좌번호).Enabled = false;
				}
			}
			else
			{
				b계좌_자동손절 = false;
				((Control)btn계좌_자동손절).Text = "자동손절";
				((Control)lbl계좌_자동손절).Text = "F";
				((Control)lbl계좌_자동손절).BackColor = Color.Red;
				((Control)comboBox_계좌손절손실률).Enabled = true;
				if (!b계좌_일괄청산)
				{
					((DataGridViewBand)dgv계좌.Columns[0]).ReadOnly = false;
					((DataGridViewBand)dgv계좌.Columns[0]).DefaultCellStyle.BackColor = Color.White;
					b계좌_자동반복조회 = false;
				}
				Logger(Log.로그창, "계좌-자동손절이 취소되었습니다.");
				f계좌잠금체크();
			}
		}

		private void btn계좌_일괄청산_Click(object sender, EventArgs e)
		{
			Logger(Log.로그창, "일괄청산");
			if (!b접속상태)
			{
				return;
			}
			s현재계좌번호 = ((Control)comboBox_계좌번호).Text;
			if (!b계좌_일괄청산)
			{
				((DataGridViewBand)dgv계좌.Columns[0]).ReadOnly = true;
				((DataGridViewBand)dgv계좌.Columns[0]).DefaultCellStyle.BackColor = Color.Gray;
				f보호종목셋팅();
				if (((ListControl)comboBox_계좌일괄청산시간).SelectedIndex == 0)
				{
					Logger(Log.로그창, "계좌 내 종목을 바로 청산합니다.");
					f일괄청산();
					return;
				}
				b계좌_일괄청산 = true;
				((Control)btn계좌_일괄청산).Text = "해제";
				((Control)lbl계좌_일괄청산).Text = "T";
				((Control)lbl계좌_일괄청산).BackColor = Color.Green;
				((Control)comboBox_계좌일괄청산시간).Enabled = false;
				n일괄청산시간 = GCode.Struct_계좌일괄청산시간[((ListControl)comboBox_계좌일괄청산시간).SelectedIndex].code1;
				Logger(Log.로그창, " {0}에 일괄청산이 설정되었습니다.", GCode.Struct_계좌일괄청산시간[((ListControl)comboBox_계좌일괄청산시간).SelectedIndex].name);
				((Control)comboBox_계좌번호).Enabled = false;
				b계좌_자동반복조회 = true;
			}
			else
			{
				b계좌_일괄청산 = false;
				((Control)btn계좌_일괄청산).Text = "설정";
				((Control)lbl계좌_일괄청산).Text = "F";
				((Control)lbl계좌_일괄청산).BackColor = Color.Red;
				((Control)comboBox_계좌일괄청산시간).Enabled = true;
				if (!b계좌_자동손절)
				{
					((DataGridViewBand)dgv계좌.Columns[0]).ReadOnly = false;
					((DataGridViewBand)dgv계좌.Columns[0]).DefaultCellStyle.BackColor = Color.White;
					b계좌_자동반복조회 = false;
				}
				Logger(Log.로그창, "일괄청산 설정이 해제되었습니다.");
				f계좌잠금체크();
			}
		}

		private void btn계좌_분할매도_Click(object sender, EventArgs e)
		{
			Logger(Log.로그창, "보유종목을 {0} 대비 {1} 매도주문", ((Control)comboBox_계좌_분할기준).Text, ((Control)comboBox_계좌_분할옵션).Text);
			int selectedIndex = ((ListControl)comboBox_계좌_분할옵션).SelectedIndex;
			double[] array = new double[10];
			double[] array2 = new double[10];
			int n복합도 = GCode.Struct_예약매도복합[selectedIndex].n복합도;
			array[0] = GCode.Struct_예약매도복합[selectedIndex].n물량1;
			array2[0] = GCode.Struct_예약매도복합[selectedIndex].f수익률1 / 100.0;
			array[1] = GCode.Struct_예약매도복합[selectedIndex].n물량2;
			array2[1] = GCode.Struct_예약매도복합[selectedIndex].f수익률2 / 100.0;
			array[2] = GCode.Struct_예약매도복합[selectedIndex].n물량3;
			array2[2] = GCode.Struct_예약매도복합[selectedIndex].f수익률3 / 100.0;
			array[3] = GCode.Struct_예약매도복합[selectedIndex].n물량4;
			array2[3] = GCode.Struct_예약매도복합[selectedIndex].f수익률4 / 100.0;
			for (int i = 0; i < n계좌_보유종목수; i++)
			{
				if (Struct_보유종목[i].n가능수량 > 0 && !bool.Parse(dgv계좌[0, i].Value.ToString()))
				{
					int num = Struct_보유종목[i].n가능수량;
					int nPrice = 0;
					if (((ListControl)comboBox_계좌_분할기준).SelectedIndex == 0)
					{
						nPrice = Struct_보유종목[i].n현재가;
					}
					if (((ListControl)comboBox_계좌_분할기준).SelectedIndex == 1)
					{
						nPrice = Struct_보유종목[i].n매수가;
					}
					string s종목코드 = Struct_보유종목[i].s종목코드;
					string s종목명 = Struct_보유종목[i].s종목명;
					int num2 = 0;
					for (int j = 0; j < n복합도; j++)
					{
						num2 = ((array[j] != -1.0) ? ((int)((double)Struct_보유종목[i].n가능수량 * array[j] / 100.0)) : num);
						num -= num2;
						Add_주문(2, s종목코드, s종목명, "", 0, num2, f호가근사치계산(0, nPrice, array2[j]));
					}
				}
			}
		}

		private void dgv계좌_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Invalid comparison between Unknown and I4
			if (e.ColumnIndex < 1 || e.RowIndex < 0)
			{
				return;
			}
			Add_조회("호가창", Struct_보유종목[e.RowIndex].s종목코드, "", "");
			((ListControl)comboBox_주문유형).SelectedIndex = 1;
			((Control)txt주문수량).Text = dgv계좌[4, e.RowIndex].Value.ToString();
			if (e.ColumnIndex == 9 && (int)MessageBox.Show(Struct_보유종목[e.RowIndex].s종목명 + ": 청산하시겠습니까?", "주의!!!", (MessageBoxButtons)4) == 6)
			{
				if (!Struct_보유종목[e.RowIndex].b보호여부 && !Struct_보유종목[e.RowIndex].b청산여부)
				{
					f주문취소와청산(b단순여부: false, Struct_보유종목[e.RowIndex].s종목코드, Struct_보유종목[e.RowIndex].s종목명, Struct_보유종목[e.RowIndex].n보유수량, Struct_보유종목[e.RowIndex].n가능수량, ((Control)comboBox_계좌번호).Text, e.RowIndex);
				}
				else
				{
					Logger(Log.로그창, "보호종목 또는 청산 중 입니다.");
				}
			}
		}

		private void dgv계좌_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Invalid comparison between Unknown and I4
			if ((int)((MouseEventArgs)e).Button == 2097152 && e.ColumnIndex >= 0 && e.RowIndex >= 0)
			{
				dgv계좌.CurrentCell = dgv계좌[e.ColumnIndex, e.RowIndex];
				f주문취소와청산(b단순여부: true, Struct_보유종목[e.RowIndex].s종목코드, Struct_보유종목[e.RowIndex].s종목명, Struct_보유종목[e.RowIndex].n보유수량, Struct_보유종목[e.RowIndex].n가능수량, ((Control)comboBox_계좌번호).Text, e.RowIndex);
			}
		}

		private void f보유종목정정취소(int nCnt, string[] sNo, string[] sCode, string[] sName, int[] nPriece, int[] nQty)
		{
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			if (nCnt != 0)
			{
				ContextMenu val = new ContextMenu();
				string[] array = sCode[0].Split(new char[1] { 'A' });
				((Menu)val).Name = array[1];
				MenuItem[] array2 = (MenuItem[])(object)new MenuItem[nCnt];
				MenuItem[,] array3 = new MenuItem[nCnt, 2];
				for (int i = 0; i < nCnt; i++)
				{
					array2[i] = new MenuItem();
					array2[i].Text = nPriece[i] + "원, " + nQty[i] + "주";
					((Menu)array2[i]).Name = sNo[i];
					array3[i, 0] = new MenuItem();
					array3[i, 0].Text = "취소";
					array3[i, 1] = new MenuItem();
					array3[i, 1].Text = "정정:시장가 매도";
					array3[i, 0].Click += mmm_clicked;
					array3[i, 1].Click += mmm_clicked;
					((Menu)array2[i]).MenuItems.Add(array3[i, 0]);
					((Menu)array2[i]).MenuItems.Add(array3[i, 1]);
					((Menu)val).MenuItems.Add(array2[i]);
				}
				Point point = ((Control)dgv계좌).PointToClient(Control.MousePosition);
				val.Show((Control)(object)dgv계좌, point);
			}
		}

		private void mmm_clicked(object sender, EventArgs e)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			MenuItem val = (MenuItem)((sender is MenuItem) ? sender : null);
			MenuItem val2 = (MenuItem)val.Parent;
			string name = ((Menu)val2).Name;
			string name2 = val2.Parent.Name;
			_ = val2.Index;
			int index = val.Index;
			int n수량 = int.Parse(val2.Text.Split(new char[1] { ',' })[1].Split(new char[1] { '주' })[0]);
			switch (index)
			{
			case 0:
				Add_주문(4, name2, "", name, 0, n수량, 0);
				break;
			case 1:
				Add_주문(4, name2, "", name, 0, n수량, 0);
				Add_주문(2, name2, "", "", 0, n수량, 0);
				break;
			}
		}

		private void f보호종목셋팅()
		{
			n계좌_보호종목수 = 0;
			for (int i = 0; i < dgv계좌.Rows.Count; i++)
			{
				Struct_보유종목[i].b보호여부 = false;
				if (bool.Parse(dgv계좌[0, i].Value.ToString()))
				{
					s계좌_보호종목[n계좌_보호종목수] = dgv계좌[1, i].Value.ToString();
					n계좌_보호종목수++;
					Struct_보유종목[i].b보호여부 = true;
				}
			}
		}

		private bool f보호종목여부체크(string sName)
		{
			for (int i = 0; i < n계좌_보호종목수; i++)
			{
				if (sName == s계좌_보호종목[i])
				{
					return true;
				}
			}
			return false;
		}

		private void f계좌잠금체크()
		{
			if (dgv조건식목록.Rows.Count == 0 && !b계좌_일괄청산 && !b계좌_자동손절)
			{
				((Control)comboBox_계좌번호).Enabled = true;
			}
		}

		private void Update_보유종목_체결(string sType, string sCode, string sName, string sPrice, string sQty)
		{
			int num = f계좌종목인덱스(sCode);
			int num2 = f계좌종목dgv인덱스(sCode);
			if (sPrice == "" || sQty == "")
			{
				return;
			}
			int num3 = int.Parse(sPrice);
			int num4 = int.Parse(sQty);
			if (num != num2)
			{
				Logger(Log.로그창, "-----보유종목 인덱스 불일치!! 보유종목 조회");
				Add_조회("보유종목", "", "", s현재계좌번호);
			}
			else if (sType == "1" && num != -1 && num2 != -1)
			{
				if (Struct_보유종목[num].n보유수량 == num4)
				{
					dgv계좌.Rows.RemoveAt(num2);
					n계좌_보유종목수--;
					for (int i = num; i < n계좌_보유종목수; i++)
					{
						Struct_보유종목[i] = Struct_보유종목[i + 1];
					}
				}
				else if (Struct_보유종목[num].n보유수량 > num4)
				{
					Struct_보유종목[num].n보유수량 = Struct_보유종목[num].n보유수량 - num4;
					dgv계좌[4, num2].Value = Struct_보유종목[num].n보유수량;
				}
				else if (Struct_보유종목[num].n보유수량 < num4)
				{
					Logger(Log.로그창, "-----보유 수량 오류!! 보유종목 조회");
					Add_조회("보유종목", "", "", s현재계좌번호);
				}
			}
			else
			{
				if (!(sType == "2"))
				{
					return;
				}
				if (num == -1)
				{
					long num5 = axKHOpenAPI.SetRealReg("5200", sCode, "9001;10", s실시간등록);
					s실시간등록 = "1";
					if (num5 != 0L)
					{
						Logger(Log.로그창, "{0} 실시간 등록이 실패하였습니다", sName);
					}
					double num6 = f종목수익률계산(num3, num3);
					Struct_보유종목[n계좌_보유종목수].s종목코드 = sCode;
					Struct_보유종목[n계좌_보유종목수].s종목명 = sName;
					Struct_보유종목[n계좌_보유종목수].s평가손익 = "0";
					Struct_보유종목[n계좌_보유종목수].n매수가 = num3;
					Struct_보유종목[n계좌_보유종목수].n현재가 = num3;
					Struct_보유종목[n계좌_보유종목수].n보유수량 = num4;
					Struct_보유종목[n계좌_보유종목수].n가능수량 = num4;
					Struct_보유종목[n계좌_보유종목수].f수익률 = num6;
					Struct_보유종목[n계좌_보유종목수].n최고가 = num3;
					Struct_보유종목[n계좌_보유종목수].f최고가대비 = num6;
					Struct_보유종목[n계좌_보유종목수].b보호여부 = false;
					Struct_보유종목[n계좌_보유종목수].b청산여부 = false;
					n계좌_보유종목수++;
					dgv계좌.Rows.Add(new object[11]
					{
						false,
						sName,
						num3,
						num3,
						num4,
						num4,
						num6 + "%",
						num3,
						num6 + "%",
						"ⓧ",
						sCode
					});
				}
				else if (num >= 0)
				{
					int n매수가 = (Struct_보유종목[num].n보유수량 * Struct_보유종목[num].n매수가 + num3 * num4) / (Struct_보유종목[num].n보유수량 + num4);
					Struct_보유종목[num].n매수가 = n매수가;
					Struct_보유종목[num].n현재가 = num3;
					Struct_보유종목[num].n보유수량 = Struct_보유종목[num].n보유수량 + num4;
					Struct_보유종목[num].n가능수량 = Struct_보유종목[num].n가능수량 + num4;
					Struct_보유종목[num].f수익률 = f종목수익률계산(n매수가, num3);
					if (num3 > Struct_보유종목[num].n최고가)
					{
						Struct_보유종목[num].n최고가 = num3;
					}
					Struct_보유종목[num].f최고가대비 = f종목수익률계산(Struct_보유종목[num].n최고가, num3);
					dgv계좌[2, num2].Value = Struct_보유종목[num].n매수가;
					dgv계좌[3, num2].Value = Struct_보유종목[num].n현재가;
					dgv계좌[4, num2].Value = Struct_보유종목[num].n보유수량;
					dgv계좌[5, num2].Value = Struct_보유종목[num].n가능수량;
					dgv계좌[6, num2].Value = Struct_보유종목[num].f수익률;
					dgv계좌[7, num2].Value = Struct_보유종목[num].n최고가;
					dgv계좌[8, num2].Value = Struct_보유종목[num].f최고가대비;
					f수익률색상업데이트(num2);
				}
			}
		}

		private void Update_보유종목_가격(string s종목코드, int n가격원값)
		{
			string masterCodeName = axKHOpenAPI.GetMasterCodeName(s종목코드);
			int num = f계좌종목인덱스(s종목코드);
			int num2 = f계좌종목dgv인덱스(s종목코드);
			int num3 = Math.Abs(n가격원값);
			if (num != num2)
			{
				Logger(Log.로그창, "-------{0} {1} {2} {3}/{4} - 보유종목 인덱스 불일치!! 보유종목 조회 필요", masterCodeName, dgv계좌[1, 3].Value, Struct_보유종목[3].s종목명, num, num2);
			}
			else if (num >= 0)
			{
				Struct_보유종목[num].n현재가 = num3;
				dgv계좌[3, num2].Value = num3;
				f현재가색상업데이트(num2, n가격원값);
				if (num3 > Struct_보유종목[num].n최고가)
				{
					Struct_보유종목[num].n최고가 = num3;
					dgv계좌[7, num2].Value = num3;
				}
				double num4 = f종목수익률계산(Struct_보유종목[num].n매수가, num3);
				Struct_보유종목[num].f수익률 = num4;
				dgv계좌[6, num2].Value = num4 + "%";
				f수익률색상업데이트(num2);
				double num5 = f종목수익률계산(Struct_보유종목[num].n최고가, num3);
				Struct_보유종목[num].f최고가대비 = num5;
				dgv계좌[8, num2].Value = num5 + "%";
				if (b계좌_자동손절 && !Struct_보유종목[num].b보호여부 && !Struct_보유종목[num].b청산여부 && (num4 < f계좌_자동손절손실율 || (f계좌_자동손절손실율 < -100.0 && num5 < f계좌_자동손절손실율 + 100.0)))
				{
					Logger(Log.로그창, "{0} 손절", Struct_보유종목[num].s종목명);
					f주문취소와청산(b단순여부: false, s종목코드, Struct_보유종목[num].s종목명, Struct_보유종목[num].n보유수량, Struct_보유종목[num].n가능수량, s현재계좌번호, num);
				}
			}
		}

		private double f종목수익률계산(int n매수가, int n현재가)
		{
			double result = 0.0;
			if (n매수가 != 0)
			{
				double num = n현재가;
				double num2 = n매수가;
				if (s실서버모의서버 == "모의투자")
				{
					result = (num * 99.4 - num2 * 100.35) / num2;
					result = (double)(int)(result * 100.0) / 100.0;
				}
				else
				{
					result = (num * 99.755 - num2 * 100.015) / num2;
					result = (double)(int)(result * 100.0) / 100.0;
				}
			}
			return result;
		}

		private void f수익률색상업데이트(int nIndex)
		{
			if (Struct_보유종목[nIndex].f수익률 > 0.0)
			{
				dgv계좌[6, nIndex].Style.ForeColor = Color.Red;
			}
			else
			{
				dgv계좌[6, nIndex].Style.ForeColor = Color.Blue;
			}
		}

		private void f현재가색상업데이트(int nIndex, int n값)
		{
			if (n값 >= 0)
			{
				dgv계좌[3, nIndex].Style.ForeColor = Color.Red;
			}
			else
			{
				dgv계좌[3, nIndex].Style.ForeColor = Color.Blue;
			}
		}

		private int f계좌종목인덱스(string sCode)
		{
			for (int i = 0; i < n계좌_보유종목수; i++)
			{
				if (sCode == Struct_보유종목[i].s종목코드)
				{
					return i;
				}
			}
			return -1;
		}

		private int f계좌종목dgv인덱스(string sCode)
		{
			for (int i = 0; i < dgv계좌.Rows.Count; i++)
			{
				if (sCode == dgv계좌[10, i].Value.ToString())
				{
					return i;
				}
			}
			return -1;
		}

		private string f문자열to돈(string s입력)
		{
			string text = "";
			while (s입력.Length > 3)
			{
				text = "," + s입력.Substring(s입력.Length - 3) + text;
				s입력 = s입력.Substring(0, s입력.Length - 3);
			}
			return s입력 + text;
		}

		public double update보유종목수익률(int nCnt, Struct_Type_보유종목[] struct_temp)
		{
			double num = 0.0;
			for (int i = 0; i < nCnt; i++)
			{
				num += struct_temp[i].f수익률;
			}
			((Control)txt보유종목누적수익률).Text = $"{num:#0.00} %";
			if (num >= 0.0)
			{
				((Control)txt보유종목누적수익률).ForeColor = Color.Red;
			}
			else
			{
				((Control)txt보유종목누적수익률).ForeColor = Color.Blue;
			}
			return num;
		}

		private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			if (!b접속상태 && axKHOpenAPI.CommConnect() != 0)
			{
				MessageBox.Show("로그인창 열기 실패!");
			}
		}

		private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisconnectAllRealData();
			axKHOpenAPI.CommTerminate();
			b접속상태 = false;
			Logger(Log.로그창, "로그아웃");
			Application.Exit();
		}

		private void 접속상태ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (axKHOpenAPI.GetConnectState() == 0)
			{
				Logger(Log.로그창, "Open API 연결 : 미연결");
				return;
			}
			Logger(Log.로그창, "Open API 연결 : 연결중");
			Logger(Log.로그창, "Count = {0}, 조회가능여부 = {1}", n쓰레드cnt, b조회가능상태);
		}

		private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void 종목리스트_지우기ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dgv조건만족종목.Rows.Clear();
		}

		private void 초기화ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lst로그창.Items.Clear();
			lst체결창.Items.Clear();
			Logger(Log.로그창, "초기화...");
			_scrNum = 5001;
			int count = dgv조건식목록.Rows.Count;
			for (int i = 0; i < count; i++)
			{
				int num = int.Parse(dgv조건식목록[0, 0].Value.ToString());
				f조건_실시간중지(s조건_화면번호[num], s조건_조건명[num], num);
				Delay(300);
			}
			dgv조건만족종목.Rows.Clear();
			if (b계좌_자동손절)
			{
				btn계좌_자동손절_Click(null, null);
			}
			if (b계좌_일괄청산)
			{
				btn계좌_일괄청산_Click(null, null);
			}
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			((Form)new HelpForm()).ShowDialog();
		}

		private void GangPROToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			((Form)new GangPRO(s버전, s상품구분, s서비스날짜, s서비스사용자이름, n서비스남은날짜.ToString())).ShowDialog();
		}

		private void 유료신청방법ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://cafe.naver.com/publicstock/1135");
		}

		private void btn유료신청방법_Click(object sender, EventArgs e)
		{
			Process.Start("https://cafe.naver.com/publicstock/1135");
		}

		private void 주식공동연구소ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("http://cafe.naver.com/publicstock");
		}

		private void 로그_매매로그확인ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			((Form)new LogForm()).ShowDialog();
		}

		private void 기능_항상위ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Form.ActiveForm.TopMost)
			{
				Form.ActiveForm.TopMost = false;
				기능_항상위ToolStripMenuItem.Checked = false;
			}
			else
			{
				Form.ActiveForm.TopMost = true;
				기능_항상위ToolStripMenuItem.Checked = true;
			}
		}

		public void Logger(Log type, string format, params object[] args)
		{
			string text = string.Format(format, args);
			text = "[" + ((Control)lbl현재시간).Text + "]" + text;
			switch (type)
			{
			case Log.로그창:
				lst로그창.Items.Add((object)text);
				((ListControl)lst로그창).SelectedIndex = lst로그창.Items.Count - 1;
				FileWrite(s로그저장경로_로그, "[{0:X4}]{1}\n", n로그Count, text);
				n로그Count++;
				break;
			case Log.체결장:
				lst체결창.Items.Add((object)text);
				((ListControl)lst체결창).SelectedIndex = lst체결창.Items.Count - 1;
				break;
			}
		}

		public string getString(string format, params object[] args)
		{
			return string.Format(format, args);
		}

		public void calc_remain_day(string s오늘, string s마감)
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			if (int.Parse(s오늘날짜) > int.Parse(s오늘))
			{
				s오늘 = s오늘날짜;
			}
			if (int.Parse(s오늘) > int.Parse(s마감))
			{
				MessageBox.Show("서비스날짜 종료(~" + s마감 + ")", "알림");
				Application.Exit();
				return;
			}
			int num = int.Parse(s오늘.Substring(0, 4));
			int num2 = int.Parse(s오늘.Substring(4, 2));
			int num3 = int.Parse(s오늘.Substring(6, 2));
			int num4 = int.Parse(s마감.Substring(0, 4));
			int num5 = int.Parse(s마감.Substring(4, 2));
			int num6 = int.Parse(s마감.Substring(6, 2));
			int num7 = 0;
			int num8 = 0;
			num7 = (num4 - num) * 365;
			for (int i = 0; i < num5 - 1; i++)
			{
				num7 += nMonth_Day[i];
			}
			num7 += num6;
			for (int j = 0; j < num2 - 1; j++)
			{
				num8 += nMonth_Day[j];
			}
			num8 += num3;
			n서비스남은날짜 = num7 - num8;
			if (n서비스남은날짜 < 7)
			{
				MessageBox.Show("GangPRO 서비스 마감 " + n서비스남은날짜 + "일 전입니다.", "알림");
			}
		}

		private static DateTime Delay(int MS)
		{
			DateTime now = DateTime.Now;
			TimeSpan value = new TimeSpan(0, 0, 0, 0, MS);
			DateTime dateTime = now.Add(value);
			while (dateTime >= now)
			{
				Application.DoEvents();
				now = DateTime.Now;
			}
			return DateTime.Now;
		}

		private string GetScrNum()
		{
			if (_scrNum < 5200)
			{
				_scrNum++;
			}
			else
			{
				_scrNum = 5001;
			}
			return _scrNum.ToString();
		}

		private void FileWrite(string s파일명, string format, params object[] args)
		{
			string contents = string.Format(format, args);
			File.AppendAllText(s파일명, contents, Encoding.Unicode);
		}

		private void SetDoNotSort(DataGridView dgv)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			foreach (DataGridViewColumn item in (BaseCollection)dgv.Columns)
			{
				item.SortMode = (DataGridViewColumnSortMode)0;
			}
		}

		private void f종목리스트초기화()
		{
			dgv조건만족종목.Rows.Clear();
		}

		private void btn리스트_초기화_Click(object sender, EventArgs e)
		{
			if (!b리스트초기화)
			{
				b리스트초기화 = true;
				((Control)btn리스트_초기화).Text = "취소";
				((Control)lbl리스트_초기화셋팅).Text = "T";
				((Control)lbl리스트_초기화셋팅).BackColor = Color.Green;
				n리스트초기화주기 = GCode.Struct_리스트초기화시간[((ListControl)comboBox_리스트초기화주기).SelectedIndex].Value;
				((Control)comboBox_리스트초기화주기).Enabled = false;
				Logger(Log.로그창, "리스트 초기화 설정되었습니다.");
			}
			else
			{
				b리스트초기화 = false;
				((Control)btn리스트_초기화).Text = "설정";
				((Control)lbl리스트_초기화셋팅).Text = "F";
				((Control)lbl리스트_초기화셋팅).BackColor = Color.Red;
				((Control)comboBox_리스트초기화주기).Enabled = true;
				Logger(Log.로그창, "리스트 초기화 취소되었습니다.");
			}
		}

		private void dgv조건만족종목_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Invalid comparison between Unknown and I4
			if ((e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2) && e.RowIndex >= 0)
			{
				Add_조회("호가창", dgv조건만족종목[1, e.RowIndex].Value.ToString(), dgv조건만족종목[2, e.RowIndex].Value.ToString(), "");
			}
			if (e.ColumnIndex == 4 && e.RowIndex >= 0)
			{
				dgv조건만족종목.Rows.RemoveAt(e.RowIndex);
			}
			if (e.ColumnIndex == 5 && e.RowIndex >= 0)
			{
				string sCode = dgv조건만족종목[1, e.RowIndex].Value.ToString();
				string text = dgv조건만족종목[2, e.RowIndex].Value.ToString();
				if ((int)MessageBox.Show(text + " : 수동 매수하시겠습니까?", "주의!!!", (MessageBoxButtons)4) == 6)
				{
					n조건_조회[999] = 2;
					f조건_리스트관리(1, 999, "직접입력");
					Add_조회("호가창", sCode, text, "");
					Add_주문(1, sCode, text, "직접입력", 999, 0, 0);
				}
			}
		}

		private void f조건만족종목리스트(bool b실시간, string sCode, string s조건인덱스, string s조건명)
		{
			int rowCount = dgv조건만족종목.RowCount;
			string masterCodeName = axKHOpenAPI.GetMasterCodeName(sCode);
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < rowCount; i++)
			{
				if (sCode == dgv조건만족종목[1, i].Value.ToString() && s조건명 == dgv조건만족종목[3, i].Value.ToString())
				{
					flag = true;
				}
				else if (sCode == dgv조건만족종목[1, i].Value.ToString())
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				return;
			}
			string text = ((Control)lbl현재시간).Text;
			if (!b실시간)
			{
				text = "등록 시";
			}
			SetDoNotSort(dgv조건만족종목);
			if (b실시간)
			{
				Logger(Log.로그창, "[{0}] - <{1}> 조건 실시간 만족", masterCodeName, s조건명);
			}
			int num = int.Parse(s조건인덱스);
			if (n조건_조회[num] == 1)
			{
				dgv조건만족종목.Rows.Add(new object[6] { text, sCode, masterCodeName, s조건명, "ⓧ", "ⓥ" });
				FileWrite(s로그저장경로_리스트, "{0}\t{1}\t{2}\t{3}\n", text, sCode, masterCodeName, s조건명);
			}
			if (n조건_조회[num] == 2)
			{
				int num2 = int.Parse(DateTime.Now.ToString("HHmmss"));
				if (n조건_매수주문수[num] < n조건_매수최대수[num] && num2 >= n조건_동작시간예약_시작시간[num] && num2 <= n조건_동작시간예약_마감시간[num])
				{
					dgv조건만족종목.Rows.Add(new object[6] { text, sCode, masterCodeName, s조건명, "ⓧ", "ⓥ" });
					FileWrite(s로그저장경로_리스트, "{0}\t{1}\t{2}\t{3}\n", text, sCode, masterCodeName, s조건명);
					int num3 = f계좌종목인덱스(sCode);
					if (checkBox_보유종목매수금지.Checked && num3 >= 0)
					{
						Logger(Log.로그창, "{0} - 보유상태로 매수 안함", masterCodeName);
					}
					else if (n계좌_보유종목수 >= GCode.Struct_보유종목수제한[((ListControl)comboBox_계좌_보유종목수제한).SelectedIndex].Value)
					{
						Logger(Log.로그창, "{0} - 계좌 보유종목수 제한으로 매수 안함", masterCodeName);
					}
					else if (checkBox_동일종목주문금지.Checked && flag2)
					{
						Logger(Log.로그창, "{0} - 다른 조건식에 의해 이미 만족된 종목", masterCodeName);
					}
					else if (b실시간 || b등록시매수주문)
					{
						Add_조회("호가창", sCode, masterCodeName, "");
						Add_주문(1, sCode, masterCodeName, s조건명, num, 0, 0);
					}
				}
				else if (n조건_매수주문수[num] >= n조건_매수최대수[num])
				{
					Logger(Log.로그창, "매수 종목 수 제한 : [{0}] 주문 안됨. {1} 조건식 자동 중지", masterCodeName, s조건_조건명[num]);
					f조건_실시간중지(s조건_화면번호[num], s조건_조건명[num], num);
				}
				else if (num2 < n조건_동작시간예약_시작시간[num])
				{
					Logger(Log.로그창, "조건식 동작 시간 설정으로 [{0}] 주문 안됨.", masterCodeName);
				}
				else if (num2 > n조건_동작시간예약_마감시간[num])
				{
					Logger(Log.로그창, "조건식 동작 시간 설정으로 [{0}] 주문 안됨. {1} 조건식 자동 중지", masterCodeName, s조건_조건명[num]);
					f조건_실시간중지(s조건_화면번호[num], s조건_조건명[num], num);
				}
			}
			if (n조건_조회[num] != 3)
			{
				return;
			}
			dgv조건만족종목.Rows.Add(new object[6] { text, sCode, masterCodeName, s조건명, "ⓧ", "" });
			FileWrite(s로그저장경로_리스트, "{0}\t{1}\t{2}\t{3}\n", text, sCode, masterCodeName, s조건명);
			int num4 = f계좌내인덱스얻어오기(sCode);
			if (num4 >= 0)
			{
				if (Struct_보유종목[num4].s종목명 == masterCodeName)
				{
					Logger(Log.로그창, "[자동매도] {0} - 전량 매도", masterCodeName);
					Console.WriteLine("{0} - {1}", masterCodeName, dgv계좌[0, num4].Value);
					if (!bool.Parse(dgv계좌[0, num4].Value.ToString()))
					{
						f주문취소와청산(b단순여부: false, sCode, masterCodeName, Struct_보유종목[num4].n보유수량, Struct_보유종목[num4].n가능수량, ((Control)comboBox_계좌번호).Text, num4);
					}
				}
				else
				{
					Logger(Log.로그창, "[자동매도] {0} - 종목 불일치", masterCodeName);
				}
			}
			else
			{
				Logger(Log.로그창, "[자동매도] {0} - 종목 존재 안함", masterCodeName);
			}
		}

		public void getAllStock()
		{
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			string codeListByMarket = axKHOpenAPI.GetCodeListByMarket("0");
			string codeListByMarket2 = axKHOpenAPI.GetCodeListByMarket("10");
			string[] array = (codeListByMarket + codeListByMarket2).Split(new char[1] { ';' });
			int num = (nAllStock_Cnt = array.Length - 1);
			sAllStock_Code = new string[num];
			sAllStock_Name = new string[num];
			for (int i = 0; i < num; i++)
			{
				sAllStock_Code[i] = array[i];
				sAllStock_Name[i] = axKHOpenAPI.GetMasterCodeName(array[i]);
			}
			AutoCompleteStringCollection val = new AutoCompleteStringCollection();
			val.AddRange(sAllStock_Name);
			txt추가종목명.AutoCompleteCustomSource = val;
			txt추가종목명.AutoCompleteMode = (AutoCompleteMode)3;
			txt추가종목명.AutoCompleteSource = (AutoCompleteSource)64;
		}

		public int getStockIndexByName(string sName)
		{
			for (int i = 0; i < nAllStock_Cnt; i++)
			{
				if (sName == sAllStock_Name[i])
				{
					return i;
				}
			}
			return -1;
		}

		public void writeSetup(string sPath)
		{
			try
			{
				StreamWriter streamWriter = new StreamWriter(sPath);
				streamWriter.WriteLine("{0}\t{1}", "nAccount", ((ListControl)comboBox_계좌번호).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sAccount", comboBox_계좌번호.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nLosscut", ((ListControl)comboBox_계좌손절손실률).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sLosscut", comboBox_계좌손절손실률.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nAutoSell", ((ListControl)comboBox_계좌일괄청산시간).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sAutoSell", comboBox_계좌일괄청산시간.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nDivisionSell_1", ((ListControl)comboBox_계좌_분할기준).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sDivisionSell_1", comboBox_계좌_분할기준.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nDivisionSell_2", ((ListControl)comboBox_계좌_분할옵션).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sDivisionSell_2", comboBox_계좌_분할옵션.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nCondition", ((ListControl)comboBox_키움조건식).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sCondition", comboBox_키움조건식.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nBuyOpt_1", ((ListControl)comboBox_자동매수호가).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sBuyOpt_1", comboBox_자동매수호가.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nBuyOpt_2", ((ListControl)comboBox_자동매수금액).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sBuyOpt_2", comboBox_자동매수금액.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "bSell", checkBox_예약매도.Checked);
				streamWriter.WriteLine("{0}\t{1}", "bSell_Simple", radioButton_예약매도_단순.Checked);
				streamWriter.WriteLine("{0}\t{1}", "nSell_Simple_Opt1", ((ListControl)comboBox_예약매도_수익비중).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sSell_Simple_Opt1", comboBox_예약매도_수익비중.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nSell_Simple_Opt2", ((ListControl)comboBox_예약매도_수익률).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sSell_Simple_Opt2", comboBox_예약매도_수익률.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nSell_Complex_Opt", ((ListControl)comboBox_예약매도_복합옵션).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sSell_Complex_Opt", comboBox_예약매도_복합옵션.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nBuyingTime1", ((ListControl)comboBox_조건_동작시간_시작).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sBuyingTime1", comboBox_조건_동작시간_시작.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "nBuyingTime2", ((ListControl)comboBox_조건_동작시간_끝).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "sBuyingTime2", comboBox_조건_동작시간_끝.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "n매수종목제한", ((ListControl)comboBox_조건_매수종목수).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "s매수종목제한", comboBox_조건_매수종목수.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "n종목리스트_초기화주기", ((ListControl)comboBox_리스트초기화주기).SelectedIndex);
				streamWriter.WriteLine("{0}\t{1}", "s종목리스트_초기화주기", comboBox_리스트초기화주기.SelectedItem.ToString());
				streamWriter.WriteLine("{0}\t{1}", "b종목리스트_보유종목매수금지", checkBox_보유종목매수금지.Checked);
				streamWriter.WriteLine("{0}\t{1}", "b종목리스트_동일종목주문금지", checkBox_동일종목주문금지.Checked);
				streamWriter.WriteLine("{0}\t{1}", "b종목리스트_등록시매수주문", checkBox_등록시매수주문.Checked);
				streamWriter.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public _Struct_GangPRO_Setup readSetup(string sPath)
		{
			_Struct_GangPRO_Setup result = default(_Struct_GangPRO_Setup);
			try
			{
				if (File.Exists(sPath))
				{
					StreamReader streamReader = new StreamReader(sPath);
					while (!streamReader.EndOfStream)
					{
						string text = streamReader.ReadLine();
						string[] array = text.Split(new char[1] { '\t' });
						if (array[0] == "nAccount")
						{
							result.nAccount = int.Parse(array[1]);
						}
						else if (array[0] == "sAccount")
						{
							result.sAccount = array[1];
						}
						else if (array[0] == "nLosscut")
						{
							result.nLosscut = int.Parse(array[1]);
						}
						else if (array[0] == "sLosscut")
						{
							result.sLosscut = array[1];
						}
						else if (array[0] == "nAutoSell")
						{
							result.nAutoSell = int.Parse(array[1]);
						}
						else if (array[0] == "sAutoSell")
						{
							result.sAutoSell = array[1];
						}
						else if (array[0] == "nDivisionSell_1")
						{
							result.nDivisionSell_1 = int.Parse(array[1]);
						}
						else if (array[0] == "sDivisionSell_1")
						{
							result.sDivisionSell_1 = array[1];
						}
						else if (array[0] == "nDivisionSell_2")
						{
							result.nDivisionSell_2 = int.Parse(array[1]);
						}
						else if (array[0] == "sDivisionSell_2")
						{
							result.sDivisionSell_2 = array[1];
						}
						else if (array[0] == "nCondition")
						{
							result.nCondition = int.Parse(array[1]);
						}
						else if (array[0] == "sCondition")
						{
							result.sCondition = array[1];
						}
						else if (array[0] == "nBuyOpt_1")
						{
							result.nBuyOpt_1 = int.Parse(array[1]);
						}
						else if (array[0] == "sBuyOpt_1")
						{
							result.sBuyOpt_1 = array[1];
						}
						else if (array[0] == "nBuyOpt_2")
						{
							result.nBuyOpt_2 = int.Parse(array[1]);
						}
						else if (array[0] == "sBuyOpt_2")
						{
							result.sBuyOpt_2 = array[1];
						}
						else if (array[0] == "bSell")
						{
							result.bSell = bool.Parse(array[1]);
						}
						else if (array[0] == "bSell_Simple")
						{
							result.bSell_Simple = bool.Parse(array[1]);
						}
						else if (array[0] == "nSell_Simple_Opt1")
						{
							result.nSell_Simple_Opt1 = int.Parse(array[1]);
						}
						else if (array[0] == "sSell_Simple_Opt1")
						{
							result.sSell_Simple_Opt1 = array[1];
						}
						else if (array[0] == "nSell_Simple_Opt2")
						{
							result.nSell_Simple_Opt2 = int.Parse(array[1]);
						}
						else if (array[0] == "sSell_Simple_Opt2")
						{
							result.sSell_Simple_Opt2 = array[1];
						}
						else if (array[0] == "nSell_Complex_Opt")
						{
							result.nSell_Complex_Opt = int.Parse(array[1]);
						}
						else if (array[0] == "sSell_Complex_Opt")
						{
							result.sSell_Complex_Opt = array[1];
						}
						else if (array[0] == "nBuyingTime1")
						{
							result.nBuyingTime1 = int.Parse(array[1]);
						}
						else if (array[0] == "sBuyingTime1")
						{
							result.sBuyingTime1 = array[1];
						}
						else if (array[0] == "nBuyingTime2")
						{
							result.nBuyingTime2 = int.Parse(array[1]);
						}
						else if (array[0] == "sBuyingTime2")
						{
							result.sBuyingTime2 = array[1];
						}
						else if (array[0] == "n매수종목제한")
						{
							result.n매수종목제한 = int.Parse(array[1]);
						}
						else if (array[0] == "s매수종목제한")
						{
							result.s매수종목제한 = array[1];
						}
						else if (array[0] == "n종목리스트_초기화주기")
						{
							result.n종목리스트_초기화주기 = int.Parse(array[1]);
						}
						else if (array[0] == "s종목리스트_초기화주기")
						{
							result.s종목리스트_초기화주기 = array[1];
						}
						else if (array[0] == "b종목리스트_보유종목매수금지")
						{
							result.b종목리스트_보유종목매수금지 = bool.Parse(array[1]);
						}
						else if (array[0] == "b종목리스트_동일종목주문금지")
						{
							result.b종목리스트_동일종목주문금지 = bool.Parse(array[1]);
						}
						else if (array[0] == "b종목리스트_등록시매수주문")
						{
							result.b종목리스트_등록시매수주문 = bool.Parse(array[1]);
						}
						else
						{
							Console.WriteLine("read setup Error : {0}", text);
						}
					}
					streamReader.Close();
				}
				else
				{
					Console.WriteLine("Setup 파일 존재안함");
					result.nAccount = 0;
					result.sAccount = "";
					result.nLosscut = 0;
					result.sLosscut = "";
					result.nAutoSell = 0;
					result.sAutoSell = "";
					result.nDivisionSell_1 = 0;
					result.sDivisionSell_1 = "";
					result.nDivisionSell_2 = 0;
					result.sDivisionSell_2 = "";
					result.nCondition = 0;
					result.sCondition = "";
					result.nBuyOpt_1 = 0;
					result.sBuyOpt_1 = "";
					result.nBuyOpt_2 = 0;
					result.sBuyOpt_2 = "";
					result.bSell = false;
					result.bSell_Simple = true;
					result.nSell_Simple_Opt1 = 0;
					result.sSell_Simple_Opt1 = "";
					result.nSell_Simple_Opt2 = 0;
					result.sSell_Simple_Opt2 = "";
					result.nSell_Complex_Opt = 0;
					result.sSell_Complex_Opt = "";
					result.nBuyingTime1 = 0;
					result.sBuyingTime1 = "";
					result.nBuyingTime2 = 0;
					result.sBuyingTime2 = "";
					result.n매수종목제한 = 0;
					result.s매수종목제한 = "";
					result.n종목리스트_초기화주기 = 0;
					result.s종목리스트_초기화주기 = "";
					result.b종목리스트_보유종목매수금지 = true;
					result.b종목리스트_동일종목주문금지 = false;
					result.b종목리스트_등록시매수주문 = false;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;
		}

		public void setSetup(_Struct_GangPRO_Setup s)
		{
			try
			{
				if (comboBox_계좌번호.Items[s.nAccount].ToString() == s.sAccount)
				{
					((ListControl)comboBox_계좌번호).SelectedIndex = s.nAccount;
				}
				if (comboBox_계좌손절손실률.Items[s.nLosscut].ToString() == s.sLosscut)
				{
					((ListControl)comboBox_계좌손절손실률).SelectedIndex = s.nLosscut;
				}
				if (comboBox_계좌일괄청산시간.Items[s.nAutoSell].ToString() == s.sAutoSell)
				{
					((ListControl)comboBox_계좌일괄청산시간).SelectedIndex = s.nAutoSell;
				}
				if (comboBox_계좌_분할기준.Items[s.nDivisionSell_1].ToString() == s.sDivisionSell_1)
				{
					((ListControl)comboBox_계좌_분할기준).SelectedIndex = s.nDivisionSell_1;
				}
				if (comboBox_계좌_분할옵션.Items[s.nDivisionSell_2].ToString() == s.sDivisionSell_2)
				{
					((ListControl)comboBox_계좌_분할옵션).SelectedIndex = s.nDivisionSell_2;
				}
				if (comboBox_키움조건식.Items[s.nCondition].ToString() == s.sCondition)
				{
					((ListControl)comboBox_키움조건식).SelectedIndex = s.nCondition;
				}
				if (comboBox_자동매수호가.Items[s.nBuyOpt_1].ToString() == s.sBuyOpt_1)
				{
					((ListControl)comboBox_자동매수호가).SelectedIndex = s.nBuyOpt_1;
				}
				if (comboBox_자동매수금액.Items[s.nBuyOpt_2].ToString() == s.sBuyOpt_2)
				{
					((ListControl)comboBox_자동매수금액).SelectedIndex = s.nBuyOpt_2;
				}
				checkBox_예약매도.Checked = s.bSell;
				if (s.bSell_Simple)
				{
					radioButton_예약매도_단순.Checked = true;
				}
				else
				{
					radioButton_예약매도_복합.Checked = true;
				}
				if (comboBox_예약매도_수익비중.Items[s.nSell_Simple_Opt1].ToString() == s.sSell_Simple_Opt1)
				{
					((ListControl)comboBox_예약매도_수익비중).SelectedIndex = s.nSell_Simple_Opt1;
				}
				if (comboBox_예약매도_수익률.Items[s.nSell_Simple_Opt2].ToString() == s.sSell_Simple_Opt2)
				{
					((ListControl)comboBox_예약매도_수익률).SelectedIndex = s.nSell_Simple_Opt2;
				}
				if (comboBox_예약매도_복합옵션.Items[s.nSell_Complex_Opt].ToString() == s.sSell_Complex_Opt)
				{
					((ListControl)comboBox_예약매도_복합옵션).SelectedIndex = s.nSell_Complex_Opt;
				}
				if (comboBox_조건_동작시간_시작.Items[s.nBuyingTime1].ToString() == s.sBuyingTime1)
				{
					((ListControl)comboBox_조건_동작시간_시작).SelectedIndex = s.nBuyingTime1;
				}
				if (comboBox_조건_동작시간_끝.Items[s.nBuyingTime2].ToString() == s.sBuyingTime2)
				{
					((ListControl)comboBox_조건_동작시간_끝).SelectedIndex = s.nBuyingTime2;
				}
				if (comboBox_조건_매수종목수.Items[s.n매수종목제한].ToString() == s.s매수종목제한)
				{
					((ListControl)comboBox_조건_매수종목수).SelectedIndex = s.n매수종목제한;
				}
				if (comboBox_리스트초기화주기.Items[s.n종목리스트_초기화주기].ToString() == s.s종목리스트_초기화주기)
				{
					((ListControl)comboBox_리스트초기화주기).SelectedIndex = s.n종목리스트_초기화주기;
				}
				checkBox_보유종목매수금지.Checked = s.b종목리스트_보유종목매수금지;
				checkBox_동일종목주문금지.Checked = s.b종목리스트_동일종목주문금지;
				b등록시매수주문_자동 = true;
				checkBox_등록시매수주문.Checked = s.b종목리스트_등록시매수주문;
				b등록시매수주문_자동 = false;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void DisconnectAllRealData()
		{
			for (int num = _scrNum; num > 5000; num--)
			{
				axKHOpenAPI.DisconnectRealData(num.ToString());
			}
			_scrNum = 5000;
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void txt조회날짜_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar((object)(Keys)8))
			{
				e.Handled = true;
			}
		}

		private void txt종목코드_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar((object)(Keys)8))
			{
				e.Handled = true;
			}
		}

		private void txt주문종목코드_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar((object)(Keys)8))
			{
				e.Handled = true;
			}
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			TestThread1.Abort();
			Thread_주문대기.Abort();
			writeSetup(DataPath.sGangPRO_SetupPath);
			Application.Exit();
		}

		private void 조건식셋팅저장ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Invalid comparison between Unknown and I4
			if (b접속상태)
			{
				Logger(Log.로그창, "조건식 셋팅 저장하기");
				((FileDialog)saveFileDialog_조건식).InitialDirectory = Application.StartupPath + "\\매매로그\\";
				((FileDialog)saveFileDialog_조건식).Filter = "조건식파일 (*.cnd)|*.cnd";
				if ((int)((CommonDialog)saveFileDialog_조건식).ShowDialog() == 1)
				{
					string fileName = ((FileDialog)saveFileDialog_조건식).FileName;
					File.Delete(fileName);
					for (int i = 0; i < dgv조건식목록.RowCount; i++)
					{
						int num = int.Parse(dgv조건식목록[0, i].Value.ToString());
						FileWrite(fileName, s조건_전체옵션[num] + "\n");
					}
				}
			}
			else
			{
				MessageBox.Show("키움증권 로그인 후 가능!", "알림");
			}
		}

		private void 조건식셋팅로드ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Invalid comparison between Unknown and I4
			if (b접속상태)
			{
				((FileDialog)openFileDialog_조건식).InitialDirectory = Application.StartupPath + "\\매매로그\\";
				((FileDialog)openFileDialog_조건식).Filter = "조건식파일 (*.cnd)|*.cnd";
				if ((int)((CommonDialog)openFileDialog_조건식).ShowDialog() != 1)
				{
					return;
				}
				Logger(Log.로그창, "조건식 셋팅 불러오기");
				string fileName = ((FileDialog)openFileDialog_조건식).FileName;
				int num = 0;
				StreamReader streamReader = File.OpenText(fileName);
				while (!streamReader.EndOfStream)
				{
					((ListControl)comboBox_조건_동작시간_시작).SelectedIndex = 0;
					((ListControl)comboBox_조건_동작시간_끝).SelectedIndex = n옵션_조건식_동작시간 - 2;
					string[] array = streamReader.ReadLine().Split(new char[1] { ';' });
					((ListControl)comboBox_키움조건식).SelectedIndex = int.Parse(array[1]);
					int num2 = n조건_인덱스[((ListControl)comboBox_키움조건식).SelectedIndex];
					if (s조건_조건명[num2] == array[3] && num2 == int.Parse(array[2]))
					{
						((ListControl)comboBox_자동매수호가).SelectedIndex = int.Parse(array[4]);
						((ListControl)comboBox_자동매수금액).SelectedIndex = int.Parse(array[5]);
						if (array[6] == "True")
						{
							checkBox_예약매도.Checked = true;
							if (array[7] == "True")
							{
								radioButton_예약매도_단순.Checked = true;
								((ListControl)comboBox_예약매도_수익비중).SelectedIndex = int.Parse(array[8]);
								((ListControl)comboBox_예약매도_수익률).SelectedIndex = int.Parse(array[9]);
							}
							if (array[10] == "True")
							{
								radioButton_예약매도_복합.Checked = true;
								((ListControl)comboBox_예약매도_복합옵션).SelectedIndex = int.Parse(array[11]);
							}
						}
						else
						{
							checkBox_예약매도.Checked = false;
						}
						((ListControl)comboBox_조건_동작시간_시작).SelectedIndex = int.Parse(array[12]);
						((ListControl)comboBox_조건_동작시간_끝).SelectedIndex = int.Parse(array[13]);
						((ListControl)comboBox_조건_매수종목수).SelectedIndex = int.Parse(array[14]);
						if (array[0] == "2")
						{
							btn조건식매수등록_Click(null, null);
						}
					}
					else
					{
						Logger(Log.로그창, "조건식 불일치!!!");
					}
					num++;
					Delay(500);
				}
				streamReader.Close();
			}
			else
			{
				MessageBox.Show("키움증권 로그인 후 가능!", "알림");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			f조건만족종목리스트(b실시간: true, "035720", "45", "스윙#101");
		}

		private void button2_Click(object sender, EventArgs e)
		{
		}

		private void checkBox_등록시매수주문_CheckedChanged(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Invalid comparison between Unknown and I4
			if (checkBox_등록시매수주문.Checked)
			{
				if (!b등록시매수주문_자동)
				{
					if ((int)MessageBox.Show("조건검색식 등록 시 이미 조건검색식을 만족해있는\n모든 종목에 대해 매수 주문이 나갑니다.\n맞습니까?", "확인", (MessageBoxButtons)1) == 1)
					{
						Logger(Log.로그창, "등록 시 매수주문");
						b등록시매수주문 = true;
					}
					else
					{
						b등록시매수주문 = false;
						checkBox_등록시매수주문.Checked = false;
					}
				}
				else
				{
					b등록시매수주문 = true;
				}
			}
			else
			{
				if (b등록시매수주문)
				{
					Logger(Log.로그창, "등록 시 매수주문 해제");
				}
				b등록시매수주문 = false;
			}
		}

		private void btn_종목리스트추가_Click(object sender, EventArgs e)
		{
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			if (b접속상태)
			{
				int stockIndexByName = getStockIndexByName(((Control)txt추가종목명).Text);
				string text = sAllStock_Name[stockIndexByName];
				string text2 = sAllStock_Code[stockIndexByName];
				if (stockIndexByName >= 0)
				{
					dgv조건만족종목.Rows.Add(new object[6]
					{
						((Control)lbl현재시간).Text,
						text2,
						text,
						"-직접추가-",
						"ⓧ",
						"ⓥ"
					});
					FileWrite(s로그저장경로_리스트, "{0}\t{1}\t{2}\t{3}\n", ((Control)lbl현재시간).Text, text2, text, "-직접추가-");
				}
			}
			else
			{
				MessageBox.Show("로그인 후 종목 추가 가능합니다.", "알림");
			}
		}

		private void txt추가종목명_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				btn_종목리스트추가_Click(null, null);
			}
		}

		private void 사용자매뉴얼ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (File.Exists(DataPath.sManualPath))
				{
					Process.Start(DataPath.sManualPath);
				}
				else
				{
					MessageBox.Show("매뉴얼 파일을 불러올 수 없습니다.", "알림");
				}
			}
			catch
			{
				MessageBox.Show("매뉴얼 파일을 불러올 수 없습니다.", "알림");
			}
		}

		private void dgv계좌_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			if (e.ColumnIndex == 0 && e.RowIndex == -1)
			{
				e.PaintBackground(e.ClipBounds, false);
				Point location = e.CellBounds.Location;
				int num = 15;
				int num2 = 15;
				int num3 = (e.CellBounds.Width - num) / 2;
				int num4 = (e.CellBounds.Height - num2) / 2;
				location.X += num3;
				location.Y += num4;
				CheckBox val = new CheckBox();
				((Control)val).Size = new Size(num, num2);
				((Control)val).Location = location;
				val.CheckedChanged += gvSheetListCheckBox_CheckedChanged;
				((Control)(DataGridView)sender).Controls.Add((Control)(object)val);
				((HandledEventArgs)(object)e).Handled = true;
			}
		}

		private void gvSheetListCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			if (dgv계좌.Rows.Count <= 0)
			{
				return;
			}
			dgv계좌.CurrentCell = dgv계좌[1, 0];
			foreach (DataGridViewRow item in (IEnumerable)dgv계좌.Rows)
			{
				item.Cells[0].Value = ((CheckBox)sender).Checked;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected O, but got Unknown
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Expected O, but got Unknown
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected O, but got Unknown
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Expected O, but got Unknown
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Expected O, but got Unknown
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Expected O, but got Unknown
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Expected O, but got Unknown
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Expected O, but got Unknown
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Expected O, but got Unknown
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Expected O, but got Unknown
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Expected O, but got Unknown
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Expected O, but got Unknown
			//IL_0246: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Expected O, but got Unknown
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Expected O, but got Unknown
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Expected O, but got Unknown
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Expected O, but got Unknown
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Expected O, but got Unknown
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Expected O, but got Unknown
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Expected O, but got Unknown
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Expected O, but got Unknown
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Expected O, but got Unknown
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Expected O, but got Unknown
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Expected O, but got Unknown
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Expected O, but got Unknown
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Expected O, but got Unknown
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Expected O, but got Unknown
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Expected O, but got Unknown
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected O, but got Unknown
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Expected O, but got Unknown
			//IL_030c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Expected O, but got Unknown
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_0321: Expected O, but got Unknown
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Expected O, but got Unknown
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Expected O, but got Unknown
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Expected O, but got Unknown
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_034d: Expected O, but got Unknown
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Expected O, but got Unknown
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_0363: Expected O, but got Unknown
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Expected O, but got Unknown
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0384: Expected O, but got Unknown
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Expected O, but got Unknown
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Expected O, but got Unknown
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Expected O, but got Unknown
			//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Expected O, but got Unknown
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Expected O, but got Unknown
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c6: Expected O, but got Unknown
			//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d1: Expected O, but got Unknown
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Expected O, but got Unknown
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e7: Expected O, but got Unknown
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f2: Expected O, but got Unknown
			//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fd: Expected O, but got Unknown
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Expected O, but got Unknown
			//IL_0409: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Expected O, but got Unknown
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_041e: Expected O, but got Unknown
			//IL_041f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0429: Expected O, but got Unknown
			//IL_042a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Expected O, but got Unknown
			//IL_0435: Unknown result type (might be due to invalid IL or missing references)
			//IL_043f: Expected O, but got Unknown
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_044a: Expected O, but got Unknown
			//IL_044b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0455: Expected O, but got Unknown
			//IL_0456: Unknown result type (might be due to invalid IL or missing references)
			//IL_0460: Expected O, but got Unknown
			//IL_0461: Unknown result type (might be due to invalid IL or missing references)
			//IL_046b: Expected O, but got Unknown
			//IL_046c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Expected O, but got Unknown
			//IL_0477: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Expected O, but got Unknown
			//IL_0482: Unknown result type (might be due to invalid IL or missing references)
			//IL_048c: Expected O, but got Unknown
			//IL_048d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0497: Expected O, but got Unknown
			//IL_0498: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a2: Expected O, but got Unknown
			//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ad: Expected O, but got Unknown
			//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b8: Expected O, but got Unknown
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Expected O, but got Unknown
			//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ce: Expected O, but got Unknown
			//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d9: Expected O, but got Unknown
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e4: Expected O, but got Unknown
			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Expected O, but got Unknown
			//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Expected O, but got Unknown
			//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0505: Expected O, but got Unknown
			//IL_0506: Unknown result type (might be due to invalid IL or missing references)
			//IL_0510: Expected O, but got Unknown
			//IL_0511: Unknown result type (might be due to invalid IL or missing references)
			//IL_051b: Expected O, but got Unknown
			//IL_051c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0526: Expected O, but got Unknown
			//IL_0527: Unknown result type (might be due to invalid IL or missing references)
			//IL_0531: Expected O, but got Unknown
			//IL_0532: Unknown result type (might be due to invalid IL or missing references)
			//IL_053c: Expected O, but got Unknown
			//IL_053d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0547: Expected O, but got Unknown
			//IL_0548: Unknown result type (might be due to invalid IL or missing references)
			//IL_0552: Expected O, but got Unknown
			//IL_0553: Unknown result type (might be due to invalid IL or missing references)
			//IL_055d: Expected O, but got Unknown
			//IL_055e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0568: Expected O, but got Unknown
			//IL_0569: Unknown result type (might be due to invalid IL or missing references)
			//IL_0573: Expected O, but got Unknown
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_057e: Expected O, but got Unknown
			//IL_057f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0589: Expected O, but got Unknown
			//IL_058a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0594: Expected O, but got Unknown
			//IL_0595: Unknown result type (might be due to invalid IL or missing references)
			//IL_059f: Expected O, but got Unknown
			//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05aa: Expected O, but got Unknown
			//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b5: Expected O, but got Unknown
			//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c0: Expected O, but got Unknown
			//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cb: Expected O, but got Unknown
			//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d6: Expected O, but got Unknown
			//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e1: Expected O, but got Unknown
			//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ec: Expected O, but got Unknown
			//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f7: Expected O, but got Unknown
			//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0602: Expected O, but got Unknown
			//IL_0603: Unknown result type (might be due to invalid IL or missing references)
			//IL_060d: Expected O, but got Unknown
			//IL_060e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0618: Expected O, but got Unknown
			//IL_0619: Unknown result type (might be due to invalid IL or missing references)
			//IL_0623: Expected O, but got Unknown
			//IL_0624: Unknown result type (might be due to invalid IL or missing references)
			//IL_062e: Expected O, but got Unknown
			//IL_062f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0639: Expected O, but got Unknown
			//IL_063a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0644: Expected O, but got Unknown
			//IL_0645: Unknown result type (might be due to invalid IL or missing references)
			//IL_064f: Expected O, but got Unknown
			//IL_0650: Unknown result type (might be due to invalid IL or missing references)
			//IL_065a: Expected O, but got Unknown
			//IL_065b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0665: Expected O, but got Unknown
			//IL_0666: Unknown result type (might be due to invalid IL or missing references)
			//IL_0670: Expected O, but got Unknown
			//IL_0671: Unknown result type (might be due to invalid IL or missing references)
			//IL_067b: Expected O, but got Unknown
			//IL_067c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0686: Expected O, but got Unknown
			//IL_0687: Unknown result type (might be due to invalid IL or missing references)
			//IL_0691: Expected O, but got Unknown
			//IL_0692: Unknown result type (might be due to invalid IL or missing references)
			//IL_069c: Expected O, but got Unknown
			//IL_10ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_10f9: Expected O, but got Unknown
			//IL_1106: Unknown result type (might be due to invalid IL or missing references)
			//IL_1110: Expected O, but got Unknown
			//IL_1341: Unknown result type (might be due to invalid IL or missing references)
			//IL_134b: Expected O, but got Unknown
			//IL_166b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1675: Expected O, but got Unknown
			//IL_1714: Unknown result type (might be due to invalid IL or missing references)
			//IL_171e: Expected O, but got Unknown
			//IL_17fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_1806: Expected O, but got Unknown
			//IL_1979: Unknown result type (might be due to invalid IL or missing references)
			//IL_1983: Expected O, but got Unknown
			//IL_1a63: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a6d: Expected O, but got Unknown
			//IL_1b4e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b58: Expected O, but got Unknown
			//IL_1c0d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c17: Expected O, but got Unknown
			//IL_1c24: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c2e: Expected O, but got Unknown
			//IL_1c3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c45: Expected O, but got Unknown
			//IL_23dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_23e6: Expected O, but got Unknown
			//IL_28bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_28c7: Expected O, but got Unknown
			//IL_295c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2966: Expected O, but got Unknown
			//IL_2b22: Unknown result type (might be due to invalid IL or missing references)
			//IL_2b2c: Expected O, but got Unknown
			//IL_2ddd: Unknown result type (might be due to invalid IL or missing references)
			//IL_2de7: Expected O, but got Unknown
			//IL_2f64: Unknown result type (might be due to invalid IL or missing references)
			//IL_2f6e: Expected O, but got Unknown
			//IL_31a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_31ac: Expected O, but got Unknown
			//IL_3491: Unknown result type (might be due to invalid IL or missing references)
			//IL_349b: Expected O, but got Unknown
			//IL_3690: Unknown result type (might be due to invalid IL or missing references)
			//IL_369a: Expected O, but got Unknown
			//IL_3c1d: Unknown result type (might be due to invalid IL or missing references)
			//IL_3c27: Expected O, but got Unknown
			//IL_3cd8: Unknown result type (might be due to invalid IL or missing references)
			//IL_3ce2: Expected O, but got Unknown
			//IL_3dd5: Unknown result type (might be due to invalid IL or missing references)
			//IL_3ddf: Expected O, but got Unknown
			//IL_3e8f: Unknown result type (might be due to invalid IL or missing references)
			//IL_3e99: Expected O, but got Unknown
			//IL_3f66: Unknown result type (might be due to invalid IL or missing references)
			//IL_3f70: Expected O, but got Unknown
			//IL_40a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_40b3: Expected O, but got Unknown
			//IL_4185: Unknown result type (might be due to invalid IL or missing references)
			//IL_418f: Expected O, but got Unknown
			//IL_4248: Unknown result type (might be due to invalid IL or missing references)
			//IL_4252: Expected O, but got Unknown
			//IL_4318: Unknown result type (might be due to invalid IL or missing references)
			//IL_4322: Expected O, but got Unknown
			//IL_44e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_44ec: Expected O, but got Unknown
			//IL_48f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_48fd: Expected O, but got Unknown
			//IL_49a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_49ab: Expected O, but got Unknown
			//IL_4a19: Unknown result type (might be due to invalid IL or missing references)
			//IL_4a23: Expected O, but got Unknown
			//IL_4a88: Unknown result type (might be due to invalid IL or missing references)
			//IL_4a92: Expected O, but got Unknown
			//IL_4d1f: Unknown result type (might be due to invalid IL or missing references)
			//IL_4d29: Expected O, but got Unknown
			//IL_4ddb: Unknown result type (might be due to invalid IL or missing references)
			//IL_4de5: Expected O, but got Unknown
			//IL_4e1f: Unknown result type (might be due to invalid IL or missing references)
			//IL_4e29: Expected O, but got Unknown
			//IL_4e36: Unknown result type (might be due to invalid IL or missing references)
			//IL_4e40: Expected O, but got Unknown
			//IL_4e4d: Unknown result type (might be due to invalid IL or missing references)
			//IL_4e57: Expected O, but got Unknown
			//IL_4e64: Unknown result type (might be due to invalid IL or missing references)
			//IL_4e6e: Expected O, but got Unknown
			//IL_4e7b: Unknown result type (might be due to invalid IL or missing references)
			//IL_4e85: Expected O, but got Unknown
			//IL_4e92: Unknown result type (might be due to invalid IL or missing references)
			//IL_4e9c: Expected O, but got Unknown
			//IL_4ea9: Unknown result type (might be due to invalid IL or missing references)
			//IL_4eb3: Expected O, but got Unknown
			//IL_4ec0: Unknown result type (might be due to invalid IL or missing references)
			//IL_4eca: Expected O, but got Unknown
			//IL_503b: Unknown result type (might be due to invalid IL or missing references)
			//IL_5045: Expected O, but got Unknown
			//IL_5076: Unknown result type (might be due to invalid IL or missing references)
			//IL_5080: Expected O, but got Unknown
			DataGridViewCellStyle val = new DataGridViewCellStyle();
			DataGridViewCellStyle val2 = new DataGridViewCellStyle();
			DataGridViewCellStyle val3 = new DataGridViewCellStyle();
			DataGridViewCellStyle val4 = new DataGridViewCellStyle();
			DataGridViewCellStyle val5 = new DataGridViewCellStyle();
			DataGridViewCellStyle val6 = new DataGridViewCellStyle();
			DataGridViewCellStyle val7 = new DataGridViewCellStyle();
			DataGridViewCellStyle val8 = new DataGridViewCellStyle();
			DataGridViewCellStyle val9 = new DataGridViewCellStyle();
			DataGridViewCellStyle val10 = new DataGridViewCellStyle();
			DataGridViewCellStyle val11 = new DataGridViewCellStyle();
			DataGridViewCellStyle val12 = new DataGridViewCellStyle();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			menuStrip = new MenuStrip();
			기본기능ToolStripMenuItem = new ToolStripMenuItem();
			로그인ToolStripMenuItem = new ToolStripMenuItem();
			로그아웃ToolStripMenuItem = new ToolStripMenuItem();
			접속상태ToolStripMenuItem = new ToolStripMenuItem();
			종료ToolStripMenuItem = new ToolStripMenuItem();
			조회기능ToolStripMenuItem = new ToolStripMenuItem();
			초기화ToolStripMenuItem = new ToolStripMenuItem();
			기능_항상위ToolStripMenuItem = new ToolStripMenuItem();
			조건식셋팅저장ToolStripMenuItem = new ToolStripMenuItem();
			조건식셋팅로드ToolStripMenuItem = new ToolStripMenuItem();
			종목리스트ToolStripMenuItem = new ToolStripMenuItem();
			종목리스트_지우기ToolStripMenuItem = new ToolStripMenuItem();
			로그ToolStripMenuItem = new ToolStripMenuItem();
			로그_매매로그확인ToolStripMenuItem = new ToolStripMenuItem();
			도움말ToolStripMenuItem = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			GangPROToolStripMenuItem = new ToolStripMenuItem();
			유료신청방법ToolStripMenuItem = new ToolStripMenuItem();
			주식공동연구소ToolStripMenuItem = new ToolStripMenuItem();
			사용자매뉴얼ToolStripMenuItem = new ToolStripMenuItem();
			lbl이름 = new Label();
			lbl아이디 = new Label();
			lst로그창 = new ListBox();
			label_로그창 = new Label();
			comboBox_계좌번호 = new ComboBox();
			txt주문종목코드 = new TextBox();
			label31 = new Label();
			label32 = new Label();
			txt주문수량 = new TextBox();
			label33 = new Label();
			txt주문단가 = new TextBox();
			lbl주문종목명 = new Label();
			btn주문실행 = new Button();
			txt원주문번호 = new TextBox();
			label34 = new Label();
			label38 = new Label();
			label39 = new Label();
			comboBox_주문유형 = new ComboBox();
			comboBox_호가유형 = new ComboBox();
			dgv호가창 = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			Column4 = new DataGridViewTextBoxColumn();
			btn종목조회 = new Button();
			btn계좌조회 = new Button();
			dgv계좌 = new DataGridView();
			Column16 = new DataGridViewCheckBoxColumn();
			Column5 = new DataGridViewTextBoxColumn();
			Column6 = new DataGridViewTextBoxColumn();
			Column10 = new DataGridViewTextBoxColumn();
			Column7 = new DataGridViewTextBoxColumn();
			Column19 = new DataGridViewTextBoxColumn();
			Column8 = new DataGridViewTextBoxColumn();
			Column17 = new DataGridViewTextBoxColumn();
			Column18 = new DataGridViewTextBoxColumn();
			Column15 = new DataGridViewTextBoxColumn();
			Column25 = new DataGridViewTextBoxColumn();
			comboBox_키움조건식 = new ComboBox();
			label40 = new Label();
			label41 = new Label();
			txt계좌잔액 = new TextBox();
			label42 = new Label();
			lst체결창 = new ListBox();
			label43 = new Label();
			openFileDialog_조건식 = new OpenFileDialog();
			saveFileDialog_조건식 = new SaveFileDialog();
			groupBox_주문 = new GroupBox();
			button2 = new Button();
			button1 = new Button();
			groupBox_계좌 = new GroupBox();
			txt보유종목누적수익률 = new TextBox();
			label15 = new Label();
			btn유료신청방법 = new Button();
			btn계좌_일괄청산 = new Button();
			label12 = new Label();
			comboBox_계좌_분할옵션 = new ComboBox();
			comboBox_계좌_분할기준 = new ComboBox();
			btn계좌_분할매도 = new Button();
			comboBox_계좌_보유종목수제한 = new ComboBox();
			label11 = new Label();
			lbl계좌_일괄청산 = new Label();
			comboBox_계좌일괄청산시간 = new ComboBox();
			label3 = new Label();
			btn_계좌_비밀번호입력창 = new Button();
			comboBox_계좌손절손실률 = new ComboBox();
			lbl계좌_자동손절 = new Label();
			btn계좌_자동손절 = new Button();
			label4 = new Label();
			groupBox_종목정보 = new GroupBox();
			label2 = new Label();
			lbl현재시간 = new Label();
			groupBox_조건식 = new GroupBox();
			btn조건식조회등록 = new Button();
			comboBox_조건_매수종목수 = new ComboBox();
			label9 = new Label();
			comboBox_조건_동작시간_끝 = new ComboBox();
			label8 = new Label();
			comboBox_조건_동작시간_시작 = new ComboBox();
			label7 = new Label();
			comboBox_예약매도_복합옵션 = new ComboBox();
			radioButton_예약매도_복합 = new RadioButton();
			radioButton_예약매도_단순 = new RadioButton();
			checkBox_예약매도 = new CheckBox();
			label6 = new Label();
			comboBox_예약매도_수익률 = new ComboBox();
			comboBox_예약매도_수익비중 = new ComboBox();
			comboBox_자동매수금액 = new ComboBox();
			comboBox_자동매수호가 = new ComboBox();
			label1 = new Label();
			btn조건식매도등록 = new Button();
			btn조건식매수등록 = new Button();
			dgv조건식목록 = new DataGridView();
			Column24 = new DataGridViewTextBoxColumn();
			Column20 = new DataGridViewTextBoxColumn();
			Column21 = new DataGridViewTextBoxColumn();
			Column22 = new DataGridViewTextBoxColumn();
			Column23 = new DataGridViewTextBoxColumn();
			label5 = new Label();
			dgv조건만족종목 = new DataGridView();
			Column14 = new DataGridViewTextBoxColumn();
			Column12 = new DataGridViewTextBoxColumn();
			Column9 = new DataGridViewTextBoxColumn();
			Column13 = new DataGridViewTextBoxColumn();
			Column11 = new DataGridViewTextBoxColumn();
			Column26 = new DataGridViewTextBoxColumn();
			comboBox_리스트초기화주기 = new ComboBox();
			btn리스트_초기화 = new Button();
			label10 = new Label();
			lbl리스트_초기화셋팅 = new Label();
			checkBox_보유종목매수금지 = new CheckBox();
			groupBox_종목리스트 = new GroupBox();
			checkBox_등록시매수주문 = new CheckBox();
			btn_종목리스트추가 = new Button();
			label13 = new Label();
			txt추가종목명 = new TextBox();
			checkBox_동일종목주문금지 = new CheckBox();
			lbl프로그램상태 = new Label();
			dgv지수정보 = new DataGridView();
			Column27 = new DataGridViewTextBoxColumn();
			Column28 = new DataGridViewTextBoxColumn();
			Column29 = new DataGridViewTextBoxColumn();
			lbl오늘날짜 = new Label();
			axKHOpenAPI = new AxKHOpenAPI();
			((Control)menuStrip).SuspendLayout();
			((ISupportInitialize)dgv호가창).BeginInit();
			((ISupportInitialize)dgv계좌).BeginInit();
			((Control)groupBox_주문).SuspendLayout();
			((Control)groupBox_계좌).SuspendLayout();
			((Control)groupBox_종목정보).SuspendLayout();
			((Control)groupBox_조건식).SuspendLayout();
			((ISupportInitialize)dgv조건식목록).BeginInit();
			((ISupportInitialize)dgv조건만족종목).BeginInit();
			((Control)groupBox_종목리스트).SuspendLayout();
			((ISupportInitialize)dgv지수정보).BeginInit();
			((ISupportInitialize)axKHOpenAPI).BeginInit();
			((Control)this).SuspendLayout();
			((ToolStrip)menuStrip).BackColor = SystemColors.ControlDark;
			((ToolStrip)menuStrip).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
			{
				(ToolStripItem)기본기능ToolStripMenuItem,
				(ToolStripItem)조회기능ToolStripMenuItem,
				(ToolStripItem)종목리스트ToolStripMenuItem,
				(ToolStripItem)로그ToolStripMenuItem,
				(ToolStripItem)도움말ToolStripMenuItem
			});
			((Control)menuStrip).Location = new Point(0, 0);
			((Control)menuStrip).Name = "menuStrip";
			((Control)menuStrip).Size = new Size(1324, 24);
			((Control)menuStrip).TabIndex = 0;
			((Control)menuStrip).Text = "menuStrip";
			((ToolStripDropDownItem)기본기능ToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[4]
			{
				(ToolStripItem)로그인ToolStripMenuItem,
				(ToolStripItem)로그아웃ToolStripMenuItem,
				(ToolStripItem)접속상태ToolStripMenuItem,
				(ToolStripItem)종료ToolStripMenuItem
			});
			((ToolStripItem)기본기능ToolStripMenuItem).Name = "기본기능ToolStripMenuItem";
			((ToolStripItem)기본기능ToolStripMenuItem).Size = new Size(43, 20);
			((ToolStripItem)기본기능ToolStripMenuItem).Text = "일반";
			((ToolStripItem)로그인ToolStripMenuItem).Name = "로그인ToolStripMenuItem";
			((ToolStripItem)로그인ToolStripMenuItem).Size = new Size(141, 22);
			((ToolStripItem)로그인ToolStripMenuItem).Text = "로그인";
			((ToolStripItem)로그인ToolStripMenuItem).Click += 로그인ToolStripMenuItem_Click;
			((ToolStripItem)로그아웃ToolStripMenuItem).Name = "로그아웃ToolStripMenuItem";
			((ToolStripItem)로그아웃ToolStripMenuItem).Size = new Size(141, 22);
			((ToolStripItem)로그아웃ToolStripMenuItem).Text = "로그아웃";
			((ToolStripItem)로그아웃ToolStripMenuItem).Visible = false;
			((ToolStripItem)로그아웃ToolStripMenuItem).Click += 로그아웃ToolStripMenuItem_Click;
			((ToolStripItem)접속상태ToolStripMenuItem).Name = "접속상태ToolStripMenuItem";
			((ToolStripItem)접속상태ToolStripMenuItem).Size = new Size(141, 22);
			((ToolStripItem)접속상태ToolStripMenuItem).Text = "접속상태";
			((ToolStripItem)접속상태ToolStripMenuItem).Click += 접속상태ToolStripMenuItem_Click;
			((ToolStripItem)종료ToolStripMenuItem).Name = "종료ToolStripMenuItem";
			종료ToolStripMenuItem.ShortcutKeys = (Keys)262259;
			((ToolStripItem)종료ToolStripMenuItem).Size = new Size(141, 22);
			((ToolStripItem)종료ToolStripMenuItem).Text = "종료";
			((ToolStripItem)종료ToolStripMenuItem).Click += 종료ToolStripMenuItem_Click;
			((ToolStripDropDownItem)조회기능ToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[4]
			{
				(ToolStripItem)초기화ToolStripMenuItem,
				(ToolStripItem)기능_항상위ToolStripMenuItem,
				(ToolStripItem)조건식셋팅저장ToolStripMenuItem,
				(ToolStripItem)조건식셋팅로드ToolStripMenuItem
			});
			((ToolStripItem)조회기능ToolStripMenuItem).Name = "조회기능ToolStripMenuItem";
			((ToolStripItem)조회기능ToolStripMenuItem).Size = new Size(43, 20);
			((ToolStripItem)조회기능ToolStripMenuItem).Text = "기능";
			((ToolStripItem)초기화ToolStripMenuItem).Name = "초기화ToolStripMenuItem";
			((ToolStripItem)초기화ToolStripMenuItem).Size = new Size(209, 22);
			((ToolStripItem)초기화ToolStripMenuItem).Text = "초기화";
			((ToolStripItem)초기화ToolStripMenuItem).Click += 초기화ToolStripMenuItem_Click;
			((ToolStripItem)기능_항상위ToolStripMenuItem).Name = "기능_항상위ToolStripMenuItem";
			기능_항상위ToolStripMenuItem.ShortcutKeys = (Keys)131156;
			((ToolStripItem)기능_항상위ToolStripMenuItem).Size = new Size(209, 22);
			((ToolStripItem)기능_항상위ToolStripMenuItem).Text = "항상 위";
			((ToolStripItem)기능_항상위ToolStripMenuItem).Click += 기능_항상위ToolStripMenuItem_Click;
			((ToolStripItem)조건식셋팅저장ToolStripMenuItem).Name = "조건식셋팅저장ToolStripMenuItem";
			조건식셋팅저장ToolStripMenuItem.ShortcutKeys = (Keys)131155;
			((ToolStripItem)조건식셋팅저장ToolStripMenuItem).Size = new Size(209, 22);
			((ToolStripItem)조건식셋팅저장ToolStripMenuItem).Text = "조건식 셋팅 저장";
			((ToolStripItem)조건식셋팅저장ToolStripMenuItem).Click += 조건식셋팅저장ToolStripMenuItem_Click;
			((ToolStripItem)조건식셋팅로드ToolStripMenuItem).Name = "조건식셋팅로드ToolStripMenuItem";
			조건식셋팅로드ToolStripMenuItem.ShortcutKeys = (Keys)131151;
			((ToolStripItem)조건식셋팅로드ToolStripMenuItem).Size = new Size(209, 22);
			((ToolStripItem)조건식셋팅로드ToolStripMenuItem).Text = "조건식 셋팅 로드";
			((ToolStripItem)조건식셋팅로드ToolStripMenuItem).Click += 조건식셋팅로드ToolStripMenuItem_Click;
			((ToolStripDropDownItem)종목리스트ToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)종목리스트_지우기ToolStripMenuItem });
			((ToolStripItem)종목리스트ToolStripMenuItem).Name = "종목리스트ToolStripMenuItem";
			((ToolStripItem)종목리스트ToolStripMenuItem).Size = new Size(79, 20);
			((ToolStripItem)종목리스트ToolStripMenuItem).Text = "종목리스트";
			((ToolStripItem)종목리스트_지우기ToolStripMenuItem).Name = "종목리스트_지우기ToolStripMenuItem";
			((ToolStripItem)종목리스트_지우기ToolStripMenuItem).Size = new Size(110, 22);
			((ToolStripItem)종목리스트_지우기ToolStripMenuItem).Text = "지우기";
			((ToolStripItem)종목리스트_지우기ToolStripMenuItem).Click += 종목리스트_지우기ToolStripMenuItem_Click;
			((ToolStripDropDownItem)로그ToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)로그_매매로그확인ToolStripMenuItem });
			((ToolStripItem)로그ToolStripMenuItem).Name = "로그ToolStripMenuItem";
			((ToolStripItem)로그ToolStripMenuItem).Size = new Size(43, 20);
			((ToolStripItem)로그ToolStripMenuItem).Text = "로그";
			((ToolStripItem)로그_매매로그확인ToolStripMenuItem).Name = "로그_매매로그확인ToolStripMenuItem";
			((ToolStripItem)로그_매매로그확인ToolStripMenuItem).Size = new Size(146, 22);
			((ToolStripItem)로그_매매로그확인ToolStripMenuItem).Text = "매매로그확인";
			((ToolStripItem)로그_매매로그확인ToolStripMenuItem).Click += 로그_매매로그확인ToolStripMenuItem_Click;
			((ToolStripDropDownItem)도움말ToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
			{
				(ToolStripItem)helpToolStripMenuItem,
				(ToolStripItem)GangPROToolStripMenuItem,
				(ToolStripItem)유료신청방법ToolStripMenuItem,
				(ToolStripItem)주식공동연구소ToolStripMenuItem,
				(ToolStripItem)사용자매뉴얼ToolStripMenuItem
			});
			((ToolStripItem)도움말ToolStripMenuItem).Name = "도움말ToolStripMenuItem";
			((ToolStripItem)도움말ToolStripMenuItem).Size = new Size(55, 20);
			((ToolStripItem)도움말ToolStripMenuItem).Text = "도움말";
			((ToolStripItem)helpToolStripMenuItem).Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.ShortcutKeys = (Keys)112;
			((ToolStripItem)helpToolStripMenuItem).Size = new Size(201, 22);
			((ToolStripItem)helpToolStripMenuItem).Text = "Help";
			((ToolStripItem)helpToolStripMenuItem).Click += helpToolStripMenuItem_Click;
			((ToolStripItem)GangPROToolStripMenuItem).Name = "GangPROToolStripMenuItem";
			((ToolStripItem)GangPROToolStripMenuItem).Size = new Size(201, 22);
			((ToolStripItem)GangPROToolStripMenuItem).Text = "GangPRO란?";
			((ToolStripItem)GangPROToolStripMenuItem).Click += GangPROToolStripMenuItem_Click;
			((ToolStripItem)유료신청방법ToolStripMenuItem).Name = "유료신청방법ToolStripMenuItem";
			((ToolStripItem)유료신청방법ToolStripMenuItem).Size = new Size(201, 22);
			((ToolStripItem)유료신청방법ToolStripMenuItem).Text = "유료 신청 방법";
			((ToolStripItem)유료신청방법ToolStripMenuItem).Click += 유료신청방법ToolStripMenuItem_Click;
			((ToolStripItem)주식공동연구소ToolStripMenuItem).Name = "주식공동연구소ToolStripMenuItem";
			주식공동연구소ToolStripMenuItem.ShortcutKeys = (Keys)131144;
			((ToolStripItem)주식공동연구소ToolStripMenuItem).Size = new Size(201, 22);
			((ToolStripItem)주식공동연구소ToolStripMenuItem).Text = "주식공동연구소";
			((ToolStripItem)주식공동연구소ToolStripMenuItem).Click += 주식공동연구소ToolStripMenuItem_Click;
			((ToolStripItem)사용자매뉴얼ToolStripMenuItem).Name = "사용자매뉴얼ToolStripMenuItem";
			((ToolStripItem)사용자매뉴얼ToolStripMenuItem).Size = new Size(201, 22);
			((ToolStripItem)사용자매뉴얼ToolStripMenuItem).Text = "사용자 매뉴얼";
			((ToolStripItem)사용자매뉴얼ToolStripMenuItem).Click += 사용자매뉴얼ToolStripMenuItem_Click;
			((Control)lbl이름).AutoSize = true;
			((Control)lbl이름).Location = new Point(52, 15);
			((Control)lbl이름).Name = "lbl이름";
			((Control)lbl이름).Size = new Size(0, 12);
			((Control)lbl이름).TabIndex = 14;
			((Control)lbl아이디).AutoSize = true;
			((Control)lbl아이디).Location = new Point(64, 105);
			((Control)lbl아이디).Name = "lbl아이디";
			((Control)lbl아이디).Size = new Size(0, 12);
			((Control)lbl아이디).TabIndex = 15;
			((ListControl)lst로그창).FormattingEnabled = true;
			lst로그창.HorizontalScrollbar = true;
			lst로그창.ItemHeight = 12;
			((Control)lst로그창).Location = new Point(538, 621);
			((Control)lst로그창).Name = "lst로그창";
			((Control)lst로그창).Size = new Size(709, 136);
			((Control)lst로그창).TabIndex = 27;
			((Control)label_로그창).AutoSize = true;
			((Control)label_로그창).Location = new Point(536, 606);
			((Control)label_로그창).Name = "label_로그창";
			((Control)label_로그창).Size = new Size(41, 12);
			((Control)label_로그창).TabIndex = 28;
			((Control)label_로그창).Text = "로그창";
			((ListControl)comboBox_계좌번호).FormattingEnabled = true;
			((Control)comboBox_계좌번호).Location = new Point(11, 14);
			((Control)comboBox_계좌번호).Name = "comboBox_계좌번호";
			((Control)comboBox_계좌번호).Size = new Size(110, 20);
			((Control)comboBox_계좌번호).TabIndex = 97;
			((Control)txt주문종목코드).Location = new Point(51, 25);
			((Control)txt주문종목코드).Name = "txt주문종목코드";
			((Control)txt주문종목코드).Size = new Size(53, 21);
			((Control)txt주문종목코드).TabIndex = 98;
			((Control)txt주문종목코드).Text = "006120";
			((Control)txt주문종목코드).KeyPress += new KeyPressEventHandler(txt주문종목코드_KeyPress);
			((Control)txt주문종목코드).KeyUp += new KeyEventHandler(txt주문종목코드_KeyUp);
			((Control)label31).AutoSize = true;
			((Control)label31).Location = new Point(7, 30);
			((Control)label31).Name = "label31";
			((Control)label31).Size = new Size(37, 12);
			((Control)label31).TabIndex = 99;
			((Control)label31).Text = "코드 :";
			((Control)label32).AutoSize = true;
			((Control)label32).Location = new Point(7, 99);
			((Control)label32).Name = "label32";
			((Control)label32).Size = new Size(37, 12);
			((Control)label32).TabIndex = 101;
			((Control)label32).Text = "수량 :";
			((Control)txt주문수량).Location = new Point(51, 95);
			((Control)txt주문수량).Name = "txt주문수량";
			((Control)txt주문수량).Size = new Size(75, 21);
			((Control)txt주문수량).TabIndex = 100;
			((Control)txt주문수량).Text = "1";
			((Control)label33).AutoSize = true;
			((Control)label33).Location = new Point(7, 122);
			((Control)label33).Name = "label33";
			((Control)label33).Size = new Size(37, 12);
			((Control)label33).TabIndex = 103;
			((Control)label33).Text = "단가 :";
			((Control)txt주문단가).Location = new Point(51, 118);
			((Control)txt주문단가).Name = "txt주문단가";
			((Control)txt주문단가).Size = new Size(75, 21);
			((Control)txt주문단가).TabIndex = 102;
			((Control)txt주문단가).Text = "1000";
			((Control)lbl주문종목명).AutoSize = true;
			((Control)lbl주문종목명).Location = new Point(65, 17);
			((Control)lbl주문종목명).Name = "lbl주문종목명";
			((Control)lbl주문종목명).Size = new Size(0, 12);
			((Control)lbl주문종목명).TabIndex = 104;
			((Control)btn주문실행).Font = new Font("굴림", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn주문실행).Location = new Point(9, 168);
			((Control)btn주문실행).Name = "btn주문실행";
			((Control)btn주문실행).Size = new Size(84, 28);
			((Control)btn주문실행).TabIndex = 105;
			((Control)btn주문실행).Text = "주문";
			((ButtonBase)btn주문실행).UseVisualStyleBackColor = true;
			((Control)btn주문실행).Click += btn주문실행_Click;
			((Control)txt원주문번호).Enabled = false;
			((Control)txt원주문번호).Location = new Point(51, 141);
			((Control)txt원주문번호).Name = "txt원주문번호";
			((Control)txt원주문번호).Size = new Size(75, 21);
			((Control)txt원주문번호).TabIndex = 106;
			((Control)txt원주문번호).Text = "1000";
			((Control)label34).AutoSize = true;
			((Control)label34).Location = new Point(7, 145);
			((Control)label34).Name = "label34";
			((Control)label34).Size = new Size(24, 12);
			((Control)label34).TabIndex = 107;
			((Control)label34).Text = "ID :";
			((Control)label38).AutoSize = true;
			((Control)label38).Location = new Point(7, 52);
			((Control)label38).Name = "label38";
			((Control)label38).Size = new Size(37, 12);
			((Control)label38).TabIndex = 115;
			((Control)label38).Text = "유형 :";
			((Control)label39).AutoSize = true;
			((Control)label39).Location = new Point(7, 75);
			((Control)label39).Name = "label39";
			((Control)label39).Size = new Size(37, 12);
			((Control)label39).TabIndex = 116;
			((Control)label39).Text = "호가 :";
			((ListControl)comboBox_주문유형).FormattingEnabled = true;
			((Control)comboBox_주문유형).Location = new Point(51, 49);
			((Control)comboBox_주문유형).Name = "comboBox_주문유형";
			((Control)comboBox_주문유형).Size = new Size(100, 20);
			((Control)comboBox_주문유형).TabIndex = 117;
			((ListControl)comboBox_호가유형).FormattingEnabled = true;
			((Control)comboBox_호가유형).Location = new Point(50, 72);
			((Control)comboBox_호가유형).Name = "comboBox_호가유형";
			((Control)comboBox_호가유형).Size = new Size(100, 20);
			((Control)comboBox_호가유형).TabIndex = 118;
			comboBox_호가유형.SelectedIndexChanged += comboBox_호가유형_SelectedIndexChanged;
			dgv호가창.AllowUserToAddRows = false;
			dgv호가창.AllowUserToDeleteRows = false;
			dgv호가창.AllowUserToResizeColumns = false;
			dgv호가창.AllowUserToResizeRows = false;
			dgv호가창.BackgroundColor = SystemColors.ButtonHighlight;
			val.Alignment = (DataGridViewContentAlignment)32;
			val.BackColor = SystemColors.Control;
			val.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val.ForeColor = SystemColors.WindowText;
			val.SelectionBackColor = SystemColors.Highlight;
			val.SelectionForeColor = SystemColors.HighlightText;
			val.WrapMode = (DataGridViewTriState)1;
			dgv호가창.ColumnHeadersDefaultCellStyle = val;
			dgv호가창.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
			dgv호가창.Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[4]
			{
				(DataGridViewColumn)Column1,
				(DataGridViewColumn)Column2,
				(DataGridViewColumn)Column3,
				(DataGridViewColumn)Column4
			});
			val2.Alignment = (DataGridViewContentAlignment)32;
			val2.BackColor = SystemColors.Window;
			val2.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val2.ForeColor = SystemColors.ControlText;
			val2.SelectionBackColor = SystemColors.Highlight;
			val2.SelectionForeColor = SystemColors.HighlightText;
			val2.WrapMode = (DataGridViewTriState)2;
			dgv호가창.DefaultCellStyle = val2;
			dgv호가창.GridColor = SystemColors.ActiveCaptionText;
			((Control)dgv호가창).Location = new Point(7, 28);
			((Control)dgv호가창).Name = "dgv호가창";
			dgv호가창.ReadOnly = true;
			dgv호가창.RowHeadersVisible = false;
			dgv호가창.RowHeadersWidth = 9;
			dgv호가창.RowTemplate.Height = 23;
			dgv호가창.ScrollBars = (ScrollBars)0;
			((Control)dgv호가창).Size = new Size(305, 253);
			((Control)dgv호가창).TabIndex = 119;
			dgv호가창.CellClick += new DataGridViewCellEventHandler(dgv호가창_CellClick);
			((DataGridViewColumn)Column1).HeaderText = "잔량";
			((DataGridViewColumn)Column1).Name = "Column1";
			((DataGridViewBand)Column1).ReadOnly = true;
			((DataGridViewColumn)Column1).Width = 70;
			((DataGridViewColumn)Column2).HeaderText = "매도호가";
			((DataGridViewColumn)Column2).Name = "Column2";
			((DataGridViewBand)Column2).ReadOnly = true;
			((DataGridViewColumn)Column2).Width = 80;
			((DataGridViewColumn)Column3).HeaderText = "매수호가";
			((DataGridViewColumn)Column3).Name = "Column3";
			((DataGridViewBand)Column3).ReadOnly = true;
			((DataGridViewColumn)Column3).Width = 80;
			((DataGridViewColumn)Column4).HeaderText = "잔량";
			((DataGridViewColumn)Column4).Name = "Column4";
			((DataGridViewBand)Column4).ReadOnly = true;
			((DataGridViewColumn)Column4).Width = 70;
			((Control)btn종목조회).Location = new Point(110, 25);
			((Control)btn종목조회).Name = "btn종목조회";
			((Control)btn종목조회).Size = new Size(57, 21);
			((Control)btn종목조회).TabIndex = 120;
			((Control)btn종목조회).Text = "조회";
			((ButtonBase)btn종목조회).UseVisualStyleBackColor = true;
			((Control)btn종목조회).Click += btn종목조회_Click;
			((Control)btn계좌조회).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn계좌조회).Location = new Point(241, 14);
			((Control)btn계좌조회).Name = "btn계좌조회";
			((Control)btn계좌조회).Size = new Size(77, 21);
			((Control)btn계좌조회).TabIndex = 121;
			((Control)btn계좌조회).Text = "계좌조회";
			((ButtonBase)btn계좌조회).UseVisualStyleBackColor = true;
			((Control)btn계좌조회).Click += btn계좌조회_Click;
			dgv계좌.AllowUserToAddRows = false;
			dgv계좌.AllowUserToDeleteRows = false;
			dgv계좌.AllowUserToResizeColumns = false;
			dgv계좌.AllowUserToResizeRows = false;
			dgv계좌.BackgroundColor = SystemColors.ButtonHighlight;
			val3.Alignment = (DataGridViewContentAlignment)32;
			val3.BackColor = SystemColors.Control;
			val3.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val3.ForeColor = SystemColors.WindowText;
			val3.SelectionBackColor = SystemColors.Highlight;
			val3.SelectionForeColor = SystemColors.HighlightText;
			val3.WrapMode = (DataGridViewTriState)1;
			dgv계좌.ColumnHeadersDefaultCellStyle = val3;
			dgv계좌.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
			dgv계좌.Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[11]
			{
				(DataGridViewColumn)Column16,
				(DataGridViewColumn)Column5,
				(DataGridViewColumn)Column6,
				(DataGridViewColumn)Column10,
				(DataGridViewColumn)Column7,
				(DataGridViewColumn)Column19,
				(DataGridViewColumn)Column8,
				(DataGridViewColumn)Column17,
				(DataGridViewColumn)Column18,
				(DataGridViewColumn)Column15,
				(DataGridViewColumn)Column25
			});
			val4.Alignment = (DataGridViewContentAlignment)32;
			val4.BackColor = SystemColors.Window;
			val4.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val4.ForeColor = SystemColors.ControlText;
			val4.SelectionBackColor = SystemColors.Highlight;
			val4.SelectionForeColor = SystemColors.HighlightText;
			val4.WrapMode = (DataGridViewTriState)2;
			dgv계좌.DefaultCellStyle = val4;
			((Control)dgv계좌).Location = new Point(4, 93);
			((Control)dgv계좌).Name = "dgv계좌";
			dgv계좌.RowHeadersVisible = false;
			dgv계좌.RowHeadersWidth = 5;
			dgv계좌.RowTemplate.Height = 23;
			((Control)dgv계좌).Size = new Size(660, 189);
			((Control)dgv계좌).TabIndex = 122;
			dgv계좌.CellClick += new DataGridViewCellEventHandler(dgv계좌_CellClick);
			dgv계좌.CellMouseUp += new DataGridViewCellMouseEventHandler(dgv계좌_CellMouseUp);
			dgv계좌.CellPainting += new DataGridViewCellPaintingEventHandler(dgv계좌_CellPainting);
			((DataGridViewColumn)Column16).HeaderText = " ";
			((DataGridViewColumn)Column16).Name = "Column16";
			((DataGridViewColumn)Column16).Width = 30;
			((DataGridViewColumn)Column5).HeaderText = "종목명";
			((DataGridViewColumn)Column5).Name = "Column5";
			((DataGridViewBand)Column5).ReadOnly = true;
			((DataGridViewColumn)Column5).Width = 85;
			val5.Format = "C0";
			val5.NullValue = null;
			((DataGridViewBand)Column6).DefaultCellStyle = val5;
			((DataGridViewColumn)Column6).HeaderText = "매수가";
			((DataGridViewColumn)Column6).Name = "Column6";
			((DataGridViewBand)Column6).ReadOnly = true;
			((DataGridViewColumn)Column6).Width = 65;
			val6.Format = "C0";
			val6.NullValue = null;
			((DataGridViewBand)Column10).DefaultCellStyle = val6;
			((DataGridViewColumn)Column10).HeaderText = "현재가";
			((DataGridViewColumn)Column10).Name = "Column10";
			((DataGridViewBand)Column10).ReadOnly = true;
			((DataGridViewColumn)Column10).Width = 65;
			((DataGridViewColumn)Column7).HeaderText = "보유수량";
			((DataGridViewColumn)Column7).Name = "Column7";
			((DataGridViewBand)Column7).ReadOnly = true;
			((DataGridViewColumn)Column7).Width = 75;
			((DataGridViewColumn)Column19).HeaderText = "가능수량";
			((DataGridViewColumn)Column19).Name = "Column19";
			((DataGridViewBand)Column19).ReadOnly = true;
			((DataGridViewColumn)Column19).Width = 75;
			val7.NullValue = null;
			((DataGridViewBand)Column8).DefaultCellStyle = val7;
			((DataGridViewColumn)Column8).HeaderText = "수익률";
			((DataGridViewColumn)Column8).Name = "Column8";
			((DataGridViewBand)Column8).ReadOnly = true;
			((DataGridViewColumn)Column8).Width = 65;
			val8.Format = "C0";
			val8.NullValue = null;
			((DataGridViewBand)Column17).DefaultCellStyle = val8;
			((DataGridViewColumn)Column17).HeaderText = "고점";
			((DataGridViewColumn)Column17).Name = "Column17";
			((DataGridViewColumn)Column17).Width = 65;
			((DataGridViewColumn)Column18).HeaderText = "고점대비";
			((DataGridViewColumn)Column18).Name = "Column18";
			((DataGridViewColumn)Column18).Width = 70;
			((DataGridViewColumn)Column15).HeaderText = "청산";
			((DataGridViewColumn)Column15).Name = "Column15";
			((DataGridViewBand)Column15).ReadOnly = true;
			((DataGridViewBand)Column15).Resizable = (DataGridViewTriState)2;
			((DataGridViewColumn)Column15).Width = 45;
			((DataGridViewColumn)Column25).HeaderText = "C";
			((DataGridViewColumn)Column25).Name = "Column25";
			((DataGridViewBand)Column25).Visible = false;
			((DataGridViewColumn)Column25).Width = 5;
			comboBox_키움조건식.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_키움조건식).FormattingEnabled = true;
			((Control)comboBox_키움조건식).Location = new Point(11, 20);
			((Control)comboBox_키움조건식).Name = "comboBox_키움조건식";
			((Control)comboBox_키움조건식).Size = new Size(141, 20);
			((Control)comboBox_키움조건식).TabIndex = 123;
			((Control)label40).AutoSize = true;
			((Control)label40).Location = new Point(375, 48);
			((Control)label40).Name = "label40";
			((Control)label40).Size = new Size(37, 12);
			((Control)label40).TabIndex = 129;
			((Control)label40).Text = "금액 :";
			((Control)label41).AutoSize = true;
			((Control)label41).Location = new Point(324, 17);
			((Control)label41).Name = "label41";
			((Control)label41).Size = new Size(61, 12);
			((Control)label41).TabIndex = 132;
			((Control)label41).Text = "계좌잔액 :";
			((Control)txt계좌잔액).Location = new Point(391, 15);
			((Control)txt계좌잔액).Name = "txt계좌잔액";
			((TextBoxBase)txt계좌잔액).ReadOnly = true;
			((Control)txt계좌잔액).Size = new Size(85, 21);
			((Control)txt계좌잔액).TabIndex = 131;
			((Control)txt계좌잔액).Text = "0";
			txt계좌잔액.TextAlign = (HorizontalAlignment)1;
			((Control)label42).AutoSize = true;
			((Control)label42).Location = new Point(72, 50);
			((Control)label42).Name = "label42";
			((Control)label42).Size = new Size(61, 12);
			((Control)label42).TabIndex = 134;
			((Control)label42).Text = "주문가격 :";
			((ListControl)lst체결창).FormattingEnabled = true;
			lst체결창.HorizontalScrollbar = true;
			lst체결창.ItemHeight = 12;
			((Control)lst체결창).Location = new Point(15, 621);
			((Control)lst체결창).Name = "lst체결창";
			((Control)lst체결창).Size = new Size(510, 136);
			((Control)lst체결창).TabIndex = 136;
			((Control)label43).AutoSize = true;
			((Control)label43).Location = new Point(13, 606);
			((Control)label43).Name = "label43";
			((Control)label43).Size = new Size(53, 12);
			((Control)label43).TabIndex = 137;
			((Control)label43).Text = "체결내역";
			((FileDialog)openFileDialog_조건식).FileName = "openFileDialog1";
			((FileDialog)saveFileDialog_조건식).Filter = "*.txt|*.*";
			((FileDialog)saveFileDialog_조건식).Title = "관심종목1 열기";
			((Control)groupBox_주문).BackColor = Color.AliceBlue;
			((Control)groupBox_주문).Controls.Add((Control)(object)button2);
			((Control)groupBox_주문).Controls.Add((Control)(object)button1);
			((Control)groupBox_주문).Controls.Add((Control)(object)btn종목조회);
			((Control)groupBox_주문).Controls.Add((Control)(object)comboBox_호가유형);
			((Control)groupBox_주문).Controls.Add((Control)(object)comboBox_주문유형);
			((Control)groupBox_주문).Controls.Add((Control)(object)label39);
			((Control)groupBox_주문).Controls.Add((Control)(object)label38);
			((Control)groupBox_주문).Controls.Add((Control)(object)label34);
			((Control)groupBox_주문).Controls.Add((Control)(object)txt원주문번호);
			((Control)groupBox_주문).Controls.Add((Control)(object)btn주문실행);
			((Control)groupBox_주문).Controls.Add((Control)(object)label33);
			((Control)groupBox_주문).Controls.Add((Control)(object)txt주문단가);
			((Control)groupBox_주문).Controls.Add((Control)(object)label32);
			((Control)groupBox_주문).Controls.Add((Control)(object)txt주문수량);
			((Control)groupBox_주문).Controls.Add((Control)(object)label31);
			((Control)groupBox_주문).Controls.Add((Control)(object)txt주문종목코드);
			((Control)groupBox_주문).Controls.Add((Control)(object)lbl아이디);
			((Control)groupBox_주문).Controls.Add((Control)(object)lbl이름);
			((Control)groupBox_주문).Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			((Control)groupBox_주문).Location = new Point(10, 32);
			((Control)groupBox_주문).Name = "groupBox_주문";
			((Control)groupBox_주문).Size = new Size(175, 201);
			((Control)groupBox_주문).TabIndex = 140;
			groupBox_주문.TabStop = false;
			((Control)groupBox_주문).Text = "주문";
			((Control)button2).Location = new Point(132, 145);
			((Control)button2).Name = "button2";
			((Control)button2).Size = new Size(37, 18);
			((Control)button2).TabIndex = 122;
			((Control)button2).Text = "button2";
			((ButtonBase)button2).UseVisualStyleBackColor = true;
			((Control)button2).Visible = false;
			((Control)button2).Click += button2_Click;
			((Control)button1).Location = new Point(94, 168);
			((Control)button1).Name = "button1";
			((Control)button1).Size = new Size(75, 23);
			((Control)button1).TabIndex = 121;
			((Control)button1).Text = "button1";
			((ButtonBase)button1).UseVisualStyleBackColor = true;
			((Control)button1).Visible = false;
			((Control)button1).Click += button1_Click;
			((Control)groupBox_계좌).BackColor = Color.MintCream;
			((Control)groupBox_계좌).Controls.Add((Control)(object)txt보유종목누적수익률);
			((Control)groupBox_계좌).Controls.Add((Control)(object)label15);
			((Control)groupBox_계좌).Controls.Add((Control)(object)btn유료신청방법);
			((Control)groupBox_계좌).Controls.Add((Control)(object)btn계좌_일괄청산);
			((Control)groupBox_계좌).Controls.Add((Control)(object)label12);
			((Control)groupBox_계좌).Controls.Add((Control)(object)comboBox_계좌_분할옵션);
			((Control)groupBox_계좌).Controls.Add((Control)(object)comboBox_계좌_분할기준);
			((Control)groupBox_계좌).Controls.Add((Control)(object)btn계좌_분할매도);
			((Control)groupBox_계좌).Controls.Add((Control)(object)comboBox_계좌_보유종목수제한);
			((Control)groupBox_계좌).Controls.Add((Control)(object)label11);
			((Control)groupBox_계좌).Controls.Add((Control)(object)lbl계좌_일괄청산);
			((Control)groupBox_계좌).Controls.Add((Control)(object)comboBox_계좌일괄청산시간);
			((Control)groupBox_계좌).Controls.Add((Control)(object)label3);
			((Control)groupBox_계좌).Controls.Add((Control)(object)btn_계좌_비밀번호입력창);
			((Control)groupBox_계좌).Controls.Add((Control)(object)comboBox_계좌손절손실률);
			((Control)groupBox_계좌).Controls.Add((Control)(object)lbl계좌_자동손절);
			((Control)groupBox_계좌).Controls.Add((Control)(object)btn계좌_자동손절);
			((Control)groupBox_계좌).Controls.Add((Control)(object)label4);
			((Control)groupBox_계좌).Controls.Add((Control)(object)label41);
			((Control)groupBox_계좌).Controls.Add((Control)(object)txt계좌잔액);
			((Control)groupBox_계좌).Controls.Add((Control)(object)dgv계좌);
			((Control)groupBox_계좌).Controls.Add((Control)(object)btn계좌조회);
			((Control)groupBox_계좌).Controls.Add((Control)(object)comboBox_계좌번호);
			((Control)groupBox_계좌).Location = new Point(191, 33);
			((Control)groupBox_계좌).Name = "groupBox_계좌";
			((Control)groupBox_계좌).Size = new Size(671, 288);
			((Control)groupBox_계좌).TabIndex = 141;
			groupBox_계좌.TabStop = false;
			((Control)groupBox_계좌).Text = "계좌정보";
			((Control)txt보유종목누적수익률).BackColor = SystemColors.ButtonFace;
			((Control)txt보유종목누적수익률).Location = new Point(598, 66);
			((Control)txt보유종목누적수익률).Name = "txt보유종목누적수익률";
			((Control)txt보유종목누적수익률).Size = new Size(66, 21);
			((Control)txt보유종목누적수익률).TabIndex = 152;
			txt보유종목누적수익률.TextAlign = (HorizontalAlignment)1;
			((Control)label15).AutoSize = true;
			((Control)label15).Location = new Point(467, 70);
			((Control)label15).Name = "label15";
			((Control)label15).Size = new Size(125, 12);
			((Control)label15).TabIndex = 151;
			((Control)label15).Text = "보유종목 누적수익률 :";
			((Control)btn유료신청방법).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn유료신청방법).Location = new Point(573, 36);
			((Control)btn유료신청방법).Name = "btn유료신청방법";
			((Control)btn유료신청방법).Size = new Size(92, 21);
			((Control)btn유료신청방법).TabIndex = 150;
			((Control)btn유료신청방법).Text = "유료신청방법";
			((ButtonBase)btn유료신청방법).UseVisualStyleBackColor = true;
			((Control)btn유료신청방법).Click += btn유료신청방법_Click;
			((Control)btn계좌_일괄청산).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn계좌_일괄청산).Location = new Point(487, 36);
			((Control)btn계좌_일괄청산).Name = "btn계좌_일괄청산";
			((Control)btn계좌_일괄청산).Size = new Size(56, 21);
			((Control)btn계좌_일괄청산).TabIndex = 148;
			((Control)btn계좌_일괄청산).Text = "설정";
			((ButtonBase)btn계좌_일괄청산).UseVisualStyleBackColor = true;
			((Control)btn계좌_일괄청산).Click += btn계좌_일괄청산_Click;
			((Control)label12).AutoSize = true;
			((Control)label12).Location = new Point(93, 70);
			((Control)label12).Name = "label12";
			((Control)label12).Size = new Size(29, 12);
			((Control)label12).TabIndex = 149;
			((Control)label12).Text = "대비";
			comboBox_계좌_분할옵션.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_계좌_분할옵션).FormattingEnabled = true;
			((Control)comboBox_계좌_분할옵션).Location = new Point(123, 66);
			((Control)comboBox_계좌_분할옵션).Name = "comboBox_계좌_분할옵션";
			((Control)comboBox_계좌_분할옵션).Size = new Size(245, 20);
			((Control)comboBox_계좌_분할옵션).TabIndex = 148;
			comboBox_계좌_분할기준.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_계좌_분할기준).FormattingEnabled = true;
			((Control)comboBox_계좌_분할기준).Location = new Point(11, 67);
			((Control)comboBox_계좌_분할기준).Name = "comboBox_계좌_분할기준";
			((Control)comboBox_계좌_분할기준).Size = new Size(75, 20);
			((Control)comboBox_계좌_분할기준).TabIndex = 147;
			((Control)btn계좌_분할매도).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn계좌_분할매도).Location = new Point(374, 65);
			((Control)btn계좌_분할매도).Name = "btn계좌_분할매도";
			((Control)btn계좌_분할매도).Size = new Size(87, 21);
			((Control)btn계좌_분할매도).TabIndex = 146;
			((Control)btn계좌_분할매도).Text = "분할매도";
			((ButtonBase)btn계좌_분할매도).UseVisualStyleBackColor = true;
			((Control)btn계좌_분할매도).Click += btn계좌_분할매도_Click;
			comboBox_계좌_보유종목수제한.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_계좌_보유종목수제한).FormattingEnabled = true;
			((Control)comboBox_계좌_보유종목수제한).Location = new Point(580, 14);
			((Control)comboBox_계좌_보유종목수제한).Name = "comboBox_계좌_보유종목수제한";
			((Control)comboBox_계좌_보유종목수제한).Size = new Size(84, 20);
			((Control)comboBox_계좌_보유종목수제한).TabIndex = 145;
			((Control)label11).AutoSize = true;
			((Control)label11).Location = new Point(489, 17);
			((Control)label11).Name = "label11";
			((Control)label11).Size = new Size(85, 12);
			((Control)label11).TabIndex = 144;
			((Control)label11).Text = "보유종목제한 :";
			((Control)lbl계좌_일괄청산).BackColor = Color.Red;
			((Control)lbl계좌_일괄청산).ForeColor = Color.White;
			((Control)lbl계좌_일괄청산).Location = new Point(544, 36);
			((Control)lbl계좌_일괄청산).Name = "lbl계좌_일괄청산";
			((Control)lbl계좌_일괄청산).Size = new Size(20, 20);
			((Control)lbl계좌_일괄청산).TabIndex = 143;
			((Control)lbl계좌_일괄청산).Text = "F";
			lbl계좌_일괄청산.TextAlign = (ContentAlignment)32;
			comboBox_계좌일괄청산시간.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_계좌일괄청산시간).FormattingEnabled = true;
			((Control)comboBox_계좌일괄청산시간).Location = new Point(419, 37);
			((Control)comboBox_계좌일괄청산시간).Name = "comboBox_계좌일괄청산시간";
			((Control)comboBox_계좌일괄청산시간).Size = new Size(64, 20);
			((Control)comboBox_계좌일괄청산시간).TabIndex = 141;
			((Control)label3).AutoSize = true;
			((Control)label3).Location = new Point(340, 41);
			((Control)label3).Name = "label3";
			((Control)label3).Size = new Size(75, 12);
			((Control)label3).TabIndex = 140;
			((Control)label3).Text = "|  일괄청산 :";
			((Control)btn_계좌_비밀번호입력창).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn_계좌_비밀번호입력창).Location = new Point(127, 13);
			((Control)btn_계좌_비밀번호입력창).Name = "btn_계좌_비밀번호입력창";
			((Control)btn_계좌_비밀번호입력창).Size = new Size(109, 21);
			((Control)btn_계좌_비밀번호입력창).TabIndex = 139;
			((Control)btn_계좌_비밀번호입력창).Text = "비밀번호 입력";
			((ButtonBase)btn_계좌_비밀번호입력창).UseVisualStyleBackColor = true;
			((Control)btn_계좌_비밀번호입력창).Click += btn_계좌_비밀번호입력창_Click;
			comboBox_계좌손절손실률.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_계좌손절손실률).FormattingEnabled = true;
			((Control)comboBox_계좌손절손실률).Location = new Point(78, 37);
			((Control)comboBox_계좌손절손실률).Name = "comboBox_계좌손절손실률";
			((Control)comboBox_계좌손절손실률).Size = new Size(158, 20);
			((Control)comboBox_계좌손절손실률).TabIndex = 138;
			((Control)lbl계좌_자동손절).BackColor = Color.Red;
			((Control)lbl계좌_자동손절).ForeColor = Color.White;
			((Control)lbl계좌_자동손절).Location = new Point(319, 36);
			((Control)lbl계좌_자동손절).Name = "lbl계좌_자동손절";
			((Control)lbl계좌_자동손절).Size = new Size(20, 20);
			((Control)lbl계좌_자동손절).TabIndex = 137;
			((Control)lbl계좌_자동손절).Text = "F";
			lbl계좌_자동손절.TextAlign = (ContentAlignment)32;
			((Control)btn계좌_자동손절).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn계좌_자동손절).Location = new Point(240, 36);
			((Control)btn계좌_자동손절).Name = "btn계좌_자동손절";
			((Control)btn계좌_자동손절).Size = new Size(78, 21);
			((Control)btn계좌_자동손절).TabIndex = 134;
			((Control)btn계좌_자동손절).Text = "자동손절";
			((ButtonBase)btn계좌_자동손절).UseVisualStyleBackColor = true;
			((Control)btn계좌_자동손절).Click += btn계좌_자동손절_Click;
			((Control)label4).AutoSize = true;
			((Control)label4).Location = new Point(11, 42);
			((Control)label4).Name = "label4";
			((Control)label4).Size = new Size(61, 12);
			((Control)label4).TabIndex = 133;
			((Control)label4).Text = "자동손절 :";
			((Control)groupBox_종목정보).BackColor = Color.SeaShell;
			((Control)groupBox_종목정보).Controls.Add((Control)(object)label2);
			((Control)groupBox_종목정보).Controls.Add((Control)(object)dgv호가창);
			((Control)groupBox_종목정보).Controls.Add((Control)(object)lbl주문종목명);
			((Control)groupBox_종목정보).Location = new Point(12, 327);
			((Control)groupBox_종목정보).Name = "groupBox_종목정보";
			((Control)groupBox_종목정보).Size = new Size(315, 276);
			((Control)groupBox_종목정보).TabIndex = 142;
			groupBox_종목정보.TabStop = false;
			((Control)groupBox_종목정보).Text = "종목정보";
			((Control)label2).AutoSize = true;
			((Control)label2).Location = new Point(6, 14);
			((Control)label2).Name = "label2";
			((Control)label2).Size = new Size(53, 12);
			((Control)label2).TabIndex = 122;
			((Control)label2).Text = "종목명 : ";
			((Control)lbl현재시간).AutoSize = true;
			((Control)lbl현재시간).BackColor = SystemColors.ControlDark;
			((Control)lbl현재시간).Font = new Font("굴림", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)lbl현재시간).ForeColor = Color.White;
			((Control)lbl현재시간).Location = new Point(597, 0);
			((Control)lbl현재시간).Name = "lbl현재시간";
			((Control)lbl현재시간).Size = new Size(29, 19);
			((Control)lbl현재시간).TabIndex = 143;
			((Control)lbl현재시간).Text = "ㅇ";
			((Control)groupBox_조건식).BackColor = Color.PapayaWhip;
			((Control)groupBox_조건식).Controls.Add((Control)(object)btn조건식조회등록);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_조건_매수종목수);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label9);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_조건_동작시간_끝);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label8);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_조건_동작시간_시작);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label7);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_예약매도_복합옵션);
			((Control)groupBox_조건식).Controls.Add((Control)(object)radioButton_예약매도_복합);
			((Control)groupBox_조건식).Controls.Add((Control)(object)radioButton_예약매도_단순);
			((Control)groupBox_조건식).Controls.Add((Control)(object)checkBox_예약매도);
			((Control)groupBox_조건식).Controls.Add((Control)(object)btn조건식매도등록);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label6);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_예약매도_수익률);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_예약매도_수익비중);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_자동매수금액);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_자동매수호가);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label1);
			((Control)groupBox_조건식).Controls.Add((Control)(object)btn조건식매수등록);
			((Control)groupBox_조건식).Controls.Add((Control)(object)comboBox_키움조건식);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label42);
			((Control)groupBox_조건식).Controls.Add((Control)(object)label40);
			((Control)groupBox_조건식).Location = new Point(333, 327);
			((Control)groupBox_조건식).Name = "groupBox_조건식";
			((Control)groupBox_조건식).Size = new Size(529, 152);
			((Control)groupBox_조건식).TabIndex = 145;
			groupBox_조건식.TabStop = false;
			((Control)groupBox_조건식).Text = "조건식";
			((Control)btn조건식조회등록).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn조건식조회등록).ForeColor = Color.Black;
			((Control)btn조건식조회등록).Location = new Point(262, 20);
			((Control)btn조건식조회등록).Name = "btn조건식조회등록";
			((Control)btn조건식조회등록).Size = new Size(113, 21);
			((Control)btn조건식조회등록).TabIndex = 164;
			((Control)btn조건식조회등록).Text = "단순조회 등록";
			((ButtonBase)btn조건식조회등록).UseVisualStyleBackColor = true;
			((Control)btn조건식조회등록).Click += btn조건식조회등록_Click;
			comboBox_조건_매수종목수.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_조건_매수종목수).FormattingEnabled = true;
			((Control)comboBox_조건_매수종목수).Location = new Point(418, 117);
			((Control)comboBox_조건_매수종목수).Name = "comboBox_조건_매수종목수";
			((Control)comboBox_조건_매수종목수).Size = new Size(78, 20);
			((Control)comboBox_조건_매수종목수).TabIndex = 163;
			((Control)label9).AutoSize = true;
			((Control)label9).Location = new Point(305, 120);
			((Control)label9).Name = "label9";
			((Control)label9).Size = new Size(107, 12);
			((Control)label9).TabIndex = 162;
			((Control)label9).Text = "|  매수 종목 제한 :";
			comboBox_조건_동작시간_끝.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_조건_동작시간_끝).FormattingEnabled = true;
			((Control)comboBox_조건_동작시간_끝).Location = new Point(221, 117);
			((Control)comboBox_조건_동작시간_끝).Name = "comboBox_조건_동작시간_끝";
			((Control)comboBox_조건_동작시간_끝).Size = new Size(78, 20);
			((Control)comboBox_조건_동작시간_끝).TabIndex = 161;
			comboBox_조건_동작시간_끝.SelectedIndexChanged += comboBox_조건_동작시간_끝_SelectedIndexChanged;
			((Control)label8).AutoSize = true;
			((Control)label8).Font = new Font("굴림", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)label8).Location = new Point(200, 120);
			((Control)label8).Name = "label8";
			((Control)label8).Size = new Size(19, 15);
			((Control)label8).TabIndex = 160;
			((Control)label8).Text = "~";
			comboBox_조건_동작시간_시작.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_조건_동작시간_시작).FormattingEnabled = true;
			((Control)comboBox_조건_동작시간_시작).Location = new Point(120, 117);
			((Control)comboBox_조건_동작시간_시작).Name = "comboBox_조건_동작시간_시작";
			((Control)comboBox_조건_동작시간_시작).Size = new Size(78, 20);
			((Control)comboBox_조건_동작시간_시작).TabIndex = 144;
			comboBox_조건_동작시간_시작.SelectedIndexChanged += comboBox_조건_동작시간_시작_SelectedIndexChanged;
			((Control)label7).AutoSize = true;
			((Control)label7).Location = new Point(9, 120);
			((Control)label7).Name = "label7";
			((Control)label7).Size = new Size(105, 12);
			((Control)label7).TabIndex = 159;
			((Control)label7).Text = "조건식 매수 시간 :";
			comboBox_예약매도_복합옵션.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_예약매도_복합옵션).FormattingEnabled = true;
			((Control)comboBox_예약매도_복합옵션).Location = new Point(205, 92);
			((Control)comboBox_예약매도_복합옵션).Name = "comboBox_예약매도_복합옵션";
			((Control)comboBox_예약매도_복합옵션).Size = new Size(270, 20);
			((Control)comboBox_예약매도_복합옵션).TabIndex = 158;
			((Control)radioButton_예약매도_복합).AutoSize = true;
			((Control)radioButton_예약매도_복합).Location = new Point(124, 93);
			((Control)radioButton_예약매도_복합).Name = "radioButton_예약매도_복합";
			((Control)radioButton_예약매도_복합).Size = new Size(83, 16);
			((Control)radioButton_예약매도_복합).TabIndex = 157;
			((Control)radioButton_예약매도_복합).Text = "복합 옵션 :";
			((ButtonBase)radioButton_예약매도_복합).UseVisualStyleBackColor = true;
			((Control)radioButton_예약매도_단순).AutoSize = true;
			radioButton_예약매도_단순.Checked = true;
			((Control)radioButton_예약매도_단순).Location = new Point(124, 71);
			((Control)radioButton_예약매도_단순).Name = "radioButton_예약매도_단순";
			((Control)radioButton_예약매도_단순).Size = new Size(147, 16);
			((Control)radioButton_예약매도_단순).TabIndex = 156;
			radioButton_예약매도_단순.TabStop = true;
			((Control)radioButton_예약매도_단순).Text = "단순 : 매수주문 수량의";
			((ButtonBase)radioButton_예약매도_단순).UseVisualStyleBackColor = true;
			((Control)checkBox_예약매도).AutoSize = true;
			((Control)checkBox_예약매도).Location = new Point(4, 72);
			((Control)checkBox_예약매도).Name = "checkBox_예약매도";
			((Control)checkBox_예약매도).Size = new Size(122, 16);
			((Control)checkBox_예약매도).TabIndex = 155;
			((Control)checkBox_예약매도).Text = "매수후 예약매도 -";
			((ButtonBase)checkBox_예약매도).UseVisualStyleBackColor = true;
			((Control)label6).AutoSize = true;
			((Control)label6).Location = new Point(352, 73);
			((Control)label6).Name = "label6";
			((Control)label6).Size = new Size(49, 12);
			((Control)label6).TabIndex = 154;
			((Control)label6).Text = ", 수익률";
			comboBox_예약매도_수익률.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_예약매도_수익률).FormattingEnabled = true;
			((Control)comboBox_예약매도_수익률).Location = new Point(407, 70);
			((Control)comboBox_예약매도_수익률).Name = "comboBox_예약매도_수익률";
			((Control)comboBox_예약매도_수익률).Size = new Size(68, 20);
			((Control)comboBox_예약매도_수익률).TabIndex = 153;
			comboBox_예약매도_수익비중.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_예약매도_수익비중).FormattingEnabled = true;
			((Control)comboBox_예약매도_수익비중).Location = new Point(276, 70);
			((Control)comboBox_예약매도_수익비중).Name = "comboBox_예약매도_수익비중";
			((Control)comboBox_예약매도_수익비중).Size = new Size(70, 20);
			((Control)comboBox_예약매도_수익비중).TabIndex = 152;
			comboBox_자동매수금액.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_자동매수금액).FormattingEnabled = true;
			((Control)comboBox_자동매수금액).Location = new Point(416, 44);
			((Control)comboBox_자동매수금액).Name = "comboBox_자동매수금액";
			((Control)comboBox_자동매수금액).Size = new Size(106, 20);
			((Control)comboBox_자동매수금액).TabIndex = 148;
			comboBox_자동매수호가.DropDownStyle = (ComboBoxStyle)2;
			((ListControl)comboBox_자동매수호가).FormattingEnabled = true;
			((Control)comboBox_자동매수호가).Location = new Point(136, 44);
			((Control)comboBox_자동매수호가).Name = "comboBox_자동매수호가";
			((Control)comboBox_자동매수호가).Size = new Size(233, 20);
			((Control)comboBox_자동매수호가).TabIndex = 147;
			((Control)label1).AutoSize = true;
			((Control)label1).Location = new Point(9, 50);
			((Control)label1).Name = "label1";
			((Control)label1).Size = new Size(59, 12);
			((Control)label1).TabIndex = 146;
			((Control)label1).Text = "매수조건-";
			((Control)btn조건식매도등록).Enabled = false;
			((Control)btn조건식매도등록).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn조건식매도등록).ForeColor = SystemColors.MenuHighlight;
			((Control)btn조건식매도등록).Location = new Point(381, 20);
			((Control)btn조건식매도등록).Name = "btn조건식매도등록";
			((Control)btn조건식매도등록).Size = new Size(115, 21);
			((Control)btn조건식매도등록).TabIndex = 128;
			((Control)btn조건식매도등록).Text = "매도 등록(불가)";
			((ButtonBase)btn조건식매도등록).UseVisualStyleBackColor = true;
			((Control)btn조건식매도등록).Visible = false;
			((Control)btn조건식매도등록).Click += btn조건식매도등록_Click;
			((Control)btn조건식매수등록).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn조건식매수등록).ForeColor = Color.Red;
			((Control)btn조건식매수등록).Location = new Point(158, 20);
			((Control)btn조건식매수등록).Name = "btn조건식매수등록";
			((Control)btn조건식매수등록).Size = new Size(98, 21);
			((Control)btn조건식매수등록).TabIndex = 127;
			((Control)btn조건식매수등록).Text = "매수 등록";
			((ButtonBase)btn조건식매수등록).UseVisualStyleBackColor = true;
			((Control)btn조건식매수등록).Click += btn조건식매수등록_Click;
			dgv조건식목록.AllowUserToAddRows = false;
			dgv조건식목록.AllowUserToDeleteRows = false;
			dgv조건식목록.AllowUserToResizeColumns = false;
			dgv조건식목록.AllowUserToResizeRows = false;
			dgv조건식목록.BackgroundColor = SystemColors.ButtonHighlight;
			val9.Alignment = (DataGridViewContentAlignment)32;
			val9.BackColor = SystemColors.Control;
			val9.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val9.ForeColor = SystemColors.WindowText;
			val9.SelectionBackColor = SystemColors.Highlight;
			val9.SelectionForeColor = SystemColors.HighlightText;
			val9.WrapMode = (DataGridViewTriState)1;
			dgv조건식목록.ColumnHeadersDefaultCellStyle = val9;
			dgv조건식목록.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
			dgv조건식목록.Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[5]
			{
				(DataGridViewColumn)Column24,
				(DataGridViewColumn)Column20,
				(DataGridViewColumn)Column21,
				(DataGridViewColumn)Column22,
				(DataGridViewColumn)Column23
			});
			val10.Alignment = (DataGridViewContentAlignment)32;
			val10.BackColor = SystemColors.Window;
			val10.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val10.ForeColor = SystemColors.ControlText;
			val10.SelectionBackColor = SystemColors.Highlight;
			val10.SelectionForeColor = SystemColors.HighlightText;
			val10.WrapMode = (DataGridViewTriState)2;
			dgv조건식목록.DefaultCellStyle = val10;
			((Control)dgv조건식목록).Location = new Point(333, 482);
			((Control)dgv조건식목록).Name = "dgv조건식목록";
			dgv조건식목록.ReadOnly = true;
			dgv조건식목록.RowHeadersVisible = false;
			dgv조건식목록.RowHeadersWidth = 5;
			dgv조건식목록.RowTemplate.Height = 23;
			((Control)dgv조건식목록).Size = new Size(890, 126);
			((Control)dgv조건식목록).TabIndex = 129;
			dgv조건식목록.CellClick += new DataGridViewCellEventHandler(dgv조건식목록_CellClick);
			((DataGridViewColumn)Column24).HeaderText = "I";
			((DataGridViewColumn)Column24).Name = "Column24";
			((DataGridViewBand)Column24).ReadOnly = true;
			((DataGridViewColumn)Column24).Width = 30;
			((DataGridViewColumn)Column20).HeaderText = "조건명";
			((DataGridViewColumn)Column20).Name = "Column20";
			((DataGridViewBand)Column20).ReadOnly = true;
			((DataGridViewColumn)Column21).HeaderText = "구분";
			((DataGridViewColumn)Column21).Name = "Column21";
			((DataGridViewBand)Column21).ReadOnly = true;
			((DataGridViewColumn)Column22).HeaderText = "옵션";
			((DataGridViewColumn)Column22).Name = "Column22";
			((DataGridViewBand)Column22).ReadOnly = true;
			((DataGridViewColumn)Column22).Width = 600;
			((DataGridViewColumn)Column23).HeaderText = "중지";
			((DataGridViewColumn)Column23).Name = "Column23";
			((DataGridViewBand)Column23).ReadOnly = true;
			((DataGridViewColumn)Column23).Width = 40;
			((Control)label5).AutoSize = true;
			((Control)label5).BackColor = SystemColors.ControlDark;
			((Control)label5).Font = new Font("굴림", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)label5).ForeColor = Color.White;
			((Control)label5).Location = new Point(490, 0);
			((Control)label5).Name = "label5";
			((Control)label5).Size = new Size(110, 19);
			((Control)label5).TabIndex = 146;
			((Control)label5).Text = "현재시간 : ";
			dgv조건만족종목.AllowUserToAddRows = false;
			dgv조건만족종목.AllowUserToDeleteRows = false;
			dgv조건만족종목.AllowUserToResizeColumns = false;
			dgv조건만족종목.AllowUserToResizeRows = false;
			dgv조건만족종목.BackgroundColor = SystemColors.ButtonFace;
			val11.Alignment = (DataGridViewContentAlignment)32;
			val11.BackColor = SystemColors.Control;
			val11.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val11.ForeColor = SystemColors.WindowText;
			val11.SelectionBackColor = SystemColors.Highlight;
			val11.SelectionForeColor = SystemColors.HighlightText;
			val11.WrapMode = (DataGridViewTriState)1;
			dgv조건만족종목.ColumnHeadersDefaultCellStyle = val11;
			dgv조건만족종목.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
			dgv조건만족종목.Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[6]
			{
				(DataGridViewColumn)Column14,
				(DataGridViewColumn)Column12,
				(DataGridViewColumn)Column9,
				(DataGridViewColumn)Column13,
				(DataGridViewColumn)Column11,
				(DataGridViewColumn)Column26
			});
			val12.Alignment = (DataGridViewContentAlignment)32;
			val12.BackColor = SystemColors.Window;
			val12.Font = new Font("굴림", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val12.ForeColor = SystemColors.ControlText;
			val12.SelectionBackColor = SystemColors.Highlight;
			val12.SelectionForeColor = SystemColors.HighlightText;
			val12.WrapMode = (DataGridViewTriState)2;
			dgv조건만족종목.DefaultCellStyle = val12;
			((Control)dgv조건만족종목).Location = new Point(6, 67);
			((Control)dgv조건만족종목).Name = "dgv조건만족종목";
			dgv조건만족종목.ReadOnly = true;
			dgv조건만족종목.RowHeadersVisible = false;
			dgv조건만족종목.RowHeadersWidth = 5;
			dgv조건만족종목.RowTemplate.Height = 23;
			((Control)dgv조건만족종목).Size = new Size(439, 339);
			((Control)dgv조건만족종목).TabIndex = 127;
			dgv조건만족종목.CellClick += new DataGridViewCellEventHandler(dgv조건만족종목_CellClick);
			((DataGridViewColumn)Column14).HeaderText = "시간";
			((DataGridViewColumn)Column14).Name = "Column14";
			((DataGridViewBand)Column14).ReadOnly = true;
			((DataGridViewColumn)Column14).Width = 60;
			((DataGridViewColumn)Column12).HeaderText = "코드";
			((DataGridViewColumn)Column12).Name = "Column12";
			((DataGridViewBand)Column12).ReadOnly = true;
			((DataGridViewBand)Column12).Resizable = (DataGridViewTriState)2;
			((DataGridViewColumn)Column12).Width = 70;
			((DataGridViewColumn)Column9).HeaderText = "종목명";
			((DataGridViewColumn)Column9).Name = "Column9";
			((DataGridViewBand)Column9).ReadOnly = true;
			((DataGridViewColumn)Column13).HeaderText = "조건명";
			((DataGridViewColumn)Column13).Name = "Column13";
			((DataGridViewBand)Column13).ReadOnly = true;
			((DataGridViewColumn)Column13).Width = 90;
			((DataGridViewColumn)Column11).HeaderText = "삭제";
			((DataGridViewColumn)Column11).Name = "Column11";
			((DataGridViewBand)Column11).ReadOnly = true;
			((DataGridViewColumn)Column11).Width = 40;
			((DataGridViewColumn)Column26).HeaderText = "매수";
			((DataGridViewColumn)Column26).Name = "Column26";
			((DataGridViewBand)Column26).ReadOnly = true;
			((DataGridViewColumn)Column26).Width = 40;
			((ListControl)comboBox_리스트초기화주기).FormattingEnabled = true;
			((Control)comboBox_리스트초기화주기).Location = new Point(116, 18);
			((Control)comboBox_리스트초기화주기).Name = "comboBox_리스트초기화주기";
			((Control)comboBox_리스트초기화주기).Size = new Size(64, 20);
			((Control)comboBox_리스트초기화주기).TabIndex = 144;
			((Control)btn리스트_초기화).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn리스트_초기화).Location = new Point(186, 18);
			((Control)btn리스트_초기화).Name = "btn리스트_초기화";
			((Control)btn리스트_초기화).Size = new Size(56, 21);
			((Control)btn리스트_초기화).TabIndex = 145;
			((Control)btn리스트_초기화).Text = "설정";
			((ButtonBase)btn리스트_초기화).UseVisualStyleBackColor = true;
			((Control)btn리스트_초기화).Click += btn리스트_초기화_Click;
			((Control)label10).AutoSize = true;
			((Control)label10).Location = new Point(6, 22);
			((Control)label10).Name = "label10";
			((Control)label10).Size = new Size(105, 12);
			((Control)label10).TabIndex = 144;
			((Control)label10).Text = "초기화 주기 설정 :";
			((Control)lbl리스트_초기화셋팅).BackColor = Color.Red;
			((Control)lbl리스트_초기화셋팅).ForeColor = Color.White;
			((Control)lbl리스트_초기화셋팅).Location = new Point(248, 19);
			((Control)lbl리스트_초기화셋팅).Name = "lbl리스트_초기화셋팅";
			((Control)lbl리스트_초기화셋팅).Size = new Size(20, 20);
			((Control)lbl리스트_초기화셋팅).TabIndex = 146;
			((Control)lbl리스트_초기화셋팅).Text = "F";
			lbl리스트_초기화셋팅.TextAlign = (ContentAlignment)32;
			((Control)checkBox_보유종목매수금지).AutoSize = true;
			checkBox_보유종목매수금지.Checked = true;
			checkBox_보유종목매수금지.CheckState = (CheckState)1;
			((Control)checkBox_보유종목매수금지).Location = new Point(300, 10);
			((Control)checkBox_보유종목매수금지).Name = "checkBox_보유종목매수금지";
			((Control)checkBox_보유종목매수금지).Size = new Size(124, 16);
			((Control)checkBox_보유종목매수금지).TabIndex = 164;
			((Control)checkBox_보유종목매수금지).Text = "보유종목 매수금지";
			((ButtonBase)checkBox_보유종목매수금지).UseVisualStyleBackColor = true;
			((Control)groupBox_종목리스트).BackColor = Color.Azure;
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)checkBox_등록시매수주문);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)btn_종목리스트추가);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)label13);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)txt추가종목명);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)checkBox_동일종목주문금지);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)checkBox_보유종목매수금지);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)lbl리스트_초기화셋팅);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)label10);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)btn리스트_초기화);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)comboBox_리스트초기화주기);
			((Control)groupBox_종목리스트).Controls.Add((Control)(object)dgv조건만족종목);
			((Control)groupBox_종목리스트).Location = new Point(868, 33);
			((Control)groupBox_종목리스트).Name = "groupBox_종목리스트";
			((Control)groupBox_종목리스트).Size = new Size(450, 446);
			((Control)groupBox_종목리스트).TabIndex = 147;
			groupBox_종목리스트.TabStop = false;
			((Control)groupBox_종목리스트).Text = "종목 리스트";
			((Control)checkBox_등록시매수주문).AutoSize = true;
			((Control)checkBox_등록시매수주문).Location = new Point(300, 45);
			((Control)checkBox_등록시매수주문).Name = "checkBox_등록시매수주문";
			((Control)checkBox_등록시매수주문).Size = new Size(128, 16);
			((Control)checkBox_등록시매수주문).TabIndex = 166;
			((Control)checkBox_등록시매수주문).Text = "\"등록 시\" 매수 주문";
			((ButtonBase)checkBox_등록시매수주문).UseVisualStyleBackColor = true;
			checkBox_등록시매수주문.CheckedChanged += checkBox_등록시매수주문_CheckedChanged;
			((Control)btn_종목리스트추가).Font = new Font("굴림", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn_종목리스트추가).Location = new Point(235, 414);
			((Control)btn_종목리스트추가).Name = "btn_종목리스트추가";
			((Control)btn_종목리스트추가).Size = new Size(56, 23);
			((Control)btn_종목리스트추가).TabIndex = 150;
			((Control)btn_종목리스트추가).Text = "추가";
			((ButtonBase)btn_종목리스트추가).UseVisualStyleBackColor = true;
			((Control)btn_종목리스트추가).Click += btn_종목리스트추가_Click;
			((Control)label13).AutoSize = true;
			((Control)label13).Font = new Font("굴림", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)label13).Location = new Point(6, 419);
			((Control)label13).Name = "label13";
			((Control)label13).Size = new Size(92, 13);
			((Control)label13).TabIndex = 122;
			((Control)label13).Text = "추가 종목명 :";
			((Control)txt추가종목명).Font = new Font("굴림", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			((Control)txt추가종목명).Location = new Point(104, 415);
			((Control)txt추가종목명).Name = "txt추가종목명";
			((Control)txt추가종목명).Size = new Size(125, 22);
			((Control)txt추가종목명).TabIndex = 122;
			((Control)txt추가종목명).Text = "삼성전자";
			((Control)txt추가종목명).KeyDown += new KeyEventHandler(txt추가종목명_KeyDown);
			((Control)checkBox_동일종목주문금지).AutoSize = true;
			((Control)checkBox_동일종목주문금지).Location = new Point(300, 28);
			((Control)checkBox_동일종목주문금지).Name = "checkBox_동일종목주문금지";
			((Control)checkBox_동일종목주문금지).Size = new Size(124, 16);
			((Control)checkBox_동일종목주문금지).TabIndex = 165;
			((Control)checkBox_동일종목주문금지).Text = "동일종목 주문금지";
			((ButtonBase)checkBox_동일종목주문금지).UseVisualStyleBackColor = true;
			((Control)lbl프로그램상태).BackColor = Color.Red;
			((Control)lbl프로그램상태).ForeColor = Color.White;
			((Control)lbl프로그램상태).Location = new Point(398, 2);
			((Control)lbl프로그램상태).Name = "lbl프로그램상태";
			((Control)lbl프로그램상태).Size = new Size(68, 20);
			((Control)lbl프로그램상태).TabIndex = 144;
			((Control)lbl프로그램상태).Text = "접속 대기";
			lbl프로그램상태.TextAlign = (ContentAlignment)32;
			dgv지수정보.AllowUserToAddRows = false;
			dgv지수정보.AllowUserToResizeColumns = false;
			dgv지수정보.AllowUserToResizeRows = false;
			dgv지수정보.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
			dgv지수정보.Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
			{
				(DataGridViewColumn)Column27,
				(DataGridViewColumn)Column28,
				(DataGridViewColumn)Column29
			});
			((Control)dgv지수정보).Location = new Point(10, 239);
			((Control)dgv지수정보).Name = "dgv지수정보";
			dgv지수정보.RowHeadersVisible = false;
			dgv지수정보.RowTemplate.Height = 23;
			dgv지수정보.ScrollBars = (ScrollBars)0;
			((Control)dgv지수정보).Size = new Size(173, 70);
			((Control)dgv지수정보).TabIndex = 148;
			((DataGridViewColumn)Column27).HeaderText = "코스피";
			((DataGridViewColumn)Column27).Name = "Column27";
			((DataGridViewColumn)Column27).Width = 50;
			((DataGridViewColumn)Column28).HeaderText = "코스닥";
			((DataGridViewColumn)Column28).Name = "Column28";
			((DataGridViewColumn)Column28).Width = 50;
			((DataGridViewColumn)Column29).HeaderText = "코스피200";
			((DataGridViewColumn)Column29).Name = "Column29";
			((DataGridViewColumn)Column29).Width = 70;
			((Control)lbl오늘날짜).AutoSize = true;
			((Control)lbl오늘날짜).BackColor = SystemColors.ControlDark;
			((Control)lbl오늘날짜).Font = new Font("굴림", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)lbl오늘날짜).ForeColor = Color.Black;
			((Control)lbl오늘날짜).Location = new Point(1107, 3);
			((Control)lbl오늘날짜).Name = "lbl오늘날짜";
			((Control)lbl오늘날짜).Size = new Size(29, 19);
			((Control)lbl오늘날짜).TabIndex = 149;
			((Control)lbl오늘날짜).Text = "ㅇ";
			((AxHost)axKHOpenAPI).Enabled = true;
			((Control)axKHOpenAPI).Location = new Point(1244, 650);
			((Control)axKHOpenAPI).Name = "axKHOpenAPI";
			((AxHost)axKHOpenAPI).OcxState = (State)componentResourceManager.GetObject("axKHOpenAPI.OcxState");
			((Control)axKHOpenAPI).Size = new Size(80, 31);
			((Control)axKHOpenAPI).TabIndex = 11;
			((Control)axKHOpenAPI).Visible = false;
			axKHOpenAPI.OnReceiveTrData += new _DKHOpenAPIEvents_OnReceiveTrDataEventHandler(axKHOpenAPI_OnReceiveTrData);
			axKHOpenAPI.OnReceiveRealData += new _DKHOpenAPIEvents_OnReceiveRealDataEventHandler(axKHOpenAPI_OnReceiveRealData);
			axKHOpenAPI.OnReceiveMsg += new _DKHOpenAPIEvents_OnReceiveMsgEventHandler(axKHOpenAPI_OnReceiveMsg);
			axKHOpenAPI.OnReceiveChejanData += new _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(axKHOpenAPI_OnReceiveChejanData);
			axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(axKHOpenAPI_OnEventConnect);
			axKHOpenAPI.OnReceiveRealCondition += new _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler(axKHOpenAPI_OnReceiveRealCondition);
			axKHOpenAPI.OnReceiveTrCondition += new _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler(axKHOpenAPI_OnReceiveTrCondition);
			axKHOpenAPI.OnReceiveConditionVer += new _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler(axKHOpenAPI_OnReceiveConditionVer);
			((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 12f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((ScrollableControl)this).AutoScroll = true;
			((Control)this).BackColor = SystemColors.Control;
			((Form)this).ClientSize = new Size(1324, 759);
			((Control)this).Controls.Add((Control)(object)lbl오늘날짜);
			((Control)this).Controls.Add((Control)(object)dgv지수정보);
			((Control)this).Controls.Add((Control)(object)lbl프로그램상태);
			((Control)this).Controls.Add((Control)(object)groupBox_종목리스트);
			((Control)this).Controls.Add((Control)(object)label5);
			((Control)this).Controls.Add((Control)(object)groupBox_조건식);
			((Control)this).Controls.Add((Control)(object)lbl현재시간);
			((Control)this).Controls.Add((Control)(object)groupBox_종목정보);
			((Control)this).Controls.Add((Control)(object)groupBox_계좌);
			((Control)this).Controls.Add((Control)(object)groupBox_주문);
			((Control)this).Controls.Add((Control)(object)label43);
			((Control)this).Controls.Add((Control)(object)lst체결창);
			((Control)this).Controls.Add((Control)(object)label_로그창);
			((Control)this).Controls.Add((Control)(object)lst로그창);
			((Control)this).Controls.Add((Control)(object)axKHOpenAPI);
			((Control)this).Controls.Add((Control)(object)menuStrip);
			((Control)this).Controls.Add((Control)(object)dgv조건식목록);
			((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			((Form)this).MainMenuStrip = menuStrip;
			((Form)this).MaximizeBox = false;
			((Control)this).Name = "Form1";
			((Control)this).Text = "GangPRO V1.13(Free)";
			((Form)this).FormClosed += new FormClosedEventHandler(Form1_FormClosed);
			((Form)this).Load += Form1_Load;
			((Control)menuStrip).ResumeLayout(false);
			((Control)menuStrip).PerformLayout();
			((ISupportInitialize)dgv호가창).EndInit();
			((ISupportInitialize)dgv계좌).EndInit();
			((Control)groupBox_주문).ResumeLayout(false);
			((Control)groupBox_주문).PerformLayout();
			((Control)groupBox_계좌).ResumeLayout(false);
			((Control)groupBox_계좌).PerformLayout();
			((Control)groupBox_종목정보).ResumeLayout(false);
			((Control)groupBox_종목정보).PerformLayout();
			((Control)groupBox_조건식).ResumeLayout(false);
			((Control)groupBox_조건식).PerformLayout();
			((ISupportInitialize)dgv조건식목록).EndInit();
			((ISupportInitialize)dgv조건만족종목).EndInit();
			((Control)groupBox_종목리스트).ResumeLayout(false);
			((Control)groupBox_종목리스트).PerformLayout();
			((ISupportInitialize)dgv지수정보).EndInit();
			((ISupportInitialize)axKHOpenAPI).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}

		private void btn조건식매수등록_Click(object sender, EventArgs e)
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			if (b접속상태)
			{
				int num = n조건_인덱스[((ListControl)comboBox_키움조건식).SelectedIndex];
				if (n조건_조회[num] == 0)
				{
					f조건_실시간등록(2, s조건_조건명[num], num);
				}
				else
				{
					Logger(Log.로그창, "이미 등록된 조건!");
				}
			}
			else
			{
				MessageBox.Show("로그인 필요!!!", "알림");
			}
		}

		private void btn조건식매도등록_Click(object sender, EventArgs e)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			MessageBox.Show("테스트 및 문제 해결을 위해 기능을 막아두었습니다.", "알림");
		}

		private void btn조건식조회등록_Click(object sender, EventArgs e)
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			if (b접속상태)
			{
				int num = n조건_인덱스[((ListControl)comboBox_키움조건식).SelectedIndex];
				if (n조건_조회[num] == 0)
				{
					f조건_실시간등록(1, s조건_조건명[num], num);
				}
				else
				{
					Logger(Log.로그창, "이미 등록된 조건!");
				}
			}
			else
			{
				MessageBox.Show("로그인 필요!!!", "알림");
			}
		}

		private void f조건_실시간등록(int nType, string s조건명, int n조건인덱스)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			string scrNum = GetScrNum();
			if (n조건식등록갯수 >= n조건식등록상한)
			{
				MessageBox.Show("조건식 등록 갯수 제한입니다.", "알림");
			}
			else if (axKHOpenAPI.SendCondition(scrNum, s조건명, n조건인덱스, 1) == 1)
			{
				n조건식등록갯수++;
				s조건_화면번호[n조건인덱스] = scrNum;
				n조건_조회[n조건인덱스] = nType;
				f조건_리스트관리(1, n조건인덱스, s조건명);
			}
			else
			{
				Logger(Log.로그창, "[조건식 등록 실패 - {0}] 잠시 후 다시 시도해주세요!", s조건명);
			}
		}

		private void f조건_실시간중지(string s화면번호, string s조건명, int n조건인덱스)
		{
			axKHOpenAPI.SendConditionStop(s화면번호, s조건명, n조건인덱스);
			Logger(Log.로그창, "{0} 조건식 조회가 중단되었습니다.", s조건명);
			n조건_조회[n조건인덱스] = 0;
			n조건_예약매도_수익[n조건인덱스] = 0;
			f조건_리스트관리(2, n조건인덱스, s조건명);
		}

		private void dgv조건식목록_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 4 && e.RowIndex >= 0)
			{
				int num = int.Parse(dgv조건식목록[0, e.RowIndex].Value.ToString());
				f조건_실시간중지(s조건_화면번호[num], s조건_조건명[num], num);
			}
		}

		private void f조건_리스트관리(int nType, int nIndex, string s조건명)
		{
			switch (nType)
			{
			case 1:
			{
				string text = "";
				string text2 = "";
				if (n조건_조회[nIndex] == 1)
				{
					text = "조회";
					text2 = "";
					Logger(Log.로그창, "[조건식 조회 등록 - {0}]", s조건명);
				}
				else if (n조건_조회[nIndex] == 2)
				{
					text = "매수";
					n조건_매수호가[nIndex] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].n복합도;
					f조건_매수_물량[nIndex, 0] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].n물량1;
					f조건_매수_가격[nIndex, 0] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].f매수가1;
					if (n조건_매수호가[nIndex] >= 2)
					{
						f조건_매수_물량[nIndex, 1] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].n물량2;
						f조건_매수_가격[nIndex, 1] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].f매수가2;
					}
					if (n조건_매수호가[nIndex] >= 3)
					{
						f조건_매수_물량[nIndex, 2] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].n물량3;
						f조건_매수_가격[nIndex, 2] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].f매수가3;
					}
					if (n조건_매수호가[nIndex] >= 4)
					{
						f조건_매수_물량[nIndex, 3] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].n물량4;
						f조건_매수_가격[nIndex, 3] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].f매수가4;
					}
					if (n조건_매수호가[nIndex] >= 5)
					{
						f조건_매수_물량[nIndex, 4] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].n물량5;
						f조건_매수_가격[nIndex, 4] = GCode.Struct_자동매수호가[((ListControl)comboBox_자동매수호가).SelectedIndex].f매수가5;
					}
					n조건_매수금액[nIndex] = GCode.Struct_자동매수금액[((ListControl)comboBox_자동매수금액).SelectedIndex].code1;
					text2 = ((Control)comboBox_자동매수호가).Text + "-" + ((Control)comboBox_자동매수금액).Text;
					if (checkBox_예약매도.Checked)
					{
						if (radioButton_예약매도_단순.Checked)
						{
							n조건_예약매도_수익[nIndex] = 1;
							f조건_예약매도_수익물량[nIndex, 0] = GCode.Struct_예약매도물량[((ListControl)comboBox_예약매도_수익비중).SelectedIndex].code1;
							f조건_예약매도_수익률[nIndex, 0] = GCode.Struct_예약매도수익률[((ListControl)comboBox_예약매도_수익률).SelectedIndex].code1 / 100.0;
							text2 = text2 + ", 예약매도:" + GCode.Struct_예약매도물량[((ListControl)comboBox_예약매도_수익비중).SelectedIndex].name + "-" + GCode.Struct_예약매도수익률[((ListControl)comboBox_예약매도_수익률).SelectedIndex].name;
						}
						else if (radioButton_예약매도_복합.Checked)
						{
							n조건_예약매도_수익[nIndex] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].n복합도;
							f조건_예약매도_수익물량[nIndex, 0] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].n물량1;
							f조건_예약매도_수익률[nIndex, 0] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].f수익률1 / 100.0;
							if (n조건_예약매도_수익[nIndex] >= 2)
							{
								f조건_예약매도_수익물량[nIndex, 1] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].n물량2;
								f조건_예약매도_수익률[nIndex, 1] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].f수익률2 / 100.0;
							}
							if (n조건_예약매도_수익[nIndex] >= 3)
							{
								f조건_예약매도_수익물량[nIndex, 2] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].n물량3;
								f조건_예약매도_수익률[nIndex, 2] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].f수익률3 / 100.0;
							}
							if (n조건_예약매도_수익[nIndex] >= 4)
							{
								f조건_예약매도_수익물량[nIndex, 3] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].n물량4;
								f조건_예약매도_수익률[nIndex, 3] = GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].f수익률4 / 100.0;
							}
							text2 = text2 + ", 매도:" + GCode.Struct_예약매도복합[((ListControl)comboBox_예약매도_복합옵션).SelectedIndex].Name;
						}
					}
					else
					{
						n조건_예약매도_수익[nIndex] = 0;
					}
					if (nIndex != 999)
					{
						n조건_동작시간예약_시작시간[nIndex] = GCode.Struct_조건동작시간[((ListControl)comboBox_조건_동작시간_시작).SelectedIndex].code1;
						n조건_동작시간예약_마감시간[nIndex] = GCode.Struct_조건동작시간[((ListControl)comboBox_조건_동작시간_끝).SelectedIndex + 1].code1;
						if (((ListControl)comboBox_조건_동작시간_시작).SelectedIndex != 0 || ((ListControl)comboBox_조건_동작시간_끝).SelectedIndex != n옵션_조건식_동작시간 - 2)
						{
							text2 = text2 + ", 동작시간:" + GCode.Struct_조건동작시간[((ListControl)comboBox_조건_동작시간_시작).SelectedIndex].name + " ~ " + GCode.Struct_조건동작시간[((ListControl)comboBox_조건_동작시간_끝).SelectedIndex + 1].name;
						}
						n조건_매수주문수[nIndex] = 0;
						n조건_매수최대수[nIndex] = GCode.Struct_조건식매수종목수[((ListControl)comboBox_조건_매수종목수).SelectedIndex].code1;
						if (((Control)comboBox_조건_매수종목수).Text != "무제한")
						{
							text2 = text2 + ", 매수제한:" + GCode.Struct_조건식매수종목수[((ListControl)comboBox_조건_매수종목수).SelectedIndex].name;
						}
						s조건_전체옵션[nIndex] = n조건_조회[nIndex].ToString() + ";" + ((ListControl)comboBox_키움조건식).SelectedIndex.ToString() + ";" + nIndex + ";" + s조건명 + ";" + ((ListControl)comboBox_자동매수호가).SelectedIndex + ";" + ((ListControl)comboBox_자동매수금액).SelectedIndex + ";";
						s조건_전체옵션[nIndex] = s조건_전체옵션[nIndex] + checkBox_예약매도.Checked + ";" + radioButton_예약매도_단순.Checked + ";" + ((ListControl)comboBox_예약매도_수익비중).SelectedIndex + ";" + ((ListControl)comboBox_예약매도_수익률).SelectedIndex + ";";
						s조건_전체옵션[nIndex] = s조건_전체옵션[nIndex] + radioButton_예약매도_복합.Checked + ";" + ((ListControl)comboBox_예약매도_복합옵션).SelectedIndex + ";" + ((ListControl)comboBox_조건_동작시간_시작).SelectedIndex + ";" + ((ListControl)comboBox_조건_동작시간_끝).SelectedIndex + ";" + ((ListControl)comboBox_조건_매수종목수).SelectedIndex;
						Logger(Log.로그창, "[조건식 매수 등록 - {0}][옵션 : {1}]", s조건명, text2);
					}
				}
				else if (n조건_조회[nIndex] == 3)
				{
					b매도조건식등록여부 = true;
					n매도조건식등록시간 = int.Parse(DateTime.Now.ToString("HHmmss"));
					text = "매도";
					text2 = "조건 만족 시 전량매도";
					Logger(Log.로그창, "[조건식 매도 등록 - {0}][옵션 : {1}]", s조건명, text2);
				}
				if (nIndex != 999)
				{
					dgv조건식목록.Rows.Add(new object[5]
					{
						nIndex,
						s조건_조건명[nIndex],
						text,
						text2,
						"ⓧ"
					});
				}
				((Control)comboBox_계좌번호).Enabled = false;
				break;
			}
			case 2:
			{
				for (int i = 0; i < dgv조건식목록.Rows.Count; i++)
				{
					if (nIndex == int.Parse(dgv조건식목록[0, i].Value.ToString()))
					{
						dgv조건식목록.Rows.RemoveAt(i);
						n조건식등록갯수--;
					}
				}
				f계좌잠금체크();
				break;
			}
			}
			SetDoNotSort(dgv조건식목록);
		}

		private void f조건로컬저장()
		{
			if (axKHOpenAPI.GetConditionLoad() != 1)
			{
				Logger(Log.로그창, "조건식 저장 실패");
			}
		}

		private void f조건불러오기()
		{
			string[] array = axKHOpenAPI.GetConditionNameList().Trim().Split(new char[1] { ';' });
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Trim().Length >= 2)
				{
					string[] array2 = array[i].Split(new char[1] { '^' });
					int num = int.Parse(array2[0]);
					string text = array2[1];
					n조건_인덱스[i] = num;
					s조건_조건명[n조건_인덱스[i]] = text;
					string text2 = "[" + num + "]" + text;
					comboBox_키움조건식.Items.Add((object)text2);
				}
			}
			((ListControl)comboBox_키움조건식).SelectedIndex = 0;
		}

		private void comboBox_조건_동작시간_끝_SelectedIndexChanged(object sender, EventArgs e)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			if (((ListControl)comboBox_조건_동작시간_끝).SelectedIndex + 1 <= ((ListControl)comboBox_조건_동작시간_시작).SelectedIndex)
			{
				MessageBox.Show("시작시간 보다 마감시간이 늦어야합니다.", "에러");
				((ListControl)comboBox_조건_동작시간_끝).SelectedIndex = n옵션_조건식_동작시간 - 2;
			}
		}

		private void comboBox_조건_동작시간_시작_SelectedIndexChanged(object sender, EventArgs e)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			if (((ListControl)comboBox_조건_동작시간_끝).SelectedIndex + 1 <= ((ListControl)comboBox_조건_동작시간_시작).SelectedIndex)
			{
				MessageBox.Show("시작시간 보다 마감시간이 늦어야합니다.", "에러");
				((ListControl)comboBox_조건_동작시간_시작).SelectedIndex = 0;
			}
		}

		private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
		{
			//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
			if (axKHOpenAPI.GetConnectState() != 1)
			{
				return;
			}
			b접속상태 = true;
			((Control)lbl프로그램상태).Text = "접속";
			((Control)lbl프로그램상태).BackColor = Color.Green;
			s사용자ID = axKHOpenAPI.GetLoginInfo("USER_ID");
			s사용자이름 = axKHOpenAPI.GetLoginInfo("USER_NAME");
			s실서버모의서버 = axKHOpenAPI.KOA_Functions("GetServerGubun", "");
			if (s실서버모의서버 == "1")
			{
				s실서버모의서버 = "모의투자";
				n시간업데이트주기 = 1800;
				if (s상품구분 != "Premium")
				{
					n옵션_계좌손절손실률 = 9;
					n옵션_계좌일괄청산시간 = 6;
					n옵션_계좌보유종목수제한 = 7;
					n옵션_자동매수호가 = 31;
					n옵션_매수금액 = 30;
					n옵션_조건식_예약매도비중 = 10;
					n옵션_단순수익률 = 11;
					n옵션_복합예약매도옵션 = 13;
					n옵션_조건식_동작시간 = 10;
					n옵션_조건_매수종목수 = 7;
					n옵션_리스트초기화주기 = 6;
					n조건식등록상한 = 9999;
					comboBox_계좌손절손실률.Items.Clear();
					comboBox_계좌일괄청산시간.Items.Clear();
					comboBox_계좌_보유종목수제한.Items.Clear();
					comboBox_계좌_분할옵션.Items.Clear();
					comboBox_자동매수호가.Items.Clear();
					comboBox_자동매수금액.Items.Clear();
					comboBox_예약매도_수익비중.Items.Clear();
					comboBox_예약매도_수익률.Items.Clear();
					comboBox_예약매도_복합옵션.Items.Clear();
					comboBox_조건_동작시간_시작.Items.Clear();
					comboBox_조건_동작시간_끝.Items.Clear();
					comboBox_조건_매수종목수.Items.Clear();
					comboBox_리스트초기화주기.Items.Clear();
					for (int i = 0; i < n옵션_계좌손절손실률; i++)
					{
						comboBox_계좌손절손실률.Items.Add((object)GCode.Struct_계좌손절손실률[i].name);
					}
					((ListControl)comboBox_계좌손절손실률).SelectedIndex = 0;
					for (int j = 0; j < n옵션_계좌일괄청산시간; j++)
					{
						comboBox_계좌일괄청산시간.Items.Add((object)GCode.Struct_계좌일괄청산시간[j].name);
					}
					((ListControl)comboBox_계좌일괄청산시간).SelectedIndex = 0;
					for (int k = 0; k < n옵션_계좌보유종목수제한; k++)
					{
						comboBox_계좌_보유종목수제한.Items.Add((object)GCode.Struct_보유종목수제한[k].Name);
					}
					((ListControl)comboBox_계좌_보유종목수제한).SelectedIndex = n옵션_계좌보유종목수제한 - 1;
					for (int l = 0; l < n옵션_복합예약매도옵션; l++)
					{
						comboBox_계좌_분할옵션.Items.Add((object)GCode.Struct_예약매도복합[l].Name);
					}
					((ListControl)comboBox_계좌_분할옵션).SelectedIndex = 0;
					for (int m = 0; m < n옵션_자동매수호가; m++)
					{
						comboBox_자동매수호가.Items.Add((object)GCode.Struct_자동매수호가[m].Name);
					}
					((ListControl)comboBox_자동매수호가).SelectedIndex = 0;
					for (int n = 0; n < n옵션_매수금액; n++)
					{
						comboBox_자동매수금액.Items.Add((object)GCode.Struct_자동매수금액[n].name);
					}
					((ListControl)comboBox_자동매수금액).SelectedIndex = 0;
					for (int num = 0; num < n옵션_조건식_예약매도비중; num++)
					{
						comboBox_예약매도_수익비중.Items.Add((object)GCode.Struct_예약매도물량[num].name);
					}
					((ListControl)comboBox_예약매도_수익비중).SelectedIndex = 0;
					for (int num2 = 0; num2 < n옵션_단순수익률; num2++)
					{
						comboBox_예약매도_수익률.Items.Add((object)GCode.Struct_예약매도수익률[num2].name);
					}
					((ListControl)comboBox_예약매도_수익률).SelectedIndex = 2;
					for (int num3 = 0; num3 < n옵션_복합예약매도옵션; num3++)
					{
						comboBox_예약매도_복합옵션.Items.Add((object)GCode.Struct_예약매도복합[num3].Name);
					}
					((ListControl)comboBox_예약매도_복합옵션).SelectedIndex = 0;
					for (int num4 = 0; num4 < n옵션_조건식_동작시간 - 1; num4++)
					{
						comboBox_조건_동작시간_끝.Items.Add((object)GCode.Struct_조건동작시간[num4 + 1].name);
					}
					((ListControl)comboBox_조건_동작시간_끝).SelectedIndex = n옵션_조건식_동작시간 - 2;
					for (int num5 = 0; num5 < n옵션_조건식_동작시간 - 1; num5++)
					{
						comboBox_조건_동작시간_시작.Items.Add((object)GCode.Struct_조건동작시간[num5].name);
					}
					((ListControl)comboBox_조건_동작시간_시작).SelectedIndex = 0;
					for (int num6 = 0; num6 < n옵션_조건_매수종목수; num6++)
					{
						comboBox_조건_매수종목수.Items.Add((object)GCode.Struct_조건식매수종목수[num6].name);
					}
					((ListControl)comboBox_조건_매수종목수).SelectedIndex = n옵션_조건_매수종목수 - 1;
					for (int num7 = 0; num7 < n옵션_리스트초기화주기; num7++)
					{
						comboBox_리스트초기화주기.Items.Add((object)GCode.Struct_리스트초기화시간[num7].Name);
					}
					((ListControl)comboBox_리스트초기화주기).SelectedIndex = 0;
				}
			}
			else
			{
				s실서버모의서버 = "실제투자";
				n시간업데이트주기 = 1800;
			}
			Logger(Log.로그창, "[로그인] {1}님 {0} {2} 접속", Error.GetErrorMessage(), s사용자이름, s실서버모의서버);
			if (s서비스사용자이름 != "공용" && s사용자이름 != s서비스사용자이름)
			{
				MessageBox.Show(s사용자이름 + "님은 사용 권한이 없습니다. " + s서비스사용자이름 + "님 전용입니다.");
				Form1_FormClosed(null, null);
				return;
			}
			string[] array = axKHOpenAPI.GetLoginInfo("ACCNO").Split(new char[1] { ';' });
			for (int num8 = 0; num8 < array.Length - 1; num8++)
			{
				comboBox_계좌번호.Items.Add((object)array[num8]);
			}
			((ListControl)comboBox_계좌번호).SelectedIndex = 0;
			f조건로컬저장();
			fn_opt10005(((Control)txt주문종목코드).Text);
			Thread_주문대기.Start();
			if (File.Exists(s로그저장경로_리스트))
			{
				sr로그_리스트 = File.OpenText(s로그저장경로_리스트);
				while (!sr로그_리스트.EndOfStream)
				{
					string[] array2 = sr로그_리스트.ReadLine().Split(new char[1] { '\t' });
					dgv조건만족종목.Rows.Add(new object[6]
					{
						array2[0],
						array2[1],
						array2[2],
						array2[3],
						"ⓧ",
						"ⓥ"
					});
				}
				sr로그_리스트.Close();
			}
			b조회가능상태 = true;
			fn_opt20001("0", "001");
			Delay(200);
			fn_opt20001("1", "101");
			Delay(200);
			fn_opt20001("2", "201");
			Delay(200);
			getAllStock();
			Delay(200);
			setup = readSetup(DataPath.sGangPRO_SetupPath);
			setSetup(setup);
		}

		private void axKHOpenAPI_OnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			if (e.sRQName == "주식주문")
			{
				string text = axKHOpenAPI.GetCommData(e.sTrCode, "", 0, "").Trim();
				long result = 0L;
				if (long.TryParse(text, out result))
				{
					((Control)txt원주문번호).Text = text;
				}
			}
			else if (e.sRQName == "주식호가")
			{
				f호가창조회(e);
			}
			else if (e.sRQName == "주식일주월시분")
			{
				s오늘날짜서버 = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "날짜").Trim();
				calc_remain_day(s오늘날짜서버, s서비스날짜);
			}
			else if (e.sRQName == "계좌평가현황")
			{
				((Control)txt계좌잔액).Text = f문자열to돈(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "D+2추정예수금").Trim()).ToString());
				Add_조회("보유종목", "", "", ((Control)comboBox_계좌번호).Text);
				b조회가능상태 = true;
			}
			else if (e.sRQName == "계좌별주문체결내역상세")
			{
				f계좌별주문체결내역상세(e);
			}
			else if (e.sRQName == "계좌평가잔고내역")
			{
				b조회가능상태 = true;
				f보유종목(e);
			}
			else if (e.sRQName == "업종현재가요청")
			{
				s지수값[n지수Cnt] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "현재가").Trim();
				s지수등락률[n지수Cnt] = axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "등락률").Trim();
				n지수Cnt++;
				if (n지수Cnt == 3)
				{
					dgv지수정보.Rows.Add(new object[3]
					{
						s지수값[0],
						s지수값[1],
						s지수값[2]
					});
					dgv지수정보.Rows.Add(new object[3]
					{
						s지수등락률[0],
						s지수등락률[1],
						s지수등락률[2]
					});
					b지수실시간 = true;
				}
			}
		}

		private void axKHOpenAPI_OnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
		{
			if (e.sRealType == "주식체결")
			{
				Update_보유종목_가격(e.sRealKey, int.Parse(axKHOpenAPI.GetCommRealData(e.sRealType, 10)));
			}
			else if (e.sRealType == "업종지수" && b지수실시간)
			{
				double num = double.Parse(axKHOpenAPI.GetCommRealData(e.sRealType, 10));
				int num2 = 0;
				if (Math.Abs(num) > 1500.0)
				{
					num2 = 0;
				}
				else if (Math.Abs(num) > 600.0)
				{
					num2 = 1;
				}
				else if (Math.Abs(num) > 100.0)
				{
					num2 = 2;
				}
				dgv지수정보[num2, 0].Value = Math.Abs(num);
				if (num > 0.0)
				{
					dgv지수정보[num2, 0].Style.ForeColor = Color.Red;
				}
				else
				{
					dgv지수정보[num2, 0].Style.ForeColor = Color.Blue;
				}
				num = double.Parse(axKHOpenAPI.GetCommRealData(e.sRealType, 12));
				dgv지수정보[num2, 1].Value = num + "%";
				if (num > 0.0)
				{
					dgv지수정보[num2, 1].Style.ForeColor = Color.Red;
				}
				else
				{
					dgv지수정보[num2, 1].Style.ForeColor = Color.Blue;
				}
			}
		}

		private void axKHOpenAPI_OnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
		{
			string sMsg = e.sMsg;
			_ = e.sTrCode;
			string sRQName = e.sRQName;
			sMsg.Substring(1, 6);
			string text = sMsg.Substring(8);
			if (sRQName == "계좌평가현황" || sRQName == "주식주문")
			{
				Logger(Log.로그창, "[결과] {0}", text);
				b조회가능상태 = true;
			}
		}

		private void axKHOpenAPI_OnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
		{
			if (e.lRet == 1)
			{
				Logger(Log.로그창, "[성공] 키움 조건식 불러오기");
			}
			else
			{
				Logger(Log.로그창, "[실패] 키움 조건식 불러오기 " + e.sMsg);
			}
			f조건불러오기();
		}

		private void axKHOpenAPI_OnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
		{
			if (e.strType == "I")
			{
				f조건만족종목리스트(b실시간: true, e.sTrCode, e.strConditionIndex, e.strConditionName);
			}
		}

		private void axKHOpenAPI_OnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
		{
			string[] array = e.strCodeList.Split(new char[1] { ';' });
			for (int i = 0; i < array.Length - 1; i++)
			{
				f조건만족종목리스트(b실시간: false, array[i], e.nIndex.ToString(), e.strConditionName);
			}
		}

		private void axKHOpenAPI_OnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{
			f주문체결(e);
		}

		public void SendOrder(int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo, string s종목명, string s계좌번호)
		{
			dg로그출력 dg로그출력 = f로그출력;
			string text = "주식주문";
			string scrNum = GetScrNum();
			if (sHogaGb == "03")
			{
				nPrice = 0;
			}
			if (b접속상태 && nQty > 0)
			{
				int num = axKHOpenAPI.SendOrder(text, scrNum, s계좌번호, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
				if (num == 0)
				{
					string name = KOACode.orderType[nOrderType - 1].name;
					((Control)this).Invoke((Delegate)dg로그출력, new object[1] { getString("[{0}][{1}][{2:C}원 - {3}주] 주문이 키움 서버로 전송되었습니다.", name, s종목명, nPrice, nQty) });
					if (name == "신규매도")
					{
						int num2 = f계좌종목인덱스(sCode);
						int num3 = f계좌종목dgv인덱스(sCode);
						if (num2 == num3 && num2 >= 0)
						{
							Struct_보유종목[num2].n가능수량 = Struct_보유종목[num2].n가능수량 - nQty;
							if (Struct_보유종목[num2].n가능수량 < 0)
							{
								Struct_보유종목[num2].n가능수량 = 0;
							}
							dgv계좌[5, num3].Value = Struct_보유종목[num2].n가능수량;
						}
						else
						{
							Add_조회("잔액", "", "", s현재계좌번호);
						}
					}
					if (nOrderType == 4)
					{
						int num4 = f계좌종목인덱스(sCode);
						int num5 = f계좌종목dgv인덱스(sCode);
						if (num4 == num5 && num4 >= 0)
						{
							Struct_보유종목[num4].n가능수량 = Struct_보유종목[num4].n가능수량 + nQty;
							if (Struct_보유종목[num4].n가능수량 > Struct_보유종목[num4].n보유수량)
							{
								Struct_보유종목[num4].n가능수량 = Struct_보유종목[num4].n보유수량;
							}
							dgv계좌[5, num5].Value = Struct_보유종목[num4].n가능수량;
						}
						else
						{
							Add_조회("잔액", "", "", s현재계좌번호);
						}
					}
				}
				else
				{
					((Control)this).Invoke((Delegate)dg로그출력, new object[1] { getString("주문이 전송 실패 하였습니다. [에러] : {0}", num) });
				}
			}
			b조회가능상태 = true;
		}

		private void btn주문실행_Click(object sender, EventArgs e)
		{
			string masterCodeName = axKHOpenAPI.GetMasterCodeName(((Control)txt주문종목코드).Text);
			Delay(100);
			SendOrder(KOACode.orderType[((ListControl)comboBox_주문유형).SelectedIndex].code, ((Control)txt주문종목코드).Text, int.Parse(((Control)txt주문수량).Text), int.Parse(((Control)txt주문단가).Text), KOACode.hogaGb[((ListControl)comboBox_호가유형).SelectedIndex].code, "0", masterCodeName, ((Control)comboBox_계좌번호).Text);
		}

		private void btn연속주문_Click(object sender, EventArgs e)
		{
			//IL_0005: Unknown result type (might be due to invalid IL or missing references)
			MessageBox.Show("기능 막아둠");
		}

		private void Thread주문()
		{
			dg종목코드 dg종목코드 = f종목코드변경;
			dg로그출력 dg로그출력 = f로그출력;
			while (true)
			{
				n쓰레드cnt++;
				if (n조회대기수 > 0 && b조회가능상태)
				{
					b조회가능상태 = false;
					string sTR코드 = Struct_조회대기리스트[n조회대기시작인덱스].sTR코드;
					string s종목코드 = Struct_조회대기리스트[n조회대기시작인덱스].s종목코드;
					string s종목명 = Struct_조회대기리스트[n조회대기시작인덱스].s종목명;
					string s계좌번호 = Struct_조회대기리스트[n조회대기시작인덱스].s계좌번호;
					switch (sTR코드)
					{
					case "ORDER":
						if (n주문대기수 > 0)
						{
							f주문(s계좌번호);
						}
						break;
					case "호가창":
						if (s종목코드.Length == 6)
						{
							((Control)this).Invoke((Delegate)dg종목코드, new object[1] { s종목코드 });
							fn_opt10004(s종목코드);
						}
						else
						{
							b조회가능상태 = true;
						}
						break;
					case "잔액":
						fn_opw00004(s계좌번호);
						b조회가능상태 = true;
						break;
					case "보유종목":
					{
						int n연속 = 0;
						if (s종목코드 == "2")
						{
							n연속 = 2;
						}
						fn_opw00018(s계좌번호, n연속);
						break;
					}
					case "체결내역":
						if (s종목명 == "단순")
						{
							b매도주문단순조회 = true;
						}
						fn_opw00007(s종목코드, s계좌번호);
						break;
					default:
						b조회가능상태 = true;
						((Control)this).Invoke((Delegate)dg로그출력, new object[1] { getString("조회대기열 에러 : {0}", sTR코드) });
						break;
					}
					n조회대기시작인덱스++;
					n조회대기수--;
				}
				Thread.Sleep(n주문쓰레드주기);
			}
		}

		private void Add_조회(string sTR코드, string sCode, string sName, string sAcc)
		{
			Struct_조회대기리스트[n조회대기마지막인덱스].sTR코드 = sTR코드;
			Struct_조회대기리스트[n조회대기마지막인덱스].s종목코드 = sCode;
			Struct_조회대기리스트[n조회대기마지막인덱스].s종목명 = sName;
			Struct_조회대기리스트[n조회대기마지막인덱스].s계좌번호 = sAcc;
			n조회대기마지막인덱스++;
			n조회대기수++;
		}

		private void Add_주문(int nType, string sCode, string sName, string s조건명, int nIndex, int n수량, int n단가)
		{
			int num = 1;
			if (nType == 1)
			{
				num = n조건_매수호가[nIndex];
			}
			for (int i = 0; i < num; i++)
			{
				Add_조회("ORDER", sCode, sName, ((Control)comboBox_계좌번호).Text);
				Struct_주문대기리스트[n주문대기마지막인덱스].n주문구분 = nType;
				Struct_주문대기리스트[n주문대기마지막인덱스].s종목명 = sName;
				Struct_주문대기리스트[n주문대기마지막인덱스].s종목코드 = sCode;
				Struct_주문대기리스트[n주문대기마지막인덱스].s조건명 = s조건명;
				Struct_주문대기리스트[n주문대기마지막인덱스].n조건인덱스 = nIndex;
				Struct_주문대기리스트[n주문대기마지막인덱스].f매수호가 = f조건_매수_가격[nIndex, i];
				Struct_주문대기리스트[n주문대기마지막인덱스].n매수금액 = (int)((double)(n조건_매수금액[nIndex] / 100) * f조건_매수_물량[nIndex, i]);
				Struct_주문대기리스트[n주문대기마지막인덱스].n매도수량 = n수량;
				Struct_주문대기리스트[n주문대기마지막인덱스].n매도단가 = n단가;
				n주문대기마지막인덱스++;
				n주문대기수++;
			}
			n조건_매수주문수[nIndex]++;
		}

		private void f주문(string s계좌번호)
		{
			dg로그출력 dg로그출력 = f로그출력;
			int n주문구분 = Struct_주문대기리스트[n주문대기시작인덱스].n주문구분;
			string s종목코드 = Struct_주문대기리스트[n주문대기시작인덱스].s종목코드;
			string s종목명 = Struct_주문대기리스트[n주문대기시작인덱스].s종목명;
			double f매수호가 = Struct_주문대기리스트[n주문대기시작인덱스].f매수호가;
			int n매수금액 = Struct_주문대기리스트[n주문대기시작인덱스].n매수금액;
			int n매도수량 = Struct_주문대기리스트[n주문대기시작인덱스].n매도수량;
			int n매도단가 = Struct_주문대기리스트[n주문대기시작인덱스].n매도단가;
			string s조건명 = Struct_주문대기리스트[n주문대기시작인덱스].s조건명;
			int n조건인덱스 = Struct_주문대기리스트[n주문대기시작인덱스].n조건인덱스;
			switch (n주문구분)
			{
			case 1:
				if (s종목명 == s호가창종목명)
				{
					int num = 0;
					int num2 = 0;
					if (f매수호가 == 0.0)
					{
						num = nHoga매도[0];
					}
					else if (f매수호가 >= 1.0)
					{
						num = ((!(f매수호가 > 10.0)) ? nHoga매수[(int)f매수호가 - 1] : nHoga매도[(int)f매수호가 - 11]);
					}
					else if (f매수호가 < 0.0)
					{
						num = f호가근사치계산(1, nHoga매도[0], f매수호가 / 100.0);
					}
					if (num != 0)
					{
						num2 = n매수금액 / num;
						if (num2 <= 0)
						{
							break;
						}
						if (n조건_예약매도_수익[n조건인덱스] > 0)
						{
							int num3 = 0;
							for (int i = 0; i < n조건_예약매도_수익[n조건인덱스]; i++)
							{
								struct_예약매도리스트[n예약매도_숫자].b예약매도 = true;
								struct_예약매도리스트[n예약매도_숫자].s종목코드 = Struct_주문대기리스트[n주문대기시작인덱스].s종목코드;
								struct_예약매도리스트[n예약매도_숫자].n매수요청량 = num2;
								if (f조건_예약매도_수익물량[n조건인덱스, i] == -1.0)
								{
									struct_예약매도리스트[n예약매도_숫자].n예약매도_수량 = num2 - num3;
									struct_예약매도리스트[n예약매도_숫자].n매도기준량 = num2;
								}
								else
								{
									struct_예약매도리스트[n예약매도_숫자].n예약매도_수량 = (int)((double)num2 * f조건_예약매도_수익물량[n조건인덱스, i] / 100.0);
									num3 += struct_예약매도리스트[n예약매도_숫자].n예약매도_수량;
									struct_예약매도리스트[n예약매도_숫자].n매도기준량 = num3;
								}
								struct_예약매도리스트[n예약매도_숫자].n예약매도_매도주문가격 = f호가근사치계산(0, num, f조건_예약매도_수익률[n조건인덱스, i]);
								n예약매도_숫자++;
							}
						}
						string sHogaGb2 = "00";
						if (f매수호가 == 0.0)
						{
							sHogaGb2 = "03";
						}
						SendOrder(1, s종목코드, num2, num, sHogaGb2, "0", s종목명, s계좌번호);
					}
					else
					{
						((Control)this).Invoke((Delegate)dg로그출력, new object[1] { getString("{0} 호가 없어서 매수 주문 못나감", Struct_주문대기리스트[n주문대기시작인덱스].s종목명) });
					}
				}
				else
				{
					((Control)this).Invoke((Delegate)dg로그출력, new object[1] { "호가창과 주문 종목 불일치!!!!" });
				}
				break;
			case 2:
			{
				string sHogaGb = "00";
				if (n매도단가 == 0)
				{
					sHogaGb = "03";
				}
				SendOrder(2, s종목코드, n매도수량, n매도단가, sHogaGb, "", s종목명, s계좌번호);
				break;
			}
			case 4:
				SendOrder(4, s종목코드, n매도수량, 0, "", s조건명, s종목명, s계좌번호);
				break;
			}
			n주문대기시작인덱스++;
			n주문대기수--;
			b조회가능상태 = true;
		}

		private void comboBox_호가유형_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (((ListControl)comboBox_호가유형).SelectedIndex == 1)
			{
				((Control)txt주문단가).Enabled = false;
			}
			else
			{
				((Control)txt주문단가).Enabled = true;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			s오늘날짜 = DateTime.Now.ToString("yyyyMMdd");
			s로그저장경로_체결 = Application.StartupPath + "\\매매로그\\" + s오늘날짜 + ".lg1";
			DataPath.sGangPRO_SetupPath = Application.StartupPath + "\\매매로그\\setup.config";
			if (!File.Exists(s로그저장경로_체결))
			{
				FileWrite(s로그저장경로_체결, "시간(PC)\t매매시간(키움서버)\t주문종류\t종목명\t체결가격\t체결수량\t계좌(앞6자리)\n");
			}
			s로그저장경로_로그 = Application.StartupPath + "\\매매로그\\" + s오늘날짜 + ".lg2";
			if (!File.Exists(s로그저장경로_로그))
			{
				FileWrite(s로그저장경로_로그, "로그내용\n");
			}
			s로그저장경로_리스트 = Application.StartupPath + "\\매매로그\\" + s오늘날짜 + ".lis";
			TestThread1 = new Thread(Thread현재시간);
			Thread_주문대기 = new Thread(Thread주문);
			if (s서비스날짜.Length != 8)
			{
				MessageBox.Show("날짜형식 오류", "알림");
				Application.Exit();
				return;
			}
			if (int.Parse(s오늘날짜) > int.Parse(s서비스날짜))
			{
				MessageBox.Show("서비스날짜 종료(~" + s서비스날짜 + ")", "알림");
				Application.Exit();
				return;
			}
			if (s상품구분 == "Free")
			{
				n옵션_계좌손절손실률 = 9;
				n옵션_계좌일괄청산시간 = 6;
				n옵션_계좌보유종목수제한 = 2;
				n옵션_자동매수호가 = 16;
				n옵션_매수금액 = 3;
				n옵션_조건식_예약매도비중 = 10;
				n옵션_단순수익률 = 5;
				n옵션_복합예약매도옵션 = 4;
				n옵션_조건식_동작시간 = 10;
				n옵션_조건_매수종목수 = 2;
				n옵션_리스트초기화주기 = 6;
				n조건식등록상한 = 1;
			}
			else if (s상품구분 == "Light")
			{
				n옵션_계좌손절손실률 = 9;
				n옵션_계좌일괄청산시간 = 6;
				n옵션_계좌보유종목수제한 = 6;
				n옵션_자동매수호가 = 19;
				n옵션_매수금액 = 12;
				n옵션_조건식_예약매도비중 = 10;
				n옵션_단순수익률 = 11;
				n옵션_복합예약매도옵션 = 8;
				n옵션_조건식_동작시간 = 10;
				n옵션_조건_매수종목수 = 4;
				n옵션_리스트초기화주기 = 6;
				n조건식등록상한 = 3;
			}
			else if (s상품구분 == "Premium")
			{
				n옵션_계좌손절손실률 = 9;
				n옵션_계좌일괄청산시간 = 6;
				n옵션_계좌보유종목수제한 = 7;
				n옵션_자동매수호가 = 31;
				n옵션_매수금액 = 30;
				n옵션_조건식_예약매도비중 = 10;
				n옵션_단순수익률 = 11;
				n옵션_복합예약매도옵션 = 13;
				n옵션_조건식_동작시간 = 10;
				n옵션_조건_매수종목수 = 7;
				n옵션_리스트초기화주기 = 6;
				n조건식등록상한 = 9999;
				if (s서비스사용자이름 == "이지원")
				{
					n주문쓰레드주기 = 210;
				}
			}
			_scrNum = 5001;
			for (int i = 0; i < 2; i++)
			{
				comboBox_호가유형.Items.Add((object)KOACode.hogaGb[i].name);
			}
			((ListControl)comboBox_호가유형).SelectedIndex = 0;
			for (int j = 0; j < 2; j++)
			{
				comboBox_주문유형.Items.Add((object)KOACode.orderType[j].name);
			}
			((ListControl)comboBox_주문유형).SelectedIndex = 0;
			for (int k = 0; k < n옵션_계좌손절손실률; k++)
			{
				comboBox_계좌손절손실률.Items.Add((object)GCode.Struct_계좌손절손실률[k].name);
			}
			((ListControl)comboBox_계좌손절손실률).SelectedIndex = 0;
			for (int l = 0; l < n옵션_계좌일괄청산시간; l++)
			{
				comboBox_계좌일괄청산시간.Items.Add((object)GCode.Struct_계좌일괄청산시간[l].name);
			}
			((ListControl)comboBox_계좌일괄청산시간).SelectedIndex = 0;
			for (int m = 0; m < n옵션_계좌보유종목수제한; m++)
			{
				comboBox_계좌_보유종목수제한.Items.Add((object)GCode.Struct_보유종목수제한[m].Name);
			}
			((ListControl)comboBox_계좌_보유종목수제한).SelectedIndex = n옵션_계좌보유종목수제한 - 1;
			for (int n = 0; n < n옵션_복합예약매도옵션; n++)
			{
				comboBox_계좌_분할옵션.Items.Add((object)GCode.Struct_예약매도복합[n].Name);
			}
			((ListControl)comboBox_계좌_분할옵션).SelectedIndex = 0;
			comboBox_계좌_분할기준.Items.Add((object)"현재가");
			comboBox_계좌_분할기준.Items.Add((object)"매수가");
			((ListControl)comboBox_계좌_분할기준).SelectedIndex = 0;
			for (int num = 0; num < n옵션_자동매수호가; num++)
			{
				comboBox_자동매수호가.Items.Add((object)GCode.Struct_자동매수호가[num].Name);
			}
			((ListControl)comboBox_자동매수호가).SelectedIndex = 0;
			for (int num2 = 0; num2 < n옵션_매수금액; num2++)
			{
				comboBox_자동매수금액.Items.Add((object)GCode.Struct_자동매수금액[num2].name);
			}
			((ListControl)comboBox_자동매수금액).SelectedIndex = 0;
			for (int num3 = 0; num3 < n옵션_조건식_예약매도비중; num3++)
			{
				comboBox_예약매도_수익비중.Items.Add((object)GCode.Struct_예약매도물량[num3].name);
			}
			((ListControl)comboBox_예약매도_수익비중).SelectedIndex = 0;
			for (int num4 = 0; num4 < n옵션_단순수익률; num4++)
			{
				comboBox_예약매도_수익률.Items.Add((object)GCode.Struct_예약매도수익률[num4].name);
			}
			((ListControl)comboBox_예약매도_수익률).SelectedIndex = 2;
			for (int num5 = 0; num5 < n옵션_복합예약매도옵션; num5++)
			{
				comboBox_예약매도_복합옵션.Items.Add((object)GCode.Struct_예약매도복합[num5].Name);
			}
			((ListControl)comboBox_예약매도_복합옵션).SelectedIndex = 0;
			for (int num6 = 0; num6 < n옵션_조건식_동작시간 - 1; num6++)
			{
				comboBox_조건_동작시간_끝.Items.Add((object)GCode.Struct_조건동작시간[num6 + 1].name);
			}
			((ListControl)comboBox_조건_동작시간_끝).SelectedIndex = n옵션_조건식_동작시간 - 2;
			for (int num7 = 0; num7 < n옵션_조건식_동작시간 - 1; num7++)
			{
				comboBox_조건_동작시간_시작.Items.Add((object)GCode.Struct_조건동작시간[num7].name);
			}
			((ListControl)comboBox_조건_동작시간_시작).SelectedIndex = 0;
			for (int num8 = 0; num8 < n옵션_조건_매수종목수; num8++)
			{
				comboBox_조건_매수종목수.Items.Add((object)GCode.Struct_조건식매수종목수[num8].name);
			}
			((ListControl)comboBox_조건_매수종목수).SelectedIndex = n옵션_조건_매수종목수 - 1;
			for (int num9 = 0; num9 < n옵션_리스트초기화주기; num9++)
			{
				comboBox_리스트초기화주기.Items.Add((object)GCode.Struct_리스트초기화시간[num9].Name);
			}
			((ListControl)comboBox_리스트초기화주기).SelectedIndex = 0;
			DataPath.sCurPath = Application.StartupPath;
			DataPath.sManualPath = DataPath.sCurPath + "\\메뉴얼_GangPRO_" + s버전 + ".pdf";
			((Control)lbl오늘날짜).Text = string.Concat(s오늘날짜.Substring(4, 2), "/", s오늘날짜.Substring(6), "(", DateTime.Now.DayOfWeek, ")");
			로그인ToolStripMenuItem_Click(null, null);
			TestThread1.Start();
		}

		private void Thread현재시간()
		{
			dg시간 dg시간 = f현재시간;
			dg로그출력 dg로그출력 = f로그출력;
			ulong num = 0uL;
			while (true)
			{
				num++;
				((Control)this).Invoke((Delegate)dg시간);
				if (b조회가능상태)
				{
					n마지막정상카운트 = num;
				}
				if (num - n마지막정상카운트 > 10 && b접속상태)
				{
					((Control)this).Invoke((Delegate)dg로그출력, new object[1] { "프로그램 정지상태!" });
				}
				if (b계좌_자동반복조회 && num % n시간업데이트주기 == 0L)
				{
					Add_조회("보유종목", "", "", s현재계좌번호);
				}
				if (num % 10 == 0L && b계좌_일괄청산)
				{
					int num2 = int.Parse(DateTime.Now.ToString("HHmmss"));
					if (num2 >= n일괄청산시간 && num2 <= n일괄청산시간 + 200)
					{
						b계좌_일괄청산 = false;
						((Control)this).Invoke((Delegate)dg로그출력, new object[1] { "일괄청산 시간입니다!" });
					}
				}
				if (b리스트초기화 && num % (uint)n리스트초기화주기 == 0L)
				{
					((Control)this).Invoke((Delegate)dg로그출력, new object[1] { "종목 리스트 초기화..." });
				}
				Thread.Sleep(1000);
			}
		}

		private void f현재시간()
		{
			string text = DateTime.Now.ToString("HHmmss");
			((Control)lbl현재시간).Text = text.Substring(0, 2) + ":" + text.Substring(2, 2) + ":" + text.Substring(4, 2);
			update보유종목수익률(n계좌_보유종목수, Struct_보유종목);
		}

		private void f종목코드변경(string sCode)
		{
			((Control)txt주문종목코드).Text = sCode;
		}

		private void f로그출력(string s내용)
		{
			Logger(Log.로그창, s내용);
			if (s내용 == "종목 리스트 초기화...")
			{
				dgv조건만족종목.Rows.Clear();
			}
			if (s내용 == "일괄청산 시간입니다!")
			{
				((Control)btn계좌_일괄청산).Text = "설정";
				((Control)lbl계좌_일괄청산).Text = "F";
				((Control)lbl계좌_일괄청산).BackColor = Color.Red;
				((Control)comboBox_계좌일괄청산시간).Enabled = true;
				f일괄청산();
			}
			if (s내용 == "프로그램 정지상태!")
			{
				Logger(Log.로그창, "자동 정상화...");
				b조회가능상태 = true;
			}
		}

		private void btn종목조회_Click(object sender, EventArgs e)
		{
			if (((Control)txt주문종목코드).Text.Length == 6 && b접속상태)
			{
				Add_조회("호가창", ((Control)txt주문종목코드).Text, "", "");
			}
		}

		private void dgv호가창_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex <= 4)
			{
				((Control)txt주문단가).Text = dgv호가창[1, e.RowIndex].Value.ToString();
			}
			if (e.RowIndex >= 5 && e.RowIndex <= 9)
			{
				((Control)txt주문단가).Text = dgv호가창[2, e.RowIndex].Value.ToString();
			}
		}

		private void f호가창조회(_DKHOpenAPIEvents_OnReceiveTrDataEvent e)
		{
			s호가창종목명 = axKHOpenAPI.GetMasterCodeName(((Control)txt주문종목코드).Text);
			((Control)lbl주문종목명).Text = s호가창종목명;
			b조회가능상태 = true;
			nHoga매도[0] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도최우선호가").Trim()));
			nHoga매도[1] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도2차선호가").Trim()));
			nHoga매도[2] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도3차선호가").Trim()));
			nHoga매도[3] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도4차선호가").Trim()));
			nHoga매도[4] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도5차선호가").Trim()));
			nHoga매도잔량[0] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도최우선잔량")));
			nHoga매도잔량[1] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도2차선잔량").Trim()));
			nHoga매도잔량[2] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도3차선잔량").Trim()));
			nHoga매도잔량[3] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도4차선잔량").Trim()));
			nHoga매도잔량[4] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매도5차선잔량").Trim()));
			nHoga매수[0] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수최우선호가").Trim()));
			nHoga매수[1] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수2차선호가").Trim()));
			nHoga매수[2] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수3차선호가").Trim()));
			nHoga매수[3] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수4차선호가").Trim()));
			nHoga매수[4] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수5차선호가").Trim()));
			nHoga매수잔량[0] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수최우선잔량")));
			nHoga매수잔량[1] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수2차선잔량").Trim()));
			nHoga매수잔량[2] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수3차선잔량").Trim()));
			nHoga매수잔량[3] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수4차선잔량").Trim()));
			nHoga매수잔량[4] = Math.Abs(int.Parse(axKHOpenAPI.CommGetData(e.sTrCode, "", e.sRQName, 0, "매수5차선잔량").Trim()));
			dgv호가창.Rows.Clear();
			dgv호가창.Rows.Add(new object[4]
			{
				nHoga매도잔량[4],
				nHoga매도[4],
				"",
				""
			});
			dgv호가창.Rows.Add(new object[4]
			{
				nHoga매도잔량[3],
				nHoga매도[3],
				"",
				""
			});
			dgv호가창.Rows.Add(new object[4]
			{
				nHoga매도잔량[2],
				nHoga매도[2],
				"",
				""
			});
			dgv호가창.Rows.Add(new object[4]
			{
				nHoga매도잔량[1],
				nHoga매도[1],
				"",
				""
			});
			dgv호가창.Rows.Add(new object[4]
			{
				nHoga매도잔량[0],
				nHoga매도[0],
				"",
				""
			});
			dgv호가창.Rows.Add(new object[4]
			{
				"",
				"",
				nHoga매수[0],
				nHoga매수잔량[0]
			});
			dgv호가창.Rows.Add(new object[4]
			{
				"",
				"",
				nHoga매수[1],
				nHoga매수잔량[1]
			});
			dgv호가창.Rows.Add(new object[4]
			{
				"",
				"",
				nHoga매수[2],
				nHoga매수잔량[2]
			});
			dgv호가창.Rows.Add(new object[4]
			{
				"",
				"",
				nHoga매수[3],
				nHoga매수잔량[3]
			});
			dgv호가창.Rows.Add(new object[4]
			{
				"",
				"",
				nHoga매수[4],
				nHoga매수잔량[4]
			});
			SetDoNotSort(dgv호가창);
		}

		private void f주문체결(_DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
		{
			if (e.sGubun == "0")
			{
				string chejanData = axKHOpenAPI.GetChejanData(9201);
				string text = axKHOpenAPI.GetChejanData(9001).Substring(1);
				string chejanData2 = axKHOpenAPI.GetChejanData(302);
				axKHOpenAPI.GetChejanData(9203);
				axKHOpenAPI.GetChejanData(900);
				axKHOpenAPI.GetChejanData(901);
				string chejanData3 = axKHOpenAPI.GetChejanData(902);
				axKHOpenAPI.GetChejanData(905);
				axKHOpenAPI.GetChejanData(906);
				string chejanData4 = axKHOpenAPI.GetChejanData(907);
				string chejanData5 = axKHOpenAPI.GetChejanData(908);
				axKHOpenAPI.GetChejanData(910);
				string chejanData6 = axKHOpenAPI.GetChejanData(911);
				axKHOpenAPI.GetChejanData(912);
				string chejanData7 = axKHOpenAPI.GetChejanData(913);
				string chejanData8 = axKHOpenAPI.GetChejanData(914);
				string chejanData9 = axKHOpenAPI.GetChejanData(915);
				string text2 = "";
				string text3 = "";
				for (int i = 0; i < chejanData2.Length - 2; i++)
				{
					if (chejanData2.Substring(i, 2) == "  ")
					{
						text3 = chejanData2.Substring(0, i);
						break;
					}
				}
				chejanData2 = text3;
				if (chejanData7 == "체결" && chejanData == ((Control)comboBox_계좌번호).Text)
				{
					if (chejanData4 == "1")
					{
						text2 = "Sell";
					}
					else if (chejanData4 == "2")
					{
						text2 = "Buy";
					}
					Update_보유종목_체결(chejanData4, text, chejanData2, chejanData8, chejanData9);
					chejanData5 = chejanData5.Substring(0, 2) + ":" + chejanData5.Substring(2, 2) + ":" + chejanData5.Substring(4, 2);
					FileWrite(s로그저장경로_체결, "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\n", ((Control)lbl현재시간).Text, chejanData5, text2, chejanData2, chejanData8, chejanData9, chejanData.Substring(0, 6));
					Logger(Log.체결장, "[{0}][{1}][{2}][가격 {3:C}원][수량 {4}주]", chejanData5, text2, chejanData2, chejanData8, chejanData9);
					if (text2 == "Buy")
					{
						f예약매도주문(chejanData2, text, chejanData6, chejanData3);
					}
				}
			}
			else if (!(e.sGubun == "1"))
			{
				_ = e.sGubun == "3";
			}
		}

		private void f예약매도주문(string s매수종목명, string s매수종목코드, string s매수체결수량, string s미체결수량)
		{
			int num = 0;
			if (s매수체결수량 != "")
			{
				num = int.Parse(s매수체결수량);
			}
			int num2 = int.Parse(s미체결수량);
			f계좌종목인덱스(s매수종목코드);
			f계좌종목dgv인덱스(s매수종목코드);
			for (int i = 0; i < n예약매도_숫자; i++)
			{
				if (!struct_예약매도리스트[i].b예약매도 || !(struct_예약매도리스트[i].s종목코드 == s매수종목코드) || struct_예약매도리스트[i].n매수요청량 != num + num2)
				{
					continue;
				}
				struct_예약매도리스트[i].n매수체결량 = num;
				if (struct_예약매도리스트[i].n매수체결량 >= struct_예약매도리스트[i].n매도기준량)
				{
					Add_주문(2, s매수종목코드, s매수종목명, "", 0, struct_예약매도리스트[i].n예약매도_수량, struct_예약매도리스트[i].n예약매도_매도주문가격);
					struct_예약매도리스트[i].b예약매도 = false;
					if (struct_예약매도리스트[i].n매도기준량 == num && num2 == 0)
					{
						break;
					}
				}
			}
		}

		private int f호가근사치계산(int nType, int nPrice, double f수익률)
		{
			int num = 0;
			int num2 = 0;
			double num3 = (double)nPrice * (1.0 + f수익률);
			if (num3 < 1000.0)
			{
				num = (int)(num3 + 0.999);
				num2 = (int)num3;
			}
			else if (num3 >= 1000.0 && num3 < 5000.0)
			{
				num = (int)(num3 + 4.999) / 5 * 5;
				num2 = (int)num3 / 5 * 5;
			}
			else if (num3 >= 5000.0 && num3 < 10000.0)
			{
				num = (int)(num3 + 9.999) / 10 * 10;
				num2 = (int)num3 / 10 * 10;
			}
			else if (num3 >= 10000.0 && num3 < 50000.0)
			{
				num = (int)(num3 + 49.999) / 50 * 50;
				num2 = (int)num3 / 50 * 50;
			}
			else if (num3 >= 50000.0 && num3 < 100000.0)
			{
				num = (int)(num3 + 99.999) / 100 * 100;
				num2 = (int)num3 / 100 * 100;
			}
			else if (num3 >= 100000.0 && num3 < 500000.0)
			{
				num = (int)(num3 + 499.999) / 500 * 500;
				num2 = (int)num3 / 500 * 500;
			}
			else
			{
				num = (int)(num3 + 999.999) / 1000 * 1000;
				num2 = (int)num3 / 1000 * 1000;
			}
			return nType switch
			{
				0 => num, 
				1 => num2, 
				_ => -1, 
			};
		}

		private void txt주문종목코드_KeyUp(object sender, KeyEventArgs e)
		{
			if (((Control)txt주문종목코드).Text.Length == 6 && b접속상태)
			{
				Add_조회("호가창", ((Control)txt주문종목코드).Text, "", "");
			}
		}

		private void fn_opt10004(string sCode)
		{
			axKHOpenAPI.SetInputValue("종목코드", sCode);
			axKHOpenAPI.CommRqData("주식호가", "OPT10004", 0, GetScrNum());
			_scrNum++;
		}

		private void fn_opt10005(string sCode)
		{
			axKHOpenAPI.SetInputValue("종목코드", sCode);
			axKHOpenAPI.CommRqData("주식일주월시분", "OPT10005", 0, GetScrNum());
			_scrNum++;
		}

		private void fn_opw00004(string s계좌번호)
		{
			axKHOpenAPI.SetInputValue("계좌번호", s계좌번호);
			axKHOpenAPI.SetInputValue("비밀번호", "");
			axKHOpenAPI.SetInputValue("상장폐지조회구분", "0");
			axKHOpenAPI.SetInputValue("비밀번호입력매체구분", "00");
			axKHOpenAPI.CommRqData("계좌평가현황", "OPW00004", 0, GetScrNum());
			_scrNum++;
		}

		private void fn_opw00007(string s종목코드, string s계좌번호)
		{
			axKHOpenAPI.SetInputValue("주문일자", s오늘날짜);
			axKHOpenAPI.SetInputValue("계좌번호", s계좌번호);
			axKHOpenAPI.SetInputValue("비밀번호", "");
			axKHOpenAPI.SetInputValue("비밀번호입력매체구분", "00");
			axKHOpenAPI.SetInputValue("조회구분", "2");
			axKHOpenAPI.SetInputValue("주식채권구분", "0");
			axKHOpenAPI.SetInputValue("매도수구분", "1");
			axKHOpenAPI.SetInputValue("종목코드", s종목코드);
			axKHOpenAPI.SetInputValue("시작주문번호", "");
			axKHOpenAPI.CommRqData("계좌별주문체결내역상세", "OPW00007", 0, GetScrNum());
			_scrNum++;
		}

		private void fn_opw00018(string s계좌번호, int n연속)
		{
			axKHOpenAPI.SetInputValue("계좌번호", s계좌번호);
			axKHOpenAPI.SetInputValue("비밀번호", "");
			axKHOpenAPI.SetInputValue("상장폐지조회구분", "0");
			axKHOpenAPI.SetInputValue("비밀번호입력매체구분", "00");
			if (n연속 == 0)
			{
				n계좌_보유종목임시 = 0;
			}
			axKHOpenAPI.CommRqData("계좌평가잔고내역", "OPW00018", n연속, GetScrNum());
			_scrNum++;
		}

		private void fn_opt20003(string sCode)
		{
			axKHOpenAPI.SetInputValue("업종코드", sCode);
			axKHOpenAPI.CommRqData("전업종지수요청", "OPT20003", 0, GetScrNum());
			_scrNum++;
		}

		private void fn_opt20001(string sCode1, string sCode2)
		{
			try
			{
				axKHOpenAPI.SetInputValue("시장구분", sCode1);
				axKHOpenAPI.SetInputValue("업종코드", sCode2);
				axKHOpenAPI.CommRqData("업종현재가요청", "OPT20001", 0, GetScrNum());
				_scrNum++;
			}
			catch
			{
			}
		}
	}
	public struct _Struct_GangPRO_Setup
	{
		public int nAccount;

		public string sAccount;

		public int nLosscut;

		public string sLosscut;

		public int nAutoSell;

		public string sAutoSell;

		public int nDivisionSell_1;

		public string sDivisionSell_1;

		public int nDivisionSell_2;

		public string sDivisionSell_2;

		public int nCondition;

		public string sCondition;

		public int nBuyOpt_1;

		public string sBuyOpt_1;

		public int nBuyOpt_2;

		public string sBuyOpt_2;

		public bool bSell;

		public bool bSell_Simple;

		public int nSell_Simple_Opt1;

		public string sSell_Simple_Opt1;

		public int nSell_Simple_Opt2;

		public string sSell_Simple_Opt2;

		public int nSell_Complex_Opt;

		public string sSell_Complex_Opt;

		public int nBuyingTime1;

		public string sBuyingTime1;

		public int nBuyingTime2;

		public string sBuyingTime2;

		public int n매수종목제한;

		public string s매수종목제한;

		public int n종목리스트_초기화주기;

		public string s종목리스트_초기화주기;

		public bool b종목리스트_보유종목매수금지;

		public bool b종목리스트_동일종목주문금지;

		public bool b종목리스트_등록시매수주문;
	}
	public struct Struct_Type_Data_Path
	{
		public string sCurPath;

		public string sUserPath;

		public string sAllCodePath;

		public string sRawDataPath;

		public string sIndexPath;

		public string sStockDailyPath;

		public string sStock5MinPath;

		public string sConditionSettingPath;

		public string sResultPath;

		public string sManualPath;

		public string sGangPRO_SetupPath;
	}
	public class GangPRO : Form
	{
		private string s버전 = "";

		private string s상품구분 = "";

		private string s서비스날짜 = "";

		private string s서비스사용자이름 = "";

		private string s서비스남은날짜 = "";

		private IContainer components;

		private Label label1;

		private Label lbl_버전정보;

		private Label lbl_사용자정보;

		private Label lbl_사용기한;

		private Label label5;

		private LinkLabel linkLabel1;

		private Label label6;

		private Label label7;

		private Button btn닫기;

		public GangPRO(string s1, string s2, string s3, string s4, string s5)
		{
			s버전 = s1;
			s상품구분 = s2;
			s서비스날짜 = s3;
			s서비스사용자이름 = s4;
			s서비스남은날짜 = s5;
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://cafe.naver.com/publicstock");
		}

		private void btn닫기_Click(object sender, EventArgs e)
		{
			((Form)this).Close();
		}

		private void GangPRO_Load(object sender, EventArgs e)
		{
			((Form)this).CenterToParent();
			((Control)lbl_버전정보).Text = "버전 정보   : " + s버전 + "(" + s상품구분 + ")";
			((Control)lbl_사용자정보).Text = "사용자정보 : " + s서비스사용자이름;
			((Control)lbl_사용기한).Text = "사용 기한   : ~ " + s서비스날짜 + " (만료 " + s서비스남은날짜 + " 일전)";
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Expected O, but got Unknown
			label1 = new Label();
			lbl_버전정보 = new Label();
			lbl_사용자정보 = new Label();
			lbl_사용기한 = new Label();
			label5 = new Label();
			linkLabel1 = new LinkLabel();
			label6 = new Label();
			label7 = new Label();
			btn닫기 = new Button();
			((Control)this).SuspendLayout();
			((Control)label1).AutoSize = true;
			((Control)label1).Location = new Point(14, 18);
			((Control)label1).Name = "label1";
			((Control)label1).Size = new Size(360, 12);
			((Control)label1).TabIndex = 0;
			((Control)label1).Text = "GangPRO는 알고리즘 기반 자동매매를 지원하는 프로그램입니다.";
			((Control)lbl_버전정보).AutoSize = true;
			((Control)lbl_버전정보).Location = new Point(14, 41);
			((Control)lbl_버전정보).Name = "lbl_버전정보";
			((Control)lbl_버전정보).Size = new Size(107, 12);
			((Control)lbl_버전정보).TabIndex = 1;
			((Control)lbl_버전정보).Text = "버전정보    : V1.03";
			((Control)lbl_사용자정보).AutoSize = true;
			((Control)lbl_사용자정보).Location = new Point(14, 64);
			((Control)lbl_사용자정보).Name = "lbl_사용자정보";
			((Control)lbl_사용자정보).Size = new Size(101, 12);
			((Control)lbl_사용자정보).TabIndex = 2;
			((Control)lbl_사용자정보).Text = "사용자정보 : 공용";
			((Control)lbl_사용기한).AutoSize = true;
			((Control)lbl_사용기한).Location = new Point(14, 86);
			((Control)lbl_사용기한).Name = "lbl_사용기한";
			((Control)lbl_사용기한).Size = new Size(160, 12);
			((Control)lbl_사용기한).TabIndex = 3;
			((Control)lbl_사용기한).Text = "사용기한    : ~17년 6월 30일";
			((Control)label5).AutoSize = true;
			((Control)label5).Location = new Point(14, 108);
			((Control)label5).Name = "label5";
			((Control)label5).Size = new Size(57, 12);
			((Control)label5).TabIndex = 4;
			((Control)label5).Text = "사용 문의";
			((Control)linkLabel1).AutoSize = true;
			((Control)linkLabel1).Location = new Point(132, 128);
			((Control)linkLabel1).Name = "linkLabel1";
			((Control)linkLabel1).Size = new Size(199, 12);
			((Control)linkLabel1).TabIndex = 11;
			linkLabel1.TabStop = true;
			((Control)linkLabel1).Text = "http://cafe.naver.com/publicstock";
			linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			((Control)label6).AutoSize = true;
			((Control)label6).Location = new Point(60, 128);
			((Control)label6).Name = "label6";
			((Control)label6).Size = new Size(75, 12);
			((Control)label6).TabIndex = 10;
			((Control)label6).Text = "- 카페주소 : ";
			((Control)label7).AutoSize = true;
			((Control)label7).Location = new Point(60, 150);
			((Control)label7).Name = "label7";
			((Control)label7).Size = new Size(203, 12);
			((Control)label7).TabIndex = 9;
			((Control)label7).Text = "- E-mail   : gangstock@naver.com";
			((Control)btn닫기).Location = new Point(158, 171);
			((Control)btn닫기).Name = "btn닫기";
			((Control)btn닫기).Size = new Size(75, 23);
			((Control)btn닫기).TabIndex = 12;
			((Control)btn닫기).Text = "닫기";
			((ButtonBase)btn닫기).UseVisualStyleBackColor = true;
			((Control)btn닫기).Click += btn닫기_Click;
			((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 12f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((Form)this).ClientSize = new Size(411, 206);
			((Control)this).Controls.Add((Control)(object)btn닫기);
			((Control)this).Controls.Add((Control)(object)linkLabel1);
			((Control)this).Controls.Add((Control)(object)label6);
			((Control)this).Controls.Add((Control)(object)label7);
			((Control)this).Controls.Add((Control)(object)label5);
			((Control)this).Controls.Add((Control)(object)lbl_사용기한);
			((Control)this).Controls.Add((Control)(object)lbl_사용자정보);
			((Control)this).Controls.Add((Control)(object)lbl_버전정보);
			((Control)this).Controls.Add((Control)(object)label1);
			((Control)this).Name = "GangPRO";
			((Control)this).Text = "GangPRO";
			((Form)this).TopMost = true;
			((Form)this).Load += GangPRO_Load;
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
	public class HelpForm : Form
	{
		private IContainer components;

		private Label label2;

		private Button btn닫기;

		private Label label3;

		private Label label4;

		private Label label1;

		private Label label5;

		private Label label6;

		private LinkLabel linkLabel1;

		public HelpForm()
		{
			InitializeComponent();
		}

		private void btn닫기_Click(object sender, EventArgs e)
		{
			((Form)this).Close();
		}

		private void HelpForm_Load(object sender, EventArgs e)
		{
			((Form)this).CenterToParent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://cafe.naver.com/publicstock");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Expected O, but got Unknown
			label2 = new Label();
			btn닫기 = new Button();
			label3 = new Label();
			label4 = new Label();
			label1 = new Label();
			label5 = new Label();
			label6 = new Label();
			linkLabel1 = new LinkLabel();
			((Control)this).SuspendLayout();
			((Control)label2).AutoSize = true;
			((Control)label2).Location = new Point(37, 193);
			((Control)label2).Name = "label2";
			((Control)label2).Size = new Size(193, 12);
			((Control)label2).TabIndex = 1;
			((Control)label2).Text = "E-mail   : gangstock@naver.com";
			((Control)btn닫기).Location = new Point(155, 227);
			((Control)btn닫기).Name = "btn닫기";
			((Control)btn닫기).Size = new Size(75, 23);
			((Control)btn닫기).TabIndex = 2;
			((Control)btn닫기).Text = "닫기";
			((ButtonBase)btn닫기).UseVisualStyleBackColor = true;
			((Control)btn닫기).Click += btn닫기_Click;
			((Control)label3).AutoSize = true;
			((Control)label3).Font = new Font("Gulim", 15.75f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)label3).Location = new Point(12, 139);
			((Control)label3).Name = "label3";
			((Control)label3).Size = new Size(98, 21);
			((Control)label3).TabIndex = 3;
			((Control)label3).Text = "문의사항";
			((Control)label4).AutoSize = true;
			((Control)label4).Location = new Point(37, 172);
			((Control)label4).Name = "label4";
			((Control)label4).Size = new Size(65, 12);
			((Control)label4).TabIndex = 4;
			((Control)label4).Text = "카페주소 : ";
			((Control)label1).AutoSize = true;
			((Control)label1).Location = new Point(22, 23);
			((Control)label1).Name = "label1";
			((Control)label1).Size = new Size(169, 12);
			((Control)label1).TabIndex = 5;
			((Control)label1).Text = "사용법은 메뉴얼을 참고하세요";
			((Control)label5).AutoSize = true;
			((Control)label5).Location = new Point(22, 48);
			((Control)label5).Name = "label5";
			((Control)label5).Size = new Size(189, 12);
			((Control)label5).TabIndex = 6;
			((Control)label5).Text = "메뉴얼은 카페 게시판에 있습니다.";
			((Control)label6).AutoSize = true;
			((Control)label6).Location = new Point(22, 72);
			((Control)label6).Name = "label6";
			((Control)label6).Size = new Size(337, 12);
			((Control)label6).TabIndex = 7;
			((Control)label6).Text = "버그 레포팅, 요청사항은 아래 메일이나 카페를 통해 해주세요";
			((Control)linkLabel1).AutoSize = true;
			((Control)linkLabel1).Location = new Point(98, 172);
			((Control)linkLabel1).Name = "linkLabel1";
			((Control)linkLabel1).Size = new Size(199, 12);
			((Control)linkLabel1).TabIndex = 8;
			linkLabel1.TabStop = true;
			((Control)linkLabel1).Text = "http://cafe.naver.com/publicstock";
			linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 12f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((Form)this).ClientSize = new Size(379, 262);
			((Control)this).Controls.Add((Control)(object)linkLabel1);
			((Control)this).Controls.Add((Control)(object)label6);
			((Control)this).Controls.Add((Control)(object)label5);
			((Control)this).Controls.Add((Control)(object)label1);
			((Control)this).Controls.Add((Control)(object)label4);
			((Control)this).Controls.Add((Control)(object)label3);
			((Control)this).Controls.Add((Control)(object)btn닫기);
			((Control)this).Controls.Add((Control)(object)label2);
			((Form)this).MaximizeBox = false;
			((Form)this).MinimizeBox = false;
			((Control)this).Name = "HelpForm";
			((Control)this).Text = "Help";
			((Form)this).Load += HelpForm_Load;
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
	public class LogForm : Form
	{
		private StreamReader sr로그1;

		private StreamReader sr로그2;

		private IContainer components;

		private OpenFileDialog openFileDialog1;

		private ListBox log2;

		private DataGridView dgv매매로그;

		private DataGridViewTextBoxColumn Column1;

		private DataGridViewTextBoxColumn Column2;

		private DataGridViewTextBoxColumn Column3;

		private DataGridViewTextBoxColumn Column4;

		private DataGridViewTextBoxColumn Column5;

		private DataGridViewTextBoxColumn Column6;

		private DataGridViewTextBoxColumn Column7;

		private Button btn닫기;

		public LogForm()
		{
			InitializeComponent();
		}

		private void LogForm_Load(object sender, EventArgs e)
		{
			openfile();
			((Form)this).CenterToParent();
		}

		private void openfile()
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Invalid comparison between Unknown and I4
			((FileDialog)openFileDialog1).InitialDirectory = Application.StartupPath + "\\매매로그\\";
			((FileDialog)openFileDialog1).Filter = "로그파일 (*.lg1)|*.lg1";
			if ((int)((CommonDialog)openFileDialog1).ShowDialog() == 1)
			{
				string fileName = ((FileDialog)openFileDialog1).FileName;
				_ = openFileDialog1.SafeFileName;
				string path = fileName.Substring(0, fileName.Length - 1) + "2";
				string[] array = new string[100000];
				int num = 0;
				sr로그1 = File.OpenText(fileName);
				while (!sr로그1.EndOfStream)
				{
					array[num] = sr로그1.ReadLine();
					num++;
				}
				sr로그1.Close();
				for (int i = 1; i < num; i++)
				{
					string[] array2 = array[i].Split(new char[1] { '\t' });
					dgv매매로그.Rows.Add(new object[7]
					{
						array2[0],
						array2[1],
						array2[2],
						array2[3],
						array2[4],
						array2[5],
						array2[6]
					});
				}
				num = 0;
				sr로그2 = File.OpenText(path);
				while (!sr로그2.EndOfStream)
				{
					array[num] = sr로그2.ReadLine();
					num++;
				}
				sr로그2.Close();
				for (int j = 1; j < num; j++)
				{
					log2.Items.Add((object)array[j]);
					((ListControl)log2).SelectedIndex = log2.Items.Count - 1;
				}
			}
			else
			{
				((Form)this).Close();
			}
		}

		private void btn닫기_Click(object sender, EventArgs e)
		{
			((Form)this).Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Expected O, but got Unknown
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0469: Expected O, but got Unknown
			DataGridViewCellStyle val = new DataGridViewCellStyle();
			DataGridViewCellStyle val2 = new DataGridViewCellStyle();
			openFileDialog1 = new OpenFileDialog();
			log2 = new ListBox();
			dgv매매로그 = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			Column4 = new DataGridViewTextBoxColumn();
			Column5 = new DataGridViewTextBoxColumn();
			Column6 = new DataGridViewTextBoxColumn();
			Column7 = new DataGridViewTextBoxColumn();
			btn닫기 = new Button();
			((ISupportInitialize)dgv매매로그).BeginInit();
			((Control)this).SuspendLayout();
			((ListControl)log2).FormattingEnabled = true;
			log2.HorizontalScrollbar = true;
			log2.ItemHeight = 12;
			((Control)log2).Location = new Point(17, 256);
			((Control)log2).Name = "log2";
			((Control)log2).Size = new Size(507, 220);
			((Control)log2).TabIndex = 0;
			dgv매매로그.AllowUserToAddRows = false;
			dgv매매로그.AllowUserToDeleteRows = false;
			dgv매매로그.AllowUserToResizeColumns = false;
			dgv매매로그.AllowUserToResizeRows = false;
			val.Alignment = (DataGridViewContentAlignment)32;
			val.BackColor = SystemColors.Control;
			val.Font = new Font("Gulim", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val.ForeColor = SystemColors.WindowText;
			val.SelectionBackColor = SystemColors.Highlight;
			val.SelectionForeColor = SystemColors.HighlightText;
			val.WrapMode = (DataGridViewTriState)1;
			dgv매매로그.ColumnHeadersDefaultCellStyle = val;
			dgv매매로그.ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
			dgv매매로그.Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[7]
			{
				(DataGridViewColumn)Column1,
				(DataGridViewColumn)Column2,
				(DataGridViewColumn)Column3,
				(DataGridViewColumn)Column4,
				(DataGridViewColumn)Column5,
				(DataGridViewColumn)Column6,
				(DataGridViewColumn)Column7
			});
			val2.Alignment = (DataGridViewContentAlignment)32;
			val2.BackColor = SystemColors.Window;
			val2.Font = new Font("Gulim", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)129);
			val2.ForeColor = SystemColors.ControlText;
			val2.SelectionBackColor = SystemColors.Highlight;
			val2.SelectionForeColor = SystemColors.HighlightText;
			val2.WrapMode = (DataGridViewTriState)2;
			dgv매매로그.DefaultCellStyle = val2;
			((Control)dgv매매로그).Location = new Point(17, 38);
			((Control)dgv매매로그).Name = "dgv매매로그";
			dgv매매로그.ReadOnly = true;
			dgv매매로그.RowHeadersVisible = false;
			dgv매매로그.RowTemplate.Height = 23;
			((Control)dgv매매로그).Size = new Size(507, 212);
			((Control)dgv매매로그).TabIndex = 1;
			((DataGridViewColumn)Column1).HeaderText = "시간";
			((DataGridViewColumn)Column1).Name = "Column1";
			((DataGridViewBand)Column1).ReadOnly = true;
			((DataGridViewColumn)Column1).Width = 60;
			((DataGridViewColumn)Column2).HeaderText = "키움시간";
			((DataGridViewColumn)Column2).Name = "Column2";
			((DataGridViewBand)Column2).ReadOnly = true;
			((DataGridViewColumn)Column2).Width = 60;
			((DataGridViewColumn)Column3).HeaderText = "구분";
			((DataGridViewColumn)Column3).Name = "Column3";
			((DataGridViewBand)Column3).ReadOnly = true;
			((DataGridViewColumn)Column3).Width = 50;
			((DataGridViewColumn)Column4).HeaderText = "종목명";
			((DataGridViewColumn)Column4).Name = "Column4";
			((DataGridViewBand)Column4).ReadOnly = true;
			((DataGridViewColumn)Column5).HeaderText = "가격";
			((DataGridViewColumn)Column5).Name = "Column5";
			((DataGridViewBand)Column5).ReadOnly = true;
			((DataGridViewColumn)Column5).Width = 60;
			((DataGridViewColumn)Column6).HeaderText = "수량";
			((DataGridViewColumn)Column6).Name = "Column6";
			((DataGridViewBand)Column6).ReadOnly = true;
			((DataGridViewColumn)Column6).Width = 60;
			((DataGridViewColumn)Column7).HeaderText = "계좌(앞6)";
			((DataGridViewColumn)Column7).Name = "Column7";
			((DataGridViewBand)Column7).ReadOnly = true;
			((Control)btn닫기).Font = new Font("Gulim", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)129);
			((Control)btn닫기).Location = new Point(17, 9);
			((Control)btn닫기).Name = "btn닫기";
			((Control)btn닫기).Size = new Size(75, 23);
			((Control)btn닫기).TabIndex = 2;
			((Control)btn닫기).Text = "닫기";
			((ButtonBase)btn닫기).UseVisualStyleBackColor = true;
			((Control)btn닫기).Click += btn닫기_Click;
			((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 12f);
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
			((Form)this).ClientSize = new Size(536, 487);
			((Control)this).Controls.Add((Control)(object)btn닫기);
			((Control)this).Controls.Add((Control)(object)dgv매매로그);
			((Control)this).Controls.Add((Control)(object)log2);
			((Control)this).Name = "LogForm";
			((Control)this).Text = "로그내역확인";
			((Form)this).TopMost = true;
			((Form)this).Load += LogForm_Load;
			((ISupportInitialize)dgv매매로그).EndInit();
			((Control)this).ResumeLayout(false);
		}
	}
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run((Form)(object)new Form1());
		}
	}
}
namespace GangPRO.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("GangPRO.Properties.Resources", typeof(Resources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal Resources()
		{
		}
	}
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

		public static Settings Default => defaultInstance;
	}
}
