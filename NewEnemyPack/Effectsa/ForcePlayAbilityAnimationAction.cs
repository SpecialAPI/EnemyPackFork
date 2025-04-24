using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class ForcePlayAbilityAnimationAction : CombatAction
    {
        // Token: 0x060005ED RID: 1517 RVA: 0x00039242 File Offset: 0x00037442
        public ForcePlayAbilityAnimationAction(AttackVisualsSO visuals, BaseCombatTargettingSO targetting, IUnit caster)
        {
            this._visuals = visuals;
            this._targetting = targetting;
            this._caster = caster;
        }

        // Token: 0x060005EE RID: 1518 RVA: 0x00039261 File Offset: 0x00037461
        public override IEnumerator Execute(CombatStats stats)
        {
            TargetSlotInfo[] targets = null;
            bool areTargetSlots = true;
            bool flag = this._targetting != null;
            if (flag)
            {
                targets = this._targetting.GetTargets(stats.combatSlots, this._caster.SlotID, this._caster.IsUnitCharacter);
                areTargetSlots = this._targetting.AreTargetSlots;
            }
            bool animsWasFalse = false;
            bool flag2 = !stats.combatUI._animations.CanTriggerAnimations;
            if (flag2)
            {
                animsWasFalse = true;
                stats.combatUI._animations.CanTriggerAnimations = true;
            }
            yield return stats.combatUI.PlayAbilityAnimation(this._visuals, targets, areTargetSlots);
            bool flag3 = animsWasFalse;
            if (flag3)
            {
                stats.combatUI._animations.CanTriggerAnimations = false;
            }
            yield break;
        }

        // Token: 0x0400021B RID: 539
        public BaseCombatTargettingSO _targetting;

        // Token: 0x0400021C RID: 540
        public AttackVisualsSO _visuals;

        // Token: 0x0400021D RID: 541
        public IUnit _caster;
    }
}
