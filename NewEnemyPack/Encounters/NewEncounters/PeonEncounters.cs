using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class PeonEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Peon_Sign", ResourceLoader.LoadSprite("PeonIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Easy = new EnemyEncounter_API(EncounterType.Random, "PeonEasy", "Peon_Sign");
            Easy.MusicEvent = "event:/Music/PeonTheme";
            Easy.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle")._roarReference.roarEvent;

            Easy.CreateNewEnemyEncounterData(new string[]
            {
                "TitteringPeon_EN",
                "TitteringPeon_EN",
                "NextOfKin_EN",

            });

            Easy.CreateNewEnemyEncounterData(new string[]
            {
                "TitteringPeon_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",

            });

            Easy.CreateNewEnemyEncounterData(new string[]
            {
                "TitteringPeon_EN",
                "TitteringPeon_EN",
                "ShiveringHomunculus_EN",

            });

            Easy.CreateNewEnemyEncounterData(new string[]
            {
                "TitteringPeon_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",

            });


            Easy.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("PeonEasy", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);



            EnemyEncounter_API Med = new EnemyEncounter_API(EncounterType.Random, "PeonMedium", "Peon_Sign");
            Med.MusicEvent = "event:/Music/PeonTheme";
            Med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Easy_EnemyBundle")._roarReference.roarEvent;

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "TitteringPeon_EN",
                "TitteringPeon_EN",
                "TitteringPeon_EN",
                "TitteringPeon_EN",
                "TitteringPeon_EN",

            });


            Med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("PeonMedium", 1, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);
        }

    }
}
