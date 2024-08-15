using VoidManager.CustomGUI;
using VoidManager.Utilities;

namespace FasterShards
{
    internal class GUI : ModSettingsMenu
    {
        public override string Name() => "Faster Shards";

        public override void Draw()
        {
            if (GUITools.DrawTextField("Delay before destroying shard", ref Configs.PreDestroyDelayConfig))
            {
                CarryablesSocketPatch.UpdateSocketClearTimers(Configs.PreDestroyDelayConfig.Value, Configs.PostDestroyDelayConfig.Value);
            }
            if (GUITools.DrawTextField("Delay after destroying shard", ref Configs.PostDestroyDelayConfig))
            {
                CarryablesSocketPatch.UpdateSocketClearTimers(Configs.PreDestroyDelayConfig.Value, Configs.PostDestroyDelayConfig.Value);
            }
        }
    }
}
