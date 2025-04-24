using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class UnflarbEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Unflarb_Sign", ResourceLoader.LoadSprite("UnflarbOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "UnflarbHard", "Unflarb_Sign");
            Hard.MusicEvent = "event:/Music/UnflarbTheme";
            Hard.RoarEvent = "event:/Unflarb/UnflarbRoar";

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Unflarb_EN",
                "Flarblet_EN",
                "Flarbleft_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Flarbleft_EN",
                "Flarbleft_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Flarbleft_EN",
                "Flarbleft_EN",
                "Flarblet_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Unflarb_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Flarb_EN",

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "MunglingMudLung_EN",

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "JumbleGuts_Clotted_EN",
                "Flarbleft_EN",

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Spoggle_Spitfire_EN",
                "Flarbleft_EN",

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Spoggle_Ruminating_EN",
                "Wringle_EN",

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "JumbleGuts_Waning_EN",
                "MunglingMudLung_EN",

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Flarbleft_EN",
                "FlaMinGoa_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "MudLung_EN",
                "Lipbug_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "MudLung_EN",
                "Seraphim_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Unflarb_EN",
                "Flarbleft_EN",
                "Seraphim_EN",

});

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("UnflarbHard", 32, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);

        }
    }
}
