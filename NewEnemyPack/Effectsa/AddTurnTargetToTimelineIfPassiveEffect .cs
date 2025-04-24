using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class AddTurnTargetToTimelineIfPassiveEffect : EffectSO
    {

        public string passive;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }

            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && !targetSlotInfo.IsTargetCharacterSlot && targetSlotInfo.Unit.ContainsPassiveAbility(passive))
                {
                    EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                    stats.timeline.TryAddNewExtraEnemyTurns(unit, entryVariable);
                    exitAmount += entryVariable;
                }
            }

            return true;
        }
    }
}
