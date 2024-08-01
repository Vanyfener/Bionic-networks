using System;
using Verse;
using RimWorld;

namespace BionicNetworks.Events
{
    internal class GameCondition_ConditionToSayHello: GameCondition
    {
        public override void Init()
        {
            base.Init();
            Log.Message("Starting greeting for you!");
        }
        public override void GameConditionDraw(Map map)
        {
            base.GameConditionDraw(map);
            if (Find.TickManager.TicksGame % 1000 == 0)
            {
                SayHello();
            }
        }
        private void SayHello()
        {
            Log.Message("Hello to you in a game condition!");
            foreach (var map in AffectedMaps)
            {
                foreach (var pawn in map.mapPawns.AllPawns)
                {
                    pawn.TakeDamage(new DamageInfo(DamageDefOf.Bite, 4f));
                }
            }
        }
        public override void End()
        {
            base.End();
            Log.Message("Ending to your hello...");
        }
    }
}
