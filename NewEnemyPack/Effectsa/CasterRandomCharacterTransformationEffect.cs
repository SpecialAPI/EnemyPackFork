using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class CasterRandomCharacterTransformationEffect : EffectSO
    {
        public bool _fullyHeal = true;

        public bool _maintainTimelineAbilities;

        public bool _maintainMaxHealth;

        public bool _currentToMaxHealth;

        public EnemySO _enemyTransformation;

        [CharacterRef]
        public string _characterTransformation = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (caster.IsUnitCharacter)
            {

                int index1 = Random.Range(0, LoadedDBsHandler.CharacterDB._charactersList.Count);
                string charactername = LoadedDBsHandler._CharacterDB._charactersList[index1];
                CharacterSO character = LoadedAssetsHandler.GetCharacter(charactername);
                if (character == null || character.Equals(null))
                {
                    return false;
                }

                return stats.TryTransformCharacter(caster.ID, character, _fullyHeal, _maintainMaxHealth, _currentToMaxHealth);
            }

            return stats.TryTransformEnemy(caster.ID, _enemyTransformation, _fullyHeal, _maintainTimelineAbilities, _maintainMaxHealth, _currentToMaxHealth);
        }
    }
}
