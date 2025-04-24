using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class SterileBudEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("SterileBud_Sign", ResourceLoader.LoadSprite("BudOW"), Portals.EnemyIDColor);

            EnemyEncounter_API Med = new EnemyEncounter_API(EncounterType.Random, "SterileBudMedium", "SterileBud_Sign");
            Med.MusicEvent = "event:/Music/Budtheme";
            Med.RoarEvent = LoadedAssetsHandler.GetCharacter("Leviat_CH").dxSound;

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "InHisImage_EN",
                "InHerImage_EN",
                "NextOfKin_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "SterileBud_EN",
                "NextOfKin_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "SterileBud_EN",
                "TitteringPeon_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",
                "NextOfKin_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "Unterling_EN",
                "Unterling_EN",


            });

            Med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("SterileBudMedium", 7, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);



            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "SterileBudHard", "SterileBud_Sign");
            Hard.MusicEvent = "event:/Music/Budtheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetCharacter("Leviat_CH").dxSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "InHisImage_EN",
                "InHerImage_EN",
                "SterileBud_EN",
                "InHerImage_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "ShiveringHomunculus_EN",
                "SterileBud_EN",
                "SterileBud_EN",
                "ShiveringHomunculus_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "InHisImage_EN",
                "SterileBud_EN",
                "InHisImage_EN",
                "InHerImage_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "InHisImage_EN",
                "SterileBud_EN",
                "TitteringPeon_EN",
                "TitteringPeon_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "SterileBud_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "SterileBud_EN",
                "SterileBud_EN",
                "Unterling_EN",
                "Unterling_EN",

            });

            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("SterileBudHard", 8, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);


        }
    }
}
