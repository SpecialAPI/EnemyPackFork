using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class PsychopompEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Psychopomp_Sign", ResourceLoader.LoadSprite("pompoverworld"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "PsychopompHard", "Psychopomp_Sign");
            Hard.MusicEvent = "event:/Music/PsychopompTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("Heaven_BOSS").damageSound;

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "InHerImage_EN",
                "InHisImage_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "GigglingMinister_EN",
                "GigglingMinister_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "TitteringPeon_EN",
                "InHerImage_EN",
                "InHisImage_EN"

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "ImpenetrableAngler_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
                "ScreamingHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "InHerImage_EN",
                "InHisImage_EN",
                "InHisImage_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "SterileBud_EN",
                "SterileBud_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "InHisImage_EN",
                "InHerImage_EN",
                "SterileBud_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "SterileBud_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "Unterling_EN",
                "Unterling_EN",
                "Unterling_EN",

            });


            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("PsychopompHard", 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);


            EnemyEncounter_API Med = new EnemyEncounter_API(EncounterType.Random, "PsychopompMedium", "Psychopomp_Sign");
            Med.MusicEvent = "event:/Music/PsychopompTheme";
            Med.RoarEvent = LoadedAssetsHandler.GetEnemy("Heaven_BOSS").damageSound;

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "InHisImage_EN",
                "InHerImage_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "TitteringPeon_EN",
                "InHisImage_EN",

            });

            Med.CreateNewEnemyEncounterData(new string[]
            {
                "Psychopomp_EN",
                "NextOfKin_EN",
                "SterileBud_EN",

            });

            Med.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("PsychopompMedium", 5, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Medium);

        }
    }
}
