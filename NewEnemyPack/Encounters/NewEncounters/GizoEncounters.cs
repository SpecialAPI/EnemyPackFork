using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class GizoEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Gizo_Sign", ResourceLoader.LoadSprite("GizoIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Med = new EnemyEncounter_API(EncounterType.Random, "GizoMedium", "Gizo_Sign");
            Med.MusicEvent = "event:/Music/GizoTheme";
            Med.RoarEvent = "event:/Gizo/GizoRoar";


            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "MusicMan_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "SingingStone_EN",
            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "ManicMan_EN",
                "ManicMan_EN",
                
            });
            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "JumbleGuts_Hollowing_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "JumbleGuts_Flummoxing_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "DesiccatingJumbleguts_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Neoplasm_EN",
                "MusicMan_EN",
                "Neoplasm_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Neoplasm_EN",
                "MusicMan_EN",
                "SingingStone_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "Spoggle_Resonant_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "Spoggle_Writhing_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Scrungie_EN",
                "Scrungie_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "Seraphim_EN",

            });
            Med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("GizoMedium", 20, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);



            EnemyEncounter_API hard = new EnemyEncounter_API(EncounterType.Random, "GizoHard", "Gizo_Sign");
            hard.MusicEvent = "event:/Music/GizoTheme";
            hard.RoarEvent = "event:/Gizo/GizoRoar";


            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "NakedGizo_EN",
            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "SingingStone_EN",
                "NakedGizo_EN",
            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Neoplasm_EN",
                "NakedGizo_EN",
            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "ManicMan_EN",
                "ManicMan_EN",
                "ManicMan_EN",
                "ManicMan_EN",
            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Scrungie_EN",
                "Scrungie_EN",
               
            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "JumbleGuts_Waning_EN",
                "JumbleGuts_Clotted_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "JumbleGuts_Hollowing_EN",
                "NakedGizo_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "JumbleGuts_Flummoxing_EN",
                "NakedGizo_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "DesiccatingJumbleguts_EN",
                "NakedGizo_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Spoggle_Writhing_EN",
                "NakedGizo_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Spoggle_Resonant_EN",
                "NakedGizo_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Spoggle_Spitfire_EN",
                "Spoggle_Ruminating_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Spoggle_Spitfire_EN",
                "Spoggle_Ruminating_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "MusicMan_EN",
                "MusicMan_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "MusicMan_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Chapman_EN",
                "Chapman_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "NakedGizo_EN",
                "NeoplasmHeap_EN",

            });

            hard.CreateNewEnemyEncounterData(new string[]
            {
                "Gizo_EN",
                "Gizo_EN",
                "Seraphim_EN",
                "NakedGizo_EN",

            });
            hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("GizoHard", 17, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);


        }
    }
}
