using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Ophanim
    {
        public static void Add()
        {

            BlazingPassiveAbility passive = ScriptableObject.CreateInstance<BlazingPassiveAbility>();

            passive._passiveName = "Blazing";
            passive.passiveIcon = ResourceLoader.LoadSprite("BlazingIcon");
            passive.m_PassiveID = "Blazing_PA";
            passive._enemyDescription = "This enemy permanently inflicts Fire to the Opposing Position.";
            passive._characterDescription = "This party member permanently inflicts Fire to the Opposing Position.";
            passive._triggerOn = LoadedAssetsHandler.GetEnemy("Voboola_EN").passiveAbilities[1]._triggerOn;
            passive._Fire = (OnFireFE_SO)StatusField.OnFire;

            Passives.AddCustomPassiveToPool("Blazing_PA", "Blazing", passive);
            GlossaryPassives passiveInfo = new GlossaryPassives("Blazing", "This enemy/party member permanently inflicts Fire to the Opposing Position.", ResourceLoader.LoadSprite("BlazingIcon", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);

            Enemy enemy = new Enemy("Ophanim", "Ophanim_EN");
            enemy.Health = 55;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 2;

            enemy.CombatSprite = ResourceLoader.LoadSprite("OphanimBattle", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("OphanimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("OphanimCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.MultiAttack2, Passives.Slippery, passive });
            enemy.PrepareEnemyPrefab("Assets/Ophanim/Ophanim.prefab", Main.assetBundle);

            GenerateColorManaEffect generateColorMana = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            generateColorMana.mana = Pigments.Red;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.OnFire;
            fieldEffect_Apply_._UseRandomBetweenPrevious = true;

            FieldEffect_Apply_Effect fieldEffect_Apply_1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_1._Field = StatusField.Constricted;


            Ability ability = new Ability("Legion_A");
            ability.Name = "Legion";
            ability.Description = "Apply 1-2 Fire to the Opposing positions.\nMove Left or Right.\nProduce 1-2 Red pigment.\n\"For we are many\"";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_Apply_, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(generateColorMana, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(generateColorMana, 1, Targeting.Slot_SelfSlot, Conditions.Chance(50)),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Field_Fire.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Mana_Generate.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Pyre_A").visuals;

            SwapToOneSideEffect swapright = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapright._swapRight = true;

            SwapToOneSideEffect swapleft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapleft._swapRight = false;


            Ability ability1 = new Ability("WalktheEarth_A");
            ability1.Name = "Walk the Earth";
            ability1.Description = "Move the Left and Right party members not Opposing this enemy closer to this enemy.\nApply 1 Constricted to the Opposing positions.\nProduce 1-2 Red pigment.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(swapright, 1, Targeting.Slot_OpponentLeft),
                  Effects.GenerateEffect(swapleft, 1, Targeting.Slot_OpponentRight),
                  Effects.GenerateEffect(fieldEffect_Apply_1, 1, Targeting.Slot_Front),
                 Effects.GenerateEffect(generateColorMana, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(generateColorMana, 1, Targeting.Slot_SelfSlot, Conditions.Chance(50)),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentLeft, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentRight, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Field_Constricted.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            ability1.AnimationTarget = Targeting.Slot_OpponentSides;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals;

            FieldEffectIfStatus_Apply_Effect fieldEffectIfStatus_Apply_ = ScriptableObject.CreateInstance<FieldEffectIfStatus_Apply_Effect>();
            fieldEffectIfStatus_Apply_._Status = StatusField.OilSlicked.ToString();
            fieldEffectIfStatus_Apply_._Field = StatusField.OnFire;

            StatusEffectIfInField_Apply_Effect statusEffectIfInField_Apply_Effect = ScriptableObject.CreateInstance<StatusEffectIfInField_Apply_Effect>();
            statusEffectIfInField_Apply_Effect._Field = StatusField.OnFire._FieldID;
            statusEffectIfInField_Apply_Effect._Status = StatusField.OilSlicked;



            Ability ability11 = new Ability("CarbonTears_A");
            ability11.Name = "Carbon Tears";
            ability11.Description = "Apply 1 Fire to All party members that are Oil-Slicked.\nInflict 1-2 Oil-Slicked to All party members not standing in Fire.";
            ability11.Rarity = Abil.Weight(5);
            ability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(fieldEffectIfStatus_Apply_, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(statusEffectIfInField_Apply_Effect, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(statusEffectIfInField_Apply_Effect, 1, Targeting.Unit_AllOpponents, Conditions.Chance(50)),



            };
            ability11.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Field_Fire.ToString(), IntentType_GameIDs.Status_OilSlicked.ToString() });
            ability11.AnimationTarget = Targeting.Unit_AllOpponents;
            ability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, false, false);
            

          
        }

    }
}
