using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class CherubimEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Cherubim_Sign", ResourceLoader.LoadSprite("CherubimOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "CherubimHard", "Cherubim_Sign");
            Hard.MusicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle")._musicEventReference;
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_Spoggle_Writhing_Medium_EnemyBundle")._roarReference.roarEvent;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Cherubim_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
          {
                "Cherubim_EN",
                "MusicMan_EN",
                "SingingStone_EN",

          });

            Hard.CreateNewEnemyEncounterData(new string[]
          {
                "Cherubim_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

          });

            Hard.CreateNewEnemyEncounterData(new string[]
             {
                "Cherubim_EN",

            });


            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("CherubimHard", 8, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
