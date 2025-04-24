using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class FountainEncounter
    {
        public static void Add()
        {

            Portals.AddPortalSign("Fountain_Sign", ResourceLoader.LoadSprite("FounIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Specific, "FountainHard", "Fountain_Sign");
            Hard.MusicEvent = "event:/Music/FountainTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "TheFountainofYouth_EN",

            },
            new int[]
            {
                2

            });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("FountainHard", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);

        }
    }
}
