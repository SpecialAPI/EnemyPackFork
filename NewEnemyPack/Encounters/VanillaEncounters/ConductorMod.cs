using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class ConductorMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "NakedGizo_EN", "Conductor_EN", "MusicMan_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Chapman_EN", "Conductor_EN", "Chapman_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SingingStone_EN", "Conductor_EN", "Seraphim_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Neoplasm_EN", "Conductor_EN", "Neoplasm_EN", "Neoplasm_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Medium_EnemyBundle"))._enemyBundles = bundleVariations;

            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Gizo_EN", "Conductor_EN", "MusicMan_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "NeoplasmHeap_EN", "Conductor_EN", "Neoplasm_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "NeoplasmHeap_EN", "Conductor_EN", "MusicMan_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Conductor_EN", "MusicMan_EN", "Neoplasm_EN", "Neoplasm_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Gizo_EN", "Conductor_EN", "Scrungie_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "NakedGizo_EN", "Conductor_EN", "MusicMan_EN", "MusicMan_EN", "SingingStone_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Chapman_EN", "Conductor_EN", "Chapman_EN", "Chapman_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Seraphim_EN", "Conductor_EN", "MusicMan_EN", "MusicMan_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Seraphim_EN", "Conductor_EN", "MusicMan_EN", "MusicMan_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Gizo_EN", "Conductor_EN", "MusicMan_EN", "MusicMan_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Gizo_EN", "Conductor_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Gizo_EN", "Conductor_EN", "Gizo_EN", "NakedGizo_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Conductor_EN", "MusicMan_EN", "NakedGizo_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle"))._enemyBundles = bundleVariations1;
        }
    }
}
