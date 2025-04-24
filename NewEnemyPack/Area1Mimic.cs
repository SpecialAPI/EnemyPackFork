using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Area1Mimic
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

            Ability ability1 = new Ability("MimicSwipe_A");
            ability1.Name = "Swipe";
            ability1.Description = "Move this Enemy to the Left or Right.\nDeals a painful amount of damage to the opposing party member, if successful steal the opposing party member's item.";
            ability1.Rarity = Abil.Weight(10);
            ability1.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisuals, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_Front, previousEffectCondition),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc.ToString(), });

            ExtraAbilityInfo extraAbility = new ExtraAbilityInfo();
            extraAbility.ability = ability1.ability;
            extraAbility.rarity = Abil.Weight(0);
            extraAbility.cost = new ManaColorSO[] { Pigments.Yellow };

            ExtraLootEffect loot = ScriptableObject.CreateInstance<ExtraLootEffect>();
            loot._isTreasure = true;

            Enemy enemy = new Enemy("Yellow Sandbank", "YellowSandbank_EN");
            enemy.Health = 30;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot), };
            enemy.CombatSprite = ResourceLoader.LoadSprite("YChestIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("YChestOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("YChestCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.BonusAttackGenerator(extraAbility) });
            enemy.PrepareEnemyPrefab("assets/mimics/area1/yellowarea1mimic.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/mimics/area1/giblets_goldsandbank.prefab").GetComponent<ParticleSystem>());
            enemy.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(loot, 1, Targeting.Slot_SelfSlot) };

            StatusEffect_Apply_Effect statusEffect_Apply = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply._RandomBetweenPrevious = true;
            statusEffect_Apply._Status = StatusField.OilSlicked;

            Ability ability = new Ability("MimicInk_A");
            ability.Name = "Ink";
            ability.Description = "Inflict 1-2 Oil-Slicked to the Opposing party member.\nDeal a Painful amount of damage to the Opposing party member.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(statusEffect_Apply, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front),

            };            
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_OilSlicked.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;


            Ability zability111 = new Ability("MimicSticky_A");
            zability111.Name = "Sticky";
            zability111.Description = "Deal a Painful amount of damage to the Left and Right party member. If Successful steal 1 Coin.";
            zability111.Rarity = Abil.Weight(8);
            zability111.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            zability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentRight),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(),1, Targeting.Slot_OpponentRight, previousEffectCondition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentLeft),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(),1, Targeting.Slot_OpponentLeft, previousEffectCondition),

            };
            zability111.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc_Currency.ToString(), });
           




            enemy.AddEnemyAbilities(new Ability[] { ability, zability111 });
            enemy.AddEnemy(false, false, false);


            Ability ability111 = new Ability("MimicSnag_A");
            ability111.Name = "Snag";
            ability111.Description = "Move this Enemy to the Left or Right.\nDeals a painful amount of damage to the opposing party member, if successful steal 5 coins.";
            ability111.Rarity = Abil.Weight(10);
            ability111.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisuals, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 5, Targeting.Slot_Front, previousEffectCondition),

            };
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), });
            ability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc_Currency.ToString(), });

            ExtraAbilityInfo extraAbility1 = new ExtraAbilityInfo();
            extraAbility1.ability = ability111.GenerateEnemyAbility().ability;
            extraAbility1.rarity = Abil.Weight(0);
            extraAbility1.cost = new ManaColorSO[] { Pigments.Yellow };
        


            Enemy enemy1 = new Enemy("Sandbank", "Sandbank_EN");
            enemy1.Health = 30;
            enemy1.HealthColor = Pigments.Red;
            enemy1.Size = 1;
            enemy1.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot), };
            enemy1.CombatSprite = ResourceLoader.LoadSprite("ChestIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy1.OverworldAliveSprite = ResourceLoader.LoadSprite("ChestOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy1.OverworldDeadSprite = ResourceLoader.LoadSprite("ChestCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy1.DamageSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            enemy1.DeathSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").deathSound;

            enemy1.AddPassives(new BasePassiveAbilitySO[] { Passives.BonusAttackGenerator(extraAbility1) });
            enemy1.PrepareEnemyPrefab("assets/mimics/area1/greyarea1mimic.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/mimics/area1/giblets_greysandbank.prefab").GetComponent<ParticleSystem>());
            enemy1.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraCurrencyEffect>(), 6, Targeting.Slot_SelfSlot) };



            enemy1.AddEnemyAbilities(new Ability[] { ability, zability111 });
            enemy1.AddEnemy(false, false, false);

            MimicSticky = zability111;


        }
        public static BrutalAPI.Ability MimicSticky;
    }
}
