using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;

namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]

    public class AtomPill : CustomItem
    {
        public override uint Id { get; set; } = 5005;
        public override string Name { get; set; } = "Atom Pill";
        public override string Description { get; set; } = "Shrinks your body size.";
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
            ev.Player.Scale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}