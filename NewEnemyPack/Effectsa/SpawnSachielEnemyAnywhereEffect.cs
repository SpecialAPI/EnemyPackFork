using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class SpawnSachielEnemyAnywhereEffect : EffectSO
    {
        public EnemySO enemy;

        public bool givesExperience;

        [CombatIDsEnumRef]
        public string _spawnTypeID = "";

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;


            if (stats.BundleDifficulty == BundleDifficulty.Boss)
            {
                return false;
            }

            if (!stats.combatSlots.HasEnemyEmptySlots)
            {
                return false;
            }

            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    if (targetSlotInfo.Unit.MaximumHealth >= 90)
                    {
                        return false;
                    }

                }
            } 

                for (int i = 0; i < entryVariable; i++)
            {
                CombatManager.Instance.AddSubAction(new SpawnEnemyAction(enemy, -1, givesExperience, trySpawnAnyways: false, _spawnTypeID));
                LoadedDBsHandler.InfoHolder.Run.inGameData.SetBoolData("SachielEntered", true);
                LoadedDBsHandler.InfoHolder.Run.inGameData.SetIntData("SachielSplash", 3);

            }

     
            return true;
        }
    }
}



