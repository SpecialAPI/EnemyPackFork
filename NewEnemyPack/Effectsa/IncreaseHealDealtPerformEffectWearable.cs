using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class IncreaseHealDealtPerformEffectWearable : BaseWearableSO
    {
        // Token: 0x1700035F RID: 863
        // (get) Token: 0x06000DDA RID: 3546 RVA: 0x00022741 File Offset: 0x00020941
        public override bool IsItemImmediate
        {
            get
            {
                return true;
            }
        }

        // Token: 0x17000360 RID: 864
        // (get) Token: 0x06000DDB RID: 3547 RVA: 0x0000716C File Offset: 0x0000536C
        public override bool DoesItemTrigger
        {
            get
            {
                return true;
            }
        }
        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(this.TweakHeal), TriggerCalls.OnWillApplyHeal.ToString(), caller);
        }
        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(this.TweakHeal), TriggerCalls.OnWillApplyHeal.ToString(), caller);
        }
        public void TweakHeal(object sender, object args)
        {
            HealingDealtValueChangeException ex = args as HealingDealtValueChangeException;
            IWearableEffector wearableEffector = sender as IWearableEffector;

            if (this._healPerformConditions != null && !this._healPerformConditions.Equals(null))
            {
                EffectorConditionSO[] secondPerformConditions = this._healPerformConditions;
                for (int i = 0; i < secondPerformConditions.Length; i++)
                {
                    if (!secondPerformConditions[i].MeetCondition(wearableEffector, args))
                    {
                        return;
                    }
                }
            }

            ex.AddModifier(new PercentageValueModifier(false, percentToModify, IncreaseHealing));
            CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(wearableEffector.ID, base.GetItemLocData().text, false, this.wearableImage));

        }
        // Token: 0x06000DDC RID: 3548 RVA: 0x0002274C File Offset: 0x0002094C
        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (this.ImmediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(this.Effects, caster, 0), false);
                return;
            }
            CombatManager.Instance.AddSubAction(new EffectAction(this.Effects, caster, 0));
        }

        public int percentToModify = 25;
        public bool IncreaseHealing = true;
        public EffectorConditionSO[] _healPerformConditions;
        public bool ImmediateEffect = true;
        public EffectInfo[] Effects;
    }
}
