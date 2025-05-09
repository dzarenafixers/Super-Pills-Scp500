using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class RevivePill : CustomItem
    {
        public override uint Id { get; set; } = 5005;
        public override string Name { get; set; } = "Revive Pill";
        public override string Description { get; set; } = "Revives a dead teammate to your team, keeping their original role if possible.";
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

            // البحث عن أقرب لاعب ميت
            var deadPlayer = Player.List.FirstOrDefault(p => !p.IsAlive);
            
            if (deadPlayer != null)
            {
                RoleTypeId reviveRole = deadPlayer.Role.Type; // الاحتفاظ بنفس الدور السابق

                // إذا كان الدور غير متوافق مع فريق اللاعب، يتم تغييره لدور افتراضي يناسب الفريق
                switch (ev.Player.Role.Team)
                {
                    case Team.FoundationForces when reviveRole.GetTeam() != Team.FoundationForces:
                        reviveRole = RoleTypeId.NtfPrivate;
                        break;
                    case Team.ClassD when reviveRole.GetTeam() != Team.ClassD:
                        reviveRole = RoleTypeId.ChaosConscript;
                        break;
                    case Team.FoundationForces when reviveRole.GetTeam() != Team.FoundationForces:
                        reviveRole = RoleTypeId.Scientist;
                        break;
                    case Team.ChaosInsurgency when reviveRole.GetTeam() != Team.ChaosInsurgency:
                        reviveRole = RoleTypeId.ClassD;
                        break;
                }

                // إحياء اللاعب الميت بالدور المحدد
                deadPlayer.GrantLoadout(reviveRole);
                ev.Player.Broadcast(5, $"You revived {deadPlayer.Nickname} with role {reviveRole}!");
            }
            else
            {
                ev.Player.Broadcast(5, "No dead teammates to revive!");
            }
        }
    }
}