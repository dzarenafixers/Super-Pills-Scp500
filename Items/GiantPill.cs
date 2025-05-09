using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class GiantPill : CustomItem
    {
        public override uint Id { get; set; } = 525;
        public override string Name { get; set; } = "Giant Pill";
        public override string Description { get; set; } = "Makes you larger and stronger for 10 seconds.";
        public override float Weight { get; set; } = 0.1f;
        public override SpawnProperties SpawnProperties { get; set; }

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

            ev.Player.Scale *= 1.5f; // تكبير اللاعب
            Timing.CallDelayed(10, () =>
            {
                ev.Player.Scale = UnityEngine.Vector3.one; // إعادة الحجم الطبيعي
            });

            ev.Player.Broadcast(5, "You are now a giant for 10 seconds!");
        }
    }
}