using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Area2Mimic
    {
        public static void Add()
        {
            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.wasSuccessful = true;

            AnimationVisualsEffect animationVisuals = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisuals._visuals = LoadedAssetsHandler.GetEnemy("Wringle_EN").abilities[1].ability.visuals;
            animationVisuals._animationTarget = Targeting.Slot_Front;


            TryUnlockAchievementEffect tryUnlockAchievement = ScriptableObject.CreateInstance<TryUnlockAchievementEffect>();
            tryUnlockAchievement._unlockID = "MimicTragedy";


            ExtraLootEffect loot = ScriptableObject.CreateInstance<ExtraLootEffect>();
            loot._isTreasure = true;

            Enemy enemy = new Enemy("Gold Roadie", "GoldRoadie_EN");
            enemy.Health = 40;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot), };
            enemy.CombatSprite = ResourceLoader.LoadSprite("YChestIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("YChestOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("YChestCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Chordophone_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Chordophone_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Slippery, Passives.MultiAttack2 });
            enemy.PrepareEnemyPrefab("assets/mimics/area2/area2mimicgold.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/mimics/area2/giblets_goldroadie.prefab").GetComponent<ParticleSystem>());
            enemy.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(loot, 1, Targeting.Slot_SelfSlot) };

            StatusEffect_Apply_Effect statusEffect_Apply = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply._RandomBetweenPrevious = true;
            statusEffect_Apply._Status = StatusField.OilSlicked;



            Ability ability1 = new Ability("MimicSmackdown_A");
            ability1.Name = "Smackdown";
            ability1.Description = "Deals a Mortal amount of damage to the opposing party member. If hit, steal the Left and Right party members' item.";
            ability1.Rarity = Abil.Weight(10);
            ability1.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 12, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_OpponentSides, previousEffectCondition),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_11_15.ToString(), });
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Misc.ToString(), });
            ability1.Visuals = LoadedAssetsHandler.GetCharacter("Leviat_CH").rankedData[0].rankAbilities[1].ability.visuals;
            ability1.AnimationTarget = Targeting.Slot_Front;

            Ability ability = new Ability("MimicSouvenir_A");
            ability.Name = "Souvenir";
            ability.Description = "Move Left or Right three times. Steal the Opposing party member's item.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                   Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_Front),

            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), });
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Fandango_A").visuals;




            enemy.AddEnemyAbilities(new Ability[] { ability,ability1 ,Area1Mimic.MimicSticky });
            enemy.AddEnemy(false, false, false);






            Enemy enemy1 = new Enemy("Roadie", "Roadie_EN");
            enemy1.Health = 40;
            enemy1.HealthColor = Pigments.Red;
            enemy1.Size = 1;
            enemy1.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot), };
            enemy1.CombatSprite = ResourceLoader.LoadSprite("ChestIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy1.OverworldAliveSprite = ResourceLoader.LoadSprite("ChestOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy1.OverworldDeadSprite = ResourceLoader.LoadSprite("ChestCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy1.DamageSound = LoadedAssetsHandler.GetEnemy("Chordophone_EN").damageSound;
            enemy1.DeathSound = LoadedAssetsHandler.GetEnemy("Chordophone_EN").deathSound;

            enemy1.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Slippery, Passives.MultiAttack2 });
            enemy1.PrepareEnemyPrefab("assets/mimics/area2/area2mimic.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/mimics/area2/giblets_greyroadie.prefab").GetComponent<ParticleSystem>());
            enemy1.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraCurrencyEffect>(), 8, Targeting.Slot_SelfSlot) };


            Ability ability111 = new Ability("MimicShakedown_A");
            ability111.Name = "Shakedown";
            ability111.Description = "Deal a Painful amount damage to the Opposing party member. Steal 2 coins from the Left and Right party members.";
            ability111.Rarity = Abil.Weight(10);
            ability111.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_OpponentRight),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 2, Targeting.Slot_OpponentRight, previousEffectCondition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_OpponentLeft),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 2, Targeting.Slot_OpponentLeft, previousEffectCondition),

            };
            ability111.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Misc_Currency.ToString(), });
            ability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), });
            ability111.Visuals = LoadedAssetsHandler.GetCharacter("Leviat_CH").rankedData[0].rankAbilities[1].ability.visuals;
            ability111.AnimationTarget = Targeting.Slot_Front;


            Ability kability111 = new Ability("StreetPerformance_A");
            kability111.Name = "Street Performance";
            kability111.Description = "Move Left or Right 3 times. Steal 1 coin from the Opposing party member each time moved.";
            kability111.Rarity = Abil.Weight(10);
            kability111.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            kability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 1, Targeting.Slot_Front, previousEffectCondition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 1, Targeting.Slot_Front, previousEffectCondition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 1, Targeting.Slot_Front, previousEffectCondition),

            };
            kability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), });
            kability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc_Currency.ToString(), IntentType_GameIDs.Misc_Currency.ToString(), IntentType_GameIDs.Misc_Currency.ToString(), });
            kability111.AnimationTarget = Targeting.Slot_SelfSlot;
            kability111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Fandango_A").visuals;


            enemy1.AddEnemyAbilities(new Ability[] { ability111, kability111,Area1Mimic.MimicSticky });
            enemy1.AddEnemy(false, false, false);

        }
    }
}
