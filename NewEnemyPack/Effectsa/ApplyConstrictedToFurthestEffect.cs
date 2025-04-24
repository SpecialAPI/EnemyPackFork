using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class ApplyConstrictedToFurthestEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            TargetSlotInfo[] furthestToClosestRight = Targeting.GenerateSlotTarget(new int[] { 4, 3, 2, 1 }, true).GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);
            TargetSlotInfo[] furthestToClosestLeft = Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1 }, true).GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter);

            foreach (TargetSlotInfo target in furthestToClosestRight)
            {
                if (target.HasUnit)
                {
                    stats.combatSlots.ApplyFieldEffect(target.SlotID, target.IsTargetCharacterSlot, StatusField.Constricted, entryVariable);
                    exitAmount++;
                    break;
                }
            }

            foreach (TargetSlotInfo target in furthestToClosestLeft)
            {
                if (target.HasUnit)
                {
                    stats.combatSlots.ApplyFieldEffect(target.SlotID, target.IsTargetCharacterSlot, StatusField.Constricted, entryVariable);
                    exitAmount++;
                    break;
                }
            }

            return exitAmount > 0;
        }
    }
}
