using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class KekoMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Easy_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarbleft_EN", "Keko_EN", "Keko_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Lipbug_EN", "Keko_EN", "Keko_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Easy_EnemyBundle"))._enemyBundles = bundleVariations;


            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Lipbug_EN", "Keko_EN", "Keko_EN", "Keko_EN", "Keko_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Seraphim_EN", "Keko_EN", "Keko_EN", "Keko_EN", "Keko_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Keko_Medium_EnemyBundle"))._enemyBundles = bundleVariations1;
        }
    }
}
