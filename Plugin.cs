using BepInEx;
using UnityEngine;

namespace NoDebugLog;

[BepInPlugin(Guid, Name, Version)]
public class Plugin : BaseUnityPlugin
{
    private const string Guid = "com.enchart.nodebuglog";
    private const string Name = "NoDebugLog";
    private const string Version = "1.0.0.0";
        
    private void Awake()
    {
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        Debug.unityLogger.logEnabled = false;
        Logger.LogWarning("Unity logger is turned off now!");
    }
}