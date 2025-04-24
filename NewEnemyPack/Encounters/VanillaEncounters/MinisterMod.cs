using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class MinisterMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "NextOfKin_EN", "NextOfKin_EN", "TitteringPeon_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "NextOfKin_EN", "NextOfKin_EN", "Unterling_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle"))._enemyBundles = bundleVariations;





            ////////////////////////////////////////////////////////////////////////////////////////////////

            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "TitteringPeon_EN", "InHisImage_EN", "InHerImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "GigglingMinister_EN", "TitteringPeon_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "GigglingMinister_EN", "SterileBud_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "SterileBud_EN", "SterileBud_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "SterileBud_EN", "Unterling_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "GigglingMinister_EN", "Unterling_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Medium_EnemyBundle"))._enemyBundles = bundleVariations1;


            //////////////////////////////////////////////////////////////////////////////////////////////////////

            List<RandomEnemyGroup> bundleVariations2 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "SkinningHomunculus_EN", "ScreamingHomunculus_EN", "ShiveringHomunculus_EN", }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "SkinningHomunculus_EN", "ScreamingHomunculus_EN", "SkinningHomunculus_EN", }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "TitteringPeon_EN", "ChoirBoy_EN", "ChoirBoy_EN", }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "InHisImage_EN", "InHisImage_EN", "InHerImage_EN", "TitteringPeon_EN", }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "SkinningHomunculus_EN", "ScreamingHomunculus_EN", "SterileBud_EN"}));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "ShiveringHomunculus_EN", "ShiveringHomunculus_EN", "SterileBud_EN" }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "Unterling_EN", "Unterling_EN", "SterileBud_EN" }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "Unterling_EN", "TitteringPeon_EN", "SterileBud_EN" }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "Unterling_EN", "TitteringPeon_EN", "ChoirBoy_EN" }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "Unterling_EN", "Unterling_EN", "ChoirBoy_EN" }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "TitteringPeon_EN", "TitteringPeon_EN", "ChoirBoy_EN" }));

            bundleVariations2.Add(new RandomEnemyGroup(new string[] { "GigglingMinister_EN", "SkinningHomunculus_EN", "SkinningHomunculus_EN", "Unterling_EN" }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle"))._enemyBundles = bundleVariations2;
        }
    }
}
