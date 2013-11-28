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
		//Gtk.TreeIter tempX;


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



			treeLevel1_Enviroment = musicList.AppendValues(false,"Environments","","","","",1000);
			treeLevel2_Desktop = musicList.AppendValues(treeLevel1_Enviroment, false,"Desktop","","","","",2000);
			treeLevel3_Wind = musicList.AppendValues(treeLevel2_Desktop, false,"Windows","","","","",2100);
			treeLevel4_XP = musicList.AppendValues(treeLevel3_Wind, false,"XP","","","","",2110);
			treeLevel4_Vista = musicList.AppendValues(treeLevel3_Wind, false,"Vista","","","","",2120);
			treeLevel4_7 = musicList.AppendValues(treeLevel3_Wind, false,"7","","","","",2130);
			treeLevel4_8 = musicList.AppendValues(treeLevel3_Wind, false,"8","","","","",2140);
			treeLevel4_81 = musicList.AppendValues(treeLevel3_Wind, false,"8.1","","","","",2150);
			treeLevel2_Devices = musicList.AppendValues(treeLevel1_Enviroment, false,"Devices","","","","",3000);
			treeLevel3_iOS = musicList.AppendValues(treeLevel2_Devices, false,"iOS","","","","",4000);
			treeLevel3_i_3o4 = musicList.AppendValues(treeLevel3_iOS, false,"Version 3 or 4","","","","",4100);
			treeLevel3_i_5 = musicList.AppendValues(treeLevel3_iOS, false,"Version 5","","","","",4100);
			treeLevel3_i_6 = musicList.AppendValues(treeLevel3_iOS, false,"Version 6","","","","",4100);
			treeLevel3_i_7 = musicList.AppendValues(treeLevel3_iOS, false,"Version 7","","","","",4100);
			treeLevel3_Android = musicList.AppendValues(treeLevel2_Devices, false,"Android","","","","",5000);
			treeLevel3_A_HTC = musicList.AppendValues(treeLevel3_Android, false,"HTC","","","","",5100);
			treeLevel3_A_Samsung = musicList.AppendValues(treeLevel3_Android, false,"Samsung","","","","",5200);
			treeLevel3_A_Other = musicList.AppendValues(treeLevel3_Android, false,"Other","","","","",5300);
			treeLevel3_Other = musicList.AppendValues(treeLevel2_Devices, false,"Windows/BB/etc","","","","",6000);

			for(int x = 0; x < enviroBools.Length; x++){
				if(enviroManu[x] == "Windows"){
					if(enviroType[x] == "XP"){
						//Gtk.TreeIter tempX;
						if(enviroDM[x-77] != "None"){
							treeLevel5_1 = musicList.AppendValues(treeLevel4_XP, enviroBools[x], (enviroName[x] + " " + enviroDM[x-77]));
						}else{
							treeLevel5_1 = musicList.AppendValues(treeLevel4_XP, enviroBools[x], enviroName[x]);
						}
						musicList.AppendValues(treeLevel5_1, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroFF[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroSafari[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_1, false, enviroOpera[x-77], "", "(Latest)");
						if(enviroDM[x-77] != "None"){
							musicList.AppendValues(treeLevel5_1, false, "Mail", enviroType[x], enviroDM[x-77]);
						}
					}
					else if(enviroType[x] == "Vista"){
						//Gtk.TreeIter tempX;
						if(enviroDM[x-77] != "None"){
							treeLevel5_2 = musicList.AppendValues(treeLevel4_Vista, enviroBools[x], (enviroName[x] + " " + enviroDM[x-77]));
						}else{
							treeLevel5_2 = musicList.AppendValues(treeLevel4_Vista, enviroBools[x], enviroName[x]);
						}
						musicList.AppendValues(treeLevel5_2, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroFF[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroSafari[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_2, false, enviroOpera[x-77], "", "(Latest)");
						if(enviroDM[x-77] != "None"){
							musicList.AppendValues(treeLevel5_2, false, "Mail", enviroType[x], enviroDM[x-77]);
						}
					}
					else if(enviroType[x] == "7"){
						//Gtk.TreeIter tempX;
						if(enviroDM[x-77] != "None"){
							treeLevel5_3 = musicList.AppendValues(treeLevel4_7, enviroBools[x], (enviroName[x] + " " + enviroDM[x-77]));
						}else{
							treeLevel5_3 = musicList.AppendValues(treeLevel4_7, enviroBools[x], enviroName[x]);
						}
						musicList.AppendValues(treeLevel5_3, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroFF[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroSafari[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_3, false, enviroOpera[x-77], "", "(Latest)");
						if(enviroDM[x-77] != "None"){
							musicList.AppendValues(treeLevel5_3, false, "Mail", enviroType[x], enviroDM[x-77]);
						}
					}
					else if(enviroType[x] == "8"){
						//Gtk.TreeIter tempX;
						if(enviroDM[x-77] != "None"){
							treeLevel5_4 = musicList.AppendValues(treeLevel4_8, enviroBools[x], (enviroName[x] + " " + enviroDM[x-77]));
						}else{
							treeLevel5_4 = musicList.AppendValues(treeLevel4_8, enviroBools[x], enviroName[x]);
						}
						musicList.AppendValues(treeLevel5_4, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroFF[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroSafari[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_4, false, enviroOpera[x-77], "", "(Latest)");
						if(enviroDM[x-77] != "None"){
							musicList.AppendValues(treeLevel5_4, false, "Mail", enviroType[x], enviroDM[x-77]);
						}
					}//treeLevel4_8
					else if(enviroType[x] == "8.1"){
						//Gtk.TreeIter tempX;
						if(enviroDM[x-77] != "None"){
							treeLevel5_5 = musicList.AppendValues(treeLevel4_81, enviroBools[x], (enviroName[x] + " " + enviroDM[x-77]));
						}else{
							treeLevel5_5 = musicList.AppendValues(treeLevel4_81, enviroBools[x], enviroName[x]);
						}
						musicList.AppendValues(treeLevel5_5, false, enviroOS[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroVersion[x], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroFF[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroSafari[x-77], "", "(Latest)");
						musicList.AppendValues(treeLevel5_5, false, enviroOpera[x-77], "", "(Latest)");
						if(enviroDM[x-77] != "None"){
							musicList.AppendValues(treeLevel5_5, false, "Mail", enviroType[x], enviroDM[x-77]);
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
					int count2 = (enviroBools.Length -1);
					int count = enviroBools.Length;
					count  += (words.Length);
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

					/////////////

					Array.Resize(ref words, words.Length -1);
					int count2 = (enviroManu.Length -1);
					int count = enviroManu.Length -1;
					count  += (words.Length);
					Array.Resize(ref enviroManu, count);

					for(int x = count2; x < count; x++){
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
					int count2 = (enviroType.Length -1);
					int count = enviroType.Length -1;
					count  += (words.Length);
					Array.Resize(ref enviroType, count);

					for(int x = count2; x < count; x++){
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
					int count2 = (enviroName.Length -1);
					int count = enviroName.Length -1;
					count  += (words.Length);
					Array.Resize(ref enviroName, count);

					for(int x = count2; x < count; x++){
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
					int count2 = (enviroOS.Length -1);
					int count = enviroOS.Length -1;
					count  += (words.Length);
					Array.Resize(ref enviroOS, count);

					for(int x = count2; x < count; x++){
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
					int count2 = (enviroVersion.Length -1);
					int count = enviroVersion.Length -1;
					count  += (words.Length);
					Array.Resize(ref enviroVersion, count);

					for(int x = count2; x < count; x++){
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
					int count2 = (enviroID.Length -1);
					int count = enviroID.Length -1;
					count  += (words.Length);
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
					enviroFF = new string[words.Length-1];
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
					enviroSafari = new string[words.Length-1];
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
					enviroOpera = new string[words.Length-1];
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
					enviroDM = new string[words.Length-1];
					enviroDM = words;

					foreach(string word in enviroDM){
						enviroDM[testa] = words[testa].Trim();
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

				//get 6
				int id = (int) musicList.GetValue(iter, 6);

				for(int x = 0; x < enviroBools.Length; x++){
					if(enviroID[x] == id){
						enviroBools[x] = !old;
						return;
					}
				}
			}
		}

		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			for(int x = 0; x < enviroBools.Length; x++){
				//enviroBools[x]

				//EnviroMegaList.Text += 
				if(enviroBools[x] == true){
					if(enviroType[x] == "Handset"){
						 //TextView.Text += (@"Handset: " +  enviroName[x] + " - " + enviroVersion[x]);
						textview1.Buffer.Text += (@"Handset: " +  enviroName[x] + " - " + enviroVersion[x] + "\n");
					}
					else if(enviroType[x] == "Tablet"){
						textview1.Buffer.Text += (@"Tablet: " +  enviroName[x] + " - " + enviroVersion[x] + "\n");
					}
					else {

					}
				}

				//temp
				enviroBools[x] = false;
			}
		}

		protected void OnButton1Clicked (object sender, EventArgs e){
			return;
		}

		protected void OnButton2Clicked (object sender, EventArgs e){
			//TreeIter iter;
			/*
			musicList.GetIter(out iter,musicList.GetPath(treeLevel1_Enviroment));
			musicList.SetValue(iter, 0, false);

			musicList.GetIter(out iter,musicList.GetPath(treeLevel2_Devices));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel2_Desktop));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_Android));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_iOS));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_Other));
			musicList.SetValue(iter, 0, false);


			musicList.GetIter(out iter,musicList.GetPath(treeLevel4_Vista));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel4_7));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel4_8));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel4_81));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_A_HTC));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_A_Samsung));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_A_Other));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_i_3o4));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_i_5));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_i_6));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_i_7));
			musicList.SetValue(iter, 0, false);


			musicList.GetIter(out iter,musicList.GetPath(treeLevel2_Desktop));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel3_Wind));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel4_XP));
			musicList.SetValue(iter, 0, false);
			musicList.GetIter(out iter,musicList.GetPath(treeLevel5_1));
			*/

			//iter = treeLevel1_Enviroment;
		

			EnviroTree.Model.Foreach((model, path, iter) => {
				musicList.SetValue(iter, 0, false);
				return false;
			});

			/*
			musicList.GetIter(out iter,musicList.GetPath(treeLevel1_Enviroment));
			musicList.SetValue(iter, 0, false);
			Console.WriteLine(musicList.IterDepth(iter));
			if(musicList.IterHasChild(iter)){
				Console.WriteLine("Yes");
				Console.WriteLine(musicList.IterNChildren(iter));
				if(musicList.IterNthChild(out iter, 0)){
					Console.WriteLine("Yes 0");
					Console.WriteLine(musicList.IterDepth(iter));
					musicList.SetValue(iter, 0, false);
				}
				if(musicList.IterNthChild(out iter, 1))
					Console.WriteLine("Yes 1");
				if(musicList.IterNthChild(out iter, 2))
					Console.WriteLine("Yes 2");
			}
			*/


			//musicList.SetValue(iter, 0, false);
			//musicList.IterNext(ref treeLevel4_XP);
			//musicList.SetValue(iter, 0, false);
			//musicList.IterNext(ref treeLevel4_XP);
			//musicList.SetValue(iter, 0, false);


			/*
			musicList.GetIter(out iter,musicList.GetPath(treeLevel5_2));
			musicList.SetValue(iter, 0, false);
			musicList.IterChildren(out treeLevel5_2);
			musicList.SetValue(iter, 0, false);
			musicList.IterNext(ref treeLevel5_2);
			musicList.SetValue(iter, 0, false);
			*/
			//	}


		}
		
	}
}

