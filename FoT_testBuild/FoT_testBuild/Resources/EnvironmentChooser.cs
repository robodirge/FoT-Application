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

			//							toggle			Manu				type			name			OS				Version			ID
			musicList = new Gtk.TreeStore(typeof(bool), typeof (string), typeof (string), typeof (string),typeof (string),typeof (string),typeof (int));

			//ID MAY CHANGE!!!!//ID MAY CHANGE!!!!//ID MAY CHANGE!!!!//ID MAY CHANGE!!!!
			/*
			Gtk.TreeIter iter = musicList.AppendValues(false,"Mobile","","","","",1000);
			for(int x = 0; x < enviroBools.Length-1; x++){
				musicList.AppendValues(iter, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
			}
			iter = musicList.AppendValues(false, "Desktop", "a", "a", "a","a", 2000);
			*/


			/*  VVVVVVVVVVVVVVVVVVV


			EnviroTree.ExpandRow(



				^^^^^^^^^^^^^^^^^ */ 


			///*

			Gtk.TreeIter treeLevel1_Enviroment; // Main
			Gtk.TreeIter treeLevel2_Desktop; // Type
			Gtk.TreeIter treeLevel2_Devices; // Type
			Gtk.TreeIter treeLevel3_iOS; // Devices  
			Gtk.TreeIter treeLevel3_i_3o4; //iOS
			Gtk.TreeIter treeLevel3_i_5; //iOS
			Gtk.TreeIter treeLevel3_i_6; //iOS
			Gtk.TreeIter treeLevel3_i_7; //iOS
			Gtk.TreeIter treeLevel3_Android; // Devices
			Gtk.TreeIter treeLevel3_Other; // Devices
			Gtk.TreeIter treeLevel3_A_HTC; // Android
			Gtk.TreeIter treeLevel3_A_Samsung; // Android
			Gtk.TreeIter treeLevel3_A_Other; // Android

			treeLevel1_Enviroment = musicList.AppendValues(false,"Environments","","","","",1000);

			treeLevel2_Desktop = musicList.AppendValues(treeLevel1_Enviroment, false,"Desktop","","","","",2000);
			//EMPTY!
			treeLevel2_Devices = musicList.AppendValues(treeLevel1_Enviroment, false,"Devices","","","","",3000);
			treeLevel3_iOS = musicList.AppendValues(treeLevel2_Devices, false,"iOS","","","","",4000);
			treeLevel3_i_3o4 = musicList.AppendValues(treeLevel3_iOS, false,"Version 3 or 4","","","","",4100);
			treeLevel3_i_5 = musicList.AppendValues(treeLevel3_iOS, false,"Version 5","","","","",4100);
			treeLevel3_i_6 = musicList.AppendValues(treeLevel3_iOS, false,"Version 6","","","","",4100);
			treeLevel3_i_7 = musicList.AppendValues(treeLevel3_iOS, false,"Version 7","","","","",4100);
			//EMPTY!
			treeLevel3_Android = musicList.AppendValues(treeLevel2_Devices, false,"Android","","","","",5000);
			treeLevel3_A_HTC = musicList.AppendValues(treeLevel3_Android, false,"HTC","","","","",5100);
			treeLevel3_A_Samsung = musicList.AppendValues(treeLevel3_Android, false,"Samsung","","","","",5200);
			treeLevel3_A_Other = musicList.AppendValues(treeLevel3_Android, false,"Other","","","","",5300);
			treeLevel3_Other = musicList.AppendValues(treeLevel2_Devices, false,"Other","","","","",6000);
			//EMPTY!

			for(int x = 0; x < enviroBools.Length; x++){
				if(enviroOS[x] == "iOS"){
					if((enviroVersion[x].StartsWith("3"))){
						musicList.AppendValues(treeLevel3_i_3o4, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("4")){
						musicList.AppendValues(treeLevel3_i_3o4, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("5")){
						musicList.AppendValues(treeLevel3_i_5, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("6")){
						musicList.AppendValues(treeLevel3_i_6, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("7")){
						musicList.AppendValues(treeLevel3_i_7, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
				}
				else if(enviroOS[x] == "Android"){
					if(enviroManu[x] == "HTC"){
						musicList.AppendValues(treeLevel3_A_HTC, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroManu[x] == "Samsung"){
						musicList.AppendValues(treeLevel3_A_Samsung, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else{
						musicList.AppendValues(treeLevel3_A_Other, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
				}
				else{
					musicList.AppendValues(treeLevel3_Other, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
				}
			}

			EnviroTree.Model = musicList;

			myToggle = new Gtk.CellRendererToggle();
			myToggle.Activatable = true;
			myToggle.Toggled += myToggle_toggled;
			Gtk.TreeViewColumn column_toggle = new Gtk.TreeViewColumn("Toggle", myToggle, tbool);
			column_toggle.FixedWidth = 150;
			EnviroTree.AppendColumn(column_toggle);

			Gtk.CellRendererText SubGroup = new Gtk.CellRendererText();
			Gtk.TreeViewColumn subGRPCol = new Gtk.TreeViewColumn("Manufacturer", SubGroup, stext1);
			subGRPCol.Expand = true;
			EnviroTree.AppendColumn(subGRPCol);

			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn songCol = new Gtk.TreeViewColumn("Name", songNameCell, stext2);
			songCol.Expand = true;
			EnviroTree.AppendColumn(songCol);
		
			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn artistCol = new Gtk.TreeViewColumn("Type", artistNameCell, stext3);
			//EnviroTree.AppendColumn(artistCol);

			Gtk.CellRendererText OSNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn OSCol = new Gtk.TreeViewColumn("OS", OSNameCell, 4);
			//EnviroTree.AppendColumn(OSCol);

			Gtk.CellRendererText VerNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn VerCol = new Gtk.TreeViewColumn("Version", VerNameCell, 5);
			VerCol.Expand = true;
			EnviroTree.AppendColumn(VerCol);

			Gtk.CellRendererText IDNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn IDCol = new Gtk.TreeViewColumn("ID", IDNameCell, 6);
			//EnviroTree.AppendColumn(IDCol);

			column_toggle.AddAttribute(myToggle, "active", 0);
			subGRPCol.AddAttribute(SubGroup, "text", 1);
			//artistCol.AddAttribute(artistNameCell, "text", 2);
			songCol.AddAttribute(songNameCell, "text", 3);
			//OSCol.AddAttribute(OSNameCell, "text", 4);
			VerCol.AddAttribute(VerNameCell, "text", 5);
			//IDCol.AddAttribute(IDNameCell, "text", 6);

			EnviroTree.Model = musicList;
		}
	
		protected void initSetup(){
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
						//Console.WriteLine(enviroBools[testa].ToString());
						testa++;
					}
					testa = 0;

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
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

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
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

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
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

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
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

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
					enviroID = new int[words.Length];
					for(int x = 0; x < words.Length-1;x++){
						enviroID[testa] =  int.Parse(words[testa]);
						testa++;
					}
					testa = 0;

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
				int id = (int) musicList.GetValue(iter, 6);
				Console.WriteLine(@"ID number"); Console.WriteLine(id);
				Console.WriteLine(@"To string Var: "); Console.WriteLine(musicList.IterDepth(iter).ToString());
				Console.WriteLine(@"IterNChildren: "); Console.WriteLine(musicList.IterNChildren());
				Console.WriteLine(@"IterNChildren(iter): "); Console.WriteLine( musicList.IterNChildren(iter));

				if(musicList.IterNext(ref iter)){
					id = (int) musicList.GetValue(iter, 6);
					Console.WriteLine(@"ID number"); Console.WriteLine(id);
				}

				//Console.WriteLine(musicList.iter);
				*/
			}

		}
	}
}

