using VoidManager.MPModChecks;

namespace FasterShards
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Host;

        public override string Author => "18107";

        public override string Description => "Makes data shards process faster";
    }
}
