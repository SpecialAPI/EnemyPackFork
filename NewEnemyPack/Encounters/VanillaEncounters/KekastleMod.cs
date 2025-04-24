using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class KekastleMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Kekastle_EN", "Unflarb_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Kekastle_EN", "DrySimian_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Kekastle_EN", "Seraphim_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Kekastle_EN", "Lipbug_EN", "MudLung_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Kekastle_EN", "Lipbug_EN", "Keko_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
