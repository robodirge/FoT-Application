
// This file has been generated by the GUI designer. Do not modify.
namespace FoT
{
	public partial class EnvironmentChooser
	{
		private global::Gtk.HBox hbox26;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView EnviroTree;
		private global::Gtk.VBox vbox14;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget FoT.EnvironmentChooser
			this.WidthRequest = 700;
			this.Name = "FoT.EnvironmentChooser";
			this.Title = global::Mono.Unix.Catalog.GetString ("EnvironmentChooser");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child FoT.EnvironmentChooser.Gtk.Container+ContainerChild
			this.hbox26 = new global::Gtk.HBox ();
			this.hbox26.Name = "hbox26";
			this.hbox26.Spacing = 6;
			// Container child hbox26.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.EnviroTree = new global::Gtk.TreeView ();
			this.EnviroTree.CanFocus = true;
			this.EnviroTree.Name = "EnviroTree";
			this.EnviroTree.EnableSearch = false;
			this.EnviroTree.RulesHint = true;
			this.GtkScrolledWindow.Add (this.EnviroTree);
			this.hbox26.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox26 [this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child hbox26.Gtk.Box+BoxChild
			this.vbox14 = new global::Gtk.VBox ();
			this.vbox14.Name = "vbox14";
			this.vbox14.Spacing = 6;
			this.hbox26.Add (this.vbox14);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox26 [this.vbox14]));
			w3.Position = 1;
			this.Add (this.hbox26);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 1068;
			this.DefaultHeight = 695;
			this.Show ();
		}
	}
}
