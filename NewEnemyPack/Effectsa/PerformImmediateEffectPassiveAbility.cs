using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class PerformImmediateEffectPassiveAbility : BasePassiveAbilitySO
    {
        [Header("Passive Effects")]
        public EffectInfo[] effects;

        public override bool IsPassiveImmediate => true;

        public override bool DoesPassiveTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            CombatManager.Instance.AddSubAction(new EffectAction(effects, caster));
        }

        public override void OnPassiveConnected(IUnit unit)
        {
        }

        public override void OnPassiveDisconnected(IUnit unit)
        {
        }
    }
}
