using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class ChapbullEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Chapbull_Sign", ResourceLoader.LoadSprite("ChapbullOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "ChapbullHard", "Chapbull_Sign");
            Hard.MusicEvent = "event:/Music/Chaptheme";
            Hard.RoarEvent = "event:/ChapBull/BullRoar";

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Musicman_EN",
                "Chapman_EN",
                "Musicman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Chapman_EN",
                "SilverSuckle_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Scrungie_EN",
                "Scrungie_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Spoggle_Ruminating_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Spoggle_Spitfire_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "JumbleGuts_Waning_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "JumbleGuts_Clotted_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "NakedGizo_EN",
                "Chapman_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Neoplasm_EN",
                "Chapman_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "NeoplasmHeap_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "Gizo_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Chapbull_EN",
                "Chapman_EN",
                "DesiccatingJumbleguts_EN",

            });


            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("ChapbullHard", 15, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
