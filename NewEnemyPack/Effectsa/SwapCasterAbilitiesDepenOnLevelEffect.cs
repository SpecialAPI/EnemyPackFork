using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class SwapCasterAbilitiesDepenOnLevelEffect : EffectSO
    {
        // Token: 0x06001A00 RID: 6656 RVA: 0x000439F2 File Offset: 0x00041BF2
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if ((caster as CharacterCombat).Rank == 0)
            {
                caster.SwapWithExtraAbilities(this._abilitiesToSwap);
            }
            else if ((caster as CharacterCombat).Rank == 1)
            {
                caster.SwapWithExtraAbilities(this._abilitiesToSwap1);
            }
            else if ((caster as CharacterCombat).Rank == 2)
            {
                caster.SwapWithExtraAbilities(this._abilitiesToSwap2);
            }
            else
            {
                caster.SwapWithExtraAbilities(this._abilitiesToSwap3);
            }
            return true;
        }

        // Token: 0x0400104C RID: 4172
        [Header("Abilities To Swap Data")]
        [SerializeField]
        public ExtraAbilityInfo[] _abilitiesToSwap;
        public ExtraAbilityInfo[] _abilitiesToSwap1;
        public ExtraAbilityInfo[] _abilitiesToSwap2;
        public ExtraAbilityInfo[] _abilitiesToSwap3;
    }
}
