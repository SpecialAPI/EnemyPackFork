using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class AdditionDamageModifierWithStoredValueSetterWearable_Item : BaseItem
    {
        public AdditionDamageModifierWithStoredValueSetterWearable item;

        public override BaseWearableSO Item => item;


        public TriggerCalls[] SecondaryTriggerOn
        {
            get
            {
                return item._secondPerformTriggersOn;
            }
            set
            {
                item._secondPerformTriggersOn = value;
            }
        }

        public bool SecondaryDoesPopUpInfo
        {
            set
            {
                item._secondDoesPerformItemPopUp = value;
            }
        }

        public EffectorConditionSO[] SecondaryConditions
        {
            get
            {
                return item._secondPerformConditions;
            }
            set
            {
                item._secondPerformConditions = value;
            }
        }

        public bool SecondaryConsumeOnUse
        {
            set
            {
                item._GetsConsumedOnSecondaryUse = value;
            }
        }

        public EffectInfo[] SecondaryEffects
        {
            get
            {
                return item._secondEffects;
            }
            set
            {
                item._secondEffects = value;
            }
        }

        public bool SecondaryIsEffectImmediate
        {
            set
            {
                item._secondImmediateEffect = value;
            }
        }

        public bool Usedealt
        {
            set
            {
                item._useDealt = value;
            }
        }


        public string StoreValue
        {
            get
            {
                return item._valueName;
            }
            set
            {
                item._valueName = value;
            }
        }

        public int ToAdd
        {
            set
            {
                item._toAdd = value;
            }
        }


        public AdditionDamageModifierWithStoredValueSetterWearable_Item(string itemID = "DefaultID_Item", int percentage = 1, bool useDealt = false, bool useInt = false, bool doesIncreaseDmg = false, EffectInfo[] effects = null, bool immediate = false, bool consumed = false, TriggerCalls[] triggers = null)
        {
            item = ScriptableObject.CreateInstance<AdditionDamageModifierWithStoredValueSetterWearable>();
            item._secondEffects = effects;
            item._secondImmediateEffect = immediate;
            item._GetsConsumedOnSecondaryUse = consumed;
            item._secondPerformTriggersOn = triggers;
            InitializeItemData(itemID);
        }
    }
}
