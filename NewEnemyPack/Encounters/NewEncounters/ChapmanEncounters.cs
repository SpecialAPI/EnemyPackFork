using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class ChapmanEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Chapman_Sign", ResourceLoader.LoadSprite("ChapmanOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Random, "ChapmanMedium", "Chapman_Sign");
            Medium.MusicEvent = "event:/Music/Chaptheme";
            Medium.RoarEvent = "event:/Chapman/ChapRoar";

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "SingingStone_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "Neoplasm_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "NakedGizo_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Spoggle_Ruminating_EN",
                "Spoggle_Spitfire_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "JumbleGuts_Waning_EN",
                "JumbleGuts_Clotted_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "MusicMan_EN",


            });

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Chapman_EN",
                "Chapman_EN",
                "Chapman_EN",
                "Seraphim_EN",


            });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "Chapman_EN",
                "Chapman_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",


           });


            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("ChapmanMedium", 20, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);


        }

    }
}
