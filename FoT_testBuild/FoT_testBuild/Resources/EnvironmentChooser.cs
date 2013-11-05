using System;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{

		public EnvironmentChooser () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
	
			Gtk.TreeViewColumn artistCol = new Gtk.TreeViewColumn();
			artistCol.Title = "Artist";
			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			artistCol.PackStart (artistNameCell, true);

			Gtk.TreeViewColumn songCol = new Gtk.TreeViewColumn();
			songCol.Title = "Song";
			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			songCol.PackStart (songNameCell, true);

			EnviroTree.AppendColumn(artistCol);
			EnviroTree.AppendColumn(songCol);

			artistCol.AddAttribute(artistNameCell, "text", 0);
			songCol.AddAttribute(songNameCell, "text", 1);

			//Gtk.ListStore musicList = new Gtk.ListStore(typeof (string), typeof (string));
			Gtk.TreeStore musicList = new Gtk.TreeStore(typeof (string), typeof (string));

			Gtk.TreeIter iter = musicList.AppendValues("dance");
			musicList.AppendValues(iter, "sdfg", "asdfghjhgfdfgfdfgfdfedfdf");

			iter = musicList.AppendValues ("hip-hop");
			musicList.AppendValues(iter, "nelly", "afasv asv wsr w");

			EnviroTree.Model = musicList;

			ShowAll();

		}
	
	}
}

