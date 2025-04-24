using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class MudLungMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Easy_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MudLung_EN", "Lipbug_EN", "MudLung_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Easy_EnemyBundle"))._enemyBundles = bundleVariations;


            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MudLung_EN", "Lipbug_EN", "MudLung_EN", "MudLung_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MudLung_EN", "Lipbug_EN", "MunglingMudLung_EN",  }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MudLung_EN", "Lipbug_EN", "MudLung_EN", "Lipbug_EN" }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MudLung_EN", "Seraphim_EN", "MudLung_EN",}));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MudLung_EN", "DrySimian_EN",  }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MudLung_Medium_EnemyBundle"))._enemyBundles = bundleVariations1;
        }
    }
}
