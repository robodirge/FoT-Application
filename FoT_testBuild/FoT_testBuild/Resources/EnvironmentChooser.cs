using System;
using System.IO;
using Gtk;

namespace FoT
{

	public partial class EnvironmentChooser : Gtk.Window
	{
		#region Globals

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

		Gtk.TreeIter treeLevel3_OSX; // desktop 
		Gtk.TreeIter treeLevel4_105; // desktop  
		Gtk.TreeIter treeLevel4_106; // desktop  
		Gtk.TreeIter treeLevel4_107; // desktop
		Gtk.TreeIter treeLevel4_108; // desktop  
		Gtk.TreeIter treeLevel4_109; // desktop 


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
		Gtk.TreeIter selWindowXPLeve4;
		Gtk.TreeIter selWindowVistaLeve4;
		Gtk.TreeIter selWindowWin7Leve4;
		Gtk.TreeIter selWindowWin8Leve4;
		Gtk.TreeIter selWindowWin81Leve4;
		Gtk.TreeIter selWindowDOtherLeve4;

		Gtk.TreeIter selOSXLeve3;
		Gtk.TreeIter selOSX_5_Leve4;
		Gtk.TreeIter selOSX_6_Leve4;
		Gtk.TreeIter selOSX_7_Leve4;
		Gtk.TreeIter selOSX_8_Leve4;
		Gtk.TreeIter selOSX_9_Leve4;
		Gtk.TreeIter selOSX_Other_Leve4;

		Gtk.TreeIter selDevicesLeve3;
		Gtk.TreeIter selIOSLeve4;
		Gtk.TreeIter selANDLeve4;
		Gtk.TreeIter selDOtherLeve4;

		TreeSelection selSelection;

		static int disCount;
		static int previousCount;
		static bool enabletree;
		static bool enabletreedesktop;
		static bool enabletreewindows;
		static bool enableXP;
		static bool enableVista;
		static bool enableWin7;
		static bool enableWin8;
		static bool enableWin81;
		static bool enableDOther;

		static bool enableOSX;
		static bool enableOSX5;
		static bool enableOSX6;
		static bool enableOSX7;
		static bool enableOSX8;
		static bool enableOSX9;
		static bool enableOSXOther;

		static bool enableDevices;
		static bool enableIOS;
		static bool enableAND;
		static bool enableDevOther;

		static bool reenable;

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

		#endregion

