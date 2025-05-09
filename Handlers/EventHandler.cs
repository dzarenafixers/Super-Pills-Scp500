using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
// هذا المشروع محمي من قبل حقوق االطبع والنشر MTI , صانعه الاصلي MOCNEF50G 
// ويشرف عليه dzarenafixer لذا نرجو عدم مخالفة القواعد واستشر المالك اذا اردت اخذه وشكرا
namespace SCP500Expanded.Handlers
{
    public static class EventHandler
    {
        public static void RegisterEvents()
        {
            CustomItem.RegisterItems();
            new Items.AegisPill();
            new Items.ApexPill();
            new Items.AuroraPill();
            new Items.AnomalyPill();
            new Items.AtomPill();
            new Items.AbyssPill();
            new Items.AscentPill();
            new Items.AvatarPill();
            new Items.ArcanePill();
            new Items.ArtifactPill();
            new Items.PowerPill();        
            new Items.GhostPill();         
            new Items.AntiGravityPill();  
            new Items.RevivePill();       
            new Items.ChaosPill();       
            new Items.MorphPill(); 
            new Items.LuckPill();           
            new Items.AdvancedHealingPill();
            new Items.TeleportationPill();  
            new Items.HypnosisPill();      
            new Items.GiantPill();        
            new Items.MiniPill();          
            new Items.ClonePill();       
            ;
        }

        public static void UnregisterEvents()
        {
            CustomItem.UnregisterItems();
        }
    }
}