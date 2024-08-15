using CG.Game;
using CG.Ship.Hull;
using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace FasterShards
{
    [HarmonyPatch(typeof(CarryablesSocket))]
    internal class CarryablesSocketPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("SetUseExternalSocketClear")]
        static void SetUseExternalSocketClear(CarryablesSocket __instance, ref float preDestroyTimer, ref float postDestroyTimer)
        {
            if (__instance.name == "GalaxyMapTerminal_SingleSocket")
            {
                preDestroyTimer = Mathf.Max(Configs.PreDestroyDelayConfig.Value, 0.01f);
                postDestroyTimer = Mathf.Max(Configs.PostDestroyDelayConfig.Value, 0f);
            }
        }

        public static void UpdateSocketClearTimers(float preDestroyTimer, float postDestroyTimer)
        {
            SocketClearOperation socketOperation = ClientGame.Current?.PlayerShip?.GameObject?.GetComponentsInChildren<CarryablesSocket>()?.FirstOrDefault(socket => socket.name == "GalaxyMapTerminal_SingleSocket")?.customSocketClearOperation;
            if (socketOperation == null) return;
            socketOperation.preDestroyTimer = Mathf.Max(preDestroyTimer, 0.01f);
            socketOperation.postDestroyTime = Mathf.Max(postDestroyTimer, 0f);
        }
    }
}
