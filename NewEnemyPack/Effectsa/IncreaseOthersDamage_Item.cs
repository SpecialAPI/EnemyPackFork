using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class IncreaseOthersDamage_Item : BaseItem
    {
        public IncreaseOthersDamageWearable item;

        public override BaseWearableSO Item => item;

        public EffectInfo[] Effects
        {
            get
            {
                return item._firstEffects;
            }
            set
            {
                item._firstEffects = value;
            }
        }

        public bool IsEffectImmediate
        {
            set
            {
                item._firstImmediateEffect = value;
            }
        }

        public int damageincrease
        {
            set
            {
                item._damageincrease = value;
            }
        }


        public IncreaseOthersDamage_Item(string itemID = "DefaultID_Item", EffectInfo[] effects = null, bool immediate = false, int damage = 0)
        {
            item = ScriptableObject.CreateInstance<IncreaseOthersDamageWearable>();
            item._firstImmediateEffect = immediate;
            item._firstEffects = effects;
            item._damageincrease = damage;
            InitializeItemData(itemID);
        }
    }
}
