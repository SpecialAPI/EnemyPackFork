using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class VoboolaMod
    {
        public static void Add()
        {

            List<RandomEnemyGroup> bundleVariations1 = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles);

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Voboola_EN", "Unflarb_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Voboola_EN", "Nephilim_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Voboola_EN", "Lipbug_EN", "Mudlung_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Voboola_EN", "Seraphim_EN", "Flarblet_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Voboola_EN", "DrySimian_EN", "MudLung_EN", }));

            bundleVariations1.Add(new RandomEnemyGroup(new string[] { "Voboola_EN", "DrySimian_EN", "Lipbug_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle"))._enemyBundles = bundleVariations1;


        }

    }
}
