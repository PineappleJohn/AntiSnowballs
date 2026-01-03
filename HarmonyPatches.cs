using AntiSnowballs;
using ExitGames.Client.Photon;
using GorillaLocomotion;
using HarmonyLib;
using Photon.Realtime;
using UnityEngine;

namespace AntiSnowballs
{
    public class HarmonyPatches
    {
        static Harmony instance;
        static bool isPatched = false;
        public static bool IsPatched
        {
            get => isPatched;
            set
            {
                if (IsPatched == value || (instance == null && !value)) return;
                isPatched = value;

                if (value)
                {
                    instance ??= Harmony.CreateAndPatchAll(typeof(Plugin).Assembly, "John.PineappleP");
                    return;
                }

                instance.UnpatchSelf();
                instance = null;
            }
        }
        public static void ApplyHarmonyPatches() => IsPatched = true;
        public static void RemoveHarmonyPatches() => IsPatched = false;
    }

    [HarmonyPatch(typeof(GTPlayer), "ApplyKnockback")]
    public class KnockbackPatch
    {
        public static bool Prefix(Vector3 direction, float speed)
        {
            return !NetworkSystem.Instance.GameModeString.Contains("MODDED_");
        }
    }
}