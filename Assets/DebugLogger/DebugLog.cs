//#define FORCE_LOGGING_OFF
// Don't edit first line above as this is auto-edited by the DebugPreferencesConfig.cs editor script to enable/disable logging.

#if DEVELOPMENT_BUILD || UNITY_EDITOR
#if !FORCE_LOGGING_OFF
#define ENABLE_DEBUG_LOGGING
#endif
#endif

using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public static class DebugLogging
{
    [ConditionalAttribute("ENABLE_DEBUG_LOGGING")]
    public static void Log(string message)
    {
        UnityEngine.Debug.Log(message);
    }

    [ConditionalAttribute("ENABLE_DEBUG_LOGGING")]
    public static void Log(string message, UnityEngine.Object context)
    {
        UnityEngine.Debug.Log(message, context );
    }

    [ConditionalAttribute("ENABLE_DEBUG_LOGGING")]
    public static void LogWarning(string message)
    {
        UnityEngine.Debug.LogWarning(message);
    }

    [ConditionalAttribute("ENABLE_DEBUG_LOGGING")]
    public static void LogWarning(string message, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogWarning(message, context);
    }

    [ConditionalAttribute("ENABLE_DEBUG_LOGGING")]
    public static void LogError(string message)
    {
        UnityEngine.Debug.LogError(message);
    }

    [ConditionalAttribute("ENABLE_DEBUG_LOGGING")]
    public static void LogError(string message, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogError(message, context);
    }
}

