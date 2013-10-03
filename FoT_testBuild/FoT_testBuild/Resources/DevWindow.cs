using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Globalization;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;

namespace FoT
{
	public partial class DevWindow : Gtk.Window
	{

		Word.Application wordApplication = new Word.Application();
		Word.Document newDocument = null;

		public DevWindow () : base(Gtk.WindowType.Toplevel){
			this.Build ();
			/*
			// start word and turn off msg boxes
			Word.Application wordApplication = new Word.Application();
			wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;

			// add a new document
			Word.Document newDocument = wordApplication.Documents.Add();

			// insert some text
			wordApplication.Selection.TypeText("This text is written by NetOffice");

			wordApplication.Selection.HomeKey(WdUnits.wdLine, WdMovementType.wdExtend);
			wordApplication.Selection.Font.Color = WdColor.wdColorSeaGreen;
			wordApplication.Selection.Font.Bold = 1;
			wordApplication.Selection.Font.Size = 18;

			// we save the document as .doc for compatibility with all word versions
			//string documentFile = string.Format("{0}\\Example01{1}", _hostApplication.RootDirectory, ".doc");
			string documentFile = @"C:\Users\Ben\Downloads\TemptDoc.doc";
			double wordVersion = Convert.ToDouble(wordApplication.Version, CultureInfo.InvariantCulture);
			if (wordVersion >= 12.0)
				newDocument.SaveAs(documentFile, WdSaveFormat.wdFormatDocumentDefault);
			else
				newDocument.SaveAs(documentFile);

			// close word and dispose reference
			wordApplication.Quit();
			wordApplication.Dispose();
			*/

			// start word and turn off msg boxes
			//Word.Application wordApplication = new Word.Application();
			wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;

			// add a new document
			//Word.Document newDocument = wordApplication.Documents.Open(@"C:\Users\Ben\Desktop\Develop_WIP\delete me\test.docx");
			// add a new document
			newDocument = wordApplication.Documents.Add();

			//Tables
			firstTable();
				moveDownpar();
			secondTable();
				moveDownpar();
			thirdTable();
				moveDownpar();
			fouthTable();
				moveDownpar();
			fithTable();
				moveDownpar();
			wordApplication.Selection.TypeText(@"*Environments checked in this test run");

			wordApplication.ActiveWindow.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
			wordApplication.Selection.InlineShapes.AddPicture(@"C:\Users\Ben\Desktop\Develop_WIP\delete me\ZoonouLogo.jpg");

			wordApplication.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;

			string documentFile = @"C:\Users\Ben\Desktop\Develop_WIP\delete me\test.docx";
			double wordVersion = Convert.ToDouble(wordApplication.Version, CultureInfo.InvariantCulture);
			if (wordVersion >= 12.0)
				newDocument.SaveAs(documentFile, WdSaveFormat.wdFormatDocumentDefault);
			else
				newDocument.SaveAs(documentFile);

			// close word and dispose reference
			wordApplication.Quit();
			wordApplication.Dispose();

		}

		public void moveDownpar(){
			wordApplication.Selection.MoveDown();
			wordApplication.Selection.MoveDown();
			wordApplication.Selection.TypeParagraph();
			return;
		}

		public void firstTable(){
			//
			int r = 6;
			int c = 2;
			Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

			for(int x = 1; x < 7; x++){
				table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
				//Console.WriteLine(table.Cell(1,1).Width);
			}

			table.Cell(1,1).Select();
			wordApplication.Selection.TypeText(@"Project Details");
			table.Cell(2,1).Select();
			wordApplication.Selection.TypeText(@"Client:");
			table.Cell(3,1).Select();
			wordApplication.Selection.TypeText(@"Project name:");
			table.Cell(4,1).Select();
			wordApplication.Selection.TypeText(@"URL(s) tested:");
			table.Cell(5,1).Select();
			wordApplication.Selection.TypeText(@"Build version(s) tested:");
			table.Cell(6,1).Select();
			wordApplication.Selection.TypeText(@"Test environment(s):");

			table.Cell(2,2).Select();
			wordApplication.Selection.TypeText(@"Ben's temp client");
			table.Cell(3,2).Select();
			wordApplication.Selection.TypeText(@"Ben's temp Project");
			table.Cell(6,2).Select();
			wordApplication.Selection.TypeText(@"sjhosfhossohsofnfvosfnvofnoofojsfhosffsohfsofsosfohfso osf ojsf osf ofs sfosfiosf ofshosf osos fofsh os fhofs osfh sofh fsosfoh fsofosf osfh osf os");

			table.Style = "List Table 4 - Accent 5";

			table.Dispose();
			return;
		}

