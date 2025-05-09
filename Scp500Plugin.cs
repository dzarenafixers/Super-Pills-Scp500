// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
 // ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
using System;
using CustomSCP500;
using Exiled.API.Features;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using SCP500Expanded.Items;
// DZCP SUPPORTED ALL CODES FOR MONCEF50G 
// SPECIAL THX TO DZCP DEVLOPERS TEAM
namespace SCP500Expanded
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;

        public override string Name => "SuperSCP500";
        public override string Author => "MONCEF50G & dzarenafixer";
        public override string Prefix => "scp500xp";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(9, 5, 2);

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

        public PowerPill PowerPill;
        public GhostPill GhostPill;
        public AntiGravityPill AntiGravityPill;
        public RevivePill RevivePill;
        public ChaosPill ChaosPill;
        public LuckPill LuckPill;
        public AdvancedHealingPill AdvancedHealingPill;
        public TeleportationPill TeleportationPill;
        public HypnosisPill HypnosisPill;
        public GiantPill GiantPill;
        public MiniPill MiniPill;
        public ClonePill ClonePill;

        public override void OnEnabled()
        {
            Instance = this;

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
            PowerPill = new PowerPill();
            GhostPill = new GhostPill();
            AntiGravityPill = new AntiGravityPill();
            RevivePill = new RevivePill();
            ChaosPill = new ChaosPill();
            LuckPill = new LuckPill();
            AdvancedHealingPill = new AdvancedHealingPill();
            TeleportationPill = new TeleportationPill();
            HypnosisPill = new HypnosisPill();
            GiantPill = new GiantPill();
            MiniPill = new MiniPill();
            ClonePill = new ClonePill();

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