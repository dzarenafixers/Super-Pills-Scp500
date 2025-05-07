using Exiled.API.Features;
using Exiled.CustomItems.API.Features;

namespace SCP500Expanded.Handlers
{
    public static class EventHandler
    {
        public static void RegisterEvents()
        {
            CustomItem.RegisterItems();
                new Items.AegisPill();
                new Items.ApexPill();
                new Items.AuroraPill();
                new Items.AnomalyPill();
                new Items.AtomPill();
                new Items.AbyssPill();
                new Items.AscentPill();
                new Items.AvatarPill();
                new Items.ArcanePill();
                new Items.ArtifactPill();
            ;
        }

        public static void UnregisterEvents()
        {
            CustomItem.UnregisterItems();
        }
    }
}