		public void secondTable(){
			//
			int r = 3;
			int c = 2;
			Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

			for(int x = 1; x < 4; x++){
				table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
				//Console.WriteLine(table.Cell(1,1).Width);
			}

			table.Cell(1,1).Select();
			wordApplication.Selection.TypeText(@"Report Details");
			table.Cell(2,1).Select();
			wordApplication.Selection.TypeText(@"Tester Name:");
			table.Cell(3,1).Select();
			wordApplication.Selection.TypeText(@"Date:");


			table.Style = "List Table 4 - Accent 5";

			table.Dispose();
			return;
		}

		public void thirdTable(){
			//
			int r = 4;
			int c = 2;
			Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

			for(int x = 1; x < 5; x++){
				table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
				//Console.WriteLine(table.Cell(1,1).Width);
			}

			table.Cell(1,1).Select();
			wordApplication.Selection.TypeText(@"Report Detail");
			table.Cell(2,1).Select();
			wordApplication.Selection.TypeText(@"Test activities:");
			table.Cell(3,1).Select();
			wordApplication.Selection.TypeText(@"Test tasks completed:");
			table.Cell(4,1).Select();
			wordApplication.Selection.TypeText(@"Brief overview of testing:");

			table.Cell(2,2).Select();
			wordApplication.Selection.TypeText(@"Bluh");
			table.Cell(3,2).Select();
			wordApplication.Selection.TypeText(@"12231");
			table.Cell(4,2).Select();
			wordApplication.Selection.TypeText(@"252452352");

			table.Style = "List Table 4 - Accent 5";

			table.Dispose();
			return;
		}

		public void fouthTable(){
			//
			int r = 9;
			int c = 2;
			Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

			for(int x = 1; x < 10; x++){
				table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
				//Console.WriteLine(table.Cell(1,1).Width);
			}

			table.Cell(1,1).Select();
			wordApplication.Selection.TypeText(@"Issue Summary");
			table.Cell(2,1).Select();
			wordApplication.Selection.TypeText(@"Have any issues been found that block test progress? (Y/N):");
			table.Cell(3,1).Select();
			wordApplication.Selection.TypeText(@"Issues blocking testing:");
			table.Cell(4,1).Select();
			wordApplication.Selection.TypeText(@"Top 5 issues of concern:");
			table.Cell(5,1).Select();
			wordApplication.Selection.TypeText(@"");
			table.Cell(6,1).Select();
			wordApplication.Selection.TypeText(@"");
			table.Cell(7,1).Select();
			wordApplication.Selection.TypeText(@"");
			table.Cell(8,1).Select();
			wordApplication.Selection.TypeText(@"");
			table.Cell(9,1).Select();
			wordApplication.Selection.TypeText(@"");

			table.Cell(2,2).Select();
			wordApplication.Selection.TypeText(@"N");
			table.Cell(3,2).Select();
			wordApplication.Selection.TypeText(@"(Issue numbers)");
			table.Cell(5,2).Select();
			wordApplication.Selection.TypeText(@"#101 - Temp text");
			table.Cell(6,2).Select();
			wordApplication.Selection.TypeText(@"#102 - Temp text");
			table.Cell(7,2).Select();
			wordApplication.Selection.TypeText(@"#103 - Temp text");
			table.Cell(8,2).Select();
			wordApplication.Selection.TypeText(@"#104 - Temp text");
			table.Cell(9,2).Select();
			wordApplication.Selection.TypeText(@"#105 - Temp text");

			table.Style = "List Table 4 - Accent 5";

			table.Dispose();
			return;
		}

		public void fithTable(){
			//
			int r = 5;
			int c = 2;
			Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

			for(int x = 1; x < 6; x++){
				table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
				//Console.WriteLine(table.Cell(1,1).Width);
			}

			table.Cell(1,1).Select();
			wordApplication.Selection.TypeText(@"Metrics");
			table.Cell(2,1).Select();
			wordApplication.Selection.TypeText(@"New issues raised today:");
			table.Cell(3,1).Select();
			wordApplication.Selection.TypeText(@"Issues re-opened today:");
			table.Cell(4,1).Select();
			wordApplication.Selection.TypeText(@"Issues closed today:");
			table.Cell(5,1).Select();
			wordApplication.Selection.TypeText(@"Total number of issues currently open against this project:");

			table.Cell(2,2).Select();
			wordApplication.Selection.TypeText(@"4");
			table.Cell(3,2).Select();
			wordApplication.Selection.TypeText(@"9");
			table.Cell(4,2).Select();
			wordApplication.Selection.TypeText(@"20");
			table.Cell(5,2).Select();
			wordApplication.Selection.TypeText(@"38");

			table.Style = "List Table 4 - Accent 5";

			table.Dispose();
			return;
		}
	}
}

