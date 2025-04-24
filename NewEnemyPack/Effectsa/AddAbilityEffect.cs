using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    internal class AddAbilityEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;


            int index1 = Random.Range(0,LoadedDBsHandler.CharacterDB._charactersList.Count);
            string charactername = LoadedDBsHandler._CharacterDB._charactersList[index1];
   

            CharacterSO fool = LoadedAssetsHandler.GetCharacter(charactername);
            int abilitynumber = 0;


            if (fool.rankedData.Count > 1)
            {
               
                abilitynumber = Random.Range(0, fool.rankedData[((CharacterCombat)caster)._rank].rankAbilities.Length);
            }
            else
            {
                abilitynumber = Random.Range(0, fool.rankedData[0].rankAbilities.Length);
            }



            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();

            if (fool.rankedData.Count > 1)
            {
                extraAbilityInfo.ability = fool.rankedData[((CharacterCombat)caster)._rank].rankAbilities[abilitynumber].ability;
                extraAbilityInfo.cost = fool.rankedData[((CharacterCombat)caster)._rank].rankAbilities[abilitynumber].cost;
            }
            else
            {
                extraAbilityInfo.ability = fool.rankedData[0].rankAbilities[abilitynumber].ability;
                extraAbilityInfo.cost = fool.rankedData[0].rankAbilities[abilitynumber].cost;
            }




            CharacterCombat characterCombat = caster as CharacterCombat;
            bool flag1 = characterCombat != null;
            if (flag1)
            {
                characterCombat.AddExtraAbility(extraAbilityInfo);

                exitAmount++;
            }


            return exitAmount > 0;

        }
    }
}
