using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class SpawnRandomEnemyIfTheresSpaceAnywhereEffect : EffectSO
    {
        public List<EnemySO> _enemies;

        public bool _givesExperience;

        [CombatIDsEnumRef]
        public string _spawnTypeID = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            if (_enemies == null || _enemies.Count <= 0)
            {
                exitAmount = 0;
                return false;
            }

            if (stats.EnemiesOnField.Count > 1)
            {
                exitAmount = 0;
                return false;

            }

            for (int i = 0; i < entryVariable; i++)
            {
                int index = Random.Range(0, _enemies.Count);
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(_enemies[index], -1, _givesExperience, trySpawnAnyways: false, _spawnTypeID));
            }

            exitAmount = entryVariable;
            return true;
        }
    }
}
