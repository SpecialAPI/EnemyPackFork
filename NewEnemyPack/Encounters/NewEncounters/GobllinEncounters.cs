using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class GobllinEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Goblin_Sign", ResourceLoader.LoadSprite("GoblinIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "GoblinEasy", "Goblin_Sign");
            Medium.MusicEvent = "event:/Music/GoblinTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "TheGoblin_EN",

            },
            new int[]
            {
                2

            });

            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("GoblinEasy", 1, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Easy);
        }
    }
}
