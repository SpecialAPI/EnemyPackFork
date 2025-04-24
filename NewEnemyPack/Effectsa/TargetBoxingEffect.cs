using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class TargetBoxingEffect : EffectSO
    {
        // Token: 0x060018F3 RID: 6387 RVA: 0x0003F960 File Offset: 0x0003DB60
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (this._unboxHandler == null || this._unboxHandler.Equals(null))
                {
                    return false;
                }
                bool result;
                if (targetSlotInfo.Unit.IsUnitCharacter)
                {
                    result = stats.TryBoxCharacter(targetSlotInfo.Unit.ID, this._unboxHandler, this._exitType);
                }
                else
                {
                    result = stats.TryBoxEnemy(targetSlotInfo.Unit.ID, this._unboxHandler, this._exitType);
                }


            }
            return true;
        }

        // Token: 0x04000F72 RID: 3954
        [SerializeField]
        public UnboxUnitHandlerSO _unboxHandler;

        // Token: 0x04000F73 RID: 3955
        [SerializeField]
        public string _exitType = CombatType_GameIDs.Exit_Boxing.ToString();
    }
}
