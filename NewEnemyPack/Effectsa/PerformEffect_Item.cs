using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class PerformEffectBloodyValve_Item : BaseItem
    {
        public BloodyValvePerformEffectWearable item;

        public override BaseWearableSO Item => item;

        public EffectInfo[] Effects
        {
            get
            {
                return item.effects;
            }
            set
            {
                item.effects = value;
            }
        }

        public bool IsEffectImmediate
        {
            set
            {
                item._immediateEffect = value;
            }
        }

        public PerformEffectBloodyValve_Item(string itemID = "DefaultID_Item", EffectInfo[] effects = null, bool immediate = false)
        {
            item = ScriptableObject.CreateInstance<BloodyValvePerformEffectWearable>();
            item._immediateEffect = immediate;
            item.effects = effects;
            InitializeItemData(itemID);
        }
    }
}
