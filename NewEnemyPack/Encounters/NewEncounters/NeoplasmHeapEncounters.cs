using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class NeoplasmHeapEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("NeoplasmHeap_Sign", ResourceLoader.LoadSprite("HeapOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Random, "HeapMedium", "NeoplasmHeap_Sign");
            Medium.MusicEvent = "event:/Music/SlimeTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;

            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "SingingStone_EN",
                "SingingStone_EN",

            });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "Neoplasm_EN",

           });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "MusicMan_EN",
                "MusicMan_EN",

           });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "Gizo_EN",

           });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",

           });

            Medium.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "Neoplasm_EN",
                "MusicMan_EN",

           });


            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("HeapMedium", 12, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "HeapHard", "NeoplasmHeap_Sign");
            Hard.MusicEvent = "event:/Music/SlimeTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "NeoplasmHeap_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "Seraphim_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "Gizo_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "MusicMan_EN",
                "MusicMan_EN",
                "MusicMan_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "NeoplasmHeap_EN",
                "Scrungie_EN",
                "Scrungie_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "Gizo_EN",
                "NakedGizo_EN",
                "Neoplasm_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "Chapman_EN",
                "Chapman_EN",
                

           });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "NeoplasmHeap_EN",
                "Chapman_EN",
                "Chapman_EN",
                "Neoplasm_EN",


           });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("HeapHard", 13, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);


        }
    }
}
