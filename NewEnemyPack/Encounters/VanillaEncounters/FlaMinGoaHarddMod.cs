using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class FlaMinGoaHarddMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "Mudlung_EN", "Mudlung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "Mudlung_EN", "MunglingMudLung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "FlaMinGoa_EN",  }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "Mudlung_EN", "Wringle_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Flarbleft_EN", "Flarbleft_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Seraphim_EN", "Mudlung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Mudlung_EN", "DrySimian_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Lipbug_EN", "DrySimian_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "FlaMinGoa_EN", "Wringle_EN", "DrySimian_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_FlaMingGoa_Hard_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
