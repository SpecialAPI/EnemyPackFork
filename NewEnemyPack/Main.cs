using BepInEx;
using BrutalAPI;
using BrutalAPI.Items;
using MonoMod.RuntimeDetour;
using NewEnemyPack.Effectsa;
using NewEnemyPack.Encounters.NewEncounters;
using NewEnemyPack.Encounters.VanillaEncounters;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Utility.SerializableCollection;
using Yarn;
using static NewEnemyPack.BossUnlocks;
using Random = UnityEngine.Random;

namespace NewEnemyPack
{
    [BepInPlugin("TairbazPeep.EnemyPack", "Enemy Pack", "1.0.0")]
    [BepInDependency("BrutalOrchestra.BrutalAPI")]
    public class Main : BaseUnityPlugin
    {

        public void Awake()
        {
            IDetour CharacterIDetour = (IDetour)new Hook((MethodBase)typeof(CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof(Main).GetMethod("WillApplyDamageCH", ~BindingFlags.Default));

            Main.assetBundle = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("greyjumble"));

            if (!LoadedAssetsHandler.GetEnemy("Flarb_EN").unitTypes.Contains("Amphibian_ID")) { 
            LoadedAssetsHandler.GetEnemy("Flarb_EN").unitTypes.Add("AmphibianID");
            }
            if (!LoadedAssetsHandler.GetEnemy("Flarblet_EN").unitTypes.Contains("Amphibian_ID"))
            {
                LoadedAssetsHandler.GetEnemy("Flarblet_EN").unitTypes.Add("AmphibianID");
            }

          

            ExtraUtils_T.SetUp();


            ((CasterTransformationEffect)((PerformEffectPassiveAbility)LoadedAssetsHandler.GetEnemy("InHerImage_EN").passiveAbilities[1]).effects[0].effect)._maintainMaxHealth = true;


            


            FMODthings.Add();
            Angler.Add();
            Bud.Add();
            Area1Mimic.Add();
            Area2Mimic.Add();
            Chapman.Add();
            Chapbull.Add();
            Cherubim.Add();
            Cougher.Add();
            Unflarb.Add();
            DavyFlarb.Add();
            Flarbleft.Add();
            DrySimian.Add();
            Lipbug.Add();
            Nephilim.Add();
            Seraphim.Add();
            Zygote.Add();
            FesteringPile.Add();
            Kekapex.Add();
            DeadFlarb.Add();
            Intijar.Add();
            GreyJumble.Add();
            Gizo.Add();
            Revolting.Add();
            Ophanim.Add();
            Maestro.Add();
            SingingMountain.Add();
            Opisthotonus.Add();
            Neoplasms.Add();
            Unicorn.Add();
            DepressionSquid.Add();
            NowakSpoggle.Add();
            Peon.Add();
            Unterling.Add();
            Screaming.Add();
            Psychopomp.Add();
            Metatron.Add();
            Fountain.Add();
            Usurper.Add();
            Highness.Add();
            Doula.Add();
            Sachiel.Add();
            Goblin.Add();
            KleiverConductor.Add();
            Vermin.Add();







            //// ENCOUNTERS /////
            DrySimianEncounters.Add();
            UnflarbEncounters.Add();
            SanbdankEncounters.Add();
            NephilimEncounters.Add();
            SeraphimEncounters.Add();
            KekapexEncounters.Add();
            ZygoteEncounters.Add();
            IntijarBOSSencounter.Add();
            GreyJumbleEncounters.Add();
            GizoEncounters.Add();
            RoadieEncounters.Add();
            ChapmanEncounters.Add();
            CherubimEncounters.Add();
            OpisthotonusEncounters.Add();
            ChapbullEncounters.Add();
            RevoltingEncounters.Add();
            OphanimEncounters.Add();     
            SingingMountainEncounter.Add();
            UnicornBOSSEncounter.Add();
            DepressionSquidBOSS.Add();
            NeoplasmHeapEncounters.Add();
            NeoplasmLakeEncounters.Add();
            AnglerEncounters.Add();
            FountainEncounter.Add();
            HighnessEncounter.Add();
            PeonEncounters.Add();
            PsychopompEncounters.Add();
            SterileBudEncounters.Add();
            MetatronEncounters.Add();
            GobllinEncounters.Add();
            DoulaBOSS.Add();


            


            //// ITEMS //////
            HalfIndirectUnlockItem.Setup();
            DoulaUnlocks.Add();
            BossUnlocks.Add();
            TragedyUnlocks.Add();
            ComedyUnlocks.Add();
            MasteryUnlock.Add();
            


            //// VANILLA ENCOUNTERS /////

            ClottedMod.Add();
            FlaMinGoaHarddMod.Add();
            FlaMinGoaMediumdMod.Add();
            FlarbMod.Add();
            KekastleMod.Add();
            KekoMod.Add();
            MudLungMod.Add();
            MunglingMod.Add();
            VoboolaMod.Add();
            ConductorMod.Add();
            FlummoxingMod.Add();
            WrithingMod.Add();
            HollowingMod.Add();
            ResonantMod.Add();
            MusicManMod.Add();
            RevolaMod.Add();
            ScrungieMod.Add();
            HerImageMod.Add();
            HisImageMod.Add();
            HomunculiMod.Add();
            MinisterMod.Add();

            SaveBoolSetterEffect saveBoolSetterEffect = ScriptableObject.CreateInstance<SaveBoolSetterEffect>();
            saveBoolSetterEffect.settotrue = true;
            saveBoolSetterEffect.variablename = "BronzoSpawn";






            LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enterEffects = new EffectInfo[] { LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enterEffects[0], LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enterEffects[1], LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enterEffects[2], LoadedAssetsHandler.GetEnemy("Bronzo1_EN").enterEffects[3], Effects.GenerateEffect(saveBoolSetterEffect, 1, Targeting.Unit_AllOpponents) };

        }
        public static List<EffectInfo> _bronzoeffects;

        public static AssetBundle assetBundle;

        

        public static int WillApplyDamageCH(Func<CharacterCombat, int, IUnit, int> orig, CharacterCombat self, int amount, IUnit target)
        {
            int newdamage = orig(self, amount, target);
            if (IncreaseOthersDamageWearable.controlint >= 0)
            {
                newdamage = IncreaseOthersDamageWearable.damage + newdamage;
            }

            return newdamage;

        }

    }
}
