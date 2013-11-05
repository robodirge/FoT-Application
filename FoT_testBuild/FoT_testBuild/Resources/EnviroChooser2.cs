using System;
using Gtk;

namespace FoT{
	public partial class EnviroChooser2 : Gtk.Window{
		
		//Current active
		//Layer 1 (dekstop)
		static public int currentLayer1;
			//1 = Desktop
			//2 = Device
		//Layer 2 (OS)
		static public int currentLayer2;
			//1 - 3 = Desktop
			//4 - 6 = Device
		//Layer 3 (Type)
		static public int currentLayer3;
		//Layer 4 (V - Control)
		static public int currentLayer4;
		//Layer 5 (version)
		static public int currentLayer5;
		static public int currentLayer6;

		public EnviroChooser2 () : 
				base(Gtk.WindowType.Toplevel){
			this.Build ();

			//hbox2.Hide();
			//hbox3.Hide();

			activeSetup();

			enablelvl3(0);
		}

		protected void activeSetup(){
			currentLayer1 = 0; // None selected
			currentLayer2 = 0; 
			currentLayer3 = 0; 
			currentLayer4 = 0; 
			currentLayer5 = 0; 
			currentLayer6 = 0;
			return;
		}
		//<param> Desktop button clicked </param>
		protected void OnButton1Clicked (object sender, EventArgs e){
			activeSetup();
			currentLayer1 = 1; //Destop selected

			button1.Sensitive = false;
			button2.Sensitive = true;

			resetLevel1();
			enablelvl3(0);

			Gdk.Color c = new Gdk.Color();
			Gdk.Color.Parse("red", ref c);

			AreaB3.Hide();
			button3.Visible = true;
			button4.Visible = true;
			button5.Visible = true;
			AreaB2.Show();
			button6.Visible = false;
			button7.Visible = false;
			button8.Visible = false;
		}

		//<param> Device button clicked </param>
		protected void OnButton2Clicked (object sender, EventArgs e){
			activeSetup();
			currentLayer1 = 2; //Destop selected

			button1.Sensitive = true;
			button2.Sensitive = false;

			resetLevel1();
			enablelvl3(0);

			Gdk.Color c = new Gdk.Color();
			Gdk.Color.Parse("green", ref c);

			AreaB2.Hide();
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			AreaB3.Show();
			button6.Visible = true;
			button7.Visible = true;
			button8.Visible = true;
		}

		//<param> Windows button clicked </param>
		protected void OnButton3Clicked (object sender, EventArgs e){
			currentLayer2 = 1; // Windows
			toggleactive(3);
			enablelvl3(3);
		}

		//<param> OSX button clicked </param>
		protected void OnButton4Clicked (object sender, EventArgs e){
			currentLayer2 = 2; // OSX
			toggleactive(4);
			enablelvl3(4);
		}

		//<param> Other button clicked </param>
		protected void OnButton5Clicked (object sender, EventArgs e){
			currentLayer2 = 3; // Other
			toggleactive(5);
			enablelvl3(5);
		}

		//<param> Android button clicked </param>
		protected void OnButton6Clicked (object sender, EventArgs e){
			currentLayer2 = 4; // Android
			toggleactive(6);
			//AllVerHbox.Show();
			//OtherHbox.Hide();
			enablelvl3(6);

		}

		//<param> iOS button clicked </param>
		protected void OnButton7Clicked (object sender, EventArgs e){
			currentLayer2 = 5; // iOS
			toggleactive(7);
			//AllVerHbox.Hide();
			//OtherHbox.Show();
			enablelvl3(7);
		}

		//<param> BB / WinP button clicked </param>
		protected void OnButton8Clicked (object sender, EventArgs e){
			currentLayer2 = 6; // BB.Win
			toggleactive(8);
			enablelvl3(8);
		}

