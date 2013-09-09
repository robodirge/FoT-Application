using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public static bool enabledSection { get; set; }

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		enabledSection = false;
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
		// temp solution until 'continue' is implemented
		Gtk.Main.Quit (); // Quite main application

		throw new NotImplementedException ();
	}


	protected void OnRadioResource2Toggled (object sender, EventArgs e)
	{
		if (enabledSection == false) {
			labelClient2.Visible = true;
			labelProject2.Visible = true;
			entry3.Visible = true;
			enabledSection = true;
		} else {
			labelClient2.Visible = false;
			labelProject2.Visible = false;
			entry4.Visible = false;
			enabledSection = false;
		}
	}

}
