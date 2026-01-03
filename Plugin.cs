using BepInEx;
using Photon.Pun;
using System;
using UnityEngine;

namespace AntiSnowballs
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance { get; private set; }

        public void OnEnable() => HarmonyPatches.ApplyHarmonyPatches();
        public void OnDisable() => HarmonyPatches.RemoveHarmonyPatches();
    }
    public class PluginInfo
    {
        internal const string
            GUID = "John.antisnowballs",
            Name = "AntiSnowballs",
            Version = "1.0.0";
    }
}
