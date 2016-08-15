using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace QFCore.Editor.Util {
    public class SyncRiderProject {
        /// Add any filetypes you require to be included in the project file here.
        private static readonly string[] unCompiledExtensions = {"shader", "cginc", "txt", "xml", ".json"};

        private static readonly string[] unityDlls = {"UnityEngine", "UnityEditor"};

        private static readonly string[] monoDlls = {
            "System", "System.Data", "System.Core", "System.Xml", "System.Xml.Linq"
        };

        private static string dllPath {
            get {
                if (Application.platform == RuntimePlatform.OSXEditor)
                    return EditorApplication.applicationContentsPath + "/Frameworks/Managed/";

                return EditorApplication.applicationContentsPath + "/Managed/";
            }
        }

        [MenuItem("Assets/Sync Rider Project")]
        static void SyncProject() {
            Guid guid = Guid.NewGuid();

            string projectFile = projectXMLHeader;
            string targetDir = Application.dataPath.Substring(0, Application.dataPath.Length - 7);
            string projectName = targetDir.Substring(targetDir.LastIndexOf("/", StringComparison.Ordinal) + 1);
            int pathBeginIndex = Application.dataPath.IndexOf("Assets", StringComparison.Ordinal);
            string[] cSharpFiles = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories);
            string[] dllFiles = Directory.GetFiles(Application.dataPath, "*.dll", SearchOption.AllDirectories);
            foreach (string file in cSharpFiles) {
                string croppedFile = file.Substring(pathBeginIndex);
                projectFile += "<Compile Include=\"" + croppedFile.Replace("/", "\\") + "\" />\n";
            }

            foreach (string ext in unCompiledExtensions) {
                string[] files = Directory.GetFiles(Application.dataPath, "*." + ext, SearchOption.AllDirectories);
                foreach (string file in files) {
                    string croppedFile = file.Substring(pathBeginIndex);
                    projectFile += "<None Include=\"" + croppedFile.Replace("/", "\\") + "\" />\n";
                }
            }

            string extraPlugins = "";
            foreach (string file in dllFiles) {
                string croppedFile = file.Substring(pathBeginIndex);
                string dllName = croppedFile.Substring(croppedFile.LastIndexOf("/", StringComparison.Ordinal) + 1);
                dllName = dllName.Substring(0, dllName.LastIndexOf('.'));
                extraPlugins += "<Reference Include=\"" + dllName + "\">\n";
                extraPlugins += "<HintPath>.\\" + croppedFile.Replace("/", "\\") + "</HintPath>\n</Reference>\n";
            }

            string buildTarget = "";
            switch (EditorUserBuildSettings.activeBuildTarget) {
                case BuildTarget.Android:
                    buildTarget = ";UNITY_ANDROID";
                    break;
                case BuildTarget.iOS:
                    buildTarget = ";UNITY_IPHONE";
                    break;
            }

            string[] filesToDelete = new[] {"*.csproj", "*.unityproj", "*.pidb", "*.user", "*.sln"};

            foreach (string fileType in filesToDelete) {
                string[] projectRootFiles = Directory.GetFiles(targetDir, fileType);
                foreach (string file in projectRootFiles) File.Delete(file);
            }

            // unity dlls
            string unityDllString = "";
            foreach (string unityDll in unityDlls) {
                string unityDllPath = dllPath + unityDll + ".dll";
                unityDllPath = unityDllPath.Replace("/", "\\");
                unityDllString += "<Reference Include=\"" + unityDll + "\">\n";
                unityDllString += "<HintPath>" + unityDllPath + "</HintPath>\n</Reference>\n";
            }

            // mono dlls
            foreach (string monoDll in monoDlls) {
                string monoDllPath = EditorApplication.applicationContentsPath + "/Frameworks/Mono/lib/mono/unity/" + monoDll + ".dll";
                monoDllPath = monoDllPath.Replace("/", "\\");
                unityDllString += "<Reference Include=\"" + monoDll + "\">\n";
                unityDllString += "<HintPath>" + monoDllPath + "</HintPath>\n</Reference>\n";
            }

            // Extensions
            string[] extensions = Directory.GetFiles(EditorApplication.applicationContentsPath + "/UnityExtensions/",
                "*.dll", SearchOption.AllDirectories);

            string extensionsDlls = "";
            foreach (string file in extensions) {
                if (file.IndexOf("/Standalone/", StringComparison.Ordinal) != -1) continue;
                string dllName = file.Substring(file.LastIndexOf("/", StringComparison.Ordinal) + 1);
                dllName = dllName.Substring(0, dllName.LastIndexOf('.'));
                extensionsDlls += "<Reference Include=\"" + dllName + "\">\n";
                extensionsDlls += "<HintPath>" + (file).Replace("/", "\\") + "</HintPath>\n</Reference>\n";
            }

            projectFile += projectXMLFooter;
            projectFile = projectFile.Replace("#GUID#", guid.ToString());
            projectFile = projectFile.Replace("#UNITYDLLS#", unityDllString + extensionsDlls);
            projectFile = projectFile.Replace("#EXTRADLLS#", extraPlugins);
            projectFile = projectFile.Replace("#TARGET#", buildTarget);

            StreamWriter sw = new StreamWriter(targetDir + "/" + projectName + " - Unity.csproj");
            sw.Write(projectFile);
            sw.Flush();
            sw.Close();

            string solutionFile = solutionHeader;
            solutionFile += projectName + "\",\"" + projectName + " - Unity.csproj\", \"{#GUID#}\"\n";
            solutionFile += solutionFooter;
            solutionFile = solutionFile.Replace("#GUID#", guid.ToString());
            StreamWriter sw2 = new StreamWriter(targetDir + "/" + projectName + " - Unity.sln");
            sw2.Write(solutionFile);
            sw2.Flush();
            sw2.Close();

            // This is my own personal resharper settings, you can replace the string with your own or take this line out
            File.WriteAllText(targetDir + "/" + projectName + " - Unity.sln.DotSettings", resharperSettingsFile);

            // Refresh the instance of Rider EAP if there is one running... (Only way right now - is to close and reopen)
            ProcessStartInfo processStartInfo = new ProcessStartInfo("osascript");
            processStartInfo.UseShellExecute = false;
            processStartInfo.Arguments = "-e 'tell application \"Rider EAP\" to quit'";
            Process p = Process.Start(processStartInfo);
            p.WaitForExit();
            Process.Start("/usr/local/bin/rider", "\"" + targetDir + "/" + projectName + " - Unity.sln\"");
        }

        #region Project File contents (Leave these alone)

        private const string projectXMLHeader =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?><Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\n<PropertyGroup>\n<Configuration Condition=\" \'$(Configuration)\' == \'\' \">Debug</Configuration>\n<Platform Condition=\" \'$(Platform)\' == \'\' \">AnyCPU</Platform>\n<ProductVersion>9.0.21022</ProductVersion>\n<SchemaVersion>2.0</SchemaVersion>\n<ProjectGuid>{#GUID#}</ProjectGuid>\n<OutputType>Library</OutputType>\n<AppDesignerFolder>Properties</AppDesignerFolder>\n<RootNamespace></RootNamespace>\n<AssemblyName>Assembly-CSharp</AssemblyName>\n<TargetFrameworkVersion>v3.5</TargetFrameworkVersion>\n<FileAlignment>512</FileAlignment>\n</PropertyGroup>\n<PropertyGroup Condition=\" \'$(Configuration)|$(Platform)\' == \'Debug|AnyCPU\' \">\n<DebugSymbols>true</DebugSymbols>\n<DebugType>full</DebugType>\n<Optimize>false</Optimize>\n<OutputPath>Temp\\bin\\Debug\\</OutputPath>\n<DefineConstants>DEBUG;TRACE;UNITY_5_2_3;UNITY_5_2;UNITY_5;ENABLE_NEW_BUGREPORTER;ENABLE_2D_PHYSICS;ENABLE_4_6_FEATURES;ENABLE_AUDIO;ENABLE_CACHING;ENABLE_CLOTH;ENABLE_DUCK_TYPING;ENABLE_FRAME_DEBUGGER;ENABLE_GENERICS;ENABLE_HOME_SCREEN;ENABLE_IMAGEEFFECTS;ENABLE_LIGHT_PROBES_LEGACY;ENABLE_MICROPHONE;ENABLE_MULTIPLE_DISPLAYS;ENABLE_PHYSICS;ENABLE_PLUGIN_INSPECTOR;ENABLE_SHADOWS;ENABLE_SINGLE_INSTANCE_BUILD_SETTING;ENABLE_SPRITES;ENABLE_TERRAIN;ENABLE_RAKNET;ENABLE_UNET;ENABLE_UNITYEVENTS;ENABLE_VR;ENABLE_WEBCAM;ENABLE_WWW;ENABLE_CLOUD_SERVICES;ENABLE_CLOUD_SERVICES_ADS;ENABLE_CLOUD_HUB;ENABLE_CLOUD_PROJECT_ID;ENABLE_CLOUD_SERVICES_ANALYTICS;ENABLE_CLOUD_SERVICES_UNET;ENABLE_CLOUD_SERVICES_BUILD;ENABLE_CLOUD_LICENSE;ENABLE_EDITOR_METRICS;ENABLE_REFLECTION_BUFFERS;INCLUDE_DYNAMIC_GI;INCLUDE_GI;INCLUDE_IL2CPP;INCLUDE_DIRECTX12;PLATFORM_SUPPORTS_MONO;RENDER_SOFTWARE_CURSOR;ENABLE_LOCALIZATION;ENABLE_ANDROID_ATLAS_ETC1_COMPRESSION;UNITY_STANDALONE_OSX;UNITY_STANDALONE;ENABLE_SUBSTANCE;ENABLE_GAMECENTER;ENABLE_TEXTUREID_MAP;ENABLE_RUNTIME_GI;ENABLE_MOVIES;ENABLE_NETWORK;ENABLE_CRUNCH_TEXTURE_COMPRESSION;ENABLE_LOG_MIXED_STACKTRACE;ENABLE_UNITYWEBREQUEST;ENABLE_WEBSOCKET_HOST;ENABLE_MONO;ENABLE_PROFILER;UNITY_ASSERTIONS;UNITY_EDITOR;UNITY_EDITOR_64;UNITY_EDITOR_OSX;UNITY_TEAM_LICENSE;UNITY_PRO_LICENSE</DefineConstants>\n<ErrorReport>prompt</ErrorReport>\n<WarningLevel>4</WarningLevel>\n<NoWarn>0169</NoWarn>\n</PropertyGroup>\n<PropertyGroup Condition=\" \'$(Configuration)|$(Platform)\' == \'Release|AnyCPU\' \">\n<DebugType>pdbonly</DebugType>\n<Optimize>true</Optimize>\n<OutputPath>Temp\\bin\\Release\\</OutputPath>\n<DefineConstants>TRACE#TARGET#</DefineConstants>\n<ErrorReport>prompt</ErrorReport>\n<WarningLevel>4</WarningLevel>\n<NoWarn>0169</NoWarn>\n</PropertyGroup>\n<ItemGroup>\n<Reference Include=\"System\" />\n   <Reference Include=\"System.XML\" />\n<Reference Include=\"System.Core\" />\n#UNITYDLLS#\n#EXTRADLLS#</ItemGroup>\n<ItemGroup>";

        private const string projectXMLFooter =
            "</ItemGroup>\n<Import Project=\"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />\n</Project>";

        private const string solutionHeader =
            "Microsoft Visual Studio Solution File, Format Version 12.00\n# Visual Studio 2013\nVisualStudioVersion = 12.0.0.0\nMinimumVisualStudioVersion = 10.0.0.1\nProject(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"";

        private const string solutionFooter =
            "EndProject\nGlobal\n	GlobalSection(SolutionConfigurationPlatforms) = preSolution\n		Debug|Any CPU = Debug|Any CPU\n		Release|Any CPU = Release|Any CPU\n	EndGlobalSection\n	GlobalSection(ProjectConfigurationPlatforms) = postSolution\n		{#GUID#}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n		{#GUID#}.Debug|Any CPU.Build.0 = Debug|Any CPU\n		{#GUID#}.Release|Any CPU.ActiveCfg = Release|Any CPU\n		{#GUID#}.Release|Any CPU.Build.0 = Release|Any CPU\n		EndGlobalSection\n	GlobalSection(SolutionProperties) = preSolution\n		HideSolutionNode = FALSE\n	EndGlobalSection\nEndGlobal";

        private const string resharperSettingsFile =
            @"<wpf:ResourceDictionary xml:space=""preserve"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" xmlns:s=""clr-namespace:System;assembly=mscorlib"" xmlns:ss=""urn:shemas-jetbrains-com:settings-storage-xaml"" xmlns:wpf=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
                                                           	<s:Boolean x:Key=""/Default/CodeEditing/Intellisense/CodeCompletion/IntelliSenseCompletingCharacters/CSharpCompletingCharacters/UpgradedFromVSSettings/@EntryValue"">True</s:Boolean>
                                                           	<s:Boolean x:Key=""/Default/CodeInspection/Highlighting/IdentifierHighlightingEnabled/@EntryValue"">True</s:Boolean>
                                                           	<s:String x:Key=""/Default/CodeInspection/Highlighting/InspectionSeverities/=SuggestVarOrType_005FSimpleTypes/@EntryIndexedValue"">DO_NOT_SHOW</s:String>
                                                           	<s:String x:Key=""/Default/CodeInspection/Highlighting/InspectionSeverities/=UnassignedField_002ECompiler/@EntryIndexedValue"">DO_NOT_SHOW</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeCleanup/RecentlyUsedProfile/@EntryValue"">Default: Reformat Code</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/ACCESSOR_DECLARATION_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/ACCESSOR_OWNER_DECLARATION_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/ANONYMOUS_METHOD_DECLARATION_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/CASE_BLOCK_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/EMPTY_BLOCK_STYLE/@EntryValue"">TOGETHER</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/INITIALIZER_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/INVOCABLE_DECLARATION_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/OTHER_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:Boolean x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/PLACE_CATCH_ON_NEW_LINE/@EntryValue"">False</s:Boolean>
                                                           	<s:Boolean x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/PLACE_ELSE_ON_NEW_LINE/@EntryValue"">False</s:Boolean>
                                                           	<s:Boolean x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/PLACE_FINALLY_ON_NEW_LINE/@EntryValue"">False</s:Boolean>
                                                           	<s:Boolean x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/REMOVE_BLANK_LINES_NEAR_BRACES_IN_DECLARATIONS/@EntryValue"">False</s:Boolean>
                                                           	<s:String x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/TYPE_DECLARATION_BRACES/@EntryValue"">END_OF_LINE</s:String>
                                                           	<s:Int64 x:Key=""/Default/CodeStyle/CodeFormatting/CSharpFormat/WRAP_LIMIT/@EntryValue"">190</s:Int64>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/CSharpNaming/PredefinedNamingRules/=PrivateInstanceFields/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/CSharpNaming/PredefinedNamingRules/=PublicFields/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FBLOCK_005FSCOPE_005FCONSTANT/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FBLOCK_005FSCOPE_005FVARIABLE/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FCONSTRUCTOR/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FFUNCTION/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FGLOBAL_005FVARIABLE/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FLABEL/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FLOCAL_005FCONSTRUCTOR/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FLOCAL_005FVARIABLE/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FOBJECT_005FPROPERTY_005FOF_005FFUNCTION/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=JS_005FPARAMETER/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FCLASS/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FENUM/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FENUM_005FMEMBER/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FINTERFACE/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix=""I"" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FMODULE/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FMODULE_005FEXPORTED/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FMODULE_005FLOCAL/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPRIVATE_005FMEMBER_005FACCESSOR/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPRIVATE_005FSTATIC_005FTYPE_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPRIVATE_005FTYPE_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPRIVATE_005FTYPE_005FMETHOD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPROTECTED_005FMEMBER_005FACCESSOR/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPROTECTED_005FSTATIC_005FTYPE_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPROTECTED_005FTYPE_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPROTECTED_005FTYPE_005FMETHOD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPUBLIC_005FMEMBER_005FACCESSOR/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPUBLIC_005FSTATIC_005FTYPE_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPUBLIC_005FTYPE_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FPUBLIC_005FTYPE_005FMETHOD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/JavaScriptNaming/UserRules/=TS_005FTYPE_005FPARAMETER/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix=""T"" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/WebNaming/UserRules/=ASP_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/WebNaming/UserRules/=ASP_005FHTML_005FCONTROL/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/WebNaming/UserRules/=ASP_005FTAG_005FNAME/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/WebNaming/UserRules/=ASP_005FTAG_005FPREFIX/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/XamlNaming/UserRules/=NAMESPACE_005FALIAS/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""aaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/XamlNaming/UserRules/=XAML_005FFIELD/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String>
                                                           	<s:String x:Key=""/Default/CodeStyle/Naming/XamlNaming/UserRules/=XAML_005FRESOURCE/@EntryIndexedValue"">&lt;Policy Inspect=""True"" Prefix="""" Suffix="""" Style=""AaBb"" /&gt;</s:String></wpf:ResourceDictionary>";

        #endregion
    }
}