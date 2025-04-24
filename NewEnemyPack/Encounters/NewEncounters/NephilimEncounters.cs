using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class NephilimEncounters
    {
        public static void Add()
        {


            Portals.AddPortalSign("Nephilim_Sign", ResourceLoader.LoadSprite("NephelimOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Random, "NephilimMedium", "Nephilim_Sign");
            Medium.MusicEvent = "event:/Music/NephilimTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemy("Ungod_EN").deathSound;

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Nephilim_EN",
                "Flarbleft_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Nephilim_EN",
                "Flarblet_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Nephilim_EN",
                "MudLung_EN",
                "MudLung_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "Nephilim_EN",
                "Mung_EN",
                "Mung_EN",
                "Mung_EN",

           });

            Medium.CreateNewEnemyEncounterData(new string[]
          {
                "Nephilim_EN",
                "Keko_EN",
                "Keko_EN",

          });

            Medium.CreateNewEnemyEncounterData(new string[]
          {
                "Nephilim_EN",
                "Lipbug_EN",
                "Mung_EN",

          });


            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("NephilimMedium", 30, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);


            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "NephilimHard", "Nephilim_Sign");
            Hard.MusicEvent = "event:/Music/NephilimTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("Ungod_EN").deathSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Nephilim_EN",
                "Seraphim_EN",
                "MudLung_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Seraphim_EN",
                "Lipbug_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Flarb_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Unflarb_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "MunglingMudLung_EN",
                "MudLung_EN",
});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Flarblet_EN",
                "FlaMinGoa_EN",
});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Flarbleft_EN",
                "Wringle_EN",
});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Lipbug_EN",
                "Wringle_EN",
});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Voboola_EN",
});

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "Nephilim_EN",
                "Keko_EN",
                "Keko_EN",
                "Keko_EN",
                "Keko_EN",
});

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("NephilimHard", 30, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);

        }
    }
}
