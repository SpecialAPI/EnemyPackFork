using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class GreyJumbleEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("GreyJumble_Sign", ResourceLoader.LoadSprite("GreyJIconB"), Portals.EnemyIDColor);

            EnemyEncounter_API Med = new EnemyEncounter_API(EncounterType.Random, "GreyJumbleMedium", "GreyJumble_Sign");
            Med.MusicEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle")._musicEventReference;
            Med.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone02_JumbleGuts_Flummoxing_Medium_EnemyBundle")._roarReference.roarEvent;
            

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "DesiccatingJumbleguts_EN",
                "JumbleGuts_Flummoxing_EN",
                "MusicMan_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "DesiccatingJumbleguts_EN",
                "JumbleGuts_Hollowing_EN",
                "MusicMan_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "DesiccatingJumbleguts_EN",
                "MusicMan_EN",
                "MusicMan_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
          {
                "DesiccatingJumbleguts_EN",
                "MusicMan_EN",
                "SilverSuckle_EN",

          });


            Med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("GreyJumbleMedium", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Medium);


        }
    }
}
