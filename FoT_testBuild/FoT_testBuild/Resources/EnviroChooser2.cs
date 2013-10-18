using System;
using Gtk;

namespace FoT{
	public partial class EnviroChooser2 : Gtk.Window{

		static public bool isAllTypesActive;

		public EnviroChooser2 () : 
				base(Gtk.WindowType.Toplevel){
			this.Build ();
			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			button6.Visible = false;
			button7.Visible = false;
			button8.Visible = false;

			label3.Visible = false;
			label4.Visible = false;

			//Gdk.Color c = new Gdk.Color();
			//Gdk.Color.Parse("red", ref c);

			isAllTypesActive = true;

			enablelvl3(0);

		}
		//<param> Desktop button clicked </param>
		protected void OnButton1Clicked (object sender, EventArgs e){
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

			button3.Visible = true;
			button4.Visible = true;
			button5.Visible = true;
			button6.Visible = false;
			button7.Visible = false;
			button8.Visible = false;
		}

		//<param> Device button clicked </param>
		protected void OnButton2Clicked (object sender, EventArgs e){
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

			button3.Visible = false;
			button4.Visible = false;
			button5.Visible = false;
			button6.Visible = true;
			button7.Visible = true;
			button8.Visible = true;
		}

		//<param> Windows button clicked </param>
		protected void OnButton3Clicked (object sender, EventArgs e){
			toggleactive(3);
			label3.Text = @"Windows is selected";
			enablelvl3(3);
		}

		//<param> OSX button clicked </param>
		protected void OnButton4Clicked (object sender, EventArgs e){
			toggleactive(4);
			label3.Text = @"OSX is selected";
			enablelvl3(4);
		}

		//<param> Other button clicked </param>
		protected void OnButton5Clicked (object sender, EventArgs e){
			toggleactive(5);
			label3.Text = @"Other is selected";
			enablelvl3(5);
		}

		//<param> Android button clicked </param>
		protected void OnButton6Clicked (object sender, EventArgs e){
			toggleactive(6);
			label4.Text = @"Android is selected";
			enablelvl3(6);
		}

		//<param> iOS button clicked </param>
		protected void OnButton7Clicked (object sender, EventArgs e){
			toggleactive(7);
			label4.Text = @"iOS is selected";
			enablelvl3(7);
		}

		//<param> BB / WinP button clicked </param>
		protected void OnButton8Clicked (object sender, EventArgs e){
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
			
				//button22.Sensitive = isAllTypesActive;
				button22.Click();

				break;
			case 7:
				button11.Visible = false;
				button12.Visible = false;
				button13.Visible = false;
				button14.Visible = false;
				button15.Visible = false;

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
				break;
			default:
				break;
			}
		}

		protected void OnButton22Clicked (object sender, EventArgs e){
			if(isAllTypesActive == true){
				button22.Sensitive = false;
				button9.Sensitive = true;
				button10.Sensitive = true;
				label1.Text = @"All Android devices // Or iOS // Or Other";
			}
		}

		protected void OnButton9Clicked (object sender, EventArgs e){
			isAllTypesActive = true;
			button22.Sensitive = true;
			button9.Sensitive = false;
			button10.Sensitive = true;
			label1.Text = @"Tablet devices";
		}

		protected void OnButton10Clicked (object sender, EventArgs e){
			isAllTypesActive = true;
			button22.Sensitive = true;
			button9.Sensitive = true;
			button10.Sensitive = false;
			label1.Text = @"Mobile devices";
		}
		
		protected void OnButton11Clicked (object sender, EventArgs e){
			enableAlllvl4();
			button11.Sensitive = false;
			label1.Text = @"Android v2.0 devices";
		}

		protected void OnButton12Clicked (object sender, EventArgs e){
			enableAlllvl4();
			button12.Sensitive = false;
			label1.Text = @"Android v3.0 devices";
		}

		protected void OnButton13Clicked (object sender, EventArgs e){
			enableAlllvl4();
			button13.Sensitive = false;
			label1.Text = @"Android v4.1 devices";
		}

		protected void OnButton14Clicked (object sender, EventArgs e){
			enableAlllvl4();
			button14.Sensitive = false;
			label1.Text = @"Android v4.2 devices";
		}

		public void enableAlllvl4(){
			//button9.Sensitive = true;
			//button10.Sensitive = true;
			button11.Sensitive = true;
			button12.Sensitive = true;
			button13.Sensitive = true;
			button14.Sensitive = true;
			button15.Sensitive = true;
		}
	}
}

