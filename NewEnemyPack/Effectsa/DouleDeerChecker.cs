using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class DoulaDeerChecker : EffectSO
    {
        // Token: 0x0600000D RID: 13 RVA: 0x00003C9C File Offset: 0x00001E9C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (stats.EnemiesOnField.Count != 5)
            {
                exitAmount++;
            }
            return exitAmount > 0;
        }
    }
}
