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
    public class LuckPill : CustomItem
    {
        public override uint Id { get; set; } = 8686;
        public override string Name { get; set; } = "Luck Pill";
        public override string Description { get; set; } = "Increases your chances of finding rare items for 1 minute.";
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

            ev.Player.Broadcast(5, "Your luck has increased for 1 minute!");
            ev.Player.EnableEffect(EffectType.Scp207, 60);
            ev.Player.EnableEffect(EffectType.Burned, 60);
            ev.Player.EnableEffect(EffectType.Invisible, 60);
            ev.Player.EnableEffect(EffectType.SilentWalk, 60);

        }
    }
}