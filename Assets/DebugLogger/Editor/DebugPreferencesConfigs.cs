using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class DebugPreferencesConfig  
{
    private static bool initialised;
    public static bool enableLogging = true;
   
    [PreferenceItem ("Debug Logging")]
    static void PreferencesGUI ()
    {
        // Load the preferences
        if (initialised == false)
        {
            ReadInitialSettings();
            initialised = true;
        }

        GUILayout.Space(10);
        GUILayout.Label("To remove debug logging when profiling development\nbuilds turn off \"Enable Logging\".");
        GUILayout.Label("Debugging is automatically turned off in\nnon-development builds");

        GUILayout.Space(10);

        GUI.enabled = !EditorApplication.isCompiling;
        enableLogging = EditorGUILayout.Toggle ("Enable Logging", enableLogging);
        GUI.enabled = true;

        if (EditorApplication.isCompiling == true )
        {
            GUILayout.Space(10);
            GUILayout.Label("Please wait... Editor is currently compiling scripts.");
        }

        if (GUI.changed == true)
		{
            EditorPrefs.SetBool ("EnableLogging", enableLogging);
			UpdateDebugSettings();
		}
    }

    /// <summary>
    /// Returns the path to the DebugLog.cs in the AssetDatabase
    /// </summary>
    /// <returns></returns>
    static string FindDebugLoggingScript()
    {
        string[] guids = AssetDatabase.FindAssets("DebugLog");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            if (Path.GetFileName(path) == "DebugLog.cs")
            {
                return path;
            }
        }

        return null;
    }

    static void ReadInitialSettings()
    {
        // Read value from EditorPrefs.
        enableLogging = EditorPrefs.GetBool("EnableLogging", false);

        // Check value against contents of DebugLog.cs
        string path = FindDebugLoggingScript();

        if (path == null)
        {
            Debug.LogError("Debugging Preferences: Can't find DebugLog.cs script.");
            return;
        }

        // Open the file.
        string[] lines = File.ReadAllLines(path);

        // Change first file in file.
        if (lines.Length > 1)
        {
            if (lines[0] == @"//#define FORCE_LOGGING_OFF")
            {
                enableLogging = true;
            }
            else enableLogging = false;
        }
    }

    static void UpdateDebugSettings()
    {
        string path = FindDebugLoggingScript();

        if (path == null)
        {
            Debug.LogError("Debugging Preferences: Can't find DebugLog.cs script.");
            return;
        }

        // Open the file.
        string[] lines = File.ReadAllLines(path);

        // Change first file in file.
        if (lines.Length > 1)
        {
            if (enableLogging == true)
            {
                lines[0] = @"//#define FORCE_LOGGING_OFF";
            }
            else
            {
                lines[0] = @"#define FORCE_LOGGING_OFF";
            }

            // Write file back.
            File.WriteAllLines(path, lines);

            AssetDatabase.ImportAsset(path);
        }
    }
}