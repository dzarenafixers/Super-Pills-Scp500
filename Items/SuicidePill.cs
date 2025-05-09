using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using System.Collections.Generic;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class SuicidePill : CustomItem
    {
        public override uint Id { get; set; } = 14;
        public override string Name { get; set; } = "Suicide Pill";
        public override string Description { get; set; } = "Explodes you after 3 seconds.";
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
            ev.Player.ShowHint("💥 ستنفجر خلال 3 ثواني!", 3);

            Timing.CallDelayed(3f, () =>
            {
                if (ev.Player.IsAlive)
                {
                    ev.Player.Kill(DamageType.Explosion, "Suicide Pill");
                }
            });
        }
    }
}