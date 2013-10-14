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
			OnStartActions();
		}

		protected void OnCombobox2Changed (object sender, EventArgs e){
			combostartactions();
			combobox4.Visible = true;
			onToggleactions(true);
			//combobox4.AppendText("sdvgsfvssvsv");
			if(combobox2.ActiveText == @"Desktop"){
				radiobutton6.Label = @"Windows 7 Pro SP1 - IE9";
				radiobutton7.Label = @"Windows 7 Pro SP1 - Chrome (latest)";
				radiobutton11.Label = @"Windows 7 Pro SP1 - Firefox (latest)";
				radiobutton12.Label = @"MacBook Pro OSX 10.8 - Safari (latest)";
				radiobutton15.Label = @"MacBook Pro OSX 10.8 - Chrome (latest)";
				radiobutton16.Label = @"MacBook Pro OSX 10.8 - Firefox (latest)";
				radiobutton8.Label = @"Windows 8 - IE10";
				radiobutton9.Label = @"Windows 8 - Chrome (latest)";
				radiobutton10.Label = @"Windows 8 - Firefox (latest)";
				radiobutton13.Label = @"Windows XP Pro SP2 - IE8";
				radiobutton14.Label = @"Windows XP Pro SP2 - Chrome (latest)";
				radiobutton17.Label = @"Windows XP Pro SP2 - Firefox (latest)";

				combobox4.AppendText(@"Windows");
				combobox4.AppendText(@"OSX");
				combobox4.AppendText(@"Other");
			}
			if(combobox2.ActiveText == @"Device"){
				radiobutton8.Label = @"iPhone 5c - 7.0.1 - Native Browser";
				radiobutton9.Label = @"iPhone 4s - 5.1.1 - Native Browser";
				radiobutton10.Label = @"iPad 4 3g - 6.1.2 - Native Browser";
				radiobutton13.Label = @"Samsung Nexus 10 - 4.2 - Native Browser";
				radiobutton14.Label = @"Samsung Galaxy S4 - 4.2.2 - Native Browser";
				radiobutton17.Label = @"Samsung Galaxy Nexus - 4.0.1 - Native Browser";
				radiobutton6.Label = @"Acer Nexus 7 - 4.1 - Native Browser";
				radiobutton7.Label = @"Samsung Galaxy TAB 2 10.1 - 4.0.4 - Native Browser";
				radiobutton11.Label = @"HTC Desire C - 4.0.3 - Native Browser";
				radiobutton12.Label = @"HTC Google Nexus One - 2.3.6 - Native Browser";
				radiobutton15.Label = @"Nokia Lumia 820 - Windows 8.0 - Native Browser";
				radiobutton16.Label = @"Blackberry 9320 Curve - 7.1.0.398 - Native Browser";

				combobox4.AppendText(@"Android");
				combobox4.AppendText(@"iOS");
				combobox4.AppendText(@"Windows / BB");
			}
		}

		public void combostartactions(){
			if(combobox4.Visible == false)
				return;
			else{
				int testVal = combobox4.Model.IterNChildren();
				for(int n = 0; n < testVal; n++){
					combobox4.RemoveText(0);
				}
			}
		}

		public void combo3startactions(){
			if(combobox3.Visible == false)
				return;
			else{
				int testVal = combobox3.Model.IterNChildren();
				for(int n = 0; n < testVal; n++){
					combobox3.RemoveText(0);
				}
			}
		}

		public void OnStartActions(){
			combobox2.AppendText(@"Desktop");
			combobox2.AppendText(@"Device");
		
			combobox4.Visible = false;
			combobox3.Visible = false;

			radiobutton6.Label = @"Windows 7 Pro SP1 - IE9";
			radiobutton7.Label = @"Windows 7 Pro SP1 - Chrome (latest)";
			radiobutton11.Label = @"Windows 7 Pro SP1 - Firefox (latest)";
			radiobutton12.Label = @"OSX 10.8 - Safari (latest)";
			radiobutton15.Label = @"OSX 10.8 - Chrome (latest)";
			radiobutton16.Label = @"OSX 10.8 - Firefox (latest)";

			radiobutton8.Label = @"iPhone 5c - 7.0 - Native Browser";
			radiobutton9.Label = @"iPhone 4s - 5.1.1 - Native Browser";
			radiobutton10.Label = @"iPad 4 3g - 6.1.2 - Native Browser";
			radiobutton13.Label = @"Samsung Nexus 10 - 4.2 - Native Browser";
			radiobutton14.Label = @"Samsung Galaxy S4 - 4.2.2 - Native Browser";
			radiobutton17.Label = @"Samsung Galaxy Nexus - 4.0.1 - Native Browser";
		}

		protected void OnCombobox4Changed (object sender, EventArgs e){
			if(combobox4.ActiveText == @"Windows"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				radiobutton6.Label = @"Windows 7 Pro SP1 - IE9";
				radiobutton7.Label = @"Windows 7 Pro SP1 - Chrome (latest)";
				radiobutton11.Label = @"Windows 7 Pro SP1 - Firefox (latest)";
				radiobutton12.Label = @"Windows Vista Ult - IE8";
				radiobutton15.Label = @"Windows Vista Ult - Chrome (latest)";
				radiobutton16.Label = @"Windows Vista Ult - Firefox (latest)";
				radiobutton8.Label = @"Windows 8 - IE10";
				radiobutton9.Label = @"Windows 8 - Chrome (latest)";
				radiobutton10.Label = @"Windows 8 - Firefox (latest)";
				radiobutton13.Label = @"Windows XP Pro SP2 - IE8";
				radiobutton14.Label = @"Windows XP Pro SP2 - Chrome (latest)";
				radiobutton17.Label = @"Windows XP Pro SP2 - Firefox (latest)";

				combobox3.AppendText(@"XP");
				combobox3.AppendText(@"Vista");
				combobox3.AppendText(@"Win 7");
				combobox3.AppendText(@"Win 8");

			}
			if(combobox4.ActiveText == @"OSX"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				radiobutton6.Label = @"OSX 10.8 ML- Safari (latest)";
				radiobutton7.Label = @"OSX 10.8 ML- Chrome (latest)";
				radiobutton11.Label = @"OSX 10.8 ML - Firefox (latest)";
				radiobutton12.Label = @"OSX 10.7 Lion - Safari (latest)";
				radiobutton15.Label = @"OSX 10.7 Lion - Chrome (latest)";
				radiobutton16.Label = @"SX 10.7 Lion - Firefox (latest)";
				radiobutton8.Label = @"OSX 10.6 SL - Safari (latest)";
				radiobutton9.Label = @"OSX 10.6 SL - Chrome (latest)";
				radiobutton10.Label = @"OSX 10.6 SL - Firefox (latest)";
				radiobutton13.Label = @"OSX 10.5 Leopard - Safari (latest)";
				radiobutton14.Label = @"OSX 10.5 Leopard - Chrome (latest)";
				radiobutton17.Label = @"OSX 10.5 Leopard - Firefox (latest)";

				combobox3.AppendText(@"Leopard (10.5)");
				combobox3.AppendText(@"Snow Leopard (10.6)");
				combobox3.AppendText(@"Lion (10.7)");
				combobox3.AppendText(@"Moutain Lion (10.8)");
			}
			if(combobox4.ActiveText == @"Other"){
				combo3startactions();
				combobox3.Visible = false;

				radiobutton6.Label = @"Chrome Book - Google Chrome - Chrome (latest)";
				radiobutton7.Label = @"Ubuntu 12.04 LTS (Precise Pangolin) - Chrome (latest)";
				radiobutton11.Label = @"Ubuntu 12.04 LTS (Precise Pangolin) - Firefox (latest)";
				radiobutton12.Label = @"Ubuntu 12.04 LTS (Precise Pangolin) - Other";
				radiobutton15.Visible = false;
				radiobutton16.Visible = false;
				radiobutton8.Visible = false;
				radiobutton9.Visible = false;
				radiobutton10.Visible = false;
				radiobutton13.Visible = false;
				radiobutton14.Visible = false;
				radiobutton17.Visible = false;
			}

			if(combobox4.ActiveText == @"Android"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				radiobutton6.Label = @"Samsung Galaxy S2 - 2.3.3 - Native Browser";
				radiobutton7.Label = @"Samsung Galaxy S3 - 4.0.4 - Native Browser";
				radiobutton11.Label = @"Samsung Galaxy S4 - 4.2.2 - Native Browser";
				radiobutton12.Label = @"Samsung Galaxy TAB 10.1 - 3.1 - Native Browser";
				radiobutton15.Label = @"Samsung Galaxy TAB 2 10.1 - 4.0.4 - Native Browser";
				radiobutton16.Label = @"Samsung Galaxy TAB 2 7.0 - 4.1.2 - Native Browser";
				radiobutton8.Label = @"Acer Iconia TAB B1-710 - 4.1.2 - Native Browser";
				radiobutton9.Label = @"Acer Nexus 7 3G - 4.1 - Native Browser";
				radiobutton10.Label = @"Dell Streak 7 - 3.2 - Native Browser";
				radiobutton13.Label = @"HTC Google Nexus One - 2.3.6 - Native Browser";
				radiobutton14.Label = @"HTC Sensation XE - 4.0.3 - Native Browser";
				radiobutton17.Label = @"LG Nexus 4 E960 - 4.2.1 - Native Browser";

				combobox3.AppendText(@"Android Version 2");
				combobox3.AppendText(@"Android Version 3");
				combobox3.AppendText(@"Android Version 4");
				combobox3.AppendText(@"HTC");
				combobox3.AppendText(@"Samsung");
				combobox3.AppendText(@"Other");
				//radiobutton10.Label = @"Kindle Fire HD - Android 4.0 (Kindle: 7.2.1) - Native Browser";
			}
			if(combobox4.ActiveText == @"iOS"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				radiobutton6.Label = @"iPad 4 3g - 6.1.2 - Native Browser";
				radiobutton7.Label = @"iPad 3 3g - 6.0.1 - Native Browser";
				radiobutton11.Label = @"iPad 2 3g - 7.0.2 - Native Browser";
				radiobutton12.Label = @"iPhone 5s - 7.0.1 - Native Browser";
				radiobutton15.Label = @"iPhone 5c - 7.0 - Native Browser";
				radiobutton16.Label = @"iPhone 5 - 7.0.2 - Native Browser";
				radiobutton8.Label = @"iPhone 5 - 6.1.4 - Native Browser";
				radiobutton9.Label = @"iPhone 4s - 7.0 - Native Browser";
				radiobutton10.Label = @"iPhone 4s - 5.1.1 - Native Browser";
				radiobutton13.Label = @"iPhone 4 - 6.1.3 - Native Browser";
				radiobutton14.Label = @"iPhone 3GS - 6.0 - Native Browser";
				radiobutton17.Label = @"iPhone 3G - 4.2.1 - Native Browser";

				combobox3.AppendText(@"iPad");
				combobox3.AppendText(@"iPhone 3/s");
				combobox3.AppendText(@"iPhone 4/s");
				combobox3.AppendText(@"iPhone 5/s");
				combobox3.AppendText(@"iPods");
			}
			if(combobox4.ActiveText == @"Windows / BB"){
				combo3startactions();
				combobox3.Visible = false;

				radiobutton6.Label = @"HTC 7 Pro - 7.10.8773.98 - Native Browser";
				radiobutton7.Label = @"HTC Windows Phone 8x - 8.0.10211.204 - Native Browser";
				radiobutton11.Label = @"Microsoft Surface - RT 32-bit (6.2) - Native Browser";
				radiobutton12.Label = @"Nokia Lumia 720 - 8.0 - Native Browser";
				radiobutton15.Label = @"Nokia Lumia 820 - 8.0 - Native Browser";
				radiobutton16.Label = @"Nokia Lumia 900 - 7.10.8773.98 - Native Browser";
				radiobutton8.Label = @"Blackberry 9300 Curve - 6.6.0.233 - Native Browser";
				radiobutton9.Label = @"Blackberry 9320 Curve - 7.1.0.398 - Native Browser";
				radiobutton10.Visible = false;
				radiobutton13.Visible = false;
				radiobutton14.Visible = false;
				radiobutton17.Visible = false;
			}
		}

		public void onToggleactions(bool toggleval){
			if(toggleval == false){
				radiobutton6.Visible = false;
				radiobutton7.Visible = false;
				radiobutton11.Visible = false;
				radiobutton12.Visible = false;
				radiobutton15.Visible = false;
				radiobutton16.Visible = false;
				radiobutton8.Visible = false;
				radiobutton9.Visible = false;
				radiobutton10.Visible = false;
				radiobutton13.Visible = false;
				radiobutton14.Visible = false;
				radiobutton17.Visible = false;
			}else{
				radiobutton6.Visible = true;
				radiobutton7.Visible = true;
				radiobutton11.Visible = true;
				radiobutton12.Visible = true;
				radiobutton15.Visible = true;
				radiobutton16.Visible = true;
				radiobutton8.Visible = true;
				radiobutton9.Visible = true;
				radiobutton10.Visible = true;
				radiobutton13.Visible = true;
				radiobutton14.Visible = true;
				radiobutton17.Visible = true;
			}
		}
	}
}

