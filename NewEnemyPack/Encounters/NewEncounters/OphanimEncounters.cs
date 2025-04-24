using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class OphanimEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Ophanim_Sign", ResourceLoader.LoadSprite("OphanimBattle"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "OphanimHard", "Ophanim_Sign");
            Hard.MusicEvent = "event:/Music/OphanimTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").damageSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "JumbleGuts_Clotted_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "MusicMan_EN",
                "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "MusicMan_EN",
                "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Chapman_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "JumbleGuts_Hollowing_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "JumbleGuts_Flummoxing_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "DesiccatingJumbleguts_EN",
                 "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "JumbleGuts_Clotted_EN",
                "JumbleGuts_Waning_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "Gizo_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "Spoggle_Spitfire_EN",
                "Spoggle_Ruminating_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Scrungie_EN",
                "Scrungie_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "NeoplasmHeap_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Ophanim_EN",
                "Seraphim_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",


            });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("OphanimHard", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
