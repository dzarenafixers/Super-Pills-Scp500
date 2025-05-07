using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems;
using Exiled.Events.EventArgs.Player;
using System.Linq;
using Exiled.API.Extensions;
using Exiled.API.Features.Attributes;
using Exiled.CustomItems.API.Features;

namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]

    public class AbyssPill : CustomItem
    {
        public override uint Id { get; set; } = 5006;
        public override string Name { get; set; } = "Abyss Pill";
        public override string Description { get; set; } = "Teleports you to a random location.";
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

            var randomRoom = Room.List.ToList().GetRandomValue();
            ev.Player.Teleport(randomRoom.Position + UnityEngine.Vector3.up);
        }
    }
}