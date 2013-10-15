using System;
using Gtk;

namespace FoT
{
	public partial class EnviroChooser2 : Gtk.Window
	{
		public EnviroChooser2 () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void OnDesktopActionActivated (object sender, EventArgs e)
		{
			throw new NotImplementedException ();
		}
	}
}

