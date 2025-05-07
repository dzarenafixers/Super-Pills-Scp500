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
    public class ArtifactPill : CustomItem
    {
        public override uint Id { get; set; } = 5010;
        public override string Name { get; set; } = "Artifact Pill";
        public override string Description { get; set; } = "Grants a random item.";
        public override float Weight { get; set; } = 0.1f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get; set; } = ItemType.SCP500;

        private static readonly ItemType[] Items = new ItemType[]
        {
            ItemType.GunCOM15,
            ItemType.GunE11SR,
            ItemType.GunCrossvec,
            ItemType.Adrenaline,
            ItemType.SCP207,
            ItemType.GrenadeHE,
            ItemType.ArmorHeavy,
            ItemType.Coin,
            ItemType.SCP500,
            ItemType.MicroHID,
            ItemType.KeycardChaosInsurgency,
            ItemType.GrenadeFlash

        };

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

            ItemType randomItem = Items[UnityEngine.Random.Range(0, Items.Length)];
            ev.Player.AddItem(randomItem);
        }
    }
}