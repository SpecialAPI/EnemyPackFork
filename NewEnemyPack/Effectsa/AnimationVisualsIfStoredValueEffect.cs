using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class AnimationVisualsIfStoredValueEffect : EffectSO
    {
        // Token: 0x06001894 RID: 6292 RVA: 0x0003E1B6 File Offset: 0x0003C3B6
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (caster.SimpleGetStoredValue(valueName) > 0)
            {
                CombatManager.Instance.AddUIAction(new PlayAbilityAnimationAction(this._visuals, this._animationTarget, caster));
            }
            exitAmount = 0;
            return true;
        }

        // Token: 0x04000F4A RID: 3914
        [Header("Visual")]
        [SerializeField]
        public AttackVisualsSO _visuals;

        // Token: 0x04000F4B RID: 3915
        [SerializeField]
        public BaseCombatTargettingSO _animationTarget;

        public string valueName;
    }
}
