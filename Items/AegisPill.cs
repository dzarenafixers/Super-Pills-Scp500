using Exiled.API.Features.Items;
using Exiled.API.Enums;
using Exiled.CustomItems;
using Exiled.Events.EventArgs.Player;
using MEC;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using UnityEngine;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]

    public class AegisPill : CustomItem
    {
        public override uint Id { get; set; } = 5001;
        public override string Name { get; set; } = "Aegis Pill";
        public override string Description { get; set; } = "Grants wallhack for 10 seconds.";
        public override float Weight { get; set; } = 0.1f;
        public override SpawnProperties SpawnProperties { get; set; }
        public override ItemType Type { get; set; } = ItemType.SCP500;

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem += OnUsedItem;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedItem;

            base.UnsubscribeEvents();
        }

        private void OnUsedItem(UsedItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                GrantWallHack(ev.Player);
            }
        }

        private void GrantWallHack(Player player)
        {
            player.EnableEffect(EffectType.Scp1344, 10, true);
            player.ShowHint("يمكنك رؤية الأعداء خلف الجدران لمدة 10 ثوانٍ!", 3);
        }

    }
}