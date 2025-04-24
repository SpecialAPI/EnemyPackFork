using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class PercentHealMod_PerformEffect_Item : BaseItem
    {
        public IncreaseHealDealtPerformEffectWearable item;
        public override BaseWearableSO Item { get => item; }
        public EffectInfo[] Effects { get { return item.Effects; } set { item.Effects = value; } }
        public EffectorConditionSO[] HealPerformConditions { get { return item._healPerformConditions; } set { item._healPerformConditions = value; } }
        public int percentToModify { set { item.percentToModify = value; } }
        public bool IncreaseHealing { set { item.IncreaseHealing = value; } }
        public bool ImmediateEffect { set { item.ImmediateEffect = value; } }
        public PercentHealMod_PerformEffect_Item(string itemID = "DefaultID_Item")
        {
            item = ScriptableObject.CreateInstance<IncreaseHealDealtPerformEffectWearable>();
            InitializeItemData(itemID);
        }
    }
}
