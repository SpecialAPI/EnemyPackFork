using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public static class Conditions
    {
        public static dynamic Chance<T>(int num)
        {
            if (typeof(T) == typeof(EffectorConditionSO))
            {
                PercentageEffectorCondition percentageEffectorCondition = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
                percentageEffectorCondition.triggerPercentage = num;
                return percentageEffectorCondition;
            }

            if (typeof(T) == typeof(EffectConditionSO))
            {
                PercentageEffectCondition percentageEffectCondition = ScriptableObject.CreateInstance<PercentageEffectCondition>();
                percentageEffectCondition.percentage = num;
                return percentageEffectCondition;
            }

            return new Exception("Return type of Chance() not EffectConditionSO or EffectorConditionSO.");
        }

        public static PercentageEffectCondition Chance(int num)
        {
            PercentageEffectCondition percentageEffectCondition = ScriptableObject.CreateInstance<PercentageEffectCondition>();
            percentageEffectCondition.percentage = num;
            return percentageEffectCondition;
        }
    }
}
