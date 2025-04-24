using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class ProduceTargetManaEffect : EffectSO
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                bool hasUnit = targetSlotInfo.HasUnit;
                if (hasUnit)
                {

                    targetSlotInfo.Unit.GenerateHealthMana(entryVariable);

                }
            }


            return exitAmount > 0;
        }
    }
}