		//<param> disable 'clicked' button </param>
		public void toggleactive(int inumber){
			button3.Sensitive = true;
			button4.Sensitive = true;
			button5.Sensitive = true;
			button6.Sensitive = true;
			button7.Sensitive = true;
			button8.Sensitive = true;

			switch (inumber){
				case 3:
					button3.Sensitive = false;
					break;
				case 4:
					button4.Sensitive = false;
					break;
				case 5:
					button5.Sensitive = false;
					break;
				case 6:
					button6.Sensitive = false;
					break;
				case 7:
					button7.Sensitive = false;
					break;
				case 8:
					button8.Sensitive = false;
					break;
				default:
					break;
			}
		}

		//<param> Re-enables all buttons and resets labels Lvl1 </param>
		public void resetLevel1(){
			button3.Sensitive = true;
			button4.Sensitive = true;
			button5.Sensitive = true;
			button6.Sensitive = true;
			button7.Sensitive = true;
			button8.Sensitive = true;

		}

		//<param> enable visible lvl 3 items </param>
		public void enablelvl3(int inumber){
			//hbox4.Show();
			button9.Visible = true;
			button10.Visible = true;
			button11.Visible = true;
			button12.Visible = true;
			button13.Visible = true;
			button14.Visible = true;
			button15.Visible = true;
			button16.Visible = true;
			button17.Visible = true;
			button18.Visible = true;
			button19.Visible = true;
			button20.Visible = true;
			button21.Visible = true;
			button22.Visible = true;
			button24.Visible = true;
			button25.Visible = true;
			button26.Visible = true;
			button27.Visible = true;
			button28.Visible = true;
			button29.Visible = true;
			button30.Visible = true;
			button31.Visible = true;
			button32.Visible = true;

			if(inumber == 0){
				button9.Visible = false;
				button10.Visible = false;
				button11.Visible = false;
				button12.Visible = false;
				button13.Visible = false;
				button14.Visible = false;
				button15.Visible = false;
				button16.Visible = false;
				button17.Visible = false;
				button18.Visible = false;
				button19.Visible = false;
				button20.Visible = false;
				button21.Visible = false;
				button22.Visible = false;
				button24.Visible = false;
				button25.Visible = false;
				button26.Visible = false;
				button27.Visible = false;
				button28.Visible = false;
				button29.Visible = false;
				button30.Visible = false;
				button31.Visible = false;
				button32.Visible = false;
			}
			else if((inumber < 6)&&(inumber != 0)){
				//hbox4.Hide();
				button9.Visible = false;
				button10.Visible = false;
				button11.Visible = false;
				button12.Visible = false;
				button13.Visible = false;
				button14.Visible = false;
				button15.Visible = false;
				button16.Visible = false;
				button17.Visible = false;
				button18.Visible = false;
				button19.Visible = false;
				button20.Visible = false;
				button21.Visible = false;
				button22.Visible = false;

				enableSelection3(inumber);
			}
			else{
				button24.Visible = false;
				button25.Visible = false;
				button26.Visible = false;
				button27.Visible = false;
				button28.Visible = false;
				button29.Visible = false;
				button30.Visible = false;
				button31.Visible = false;
				button32.Visible = false;

				enableSelection3(inumber);
			}
		}
   
		//<param> enable visible lvl 3 items </param> 24 -28
		public void enableSelection3(int inumber){
			switch(inumber){
			case 3:
				button29.Visible = false;
				button30.Visible = false;
				button31.Visible = false;
				button32.Visible = false;
				break;
			case 4:
				button24.Visible = false;
				button25.Visible = false;
				button26.Visible = false;
				button27.Visible = false;
				button28.Visible = false;
				break;
			case 5:
				button24.Visible = false;
				button25.Visible = false;
				button26.Visible = false;
				button27.Visible = false;
				button28.Visible = false;
				button29.Visible = false;
				button30.Visible = false;
				button31.Visible = false;
				button32.Visible = false;
				break;
			case 6:
				button16.Visible = false;
				button17.Visible = false;
				button18.Visible = false;
				button19.Visible = false;
				button20.Visible = false;
				button21.Visible = false;

				currentLayer5 = 1;
				button22.Click();

				break;
			case 7:
				button11.Visible = false;
				button12.Visible = false;
				button13.Visible = false;
				button14.Visible = false;
				//button15.Visible = false;

				currentLayer5 = 1;
				button22.Click();

				break;
			case 8:
				button9.Visible = false;
				button10.Visible = false;
				button11.Visible = false;
				button12.Visible = false;
				button13.Visible = false;
				button14.Visible = false;
				button15.Visible = false;
				button16.Visible = false;
				button17.Visible = false;
				button18.Visible = false;
				button19.Visible = false;
				button20.Visible = false;
				button21.Visible = false;
				button22.Visible = false;

				showOption8();
				break;
			default:
				break;
			}
		}

