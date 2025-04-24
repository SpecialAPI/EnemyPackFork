using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class TargetStoredValueCheckerEffect : EffectSO
    {
        // Token: 0x060018D8 RID: 6360 RVA: 0x0003F660 File Offset: 0x0003D860
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    exitAmount = targetSlotInfo.Unit.SimpleGetStoredValue(this._valueName);
                }
            }
            return exitAmount > 0;
        }



        // Token: 0x04000F6A RID: 3946
        [SerializeField]
        public string _valueName;

    }
}
