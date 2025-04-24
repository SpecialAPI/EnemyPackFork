using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class PerformRandomAbilityEnemyEffect : EffectSO
    {


        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            int index1 = Random.Range(0, LoadedDBsHandler.EnemyDB.EnemiesList.Count);
            string charactername = LoadedDBsHandler.EnemyDB.EnemiesList[index1];
            EnemySO enemy = LoadedAssetsHandler.GetEnemy(charactername);

            bool result;
            if (enemy != null)
            {

                if (enemy.abilities == null || enemy.abilities.Count <= 0)
                {
                    result = false;
                }
                else
                {
                    int index = Random.Range(0, enemy.abilities.Count);
                    AbilitySO ability = enemy.abilities[index].ability;
                    CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, ability.GetAbilityLocData().text));
                    CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, caster));
                    CombatManager.Instance.AddSubAction(new EffectAction(ability.effects, caster, 0));
                    result = true;
                }
            }
            else
            {
                result = (exitAmount > 0);
            }
            return result;
        }

        // Token: 0x04000061 RID: 97
        [SerializeField]
        public bool _increase = true;

        // Token: 0x04000062 RID: 98
        [SerializeField]
        public bool _entryAsPercentage;
    }
}
