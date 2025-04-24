using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class SachielAnimationVisualsEffect : EffectSO
    {
        [Header("Visual")]
        public AttackVisualsSO _visuals;

        public BaseCombatTargettingSO _animationTarget;



        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {


            exitAmount = 0;
            if (stats.BundleDifficulty == BundleDifficulty.Boss)
            {
                return false;
            }

            if (!stats.combatSlots.HasEnemyEmptySlots)
            {
                return false;
            }

            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    if (targetSlotInfo.Unit.MaximumHealth >= 90)
                    {
                        return false;
                    }

                }
            }


            CombatManager.Instance.AddUIAction(new ForcePlayAbilityAnimationAction(_visuals, _animationTarget, caster));
            LoadedDBsHandler.InfoHolder.Run.inGameData.SetIntData("SachielSplash", 1);
            return true;
        }
    }
}
