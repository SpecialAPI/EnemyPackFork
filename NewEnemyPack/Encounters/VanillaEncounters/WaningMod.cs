using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class WaningMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Waning_EN", "MunglingMudLung_EN", "Lipbug_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Waning_EN", "JumbleGuts_Waning_EN", "Lipbug_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
