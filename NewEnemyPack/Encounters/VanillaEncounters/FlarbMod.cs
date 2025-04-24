using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class FlarbMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarb_EN", "Lipbug_EN", "Mudlung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarb_EN", "Unflarb_EN",  }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarb_EN", "Seraphim_EN", "Flarblet_EN" }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarb_EN", "DrySimian_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarb_EN", "DrySimian_EN", "Flarblet_EN" }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Flarb_EN", "Lipbug_EN", "Wringle_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Flarb_Hard_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
