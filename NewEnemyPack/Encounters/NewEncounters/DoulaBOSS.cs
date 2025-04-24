using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class DoulaBOSS
    {
        public static void Add()
        {


            Portals.AddPortalSign("Doula_Sign", ResourceLoader.LoadSprite("DoulaIcon"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Mods/CombatEnvironment/Doula/Zone01_CombatEnv_ModTemplate.prefab", "DoulaEnv", Main.assetBundle);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "DoulaBOSS", "Doula_Sign");
            Medium.MusicEvent = "event:/Music/DoulaTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("BOSS_Zone03_Corpse_EnemyBundle")._roarReference.roarEvent;
            Medium.BossID = "DoulaBoss";
            Medium.SpecialEnvironmentID = "DoulaEnv";
            Medium.UsesSpecialEnvironment = true;



            Medium.CreateNewEnemyEncounterData(new string[]
            {
         
                "Doula_BOSS",


            },
            new int[]
            {
                
                2,
                

            });



            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("DoulaBOSS", 10, ZoneType_GameIDs.Garden_Hard, BundleDifficulty.Boss);

            VsBossData vsBossData111 = new VsBossData();
            vsBossData111.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/BossSplashes/DoulaSplash.anim");
            vsBossData111.roarTime = 3;
            vsBossData111.arenaSprite = ResourceLoader.LoadSprite("DoulaEnv");
            vsBossData111.extraArenaSprite = ResourceLoader.LoadSprite("UniEnv");
            vsBossData111.bossSprite = ResourceLoader.LoadSprite("DoulaNewSplash");
            vsBossData111.signatureSprite = ResourceLoader.LoadSprite("DoulaName");
            vsBossData111.extraSignatureSprite = ResourceLoader.LoadSprite("SquidName");

            Misc.AddCustom_VSAnimationData("DoulaBoss", vsBossData111);

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("DoulaBoss", ResourceLoader.LoadSprite("DoulaPortal"));


            string[] dialogue =
{
                "God, I feel so sick. Do you feel like you are spinning too?",
                "Wait, that didn't happen right? That couldn't have happened to us.",
                "Who's that crying? Nowak am I crying? Are those tears mine?"

            };



            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("DoulaBoss", dialogue);

        }
    }
}
