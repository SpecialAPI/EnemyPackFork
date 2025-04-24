using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class KekapexEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Kekapex_Sign", ResourceLoader.LoadSprite("DeadFlarbOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "KekapexHard", "Kekapex_Sign");
            Medium.MusicEvent = "event:/Music/KekapexTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "DyingFlarb_EN",

            },
            new int[]
            {
                2

            });

            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("KekapexHard", 3, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
