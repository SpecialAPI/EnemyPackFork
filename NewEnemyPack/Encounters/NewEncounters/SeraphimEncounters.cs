using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class SeraphimEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Seraphim_Sign", ResourceLoader.LoadSprite("SeraphimOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "SeraphimHard", "Seraphim_Sign");
            Hard.MusicEvent = "event:/Music/SeraphimTheme";
            Hard.RoarEvent = "event:/Characters/Player/Dimitri/CHR_PLR_Dimitri_Dth";

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Seraphim_EN",
                "Flarblet_EN",
                "Flarbleft_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Seraphim_EN",
                "MudLung_EN",
                "MudLung_EN",
                "MudLung_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Seraphim_EN",
                "JumbleGuts_Waning_EN",
                "JumbleGuts_Clotted_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Seraphim_EN",
                "Spoggle_Ruminating_EN",
                "Spoggle_Spitfire_EN",

});

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("SeraphimHard", 5, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
