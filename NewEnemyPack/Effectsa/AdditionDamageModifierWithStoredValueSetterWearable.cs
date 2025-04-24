using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class AdditionDamageModifierWithStoredValueSetterWearable : BaseWearableSO
    {
        // Token: 0x17000334 RID: 820
        // (get) Token: 0x06000D62 RID: 3426 RVA: 0x0000726C File Offset: 0x0000546C
        public override bool IsItemImmediate
        {
            get
            {
                return true;
            }
        }

        // Token: 0x17000335 RID: 821
        // (get) Token: 0x06000D63 RID: 3427 RVA: 0x0000726C File Offset: 0x0000546C
        public override bool DoesItemTrigger
        {
            get
            {
                return true;
            }
        }

        // Token: 0x06000D64 RID: 3428 RVA: 0x0002119C File Offset: 0x0001F39C
        public override void TriggerPassive(object sender, object args)
        {
            int num = (sender as IUnit).SimpleGetStoredValue(this._valueName);

            if (this._useDealt)
            {
                DamageDealtValueChangeException ex = args as DamageDealtValueChangeException;
                if (ex != null && !ex.Equals(null))
                {
                    ex.AddModifier(new BetterAdditionValueModifier(true, this._toAdd + num));
                    return;
                }
            }
            else
            {
                DamageReceivedValueChangeException ex2 = args as DamageReceivedValueChangeException;
                if (ex2 != null && !ex2.Equals(null))
                {
                    ex2.AddModifier(new BetterAdditionValueModifier(false, this._toAdd + num));
                }
            }
        }

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            foreach (TriggerCalls triggerCalls in this._secondPerformTriggersOn)
            {
                if (triggerCalls != TriggerCalls.Count)
                {
                    CombatManager.Instance.AddObserver(new Action<object, object>(this.TryPerformWearable), triggerCalls.ToString(), caller);
                }
            }
        }

        // Token: 0x06000DC2 RID: 3522 RVA: 0x00022010 File Offset: 0x00020210
        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            foreach (TriggerCalls triggerCalls in this._secondPerformTriggersOn)
            {
                if (triggerCalls != TriggerCalls.Count)
                {
                    CombatManager.Instance.RemoveObserver(new Action<object, object>(this.TryPerformWearable), triggerCalls.ToString(), caller);
                }
            }
        }

        // Token: 0x06000DC3 RID: 3523 RVA: 0x00022064 File Offset: 0x00020264
        public override void FinalizeCustomTriggerItem(object sender, object args, int triggerID)
        {
            IWearableEffector wearableEffector = sender as IWearableEffector;
            if (wearableEffector == null || wearableEffector.Equals(null))
            {
                return;
            }
            if (wearableEffector.IsWearableConsumed)
            {
                return;
            }
            bool itemConsumed = false;
            if (this._GetsConsumedOnSecondaryUse)
            {
                itemConsumed = true;
                wearableEffector.ConsumeWearable();
            }
            if (this._secondDoesPerformItemPopUp)
            {
                CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(wearableEffector.ID, base.GetItemLocData().text, itemConsumed));
            }
            IUnit caster = sender as IUnit;
            if (this._secondImmediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(this._secondEffects, caster, 0), false);
                return;
            }
            CombatManager.Instance.AddSubAction(new EffectAction(this._secondEffects, caster, 0));
        }

        // Token: 0x06000DC4 RID: 3524 RVA: 0x00022108 File Offset: 0x00020308
        public void TryPerformWearable(object sender, object args)
        {
            IWearableEffector wearableEffector = sender as IWearableEffector;
            if (wearableEffector == null || wearableEffector.Equals(null))
            {
                return;
            }
            if (!wearableEffector.CanWearableTrigger)
            {
                return;
            }
            if (this._secondPerformConditions != null && !this._secondPerformConditions.Equals(null))
            {
                EffectorConditionSO[] secondPerformConditions = this._secondPerformConditions;
                for (int i = 0; i < secondPerformConditions.Length; i++)
                {
                    if (!secondPerformConditions[i].MeetCondition(wearableEffector, args))
                    {
                        return;
                    }
                }
            }
            if (this._secondImmediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new PerformItemCustomImmediateAction(this, sender, args, 0), false);
                return;
            }
            CombatManager.Instance.AddSubAction(new PerformItemCustomAction(this, sender, args, 0));
        }

        // Token: 0x040008F0 RID: 2288
        [Header("Addition Data")]
        [SerializeField]
        public bool _useDealt;

        // Token: 0x040008F1 RID: 2289
        [SerializeField]
        public int _toAdd;

        public string _valueName = "";

        [SerializeField]
        public TriggerCalls[] _secondPerformTriggersOn;

        // Token: 0x04000922 RID: 2338
        [SerializeField]
        public EffectorConditionSO[] _secondPerformConditions;

        // Token: 0x04000923 RID: 2339
        [SerializeField]
        public bool _secondDoesPerformItemPopUp = true;

        // Token: 0x04000924 RID: 2340
        [Header("Secondary Consume Data")]
        [SerializeField]
        public bool _GetsConsumedOnSecondaryUse;

        // Token: 0x04000925 RID: 2341
        [Header("Wearable Effects")]
        [SerializeField]
        public bool _secondImmediateEffect;

        // Token: 0x04000926 RID: 2342
        [SerializeField]
        public EffectInfo[] _secondEffects;
    }
}
