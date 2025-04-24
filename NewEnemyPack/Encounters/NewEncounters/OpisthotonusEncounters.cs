using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class OpisthotonusEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Opisthotonus_Sign", ResourceLoader.LoadSprite("Opisthotonus"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "OpisthotonusHard", "Opisthotonus_Sign");
            Hard.MusicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_JumbleGuts_Waning_Medium_EnemyBundle")._musicEventReference;
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("Charcarrion_Corpse_BOSS").deathSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Opisthotonus_EN",
                "SilverSuckle_EN",
                "SilverSuckle_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
          {
                "Opisthotonus_EN",
                "MusicMan_EN",
                "SingingStone_EN",

          });

            Hard.CreateNewEnemyEncounterData(new string[]
          {
                "Opisthotonus_EN",
                "Neoplasm_EN",
                "Neoplasm_EN",

          });

            Hard.CreateNewEnemyEncounterData(new string[]
             {
                "Opisthotonus_EN",

            });


            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("OpisthotonusHard", 8, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Hard);
        }
    }
}
