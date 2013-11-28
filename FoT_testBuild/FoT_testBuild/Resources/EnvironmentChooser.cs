using System;
using System.IO;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{
		Gtk.TreeStore musicList;
		Gtk.CellRendererToggle myToggle;
		Gtk.TreeIter treeLevel1_Enviroment;
		Gtk.TreeIter treeLevel2_Desktop; // Type
		Gtk.TreeIter treeLevel3_Wind; // desktop 
		Gtk.TreeIter treeLevel4_XP; // desktop  
		Gtk.TreeIter treeLevel4_Vista; // desktop  
		Gtk.TreeIter treeLevel4_7; // desktop
		Gtk.TreeIter treeLevel4_8; // desktop  
		Gtk.TreeIter treeLevel4_81; // desktop 
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
		Gtk.TreeIter treeLevel5_1; // desktop
		Gtk.TreeIter treeLevel5_2; // desktop
		Gtk.TreeIter treeLevel5_3; // desktop
		Gtk.TreeIter treeLevel5_4; // desktop
		Gtk.TreeIter treeLevel5_5; // desktop

		static int disCount; //Count (-76)
		static bool[] enviroBools;
		static string[] enviroManu;
		static string[] enviroType;
		static string[] enviroName;
		static string[] enviroOS;
		static string[] enviroVersion;
		static int[] enviroID;
		static string[] enviroFF;
		static string[] enviroSafari;
		static string[] enviroOpera;
		static string[] enviroDM;

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

			EnviroTree.RulesHint = true;


			//							toggle			Manu				type			name			OS				Version			ID
			musicList = new Gtk.TreeStore(
				typeof(bool), typeof (string),
				typeof (string), typeof (string),
				typeof (string), typeof (string),
				typeof (int), typeof (string), 
				typeof (string), typeof (string), 
				typeof (string));

			treeLevel1_Enviroment = musicList.AppendValues(false,"Environments","","","","",99999);
			treeLevel2_Desktop = musicList.AppendValues(treeLevel1_Enviroment, false,"Desktop","","","","",99999);
			treeLevel3_Wind = musicList.AppendValues(treeLevel2_Desktop, false,"Windows","","","","",99999);
			treeLevel4_XP = musicList.AppendValues(treeLevel3_Wind, false,"XP","","","","",99999);
			treeLevel4_Vista = musicList.AppendValues(treeLevel3_Wind, false,"Vista","","","","",99999);
			treeLevel4_7 = musicList.AppendValues(treeLevel3_Wind, false,"7","","","","",99999);
			treeLevel4_8 = musicList.AppendValues(treeLevel3_Wind, false,"8","","","","",99999);
			treeLevel4_81 = musicList.AppendValues(treeLevel3_Wind, false,"8.1","","","","",99999);
			treeLevel2_Devices = musicList.AppendValues(treeLevel1_Enviroment, false,"Devices","","","","",99999);
			treeLevel3_iOS = musicList.AppendValues(treeLevel2_Devices, false,"iOS","","","","",99999);
			treeLevel3_i_3o4 = musicList.AppendValues(treeLevel3_iOS, false,"Version 3 or 4","","","","",30100); 	// Enable all
			treeLevel3_i_5 = musicList.AppendValues(treeLevel3_iOS, false,"Version 5","","","","",30200);			// Enable all
			treeLevel3_i_6 = musicList.AppendValues(treeLevel3_iOS, false,"Version 6","","","","",30300);			// Enable all
			treeLevel3_i_7 = musicList.AppendValues(treeLevel3_iOS, false,"Version 7","","","","",30400);			// Enable all
			treeLevel3_Android = musicList.AppendValues(treeLevel2_Devices, false,"Android","","","","",99999);
			treeLevel3_A_HTC = musicList.AppendValues(treeLevel3_Android, false,"HTC","","","","",99999);
			treeLevel3_A_Samsung = musicList.AppendValues(treeLevel3_Android, false,"Samsung","","","","",99999);
			treeLevel3_A_Other = musicList.AppendValues(treeLevel3_Android, false,"Other","","","","",99999);
			treeLevel3_Other = musicList.AppendValues(treeLevel2_Devices, false,"Windows/BB/etc","","","","",99999);

			for(int x = 0; x < enviroBools.Length; x++){
				if(enviroManu[x] == "Windows"){
					if(enviroType[x] == "XP"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_1 = musicList.AppendValues(treeLevel4_XP, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", 40100);
						}else{
							treeLevel5_1 = musicList.AppendValues(treeLevel4_XP, enviroBools[x], enviroName[x], "", "", "", "", 40100);
						}
						musicList.AppendValues(treeLevel5_1, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroFF[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroSafari[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroOpera[x-disCount], "", "(Latest)");
						if(enviroDM[x-disCount] != "None"){
							musicList.AppendValues(treeLevel5_1, false, "Mail", enviroType[x], enviroDM[x-disCount]);
						}
					}
					else if(enviroType[x] == "Vista"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_2 = musicList.AppendValues(treeLevel4_Vista, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", 40200);
						}else{
							treeLevel5_2 = musicList.AppendValues(treeLevel4_Vista, enviroBools[x], enviroName[x], "", "", "", "", 40200);
						}
						musicList.AppendValues(treeLevel5_2, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroFF[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroSafari[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroOpera[x-disCount], "", "(Latest)");
						if(enviroDM[x-disCount] != "None"){
							musicList.AppendValues(treeLevel5_2, false, "Mail", enviroType[x], enviroDM[x-disCount]);
						}
					}
					else if(enviroType[x] == "7"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_3 = musicList.AppendValues(treeLevel4_7, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", 40300);
						}else{
							treeLevel5_3 = musicList.AppendValues(treeLevel4_7, enviroBools[x], enviroName[x], "", "", "", "", 40300);
						}
						musicList.AppendValues(treeLevel5_3, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroFF[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroSafari[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroOpera[x-disCount], "", "(Latest)");
						if(enviroDM[x-disCount] != "None"){
							musicList.AppendValues(treeLevel5_3, false, "Mail", enviroType[x], enviroDM[x-disCount]);
						}
					}
					else if(enviroType[x] == "8"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_4 = musicList.AppendValues(treeLevel4_8, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", 40400);
						}else{
							treeLevel5_4 = musicList.AppendValues(treeLevel4_8, enviroBools[x], enviroName[x], "", "", "", "", 40400);
						}
						musicList.AppendValues(treeLevel5_4, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroFF[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroSafari[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroOpera[x-disCount], "", "(Latest)");
						if(enviroDM[x-disCount] != "None"){
							musicList.AppendValues(treeLevel5_4, false, "Mail", enviroType[x], enviroDM[x-disCount]);
						}
					}//treeLevel4_8
					else if(enviroType[x] == "8.1"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_5 = musicList.AppendValues(treeLevel4_81, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", 40500);
						}else{
							treeLevel5_5 = musicList.AppendValues(treeLevel4_81, enviroBools[x], enviroName[x], "", "", "", "", 40500);
						}
						musicList.AppendValues(treeLevel5_5, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroFF[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroSafari[x-disCount], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroOpera[x-disCount], "", "(Latest)");
						if(enviroDM[x-disCount] != "None"){
							musicList.AppendValues(treeLevel5_5, false, "Mail", enviroType[x], enviroDM[x-disCount]);
						}
					}
				}
				else if(enviroOS[x] == "iOS"){
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
			myToggle.CellBackground = "light blue";
			Gtk.TreeViewColumn column_toggle = new Gtk.TreeViewColumn("Toggle", myToggle, tbool);
			column_toggle.FixedWidth = 150;
			EnviroTree.AppendColumn(column_toggle);

			Gtk.CellRendererText SubGroup = new Gtk.CellRendererText();
			SubGroup.CellBackground = "light blue";
			Gtk.TreeViewColumn subGRPCol = new Gtk.TreeViewColumn("Manufacturer", SubGroup, stext1);
			subGRPCol.Expand = true;
			EnviroTree.AppendColumn(subGRPCol);

			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			songNameCell.CellBackground = "light blue";
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
			VerNameCell.CellBackground = "light blue";
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

			EnviroTree.RulesHint = true;

			EnviroTree.Model = musicList;
			EnviroTree.ExpandRow(musicList.GetPath(treeLevel1_Enviroment), false);
			//EnviroTree.ExpandRow(musicList.GetPath(temp), false);
		}
	
		protected void initSetup(){
			enviroPath = Environment.CurrentDirectory + @"\Resources\AndroidEnviro.txt";
			readFile();
			enviroPath = Environment.CurrentDirectory + @"\Resources\DesktopEnviro.txt";
			readFile_Desktop();
			return;
		}

		#region filereader

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
					enviroBools = new bool[words.Length];
					for(int x = 0; x < words.Length-1;x++){
						enviroBools[testa] = Boolean.Parse(words[testa]);
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


					for(int x = 0; x < words.Length;x++){
						enviroID[x] =  int.Parse(words[x]);
						//testa++;
					}
					//testa = 0;

				}
			}

			file.Close();

			disCount = enviroBools.Length;
			Console.WriteLine(disCount);

			return;
		}

		protected void readFile_Desktop(){
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
					int count2 = enviroBools.Length;

					int count = (words.Length + enviroBools.Length);
					Array.Resize(ref enviroBools, count);

					for(int x = count2; x < count-1; x++){
						enviroBools[x] = Boolean.Parse(words[testa]);
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Platform")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					int count2 = enviroManu.Length;

					int count = (enviroManu.Length + words.Length);
					Array.Resize(ref enviroManu, count);

					for(int x = count2; x < count-1; x++){
						enviroManu[x] = words[testa].Trim();
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
					int count2 = enviroType.Length;

					int count = (enviroType.Length + words.Length);
					Array.Resize(ref enviroType, count);

					for(int x = count2; x < count-1; x++){
						enviroType[x] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**SP")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					int count2 = enviroName.Length;

					int count = (enviroName.Length + words.Length);
					Array.Resize(ref enviroName, count);

					for(int x = count2; x < count-1; x++){
						enviroName[x] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**IE")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					int count2 = enviroOS.Length;

					int count = (enviroOS.Length + words.Length);
					Array.Resize(ref enviroOS, count);

					for(int x = count2; x < count-1; x++){
						enviroOS[x] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Chrome")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);
					int count2 = enviroVersion.Length;

					int count = (enviroVersion.Length + words.Length);
					Array.Resize(ref enviroVersion, count);

					for(int x = count2; x < count-1; x++){
						enviroVersion[x] = words[testa].Trim();
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
					int count2 = enviroID.Length;

					int count = (enviroID.Length + words.Length);
					Array.Resize(ref enviroID, count);

					for(int x = count2; x < count; x++){
						enviroID[x] = int.Parse(words[testa]);
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Firefox")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);

					enviroFF = new string[words.Length];
					enviroFF = words;

					foreach(string word in enviroFF){
						enviroFF[testa] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Safari")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);

					enviroSafari = new string[words.Length];
					enviroSafari = words;

					foreach(string word in enviroSafari){
						enviroSafari[testa] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**Opera")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);

					enviroOpera = new string[words.Length];
					enviroOpera = words;

					foreach(string word in enviroOpera){
						enviroOpera[testa] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
				if(line.Contains(@"**DM")){
					search = line;
					string[] words = search.Split(new char[]{'&', '*'}, StringSplitOptions.RemoveEmptyEntries);
					for(int a = 0; a < words.Length -1; a++){
						words[a] = words[a+1];
					}

					Array.Resize(ref words, words.Length -1);

					enviroDM = new string[words.Length];
					enviroDM = words;

					foreach(string word in enviroDM){
						enviroDM[testa] = words[testa].Trim();
						testa++;
					}
					testa = 0;
				}
			}

			file.Close();

			//disCount = enviroBools.Length;
			//Console.WriteLine(disCount);

			return;
		}

		#endregion

		protected void myToggle_toggled (object o, ToggledArgs args)
		{
			TreeIter iter;
			if(musicList.GetIter(out iter, new TreePath(args.Path))){
				int idNumber = (int) musicList.GetValue(iter, 6);
				if(idNumber != 99999){
					bool old = (bool) musicList.GetValue(iter, 0);
					musicList.SetValue(iter, 0, !old);

					int id = (int) musicList.GetValue(iter, 6);

					for(int x = 0; x < enviroBools.Length; x++){
						if(enviroID[x] == id){
							enviroBools[x] = !old;
							return;
						}
					}
				}
			}
		}

		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			for(int x = 0; x < enviroBools.Length; x++){
				if(enviroBools[x] == true){
					if(enviroType[x] == "Handset"){
						textview1.Buffer.Text += (@"Handset: " +  enviroName[x] + " - " + enviroVersion[x] + "\n");
					}
					else if(enviroType[x] == "Tablet"){
						textview1.Buffer.Text += (@"Tablet: " +  enviroName[x] + " - " + enviroVersion[x] + "\n");
					}
					else{

					}
				}

				//temp
				enviroBools[x] = false;
			}
		}

		//<param> quit </param>
		protected void OnButton1Clicked (object sender, EventArgs e){
			Destroy();
			return;
		}

		//<param> Untick all </param>
		protected void OnButton2Clicked (object sender, EventArgs e){
			EnviroTree.Model.Foreach((model, path, iter) => {
				musicList.SetValue(iter, 0, false);
				return false;
			});

			for(int x = 0; x < (enviroBools.Length -1); x++){
				enviroBools[x] = false; 
			}
		}
		
	}
}

