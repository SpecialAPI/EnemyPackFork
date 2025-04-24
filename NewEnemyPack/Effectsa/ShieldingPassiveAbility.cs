using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    public class ShieldingPassiveAbility : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate { get { return true; } }

        public override bool DoesPassiveTrigger { get { return true; } }

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;

            IntegerReference integerReference = args as IntegerReference;
            if (integerReference == null)
            {
                return;
            }
            int value = integerReference.value;

            CombatManager.Instance.ProcessImmediateAction(new SelfMoveFieldsAction(this._Field, value, unit.SlotID, unit.Size, unit.IsUnitCharacter));
        }

        public override void OnPassiveConnected(IUnit unit) { }
        public override void OnPassiveDisconnected(IUnit unit) { }

        public FieldEffect_SO _Field;
    }
}

