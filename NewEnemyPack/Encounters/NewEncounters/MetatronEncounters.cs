using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class MetatronEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Metatron_Sign", ResourceLoader.LoadSprite("Metatron"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "MetatronHard", "Metatron_Sign");
            Hard.MusicEvent = "event:/Music/MetaTheme";
            Hard.RoarEvent = "event:/Metatron/MetatronRoar";

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "ShiveringHomunculus_EN",
                "ShiveringHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "SkinningHomunculus_EN",
                "SkinningHomunculus_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "InHerImage_EN",
                "InHisImage_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "GigglingMinister_EN",
                "GigglingMinister_EN",
                

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "GigglingMinister_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "GigglingMinister_EN",
                "TitteringPeon_EN",
                "TitteringPeon_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "SkinningHomunculus_EN",
                "ShiveringHomunculus_EN",
                "ScreamingHomunculus_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "InHerImage_EN",
                "InHerImage_EN",
                "InHisImage_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "InHerImage_EN",
                "InHisImage_EN",
                "InHisImage_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "SterileBud_EN",
                "SterileBud_EN",


            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "SterileBud_EN",
                "InHerImage_EN",
                "InHisImage_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "SterileBud_EN",
                "ChoirBoy_EN",
                "ChoirBoy_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "Metatron_EN",
                "SterileBud_EN",
                "Unterling_EN",
                "Unterling_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
           {
                "Metatron_EN",
                "GigglingMinister_EN",
                "Unterling_EN",
                "Unterling_EN",

           });


            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("MetatronHard", 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Hard);
        }

    }
}
