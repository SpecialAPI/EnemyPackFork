using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class RefreshMoveIfStoredValueNotZero : EffectSO
    {
        // Token: 0x06000037 RID: 55 RVA: 0x000074A0 File Offset: 0x000056A0
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].Unit.SimpleGetStoredValue(_valueName) > 0)
                {
                    if (targets[i].HasUnit && targets[i].Unit.RestoreSwapUse())
                    {
                        exitAmount++;

                    }
                    targets[i].Unit.SimpleSetStoredValue(_valueName, 0);
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x0400002E RID: 46
        [SerializeField]
        public bool _doesExhaustInstead;

        // Token: 0x0400002F RID: 47
        [SerializeField]
        public string _valueName;
    }
}
