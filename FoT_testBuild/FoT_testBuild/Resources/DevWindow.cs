using System;

namespace FoT
{
	public partial class DevWindow : Gtk.Window
	{
		public DevWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			CanDefault = true;
		}
	}
}

