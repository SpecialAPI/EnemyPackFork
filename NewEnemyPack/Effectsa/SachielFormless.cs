using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class SachielFormless : BasePassiveAbilitySO
    {
        public bool m_DontRerollIfNoAbilitiesLeft;

        public TriggerCalls[] _secondTriggerOn;

        public EffectorConditionSO[] _secondPerformConditions;

        public bool _secondDoesPerformPopUp = true;

        public EffectInfo[] _secondEffects;

        public override bool IsPassiveImmediate => false;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;
            CombatManager.Instance.ProcessImmediateAction(new FormlessTriggeredAction(unit.ID, unit.IsUnitCharacter, m_DontRerollIfNoAbilitiesLeft));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }

        public override void CustomOnTriggerAttached(IPassiveEffector caller)
        {
            TriggerCalls[] secondTriggerOn = _secondTriggerOn;
            for (int i = 0; i < secondTriggerOn.Length; i++)
            {
                TriggerCalls triggerCalls = secondTriggerOn[i];
                if (triggerCalls != TriggerCalls.Count)
                {
                    CombatManager.Instance.AddObserver(CustomTryTriggerPassive, triggerCalls.ToString(), caller);
                }
            }
        }

        public override void CustomOnTriggerDettached(IPassiveEffector caller)
        {
            TriggerCalls[] secondTriggerOn = _secondTriggerOn;
            for (int i = 0; i < secondTriggerOn.Length; i++)
            {
                TriggerCalls triggerCalls = secondTriggerOn[i];
                if (triggerCalls != TriggerCalls.Count)
                {
                    CombatManager.Instance.RemoveObserver(CustomTryTriggerPassive, triggerCalls.ToString(), caller);
                }
            }
        }

        public override void FinalizeCustomTriggerPassive(object sender, object args, int triggerID)
        {
            IPassiveEffector passiveEffector = sender as IPassiveEffector;
            if (passiveEffector != null && !passiveEffector.Equals(null))
            {
                if (_secondDoesPerformPopUp)
                {
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(passiveEffector.ID, passiveEffector.IsUnitCharacter, GetPassiveLocData().text, passiveIcon));
                }

                IUnit caster = sender as IUnit;
                CombatManager.Instance.AddSubAction(new EffectAction(_secondEffects, caster));
            }
        }

        public void CustomTryTriggerPassive(object sender, object args)
        {
            IPassiveEffector passiveEffector = sender as IPassiveEffector;
            if (passiveEffector == null || passiveEffector.Equals(null) || !passiveEffector.CanPassiveTrigger(m_PassiveID))
            {
                return;
            }

            if (_secondPerformConditions != null && !_secondPerformConditions.Equals(null))
            {
                EffectorConditionSO[] secondPerformConditions = _secondPerformConditions;
                for (int i = 0; i < secondPerformConditions.Length; i++)
                {
                    if (!secondPerformConditions[i].MeetCondition(passiveEffector, args))
                    {
                        return;
                    }
                }
            }

            CombatManager.Instance.AddSubAction(new PerformPassiveCustomAction(this, sender, args, 0));
        }

    }
}
