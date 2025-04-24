using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class BlazingPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Field")]
        public OnFireFE_SO _Fire;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            IntegerReference integerReference = args as IntegerReference;
            if (integerReference != null)
            {
                int value = integerReference.value;
                CombatManager.Instance.ProcessImmediateAction(new ConstrinctingMoveAction(_Fire, value, unit.SlotID, unit.Size, !unit.IsUnitCharacter));
            }
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            CombatManager.Instance.AddSubAction(new ConstrictedConnectedAction(unit, GetPassiveLocData().text, passiveIcon, _Fire));
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            CombatManager.Instance.AddSubAction(new ConstrictedDisconnectedAction(_Fire.FieldID, unit.SlotID, unit.IsUnitCharacter, unit.Size));
        }
    }
}
