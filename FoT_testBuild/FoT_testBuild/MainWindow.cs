using System;
using System.IO;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public static bool enabledSection { get; set; }

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

		//Get the user's path to desktop folder
		string currentPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		//Supply a folder name to be created onto the desktop
		currentPath = currentPath + @"\FoT\";

		try{

			if(Directory.Exists(currentPath)){
				Console.WriteLine("Path already exists.");
				return;
			}

			DirectoryInfo di = Directory.CreateDirectory(currentPath);
			Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(currentPath));
		}
		catch{
			Console.WriteLine("Some error happened");
			//Console.WriteLine("The process failed: {0}", e.ToString());
		}

		/*var dirsx = AppDomain.CurrentDomain.BaseDirectory;
		Console.WriteLine(dirsx);

		string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
		UriBuilder uri = new UriBuilder(codeBase);
		string path = Uri.UnescapeDataString(uri.Path);
		Console.WriteLine(path);*/
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
		myDialogWindow.Run();
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

			//Combine two strings with ' - ' seperator 
			FullDayResource = clientName2 + " - " + projectName2;

			//MessageDialog.
			MessageDialog myDialogWindow2 = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, FullDayResource);

			//Opens dialog
			myDialogWindow2.Run();
			//Will close dialog
			myDialogWindow2.Destroy();
		}

		//Will close dialog
		myDialogWindow.Destroy();

		//Get the user's path to desktop folder
		string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		//Supply a folder name to be created onto the desktop
		//FoT
		//	YYYY_Month
		string currentDate = DateTime.Now.ToString("yyyy_MMMMM");
		path = path + @"\FoT\" + currentDate + @"\";


		if(Directory.Exists(path)){
			Console.WriteLine("Path already exists.");
			//return;
		}else{

			DirectoryInfo di = Directory.CreateDirectory(path);
			Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
		}
		
		//Continue with folder set up
		FolderSetup(ref path, ref halfDayResource, ref FullDayResource,  e);
	} 

	protected void FolderSetup(ref string path, ref string halfDR,ref string fullDR, EventArgs e){

		string currentDate = DateTime.Now.ToString("yyyy_MM_dd");
		path = path + currentDate + @"\";

		if(Directory.Exists(path)){
			Console.WriteLine("Path already exists.");
			//return;
		}else{
			DirectoryInfo di = Directory.CreateDirectory(path);
			Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
		}
		
		string pathClient1 = path;
		pathClient1 = pathClient1 + halfDR + @"\";

		if(Directory.Exists(pathClient1)){
			Console.WriteLine("Path already exists.");
				//return;
		}else{
			//string pathClient1 = path;
			DirectoryInfo di = Directory.CreateDirectory(pathClient1);

			// Copy dayily report here
			//...
			//Create folder working docs
			DirectoryInfo wd = Directory.CreateDirectory((pathClient1 + @"Working_Docs\"));
			//Copy unrepeat doc in the folder just created
			//...

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
				Console.WriteLine("Path already exists.");
				//return;
			}else{
				DirectoryInfo di = Directory.CreateDirectory(pathClient2);
				// Copy dayily report here
				//...

				//Create folder working docs
				DirectoryInfo wd = Directory.CreateDirectory((pathClient2 + @"Working_Docs\"));
				//Copy unrepeat doc in the folder just created
				//...

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
