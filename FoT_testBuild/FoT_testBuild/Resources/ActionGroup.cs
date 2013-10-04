using System;

namespace FoT
{
	public partial class ActionGroup : Gtk.ActionGroup
	{
		public ActionGroup () : 
				base("FoT.ActionGroup")
		{
			this.Build ();
		}
	}
}

