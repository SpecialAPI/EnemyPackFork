using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class ProduceCoinsIfUnitHasItemEffect : EffectSO
    {
        // Token: 0x06001898 RID: 6296 RVA: 0x0003E24C File Offset: 0x0003C44C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (entryVariable <= 0)
            {
                return false;
            }
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {


                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.HasUsableItem)
                {

                    exitAmount = stats.TryGainCurrency(entryVariable, true);
                    if (exitAmount > 0)
                    {
                        CombatManager.Instance.AddUIAction(new PlayCurrencyEffectUIAction(caster.ID, caster.IsUnitCharacter, exitAmount, isMultiplier: false));
                    }


                }
            }
            return exitAmount > 0;
        }
        public bool _loseFromPlayer = true;
    }
}
