using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class GreyJumble
    {
        public static void Add()
        {

            Enemy enemy = new Enemy("Desiccating Jumbleguts", "DesiccatingJumbleguts_EN");
            enemy.Health = 22;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("GreyJIconB", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("GreyJIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("GreyJDead", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Pure, Passives.Transfusion });
            enemy.PrepareEnemyPrefab("assets/greyjumble/greyjumble.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/greyJumble/giblets_greyJumble.prefab").GetComponent<ParticleSystem>());

            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.wasSuccessful = true;

            PreviousEffectCondition previousEffectCondition1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition1.wasSuccessful = false;
            previousEffectCondition1.previousAmount = 2;

            PreviousEffectCondition prevfalse = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            prevfalse.wasSuccessful = false;

            Ability ability = new Ability("Plaster_A");
            ability.Name = "Plaster";
            ability.Description = "Deal a Painful amount of Damage to the Left, Opposing, and Right party members.\nIf this enemy has less than 50% health, deal that damage to only Opposing instead.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageIfUnderFiftyHealthEffect>(), 6, Targeting.Slot_OpponentSides),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_Front),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").rankedData[0].rankAbilities[2].ability.visuals;

            Ability ability1 = new Ability("Cling_A");
            ability1.Name = "Cling";
            ability1.Description = "Produce 3 Pigment of the Opposing party member's Health color.\nIf there is no Opposing party member deal a Painful amount of damage to this enemy.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {

                    Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ProduceTargetManaEffect>(), 3, Targeting.Slot_Front, previousEffectCondition),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_SelfSlot, previousEffectCondition1),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;

            ChangeMaxHealthEffect changeMaxHealth = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealth._increase = false;

            Ability ability11 = new Ability("Dust_A");
            ability11.Name = "Dust";
            ability11.Description = "Decreases all party members maximum health by 1.\nDeal a Little amount of damage to this Enemy.";
            ability11.Rarity = Abil.Weight(5);
            ability11.Effects = new EffectInfo[]
            {

                    Effects.GenerateEffect(changeMaxHealth, 1, Targeting.Unit_AllOpponents),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfSlot),


            };
            ability11.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Other_MaxHealth.ToString() });
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability11.AnimationTarget = Targeting.Slot_SelfSlot;
            ability11.Visuals = LoadedAssetsHandler.GetCharacter("Hans_CH").rankedData[0].rankAbilities[2].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, false);

        }
    }
}
