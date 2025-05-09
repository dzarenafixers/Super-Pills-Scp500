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
    public class ChaosPill : CustomItem
    {
        public override uint Id { get; set; } = 33;
        public override string Name { get; set; } = "Chaos Pill";
        public override string Description { get; set; } = "Grants a random effect when used.";
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

            var effects = new[] { EffectType.Scp207, EffectType.Invisible, EffectType.Asphyxiated };
            var randomEffect = effects[UnityEngine.Random.Range(0, effects.Length)];
            ev.Player.EnableEffect(randomEffect, 10); // تطبيق تأثير عشوائي لمدة 10 ثوانٍ
        }
    }
}