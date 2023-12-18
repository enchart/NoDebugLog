using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace NoDebugLog;

[BepInPlugin(Guid, Name, Version)]
public class Plugin : BaseUnityPlugin
{
    private const string Guid = "com.enchart.nodebuglog";
    private const string Name = "NoDebugLog";
    private const string Version = "1.0.0.0";

    private readonly ConfigEntry<bool> _configDisableLogging;

    public Plugin()
    {
        _configDisableLogging = Config.Bind("General", "DisableLogging", true, "Disables Unity logger.");
        _configDisableLogging.SettingChanged += (_, _) => LogEnabled = _configDisableLogging.Value;
    }

    private bool LogEnabled
    {
        set
        {
            Debug.unityLogger.logEnabled = !value;
            if (value)
                Logger.LogWarning($"Unity logger has been disabled! To enable it, edit the configuration of {Name}");
        }
    }

    private void Awake()
    {
        Logger.LogInfo($"Plugin {Guid} is loaded!");
        LogEnabled = _configDisableLogging.Value;
    }
}