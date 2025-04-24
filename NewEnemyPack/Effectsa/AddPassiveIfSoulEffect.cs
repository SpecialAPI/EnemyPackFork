using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class AddPassiveIfSoulEffect : EffectSO
    {
        [Header("Passives To Swap Data")]
        public BasePassiveAbilitySO _passiveToAdd;

        public EnemySO _enemyToAdd;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && ((EnemyCombat)targetSlotInfo.Unit).Enemy == _enemyToAdd )
                {
                    targetSlotInfo.Unit.AddPassiveAbility(_passiveToAdd);
                    exitAmount++;
                }
            }

            return exitAmount > 0;
        }
    }
}
