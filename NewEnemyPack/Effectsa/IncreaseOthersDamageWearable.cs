using BrutalAPI.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class IncreaseOthersDamageWearable : BaseWearableSO
    {
        public static int controlint = 0;

        public static int damage = 0;
        public override bool IsItemImmediate
        {
            get
            {
                return this._firstImmediateEffect;
            }
        }



        public override bool DoesItemTrigger
        {
            get
            {
                return true;
            }
        }
        public override void TriggerPassive(object sender, object args)
        {
            IUnit caster = sender as IUnit;
            if (this._firstImmediateEffect)
            {
                CombatManager.Instance.ProcessImmediateAction(new ImmediateEffectAction(this._firstEffects, caster, 0), false);
                return;
            }
            CombatManager.Instance.AddSubAction(new EffectAction(this._firstEffects, caster, 0));
        }

        public override void OnTriggerAttachedAction(IWearableEffector caller)
        {
            controlint = 1;
            damage = _damageincrease;
        }


        public override void OnTriggerDettachedAction(IWearableEffector caller)
        {
            controlint = 0;
            damage = 0;
        }





        [Header("Wearable Effects")]
        [SerializeField]
        public bool _firstImmediateEffect;

        public EffectInfo[] _firstEffects;


        public int _damageincrease;
    }
}
