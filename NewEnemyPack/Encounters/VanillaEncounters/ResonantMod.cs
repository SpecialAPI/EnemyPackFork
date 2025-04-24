using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class ResonantMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Spoggle_Resonant_EN", "Chapman_EN", "Chapman_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Spoggle_Resonant_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Spoggle_Writhing_EN", "Seraphim_EN", "Spoggle_Resonant_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Spoggle_Resonant_EN", "Gizo_EN", "Spoggle_Writhing_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Spoggle_Resonant_EN", "Gizo_EN", "MusicMan_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "Spoggle_Resonant_EN", "NakedGizo_EN", "MusicMan_EN", "MusicMan_EN", }));



            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Resonant_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
