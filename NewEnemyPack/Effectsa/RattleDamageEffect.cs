using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class RattleDamageEffect : EffectSO
    {
        // Token: 0x06001989 RID: 6537 RVA: 0x00042298 File Offset: 0x00040498
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (this._usePreviousExitValue)
            {
                entryVariable *= base.PreviousExitValue;
            }
            exitAmount = 0;
            bool flag = false;
            bool indirect = false;
            int random = Random.Range(0, 101);
            if (random <= 20)
            {
                indirect = true;
            }
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    int targetSlotOffset = areTargetSlots ? (targetSlotInfo.SlotID - targetSlotInfo.Unit.SlotID) : -1;
                    int amount = entryVariable;
                    DamageInfo damageInfo;
                    if (indirect)
                    {
                        damageInfo = targetSlotInfo.Unit.Damage(amount - 1, null, this._deathType, targetSlotOffset, false, false, true);
                    }
                    else
                    {
                        amount = caster.WillApplyDamage(amount, targetSlotInfo.Unit);
                        damageInfo = targetSlotInfo.Unit.Damage(amount, caster, this._deathType, targetSlotOffset, true, true, this._ignoreShield);
                    }
                    flag |= damageInfo.beenKilled;
                    exitAmount += damageInfo.damageAmount;
                }
            }
            if (!indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }
            if (!this._returnKillAsSuccess)
            {
                return exitAmount > 0;
            }
            return flag;
        }

        // Token: 0x04001025 RID: 4133
        [SerializeField]
        public string _deathType = DeathType_GameIDs.Basic.ToString();

        // Token: 0x04001026 RID: 4134
        [SerializeField]
        public bool _usePreviousExitValue;

        // Token: 0x04001027 RID: 4135
        [SerializeField]
        public bool _ignoreShield;

        // Token: 0x04001028 RID: 4136
        [SerializeField]
        public bool _indirect;

        // Token: 0x04001029 RID: 4137
        [SerializeField]
        public bool _returnKillAsSuccess;
    }
}
