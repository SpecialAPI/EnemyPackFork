using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class DirectDeathIfStoredValueEffect : EffectSO
    {
        // Token: 0x0600196C RID: 6508 RVA: 0x00041B8C File Offset: 0x0003FD8C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {

                float healthcalc = targets[i].Unit.MaximumHealth / 10f;



                if (targets[i].HasUnit)
                {
                    if (targets[i].Unit.SimpleGetStoredValue(_storedvalue) >= Math.Ceiling(healthcalc))
                    {
                        targets[i].Unit.DirectDeath(caster, this._obliterationDeath);
                        exitAmount++;
                    }


                }
            }
            return exitAmount > 0;
        }

        // Token: 0x04000FE1 RID: 4065
        [SerializeField]
        public bool _obliterationDeath;

        // Token: 0x04000FE2 RID: 4066
        [SerializeField]
        public string _storedvalue;
    }
}
