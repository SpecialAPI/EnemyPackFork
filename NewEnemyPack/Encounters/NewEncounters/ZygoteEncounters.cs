using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class ZygoteEncounters
    {
        public static void Add()
        {
            Portals.AddPortalSign("Zygote_Sign", ResourceLoader.LoadSprite("ZygoteIcon"), Portals.EnemyIDColor);

            EnemyEncounter_API Hard = new EnemyEncounter_API(EncounterType.Random, "ZygoteHard", "Zygote_Sign");
            Hard.MusicEvent = "event:/Music/ZygoteTheme";
            Hard.RoarEvent = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").deathSound;


            Hard.CreateNewEnemyEncounterData(new string[]
{
                "BastardZygote_EN",

});

            Hard.CreateNewEnemyEncounterData(new string[]
            {
                "BastardZygote_EN",
                "Keko_EN",
                "Keko_EN",

            });

            Hard.CreateNewEnemyEncounterData(new string[]
{
                "BastardZygote_EN",
                "MudLung_EN",
            

});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "BastardZygote_EN",
                "MunglingMudLung_EN",


});
            Hard.CreateNewEnemyEncounterData(new string[]
{
                "BastardZygote_EN",
                "Seraphim_EN",


});


            Hard.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("ZygoteHard", 12, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Hard);
        }
    }
}
