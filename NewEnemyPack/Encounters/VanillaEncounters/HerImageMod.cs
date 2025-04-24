using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class HerImageMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Easy_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "InHisImage_EN", "InHerImage_EN", "TitteringPeon_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "NextOfKin_EN", "NextOfKin_EN", "InHerImage_EN", "TitteringPeon_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "InHisImage_EN", "InHerImage_EN", "Unterling_EN",}));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Unterling_EN", "InHerImage_EN", "Unterling_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "NextOfKin_EN", "InHerImage_EN", "Unterling_EN", "NextOfKin_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Easy_EnemyBundle"))._enemyBundles = bundleVariations;



            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHisImage_EN", "InHerImage_EN", "TitteringPeon_EN", "InHisImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHisImage_EN", "InHerImage_EN", "ScreamingHomunculus_EN", "InHisImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHerImage_EN", "InHerImage_EN", "ScreamingHomunculus_EN", "InHisImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHerImage_EN", "TitteringPeon_EN", "TitteringPeon_EN", "InHisImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHerImage_EN", "Unterling_EN", "TitteringPeon_EN", "InHisImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHerImage_EN", "InHerImage_EN", "Unterling_EN", "InHisImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHerImage_EN", "InHerImage_EN", "Unterling_EN", "InHerImage_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Unterling_EN", "InHerImage_EN", "Unterling_EN", "Unterling_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "InHerImage_EN", "InHerImage_EN", "ChoirBoy_EN", "Unterling_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone03_InHerImage_Medium_EnemyBundle"))._enemyBundles = bundleVariations1;
        }
    }
}
