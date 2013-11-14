using System;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{
		//Gtk.TreeStore musicList;
		Gtk.ListStore enviroList;
		Gtk.CellRendererToggle myToggle;

		public EnvironmentChooser () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			int tbool = 0;
			int stext1 = 1;
			int stext2 = 2;

			enviroList = new Gtk.ListStore(typeof(bool), typeof (string), typeof (string));

			/*
			Gtk.TreeIter iter = musicList.AppendValues("dance");
			musicList.AppendValues(iter, "Entry 1", "Version 1");
			musicList.AppendValues(iter, "Entry 2", "Version 2");
			iter = musicList.AppendValues ("hip-hop");
			musicList.AppendValues(iter, "Entry 3", "Version 3");
			*/
			//enviroList.Append(false, "Phone1", "V2.0");
			enviroList.AppendValues(false, "Phone1", "V2.0");
			enviroList.AppendValues(false, "Phone2", "V2.0");
			enviroList.AppendValues(false, "Phone3", "V2.0");

			//EnviroTree.Model = enviroList;
			EnviroTree.Model = enviroList;

			myToggle = new Gtk.CellRendererToggle();
			myToggle.Activatable = true;
			myToggle.Toggled += myToggle_toggled;
			Gtk.TreeViewColumn column_toggle = new Gtk.TreeViewColumn("Toggle", myToggle, tbool);
			EnviroTree.AppendColumn(column_toggle);
		
			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn artistCol = new Gtk.TreeViewColumn("Name", artistNameCell, stext1);
			EnviroTree.AppendColumn(artistCol);

			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn songCol = new Gtk.TreeViewColumn("Version", songNameCell, stext2);
			EnviroTree.AppendColumn(songCol);

			column_toggle.AddAttribute(myToggle, "active", 0);
			artistCol.AddAttribute(artistNameCell, "text", 1);
			songCol.AddAttribute(songNameCell, "text", 2);


			EnviroTree.Model = enviroList;

			//ShowAll();

		}
	
		protected void myToggle_toggled (object o, ToggledArgs args)
		{
			Console.WriteLine("muahahah");

			TreeIter iter;

			if(enviroList.GetIter(out iter, new TreePath(args.Path))){
				bool old = (bool) enviroList.GetValue(iter, 0);
				enviroList.SetValue(iter, 0, !old);
				//enviroList.SetValue(iter, 0, !myToggle.Active);
			}

		}
	}
}

