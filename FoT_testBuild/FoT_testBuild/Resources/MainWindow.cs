/*
 * Copyright Zoonou, for internal use only
 * Developed and Maintained by Ben Vere
 * Any queries and or problems please contact me @ ben.vere@zoonou.com / 07596869638
 * Last updated (header) 13/09/2013
*/

using System;
using System.IO;
using Gtk;

public partial class MainWindow: Gtk.Window{	
	public static bool enabledSection { get; set; }
	public static string baseLocation { get; set; }
	public static string baseLocation1 { get; set; }
	public static string currentPath {get; set; }

	public MainWindow (): base (Gtk.WindowType.Toplevel){
		Build ();
		onStartActions ();
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
		//---------------------------------------
		string configLocation = Environment.CurrentDirectory + @"\Resources\Config.txt";
		try{
			using(StreamReader sr = new StreamReader(configLocation)){
				string line = sr.ReadToEnd();
				Console.WriteLine(line);

				if(line == "Default"){
					//---------------------------------------
					//Console.WriteLine(Environment.CurrentDirectory);
					baseLocation1 = Environment.CurrentDirectory + @"\Resources\Unrepeatable.docx";
					baseLocation = Environment.CurrentDirectory + @"\Resources\Client Name - Project Name Daily Report - DDMMYYYY.docx";

					//Get the user's path to desktop folder
					currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					//Supply a folder name to be created onto the desktop
					currentPath = currentPath + @"\FoT\";

					if(Directory.Exists(currentPath)){
						return;
					}else{
						DirectoryInfo di = Directory.CreateDirectory(currentPath);
					}
				}else{
					//--------------------------------------- // C:\Users\Ben\Desktop
					//Console.WriteLine(Environment.CurrentDirectory);
					baseLocation1 = Environment.CurrentDirectory + @"\Resources\Unrepeatable.docx";
					baseLocation = Environment.CurrentDirectory + @"\Resources\Client Name - Project Name Daily Report - DDMMYYYY.docx";

					//Get the user's path to desktop folder
					currentPath = line;
					//Supply a folder name to be created onto the desktop
					currentPath = currentPath + @"\FoT\";

					if(Directory.Exists(currentPath)){
						return;
					}else{
						DirectoryInfo di = Directory.CreateDirectory(currentPath);
					}

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

	protected void OnButtonContinueClicked (object sender, EventArgs e){
		//Collect the data the user entered
		string clientName1 = entry1.Text;
		string projectName1 = entry2.Text;

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

		if(enabledSection==true){
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
		}

		//Get the user's path to desktop folder
		//string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		string currentDate = DateTime.Now.ToString("yyyy_MMMMM");
		currentPath = currentPath + @"\FoT\" + currentDate + @"\";

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

		if(enabledSection==true){
			string pathClient2 = path;
			pathClient2 = pathClient2 + fullDR + @"\";

			if(!Directory.Exists(pathClient2)){
				DirectoryInfo di = Directory.CreateDirectory(pathClient2);

				// Copy dayily report here
				// Copy dayily report here
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
		}

		//MessageDialog.
		/*MessageDialog myDialogWindow2 = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Folders created");
			myDialogWindow2.Run();
			myDialogWindow2.Destroy();*/
		Application.Quit ();
	}

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
}
