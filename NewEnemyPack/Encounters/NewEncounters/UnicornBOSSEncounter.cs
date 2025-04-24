using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Encounters.NewEncounters
{
    internal class UnicornBOSSEncounter
    {
        public static void Add()
        {


            Portals.AddPortalSign("Unicorn_Sign", ResourceLoader.LoadSprite("Unicorn_icon"), Portals.BossIDColor);

            EnvironmentTools.PrepareCombatEnvPrefab("Assets/Mods/CombatEnvironment/Unicorn/UniZone.prefab", "UnicornEnv", Main.assetBundle);

            EnemyEncounter_API Medium = new EnemyEncounter_API(EncounterType.Specific, "UnicornBOSS", "Unicorn_Sign");
            Medium.MusicEvent = "event:/Music/UnicornTheme";
            Medium.RoarEvent = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_ShiveringHomunculus_Medium_EnemyBundle")._roarReference.roarEvent;
            Medium.BossID = "UnicornBoss";
            Medium.SpecialEnvironmentID = "UnicornEnv";
            Medium.UsesSpecialEnvironment = true;



            Medium.CreateNewEnemyEncounterData(new string[]
            {
                "MalformedUnicorn_BOSS",
                "HumanElemental_EN",

            },
            new int[]
            {
                1,
                3

            });



            Medium.AddEncounterToDataBases();
            EnemyEncounterUtils.AddEncounterToZoneSelector("UnicornBOSS", 10, ZoneType_GameIDs.Orpheum_Hard, BundleDifficulty.Boss);

            VsBossData vsBossData111 = new VsBossData();
            vsBossData111.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/BossSplashes/UnicornSplash.anim");
            vsBossData111.roarTime = 3;
            vsBossData111.arenaSprite = ResourceLoader.LoadSprite("UniEnv");
            vsBossData111.extraArenaSprite = ResourceLoader.LoadSprite("UniEnv");
            vsBossData111.bossSprite = ResourceLoader.LoadSprite("UniSplash");
            vsBossData111.signatureSprite = ResourceLoader.LoadSprite("UniName");
            vsBossData111.extraSignatureSprite = ResourceLoader.LoadSprite("UniName");

            Misc.AddCustom_VSAnimationData("UnicornBoss", vsBossData111);

            LoadedDBsHandler._PortalDB.AddBackgroundPortal("UnicornBoss", ResourceLoader.LoadSprite("UniPortal"));

            string[] dialogue =
{
                "I know it's tempting, but probably don't smack the Unicorn when it's retracted. Lots of pokey bone bits sticking out, you can suffer some serious damage!",
                "Try to keep your damage sponges away from the cube, it doesn't seem very dangerous itself, but the Ruptured it applies seems to make the Unicorn hurt a whole lot more.",
                "Be careful with the cube. It's practically unkillable so you can smack it for pigment however much you want, but take into consideration that it rerolls its abilities and moves around when you hit it. It could get your good party members on accident."


            };



            LoadedDBsHandler.GameOverDialogueDB.AddBossLinesData("UnicornBoss", dialogue);


        }
    }
}
