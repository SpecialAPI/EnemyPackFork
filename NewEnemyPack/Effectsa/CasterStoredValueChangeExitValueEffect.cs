using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class CasterStoredValueChangeExitValueEffect : EffectSO
    {
        public bool _increase = true;

        public int _minimumValue;

        [UnitStoreValueNamesIDsEnumRef]
        public string m_unitStoredDataID = "";

        public bool _randomBetweenPrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            caster.TryGetStoredData(m_unitStoredDataID, out var holder);
            exitAmount = holder.m_MainData;
            if (_randomBetweenPrevious)
            {
                this.PreviousExitValue = Random.Range(base.PreviousExitValue, this.PreviousExitValue + 1);
            }

            exitAmount += (_increase ? this.PreviousExitValue : (-this.PreviousExitValue));
            exitAmount = Mathf.Max(_minimumValue, exitAmount);
            holder.m_MainData = exitAmount;
            return true;
        }
    }
}