		protected void showOption8(){
			label1.Text = @"Black berry and other stuff.";
			return;
		}

		protected void OnButton22Clicked (object sender, EventArgs e){
			currentLayer3 = 3;
			button22.Sensitive = false;
			button9.Sensitive = true;
			button10.Sensitive = true;
			sortActiveLayers();
		}

		public void sortActiveLayers(){
			switch(currentLayer2){
			case 0:
				Console.WriteLine(@"No OS Selected");
				break;
			case 4:
				currentLayer4 = 1; //Android
				callActivelayer();
				break;
			case 5:
				currentLayer4 = 2; //iOS
				callActivelayer();
				break;
			default:
				Console.WriteLine(@"Different OS Selected");
				Console.WriteLine(@"----->" + currentLayer2);
				break;
			}
		}

		public void callActivelayer(){
			Console.WriteLine("layer 5:");
			Console.WriteLine(currentLayer5);
			switch(currentLayer5){
			case 0:
				break;
			case 1:
				button15.Click(); //all
				break;
			case 2:
				button11.Click();//and
				break;
			case 3:
				button12.Click();//and
				break;
			case 4:
				button13.Click();//and
				break;
			case 5:
				button14.Click();//and
				break;
			case 6:
				button16.Click();//ios
				break;
			case 7:
				button17.Click();//ios
				break;
			case 8:
				button18.Click();//ios
				break;
			case 9:
				button19.Click();//ios
				break;
			case 10:
				button20.Click();//ios
				break;
			case 11:
				button21.Click();//ios
				break;
			default:
				break;
			}

			EnviroShow();
		}

		protected void OnButton9Clicked (object sender, EventArgs e){
			currentLayer3 = 1; // Tablet
			button22.Sensitive = true;
			button9.Sensitive = false;
			button10.Sensitive = true;
			callActivelayer();
		}

		protected void OnButton10Clicked (object sender, EventArgs e){
			currentLayer3 = 2; //Mobile
			button22.Sensitive = true;
			button9.Sensitive = true;
			button10.Sensitive = false;
			callActivelayer();
		}
		
		protected void OnButton11Clicked (object sender, EventArgs e){
			currentLayer5 = 2; // Android
			enableAlllvl4();
			button11.Sensitive = false;

			if(currentLayer3 ==1){
				currentLayer6 = 1;
				label1.Text = @"Tablet Android v2.0 devices";
			}
			else if(currentLayer3 ==2){
				currentLayer6 = 2;
				label1.Text = @"Mobile Android v2.0 devices";
			}
			else if(currentLayer3 == 3){
				currentLayer6 = 3;
				label1.Text = @"All Android v2.0 devices";
			}

		}

		protected void OnButton12Clicked (object sender, EventArgs e){
			currentLayer5 = 3; // Android
			enableAlllvl4();
			button12.Sensitive = false;

			if(currentLayer3 ==1){
				currentLayer6 = 4;
				label1.Text = @"Tablet Android v3.0 devices";
			}
			else if(currentLayer3 ==2){
				currentLayer6 = 5;
				label1.Text = @"Mobile Android v3.0 devices";
			}
			else if(currentLayer3 == 3){
				currentLayer6 = 6;
				label1.Text = @"All Android v3.0 devices";
			}
		}

		protected void OnButton13Clicked (object sender, EventArgs e){
			currentLayer5 = 4; // Android
			enableAlllvl4();
			button13.Sensitive = false;

			if(currentLayer3 ==1){
				currentLayer6 = 7;
				label1.Text = @"Tablet Android v4.0 devices";
			}
			else if(currentLayer3 ==2){
				currentLayer6 = 8;
				label1.Text = @"Mobile Android v4.0 devices";
			}
			else if(currentLayer3 == 3){
				currentLayer6 = 9;
				label1.Text = @"All Android v4.0 devices";
			}
		}

