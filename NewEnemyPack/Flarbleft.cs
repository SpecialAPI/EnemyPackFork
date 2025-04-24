using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Flarbleft
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Flarbleft", "Flarbleft_EN");
            enemy.Health = 8;
            enemy.HealthColor = Pigments.Blue;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(-1);

            enemy.CombatSprite = ResourceLoader.LoadSprite("FlarbleftIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("FlarbleftOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("FlarbleftCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Flarbleft/FlarbleftDMG";
            enemy.DeathSound = "event:/Flarbleft/FlarbleftDeath";

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Infantile});
            enemy.PrepareEnemyPrefab("assets/flarbleft/flarbleft.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/flarbleft/giblets_flarbleft.prefab").GetComponent<ParticleSystem>());

            DamageTargetRandomEffect fl = ScriptableObject.CreateInstance<DamageTargetRandomEffect>();
            fl._indirect = true;

            Ability ability = new Ability("Flick_A");
            ability.Name = "Flick";
            ability.Description = "Deals almost no Indirect damage to a Random party member.";
            ability.Rarity = Abil.Weight(8);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(fl, 1, Targeting.Unit_AllOpponents),


            };
            ability.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability.AnimationTarget = Targeting.Unit_AllOpponents;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Psaltery_EN").abilities[0].ability.visuals;



            GenerateColorManaEffect he = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            he.mana = Pigments.Blue;


            GenerateColorManaEffect he1 = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            he1.mana = Pigments.Purple;

            Ability ability1 = new Ability("EctoplasmicEmesis_A");
            ability1.Name = "Ectoplasmic Emesis";
            ability1.Description = "This enemy produces one Purple, and one Blue pigment.\n\"Point of study among experts nowhere\"";
            ability1.Rarity = Abil.Weight(12);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(he1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(he, 1, Targeting.Slot_SelfSlot),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Flarblet_EN").abilities[1].ability.visuals;


            SpawnEnemyAnywhereEffect he2 = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            he2.enemy = LoadedAssetsHandler.GetEnemy("Unflarb_EN");
            he2._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            SpawnEnemyAnywhereEffect he3 = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            he3.enemy = LoadedAssetsHandler.GetEnemy("DavyFlarb_EN");
            he3._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.wasSuccessful = true;

            PreviousEffectCondition previousEffectCondition1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition1.wasSuccessful = false;
            previousEffectCondition1.previousAmount = 2;

            Ability ability11 = new Ability("GhastlyCry_A");
            ability11.Name = "Ghastly Cry";
            ability11.Description = "Attempt to summon an Unflarb.";
            ability11.Rarity = Abil.Weight(3);
            ability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot, Conditions.Chance(99)),
                  Effects.GenerateEffect(he2, 1, Targeting.Slot_SelfSlot, previousEffectCondition),
                  Effects.GenerateEffect(he3, 1, Targeting.Slot_SelfSlot, previousEffectCondition1),


            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Spawn.ToString() });
            ability11.AnimationTarget = Targeting.Slot_SelfSlot;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Flarblet_EN").abilities[2].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, true);


        }
    }
}
