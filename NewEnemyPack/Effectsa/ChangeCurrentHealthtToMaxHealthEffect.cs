using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class ChangeCurrentHealthtToMaxHealthEffect : EffectSO
    {
        // Token: 0x0600193A RID: 6458 RVA: 0x0004105C File Offset: 0x0003F25C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    targets[i].Unit.SetHealthTo(targets[i].Unit.MaximumHealth);
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x04000FEA RID: 4074
        [SerializeField]
        public bool _increase = true;

        // Token: 0x04000FEB RID: 4075
        [SerializeField]
        public bool _entryAsPercentage;
    }
}