		protected void OnButton14Clicked (object sender, EventArgs e){
			currentLayer5 = 5; // Android
			enableAlllvl4();
			button14.Sensitive = false;

			if(currentLayer3 ==1){
				currentLayer6 = 10;
				label1.Text = @"Tablet Android v4.1+ devices";
			}
			else if(currentLayer3 ==2){
				currentLayer6 = 11;
				label1.Text = @"Mobile Android v4.1+ devices";
			}			
			else if(currentLayer3 == 3){
				currentLayer6 = 12;
				label1.Text = @"All Android v4.1+ devices";
			}
		}

		public void enableAlllvl4(){
			button11.Sensitive = true;
			button12.Sensitive = true;
			button13.Sensitive = true;
			button14.Sensitive = true;
			button15.Sensitive = true;
		}

		public void enableAlllvl4a(){
			button15.Sensitive = true;
			button16.Sensitive = true;
			button17.Sensitive = true;
			button18.Sensitive = true;
			button19.Sensitive = true;
			button20.Sensitive = true;
			button21.Sensitive = true;
		}

		protected void OnButton15Clicked (object sender, EventArgs e){
			currentLayer5 = 1;

			switch(currentLayer4){
			case 0:
				Console.WriteLine(@"No Version Selected");
				break;
			case 1:
				enableAlllvl4();
				if(currentLayer3 ==3){
					currentLayer6 = 13;
					label1.Text = @"All android Active";
				}
				else if(currentLayer3 ==1){
					currentLayer6 = 14;
					label1.Text = @"Tablet Only android";
				}
				else if(currentLayer3 ==2){
					currentLayer6 = 15;
					label1.Text = @"Mobile Only android";
				}
				break;
			case 2:
				enableAlllvl4a();
				if(currentLayer3 ==3){
					label1.Text = @"All iOS Active";
				}
				else if(currentLayer3 ==1){
					label1.Text = @"Tablet Only iOS";
				}
				else if(currentLayer3 ==2){
					label1.Text = @"Mobile Only iOS";
				}
				break;
			default:
				Console.WriteLine(@"Different OS Selected");
				Console.WriteLine(@"----->" + currentLayer4);
				break;
			}

			button15.Sensitive = false;
		}

		protected void OnButton16Clicked (object sender, EventArgs e){
			currentLayer5 = 6; // Android
			enableAlllvl4a();
			button16.Sensitive = false;
			label1.Text = @"iPod devices";
		}

		protected void OnButton17Clicked (object sender, EventArgs e){
			currentLayer5 = 7; // Android
			enableAlllvl4a();
			button17.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet iOS 3 / 4 ";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile iOS 3 / 4";
			}			
			else if(currentLayer3 == 3){
				label1.Text = @"All iOS 3 / 4 devices";
			}
		}

