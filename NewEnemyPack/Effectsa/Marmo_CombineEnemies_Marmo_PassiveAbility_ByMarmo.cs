using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class Marmo_CombineEnemies_Marmo_PassiveAbility_ByMarmo : BasePassiveAbilitySO
    {
        public override bool IsPassiveImmediate { get { return false; } }

        public override bool DoesPassiveTrigger { get { return true; } }

        public override void TriggerPassive(object sender, object args)
        {
            IUnit User = sender as IUnit;
            if (User.IsAlive && !User.IsUnitCharacter)
            {
                CombatManager.Instance.ProcessImmediateAction(new CheckAndCombineEnemiesAction(User, _EnemyToSpawn, this, PassiveToRemove));
                
            }
        }

        public override void OnPassiveConnected(IUnit unit) { }
        public override void OnPassiveDisconnected(IUnit unit) { }

        public EnemySO _EnemyToSpawn;

        public string PassiveToRemove;
    }
}
