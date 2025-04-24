using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    internal class DamageWeakestEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = false;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            int num = -1;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit.IsAlive)
                {
                    if (num < 0)
                    {
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth < num)
                    {
                        list.Clear();
                        list.Add(targetSlotInfo);
                        num = targetSlotInfo.Unit.CurrentHealth;
                    }
                    else if (targetSlotInfo.Unit.CurrentHealth == num)
                    {
                        list.Add(targetSlotInfo);
                    }
                }
            }
            foreach (TargetSlotInfo targetSlotInfo2 in list)
            {
                int targetSlotOffset = areTargetSlots ? (targetSlotInfo2.SlotID - targetSlotInfo2.Unit.SlotID) : -1;
                int amount = entryVariable;
                DamageInfo damageInfo;
                if (this._indirect)
                {
                    damageInfo = targetSlotInfo2.Unit.Damage(amount, null, this._deathType, targetSlotOffset, false, false, true, CombatType_GameIDs.Dmg_Normal.ToString());
                }
                else
                {
                    amount = caster.WillApplyDamage(amount, targetSlotInfo2.Unit);
                    damageInfo = targetSlotInfo2.Unit.Damage(amount, caster, this._deathType, targetSlotOffset, true, true, this._ignoreShield, CombatType_GameIDs.Dmg_Normal.ToString());
                }
                flag |= damageInfo.beenKilled;
                exitAmount += damageInfo.damageAmount;

            }
            if (!this._indirect && exitAmount > 0)
            {
                caster.DidApplyDamage(exitAmount);
            }
            if (!this._returnKillAsSuccess)
            {
                return exitAmount > 0;
            }
            return flag;
        }

        // Token: 0x04000FF3 RID: 4083
        [SerializeField]
        public bool _directHeal = true;

        // Token: 0x04000FF4 RID: 4084
        [SerializeField]
        public bool _checkCanHeal = true;

        public string _deathType;

        public bool _ignoreShield = false;

        public bool _returnKillAsSuccess;

        public bool _indirect = false;
    }
}

