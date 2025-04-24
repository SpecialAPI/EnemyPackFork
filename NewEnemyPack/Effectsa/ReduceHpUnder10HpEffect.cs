using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class ReduceHpUnder10HpEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : -1;


                    if (targetSlotInfo.Unit.CurrentHealth < 15)
                        exitAmount += targetSlotInfo.Unit.ReduceHealthTo(entryVariable);

                    else
                        return flag;
                }
            }
            return flag;
        }
    }
}
