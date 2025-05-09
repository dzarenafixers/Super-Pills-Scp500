using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class AdvancedHealingPill : CustomItem
    {
        public override uint Id { get; set; } = 5009;
        public override string Name { get; set; } = "Advanced Healing Pill";
        public override string Description { get; set; } = "Heals all injuries and grants temporary damage resistance for 10 seconds.";
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

            ev.Player.Health = ev.Player.MaxHealth; // شفاء كامل
            ev.Player.EnableEffect(EffectType.Invigorated, 10); // مقاومة مؤقتة
            ev.Player.Broadcast(5, "You are fully healed and resistant to damage for 10 seconds!");
        }
    }
}