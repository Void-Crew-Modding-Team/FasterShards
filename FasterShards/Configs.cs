using BepInEx.Configuration;

namespace FasterShards
{
    internal class Configs
    {
        internal static ConfigEntry<float> PreDestroyDelayConfig;
        internal static ConfigEntry<float> PostDestroyDelayConfig;

        internal static void Load(BepinPlugin plugin)
        {
            PreDestroyDelayConfig = plugin.Config.Bind("FasterShards", "PreDestroyDelay", 4.5f);
            PreDestroyDelayConfig.SettingChanged += (sender, args) => { if (PreDestroyDelayConfig.Value < 0.01f) PreDestroyDelayConfig.Value = 0.01f; };
            PostDestroyDelayConfig = plugin.Config.Bind("FasterShards", "PostDestroyDelay", 0f);
            PostDestroyDelayConfig.SettingChanged += (sender, args) => { if (PostDestroyDelayConfig.Value < 0f) PostDestroyDelayConfig.Value = 0f; };
        }
    }
}
