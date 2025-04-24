using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Opisthotonus
    {
        public static void Add()
        {
            

            Enemy enemy = new Enemy("Opisthotonus", "Opisthotonus_EN");
            enemy.Health = 85;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("Opisthotonus", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("Opisthotonus", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("OpisthotonusCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Charcarrion_Corpse_BOSS").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Charcarrion_Corpse_BOSS").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.GetCustomPassive("FourFaced_PA"), Passives.MultiAttack3, Passives.Slippery, Passives.Transfusion });
            enemy.PrepareEnemyPrefab("Assets/DemonJumble/Opisthotonus.prefab", Main.assetBundle);
            
            CheckHealthColorEffect checkRedHealthColorEffect = ScriptableObject.CreateInstance<CheckHealthColorEffect>();
            checkRedHealthColorEffect._Color = Pigments.Red;

            CheckHealthColorEffect checkPurpleHealthColorEffect = ScriptableObject.CreateInstance<CheckHealthColorEffect>();
            checkPurpleHealthColorEffect._Color = Pigments.Purple;

            CheckHealthColorEffect checkYellowHealthColorEffect = ScriptableObject.CreateInstance<CheckHealthColorEffect>();
            checkYellowHealthColorEffect._Color = Pigments.Yellow;

            CheckHealthColorEffect checkBlueHealthColorEffect = ScriptableObject.CreateInstance<CheckHealthColorEffect>();
            checkBlueHealthColorEffect._Color = Pigments.Blue;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.OnFire;

            enemy.AddLootData(new EnemyLootItemProbability[]{
                new EnemyLootItemProbability
                {
                    isItemTreasure = true,
                    amount = 1,
                    probability = 100
                },
                   new EnemyLootItemProbability
                {
                    isItemTreasure = false,
                    amount = 1,
                    probability = 100
                },});

            Ability ability = new Ability("Blood_A");
            ability.Name = "Blood";
            ability.Description = "Deals a Little amount of damage to the Opposing party member and Inflict 1 Fire to the Opposing position.\nIf this enemy's health color is Red, instead Inflict 99 fire to the Opposing position and deal a Painful amount of damage to the Opposing party member.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(checkRedHealthColorEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,1)),
                  Effects.GenerateEffect(fieldEffect_Apply_, 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,2)),
                  Effects.GenerateEffect(fieldEffect_Apply_, 99, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,3)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,4)),

            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Field_Fire.ToString(), IntentType_GameIDs.Misc.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Pyre_A").visuals;

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.OilSlicked;

            Ability ability1 = new Ability("Bile_A");
            ability1.Name = "Bile";
            ability1.Description = "Inflict 1 Oil-slicked to the Opposing party member, and deal a Little amount of damage to the Opposing party member.\nIf this enemy's health color is Yellow, instead deal a Painful amount of damage then Inflict 99 Oil-slicked to the Opposing party member.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(checkYellowHealthColorEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,2)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,3)),
                  Effects.GenerateEffect(statusEffect_Apply_, 99, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true, 4)),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_OilSlicked.ToString(), IntentType_GameIDs.Misc.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("FetalFroth_A").visuals;

            StatusEffect_Apply_Effect cstatusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            cstatusEffect_Apply_1._Status = StatusField.Cursed;

            ChangeMaxHealthEffect changeMaxHealth = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealth._entryAsPercentage = true;
            changeMaxHealth._increase = false;

            Ability ability11 = new Ability("Arsenic_A");
            ability11.Name = "Arsenic";
            ability11.Description = "Inflict Curse to the Opposing party member.\nIf this enemy's health color is Purple, reduce the Opposing party member's health to 20% of their max health and inflict them with Curse, and then deal Almost no damage to them.";
            ability11.Rarity = Abil.Weight(5);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(checkPurpleHealthColorEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(cstatusEffect_Apply_1, 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SetHealthToPercentOfMaxHealthEffect>(), 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,2)),
                  Effects.GenerateEffect(cstatusEffect_Apply_1, 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,3)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,4)),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Cursed.ToString(), IntentType_GameIDs.Other_MaxHealth_Alt.ToString(), IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Misc.ToString() });
            ability11.AnimationTarget = Targeting.Slot_Front;
            ability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("Boil_A").visuals;


            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.Ruptured;

            Ability ability111 = new Ability("Salt_A");
            ability111.Name = "Salt";
            ability111.Description = "Inflict 1 Ruptured to the Opposing party member, and move the Opposing party member Left or Right.\nIf this enemy's health color is Blue, instead Apply 99 Ruptured to the Opposing party member, move this enemy Left or Right 3 times, and Deal a Painful amount of damage to the Opposing party member.\r\n";
            ability111.Rarity = Abil.Weight(5);
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(checkBlueHealthColorEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(statusEffect_Apply_1, 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false,2)),
                  Effects.GenerateEffect(statusEffect_Apply_1, 99, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,3)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,4)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,5)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,6)),
                   Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,7)),
            };
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc.ToString() });
            ability111.AnimationTarget = Targeting.Slot_Front;
            ability111.Visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;


            Ability ability1111 = new Ability("FourHumors_A");
            ability1111.Name = "Four Humors";
            ability1111.Description = "Produce 3 Pigment of this enemy's health color.\nMove this enemy to the Left or Right.";
            ability1111.Rarity = Abil.Weight(5);
            ability1111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 3, Targeting.Slot_SelfSlot),
                   Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            ability1111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString(), IntentType_GameIDs.Swap_Sides.ToString() });
            ability1111.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;


            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability111, ability11, ability1111 });
            enemy.AddEnemy(true, false, false);


        }

    }
}
