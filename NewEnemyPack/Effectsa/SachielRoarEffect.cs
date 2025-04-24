using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class SachielRoarEffect : EffectSO
    {
        // Token: 0x0600000D RID: 13 RVA: 0x00003C9C File Offset: 0x00001E9C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            CombatManager.Instance.AddUIAction(new PlayStatusEffectSoundAndWaitUIAction("event:/Sachiel/SachielRoar", 2f));
            exitAmount = entryVariable;
            return exitAmount > 0;
        }
    }
}
