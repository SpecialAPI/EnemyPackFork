using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class DeathReferenceSlimeCondition : EffectorConditionSO
    {
        [Header("Death Reference Data")]
        public bool _useWithering;

        public bool _witheringDeath;



        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            DeathReference deathReference = args as DeathReference;
            if (deathReference == null || deathReference.Equals(null))
            {
                return false;

            }
            if (deathReference.deathType == DeathType_GameIDs.DirectDeath.ToString() || deathReference.deathType == DeathType_GameIDs.Withering.ToString())
            {

                return false;
            }

            return true;
        }
    } 
}
