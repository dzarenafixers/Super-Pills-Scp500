using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Items
{
    [CustomItem(ItemType.SCP500)]
    public class ClonePill : CustomItem
    {
        public override uint Id { get; set; } = 222;
        public override string Name { get; set; } = "Clone Pill";
        public override string Description { get; set; } = "Creates a clone of yourself to distract enemies for 5 seconds.";
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

            // إنشاء نسخة مرئية للاعب
            var clone = Object.Instantiate(ev.Player.GameObject); // نسخ الكائن المرئي للاعب
            clone.transform.position = ev.Player.Position + new Vector3(0, 0, 2); // وضع النسخة أمام اللاعب
            clone.name = "Clone";

            // تعطيل التحكم في النسخة
            var cloneComponents = clone.GetComponentsInChildren<MonoBehaviour>();
            foreach (var component in cloneComponents)
            {
                if (!(component is Transform)) // الاحتفاظ بالمكونات الضرورية فقط
                    Object.Destroy(component);
            }

            // تدمير النسخة بعد 5 ثوانٍ
            Object.Destroy(clone, 5f);

            ev.Player.Broadcast(5, "You created a clone to distract enemies!");
        }
    }
}