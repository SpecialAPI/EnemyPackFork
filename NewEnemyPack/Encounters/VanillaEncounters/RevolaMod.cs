using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class RevolaMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Revola_EN", "MusicMan_EN", "Gizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Revola_EN", "Chapman_EN", "Chapman_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Revola_EN", "NeoplasmHeap_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Revola_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Revola_EN", "Seraphim_EN", "Seraphim_EN",  }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Revola_EN", "MusicMan_EN", "NakedGizo_EN", "MusicMan_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
