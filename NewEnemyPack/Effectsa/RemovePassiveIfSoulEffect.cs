using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class RemovePassiveIfSoulEffect : EffectSO
    {
        [Header("Passives To Remove Data")]
        [PassiveIDsEnumRef]
        public string m_PassiveID = "Focus";

        public EnemySO _enemy;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && ((EnemyCombat)targetSlotInfo.Unit).Enemy == _enemy)
                {
                    targetSlotInfo.Unit.TryRemovePassiveAbility(m_PassiveID);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
}
