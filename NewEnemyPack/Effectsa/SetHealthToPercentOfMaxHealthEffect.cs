using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class SetHealthToPercentOfMaxHealthEffect : EffectSO
    {
        public bool _increase = true;

        public float _entryAsPercentage;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit)
                {
                    int num = entryVariable;

                    int newMaxHealth = (int)Math.Floor(targets[i].Unit.MaximumHealth * 0.2);
                    if (targets[i].Unit.CurrentHealth > newMaxHealth)
                    {
                        targets[i].Unit.SetHealthTo(newMaxHealth);
                        exitAmount += num;
                    }
                }
            }

            return exitAmount > 0;
        }
    }
}
