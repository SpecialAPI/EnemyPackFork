using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class SingingMountainEncounter
    {
        public static void Add()
        {
            Portals.AddPortalSign("Mountain_Sign", ResourceLoader.LoadSprite("SingingMountain_overworld"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "MountainHard", "Mountain_Sign");
            Hard.MusicEvent = "event:/Music/MountainTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Conductor_Hard_EnemyBundle")._roarReference.roarEvent;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SingingMountain_EN",
                "Spoggle_Writhing_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SingingMountain_EN",
                "Spoggle_Resonant_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SingingMountain_EN",
                "Scrungie_EN",
                "Scrungie_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SingingMountain_EN",
                "MusicMan_EN",
                "SingingStone_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SingingMountain_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SingingMountain_EN",
                "SingingStone_EN",
                "SingingStone_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "SingingMountain_EN",
                "Chapman_EN",
                "Chapman_EN",

           });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "SingingMountain_EN",
                "Seraphim_EN",

           });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("MountainHard", 12, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
