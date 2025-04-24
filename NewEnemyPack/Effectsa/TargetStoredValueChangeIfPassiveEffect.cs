using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class TargetStoredValueChangeIfPassiveEffect : EffectSO
    {
        // Token: 0x060018D8 RID: 6360 RVA: 0x0003F660 File Offset: 0x0003D860
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.Unit.ContainsPassiveAbility(passiveAbilitytype))
                {
                    exitAmount = targetSlotInfo.Unit.SimpleGetStoredValue(this._valueName);
                    if (this._randomBetweenPrevious)
                    {
                        entryVariable = UnityEngine.Random.Range(base.PreviousExitValue, entryVariable + 1);
                    }
                    exitAmount += (this._increase ? entryVariable : (-entryVariable));
                    exitAmount = Mathf.Max(this._minimumValue, exitAmount);
                    targetSlotInfo.Unit.SimpleSetStoredValue(this._valueName, exitAmount);
                    if (targetSlotInfo.Unit.SimpleGetStoredValue(this._valueName) >= 10)
                    {
                        CombatManager.Instance.AddUIAction(new UnlockAchievementEffectUIAction("DoulaTragedy"));

                    }

                }
            }
            return exitAmount > 0;
        }

        // Token: 0x04000F68 RID: 3944
        [SerializeField]
        public bool _increase = true;

        // Token: 0x04000F69 RID: 3945
        [SerializeField]
        public int _minimumValue = 1;

        // Token: 0x04000F6A RID: 3946
        [SerializeField]
        public string _valueName;

        // Token: 0x04000F6B RID: 3947
        [SerializeField]
        public bool _randomBetweenPrevious;

        public string passiveAbilitytype;
    }

}
