using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class MunglingMod
    {
        public static void Add()
        {

            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MunglingMudLung_EN", "Lipbug_EN", "MunglingMudLung_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MunglingMudLung_EN", "Seraphim_EN", "MudLung_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "MunglingMudLung_EN", "DrySimian_EN", "MudLung_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_MunglingMudLung_Medium_EnemyBundle"))._enemyBundles = bundleVariations1;


        }
    }
}
