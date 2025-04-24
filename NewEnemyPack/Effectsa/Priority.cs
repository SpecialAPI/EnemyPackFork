using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    public static class Priority
    {
        static Dictionary<int, PrioritySO> Rarity_DB = new Dictionary<int, PrioritySO>();
        static Dictionary<int, PrioritySO> Rarity_NoReroll_DB = new Dictionary<int, PrioritySO>();

        static public PrioritySO Weight(int Value)
        {

             if (Rarity_DB.ContainsKey(Value))
             {
                Rarity_DB.TryGetValue(Value, out PrioritySO rarity);
                return rarity;
             }



            PrioritySO NewRarity = ScriptableObject.CreateInstance<PrioritySO>();
            NewRarity.priorityValue = Value;
            Rarity_DB.Add(Value, NewRarity);

            return NewRarity;
        }

    }
}
