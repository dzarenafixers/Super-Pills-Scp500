using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SCP500Expanded.Items
{
    [CustomItem (ItemType.SCP500)]

    public class AnomalyPill : CustomItem
    {
        public override uint Id { get; set; } = 5004;
        public override string Name { get; set; } = "Anomaly Pill";
        public override string Description { get; set; } = "Switches your team to an enemy team while keeping inventory.";
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

            RoleTypeId newRole = ev.Player.Role.Team switch
            {
                Team.FoundationForces => RoleTypeId.ChaosConscript,
                Team.ChaosInsurgency => RoleTypeId.NtfPrivate,
                Team.Scientists => RoleTypeId.ClassD,
                Team.ClassD => RoleTypeId.Scientist,
                _ => ev.Player.Role.Type
            };

            ev.Player.Role.Set(newRole, RoleSpawnFlags.AssignInventory);
        }
    }
}