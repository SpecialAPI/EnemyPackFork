using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class IntijarBOSSencounter
    {
        public static void Add()
        {


            Portals.AddPortalSign("Intijar_Sign", ResourceLoader.LoadSprite("IntijarIcon"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Mods/CombatEnvironment/Intijar/IntijarEnv.prefab","IntijarEnv", Main.assetBundle);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "IntijarBOSS", "Intijar_Sign");
            Medium.MusicEvent = "event:/Music/IntijarTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemy("Bronzo1_EN").deathSound;
            Medium.BossID = "IntijarBoss";
            Medium.SpecialEnvironmentID = "IntijarEnv";
            Medium.UsesSpecialEnvironment = true;
            


            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "Intijar_BOSS",

            },
            new int[]
            {
                2

            });

            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("IntijarBOSS", 10, ZoneType_GameIDs.FarShore_Hard, BundleDifficulty.Boss);

            VsBossData vsBossData111 = new VsBossData();
            vsBossData111.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/BossSplashes/IntijarSplash.anim");
            vsBossData111.roarTime = 3;
            vsBossData111.arenaSprite = ResourceLoader.LoadSprite("IntijarEnv");
            vsBossData111.extraArenaSprite = ResourceLoader.LoadSprite("UniEnv");
            vsBossData111.bossSprite = ResourceLoader.LoadSprite("IntijarSplash");
            vsBossData111.signatureSprite = ResourceLoader.LoadSprite("IntijarName");
            vsBossData111.extraSignatureSprite = ResourceLoader.LoadSprite("SquidName");

            Misc.AddCustom_VSAnimationData("IntijarBoss", vsBossData111);
            
            LoadedDBsHandler._PortalDB.AddBackgroundPortal("IntijarBoss", ResourceLoader.LoadSprite("IntijarPortal"));

            string[] dialogue =
            {
                "I know you want to wallop on this guy, but temper your anger for this one, he spawns more rocks the more you pummel him.",
                "Be careful and don't let this egghead get too comfortable in all his rocks, or else it'll all come crashing down (literally, in your face, it'll be painful)",
                "His little statues might seem scary, but they are fairly weak on their own, just don't let a bunch of them pile up."


            };



            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("IntijarBoss", dialogue);


        }

    }
}