		public EnvironmentChooser () : 
				base(Gtk.WindowType.Toplevel)
		{
			#region Setups

			this.Build ();

			initSetup();

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
			treeLevel3_OSX = enviroStore.AppendValues(treeLevel2_Desktop, false,"OS X","","","","",99999);

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

			int OSX5 = 141000;
			int OSX6 = 142000;
			int OSX7 = 143000;
			int OSX8 = 144000;
			int OSX9 = 145000;


			previousCount = enviroID.Length -1;
			int count = 0;
			int currentSize = enviroID.Length-1;

			#endregion

			// Main setup loop
			for(int x = 0; x < enviroBools.Length; x++){
				#region OSX
				if(enviroManu[x] == "OS X"){
					if(enviroType[x] == "10.5"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel4_105 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX5);
						}else{
							treeLevel4_105 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX5);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else{
							if(enviroOS[x] == "NA")
								count = 4;
							else
								count = 5;
						}

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						int p = 1;
						if(enviroOS[x] != "NA"){
							enviroStore.AppendValues(treeLevel4_105, false, enviroType[x],  "", enviroOS[x], "", "(Latest)",  OSX5+1);
							enviroID[++currentSize] = OSX5+(++p);
						}
						enviroStore.AppendValues(treeLevel4_105, false, enviroType[x],  "", enviroVersion[x], "", "(Latest)",  OSX5+2);
						enviroID[++currentSize] = OSX5+(++p);
						enviroStore.AppendValues(treeLevel4_105, false, enviroType[x],  "", enviroFF[x-disCount], "", "(Latest)",  OSX5+3);
						enviroID[++currentSize] = OSX5+(++p);
						enviroStore.AppendValues(treeLevel4_105, false, enviroType[x],  "",  enviroSafari[x-disCount], "", "(Latest)",  OSX5+4);
						enviroID[++currentSize] = OSX5+(++p);
						enviroStore.AppendValues(treeLevel4_105, false, enviroType[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  OSX5+5);
						enviroID[++currentSize] = OSX5+(++p);
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel4_105, false, enviroType[x],  "",  "Mail", "", enviroDM[x-disCount], OSX5+6);	
							enviroID[++currentSize] = OSX5+(++p);	
						
						}

						OSX5 += 10; 

					}
					else if(enviroType[x] == "10.6"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel4_106 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX6);
						}else{
							treeLevel4_106 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX6);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else{
							if(enviroOS[x] == "NA")
								count = 4;
							else
								count = 5;
						}

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						int p = 1;
						if(enviroOS[x] != "NA"){
							enviroStore.AppendValues(treeLevel4_106, false, enviroType[x],  "", enviroOS[x], "", "(Latest)",  OSX6+1);
							enviroID[++currentSize] = OSX6+(++p);
						}
						enviroStore.AppendValues(treeLevel4_106, false, enviroType[x],  "", enviroVersion[x], "", "(Latest)",  OSX6+2);
						enviroID[++currentSize] = OSX6+(++p);
						enviroStore.AppendValues(treeLevel4_106, false, enviroType[x],  "", enviroFF[x-disCount], "", "(Latest)",  OSX6+3);
						enviroID[++currentSize] = OSX6+(++p);
						enviroStore.AppendValues(treeLevel4_106, false, enviroType[x],  "",  enviroSafari[x-disCount], "", "(Latest)",  OSX6+4);
						enviroID[++currentSize] = OSX6+(++p);
						enviroStore.AppendValues(treeLevel4_106, false, enviroType[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  OSX6+5);
						enviroID[++currentSize] = OSX6+(++p);
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel4_106, false, enviroType[x],  "",  "Mail", "", enviroDM[x-disCount], OSX6+6);	
							enviroID[++currentSize] = OSX6+(++p);	
						}

						OSX6 += 10; 
					}
					else if(enviroType[x] == "10.7"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel4_107 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX7);
						}else{
							treeLevel4_107 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX7);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else{
							if(enviroOS[x] == "NA")
								count = 4;
							else
								count = 5;
						}

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						int p = 1;
						if(enviroOS[x] != "NA"){
							enviroStore.AppendValues(treeLevel4_107, false, enviroType[x],  "", enviroOS[x], "", "(Latest)",  OSX7+1);
							enviroID[++currentSize] = OSX7+(++p);
						}
						enviroStore.AppendValues(treeLevel4_107, false, enviroType[x],  "", enviroVersion[x], "", "(Latest)",  OSX7+2);
						enviroID[++currentSize] = OSX7+(++p);
						enviroStore.AppendValues(treeLevel4_107, false, enviroType[x],  "", enviroFF[x-disCount], "", "(Latest)",  OSX7+3);
						enviroID[++currentSize] = OSX7+(++p);
						enviroStore.AppendValues(treeLevel4_107, false, enviroType[x],  "",  enviroSafari[x-disCount], "", "(Latest)",  OSX7+4);
						enviroID[++currentSize] = OSX7+(++p);
						enviroStore.AppendValues(treeLevel4_107, false, enviroType[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  OSX7+5);
						enviroID[++currentSize] = OSX7+(++p);
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel4_107, false, enviroType[x],  "",  "Mail", "", enviroDM[x-disCount], OSX7+6);	
							enviroID[++currentSize] = OSX7+(++p);	
						}

						OSX7 += 10; 
					}
					else if(enviroType[x] == "10.8"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel4_108 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX8);
						}else{
							treeLevel4_108 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX8);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else{
							if(enviroOS[x] == "NA")
								count = 4;
							else
								count = 5;
						}

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						int p = 1;
						if(enviroOS[x] != "NA"){
							enviroStore.AppendValues(treeLevel4_108, false, enviroType[x],  "", enviroOS[x], "", "(Latest)",  OSX8+1);
							enviroID[++currentSize] = OSX8+(++p);
						}
						enviroStore.AppendValues(treeLevel4_108, false, enviroType[x],  "", enviroVersion[x], "", "(Latest)",  OSX8+2);
						enviroID[++currentSize] = OSX8+(++p);
						enviroStore.AppendValues(treeLevel4_108, false, enviroType[x],  "", enviroFF[x-disCount], "", "(Latest)",  OSX8+3);
						enviroID[++currentSize] = OSX8+(++p);
						enviroStore.AppendValues(treeLevel4_108, false, enviroType[x],  "",  enviroSafari[x-disCount], "", "(Latest)",  OSX8+4);
						enviroID[++currentSize] = OSX8+(++p);
						enviroStore.AppendValues(treeLevel4_108, false, enviroType[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  OSX8+5);
						enviroID[++currentSize] = OSX8+(++p);
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel4_108, false, enviroType[x],  "",  "Mail", "", enviroDM[x-disCount], OSX8+6);	
							enviroID[++currentSize] = OSX8+(++p);	
						}

						OSX8 += 10; 
					}
					else if(enviroType[x] == "10.9"){
						if(enviroDM[x-disCount] != "None"){
							treeLevel4_109 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX9);
						}else{
							treeLevel4_109 = enviroStore.AppendValues(treeLevel3_OSX, enviroBools[x], enviroType[x], "", "", "", "", OSX9);
						}

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else{
							if(enviroOS[x] == "NA")
								count = 4;
							else
								count = 5;
						}

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						int p = 1;
						if(enviroOS[x] != "NA"){
							enviroStore.AppendValues(treeLevel4_109, false, enviroType[x],  "", enviroOS[x], "", "(Latest)",  OSX9+1);
							enviroID[++currentSize] = OSX9+(++p);
						}
						enviroStore.AppendValues(treeLevel4_109, false, enviroType[x],  "", enviroVersion[x], "", "(Latest)",  OSX9+2);
						enviroID[++currentSize] = OSX9+(++p);
						enviroStore.AppendValues(treeLevel4_109, false, enviroType[x],  "", enviroFF[x-disCount], "", "(Latest)",  OSX9+3);
						enviroID[++currentSize] = OSX9+(++p);
						enviroStore.AppendValues(treeLevel4_109, false, enviroType[x],  "",  enviroSafari[x-disCount], "", "(Latest)",  OSX9+4);
						enviroID[++currentSize] = OSX9+(++p);
						enviroStore.AppendValues(treeLevel4_109, false, enviroType[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  OSX9+5);
						enviroID[++currentSize] = OSX9+(++p);
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel4_109, false, enviroType[x],  "",  "Mail", "", enviroDM[x-disCount], OSX9+6);	
							enviroID[++currentSize] = OSX9+(++p);	
						}

						OSX9 += 10; 
					}
					//-------------->Else???
				}
				#endregion
				#region Window
				else if(enviroManu[x] == "Windows"){
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

						enviroStore.AppendValues(treeLevel5_1, false, enviroName[x],  "", enviroOS[x], "", "(Latest)",  XPID+1);
						enviroID[++currentSize] = XPID+1;
						enviroStore.AppendValues(treeLevel5_1, false, enviroName[x],  "", enviroVersion[x], "", "(Latest)",  XPID+2);
						enviroID[++currentSize] = XPID+2;
						enviroStore.AppendValues(treeLevel5_1, false, enviroName[x],  "", enviroFF[x-disCount], "", "(Latest)",  XPID+3);
						enviroID[++currentSize] = XPID+3;
						enviroStore.AppendValues(treeLevel5_1, false, enviroName[x],  "",  enviroSafari[x-disCount], "", "(Latest)",  XPID+4);
						enviroID[++currentSize] = XPID+4;
						enviroStore.AppendValues(treeLevel5_1, false, enviroName[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  XPID+5);
						enviroID[++currentSize] = XPID+5;

						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_1, false, enviroName[x],  "",  "Mail", "", enviroDM[x-disCount], XPID+6);	
							enviroID[++currentSize] = XPID+6;	
						}

						XPID += 10; 
					}
					else if(enviroType[x] == "Vista"){
						if(enviroDM[x-disCount] != "None")
							treeLevel5_2 = enviroStore.AppendValues(treeLevel4_Vista, enviroBools[x], (enviroName[x] + " " + enviroDM[x-disCount]), "", "", "", "", VIID);
						else
							treeLevel5_2 = enviroStore.AppendValues(treeLevel4_Vista, enviroBools[x], enviroName[x], "", "", "", "", VIID);

						if(enviroDM[x-disCount] != "None")	
							count = 6;
						else
							count = 5;

						count = (inList.Length + count);
						Array.Resize(ref inList, count);
						Array.Resize(ref enviroID, count);

						enviroStore.AppendValues(treeLevel5_2, false, enviroName[x],  "", enviroOS[x], "", "(Latest)", VIID+1);
						enviroID[++currentSize] = VIID+1;
						enviroStore.AppendValues(treeLevel5_2, false, enviroName[x],  "", enviroVersion[x], "", "(Latest)", VIID+2);
						enviroID[++currentSize] = VIID+2;
						enviroStore.AppendValues(treeLevel5_2, false, enviroName[x],  "", enviroFF[x-disCount], "", "(Latest)", VIID+3);
						enviroID[++currentSize] = VIID+3;
						enviroStore.AppendValues(treeLevel5_2, false, enviroName[x],  "", enviroSafari[x-disCount], "", "(Latest)", VIID+4);
						enviroID[++currentSize] = VIID+4;
						enviroStore.AppendValues(treeLevel5_2, false, enviroName[x],  "", enviroOpera[x-disCount], "", "(Latest)", VIID+5);
						enviroID[++currentSize] = VIID+5;

						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_2, false, enviroName[x],  "", "Mail", "", enviroDM[x-disCount], VIID+6);
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

						enviroStore.AppendValues(treeLevel5_3, false, enviroName[x],  "", enviroOS[x], "", "(Latest)", W7ID+1);
						enviroID[++currentSize] = W7ID+1;
						enviroStore.AppendValues(treeLevel5_3, false, enviroName[x],  "", enviroVersion[x], "", "(Latest)",  W7ID+2);
						enviroID[++currentSize] = W7ID+2;
						enviroStore.AppendValues(treeLevel5_3, false, enviroName[x],  "", enviroFF[x-disCount], "", "(Latest)", W7ID+3);
						enviroID[++currentSize] = W7ID+3;
						enviroStore.AppendValues(treeLevel5_3, false, enviroName[x],  "", enviroSafari[x-disCount], "", "(Latest)", W7ID+4);
						enviroID[++currentSize] = W7ID+4;
						enviroStore.AppendValues(treeLevel5_3, false, enviroName[x],  "", enviroOpera[x-disCount], "", "(Latest)", W7ID+5);
						enviroID[++currentSize] = W7ID+5;

						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_3, false, enviroName[x],  "", "Mail", "", enviroDM[x-disCount], W7ID+6);
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

						enviroStore.AppendValues(treeLevel5_4, false, enviroName[x],  "", enviroOS[x], "", "(Latest)",  W8ID+1);
						enviroID[++currentSize] = W8ID+1;
						enviroStore.AppendValues(treeLevel5_4, false, enviroName[x],  "", enviroVersion[x], "", "(Latest)",  W8ID+2);
						enviroID[++currentSize] = W8ID+2;
						enviroStore.AppendValues(treeLevel5_4, false, enviroName[x],  "", enviroFF[x-disCount], "", "(Latest)", W8ID+3);
						enviroID[++currentSize] = W8ID+3;
						enviroStore.AppendValues(treeLevel5_4, false, enviroName[x],  "", enviroSafari[x-disCount], "", "(Latest)",  W8ID+4);
						enviroID[++currentSize] = W8ID+4;
						enviroStore.AppendValues(treeLevel5_4, false, enviroName[x],  "", enviroOpera[x-disCount], "", "(Latest)", W8ID+5);
						enviroID[++currentSize] = W8ID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_4, false, enviroName[x],  "", "Mail", "", enviroDM[x-disCount], W8ID+6);
							enviroID[++currentSize] = W8ID+6;
						}

						W8ID +=10;
					}
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

						enviroStore.AppendValues(treeLevel5_5, false, enviroName[x],  "",  enviroOS[x], "", "(Latest)", W81ID+1);
						enviroID[++currentSize] = W81ID+1;
						enviroStore.AppendValues(treeLevel5_5, false, enviroName[x],  "",  enviroVersion[x], "", "(Latest)",  W81ID+2);
						enviroID[++currentSize] = W81ID+2;
						enviroStore.AppendValues(treeLevel5_5, false, enviroName[x],  "",  enviroFF[x-disCount], "", "(Latest)",  W81ID+3);
						enviroID[++currentSize] = W81ID+3;
						enviroStore.AppendValues(treeLevel5_5, false, enviroName[x],  "",  enviroSafari[x-disCount], "", "(Latest)", W81ID+4);
						enviroID[++currentSize] = W81ID+4;
						enviroStore.AppendValues(treeLevel5_5, false, enviroName[x],  "",  enviroOpera[x-disCount], "", "(Latest)",  W81ID+5);
						enviroID[++currentSize] = W81ID+5;
						if(enviroDM[x-disCount] != "None"){
							enviroStore.AppendValues(treeLevel5_5, false, enviroName[x],  "", "Mail", "", enviroDM[x-disCount], W81ID+6);
							enviroID[++currentSize] = W81ID+6;
						}

						W81ID +=10;
					}
					//-------------->Else???
				}
				#endregion
				#region Other
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
				#endregion
			}

			#region TreeView stuff

			EnviroTree.Model = enviroStore;

			myToggle = new Gtk.CellRendererToggle();
			//myToggle = new CellRendererCombo();
			myToggle.Activatable = true;
			myToggle.Toggled += myToggle_toggled;
			myToggle.CellBackground = "light blue";
			Gtk.TreeViewColumn column_toggle = new Gtk.TreeViewColumn("", myToggle);
			column_toggle.FixedWidth = 150;
			//EnviroTree.AppendColumn(column_toggle);

			Gtk.CellRendererText SubGroup = new Gtk.CellRendererText();
			SubGroup.CellBackground = "light blue";
			Gtk.TreeViewColumn subGRPCol = new Gtk.TreeViewColumn("", SubGroup, stext1);
			EnviroTree.AppendColumn(subGRPCol);
			//EnviroTree.InsertColumn(subGRPCol, 1);

			Gtk.CellRendererText songNameCell = new Gtk.CellRendererText();
			songNameCell.CellBackground = "light blue";
			Gtk.TreeViewColumn songCol = new Gtk.TreeViewColumn("", songNameCell, stext2);
			songCol.Expand = true;
			EnviroTree.AppendColumn(songCol);
		
			Gtk.CellRendererText artistNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn artistCol = new Gtk.TreeViewColumn("", artistNameCell, stext3);
			//EnviroTree.AppendColumn(artistCol);

			Gtk.CellRendererText OSNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn OSCol = new Gtk.TreeViewColumn("", OSNameCell, 4);
			//EnviroTree.AppendColumn(OSCol);

			Gtk.CellRendererText VerNameCell = new Gtk.CellRendererText();
			VerNameCell.CellBackground = "light blue";
			Gtk.TreeViewColumn VerCol = new Gtk.TreeViewColumn("", VerNameCell, 5);
			VerCol.Expand = true;
			EnviroTree.AppendColumn(VerCol);

			Gtk.CellRendererText IDNameCell = new Gtk.CellRendererText();
			Gtk.TreeViewColumn IDCol = new Gtk.TreeViewColumn("", IDNameCell, 6);
			//EnviroTree.AppendColumn(IDCol);

			EnviroTree.AppendColumn(column_toggle);

			//column_toggle.AddAttribute(myToggle, "active", 0);
			subGRPCol.AddAttribute(SubGroup, "text", 1);
			//artistCol.AddAttribute(artistNameCell, "text", 2);
			songCol.AddAttribute(songNameCell, "text", 3);
			//OSCol.AddAttribute(OSNameCell, "text", 4);
			VerCol.AddAttribute(VerNameCell, "text", 5);
			//IDCol.AddAttribute(IDNameCell, "text", 6);
			column_toggle.AddAttribute(myToggle, "active", 0);


			EnviroTree.RulesHint = true;
			EnviroTree.Model = enviroStore;
			EnviroTree.ExpandRow(enviroStore.GetPath(treeLevel1_Enviroment), false);
			//EnviroTree.ExpanderColumn = subGRPCol;  //<--- Open child --->
			EnviroTree.HeadersVisible = false;
			//EnviroTree.RulesHint = true;

			#endregion
		}
	
		#region Completed

		protected void initSetup(){
			enviroPath = Environment.CurrentDirectory + @"\Resources\AndroidEnviro.txt";
			readFile();
			enviroPath = Environment.CurrentDirectory + @"\Resources\DesktopEnviro.txt";
			readFile_Desktop();

			enabletree = false;
			enabletreedesktop = false;
			enabletreewindows = false;

			enableXP = false;
			enableVista = false;
			enableWin7 = false;
			enableWin8 = false;
			enableWin81 = false;

			enableOSX = false;
			enableOSX5 = false;
			enableOSX6 = false;
			enableOSX7 = false;
			enableOSX8 = false;
			enableOSX9 = false;

			reenable = false;
			enableDevices= false;
			enableIOS= false;
			enableAND= false;
			enableDevOther= false;

			//colorbutton2.
			//colorbutton2.ModifyBase(StateType.Normal, Color.Red);


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

		protected void myToggle_toggled (object o, ToggledArgs args){
			TreeIter iter;
			if(enviroStore.GetIter(out iter, new TreePath(args.Path))){
				int idNumber = (int) enviroStore.GetValue(iter, 6);
				if(idNumber != 99999){
					bool old = (bool) enviroStore.GetValue(iter, 0);
					enviroStore.SetValue(iter, 0, !old);
				}
			}
		}

		#endregion

		protected void OnButton3Clicked (object sender, EventArgs e){
			int loop = 0;
			int count = 0;
			int posNum = 99999;

				EnviroTree.Model.Foreach((model, path, iter) => {
					bool selected = (bool) enviroStore.GetValue(iter, 0);

					if(selected){
						int idNumber = (int) enviroStore.GetValue(iter, 6);

						if(idNumber != 99999){
							for(int count2 = 0; count2 < enviroID.Length ; count2++){
								if(enviroID[count2] == idNumber){
									posNum = count2;
									break;
								}
							}

							if(posNum != 99999){
								if(inList[posNum] == false){
									if(!enabletree)
										StartTreetwo();
									#region Windows
									if((idNumber > 4000) && ( idNumber < 99999)){
										if(!enabletreedesktop){
											selDesktopLevel2 = selectedStore.AppendValues(selTreeLevel1, "Desktop","",99999);
											enabletreedesktop = true;
											selTree.ExpandRow(selectedStore.GetPath(selTreeLevel1), false);
										}

										if(!enabletreewindows){
											selWindowLeve3 = selectedStore.AppendValues(selDesktopLevel2, "Windows","",99999);
											enabletreewindows = true;
											selTree.ExpandRow(selectedStore.GetPath(selDesktopLevel2), false);

										}

										string nameType = (string) enviroStore.GetValue(iter, 1);
										string nameType2 = (string) enviroStore.GetValue(iter, 3);
										string nameType3 = (string) enviroStore.GetValue(iter, 5);
										int intID = (int) enviroStore.GetValue(iter, 6);

										if((idNumber > 41000)&&(idNumber < 42000)){
											if(!enableXP){
												selWindowXPLeve4 = selectedStore.AppendValues(selWindowLeve3, "XP","",99999);
												enableXP = true;
											}

											selectedStore.AppendValues(selWindowXPLeve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 42000)&&(idNumber < 43000)){
											if(!enableVista){
												selWindowVistaLeve4 = selectedStore.AppendValues(selWindowLeve3, "Vista","",99999);
												enableVista = true;
											}
											selectedStore.AppendValues(selWindowVistaLeve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 43000)&&(idNumber < 44000)){
											if(!enableWin7){
												selWindowWin7Leve4 = selectedStore.AppendValues(selWindowLeve3, "Win7","",99999);
												enableWin7 = true;
											}
											selectedStore.AppendValues(selWindowWin7Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 44000)&&(idNumber < 45000)){
											if(!enableWin8){
												selWindowWin8Leve4 = selectedStore.AppendValues(selWindowLeve3, "Win8","",99999);
												enableWin8 = true;
											}
											selectedStore.AppendValues(selWindowWin8Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 45000)&&(idNumber < 46000)){
											if(!enableWin81){
												selWindowWin81Leve4 = selectedStore.AppendValues(selWindowLeve3, "Win8.1","",99999);
												enableWin81 = true;
											}
											selectedStore.AppendValues(selWindowWin81Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else{
											if(!enableDOther){
												selWindowDOtherLeve4 = selectedStore.AppendValues(selWindowLeve3, "Other","",99999);
												enableDOther = true;
											}
											selectedStore.AppendValues(selWindowDOtherLeve4, (nameType + " - " + nameType2), nameType3, intID);

										}


										if((idNumber > 41000)&&(idNumber < 46000))
											selTree.ExpandRow(selectedStore.GetPath(selWindowLeve3), false);

										inList[posNum] = true;

									}
									#endregion

									else if(idNumber >= 141000){
										#region OSX
										if(!enabletreedesktop){
											selDesktopLevel2 = selectedStore.AppendValues(selTreeLevel1, "Desktop","",99999);
											enabletreedesktop = true;
											selTree.ExpandRow(selectedStore.GetPath(selTreeLevel1), false);
										}

										if(!enableOSX){
											selOSXLeve3 = selectedStore.AppendValues(selDesktopLevel2, "OS X","",99999);
											enableOSX = true;
											selTree.ExpandRow(selectedStore.GetPath(selDesktopLevel2), false);

										}

										string nameType = (string) enviroStore.GetValue(iter, 1);
										string nameType2 = (string) enviroStore.GetValue(iter, 3);
										string nameType3 = (string) enviroStore.GetValue(iter, 5);
										int intID = (int) enviroStore.GetValue(iter, 6);

										if((idNumber > 141000)&&(idNumber < 142000)){
											if(!enableOSX5){
												selOSX_5_Leve4 = selectedStore.AppendValues(selOSXLeve3, "10.5","",99999);
												enableOSX5 = true;
											}

											selectedStore.AppendValues(selOSX_5_Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 142000)&&(idNumber < 143000)){
											if(!enableOSX6){
												selOSX_6_Leve4 = selectedStore.AppendValues(selOSXLeve3, "10.6","",99999);
												enableOSX6 = true;
											}

											selectedStore.AppendValues(selOSX_6_Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 143000)&&(idNumber < 144000)){
											if(!enableOSX7){
												selOSX_7_Leve4 = selectedStore.AppendValues(selOSXLeve3, "10.7","",99999);
												enableOSX7 = true;
											}

											selectedStore.AppendValues(selOSX_7_Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 144000)&&(idNumber < 145000)){
											if(!enableOSX8){
												selOSX_8_Leve4 = selectedStore.AppendValues(selOSXLeve3, "10.8","",99999);
												enableOSX8 = true;
											}

											selectedStore.AppendValues(selOSX_8_Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else if((idNumber > 145000)&&(idNumber < 146000)){
											if(!enableOSX9){
												selOSX_9_Leve4 = selectedStore.AppendValues(selOSXLeve3, "10.9","",99999);
												enableOSX9 = true;
											}

											selectedStore.AppendValues(selOSX_9_Leve4, (nameType + " - " + nameType2), nameType3, intID);
										}
										else{
											if(!enableOSXOther){
												selOSX_Other_Leve4 = selectedStore.AppendValues(selWindowLeve3, "Other","",99999);
												enableOSXOther = true;
											}
											selectedStore.AppendValues(selOSX_Other_Leve4, (nameType + " - " + nameType2), nameType3, intID);

										}

										if((idNumber > 141000)&&(idNumber < 146000))
											selTree.ExpandRow(selectedStore.GetPath(selOSXLeve3), false);

										inList[posNum] = true;
										#endregion
									}
									else{
										if(posNum <= enviroType.Length){
											if(!enableDevices){
												selDevicesLeve3 = selectedStore.AppendValues(selTreeLevel1, "Devices","",99999);
												enableDevices = true;
												selTree.ExpandRow(selectedStore.GetPath(selTreeLevel1), false);
											}

											string nameType = (string) enviroStore.GetValue(iter, 1);
											string nameType2 = (string) enviroStore.GetValue(iter, 3);
											string nameType3 = (string) enviroStore.GetValue(iter, 5);
											int intID = (int) enviroStore.GetValue(iter, 6);

											if(enviroOS[posNum] == "Android"){
												//textview1.Buffer.Text += (@"Handset: " +  enviroName[posNum] + " (" + enviroVersion[posNum] + ")" + "\n");
												if(!enableAND){
													selANDLeve4 = selectedStore.AppendValues(selDevicesLeve3, "Android","",99999);
													enableAND = true;
													selTree.ExpandRow(selectedStore.GetPath(selDevicesLeve3), false);

												}

												selectedStore.AppendValues(selANDLeve4, (nameType + " - " + nameType2), nameType3, intID);

											}
											else if(enviroOS[posNum] == "iOS"){
												//textview1.Buffer.Text += (@"Tablet: " +  enviroName[posNum] + " (" + enviroVersion[posNum] + ")" + "\n");
												if(!enableIOS){
													selIOSLeve4 = selectedStore.AppendValues(selDevicesLeve3, "iOS","",99999);
													enableIOS = true;
													selTree.ExpandRow(selectedStore.GetPath(selDevicesLeve3), false);

												}

												selectedStore.AppendValues(selIOSLeve4, (nameType + " - " + nameType2), nameType3, intID);
											}
											else{
												//textview1.Buffer.Text += (@"Something: " +  enviroName[posNum] + " ("  + enviroVersion[posNum] + ")" + "\n");
												if(!enableDevOther){
													selDOtherLeve4 = selectedStore.AppendValues(selDevicesLeve3, "Other","",99999);
													enableDevOther = true;
													selTree.ExpandRow(selectedStore.GetPath(selDevicesLeve3), false);

												}

												selectedStore.AppendValues(selDOtherLeve4, (nameType + " - " + nameType2), nameType3, intID);
											}
											inList[posNum] = true;
										}
									}
								}
							button4.Sensitive = true;
							}
						}
						loop++;
					}
					count++;
					return false;
				});
		}

		#region Otherstyff

		//<param> Set up tree 2 </param>
		protected void StartTreetwo(){
			selectedStore = new Gtk.TreeStore(typeof (string), typeof (string), typeof (int));
			selTreeLevel1 = selectedStore.AppendValues("Selected","",99999);

			Gtk.CellRendererText SelRT1 = new Gtk.CellRendererText();
			SelRT1.CellBackground = "light blue";
			Gtk.TreeViewColumn SelCol1 = new Gtk.TreeViewColumn("", SelRT1, 0);
			SelCol1.Expand = true;
			//selTree.AppendColumn(SelCol1);

			Gtk.CellRendererText SelRT2 = new Gtk.CellRendererText();
			SelRT2.CellBackground = "light blue";
			Gtk.TreeViewColumn SelCol2 = new Gtk.TreeViewColumn("", SelRT2, 1);
			SelCol2.Expand = true;

			if(!reenable){
				selTree.AppendColumn(SelCol1);
				selTree.AppendColumn(SelCol2);
			}

			SelCol1.AddAttribute(SelRT1, "text", 0);
			SelCol2.AddAttribute(SelRT2, "text", 1);

			selTree.Model = selectedStore;
			selTree.HeadersVisible = false;
			//selTree.RulesHint = true;
			selSelection = selTree.Selection;
			selSelection.Mode = SelectionMode.Single;

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

		//<param> Remove selected item from tree 2 </param>
		protected void OnButton4Clicked (object sender, EventArgs e)
		{
			//TreeModel temp = selTree.Model;
			TreeModel temp;
			TreeIter itertemp;
			if(selSelection.GetSelected(out temp, out itertemp)){

				int intID = (int) selectedStore.GetValue(itertemp, 2);

				if(intID != 99999){
					selectedStore.Remove(ref itertemp);

					int loop = 0;

					EnviroTree.Model.Foreach((model, path, iter) => {
						if(loop < enviroID.Length){
							if(intID == enviroID[loop]){
								inList[loop] = false;

								enviroStore.SetValue(iter, 0, false);
								return true;
							}
						}

						loop++;
						return false;
					});

					bool bconti = false;

					selTree.Model.Foreach((model, path, iter) => {
						intID = (int) selectedStore.GetValue(iter, 2);
						if(intID != 99999){
							bconti = true;
							return true;
						}
						return false;
					});

					if(!bconti){
						resetTree2();
					}

				}else{
					Console.WriteLine("Not an environment");
				}
			}

			return;
		}

		//<param> Reset tree 2 no selected content </param>
		protected void resetTree2(){

			selectedStore.Clear();

			reenable = true;

			enabletree = false;
			enabletreedesktop = false;
			enabletreewindows = false;

			enableXP = false;
			enableVista = false;
			enableWin7 = false;
			enableWin8 = false;
			enableWin81 = false;

			enableOSX = false;
			enableOSX5 = false;
			enableOSX6 = false;
			enableOSX7 = false;
			enableOSX8 = false;
			enableOSX9 = false;

			enableDevices= false;
			enableIOS= false;
			enableAND= false;
			enableDevOther= false;

			return;
		}

		#endregion
	}
}

