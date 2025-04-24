using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class NeoplasmLakeEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("NeoplasmLake_Sign", ResourceLoader.LoadSprite("LakeIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "LakeHard", "NeoplasmLake_Sign");
            Hard.MusicEvent = "event:/Music/SlimeTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmLake_EN",
                "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmLake_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmLake_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmLake_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmLake_EN",
                "Gizo_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmLake_EN",
                "Spoggle_Writhing_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmLake_EN",
                "Spoggle_Resonant_EN",

           });




            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("LakeHard", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
