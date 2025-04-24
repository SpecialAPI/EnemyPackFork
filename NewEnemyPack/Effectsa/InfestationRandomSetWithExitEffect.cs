using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class InfestationRandomSetWithExitEffect : EffectSO
    {
        public InfestationPassiveAbility _infestationPassive;

        [UnitStoreValueNamesIDsEnumRef]
        public string infestation_USD = "InfestationPA";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<IUnit> list = new List<IUnit>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    list.Add(targetSlotInfo.Unit);
                }
            }

            if (list.Count <= 0)
            {
                return false;
            }

            StringTrioData passiveLocData = _infestationPassive.GetPassiveLocData();
            for (int j = 0; j < this.PreviousExitValue; j++)
            {
                int index = Random.Range(0, list.Count);
                IUnit unit = list[index];
                if (!unit.ContainsPassiveAbility(PassiveType_GameIDs.Infestation.ToString()))
                {
                    unit.AddPassiveAbility(_infestationPassive);
                }
                else
                {
                    unit.TryGetStoredData(infestation_USD, out var holder);
                    holder.m_MainData++;
                }

                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, passiveLocData.text, _infestationPassive.passiveIcon));
            }

            return exitAmount > 0;
        }
    }
}
