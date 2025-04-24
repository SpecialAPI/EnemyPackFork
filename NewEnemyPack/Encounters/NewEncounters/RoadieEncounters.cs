using System;
using System.Collections.Generic;
using System.Text;
using BrutalAPI;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class RoadieEncounters
    {

        public static void Add()
        {
            

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "RoadieMedium", "Sandbank_Sign");
            Medium.MusicEvent = "event:/Music/RoadieTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Roadie_EN",

            },
            new int[]
            {
                2

            });

            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("RoadieMedium", 4, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);




           

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Specific, "GoldRoadieHard", "YellowSandbank_Sign");
            Hard.MusicEvent = "event:/Music/RoadieGoldTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "GoldRoadie_EN",

            },
            new int[]
            {
                2

            });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("GoldRoadieHard", 3, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
