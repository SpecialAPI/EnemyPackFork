using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class FlaMinGoaMediumdMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "Mudlung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "MunglingMudLung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "Wringle_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Seraphim_EN",  }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "DrySimian_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
