using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NewEnemyPack.Effectsa
{
    public class CustomAbilitySelector_Intijar : BaseAbilitySelectorSO
    {
        public override bool UsesRarity => true;

        public override int GetNextAbilitySlotUsage(List<CombatAbility> abilities, IUnit unit)
        {
            int maxExclusive = 0;
            foreach (CombatAbility ability in abilities)
                maxExclusive += ability.rarity.rarityValue;
            int num1 = UnityEngine.Random.Range(0, maxExclusive);
            int num2 = 0;
            for (int index = 0; index < abilities.Count; ++index)
            {
                num2 += abilities[index].rarity.rarityValue;
                if (num1 < num2)
                {

                    Debug.Log(abilities[index].ability._abilityName);
                    if (abilities[index].ability._abilityName == "Brainstorm")
                    {


                        if (unit.SimpleGetStoredValue("IntijarValue") > 0 || CombatManager._instance._stats.EnemiesOnField.Values.Count <= 1)
                        {
                            return GetNextAbilitySlotUsage(abilities, unit);

                        }
                        unit.SimpleSetStoredValue("IntijarValue", 1);

                    }
                    return index;
                }
            }
            return -1;
        }

    }
}
