using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class HealIfStoredValueNotZero : EffectSO
    {
        // Token: 0x06000037 RID: 55 RVA: 0x000074A0 File Offset: 0x000056A0
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].HasUnit && targets[i].Unit.SimpleGetStoredValue(_valueName) > 0)
                {
                    int amount = Random.Range(base.PreviousExitValue, entryVariable + 1);
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(caster.ID, caster.HeldItem.GetItemLocData().text, itemConsumed: false, caster.HeldItem.wearableImage));
                    exitAmount += targets[i].Unit.Heal(amount, caster, true, CombatType_GameIDs.Heal_Basic.ToString());
                    targets[i].Unit.SimpleSetStoredValue(_valueName, 0);
                }
            }
            return exitAmount > 0;
        }



        // Token: 0x0400002F RID: 47
        [SerializeField]
        public string _valueName;



        // Token: 0x04001006 RID: 4102
        [SerializeField]
        public bool _onlyIfHasHealthOver0 = true;
    }
}
