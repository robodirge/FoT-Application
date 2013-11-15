using System;
using System.IO;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{
		Gtk.TreeStore musicList;
		Gtk.CellRendererToggle myToggle;

		//static int[] enviroINTBools;
		static bool[] enviroBools;
		static string[] enviroManu;
		static string[] enviroType;
		static string[] enviroName;
		static string[] enviroOS;
		static string[] enviroVersion;
		static int[] enviroID;

		public static string enviroPath {get; set; }


		public EnvironmentChooser () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			initSetup();

			int tbool = 0;
			int stext1 = 1;
			int stext2 = 2;
			int stext3 = 3;

			musicList = new Gtk.TreeStore(typeof(bool), typeof (string), typeof (string), typeof (string),typeof (string), typeof (string), typeof (int));

			//ID MAY CHANGE!!!!//ID MAY CHANGE!!!!//ID MAY CHANGE!!!!//ID MAY CHANGE!!!!
			Gtk.TreeIter iter = musicList.AppendValues(false, "Mobile", "", "", "","", "1000");
			for(int x = 0; x < enviroBools.Length-1; x++){
				musicList.AppendValues(iter, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
			}
			iter = musicList.AppendValues(false, "Desktop", "", "", "","", "2000");
			//musicList.AppendValues(iter, false, "Win7", "Entry 3", "Version 3", 3);

			EnviroTree.Model = musicList;

			myToggle = new Gtk.CellRendererToggle();
			myToggle.Activatable = true;
			myToggle.Toggled += myToggle_toggled;
			Gtk.TreeViewColumn column_toggle = new Gtk.TreeViewColumn("Toggle", myToggle, tbool);
			EnviroTree.AppendColumn(column_toggle);

			Gtk.CellRendererText SubGroup = new Gtk.CellRendererText();
			Gtk.TreeViewColumn subGRPCol = new Gtk.TreeViewColumn("Type", SubGroup, stext1);
			EnviroTree.AppendColumn(subGRPCol);

			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn songCol = new Gtk.TreeViewColumn("Version", songNameCell, stext2);
			EnviroTree.AppendColumn(songCol);
		
			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn artistCol = new Gtk.TreeViewColumn("Name", artistNameCell, stext3);
			EnviroTree.AppendColumn(artistCol);

			column_toggle.AddAttribute(myToggle, "active", 0);
			subGRPCol.AddAttribute(SubGroup, "text", 1);
			artistCol.AddAttribute(artistNameCell, "text", 2);
			songCol.AddAttribute(songNameCell, "text", 3);

			EnviroTree.Model = musicList;
		}
	
		protected void initSetup(){
			//enviroBools = new int[200];
			//enviroManu = new string[200];
			//enviroType = new string[200];
			//enviroName = new string[200];
			//enviroOS = new string[200];
			//enviroVersion = new string[200];
			//enviroID = new int[200];

			enviroPath = Environment.CurrentDirectory + @"\Resources\AndroidEnviro.txt";
			readFile();
			return;
		}

		protected void readFile(){
			string line;
			string search;
			int testa = 0;
			StreamReader file = new StreamReader(enviroPath);

			while((line = file.ReadLine()) != null){
				if(line.Contains(@"**Enabled")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					enviroBools = new bool[words.Length-1];
					for(int x = 0; x < words.Length-1;x++){
						enviroBools[testa] = Boolean.Parse(words[testa]);
						Console.WriteLine(enviroBools[testa].ToString());
						testa++;
					}
					testa = 0;

					//enviroBools = Array.ConvertAll(words, bool.Parse);

					/*
					Array.Resize(ref words, words.Length -1);
					enviroINTBools = new int[words.Length-1];
					enviroINTBools = Array.ConvertAll(words, int.Parse);
					enviroBools = new bool[words.Length-1];


					foreach(int word in enviroINTBools){
						string output = Convert.ToString(enviroINTBools[testa], 2);
						enviroBools[testa] = Convert.ToBoolean(output);

						//enviroManu[testa] = enviroManu[testa].Trim();
						testa++;
					}
					testa = 0;
					*/
					//enviroBools = new  [words.Length-1];
					//enviroBools = Array.ConvertAll(enviroINTBools, bool.Parse);

				}
				if(line.Contains(@"**Manufacturer")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					//string[] words = search.Split(;
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					enviroManu = new string[words.Length-1];
					enviroManu = words;
				
					foreach(string word in enviroManu){
						enviroManu[testa] = enviroManu[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Type")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);

					Array.Resize(ref words, words.Length -1);
					enviroType = new string[words.Length-1];
					enviroType = words;

					foreach(string word in enviroType){
						enviroType[testa] = enviroType[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Name")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);

					Array.Resize(ref words, words.Length -1);
					enviroName = new string[words.Length-1];
					enviroName = words;

					foreach(string word in enviroName){
						enviroName[testa] = enviroName[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**OS")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);

					Array.Resize(ref words, words.Length -1);
					enviroOS = new string[words.Length-1];
					enviroOS = words;

					foreach(string word in enviroOS){
						enviroOS[testa] = enviroOS[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Version")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);

					Array.Resize(ref words, words.Length -1);
					enviroVersion = new string[words.Length-1];
					enviroVersion = words;

					foreach(string word in enviroVersion){
						enviroVersion[testa] = enviroVersion[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**ID")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);

					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					enviroID = new int[words.Length-1];
					enviroID = Array.ConvertAll(words, int.Parse);

				}

			}

			file.Close();
			return;
		}



		protected void myToggle_toggled (object o, ToggledArgs args)
		{
			TreeIter iter;
			if(musicList.GetIter(out iter, new TreePath(args.Path))){
				bool old = (bool) musicList.GetValue(iter, 0);
				musicList.SetValue(iter, 0, !old);
				/*
				if(old == true)
					Console.WriteLine("Off");
				else if(old == false)
					Console.WriteLine("On");
				*/

				int test = (int) musicList.GetValue(iter, 4);

			}

		}
	}
}

