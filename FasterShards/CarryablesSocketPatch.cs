using CG.Ship.Hull;
using HarmonyLib;
using VoidManager.Utilities;

namespace FasterShards
{
    [HarmonyPatch(typeof(CarryablesSocket))]
    internal class CarryablesSocketPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void Start(CarryablesSocket __instance)
        {
            if (__instance.name == "GalaxyMapTerminal_SingleSocket")
            {
                __instance.IsOutput = false;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("OnAcquireCarryablePassthrough")]
        static void OnAcquireCarryablePassthrough(CarryablesSocket __instance)
        {
            if (__instance.name == "GalaxyMapTerminal_SingleSocket")
            {
                Tools.DelayDo(() => __instance.SetState(Gameplay.Carryables.SocketState.Open), 0);
            }
        }
    }
}
