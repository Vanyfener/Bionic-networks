using Verse;
using RimWorld;

namespace BionicNetworks.Events
{
    /// <summary>
    /// IncidentWorker class designed to print hello in game console if more colonists than sertain number 😎
    /// </summary>
    public class IncidentWorker_SayHello: IncidentWorker
    {
        private const int COLONIST_AMOUNT_TO_DO_THE_THING = 3;
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            int colonistMapCount = map.mapPawns.ColonistCount;
            if (colonistMapCount < COLONIST_AMOUNT_TO_DO_THE_THING)
            {
                Log.Message($"There are more than {COLONIST_AMOUNT_TO_DO_THE_THING} 🤯!" +
                    $"💖 Also i would like to say that you have {colonistMapCount} colonists 💖!");
                return false;
            }
            return true;
        }
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            LookTargets lookTargets = new LookTargets();
            foreach (var pawn in map.mapPawns.FreeColonists)
            {
                lookTargets.targets.Add(pawn);
                Log.Message(pawn.NameFullColored);
            }

            SendStandardLetter(parms, lookTargets, "AAAAAAAAAAAAAAA");

            return true;
        }
    }
}
