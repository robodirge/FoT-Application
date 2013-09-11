using System;
using System.IO;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public static bool enabledSection { get; set; }
	public static string baseLocation { get; set; }
	public static string baseLocation1 { get; set; }

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
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
		//Console.WriteLine(Environment.CurrentDirectory);
		baseLocation1 = Environment.CurrentDirectory + @"\Resources\Unrepeatable.docx";
		baseLocation = Environment.CurrentDirectory + @"\Resources\Client Name - Project Name Daily Report - DDMMYYYY.docx";
		
		//Get the user's path to desktop folder
		string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		//Supply a folder name to be created onto the desktop
		currentPath = currentPath + @"\FoT\";

		if(Directory.Exists(currentPath)){
			Console.WriteLine("Path already exists.");
			return;
		}else{
			DirectoryInfo di = Directory.CreateDirectory(currentPath);
		}
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButtonQuitClicked (object sender, EventArgs e){
		Gtk.Main.Quit (); // Quite main application
		throw new NotImplementedException ();
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

		//MessageDialog.
		MessageDialog myDialogWindow = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, halfDayResource);

		//Opens dialog
		//myDialogWindow.Run();
		//If the user has selected '2 projects'

		if(enabledSection==true){
			//Collect the data the user entered
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

			//MessageDialog.
			//MessageDialog myDialogWindow2 = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, FullDayResource);
			//myDialogWindow2.Run();
			//myDialogWindow2.Destroy();
		}

		//Will close dialog
		//myDialogWindow.Destroy();

		//Get the user's path to desktop folder
		string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

		string currentDate = DateTime.Now.ToString("yyyy_MMMMM");
		path = path + @"\FoT\" + currentDate + @"\";


		if(Directory.Exists(path)){
			//Console.WriteLine("Path already exists.");
		}else{

			DirectoryInfo di = Directory.CreateDirectory(path);
		}
		//Continue with folder set up
		FolderSetup(ref path, ref halfDayResource, ref FullDayResource,  e);
	} 

	protected void FolderSetup(ref string path, ref string halfDR,ref string fullDR, EventArgs e){
	
		string currentDate = DateTime.Now.ToString("yyyy_MM_dd");
		path = path + currentDate + @"\";

		if(Directory.Exists(path)){
			Console.WriteLine("Path already exists.");
		}else{
			DirectoryInfo di = Directory.CreateDirectory(path);
		}
		
		string pathClient1 = path;
		pathClient1 = pathClient1 + halfDR + @"\";

		if(Directory.Exists(pathClient1)){
			//Console.WriteLine("Path already exists.");
			//return;
		}else{

			//		baseLocation1 = Environment.CurrentDirectory + @"\Resources\Unrepeatable.docx";
			//		baseLocation = Environment.CurrentDirectory + @"\Resources\Client Name - Project Name Daily Report - DDMMYYYY.docx";

			//string pathClient1 = path;
			DirectoryInfo di = Directory.CreateDirectory(pathClient1);

			// Copy dayily report here
			string tempNameString = pathClient1 + @"Client Name - Project Name Daily Report - DDMMYYYY.docx";
			File.Copy(baseLocation, tempNameString);
			System.IO.File.Move(tempNameString, (pathClient1 + halfDR + @".docx"));

			//Create folder working docs
			DirectoryInfo wd = Directory.CreateDirectory((pathClient1 + @"Working_Docs\"));
			//Copy unrepeat doc in the folder just created
			string tempLocString = pathClient1 + @"Working_Docs\Unrepeatable.docx";
			File.Copy(baseLocation1, tempLocString);

			//Creae folder pics and sub folders
			pathClient1 = pathClient1 + @"Screenshots\";
			DirectoryInfo ss = Directory.CreateDirectory(pathClient1);
			//sub folders
			DirectoryInfo An = Directory.CreateDirectory((pathClient1 + @"Android\"));
			DirectoryInfo Bb = Directory.CreateDirectory((pathClient1 + @"BlackBerry\"));
			DirectoryInfo Dt = Directory.CreateDirectory((pathClient1 + @"Desktop\"));
			DirectoryInfo iO = Directory.CreateDirectory((pathClient1 + @"iOS\"));
			DirectoryInfo iOb1 = Directory.CreateDirectory((pathClient1 + @"iOS\Batch1\"));
			DirectoryInfo iOb2 = Directory.CreateDirectory((pathClient1 + @"iOS\Batch2\"));
			DirectoryInfo iOb3 = Directory.CreateDirectory((pathClient1 + @"iOS\Batch3\"));
			DirectoryInfo Wp = Directory.CreateDirectory((pathClient1 + @"WindowsPhone\"));

		}
		
		if(enabledSection==true){
			string pathClient2 = path;
			pathClient2 = pathClient2 + fullDR + @"\";

			if(Directory.Exists(pathClient2)){
				//Console.WriteLine("Path already exists.");
				//return;
			}else{
				DirectoryInfo di = Directory.CreateDirectory(pathClient2);

				// Copy dayily report here
				// Copy dayily report here
				string tempNameString = pathClient2 + @"Client Name - Project Name Daily Report - DDMMYYYY.docx";
				File.Copy(baseLocation, tempNameString);
				System.IO.File.Move(tempNameString, (pathClient2 + fullDR + @".docx"));

				//Create folder working docs
				DirectoryInfo wd = Directory.CreateDirectory((pathClient2 + @"Working_Docs\"));
				//Copy unrepeat doc in the folder just created
				string tempLocString = pathClient2 + @"Working_Docs\Unrepeatable.docx";
				File.Copy(baseLocation1, tempLocString);

				//Creae folder pics and sub folders
				pathClient2 = pathClient2 + @"Screenshots\";
				DirectoryInfo ss = Directory.CreateDirectory(pathClient2);

				//sub folders
				DirectoryInfo An = Directory.CreateDirectory((pathClient2 + @"Android\"));
				DirectoryInfo Bb = Directory.CreateDirectory((pathClient2 + @"BlackBerry\"));
				DirectoryInfo Dt = Directory.CreateDirectory((pathClient2 + @"Desktop\"));
				DirectoryInfo iO = Directory.CreateDirectory((pathClient2 + @"iOS\"));
				DirectoryInfo iOb1 = Directory.CreateDirectory((pathClient2 + @"iOS\Batch1\"));
				DirectoryInfo iOb2 = Directory.CreateDirectory((pathClient2 + @"iOS\Batch2\"));
				DirectoryInfo iOb3 = Directory.CreateDirectory((pathClient2 + @"iOS\Batch3\"));
				DirectoryInfo Wp = Directory.CreateDirectory((pathClient2 + @"WindowsPhone\"));
			}
		}

		//MessageDialog.
		MessageDialog myDialogWindow2 = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Folders created");
		myDialogWindow2.Run();
		myDialogWindow2.Destroy();
	}

	protected void OnRadioResource2Toggled (object sender, EventArgs e)
	{
		//Change the display status of the below objects
		//visable - on / off - disabled
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
