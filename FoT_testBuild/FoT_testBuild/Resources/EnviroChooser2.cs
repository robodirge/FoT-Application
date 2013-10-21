using System;
using Gtk;

namespace FoT{
	public partial class EnviroChooser2 : Gtk.Window{

		static public bool isAllTypesActive;
		static public bool isAllTypesActive2;

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

		public EnviroChooser2 () : 
				base(Gtk.WindowType.Toplevel){
			this.Build ();
			/*
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			button6.Visible = false;
			button7.Visible = false;
			button8.Visible = false;
			*/

			hbox2.Hide();
			hbox3.Hide();

			label3.Visible = false;
			label4.Visible = false;

			//Gdk.Color c = new Gdk.Color();
			//Gdk.Color.Parse("red", ref c);
			activeSetup();

			isAllTypesActive = true;
			isAllTypesActive2 = false;

			enablelvl3(0);
		}

		protected void activeSetup(){
			currentLayer1 = 0; // None selected
			currentLayer2 = 0; 
			currentLayer3 = 0; 
			currentLayer4 = 0; 
			currentLayer5 = 0; 
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
			label2.ModifyFg(StateType.Normal, c);
			label3.ModifyFg(StateType.Normal, c);
			label2.Text = @"Desktop is selected";

			label3.Visible = true;
			label4.Visible = false;

			hbox2.Show();
			button3.Visible = true;
			button4.Visible = true;
			button5.Visible = true;
			hbox3.Hide();
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
			label2.ModifyFg(StateType.Normal, c);
			label4.ModifyFg(StateType.Normal, c);
			label2.Text = @"Device is selected";

			label3.Visible = false;
			label4.Visible = true;

			hbox3.Show();
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			hbox2.Hide();
			button6.Visible = true;
			button7.Visible = true;
			button8.Visible = true;
		}

		//<param> Windows button clicked </param>
		protected void OnButton3Clicked (object sender, EventArgs e){
			currentLayer2 = 1; // Windows
			toggleactive(3);
			label3.Text = @"Windows is selected";
			enablelvl3(3);
		}

		//<param> OSX button clicked </param>
		protected void OnButton4Clicked (object sender, EventArgs e){
			currentLayer2 = 2; // OSX
			toggleactive(4);
			label3.Text = @"OSX is selected";
			enablelvl3(4);
		}

		//<param> Other button clicked </param>
		protected void OnButton5Clicked (object sender, EventArgs e){
			currentLayer2 = 3; // Other
			toggleactive(5);
			label3.Text = @"Other is selected";
			enablelvl3(5);
		}

		//<param> Android button clicked </param>
		protected void OnButton6Clicked (object sender, EventArgs e){
			currentLayer2 = 4; // Android
			toggleactive(6);
			label4.Text = @"Android is selected";
			enablelvl3(6);
		}

		//<param> iOS button clicked </param>
		protected void OnButton7Clicked (object sender, EventArgs e){
			currentLayer2 = 5; // iOS
			toggleactive(7);
			label4.Text = @"iOS is selected";
			enablelvl3(7);
		}

		//<param> BB / WinP button clicked </param>
		protected void OnButton8Clicked (object sender, EventArgs e){
			currentLayer2 = 6; // BB.Win
			toggleactive(8);
			label4.Text = @"BB / WinPhone is selected";
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

			if(inumber < 6)
				label3.Text = @"< -- Select a OS";
			else
				label4.Text = @"< -- Select a OS";

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

			label3.Text = @"< -- Select a OS";
			label4.Text = @"< -- Select a OS";
		}

		//<param> enable visible lvl 3 items </param>
		public void enablelvl3(int inumber){
			hbox4.Show();
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
			button33.Visible = true;

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
				button33.Visible = false;
			}
			else if((inumber < 6)&&(inumber != 0)){
				hbox4.Hide();
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
				button33.Visible = false;

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
				button33.Visible = false;
				break;
			case 4:
				button24.Visible = false;
				button25.Visible = false;
				button26.Visible = false;
				button27.Visible = false;
				button28.Visible = false;
				button33.Visible = false;
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
			if(isAllTypesActive == true){
				currentLayer3 = 3;
				button22.Sensitive = false;
				button9.Sensitive = true;
				button10.Sensitive = true;
				sortActiveLayers();
			}
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
			//------------------------------
		}

		public void callActivelayer(){
			switch(currentLayer5){
			case 0:
				break;
			case 1:
				button15.Click();
				break;
			case 2:
				button11.Click();
				break;
			case 3:
				button12.Click();
				break;
			case 4:
				button13.Click();
				break;
			case 5:
				button14.Click();
				break;
			case 6:
				button16.Click();
				break;
			case 7:
				button17.Click();
				break;
			case 8:
				button18.Click();
				break;
			case 9:
				button19.Click();
				break;
			case 10:
				button20.Click();
				break;
			case 11:
				button21.Click();
				break;
			default:
				break;
			}
		}

		protected void OnButton9Clicked (object sender, EventArgs e){
			currentLayer3 = 1; // Tablet
			isAllTypesActive = true;
			button22.Sensitive = true;
			button9.Sensitive = false;
			button10.Sensitive = true;
			//label1.Text = @"Tablet devices";
			callActivelayer();
		}

		protected void OnButton10Clicked (object sender, EventArgs e){
			currentLayer3 = 2; //Mobile
			isAllTypesActive = true;
			button22.Sensitive = true;
			button9.Sensitive = true;
			button10.Sensitive = false;
			//label1.Text = @"Mobile devices";
			callActivelayer();
		}
		
		protected void OnButton11Clicked (object sender, EventArgs e){
			currentLayer5 = 2; // Android
			enableAlllvl4();
			button11.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet Android v2.0 devices";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile Android v2.0 devices";
			}
			else if(currentLayer3 == 3){
				label1.Text = @"All Android v2.0 devices";
			}
		}

		protected void OnButton12Clicked (object sender, EventArgs e){
			currentLayer5 = 3; // Android
			enableAlllvl4();
			button12.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet Android v3.0 devices";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile Android v3.0 devices";
			}
			else if(currentLayer3 == 3){
				label1.Text = @"All Android v3.0 devices";
			}
		}

		protected void OnButton13Clicked (object sender, EventArgs e){
			currentLayer5 = 4; // Android
			enableAlllvl4();
			button13.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet Android v4.1 devices";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile Android v4.1 devices";
			}
			else if(currentLayer3 == 3){
				label1.Text = @"All Android v4.1 devices";
			}
		}

		protected void OnButton14Clicked (object sender, EventArgs e){
			currentLayer5 = 5; // Android
			enableAlllvl4();
			button14.Sensitive = false;

			if(currentLayer3 ==1){
				label1.Text = @"Tablet Android v4.2+ devices";
			}
			else if(currentLayer3 ==2){
				label1.Text = @"Mobile Android v4.2+ devices";
			}			
			else if(currentLayer3 == 3){
				label1.Text = @"All Android v4.2+ devices";
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
				if(currentLayer3 ==3)
					label1.Text = @"All android Active";
				else if(currentLayer3 ==1)
					label1.Text = @"Tablet Only android";
				else if(currentLayer3 ==2)
					label1.Text = @"Mobile Only android";
				break;
			case 2:
				enableAlllvl4a();
				if(currentLayer3 ==3)
					label1.Text = @"All iOS Active";
				else if(currentLayer3 ==1)
					label1.Text = @"Tablet Only iOS";
				else if(currentLayer3 ==2)
					label1.Text = @"Mobile Only iOS";
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
	}
}

