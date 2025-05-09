using System.Linq;
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
    public class HypnosisPill : CustomItem
    {
        public override uint Id { get; set; } = 425;
        public override string Name { get; set; } = "Hypnosis Pill";
        public override string Description { get; set; } = "Causes nearby enemies to attack each other for 5 seconds.";
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

            foreach (var player in Player.List.Where(p => p.Role.Team != ev.Player.Role.Team && p.IsAlive))
            {
                player.EnableEffect(EffectType.Ensnared, 5); 
            }

            ev.Player.Broadcast(5, "Enemies are attacking each other!");
        }
    }
}