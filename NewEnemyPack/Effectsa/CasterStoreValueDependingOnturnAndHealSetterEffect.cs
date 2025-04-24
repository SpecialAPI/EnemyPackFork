using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class CasterStoreValueDependingOnturnAndHealSetterEffect : EffectSO
    {
        public bool _ignoreIfContains;

      

        [UnitStoreValueNamesIDsEnumRef]
        public string m_unitStoredDataID = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            UnitStoreDataHolder holder;
            bool flag = caster.TryGetStoredData(m_unitStoredDataID, out holder);
            if (!_ignoreIfContains || !flag)
            {
                if (stats.TurnsPassed % 2 != 0 ) 
                { 
                    holder.m_MainData = entryVariable;
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(caster.ID, caster.HeldItem.GetItemLocData().text, itemConsumed: false, caster.HeldItem.wearableImage));
                    caster.Heal(3, caster, true);                
                    return true;
                }
                else
                {
                
                    holder.m_MainData = -entryVariable;
                    return true;

                }

            }

            return false;
        }
    }
}
