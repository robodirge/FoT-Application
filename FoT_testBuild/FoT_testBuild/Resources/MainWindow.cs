/*
 * Copyright Zoonou, for internal use only
 * Developed and Maintained by Ben Vere
 * Any queries and or problems please contact me @ ben.vere@zoonou.com / 07596869638
 * Last updated (header) 13/09/2013
*/

using System;
using System.IO;
using Gtk;

using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Globalization;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;

public partial class MainWindow: Gtk.Window{	
	public static bool enabledSection { get; set; }
	public static string baseLocation { get; set; }
	public static string baseLocation1 { get; set; }
	public static string currentPath {get; set; }
	public static bool runDocMode {get; set;}

	public static string clientName1{get; set;}
	public static string projectName1{get; set;}

	//Word.Application wordApplication = new Word.Application();
	Word.Application wordApplication = null;
	Word.Document newDocument = null;

	public MainWindow (): base (Gtk.WindowType.Toplevel){
		Build ();
		onStartActions ();
		label2.Text = currentPath;
	}

	/*General start up parameters*/
	protected void onStartActions(){
		// Turn off visable labels and text areas
		enabledSection = false;
		labelClient2.Visible = false;
		labelProject2.Visible = false;
		entry3.Visible = false;
		entry4.Visible = false;
		enabledSection = false;

		runDocMode = true;  //<----- word doc mode
		//---------------------------------------

		string configLocation = Environment.CurrentDirectory + @"\Resources\Config.txt";

		baseLocation1 = Environment.CurrentDirectory + @"\Resources\Unrepeatable.docx";
		baseLocation = Environment.CurrentDirectory + @"\Resources\Client Name - Project Name Daily Report - DDMMYYYY.docx";

		try{
			using(StreamReader sr = new StreamReader(configLocation)){
				string line = sr.ReadToEnd();
				Console.WriteLine(line);

				if(line == "Default"){
					currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					currentPath = currentPath + @"\FoT\";
				}else{
					currentPath = line;
					currentPath = currentPath;
				}
			}
		}catch{
			Console.WriteLine("Can not locate 'Config.txt'");
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButtonQuitClicked (object sender, EventArgs e){
		// Quite main application
		Gtk.Main.Quit (); 
	}

	protected void OnButton2Clicked(object sender, EventArgs e){
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog("Choose a file", this, FileChooserAction.SelectFolder, "cancel", ResponseType.Cancel, "choose", ResponseType.Accept);
		string mytempfilename = "";
		if(fc.Run() == (int)ResponseType.Accept){
			mytempfilename = fc.CurrentFolder;

			string configLocation = Environment.CurrentDirectory + @"\Resources\Config.txt";
			FileInfo fi = new FileInfo(configLocation);

			using(TextWriter tw = new StreamWriter(fi.Open(FileMode.Truncate))){
				tw.Write(mytempfilename);
				tw.Close();
			}
			currentPath = mytempfilename;
			label2.Text = mytempfilename;
			fc.Destroy();
		}else{
			fc.Destroy();
		}
	}

	protected void OnButtonContinueClicked (object sender, EventArgs e){
		if(!Directory.Exists(currentPath)){
			DirectoryInfo di = Directory.CreateDirectory(currentPath);
		}

		//Collect the data the user entered
		clientName1 = entry1.Text;
		projectName1 = entry2.Text;

		//If the user did not supply any name - provide the folder/file with a default name
		if(clientName1 == ""){
			clientName1 = "Client_1";
		}

		if(projectName1 == ""){
			projectName1 = "Project_1";
		}
		//Combine two strings with ' - ' seperator 
		string halfDayResource = clientName1 + " - " + projectName1;
		//Creating string for use later
		string FullDayResource = "";

		/*if(enabledSection==true){
			string clientName2 = entry3.Text;
			string projectName2 = entry4.Text;

			//If the user did not supply any name - provide the folder/file with a default name
			if(clientName2 == ""){
				clientName2 = "Client_2";
			}

			if(projectName2 == ""){
				projectName2 = "Project_2";
			}

			FullDayResource = clientName2 + " - " + projectName2;
		}*/

		string currentDate = DateTime.Now.ToString("yyyy_MMMMM");
		currentPath = currentPath + @"\" + currentDate + @"\";

		if(!Directory.Exists(currentPath)){
			DirectoryInfo di = Directory.CreateDirectory(currentPath);
		}

		//Continue with folder set up
		FolderSetup(currentPath, ref halfDayResource, ref FullDayResource,  e);
	} 

	protected void FolderSetup(string path, ref string halfDR,ref string fullDR, EventArgs e){
		string currentDate = DateTime.Now.ToString("yyyy_MM_dd");
		string DailyDate = (@" Daily Report - " + DateTime.Now.ToString("ddMMyyyy"));
		path = path + currentDate + @"\";

		if(!Directory.Exists(path)){
			DirectoryInfo di = Directory.CreateDirectory(path);
		}

		string pathClient1 = path;
		pathClient1 = pathClient1 + halfDR + @"\";

		if(!Directory.Exists(pathClient1)){
			//string pathClient1 = path;
			DirectoryInfo di = Directory.CreateDirectory(pathClient1);

			// Copy dayily report here
			string tempNameString = pathClient1 + @"Client Name - Project Name Daily Report - DDMMYYYY.docx";
			File.Copy(baseLocation, tempNameString);
			System.IO.File.Move(tempNameString, (pathClient1 + halfDR + DailyDate + @".docx"));

			//Create folder working docs
			DirectoryInfo wd = Directory.CreateDirectory((pathClient1 + @"Working_Docs\"));
			//Copy unrepeat doc in the folder just created
			string tempLocString = pathClient1 + @"Working_Docs\Unrepeatable.docx";
			File.Copy(baseLocation1, tempLocString);

			//Creae folder pics and sub folders
			pathClient1 = pathClient1 + @"Screenshots\";
			//Create files using path and name etc
			massCreateFiles(ref pathClient1);
		}

		/*if(enabledSection==true){
			string pathClient2 = path;
			pathClient2 = pathClient2 + fullDR + @"\";

			if(!Directory.Exists(pathClient2)){
				DirectoryInfo di = Directory.CreateDirectory(pathClient2);

				string tempNameString = pathClient2 + @"Client Name - Project Name Daily Report - DDMMYYYY.docx";
				File.Copy(baseLocation, tempNameString);
				System.IO.File.Move(tempNameString, (pathClient2 + fullDR + DailyDate + @".docx"));

				//Create folder working docs
				DirectoryInfo wd = Directory.CreateDirectory((pathClient2 + @"Working_Docs\"));
				//Copy unrepeat doc in the folder just created
				string tempLocString = pathClient2 + @"Working_Docs\Unrepeatable.docx";
				File.Copy(baseLocation1, tempLocString);

				//Creae folder pics and sub folders
				pathClient2 = pathClient2 + @"Screenshots\";
				//Create files using path and name etc
				massCreateFiles(ref pathClient2);
			}
		}*/

		if(runDocMode == true)
			runWordApplication();

		Application.Quit ();
	}

	#region region1

	protected void massCreateFiles(ref string dirPath){
		DirectoryInfo ss = Directory.CreateDirectory(dirPath);
		//sub folders
		DirectoryInfo An = Directory.CreateDirectory((dirPath + @"Android\"));
		DirectoryInfo Bb = Directory.CreateDirectory((dirPath + @"BlackBerry\"));
		DirectoryInfo Dt = Directory.CreateDirectory((dirPath + @"Desktop\"));
		DirectoryInfo iO = Directory.CreateDirectory((dirPath + @"iOS\"));
		DirectoryInfo iOb1 = Directory.CreateDirectory((dirPath + @"iOS\Batch1\"));
		DirectoryInfo iOb2 = Directory.CreateDirectory((dirPath + @"iOS\Batch2\"));
		DirectoryInfo iOb3 = Directory.CreateDirectory((dirPath + @"iOS\Batch3\"));
		DirectoryInfo Wp = Directory.CreateDirectory((dirPath + @"WindowsPhone\"));
	}

	protected void OnRadioResource2Toggled (object sender, EventArgs e){
		if (enabledSection == false) {
			labelClient2.Visible = true;
			labelProject2.Visible = true;
			entry3.Visible = true;
			entry4.Visible = true;
			enabledSection = true;
		} else {
			labelClient2.Visible = false;
			labelProject2.Visible = false;
			entry3.Visible = false;
			entry4.Visible = false;
			enabledSection = false;
		}
	}
	protected void OnNewActionActivated(object sender, EventArgs e){
		return;
	}

	protected void OnClearActionActivated(object sender, EventArgs e){
		return;
	}

	protected void OnButton1Clicked (object sender, EventArgs e){
		string configLocation = Environment.CurrentDirectory + @"\Resources\Config.txt";
		FileInfo fi = new FileInfo(configLocation);

		using(TextWriter tw = new StreamWriter(fi.Open(FileMode.Truncate))){
			string temptstr = "Default"; 
			tw.Write(temptstr);
			tw.Close();
			label2.Text = currentPath;
		}
		currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		currentPath = currentPath + @"\FoT\";
		label2.Text = currentPath;

		entry1.Text = "";
		entry2.Text = "";
		entry3.Text = "";
		entry4.Text = "";
	}
	protected void OnDevEnviromentActionActivated (object sender, EventArgs e)
	{
		new FoT.DevWindow();
	}

	#endregion

	protected void runWordApplication(){
		this.Build ();
		wordApplication = new Word.Application();
		wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		newDocument = wordApplication.Documents.Add();

		//wordApplication.Selection.Font.Bold = 1;
		wordApplication.Selection.Font.Size = 11;
		wordApplication.Selection.Font.Name = "Corbel";

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
		wordApplication.Selection.MoveRight();
		wordApplication.ActiveWindow.Selection.TypeParagraph();
		wordApplication.Selection.PageSetup.HeaderDistance = 12.00f;
		wordApplication.Selection.PageSetup.FooterDistance = 12.00f;
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

	#region tableformat

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
		wordApplication.Selection.TypeText(clientName1);
		table.Cell(3,2).Select();
		wordApplication.Selection.TypeText(projectName1);
		table.Cell(6,2).Select();
		wordApplication.Selection.TypeText(	@"Please detail Primary functional test environment(s) where scripted testing is being carried out. 

For cross environment checks/smoke tests, please see the environments detailed in the table at the end of the report*.

For issue verifications please state: Retests executed in environments the issues were originally raised in.");

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

		table.Cell(2,2).Select();
		wordApplication.Selection.TypeText(@"BV / TY");
		table.Cell(3,2).Select();
		wordApplication.Selection.TypeText(DateTime.Now.ToString(@"dd/MM/yyyy"));


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
		wordApplication.Selection.TypeText(@"Scripting & Planning/Test Execution/Issue Verification & Retest (Please delete as appropriate)");
		table.Cell(3,2).Select();
		wordApplication.Selection.TypeText(@"Brief explanation of the work you have undertaken. Be specific here as to what you have done. Relate it back to the tasks that were required of you in the brief. 
E.g. Copy/link and rendering checks of 18 IKEA Kitchen emails across all specified environments.
E.g. Retests including issue verifications of all issues marked as resolved in the tracker.
E.g. Commenced test execution against the fully scripted test plan on …environments.
E.g. Conducted tests of all the changes detailed in the “xyz.doc” document provided by the client.

If a scenario arises where you’re not in work the following day – make sure this section makes it very clear to another tester what you have done.");
		table.Cell(4,2).Select();
		wordApplication.Selection.TypeText(@"Remember this is for the client – to give them an overview of what we have done, the results we have found and our general feedback on the application. Be factual – avoid subjective statements or opinions.  Use “We” rather than “I”. 

Things to include might be:

•	A summary of how the site/app is behaving compared to expected behaviour. 
•	How is the testing progressing against the time scheduled? Were we able to get done today what we had planned? If not, why?
•	A brief rundown of the major problems you're seeing
•	If our testing budget is used up – could more testing be required?
•	Ensure all information is measureable.
•	User experience feedback that may be valuable to the client, that is supported by factual evidence with issues in the tracker.

DO NOT:
•	Do not offer an opinion as to whether the app is ready for release.
•	Do not provide subjective feelings (e.g. “We felt that the website performed well”).
•	Do not suggest that we are ahead of schedule.");

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

	#endregion


}
