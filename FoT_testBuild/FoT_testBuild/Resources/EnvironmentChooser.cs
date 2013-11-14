using System;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{
		Gtk.TreeStore musicList;
		Gtk.CellRendererToggle myToggle;

		public EnvironmentChooser () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			int tbool = 0;
			int stext1 = 1;
			int stext2 = 2;
			int stext3 = 3;

			musicList = new Gtk.TreeStore(typeof(bool), typeof (string), typeof (string), typeof (string), typeof (int));

			Gtk.TreeIter iter = musicList.AppendValues(false, "Mobile", "", "", 0);
			musicList.AppendValues(iter, false, "iOS", "Entry 1", "Version 1", 1);
			musicList.AppendValues(iter, false, "And", "Entry 2", "Version 2", 2);
			iter = musicList.AppendValues(false, "Desktop", "", "", 3);
			musicList.AppendValues(iter, false, "Win7", "Entry 3", "Version 3", 4);

			EnviroTree.Model = musicList;

			myToggle = new Gtk.CellRendererToggle();
			myToggle.Activatable = true;
			myToggle.Toggled += myToggle_toggled;
			Gtk.TreeViewColumn column_toggle = new Gtk.TreeViewColumn("Toggle", myToggle, tbool);
			EnviroTree.AppendColumn(column_toggle);

			Gtk.CellRendererText SubGroup = new Gtk.CellRendererText();
			Gtk.TreeViewColumn subGRPCol = new Gtk.TreeViewColumn("Type", SubGroup, stext1);
			EnviroTree.AppendColumn(subGRPCol);

			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn songCol = new Gtk.TreeViewColumn("Version", songNameCell, stext2);
			EnviroTree.AppendColumn(songCol);
		
			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn artistCol = new Gtk.TreeViewColumn("Name", artistNameCell, stext3);
			EnviroTree.AppendColumn(artistCol);

			column_toggle.AddAttribute(myToggle, "active", 0);
			subGRPCol.AddAttribute(SubGroup, "text", 1);
			artistCol.AddAttribute(artistNameCell, "text", 2);
			songCol.AddAttribute(songNameCell, "text", 3);

			EnviroTree.Model = musicList;
		}
	
		protected void myToggle_toggled (object o, ToggledArgs args)
		{
			TreeIter iter;
			if(musicList.GetIter(out iter, new TreePath(args.Path))){
				bool old = (bool) musicList.GetValue(iter, 0);
				musicList.SetValue(iter, 0, !old);
				/*
				if(old == true)
					Console.WriteLine("Off");
				else if(old == false)
					Console.WriteLine("On");
				*/

				int test = (int) musicList.GetValue(iter, 4);

				if(test == 0){
					//select entire coll
					for(int x = 0; x < 3; x++){

					}
					//else
				}
			}

		}
	}
}

