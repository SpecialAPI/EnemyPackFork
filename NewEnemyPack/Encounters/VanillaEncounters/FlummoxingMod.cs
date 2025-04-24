using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.VanillaEncounters
{
    internal class FlummoxingMod
    {
        public static void Add()
        {
            List<RandomEnemyGroup> bundleVariations = new List<RandomEnemyGroup>(((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles);

            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Flummoxing_EN", "JumbleGuts_Hollowing_EN", "DesiccatingJumbleguts_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Flummoxing_EN", "Chapman_EN", "Chapman_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Flummoxing_EN", "Neoplasm_EN", "Neoplasm_EN", "JumbleGuts_Clotted_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Flummoxing_EN", "Neoplasm_EN", "Neoplasm_EN", "JumbleGuts_Waning_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Hollowing_EN", "Seraphim_EN", "JumbleGuts_Flummoxing_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Hollowing_EN", "Gizo_EN", "JumbleGuts_Flummoxing_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Flummoxing_EN", "Gizo_EN", "MusicMan_EN", "MusicMan_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Hollowing_EN", "NakedGizo_EN", "JumbleGuts_Flummoxing_EN", "MusicMan_EN", }));
            bundleVariations.Add(new RandomEnemyGroup(new string[] { "JumbleGuts_Hollowing_EN", "NakedGizo_EN", "JumbleGuts_Flummoxing_EN", "MusicMan_EN", }));



            ((RandomEnemyBundleSO)LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle"))._enemyBundles = bundleVariations;
        }
    }
}
