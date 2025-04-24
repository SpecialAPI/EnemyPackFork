using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class ClottedMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Clotted_EN", "MunglingMudLung_EN", "Lipbug_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Clotted_EN", "JumbleGuts_Clotted_EN", "Lipbug_EN", }));


            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Clotted_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
