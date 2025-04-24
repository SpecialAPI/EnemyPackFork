using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class ScrungieMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Scrungie_EN", "Scrungie_EN", "Chapman_EN", "Chapman_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Scrungie_EN", "Scrungie_EN", "Seraphim_EN", "Seraphim_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Scrungie_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Scrungie_EN", "Neoplasm_EN", "Scrungie_EN", "Neoplasm_EN", "Scrungie_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Scrungie_EN", "Scrungie_EN", "Scrungie_EN", "Gizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Scrungie_EN", "Scrungie_EN", "Scrungie_EN", "NakedGizo_EN", "NakedGizo_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Scrungie_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
