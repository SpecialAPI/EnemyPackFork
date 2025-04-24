using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class AnglerEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Angler_Sign", ResourceLoader.LoadSprite("AnglerIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "AnglerHard", "Angler_Sign");
            Hard.MusicEvent = "event:/Music/AnglerTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ChoirBoy_Easy_EnemyBundle")._roarReference.roarEvent;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "ShiveringHomunculus_EN",
                "ScreamingHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "InHerImage_EN",
                "NextOfKin_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "TitteringPeon_EN",
                "InHerImage_EN",
                "InHisImage_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "InHerImage_EN",
                "InHisImage_EN",
                "NextOfKin_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "GigglingMinister_EN",
                "TitteringPeon_EN",           

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "Unterling_EN",
                "Unterling_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "SterileBud_EN",
                "SterileBud_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "ImpenetrableAngler_EN",
                "SterileBud_EN",
                "InHisImage_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "ImpenetrableAngler_EN",
                "Unterling_EN",
                "InHisImage_EN",
                "InHerImage_EN",

});



            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("AnglerHard", 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }
    }
}
