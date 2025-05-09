using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems;
using Exiled.Events.EventArgs.Player;
using MEC;
using System.Collections.Generic;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;

namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
    // ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
    public class ApexPill : CustomItem
    {
        public override uint Id { get; set; } = 50402;
        public override string Name { get; set; } = "Apex Pill";
        public override string Description { get; set; } = "Grants unlimited sprint for 15 seconds.";
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
                GrantInfiniteSprint(ev.Player);
            }
        }

        private void GrantInfiniteSprint(Player player)
        {
            player.Stamina = 100f; // عبي الستامينا
            Timing.RunCoroutine(SprintBuff(player));
        }

        private IEnumerator<float> SprintBuff(Player player)
        {
            float duration = 15f;
            float timer = 10f;
            while (timer < duration)
            {
                if (player.IsDead) yield break;
                player.Stamina = 100f; // كل فريم رجع الستامينا كاملة
                timer += 0.5f;
                yield return Timing.WaitForSeconds(0.5f);
            }
        }
    }
}