using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class DrySimianEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("DrySimian_Sign", ResourceLoader.LoadSprite("DrySimian_Overworld"), Portals.EnemyIDColor);

            EnemyEncounter_API Normal = new EnemyEncounter_API(EncounterType.Random, "DrySimianMedium", "DrySimian_Sign");
            Normal.MusicEvent = "event:/Music/SimianTheme";
            Normal.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle")._roarReference.roarEvent;

            Normal.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Mung_EN",
                "Mung_EN",
                "Mung_EN",
            });

            Normal.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "MudLung_EN",            
                "MudLung_EN",
            });

            Normal.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "MunglingMudLung_EN",

            });

            Normal.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Keko_EN",
                "Keko_EN",

            });

            Normal.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "JumbleGuts_Clotted_EN",

           });

            Normal.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "JumbleGuts_Waning_EN",

           });

            Normal.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "Spoggle_Spitfire_EN",

           });

            Normal.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "Spoggle_Ruminating_EN",

           });

            Normal.CreateNewEnemyEncounterData(new string[]
          {
                "DrySimian_EN",
                "Lipbug_EN",
                "Mung_EN",

          });


            Normal.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("DrySimianMedium", 14, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "DrySimianHard", "DrySimian_Sign");
            Hard.MusicEvent = "event:/Music/SimianTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Voboola_Hard_EnemyBundle")._roarReference.roarEvent;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Flarb_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Unflarb_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "MudLung_EN",
                "MunglingMudLung_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "MudLung_EN",
                "FlaMinGoa_EN",
                "MudLung_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Spoggle_Ruminating_EN",
                "Spoggle_Spitfire_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "JumbleGuts_Waning_EN",
                "JumbleGuts_Clotted_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "Flarblet_EN",
                "Flarblet_EN",
                "Flarblet_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Flarbleft_EN",
                "Flarbleft_EN",
                "Flarbleft_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "DrySimian_EN",
                "MudLung_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "MudLung_EN",
                "MudLung_EN",
                "Lipbug_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "DrySimian_EN",
                "FlaMinGoa_EN",
                "Lipbug_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Seraphim_EN",
                "Mudlung_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "DrySimian_EN",
                "Seraphim_EN",
                "Lipbug_EN",

            });




            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("DrySimianHard", 22, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
