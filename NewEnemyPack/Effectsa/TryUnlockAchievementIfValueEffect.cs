using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NewEnemyPack.Effectsa
{
    public class TryUnlockAchievementIfValueEffect : EffectSO
    {
        [UnlockableIDsEnumRef]
        public string _unlockID = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (caster.CurrentHealth == caster.MaximumHealth ) 
            {
            CombatManager.Instance.AddUIAction(new UnlockAchievementEffectUIAction(_unlockID));
            }
            exitAmount = 0;
            return true;
        }
    }
}
