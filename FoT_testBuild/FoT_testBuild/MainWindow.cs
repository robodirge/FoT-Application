using System;
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
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButtonQuitClicked (object sender, EventArgs e)
	{
		Gtk.Main.Quit (); // Quite main application
		throw new NotImplementedException ();
	}

	protected void OnButtonContinueClicked (object sender, EventArgs e)
	{

		string clientName1 = entry1.Text;
		string projectName1 = entry2.Text;

		if(clientName1 == ""){
			clientName1 = "Client";
		}

		if(projectName1 == ""){
			projectName1 = "Project";
		}

		string halfDayResource = clientName1 + "_" + projectName1;

		//MessageDialog.
		MessageDialog myDialogWindow = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, halfDayResource);
		//Opens dialog
		myDialogWindow.Run();
		//Only one option 'close' - Will close dialog
		myDialogWindow.Destroy();
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
