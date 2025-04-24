using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class CheckHealthColorEffect : EffectSO
    {

        public ManaColorSO _Color;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.HealthColor == _Color)
                {
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
}
