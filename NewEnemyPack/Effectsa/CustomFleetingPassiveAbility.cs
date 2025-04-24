using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class CustomFleetingPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Fleeting Data")]
        public int _turnsBeforeFleeting = 3;

        public bool _ignoreFirstTurn;

        [UnitStoreValueNamesIDsEnumRef]
        public string fleeting_USD = "FleetingPA";

        [UnitStoreValueNamesIDsEnumRef]
        public string fleetingIgnoreFirstTurn_USD = "FleetingPA_IgnoreFirstTurn";

        public override bool IsPassiveImmediate => false;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            if (_ignoreFirstTurn)
            {
                unit.TryGetStoredData(fleetingIgnoreFirstTurn_USD, out var holder);
                if (holder.m_MainData == 0)
                {
                    holder.m_MainData = 1;
                    return;
                }
            }


            unit.TryGetStoredData("CustomFleeting", out var holder2);
            int mainData = holder2.m_MainData;
            int newnum = 0;
            newnum++;
            if (newnum >= mainData)
            {
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, GetPassiveLocData().text, passiveIcon));
                unit.UnitWillFlee();
                CombatManager.Instance.AddSubAction(new FleetingUnitAction(unit.ID, unit.IsUnitCharacter));
            }

            holder2.m_MainData = mainData - 1;
        }

        public override void OnPassiveConnected(IUnit unit)
        {
            unit.TryGetStoredData("CustomFleeting", out var holder);
            holder.m_MainData = 0;
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
            unit.TryGetStoredData("CustomFleeting", out var holder);
            holder.m_MainData = 0;
        }
    }
}
