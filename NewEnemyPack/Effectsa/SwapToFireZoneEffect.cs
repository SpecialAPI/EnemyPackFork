using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class SwapToFireZoneEffect : EffectSO
    {
        // Token: 0x060000B3 RID: 179 RVA: 0x00006618 File Offset: 0x00004818
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo target in targets)
            {
                if (target.HasUnit && target.Unit.IsUnitCharacter)
                {
                    target.Unit.SimpleSetStoredValue("SeraphimFire", 1);

                    if (stats.combatSlots.UnitInSlotContainsFieldEffect(0, true, StatusField.OnFire._FieldID) || stats.combatSlots.UnitInSlotContainsFieldEffect(1, true, StatusField.OnFire._FieldID) || stats.combatSlots.UnitInSlotContainsFieldEffect(2, true, StatusField.OnFire._FieldID) || stats.combatSlots.UnitInSlotContainsFieldEffect(3, true, StatusField.OnFire._FieldID) || stats.combatSlots.UnitInSlotContainsFieldEffect(4, true, StatusField.OnFire._FieldID))
                    {
                        int secondSlotID = UnityEngine.Random.Range(0, 5); ;
                        while (!stats.combatSlots.UnitInSlotContainsFieldEffect(secondSlotID, true, StatusField.OnFire._FieldID))
                        {
                            secondSlotID = UnityEngine.Random.Range(0, 5);
                        }
                        if (secondSlotID != caster.SlotID)
                            stats.combatSlots.SwapCharacters(caster.SlotID, secondSlotID, true);
                    }
                }
            }
            return exitAmount > 0;
        }
    }
}
