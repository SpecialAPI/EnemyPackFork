using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class PreviousExitValueChecker : EffectSO
    {
        // Token: 0x0600028F RID: 655 RVA: 0x00019DB0 File Offset: 0x00017FB0
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = base.PreviousExitValue;
            return exitAmount >= this.howmuch;
        }
        public int howmuch;
    }
}
