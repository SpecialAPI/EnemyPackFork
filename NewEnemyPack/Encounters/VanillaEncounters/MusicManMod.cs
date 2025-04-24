using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class MusicManMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> easy = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles);

            easy.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "DesiccatingJumbleguts_EN", "SingingStone_EN", }));

            easy.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Neoplasm_EN", "SingingStone_EN", "Neoplasm_EN", }));

            easy.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "MusicMan_EN", "NakedGizo_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Easy_EnemyBundle"))._enemyBundles = easy;





            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", "Neoplasm_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "DesiccatingJumbleguts_EN", "JumbleGuts_Flummoxing_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "DesiccatingJumbleguts_EN", "JumbleGuts_Hollowing_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "MusicMan_EN", "NakedGizo_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "MusicMan_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "MusicMan_EN", "MusicMan_EN", "Neoplasm_EN", "Neoplasm_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "SilverSuckle_EN", "MusicMan_EN", "NakedGizo_EN", "SilverSuckle_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "JumbleGuts_Flummoxing_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "JumbleGuts_Hollowing_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "DesiccatingJumbleguts_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Chapman_EN", "MusicMan_EN", "Chapman_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Seraphim_EN", "MusicMan_EN", "MusicMan_EN", }));


            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Gizo_EN", "MusicMan_EN", "MusicMan_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Gizo_EN", "MusicMan_EN", "MusicMan_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "NakedGizo_EN", "MusicMan_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "NakedGizo_EN", "MusicMan_EN", "MusicMan_EN", "NakedGizo_EN", }));

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "MusicMan_EN", "Gizo_EN", "NakedGizo_EN", "MusicMan_EN", }));

            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_MusicMan_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
