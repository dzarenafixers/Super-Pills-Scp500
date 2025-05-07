using CustomSCP500;
using Exiled.API.Features;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using SCP500Expanded.Items; // مسار الحبات

namespace SCP500Expanded
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        public override string Name => "SuperSCP500";
        public override string Author => "MONCEF50G";
        public override string Prefix => "scp500xp";

        // إعلان كل الحبات
        public AbyssPill AbyssPill;
        public AscentPill AscentPill;
        public AnomalyPill AnomalyPill;
        public ApexPill ApexPill;
        public AtomPill AtomPill;
        public AvatarPill AvatarPill;
        public ArcanePill ArcanePill;
        public ArtifactPill ArtifactPill;
        public AuroraPill AuroraPill;
        public AegisPill AegisPill;
        public SuicidePill SuicidePill;
        public MorphPill MorphPill;

        public override void OnEnabled()
        {
            Instance = this;
            
            // إنشاء نسخ لكل الحبات
            AbyssPill = new AbyssPill();
            AnomalyPill = new AnomalyPill();
            ApexPill = new ApexPill();
            ArcanePill = new ArcanePill();
            AtomPill = new AtomPill();
            AscentPill = new AscentPill();
            AvatarPill = new AvatarPill();
            ArcanePill = new ArcanePill();
            ArtifactPill = new ArtifactPill();
            AuroraPill = new AuroraPill();
            AegisPill = new AegisPill();
            SuicidePill = new SuicidePill();
            MorphPill = new MorphPill();

            // تسجيل كل الحبات
          CustomItem.RegisterItems();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            // تنظيف عند إيقاف البلغن
            Instance = null;
            base.OnDisabled();
        }
    }
}
