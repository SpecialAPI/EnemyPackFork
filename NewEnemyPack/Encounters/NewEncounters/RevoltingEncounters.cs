using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class RevoltingEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Revolting_Sign", ResourceLoader.LoadSprite("RevoltingIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "RevoltingHard", "Revolting_Sign");
            Hard.MusicEvent = "event:/Music/RevoltingTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Revola_Hard_EnemyBundle")._roarReference.roarEvent;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "Chapman_EN",
                "Chapman_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "NeoplasmHeap_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "JumbleGuts_Hollowing_EN",
                "JumbleGuts_Flummoxing_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "JumbleGuts_Hollowing_EN",
                "DesiccatingJumbleguts_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "Spoggle_Resonant_EN",
                "Spoggle_Writhing_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "Gizo_EN",
                "NakedGizo_EN",

            });


            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "RevoltingRevola_EN",
                "Seraphim_EN",
                "MusicMan_EN",

            });



            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("RevoltingHard", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
