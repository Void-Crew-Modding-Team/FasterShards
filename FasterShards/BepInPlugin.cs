﻿using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace FasterShards
{
    internal static class MyPluginInfo
    {
        internal const string PLUGIN_GUID = "id107.fastershards";
        internal const string PLUGIN_NAME = "FasterShards";
        internal const string PLUGIN_VERSION = "0.1.0";
    }

    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;
            Configs.Load(this);
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}