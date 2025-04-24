using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace NewEnemyPack.Effectsa
{
    public class BloodyValvePerformEffectWearable : BaseWearableSO
    {
        [Header("Wearable Effects")]
        public bool _immediateEffect;

        public EffectInfo[] effects;

        public override bool IsItemImmediate => _immediateEffect;

        public override bool DoesItemTrigger => true;

        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (_immediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(effects, caster));
            }
            else
            {
                CombatManager.Instance.AddSubAction(new EffectAction(effects, caster));
            }
        }

        public override void CustomOnTriggerAttached(IWearableEffector caller)
        {

            CombatStats stats = CombatManager.Instance._stats;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                enemy.SetUnitHealthHidden();

            }
            foreach (CharacterCombat fool in stats.CharactersOnField.Values)
            {
                fool.SetUnitHealthHidden();

            }

        }

        public override void CustomOnTriggerDettached(IWearableEffector caller)
        {
            CombatStats stats = CombatManager.Instance._stats;
            foreach (EnemyCombat enemy in stats.EnemiesOnField.Values)
            {
                enemy.RemoveUnitHiddenHealth();

            }
            foreach (CharacterCombat fool in stats.CharactersOnField.Values)
            {
                fool.RemoveUnitHiddenHealth();

            }
        }

    }
}
