using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class DirectDeathForTubeEffect : EffectSO
    {
        // Token: 0x0600199D RID: 6557 RVA: 0x00042E18 File Offset: 0x00041018
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {

            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    list.Add(targetSlotInfo);
                }
            }
            if (list.Count <= 0)
            {
                return false;
            }
            int index = Random.Range(0, list.Count);
            TargetSlotInfo targetSlotInfo2 = list[index];

            if (targetSlotInfo2.HasUnit)
            {
                exitAmount = targetSlotInfo2.Unit.CurrentHealth;
                targetSlotInfo2.Unit.DirectDeath(caster, false);
            }

            return exitAmount > 0;
        }

        // Token: 0x04001043 RID: 4163
        [SerializeField]
        public bool _obliterationDeath;

        // Token: 0x04001044 RID: 4164
        [SerializeField]
        public bool _killUnderMaxHealth;
    }
}
