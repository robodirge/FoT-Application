using System;
using System.IO;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{
		Gtk.TreeStore enviroStore;
		Gtk.TreeStore selectedStore;
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

		Gtk.TreeIter selTreeLevel1;
		Gtk.TreeIter selDesktopLevel2;
		Gtk.TreeIter selWindowLeve3;


		static int disCount; //Count (-76)
		static int previousCount;
		static bool enabletree;
		static bool enabletreedesktop;
		static bool enabletreewindows;

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
		static bool[] inList;

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
			enviroStore = new Gtk.TreeStore(
				typeof(bool), typeof (string),
				typeof (string), typeof (string),
				typeof (string), typeof (string),
				typeof (int), typeof (string), 
				typeof (string), typeof (string), 
				typeof (string));

			treeLevel1_Enviroment = enviroStore.AppendValues(false,"Environments","","","","",99999);
			treeLevel2_Desktop = enviroStore.AppendValues(treeLevel1_Enviroment, false,"Desktop","","","","",99999);
			treeLevel3_Wind = enviroStore.AppendValues(treeLevel2_Desktop, false,"Windows","","","","",99999);
			treeLevel4_XP = enviroStore.AppendValues(treeLevel3_Wind, false,"XP","","","","",99999);
			treeLevel4_Vista = enviroStore.AppendValues(treeLevel3_Wind, false,"Vista","","","","",99999);
			treeLevel4_7 = enviroStore.AppendValues(treeLevel3_Wind, false,"7","","","","",99999);
			treeLevel4_8 = enviroStore.AppendValues(treeLevel3_Wind, false,"8","","","","",99999);
			treeLevel4_81 = enviroStore.AppendValues(treeLevel3_Wind, false,"8.1","","","","",99999);
			treeLevel2_Devices = enviroStore.AppendValues(treeLevel1_Enviroment, false,"Devices","","","","",99999);
			treeLevel3_iOS = enviroStore.AppendValues(treeLevel2_Devices, false,"iOS","","","","",99999);
			treeLevel3_i_3o4 = enviroStore.AppendValues(treeLevel3_iOS, false,"Version 3 or 4","","","","",30100); 	// Enable all
			treeLevel3_i_5 = enviroStore.AppendValues(treeLevel3_iOS, false,"Version 5","","","","",30200);			// Enable all
			treeLevel3_i_6 = enviroStore.AppendValues(treeLevel3_iOS, false,"Version 6","","","","",30300);			// Enable all
			treeLevel3_i_7 = enviroStore.AppendValues(treeLevel3_iOS, false,"Version 7","","","","",30400);			// Enable all
			treeLevel3_Android = enviroStore.AppendValues(treeLevel2_Devices, false,"Android","","","","",99999);
			treeLevel3_A_HTC = enviroStore.AppendValues(treeLevel3_Android, false,"HTC","","","","",99999);
			treeLevel3_A_Samsung = enviroStore.AppendValues(treeLevel3_Android, false,"Samsung","","","","",99999);
			treeLevel3_A_Other = enviroStore.AppendValues(treeLevel3_Android, false,"Other","","","","",99999);
			treeLevel3_Other = enviroStore.AppendValues(treeLevel2_Devices, false,"Windows/BB/etc","","","","",99999);

			inList = new bool[enviroBools.Length];
			inList = enviroBools;

			int XPID = 41000;
			int VIID = 42000;
			int W7ID = 43000;
			int W8ID = 44000;
			int W81ID = 45000;
			previousCount = enviroID.Length -1;
			int count = 0;
			int currentSize = enviroID.Length-1;

			for(int x = 0; x < enviroBools.Length; x++){
				if(enviroManu[x] == "Windows"){
					if(enviroType[x] == "XP"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_1 = enviroStore.AppendValues(treeLevel4_XP, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", XPID);
						}else{
							treeLevel5_1 = enviroStore.AppendValues(treeLevel4_XP, enviroBools[x], enviroName[x], "", "", "", "", XPID);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else
							count = 5;

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						enviroStore.AppendValues(treeLevel5_1, false, enviroOS[x], "", "(Latest)",  "", "", XPID+1);
						enviroID[++currentSize] = XPID+1;
						enviroStore.AppendValues(treeLevel5_1, false, enviroVersion[x], "", "(Latest)",  "", "", XPID+2);
						enviroID[++currentSize] = XPID+2;
						enviroStore.AppendValues(treeLevel5_1, false, enviroFF[x-disCount], "", "(Latest)",  "", "", XPID+3);
						enviroID[++currentSize] = XPID+3;
						enviroStore.AppendValues(treeLevel5_1, false, enviroSafari[x-disCount], "", "(Latest)",  "", "", XPID+4);
						enviroID[++currentSize] = XPID+4;
						enviroStore.AppendValues(treeLevel5_1, false, enviroOpera[x-disCount], "", "(Latest)",  "", "", XPID+5);
						enviroID[++currentSize] = XPID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_1, false, "Mail", enviroType[x], enviroDM[x-disCount],  "", "", XPID+6);	
							enviroID[++currentSize] = XPID+6;	
						}

						XPID += 10; 
					}
					else if(enviroType[x] == "Vista"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_2 = enviroStore.AppendValues(treeLevel4_Vista, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", VIID);
						}else{
							treeLevel5_2 = enviroStore.AppendValues(treeLevel4_Vista, enviroBools[x], enviroName[x], "", "", "", "", VIID);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else
							count = 5;

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						enviroStore.AppendValues(treeLevel5_2, false, enviroOS[x], "", "(Latest)",  "", "", VIID+1);
						enviroID[++currentSize] = VIID+1;
						enviroStore.AppendValues(treeLevel5_2, false, enviroVersion[x], "", "(Latest)",  "", "", VIID+2);
						enviroID[++currentSize] = VIID+2;
						enviroStore.AppendValues(treeLevel5_2, false, enviroFF[x-disCount], "", "(Latest)",  "", "", VIID+3);
						enviroID[++currentSize] = VIID+3;
						enviroStore.AppendValues(treeLevel5_2, false, enviroSafari[x-disCount], "", "(Latest)",  "", "", VIID+4);
						enviroID[++currentSize] = VIID+4;
						enviroStore.AppendValues(treeLevel5_2, false, enviroOpera[x-disCount], "", "(Latest)",  "", "", VIID+5);
						enviroID[++currentSize] = VIID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_2, false, "Mail", enviroType[x], enviroDM[x-disCount],  "", "", VIID+6);
							enviroID[++currentSize] = VIID+6;
						}


						VIID +=10;
					}
					else if(enviroType[x] == "7"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_3 = enviroStore.AppendValues(treeLevel4_7, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", W7ID);
						}else{
							treeLevel5_3 = enviroStore.AppendValues(treeLevel4_7, enviroBools[x], enviroName[x], "", "", "", "", W7ID);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else
							count = 5;

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						enviroStore.AppendValues(treeLevel5_3, false, enviroOS[x], "", "(Latest)",  "", "", W7ID+1);
						enviroID[++currentSize] = W7ID+1;
						enviroStore.AppendValues(treeLevel5_3, false, enviroVersion[x], "", "(Latest)",  "", "", W7ID+2);
						enviroID[++currentSize] = W7ID+2;
						enviroStore.AppendValues(treeLevel5_3, false, enviroFF[x-disCount], "", "(Latest)",  "", "", W7ID+3);
						enviroID[++currentSize] = W7ID+3;
						enviroStore.AppendValues(treeLevel5_3, false, enviroSafari[x-disCount], "", "(Latest)",  "", "", W7ID+4);
						enviroID[++currentSize] = W7ID+4;
						enviroStore.AppendValues(treeLevel5_3, false, enviroOpera[x-disCount], "", "(Latest)",  "", "", W7ID+5);
						enviroID[++currentSize] = W7ID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_3, false, "Mail", enviroType[x], enviroDM[x-disCount],  "", "", W7ID+6);
							enviroID[++currentSize] = W7ID+6;
						}

						W7ID +=10;
					}
					else if(enviroType[x] == "8"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_4 = enviroStore.AppendValues(treeLevel4_8, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", W8ID);
						}else{
							treeLevel5_4 = enviroStore.AppendValues(treeLevel4_8, enviroBools[x], enviroName[x], "", "", "", "", W8ID);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else
							count = 5;

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						enviroStore.AppendValues(treeLevel5_4, false, enviroOS[x], "", "(Latest)",  "", "", W8ID+1);
						enviroID[++currentSize] = W8ID+1;
						enviroStore.AppendValues(treeLevel5_4, false, enviroVersion[x], "", "(Latest)",  "", "", W8ID+2);
						enviroID[++currentSize] = W8ID+2;
						enviroStore.AppendValues(treeLevel5_4, false, enviroFF[x-disCount], "", "(Latest)",  "", "", W8ID+3);
						enviroID[++currentSize] = W8ID+3;
						enviroStore.AppendValues(treeLevel5_4, false, enviroSafari[x-disCount], "", "(Latest)",  "", "", W8ID+4);
						enviroID[++currentSize] = W8ID+4;
						enviroStore.AppendValues(treeLevel5_4, false, enviroOpera[x-disCount], "", "(Latest)",  "", "", W8ID+5);
						enviroID[++currentSize] = W8ID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_4, false, "Mail", enviroType[x], enviroDM[x-disCount],  "", "", W8ID+6);
							enviroID[++currentSize] = W8ID+6;
						}

						W8ID +=10;
					}//treeLevel4_8
					else if(enviroType[x] == "8.1"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel5_5 = enviroStore.AppendValues(treeLevel4_81, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", W81ID);
						}else{
							treeLevel5_5 = enviroStore.AppendValues(treeLevel4_81, enviroBools[x], enviroName[x], "", "", "", "", W81ID);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else
							count = 5;

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						enviroStore.AppendValues(treeLevel5_5, false, enviroOS[x], "", "(Latest)",  "", "", W81ID+1);
						enviroID[++currentSize] = W81ID+1;
						enviroStore.AppendValues(treeLevel5_5, false, enviroVersion[x], "", "(Latest)",  "", "", W81ID+2);
						enviroID[++currentSize] = W81ID+2;
						enviroStore.AppendValues(treeLevel5_5, false, enviroFF[x-disCount], "", "(Latest)",  "", "", W81ID+3);
						enviroID[++currentSize] = W81ID+3;
						enviroStore.AppendValues(treeLevel5_5, false, enviroSafari[x-disCount], "", "(Latest)",  "", "", W81ID+4);
						enviroID[++currentSize] = W81ID+4;
						enviroStore.AppendValues(treeLevel5_5, false, enviroOpera[x-disCount], "", "(Latest)",  "", "", W81ID+5);
						enviroID[++currentSize] = W81ID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_5, false, "Mail", enviroType[x], enviroDM[x-disCount],  "", "", W81ID+6);
							enviroID[++currentSize] = W81ID+6;
						}

						W81ID +=10;
					}
				}
				else if(enviroOS[x] == "iOS"){
					if((enviroVersion[x].StartsWith("3"))){
						enviroStore.AppendValues(treeLevel3_i_3o4, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("4")){
						enviroStore.AppendValues(treeLevel3_i_3o4, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("5")){
						enviroStore.AppendValues(treeLevel3_i_5, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("6")){
						enviroStore.AppendValues(treeLevel3_i_6, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroVersion[x].StartsWith("7")){
						enviroStore.AppendValues(treeLevel3_i_7, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
				}
				else if(enviroOS[x] == "Android"){
					if(enviroManu[x] == "HTC"){
						enviroStore.AppendValues(treeLevel3_A_HTC, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else if(enviroManu[x] == "Samsung"){
						enviroStore.AppendValues(treeLevel3_A_Samsung, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
					else{
						enviroStore.AppendValues(treeLevel3_A_Other, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
					}
				}
				else{
					enviroStore.AppendValues(treeLevel3_Other, enviroBools[x], enviroManu[x], enviroType[x], enviroName[x], enviroOS[x], enviroVersion[x], enviroID[x]);
				}
			}

			EnviroTree.Model = enviroStore;

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
			EnviroTree.Model = enviroStore;
			EnviroTree.ExpandRow(enviroStore.GetPath(treeLevel1_Enviroment), false);
		}
	
		protected void initSetup(){
			enviroPath = Environment.CurrentDirectory + @"\Resources\AndroidEnviro.txt";
			readFile();
			enviroPath = Environment.CurrentDirectory + @"\Resources\DesktopEnviro.txt";
			readFile_Desktop();
			enabletree = false;
			enabletreedesktop = false;
			enabletreewindows = false;
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
					}
				}
			}

			file.Close();

			disCount = enviroBools.Length;
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
					int count2 = enviroType.Length;

					int count = (enviroType.Length + words.Length);
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
					int count2 = enviroName.Length;

					int count = (enviroName.Length + words.Length);
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
					int count2 = enviroOS.Length;

					int count = (enviroOS.Length + words.Length);
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
					int count2 = enviroVersion.Length;

					int count = (enviroVersion.Length + words.Length);
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
			return;
		}

		#endregion

		protected void myToggle_toggled (object o, ToggledArgs args)
		{
			TreeIter iter;
			if(enviroStore.GetIter(out iter, new TreePath(args.Path))){
				int idNumber = (int) enviroStore.GetValue(iter, 6);
				if(idNumber != 99999){
					bool old = (bool) enviroStore.GetValue(iter, 0);
					enviroStore.SetValue(iter, 0, !old);
				}
			}
		}

		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			if(!enabletree)
				StartTreetwo();

			int loop = 0;
			int count = 0;
			int posNum = 99999;

				EnviroTree.Model.Foreach((model, path, iter) => {
				bool selected = (bool) enviroStore.GetValue(iter, 0);
				if(selected){
					int idNumber = (int) enviroStore.GetValue(iter, 6);
					//Console.WriteLine(idNumber);
					if(idNumber != 99999){
						//Console.WriteLine("----");Console.WriteLine(enviroID.Length);
						for(int count2 = 0; count2 < enviroID.Length ; count2++){
							if(enviroID[count2] == idNumber){
								posNum = count2;
								//Console.WriteLine("found!");
								break;
							}
						}

						Console.WriteLine(posNum);

						if(posNum != 99999){
							//Console.WriteLine("Enter!");
							if(inList[posNum] == false){
								//Console.WriteLine("Enter222!");
								if((idNumber > 4000) && ( idNumber < 99999)){
									if(!enabletreedesktop){
										//selectedStore.AppendValues(selDesktopLevel2, "Desktop", "", 99999);
										selDesktopLevel2 = selectedStore.AppendValues(selTreeLevel1, "Desktop","",99999);
										enabletreedesktop = true;
									}

									if(!enabletreewindows){
										//selectedStore.AppendValues(selWindowLeve3, "Windows", "", 99999);
										selWindowLeve3 = selectedStore.AppendValues(selDesktopLevel2, "Windows","",99999);
										enabletreewindows = true;
									}

									string nameType = (string) enviroStore.GetValue(iter, 1);

									if((idNumber > 41000)&&(idNumber < 42000)){
										selectedStore.AppendValues(selWindowLeve3, "XP: ", nameType + " (Latest)");
										//selTreeLevel1 = selectedStore.AppendValues("Selected","",99999);
										//textview1.Buffer.Text += (@"XP: " +  nameType + " (Latest)" + "\n");
									}
									if((idNumber > 42000)&&(idNumber < 43000)){
										//Console.WriteLine("Vista: " + nameType);
										textview1.Buffer.Text += (@"Vista: " +  nameType + " (Latest)" + "\n");
									}
									if((idNumber > 43000)&&(idNumber < 44000)){
										//Console.WriteLine("Win7: " + nameType);
										textview1.Buffer.Text += (@"Win7: " +  nameType + " (Latest)" + "\n");
									}
									if((idNumber > 44000)&&(idNumber < 45000)){
										//Console.WriteLine("Win8: " + nameType);
										textview1.Buffer.Text += (@"Win8: " +  nameType + " (Latest)" + "\n");
									}
									if((idNumber > 45000)&&(idNumber < 46000)){
										//Console.WriteLine("Win8.1: " + nameType);
										textview1.Buffer.Text += (@"Win8.1: " +  nameType + " (Latest)" + "\n");
									}
									inList[posNum] = true;
								}else{
									if(enviroType[posNum] == "Handset"){
										textview1.Buffer.Text += (@"Handset: " +  enviroName[posNum] + " (" + enviroVersion[posNum] + ")" + "\n");
									}
									else if(enviroType[posNum] == "Tablet"){
										textview1.Buffer.Text += (@"Tablet: " +  enviroName[posNum] + " (" + enviroVersion[posNum] + ")" + "\n");
									}
									else{
										textview1.Buffer.Text += (@"Something: " +  enviroName[posNum] + " ("  + enviroVersion[posNum] + ")" + "\n");
									}
									inList[posNum] = true;
								}
							}
						}
					}
					loop++;
				}
				count++;
				return false;
				});


			Console.WriteLine(loop);
		}

		protected void StartTreetwo(){
			selectedStore = new Gtk.TreeStore(typeof (string), typeof (string), typeof (int));
			selTreeLevel1 = selectedStore.AppendValues("Selected","",99999);

			Gtk.CellRendererText SelRT1 = new Gtk.CellRendererText();
			SelRT1.CellBackground = "light blue";
			Gtk.TreeViewColumn SelCol1 = new Gtk.TreeViewColumn("Manufacturer", SelRT1, 0);
			SelCol1.Expand = true;
			selTree.AppendColumn(SelCol1);

			Gtk.CellRendererText SelRT2 = new Gtk.CellRendererText();
			SelRT2.CellBackground = "light blue";
			Gtk.TreeViewColumn SelCol2 = new Gtk.TreeViewColumn("Name", SelRT2, 1);
			SelCol2.Expand = true;
			selTree.AppendColumn(SelCol2);

			SelCol1.AddAttribute(SelRT1, "text", 0);
			SelCol2.AddAttribute(SelRT2, "text", 1);

			selTree.Model = selectedStore;

			enabletree = true;
			return;
		}

		//<param> quit </param>
		protected void OnButton1Clicked (object sender, EventArgs e){
			Destroy();
			return;
		}

		//<param> Untick all </param>
		protected void OnButton2Clicked (object sender, EventArgs e){
			EnviroTree.Model.Foreach((model, path, iter) => {
				enviroStore.SetValue(iter, 0, false);
				return false;
			});
		}	
	}
}

