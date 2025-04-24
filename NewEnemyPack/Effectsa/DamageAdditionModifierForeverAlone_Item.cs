using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class DamageAdditionModifierForeverAlone_Item : BaseItem
    {
        public ForeverAloneAdditionDamageModifierSetterWearable item;

        public override BaseWearableSO Item => item;

        public bool AffectDamageDealtInsteadOfReceived
        {
            set
            {
                item._useDealt = value;
            }
        }

        public int ToAdd
        {
            set
            {
                item._toAdd = value;
            }
        }

        public DamageAdditionModifierForeverAlone_Item(string itemID = "DefaultID_Item", int toAdd = 1, bool useDealt = false)
        {
            item = ScriptableObject.CreateInstance<ForeverAloneAdditionDamageModifierSetterWearable>();
            item._useDealt = useDealt;
            item._toAdd = toAdd;
            InitializeItemData(itemID);
        }
    }
}
