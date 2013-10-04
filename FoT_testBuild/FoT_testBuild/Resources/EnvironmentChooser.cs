using System;

namespace FoT
{
	public partial class EnvironmentChooser : Gtk.Window
	{
		public EnvironmentChooser () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			combobox2.AppendText("avfshgvjhvsujh");
		}

		protected void OnCombobox2Changed (object sender, EventArgs e)
		{
			combobox4.AppendText("sdvgsfvssvsv");
		}
	}
}

