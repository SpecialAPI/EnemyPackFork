using System;
using System.Collections.Generic;
using System.Text;
using BrutalAPI;
using UnityEngine;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class SanbdankEncounters
    {

        public static void Add()
        {
            Color fake = new Color(149/255f, 145/255f, 50/255f);

            Portals.AddPortalColor("FakeGold", fake);

            Portals.AddPortalSign("Sandbank_Sign", ResourceLoader.LoadSprite("ChestIcon"), "FakeGold");

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "SandbankMedium", "Sandbank_Sign");
            Medium.MusicEvent = "event:/Music/MimicTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Sandbank_EN",

            },
            new int[]
            {
                2

            });

            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("SandbankMedium", 4, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Medium);




            Portals.AddPortalSign("YellowSandbank_Sign", ResourceLoader.LoadSprite("YChestIcon"), "FakeGold");

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Specific, "YellowSandbankHard", "YellowSandbank_Sign");
            Hard.MusicEvent = "event:/Music/MimicTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_TaMaGoa_Hard_EnemyBundle")._roarReference.roarEvent;


            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "YellowSandbank_EN",

            },
            new int[]
            {
                2

            });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("YellowSandbankHard", 3, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
