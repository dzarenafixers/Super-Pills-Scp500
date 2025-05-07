using Exiled.API.Interfaces;
using System.ComponentModel;

namespace CustomSCP500
{
    public class Config : IConfig
    {
        [Description("Enable or disable the plugin.")]
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; }

        [Description("List of SCP-500 custom pills and their abilities.")]
        public string[] Pills { get; set; } = 
        {
            "WallVision", // رؤية الأعداء من خلال الجدران
            "InfiniteRun", // الركض اللا متناهي
            "SpeedBoost", // زيادة السرعة
            "Betrayal", // الخيانة
            "Shrink", // تصغير الجسم
            "RandomTeleport", // النقل العشوائي
            "HealthBoost", // زيادة الدم
            "Invisibility", // التخفي
            "DoorHack", // اختراق الأبواب
            "RandomItem" // شيء عشوائي
        };
    }
}