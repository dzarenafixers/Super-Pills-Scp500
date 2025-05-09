using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class MorphPill : CustomItem
    {
        public override uint Id { get; set; } = 22222;
        public override string Name { get; set; } = "Morph Pill";
        public override string Description { get; set; } = "Disguises you as an SCP!";
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

            var scpForms = new RoleTypeId[]
            {
                RoleTypeId.Scp173,
                RoleTypeId.Scp106,
                RoleTypeId.Scp939,
                RoleTypeId.Scp049,
            };

            var randomSCP = scpForms[UnityEngine.Random.Range(0, scpForms.Length)];
            ev.Player.Role.Set(randomSCP, (SpawnReason)RoleChangeReason.RemoteAdmin);
            ev.Player.ShowHint("🎭 تم تنكرك كشكل SCP!", 3);
        }
    }
}