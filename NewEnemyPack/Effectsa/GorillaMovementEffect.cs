using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class GorillaMovementEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;

            AnimationVisualsEffect animationVisualsEffect = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisualsEffect._animationTarget = Targeting.Slot_Front;
            animationVisualsEffect._visuals = LoadedAssetsHandler.GetCharacter("Mordrake_CH").rankedData[0].rankAbilities[2].ability.visuals;

            SwapToOneSideEffect left = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            left._swapRight = false;
            SwapToOneSideEffect right = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            right._swapRight = true;



            EffectInfo[] LeftInfos = new EffectInfo[] { Effects.GenerateEffect(left, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(left, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(left, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(left, 1, Targeting.Slot_SelfSlot), };
            EffectInfo[] RightInfos = new EffectInfo[] { Effects.GenerateEffect(right, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(right, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(right, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(right, 1, Targeting.Slot_SelfSlot), };
            EffectInfo[] animinfo = new EffectInfo[] { Effects.GenerateEffect(animationVisualsEffect, 1, Targeting.Slot_Front), };
            EffectInfo[] damagestuff = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Targeting.Slot_Front), };

            if (caster.SlotID == 0)
            {
                CombatManager.Instance.AddSubAction(new EffectAction(RightInfos, caster));
                CombatManager.Instance.AddSubAction(new EffectAction(animinfo, caster));
                CombatManager.Instance.AddSubAction(new EffectAction(damagestuff, caster));
                return true;
            }
            else if (caster.SlotID == 4 || UnityEngine.Random.Range(0, 100) < 50)
            {
                CombatManager.Instance.AddSubAction(new EffectAction(LeftInfos, caster));
                CombatManager.Instance.AddSubAction(new EffectAction(animinfo, caster));
                CombatManager.Instance.AddSubAction(new EffectAction(damagestuff, caster));
                return true;
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(RightInfos, caster));
                CombatManager.Instance.AddSubAction(new EffectAction(animinfo, caster));
                CombatManager.Instance.AddSubAction(new EffectAction(damagestuff, caster));
                return true;
            }
        }
    }
}
