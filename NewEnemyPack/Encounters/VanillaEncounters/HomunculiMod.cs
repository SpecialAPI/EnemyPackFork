using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class HomunculiMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "ShiveringHomunculus_EN", "ShiveringHomunculus_EN", "ScreamingHomunculus_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "SkinningHomunculus_EN", "ScreamingHomunculus_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "TitteringPeon_EN", "ScreamingHomunculus_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "SkinningHomunculus_EN", "SterileBud_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "ShiveringHomunculus_EN", "SterileBud_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "TitteringPeon_EN", "SterileBud_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "Unterling_EN", "ShiveringHomunculus_EN", "ScreamingHomunculus_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Medium_EnemyBundle"))._enemyBundles = bundleVariations;


            /////////////////////////////////////////////

            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "SkinningHomunculus_EN", "ShiveringHomunculus_EN", "ScreamingHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "ChoirBoy_EN", "ChoirBoy_EN", "ScreamingHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "SkinningHomunculus_EN", "ChoirBoy_EN", "ScreamingHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "TitteringPeon_EN", "ChoirBoy_EN", "ScreamingHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "TitteringPeon_EN", "ShiveringHomunculus_EN", "SkinningHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "TitteringPeon_EN", "ScreamingHomunculus_EN", "SkinningHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "SterileBud_EN", "ScreamingHomunculus_EN", "SkinningHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "SterileBud_EN", "ShiveringHomunculus_EN", "SkinningHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "Unterling_EN", "ShiveringHomunculus_EN", "SkinningHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "Unterling_EN", "Unterling_EN", "SkinningHomunculus_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "SkinningHomunculus_EN", "Unterling_EN", "SterileBud_EN", "SkinningHomunculus_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_SkinningHomunculus_Hard_EnemyBundle"))._enemyBundles = bundleVariations1;
        }
    }
}
