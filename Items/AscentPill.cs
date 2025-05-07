using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;

namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]

    public class AscentPill : CustomItem
    {
        public override uint Id { get; set; } = 5007;
        public override string Name { get; set; } = "Ascent Pill";
        public override string Description { get; set; } = "Grants +50 HP bonus.";
        public override float Weight { get; set; } = 0.1f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get; set; } = ItemType.SCP500;

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUse;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= OnUse;
            base.UnsubscribeEvents();
        }

        private void OnUse(UsedItemEventArgs ev)
        {
            if (!Check(ev.Item)) return;

            ev.Player.Health += 50;
        }
    }
}