using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class SkibidiPill : CustomItem
    {
        public override uint Id { get; set; } = 5007;
        public override string Name { get; set; } = "Morph Pill";
        public override string Description { get; set; } = "Transforms you into a random SCP for 15 seconds.";
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

            var randomScpRoles = new[] { RoleTypeId.Scp049, RoleTypeId.Scp096, RoleTypeId.Scp939 };
            var randomRole = randomScpRoles[UnityEngine.Random.Range(0, randomScpRoles.Length)];

            ev.Player.Role.Set(randomRole); // تحويل اللاعب إلى SCP عشوائي
            Timing.CallDelayed(15, () =>
            {
                ev.Player.Role.Set(RoleTypeId.None); // إعادة اللاعب إلى دوره السابق
            });
        }
    }
}