using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class DepressionSquidBOSS
    {
        public static void Add()
        {


            Portals.AddPortalSign("Squid_Sign", ResourceLoader.LoadSprite("SquidIcon"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Mods/CombatEnvironment/Squid/SquidEnv.prefab", "SquidEnv", Main.assetBundle);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "SquidBOSS", "Squid_Sign");
            Medium.MusicEvent = "event:/Music/SquidTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("BOSS_Zone02_Ouroboros_EnemyBundle")._roarReference.roarEvent;
            Medium.BossID = "SquidBoss";
            Medium.SpecialEnvironmentID = "SquidEnv";
            Medium.UsesSpecialEnvironment = true;



            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "GrippingTentacle_EN",
                "DepressionSquid_BOSS",
                "GrippingTentacle_EN",

            },
            new int[]
            {
                1,
                2,
                3

            });



            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("SquidBOSS", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);

            VsBossData vsBossData111 = new VsBossData();
            vsBossData111.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/BossSplashes/SquidSplash.anim");
            vsBossData111.roarTime = 4;
            vsBossData111.arenaSprite = ResourceLoader.LoadSprite("SquidEnv");
            vsBossData111.extraArenaSprite = ResourceLoader.LoadSprite("UniEnv");
            vsBossData111.bossSprite = ResourceLoader.LoadSprite("SquidSplash");
            vsBossData111.signatureSprite = ResourceLoader.LoadSprite("SquidName");
            vsBossData111.extraSignatureSprite = ResourceLoader.LoadSprite("SquidName");

            Misc.AddCustom_VSAnimationData("SquidBoss", vsBossData111);

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("SquidBoss", ResourceLoader.LoadSprite("SquidPortal"));


            string[] dialogue =
{
                "This guy's head is super bulky, don't try to bum-rush it. Killing its limbs gives the head Frail, that softens it up by a lot.",
                "Trying to get rid of all it's tentacles may be a bad idea, you won't have any actions left to attack the main guy and waste the Frail applied to it.",
                "Pick which tentacles to kill carefully. Each of them has an unique trick up their sleeve, but you probably can't afford to kill all of them. Probably"

            };



            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("SquidBoss", dialogue);

        }
    }
}
