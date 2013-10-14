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
				checkbutton1.Label = @"Windows 7 Pro SP1 - IE9";
				checkbutton2.Label = @"Windows 7 Pro SP1 - Chrome (latest)";
				checkbutton3.Label = @"Windows 7 Pro SP1 - Firefox (latest)";
				checkbutton4.Label = @"MacBook Pro OSX 10.8 - Safari (latest)";
				checkbutton5.Label = @"MacBook Pro OSX 10.8 - Chrome (latest)";
				checkbutton6.Label = @"MacBook Pro OSX 10.8 - Firefox (latest)";
				checkbutton7.Label = @"Windows 8 - IE10";
				checkbutton8.Label = @"Windows 8 - Chrome (latest)";
				checkbutton9.Label = @"Windows 8 - Firefox (latest)";
				checkbutton10.Label = @"Windows XP Pro SP2 - IE8";
				checkbutton11.Label = @"Windows XP Pro SP2 - Chrome (latest)";
				checkbutton12.Label = @"Windows XP Pro SP2 - Firefox (latest)";

				combobox4.AppendText(@"Windows");
				combobox4.AppendText(@"OSX");
				combobox4.AppendText(@"Other");
			}
			if(combobox2.ActiveText == @"Device"){
				checkbutton1.Label = @"iPhone 5c - 7.0.1 - Native Browser";
				checkbutton2.Label = @"iPhone 4s - 5.1.1 - Native Browser";
				checkbutton3.Label = @"iPad 4 3g - 6.1.2 - Native Browser";
				checkbutton4.Label = @"Samsung Nexus 10 - 4.2 - Native Browser";
				checkbutton5.Label = @"Samsung Galaxy S4 - 4.2.2 - Native Browser";
				checkbutton6.Label = @"Samsung Galaxy Nexus - 4.0.1 - Native Browser";
				checkbutton7.Label = @"Acer Nexus 7 - 4.1 - Native Browser";
				checkbutton8.Label = @"Samsung Galaxy TAB 2 10.1 - 4.0.4 - Native Browser";
				checkbutton9.Label = @"HTC Desire C - 4.0.3 - Native Browser";
				checkbutton10.Label = @"HTC Google Nexus One - 2.3.6 - Native Browser";
				checkbutton11.Label = @"Nokia Lumia 820 - Windows 8.0 - Native Browser";
				checkbutton12.Label = @"Blackberry 9320 Curve - 7.1.0.398 - Native Browser";

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

			checkbutton1.Label = @"Windows 7 Pro SP1 - IE9";
			checkbutton2.Label = @"Windows 7 Pro SP1 - Chrome (latest)";
			checkbutton3.Label = @"Windows 7 Pro SP1 - Firefox (latest)";
			checkbutton4.Label = @"OSX 10.8 - Safari (latest)";
			checkbutton5.Label = @"OSX 10.8 - Chrome (latest)";
			checkbutton6.Label = @"OSX 10.8 - Firefox (latest)";
			checkbutton7.Label = @"iPhone 5c - 7.0 - Native Browser";
			checkbutton8.Label = @"iPhone 4s - 5.1.1 - Native Browser";
			checkbutton9.Label = @"iPad 4 3g - 6.1.2 - Native Browser";
			checkbutton10.Label = @"Samsung Nexus 10 - 4.2 - Native Browser";
			checkbutton11.Label = @"Samsung Galaxy S4 - 4.2.2 - Native Browser";
			checkbutton12.Label = @"Samsung Galaxy Nexus - 4.0.1 - Native Browser";
		}

		protected void OnCombobox4Changed (object sender, EventArgs e){
			if(combobox4.ActiveText == @"Windows"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				checkbutton1.Label = @"Windows 7 Pro SP1 - IE9";
				checkbutton2.Label = @"Windows 7 Pro SP1 - Chrome (latest)";
				checkbutton3.Label = @"Windows 7 Pro SP1 - Firefox (latest)";
				checkbutton4.Label = @"Windows Vista Ult - IE8";
				checkbutton5.Label = @"Windows Vista Ult - Chrome (latest)";
				checkbutton6.Label = @"Windows Vista Ult - Firefox (latest)";
				checkbutton7.Label = @"Windows 8 - IE10";
				checkbutton8.Label = @"Windows 8 - Chrome (latest)";
				checkbutton9.Label = @"Windows 8 - Firefox (latest)";
				checkbutton10.Label = @"Windows XP Pro SP2 - IE8";
				checkbutton11.Label = @"Windows XP Pro SP2 - Chrome (latest)";
				checkbutton12.Label = @"Windows XP Pro SP2 - Firefox (latest)";

				combobox3.AppendText(@"XP");
				combobox3.AppendText(@"Vista");
				combobox3.AppendText(@"Win 7");
				combobox3.AppendText(@"Win 8");

			}
			if(combobox4.ActiveText == @"OSX"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				checkbutton1.Label = @"OSX 10.8 ML- Safari (latest)";
				checkbutton2.Label = @"OSX 10.8 ML- Chrome (latest)";
				checkbutton3.Label = @"OSX 10.8 ML - Firefox (latest)";
				checkbutton4.Label = @"OSX 10.7 Lion - Safari (latest)";
				checkbutton5.Label = @"OSX 10.7 Lion - Chrome (latest)";
				checkbutton6.Label = @"SX 10.7 Lion - Firefox (latest)";
				checkbutton7.Label = @"OSX 10.6 SL - Safari (latest)";
				checkbutton8.Label = @"OSX 10.6 SL - Chrome (latest)";
				checkbutton9.Label = @"OSX 10.6 SL - Firefox (latest)";
				checkbutton10.Label = @"OSX 10.5 Leopard - Safari (latest)";
				checkbutton11.Label = @"OSX 10.5 Leopard - Chrome (latest)";
				checkbutton12.Label = @"OSX 10.5 Leopard - Firefox (latest)";

				combobox3.AppendText(@"Leopard (10.5)");
				combobox3.AppendText(@"Snow Leopard (10.6)");
				combobox3.AppendText(@"Lion (10.7)");
				combobox3.AppendText(@"Moutain Lion (10.8)");
			}
			if(combobox4.ActiveText == @"Other"){
				combo3startactions();
				combobox3.Visible = false;

				checkbutton1.Label = @"Chrome Book - Google Chrome - Chrome (latest)";
				checkbutton2.Label = @"Ubuntu 12.04 LTS (Precise Pangolin) - Chrome (latest)";
				checkbutton3.Label = @"Ubuntu 12.04 LTS (Precise Pangolin) - Firefox (latest)";
				checkbutton4.Label = @"Ubuntu 12.04 LTS (Precise Pangolin) - Other";
				checkbutton5.Visible = false;
				checkbutton6.Visible = false;
				checkbutton7.Visible = false;
				checkbutton8.Visible = false;
				checkbutton9.Visible = false;
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}

			if(combobox4.ActiveText == @"Android"){
				combo3startactions();
				combobox3.Visible = true;
				onToggleactions(true);

				checkbutton1.Label = @"Samsung Galaxy S2 - 2.3.3 - Native Browser";
				checkbutton2.Label = @"Samsung Galaxy S3 - 4.0.4 - Native Browser";
				checkbutton3.Label = @"Samsung Galaxy S4 - 4.2.2 - Native Browser";
				checkbutton4.Label = @"Samsung Galaxy TAB 10.1 - 3.1 - Native Browser";
				checkbutton5.Label = @"Samsung Galaxy TAB 2 10.1 - 4.0.4 - Native Browser";
				checkbutton6.Label = @"Samsung Galaxy TAB 2 7.0 - 4.1.2 - Native Browser";
				checkbutton7.Label = @"Acer Iconia TAB B1-710 - 4.1.2 - Native Browser";
				checkbutton8.Label = @"Acer Nexus 7 3G - 4.1 - Native Browser";
				checkbutton9.Label = @"Dell Streak 7 - 3.2 - Native Browser";
				checkbutton10.Label = @"HTC Google Nexus One - 2.3.6 - Native Browser";
				checkbutton11.Label = @"HTC Sensation XE - 4.0.3 - Native Browser";
				checkbutton12.Label = @"LG Nexus 4 E960 - 4.2.1 - Native Browser";

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

				checkbutton1.Label = @"iPad 4 3g - 6.1.2 - Native Browser";
				checkbutton2.Label = @"iPad 3 3g - 6.0.1 - Native Browser";
				checkbutton3.Label = @"iPad 2 3g - 7.0.2 - Native Browser";
				checkbutton4.Label = @"iPhone 5s - 7.0.1 - Native Browser";
				checkbutton5.Label = @"iPhone 5c - 7.0 - Native Browser";
				checkbutton6.Label = @"iPhone 5 - 7.0.2 - Native Browser";
				checkbutton7.Label = @"iPhone 5 - 6.1.4 - Native Browser";
				checkbutton8.Label = @"iPhone 4s - 7.0 - Native Browser";
				checkbutton9.Label = @"iPhone 4s - 5.1.1 - Native Browser";
				checkbutton10.Label = @"iPhone 4 - 6.1.3 - Native Browser";
				checkbutton11.Label = @"iPhone 3GS - 6.0 - Native Browser";
				checkbutton12.Label = @"iPhone 3G - 4.2.1 - Native Browser";

				combobox3.AppendText(@"iPad");
				combobox3.AppendText(@"iPhone 3/s");
				combobox3.AppendText(@"iPhone 4/s");
				combobox3.AppendText(@"iPhone 5/s");
				combobox3.AppendText(@"iPods");
			}
			if(combobox4.ActiveText == @"Windows / BB"){
				combo3startactions();
				combobox3.Visible = false;

				checkbutton1.Label = @"HTC 7 Pro - 7.10.8773.98 - Native Browser";
				checkbutton2.Label = @"HTC Windows Phone 8x - 8.0.10211.204 - Native Browser";
				checkbutton3.Label = @"Microsoft Surface - RT 32-bit (6.2) - Native Browser";
				checkbutton4.Label = @"Nokia Lumia 720 - 8.0 - Native Browser";
				checkbutton5.Label = @"Nokia Lumia 820 - 8.0 - Native Browser";
				checkbutton6.Label = @"Nokia Lumia 900 - 7.10.8773.98 - Native Browser";
				checkbutton7.Label = @"Blackberry 9300 Curve - 6.6.0.233 - Native Browser";
				checkbutton8.Label = @"Blackberry 9320 Curve - 7.1.0.398 - Native Browser";
				checkbutton9.Visible = false;
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}
		}

		public void onToggleactions(bool toggleval){
			if(toggleval == false){
				checkbutton1.Visible = false;
				checkbutton2.Visible = false;
				checkbutton3.Visible = false;
				checkbutton4.Visible = false;
				checkbutton5.Visible = false;
				checkbutton6.Visible = false;
				checkbutton7.Visible = false;
				checkbutton8.Visible = false;
				checkbutton9.Visible = false;
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}
			else{
				checkbutton1.Visible = true;
				checkbutton2.Visible = true;
				checkbutton3.Visible = true;
				checkbutton4.Visible = true;
				checkbutton5.Visible = true;
				checkbutton6.Visible = true;
				checkbutton7.Visible = true;
				checkbutton8.Visible = true;
				checkbutton9.Visible = true;
				checkbutton10.Visible = true;
				checkbutton11.Visible = true;
				checkbutton12.Visible = true;
			}
		}

		protected void OnCombobox3Changed (object sender, EventArgs e){
			if(combobox3.ActiveText == @"XP"){
				onToggleactions(true);
				checkbutton1.Label = @"IE7";
				checkbutton2.Label = @"IE8";
				checkbutton3.Label = @"IE (Other)";
				checkbutton4.Label = @"Chrome (latest / Other)";
				checkbutton5.Label = @"Firefox (latest / Other)";
				checkbutton6.Label = @"Opera (Version)";
				checkbutton7.Label = @"Safari 5.1.7";
				checkbutton8.Label = @"Other";
				checkbutton9.Visible = false;
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}
			if(combobox3.ActiveText == @"Vista"){
				onToggleactions(true);
				checkbutton1.Label = @"IE7";
				checkbutton2.Label = @"IE8";
				checkbutton3.Label = @"IE (Other)";
				checkbutton4.Label = @"Chrome (latest / Other)";
				checkbutton5.Label = @"Firefox (latest / Other)";
				checkbutton6.Label = @"Opera (Version)";
				checkbutton7.Label = @"Safari (Version)";
				checkbutton8.Label = @"Other";
				checkbutton9.Visible = false;
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}
			if(combobox3.ActiveText == @"Win 7"){
				onToggleactions(true);
				checkbutton1.Label = @"IE8";
				checkbutton2.Label = @"IE9";
				checkbutton3.Label = @"IE10";
				checkbutton4.Label = @"IE (Other)";
				checkbutton5.Label = @"Chrome (latest / Other)";
				checkbutton6.Label = @"Firefox (latest / Other)";
				checkbutton7.Label = @"Opera (Version)";
				checkbutton8.Label = @"Safari (Version)";
				checkbutton9.Label = @"Other";
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}
			if(combobox3.ActiveText == @"Win 8"){
				onToggleactions(true);
				checkbutton1.Label = @"IE10";
				checkbutton2.Label = @"IE (Other??)";
				checkbutton3.Label = @"Chrome (latest / Other)";
				checkbutton4.Label = @"Firefox (latest / Other)";
				checkbutton5.Label = @"Opera (Version)";
				checkbutton6.Label = @"Safari (Version)";
				checkbutton7.Label = @"Other";
				checkbutton8.Visible = false;
				checkbutton9.Visible = false;
				checkbutton10.Visible = false;
				checkbutton11.Visible = false;
				checkbutton12.Visible = false;
			}
		}
	}
}

