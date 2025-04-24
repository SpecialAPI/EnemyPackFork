using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class CasterStoredValueParasiteEffect : EffectSO
    {
        // Token: 0x060019FE RID: 6654 RVA: 0x00043918 File Offset: 0x00041B18
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    IUnit unit = targetSlotInfo.Unit;
                    if (this._initialize)
                    {
                        int newValue = Mathf.Max(1, unit.CurrentHealth);
                        int newValue2 = unit.IsUnitCharacter ? (1 + unit.ID) : (-(1 + unit.ID));


                        caster.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.ParasiteIDPA.ToString(), newValue2);
                        caster.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString(), newValue);

                        exitAmount++;
                    }
                    else
                    {
                        if (this._usePreviousExitValue)
                        {
                            entryVariable *= base.PreviousExitValue;
                        }
                        int num = caster.SimpleGetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString());
                        num += entryVariable;
                        caster.SimpleSetStoredValue(UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString(), num);
                        exitAmount += entryVariable;
                    }
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x0400104A RID: 4170
        [SerializeField]
        public bool _initialize;

        // Token: 0x0400104B RID: 4171
        [SerializeField]
        public bool _usePreviousExitValue = true;
    }
}