		protected void OnButton18Clicked (object sender, EventArgs e){
			currentLayer5 = 8; // Android
			enableAlllvl4a();
			button18.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet iOS 5 ";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile iOS 5";
			}			
			else if(currentLayer3 == 3){
				label1.Text = @"All iOS 5 devices";
			}
		}

		protected void OnButton19Clicked (object sender, EventArgs e){
			currentLayer5 = 9; // Android
			enableAlllvl4a();
			button19.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet iOS 6 ";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile iOS 6";
			}			
			else if(currentLayer3 == 3){
				label1.Text = @"All iOS 6 devices";
			}
		}

		protected void OnButton20Clicked (object sender, EventArgs e){
			currentLayer5 = 10; // Android
			enableAlllvl4a();
			button20.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet iOS 6.1 ";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile iOS 6.1";
			}			
			else if(currentLayer3 == 3){
				label1.Text = @"All iOS 6.1 devices";
			}
		}

		protected void OnButton21Clicked (object sender, EventArgs e){
			currentLayer5 = 11; // Android
			enableAlllvl4a();
			button21.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet iOS 7+ ";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile iOS 7+";
			}			
			else if(currentLayer3 == 3){
				label1.Text = @"All iOS 7+ devices";
			}
		}

		#region enviro

		public void EnviroShow(){
			Console.WriteLine(currentLayer6);

			#region switch 1
			switch (currentLayer6){
			case 0:
				break;
			case 1:
				Console.WriteLine("Switch 1");
				//AND >> TAB >> V.2
				#region enviro - 1
				Option1.Label = "HTC - Legend - (2.2)";
				Option2.Label = "Samsung - Galaxy Ace S5830 - (2.2.1)";
				Option3.Label = "HTC - Wildfire (PC49100) - (2.2.1)";
				Option4.Label = "Samsung - Galaxy S - GT-i9000 - (2.2.2)";
				Option5.Label = "HTC - Desire (PB99200)\t(2.3.3)";
				Option6.Label = "Samsung - Galaxy S2 - GT-i9100 - 2.3.3";
				Option7.Label = "HTC - Desire HD - (2.3.5)";
				Option8.Label = "HTC - Wildfire S A510e - (2.3.5)";
				Option9.Label = "Samsung - Galaxy Ace S5830i - (2.3.6)";
				Option10.Label = "HTC - Google Nexus One - (2.3.6)";
				Option11.Label = "Samsung\tY - S5360 - (2.3.6)";
				Option12.Label = "Samsung - Galaxy Tab 10.1 - (3.1)";
				Option13.Label = "Dell - Streak 7 - (3.2)";
				Option14.Label = "Motorola - Xoom - (3.2)";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				#endregion
				break;
			case 2:
				#region enviro - 2
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 3:
				#region enviro - 3
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 4:
				#region enviro - 4
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 5:
				#region enviro - 5
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 6:
				#region enviro - 6
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 7:
				#region enviro - 7
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 8:
				#region enviro - 8
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 9:
				#region enviro - 9
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 10:
				#region enviro - 10
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;			
			case 11:
				#region enviro - 11
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 12:
				#region enviro - 12
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			case 13:
				#region enviro - 13
				Option1.Label = "HTC - Legend - (2.2)";
				Option2.Label = "Samsung - Galaxy Ace S5830 - (2.2.1)";
				Option3.Label = "HTC - Wildfire (PC49100) - (2.2.1)";
				Option4.Label = "Samsung - Galaxy S - GT-i9000 - (2.2.2)";
				Option5.Label = "HTC - Desire (PB99200)\t(2.3.3)";
				Option6.Label = "Samsung - Galaxy S2 - GT-i9100 - 2.3.3";
				Option7.Label = "HTC - Desire HD - (2.3.5)";
				Option8.Label = "HTC - Wildfire S A510e - (2.3.5)";
				Option9.Label = "Samsung - Galaxy Ace S5830i - (2.3.6)";
				Option10.Label = "HTC - Google Nexus One - (2.3.6)";
				Option11.Label = "Samsung\tY - S5360 - (2.3.6)";
				Option12.Label = "Samsung - Galaxy Tab 10.1 - (3.1)";
				Option13.Label = "Dell - Streak 7 - (3.2)";
				Option14.Label = "Motorola - Xoom - (3.2)";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";	
				#endregion
				break;
			case 14:
				#region enviro - 14
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				
				break;			
			case 15:
				#region enviro - 15
				Option1.Label = "";
				Option2.Label = "";
				Option3.Label = "";
				Option4.Label = "";
				Option5.Label = "";
				Option6.Label = "";
				Option7.Label = "";
				Option8.Label = "";
				Option9.Label = "";
				Option10.Label = "";
				Option11.Label = "";
				Option12.Label = "";
				Option13.Label = "";
				Option14.Label = "";
				Option15.Label = "";
				Option16.Label = "";
				Option17.Label = "";
				Option18.Label = "";
				
				
				#endregion
				break;
			default:
				break;
			}
			#endregion

			return;
		}

		#endregion
	}
}

