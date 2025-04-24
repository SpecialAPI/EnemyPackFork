using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class RemoveFieldEffectsEffect : EffectSO
    {

        public string field;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit is CharacterCombat)
                        exitAmount += stats.combatSlots.CharacterSlots[targets[i].SlotID].TryRemoveFieldEffect(field);
                    else if (targets[i].Unit is EnemyCombat)
                        exitAmount += stats.combatSlots.EnemySlots[targets[i].SlotID].TryRemoveFieldEffect(field);
                }
            }

            return exitAmount > 0;
        }
    }
}
