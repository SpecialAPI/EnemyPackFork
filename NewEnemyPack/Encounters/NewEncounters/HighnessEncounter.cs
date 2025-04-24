using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class HighnessEncounter
    {
        public static void Add()
        {

            Portals.AddPortalSign("Highness_Sign", ResourceLoader.LoadSprite("HighnessOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Specific, "HighnessHard", "Highness_Sign");
            Hard.MusicEvent = "event:/Music/HighnessTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle")._roarReference.roarEvent;


            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "GigglingUsurper_EN",
                "HeinousHighness_EN",
                "GigglingUsurper_EN",

            },
            new int[]
            {
                1,
                2,
                3

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "GigglingUsurper_EN",
                "HeinousHighness_EN",
                "GigglingUsurper_EN",

            },
            new int[]
            {
                0,
                2,
                4

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "GigglingUsurper_EN",
                "HeinousHighness_EN",
                "GigglingUsurper_EN",

            },
            new int[]
            {
                1,
                2,
                4

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "GigglingUsurper_EN",
                "HeinousHighness_EN",
                "GigglingUsurper_EN",

            },
            new int[]
            {
                0,
                2,
                3

            });



            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("HighnessHard", 4, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);

        }
    }
}
