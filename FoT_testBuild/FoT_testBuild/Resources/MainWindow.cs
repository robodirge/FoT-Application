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
using System.ComponentModel;
using System.Diagnostics;

using NetOffice;
using Word = NetOffice.WordApi;
using NetOffice.WordApi.Enums;


public partial class MainWindow: Gtk.Window{	

	#region Globals

	public static bool enabledSection { get; set; }
	public static string baseLocation { get; set; }
	public static string baseLocation1 { get; set; }
	public static string imageLoc { get; set; }
	public static string configLocation { get; set; }
	public static string logfile { get; set; }
	public static string currentPath {get; set; }
	public static string tempLocString {get; set; }
	public static bool runDocMode {get; set;}

	public static string clientName1{get; set;}
	public static string projectName1{get; set;}
	public static string txtURL{get; set;}
	public static string txtVersion{get; set;}
	public static string newPath {get; set; }

	static string[] configLines; 

	Word.Application wordApplication = null;
	Word.Document newDocument = null;

	#endregion

	#region Main
	public MainWindow (): base (Gtk.WindowType.Toplevel){
		Build ();
		onStartActions ();
		label2.Text = currentPath;
		entry4.Text = DateTime.Now.ToString(@"dd/MM/yyyy");
	}

	/*General start up parameters*/
	protected void onStartActions(){
		runDocMode = true;  //<----- word doc mode
		//---------------------------------------
		configLocation = Environment.CurrentDirectory + @"\Resources\Config.txt";
		logfile = Environment.CurrentDirectory + @"\Resources\log.txt";
		imageLoc = Environment.CurrentDirectory + @"\Resources\ZoonouLogo.jpg";
		baseLocation1 = Environment.CurrentDirectory + @"\Resources\Unrepeatable.docx";
		baseLocation = Environment.CurrentDirectory + @"\Resources\Client Name - Project Name Daily Report - DDMMYYYY.docx";

		try{
			using(StreamReader file = new StreamReader(configLocation)){
				string line;
				int lineCount = 0;

				while((line = file.ReadLine()) != null){
					lineCount++;
				}

				configLines = new string[lineCount];
				lineCount = 0;
				file.Close();
			}
			using(StreamReader file = new StreamReader(configLocation)){
				string line;
				int lineCount = 0;

				while((line = file.ReadLine()) != null){
					if(lineCount == 0){
						if(line == "Default"){
							currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
							currentPath = currentPath + @"\FoT\";
							configLines[lineCount] = currentPath;
						}else{
							currentPath = line;
							configLines[lineCount] = line;
						}
					}else if(lineCount == 1){
						testerNameTB1.Text = line;
						configLines[lineCount] = line;
					}
					lineCount++;
				}

				file.Close();
			}
		}catch{
			Console.WriteLine("Cannot locate 'Config.txt'");
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		//a.RetVal = true;
	}

	protected void OnButtonQuitClicked (object sender, EventArgs e){
		Application.Quit ();
	}

	protected void OnButton2Clicked(object sender, EventArgs e){
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog("Choose a file", this, FileChooserAction.SelectFolder, "Cancel", ResponseType.Cancel, "Choose", ResponseType.Accept);
		string mytempfilename = "";

		if(fc.Run() == (int)ResponseType.Accept){
			mytempfilename = fc.CurrentFolder;

			if(File.Exists(configLocation)){
				configLines[0] = mytempfilename;
				File.WriteAllLines(configLocation, configLines);
			}

			currentPath = mytempfilename;
			label2.Text = mytempfilename;
			fc.Destroy();

		}else{
			fc.Destroy();
		}
	}

	//<Param>  Continue --------  </param>
	protected void OnButtonContinueClicked (object sender, EventArgs e){
		if(!Directory.Exists(currentPath)){
			DirectoryInfo di = Directory.CreateDirectory(currentPath);
		}

		if(File.Exists(configLocation)){
			configLines[1] = testerNameTB1.Text;
			File.WriteAllLines(configLocation, configLines);
		}

		//Collect the data the user entered
		clientName1 = entry1.Text;
		projectName1 = entry2.Text;
		txtURL = entry3.Text;
		txtVersion = entry4.Text;
		
		if(clientName1 == ""){
			clientName1 = "Client_1";
		}

		if(projectName1 == ""){
			projectName1 = "Project_1";
		}

		string halfDayResource = clientName1 + " - " + projectName1;
		string FullDayResource = "";
		string currentDate = DateTime.Now.ToString("yyyy_MMMMM");
		currentPath = currentPath + @"\" + currentDate + @"\";

		if(!Directory.Exists(currentPath)){
			DirectoryInfo di = Directory.CreateDirectory(currentPath);
		}
		
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

		bool bcontinue = false;

		if(!Directory.Exists(pathClient1)){
			DirectoryInfo di = Directory.CreateDirectory(pathClient1);
			newPath = (pathClient1 + halfDR + DailyDate + @".docx");

			DirectoryInfo wd = Directory.CreateDirectory((pathClient1 + @"Working_Docs\"));
			tempLocString = pathClient1 + @"Working_Docs\Unrepeatable.docx";

			pathClient1 = pathClient1 + @"Screenshots\";
			massCreateFiles(ref pathClient1);

			bcontinue = true;

		}

		
		if(bcontinue == true){		
			if(runDocMode == true){
				if(dailyCheck.Active)
					runWordApplication();
				if(repeatCheck.Active)
					runRepeatDoc();
			}

			string tempchar4 = pathClient1;
			tempchar4 = tempchar4.Replace(@"\\", @"\");
			string args4 = ("/select, \"" + tempchar4 +"\"");
			ProcessStartInfo pifi = new ProcessStartInfo("Explorer.exe", args4);
			System.Diagnostics.Process.Start(pifi);
		}
		
		Application.Quit ();
	}

	protected void massCreateFiles(ref string dirPath){
		DirectoryInfo ss = Directory.CreateDirectory(dirPath);
		//sub folders
		DirectoryInfo An = Directory.CreateDirectory((dirPath + @"Batch1\"));
		DirectoryInfo Bb = Directory.CreateDirectory((dirPath + @"Batch2\"));
		DirectoryInfo Dt = Directory.CreateDirectory((dirPath + @"Batch3\"));
		//DirectoryInfo iO = Directory.CreateDirectory((dirPath + @"iOS\"));
		//DirectoryInfo iOb1 = Directory.CreateDirectory((dirPath + @"iOS\Batch1\"));
		//DirectoryInfo iOb2 = Directory.CreateDirectory((dirPath + @"iOS\Batch2\"));
		//DirectoryInfo iOb3 = Directory.CreateDirectory((dirPath + @"iOS\Batch3\"));
		//DirectoryInfo Wp = Directory.CreateDirectory((dirPath + @"WindowsPhone\"));
	}
	#endregion
	#region Buttons

	protected void OnButton1Clicked (object sender, EventArgs e){
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

		entry4.Text = DateTime.Now.ToString(@"dd/MM/yyyy");
	
		checkbutton1.Active = false;
		checkbutton2.Active = true;
		checkbutton3.Active = false;
	}

	protected void OnButton3Clicked (object sender, EventArgs e){
		new FoT.EnvironmentChooser();
	}

	#endregion
	#region tableformat

	protected void runWordApplication(){
		wordApplication = new Word.Application();
		wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		newDocument = wordApplication.Documents.Add();

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
		wordApplication.Selection.InlineShapes.AddPicture(imageLoc);
		wordApplication.Selection.MoveRight();
		wordApplication.ActiveWindow.Selection.TypeParagraph();
		wordApplication.Selection.PageSetup.HeaderDistance = 12.00f;
		wordApplication.Selection.PageSetup.FooterDistance = 12.00f;
		wordApplication.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
		wordApplication.Selection.WholeStory();
		wordApplication.Selection.Font.Color = WdColor.wdColorBlack;

		string documentFile = newPath;

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
		int r = 6;
		int c = 2;
		Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

		for(int x = 1; x < 7; x++){
			table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
		}

		table.Cell(1,1).Select();
		wordApplication.Selection.Font.Bold = 1;
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
		table.Cell(4,2).Select();
		wordApplication.Selection.TypeText(txtURL);
		table.Cell(5,2).Select();
		wordApplication.Selection.TypeText(txtVersion);
		table.Cell(6,2).Select();
		wordApplication.Selection.TypeText(	@"Please detail Primary functional test environment(s) where scripted testing is being carried out. 

For cross environment checks/smoke tests, please see the environments detailed in the table at the end of the report*.

For issue verifications please state: Retests executed in environments the issues were originally raised in.");

		String bobone = wordApplication.Version;

		if(bobone == "14.0"){
			table.Style = "Light Shading - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}else{
			table.Style = "List Table 6 Colorful - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}

		table.Dispose();
		return;
	}

	public void secondTable(){
		int r = 3;
		int c = 2;
		Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

		for(int x = 1; x < 4; x++){
			table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
			//Console.WriteLine(table.Cell(1,1).Width);
		}

		table.Cell(1,1).Select();
		wordApplication.Selection.Font.Bold = 1;
		wordApplication.Selection.TypeText(@"Report Details");
		table.Cell(2,1).Select();
		wordApplication.Selection.TypeText(@"Tester Name:");
		table.Cell(3,1).Select();
		wordApplication.Selection.TypeText(@"Date:");

		table.Cell(2,2).Select();
		wordApplication.Selection.TypeText(configLines[1]);  //////////////////////////////////////////
		table.Cell(3,2).Select();
		wordApplication.Selection.TypeText(DateTime.Now.ToString(@"dd/MM/yyyy"));

		String bobone = wordApplication.Version;

		if(bobone == "14.0"){
			table.Style = "Light Shading - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}else{
			table.Style = "List Table 6 Colorful - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}

		table.Dispose();
		return;
	}

	public void thirdTable(){
		int r = 4;
		int c = 2;
		Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

		for(int x = 1; x < 5; x++){
			table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
		}

		table.Cell(1,1).Select();
		wordApplication.Selection.Font.Bold = 0;
		wordApplication.Selection.TypeText(@"Report Detail");
		table.Cell(2,1).Select();
		wordApplication.Selection.TypeText(@"Test activities:");
		table.Cell(3,1).Select();
		wordApplication.Selection.TypeText(@"Test tasks completed:");
		table.Cell(4,1).Select();
		wordApplication.Selection.TypeText(@"Brief overview of testing:");

		string activtemp = "";

		if((checkbutton1.Active == false) & (checkbutton2.Active == false) & (checkbutton3.Active == false)){
			activtemp = @"Scripting & Planning/Test Execution/Issue Verification & Retest (Please delete as appropriate)";
		}

		if(checkbutton1.Active){
			activtemp = @"Scripting & Planning ";
			if(checkbutton2.Active){
				activtemp = activtemp + @"/ Test Execution ";
				checkbutton2.Active = false;
			}
			if(checkbutton3.Active){
				activtemp = activtemp + @"/ Issue Verification & Retest ";
				checkbutton3.Active = false;
			}
		}

		if(checkbutton2.Active){
			activtemp = activtemp + @"Test Execution ";
			if(checkbutton3.Active){
				activtemp = activtemp + @"/ Issue Verification & Retest ";
				checkbutton3.Active = false;
			}
		}

		if(checkbutton3.Active)
			activtemp = activtemp + @"Issue Verification & Retest ";




		table.Cell(2,2).Select();
		//wordApplication.Selection.TypeText(@"Scripting & Planning/Test Execution/Issue Verification & Retest (Please delete as appropriate)");
		wordApplication.Selection.TypeText(activtemp);
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

		String bobone = wordApplication.Version;

		if(bobone == "14.0"){
			table.Style = "Light Shading - Accent 1";
			table.ApplyStyleFirstColumn = false;
		}else{
			table.Style = "List Table 6 Colorful - Accent 1";
			table.ApplyStyleFirstColumn = false;
		}

		table.Dispose();
		return;
	}

	public void fouthTable(){
		int r = 9;
		int c = 2;
		Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

		for(int x = 1; x < 10; x++){
			table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
		}

		table.Cell(1,1).Select();
		wordApplication.Selection.Font.Bold = 1;
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


		table.Cell(5,1).Select();
		wordApplication.Selection.TypeText(@"1");
		wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
		table.Cell(6,1).Select();
		wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
		wordApplication.Selection.TypeText(@"2");
		table.Cell(7,1).Select();
		wordApplication.Selection.TypeText(@"3");
		wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
		table.Cell(8,1).Select();
		wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
		wordApplication.Selection.TypeText(@"4");
		table.Cell(9,1).Select();
		wordApplication.Selection.TypeText(@"5");
		wordApplication.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

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

		String bobone = wordApplication.Version;

		if(bobone == "14.0"){
			table.Style = "Light Shading - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}else{
			table.Style = "List Table 6 Colorful - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}

		table.Dispose();
		return;
	}

	public void fithTable(){
		int r = 5;
		int c = 2;
		Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, r, c);

		for(int x = 1; x < 6; x++){
			table.Cell(x,1).SetWidth(160.00f, WdRulerStyle.wdAdjustFirstColumn);
		}

		table.Cell(1,1).Select();
		wordApplication.Selection.Font.Bold = 1;
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

		String bobone = wordApplication.Version;

		if(bobone == "14.0"){
			table.Style = "Light Shading - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}else{
			table.Style = "List Table 6 Colorful - Accent 1";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
		}

		table.Dispose();
		return;
	}



	protected void runRepeatDoc(){
		wordApplication = new Word.Application();
		wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
		newDocument = wordApplication.Documents.Add();

		Word.Table table = newDocument.Tables.Add(wordApplication.Selection.Range, 2, 1);

		table.Cell(1,1).Select();

		string mylongtextstring = (@"Title: 
A one sentence descriptive title for the issue

Description: 
A detailed description of the issue, including the failure and reasoning.

Steps to Recreate: 
Go to URL: " + txtURL + @"
Log in with valid details 

Environment:
Device - Device used during the testing
Operating System - The operating system used during the testing
Browser - The web browser used during the testing
Firmware - Firmware version of the device if relevant
Login Details for Account used - Add login details if applicable

Supporting material:
Add where appropriate screenshots, log files etc to aid detection of the issue and its correction.

Version:
" + txtURL + @"

Date:
" + DateTime.Now.ToString(@"dd/MM/yyyy") + @"

Severity:

");

		wordApplication.Selection.TypeText(mylongtextstring);

		wordApplication.Selection.MoveDown();
		wordApplication.Selection.MoveDown();
		wordApplication.Selection.TypeParagraph();

		Word.Table table2 = newDocument.Tables.Add(wordApplication.Selection.Range, 4, 1);
		table2.Cell(1,1).Select();
		string temp4s = (@"1. Blocking Issue/Crash 
2. Major Impact on Functionality
3. Minor Impact on Functionality
4. Cosmetic Issue/Typo
5. Feature Enhancement/Suggestion");
		wordApplication.Selection.TypeText(temp4s);
		table2.Cell(2,1).Select();
		temp4s = (@"Issue verified as fixed - " + DateTime.Now.ToString(@"dd/MM/yyyy") + @"
Version: " + txtURL);
		wordApplication.Selection.TypeText(temp4s);
		table2.Cell(3,1).Select();
		temp4s = (@"Issue verified as not fixed - " + DateTime.Now.ToString(@"dd/MM/yyyy") + @"
Version: " + txtURL);
		wordApplication.Selection.TypeText(temp4s);
		table2.Cell(4,1).Select();
		temp4s = (@"Closing issue based on above Comments - " + DateTime.Now.ToString(@"dd/MM/yyyy") + @"
Version: " + txtURL);
		wordApplication.Selection.TypeText(temp4s);

		String bobone = wordApplication.Version;

		if(bobone == "14.0"){
			table.Style = "Table Grid";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
			table2.Style = "Table Grid";
			table2.ApplyStyleFirstColumn = false;
			table2.ApplyStyleHeadingRows = false;
		}else{
			table.Style = "Table Grid";
			table.ApplyStyleFirstColumn = false;
			table.ApplyStyleHeadingRows = false;
			table2.Style = "Table Grid";
			table2.ApplyStyleFirstColumn = false;
			table2.ApplyStyleHeadingRows = false;
		}

		string documentFile = tempLocString;

		double wordVersion = Convert.ToDouble(wordApplication.Version, CultureInfo.InvariantCulture);
		if (wordVersion >= 12.0)
			newDocument.SaveAs(documentFile, WdSaveFormat.wdFormatDocumentDefault);
		else
			newDocument.SaveAs(documentFile);

		// close word and dispose reference
		wordApplication.Quit();
		wordApplication.Dispose();
	}

	#endregion

	public void getData(){
	}
}
