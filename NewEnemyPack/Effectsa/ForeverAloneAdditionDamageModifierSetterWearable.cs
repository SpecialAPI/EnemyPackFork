using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class ForeverAloneAdditionDamageModifierSetterWearable : BaseWearableSO
    {
        [Header("Addition Data")]
        public bool _useDealt;

        public int _toAdd;

        public override bool IsItemImmediate => true;

        public override bool DoesItemTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            int count = CombatManager._instance._stats.CharactersOnField.Values.Count;
            int newdamage = this._toAdd - (count * 2);
            if (_useDealt)
            {
                DamageDealtValueChangeException ex = args as DamageDealtValueChangeException;
                if (ex != null && !ex.Equals(null))
                {
                    ex.AddModifier(new AdditionValueModifier(dmgDealt: true, newdamage));
                }
            }
            else
            {
                DamageReceivedValueChangeException ex2 = args as DamageReceivedValueChangeException;
                if (ex2 != null && !ex2.Equals(null))
                {
                    ex2.AddModifier(new AdditionValueModifier(dmgDealt: false, newdamage));
                }
            }
        }
    }
}
