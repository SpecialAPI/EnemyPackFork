using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class StatusEffect_ApplyRestrictor_Effect : EffectSO
    {
        // Token: 0x06001A0D RID: 6669 RVA: 0x000450B0 File Offset: 0x000432B0
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (this._Status == null)
            {
                return false;
            }
            if (this._ApplyToFirstUnit || this._JustOneRandomTarget)
            {
                List<TargetSlotInfo> list = new List<TargetSlotInfo>(targets);
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        list.Add(targetSlotInfo);
                        if (this._ApplyToFirstUnit)
                        {
                            break;
                        }
                    }
                }
                if (list.Count > 0)
                {
                    int num = UnityEngine.Random.Range(0, list.Count);
                    exitAmount += this.ApplyStatusEffect(list[num].Unit, entryVariable);
                }
            }
            else
            {
                for (int j = 0; j < targets.Length; j++)
                {
                    if (targets[j].HasUnit)
                    {
                        exitAmount += this.ApplyStatusEffect(targets[j].Unit, entryVariable);
                    }
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x06001A0E RID: 6670 RVA: 0x00045184 File Offset: 0x00043384
        public int ApplyStatusEffect(IUnit unit, int entryVariable)
        {
            int num = this._RandomBetweenPrevious ? UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable;
            if (num < this._Status.MinimumRequiredToApply)
            {
                return 0;
            }
            if (!unit.ApplyStatusEffect(this._Status, 0, num))
            {
                return 0;
            }
            return num;
        }

        // Token: 0x040010B6 RID: 4278
        [Header("Status")]
        public StatusEffect_SO _Status;

        // Token: 0x040010B7 RID: 4279
        [Header("Data")]
        public bool _ApplyToFirstUnit;

        // Token: 0x040010B8 RID: 4280
        public bool _JustOneRandomTarget;

        // Token: 0x040010B9 RID: 4281
        public bool _RandomBetweenPrevious;
    }
}

