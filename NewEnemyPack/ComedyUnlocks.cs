using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using NewEnemyPack.Effectsa;
using Utility.SerializableCollection;

namespace NewEnemyPack
{
    internal class ComedyUnlocks
    {
        public static void Add()
        {

            Ability gunbility = new Ability("Rattle_A_0");
            gunbility.Name = "Rattle";
            gunbility.Description = "Deal 3 damage to the Opposing enemy 5 times.\n20% chance to deal 2 Indirect damage instead each time.";
            gunbility.AbilitySprite = ResourceLoader.LoadSprite("IntijarComedyUnlockMove");
            gunbility.Cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.Red };
            gunbility.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RattleDamageEffect>(), 3, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RattleDamageEffect>(), 3, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RattleDamageEffect>(), 3, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RattleDamageEffect>(), 3, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RattleDamageEffect>(), 3, Targeting.Slot_Front),

            };
            gunbility.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });
            

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS._extraAbility = gunbility.GenerateCharacterAbility();


            PerformEffect_Item hailstormunlock = new PerformEffect_Item();
            hailstormunlock.Item_ID = "FaultyMachineGun_SW";
            hailstormunlock.Name = "Faulty Machine Gun";
            hailstormunlock.Flavour = "\"The size of your gun doesn't matter.\"";
            hailstormunlock.Description = "Adds an extra ability to this party member \"Rattle\", a strong attack that may produce a lot of pigment.";
            hailstormunlock.IsShopItem = true;
            hailstormunlock.Icon = ResourceLoader.LoadSprite("IntijarComedyUnlock");
            hailstormunlock.ShopPrice = 6;
            hailstormunlock.DoesPopUpInfo = true;
            hailstormunlock.StartsLocked = true;
            hailstormunlock.IsEffectImmediate = false;
            hailstormunlock.TriggerOn = TriggerCalls.Count;
            hailstormunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS };
            hailstormunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(hailstormunlock.Item, new ItemModdedUnlockInfo(hailstormunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked1", null, 32, null), "EP_IntijarComedy_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_IntijarComedy_ACH", "FaultyMachineGun_SW");

            UnlockableModData hailstormcomedyunlockData = new UnlockableModData("IntijarComedy");
            hailstormcomedyunlockData.hasModdedAchievementUnlock = true;
            hailstormcomedyunlockData.moddedAchievementID = "EP_IntijarComedy_ACH";
            hailstormcomedyunlockData.hasItemUnlock = true;
            hailstormcomedyunlockData.items = new string[] { "FaultyMachineGun_SW" };

            ModdedAchievements hailstormcomedyach = new ModdedAchievements("Ahead of Yourself", "Witness Intijar attempt to perform Brainstorm with no rocks present.", ResourceLoader.LoadSprite("IntijarComedyAch", null, 32, null), "EP_IntijarComedy_ACH");
            hailstormcomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);

            Unlocks.AddUnlock_ByID(hailstormcomedyunlockData);

            CasterRandomCharacterTransformationEffect casterRandomCharacterTransformation = ScriptableObject.CreateInstance<CasterRandomCharacterTransformationEffect>();
            casterRandomCharacterTransformation._maintainMaxHealth = true;
            casterRandomCharacterTransformation._fullyHeal = false;

            PerformEffect_Item gizobeatunlock = new PerformEffect_Item();
            gizobeatunlock.Item_ID = "PotassiumNightcap_TW";
            gizobeatunlock.Name = "Potassium Nightcap";
            gizobeatunlock.Flavour = "\"No banana make you go insane.\"";
            gizobeatunlock.Description = "At the start of every turn Transform this party member, into a random other party member of the same level.\nMaintain max health.";
            gizobeatunlock.IsShopItem = false;
            gizobeatunlock.Icon = ResourceLoader.LoadSprite("PotassiumNightcap");
            gizobeatunlock.ShopPrice = 6;
            gizobeatunlock.DoesPopUpInfo = true;
            gizobeatunlock.StartsLocked = true;
            gizobeatunlock.IsEffectImmediate = false;
            gizobeatunlock.TriggerOn = TriggerCalls.OnTurnStart;
            gizobeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(casterRandomCharacterTransformation, 1, Targeting.Slot_SelfSlot),
  

            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(gizobeatunlock.Item, new ItemModdedUnlockInfo(gizobeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked17", null, 32, null), "EP_Gizo_Skinned_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Gizo_Skinned_ACH", "PotassiumNightcap_TW");

            UnlockableModData gizounlockData = new UnlockableModData("Skinned");
            gizounlockData.hasModdedAchievementUnlock = true;
            gizounlockData.moddedAchievementID = "EP_Gizo_Skinned_ACH";
            gizounlockData.hasItemUnlock = true;
            gizounlockData.items = new string[] { "PotassiumNightcap_TW" };

            SerializableDictionary<string, UnlockableModData> keyValues = new SerializableDictionary<string, UnlockableModData>
            {
                { "Skinned", gizounlockData }
            };

            EnemyDeathUnlockCheck gizoDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            gizoDeathUnlock.usesSimpleDeathData = false;
            gizoDeathUnlock.enemyID = "Gizo_EN";
            gizoDeathUnlock.specialDeathData = keyValues;

            ModdedAchievements gizoach = new ModdedAchievements("Mom says it's my turn", "Witness a Gizo skin a clothed Gizo.", ResourceLoader.LoadSprite("GizoComedyAch", null, 32, null), "EP_Gizo_Skinned_ACH");
            gizoach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);

            Unlocks.AddUnlock_EnemyDeath(gizoDeathUnlock);

            StatusEffect_Apply_Effect statusEffect_Apply = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply._Status = StatusField.Focused;

            Ability focusability = new Ability("KnightsFocus_A_0");
            focusability.Name = "Knight's Focus";
            focusability.Description = "Gain Focus";
            focusability.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility1");
            focusability.Cost = new ManaColorSO[] { };
            focusability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(statusEffect_Apply, 1, Targeting.Slot_SelfSlot),
                

            };
            focusability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Focused.ToString() });
            focusability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Resolve_1_A").visuals;
            focusability.AnimationTarget = Targeting.Slot_SelfSlot;

            ExtraAbilityInfo extraAbilityInfofocus = new ExtraAbilityInfo();
            extraAbilityInfofocus.cost = new ManaColorSO[] { Pigments.Purple, Pigments.Purple, Pigments.Grey };
            extraAbilityInfofocus.ability = focusability.ability;

            Ability lanceability = new Ability("KnightLance_A_0");
            lanceability.Name = "Speedy Lance";
            lanceability.Description = "Deal 6 damage to the Left and RIght enemy.";
            lanceability.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility2");
            lanceability.Cost = new ManaColorSO[] { };
            lanceability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_OpponentSides),


            };
            lanceability.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            lanceability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
            lanceability.AnimationTarget = Targeting.Slot_OpponentSides;

            ExtraAbilityInfo extraAbilityInfolance = new ExtraAbilityInfo();
            extraAbilityInfolance.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            extraAbilityInfolance.ability = lanceability.ability;

            Ability lanceability1 = new Ability("KnightLance_A_1");
            lanceability1.Name = "Steadfast Lance";
            lanceability1.Description = "Deal 8 damage to the Left and RIght enemy.";
            lanceability1.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility2");
            lanceability1.Cost = new ManaColorSO[] { };
            lanceability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Targeting.Slot_OpponentSides),


            };
            lanceability1.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            lanceability1.Visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
            lanceability1.AnimationTarget = Targeting.Slot_OpponentSides;

            ExtraAbilityInfo extraAbilityInfolance1 = new ExtraAbilityInfo();
            extraAbilityInfolance1.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            extraAbilityInfolance1.ability = lanceability1.ability;

            Ability lanceability11 = new Ability("KnightLance_A_2");
            lanceability11.Name = "Brave Lance";
            lanceability11.Description = "Deal 10 damage to the Left and RIght enemy.";
            lanceability11.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility2");
            lanceability11.Cost = new ManaColorSO[] { };
            lanceability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Targeting.Slot_OpponentSides),


            };
            lanceability11.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            lanceability11.Visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
            lanceability11.AnimationTarget = Targeting.Slot_OpponentSides;

            ExtraAbilityInfo extraAbilityInfolance11 = new ExtraAbilityInfo();
            extraAbilityInfolance11.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            extraAbilityInfolance11.ability = lanceability11.ability;

            Ability lanceability111 = new Ability("KnightLance_A_3");
            lanceability111.Name = "Holy Lance";
            lanceability111.Description = "Deal 12 damage to the Left and RIght enemy.";
            lanceability111.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility2");
            lanceability111.Cost = new ManaColorSO[] { };
            lanceability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 12, Targeting.Slot_OpponentSides),


            };
            lanceability111.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_11_15.ToString() });
            lanceability111.Visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
            lanceability111.AnimationTarget = Targeting.Slot_OpponentSides;

            ExtraAbilityInfo extraAbilityInfolance111 = new ExtraAbilityInfo();
            extraAbilityInfolance111.cost = new ManaColorSO[] { Pigments.Red, Pigments.Red, Pigments.SplitPigment(Pigments.Red, Pigments.Yellow) };
            extraAbilityInfolance111.ability = lanceability111.ability;

            FieldEffectWeakest_Apply_Effect effectWeakest_Apply_Effect = ScriptableObject.CreateInstance<FieldEffectWeakest_Apply_Effect>();
            effectWeakest_Apply_Effect._Field = StatusField.Shield;

            Ability shieldability = new Ability("KnightsChivalry_A_0");
            shieldability.Name = "Fading Chivalry";
            shieldability.Description = "Apply 5 Shield to the lowest health party member(s).";
            shieldability.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility3");
            shieldability.Cost = new ManaColorSO[] { };
            shieldability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(effectWeakest_Apply_Effect, 5, Targeting.Unit_AllAllies),


            };
            shieldability.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            shieldability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Smokescreen_1_A").visuals;
            shieldability.AnimationTarget = Targeting.Slot_SelfSlot;

            ExtraAbilityInfo extraAbilityInfoshield = new ExtraAbilityInfo();
            extraAbilityInfoshield.cost = new ManaColorSO[] { Pigments.Blue };
            extraAbilityInfoshield.ability = shieldability.ability;


            Ability shieldability1 = new Ability("KnightsChivalry_A_1");
            shieldability1.Name = "Squire's Chivalry";
            shieldability1.Description = "Apply 7 Shield to the lowest health party member(s).";
            shieldability1.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility3");
            shieldability1.Cost = new ManaColorSO[] { };
            shieldability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(effectWeakest_Apply_Effect, 7, Targeting.Unit_AllAllies),


            };
            shieldability1.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            shieldability1.Visuals = LoadedAssetsHandler.GetCharacterAbility("Smokescreen_1_A").visuals;
            shieldability1.AnimationTarget = Targeting.Slot_SelfSlot;

            ExtraAbilityInfo extraAbilityInfoshield1 = new ExtraAbilityInfo();
            extraAbilityInfoshield1.cost = new ManaColorSO[] { Pigments.Blue };
            extraAbilityInfoshield1.ability = shieldability1.ability;

            Ability shieldability11 = new Ability("KnightsChivalry_A_2");
            shieldability11.Name = "Warrior's Chivalry";
            shieldability11.Description = "Apply 9 Shield to the lowest health party member(s).";
            shieldability11.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility3");
            shieldability11.Cost = new ManaColorSO[] { };
            shieldability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(effectWeakest_Apply_Effect, 9, Targeting.Unit_AllAllies),


            };
            shieldability11.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            shieldability11.Visuals = LoadedAssetsHandler.GetCharacterAbility("Smokescreen_1_A").visuals;
            shieldability11.AnimationTarget = Targeting.Slot_SelfSlot;

            ExtraAbilityInfo extraAbilityInfoshield11 = new ExtraAbilityInfo();
            extraAbilityInfoshield11.cost = new ManaColorSO[] { Pigments.Blue };
            extraAbilityInfoshield11.ability = shieldability11.ability;

            Ability shieldability111 = new Ability("KnightsChivalry_A_3");
            shieldability111.Name = "Hero's Chivalry";
            shieldability111.Description = "Apply 10 Shield to the lowest health party member(s).";
            shieldability111.AbilitySprite = ResourceLoader.LoadSprite("KnightAbility3");
            shieldability111.Cost = new ManaColorSO[] { };
            shieldability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(effectWeakest_Apply_Effect, 10, Targeting.Unit_AllAllies),


            };
            shieldability111.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            shieldability111.Visuals = LoadedAssetsHandler.GetCharacterAbility("Smokescreen_1_A").visuals;
            shieldability111.AnimationTarget = Targeting.Slot_SelfSlot;

            ExtraAbilityInfo extraAbilityInfoshield111 = new ExtraAbilityInfo();
            extraAbilityInfoshield111.cost = new ManaColorSO[] { Pigments.Blue };
            extraAbilityInfoshield111.ability = shieldability111.ability;

            SwapCasterAbilitiesDepenOnLevelEffect swapCasterAbilitiesDepenOnLevel = ScriptableObject.CreateInstance<SwapCasterAbilitiesDepenOnLevelEffect>();
            swapCasterAbilitiesDepenOnLevel._abilitiesToSwap = new ExtraAbilityInfo[] { extraAbilityInfofocus, extraAbilityInfolance, extraAbilityInfoshield };
            swapCasterAbilitiesDepenOnLevel._abilitiesToSwap1 = new ExtraAbilityInfo[] { extraAbilityInfofocus, extraAbilityInfolance1, extraAbilityInfoshield1 };
            swapCasterAbilitiesDepenOnLevel._abilitiesToSwap2 = new ExtraAbilityInfo[] { extraAbilityInfofocus, extraAbilityInfolance11, extraAbilityInfoshield11 };
            swapCasterAbilitiesDepenOnLevel._abilitiesToSwap3 = new ExtraAbilityInfo[] { extraAbilityInfofocus, extraAbilityInfolance111, extraAbilityInfoshield111 };

            PerformEffect_Item knightunlock = new PerformEffect_Item();
            knightunlock.Item_ID = "VanishedKnight_TW";
            knightunlock.Name = "Vanished Knight";
            knightunlock.Flavour = "\"Don't be yourself.\"";
            knightunlock.Description = "On combat start replace this party member's moveset with a generic offensive based one, that scales with level.";
            knightunlock.IsShopItem = false;
            knightunlock.Icon = ResourceLoader.LoadSprite("VanishedKnight");
            knightunlock.ShopPrice = 5;
            knightunlock.DoesPopUpInfo = true;
            knightunlock.StartsLocked = true;
            knightunlock.IsEffectImmediate = false;
            knightunlock.TriggerOn = TriggerCalls.OnCombatStart;
            knightunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(swapCasterAbilitiesDepenOnLevel, 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(knightunlock.Item, new ItemModdedUnlockInfo(knightunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked18", null, 32, null), "EP_UnicornComedy_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_UnicornComedy_ACH", "VanishedKnight_TW");

            UnlockableModData unicomedyunlockData = new UnlockableModData("UnicornComedy");
            unicomedyunlockData.hasModdedAchievementUnlock = true;
            unicomedyunlockData.moddedAchievementID = "EP_UnicornComedy_ACH";
            unicomedyunlockData.hasItemUnlock = true;
            unicomedyunlockData.items = new string[] { "VanishedKnight_TW" };

            ModdedAchievements unicomedyach = new ModdedAchievements("Six Feet Under", "Beat the Malformed Unicorn without damaging the Human Elemental.", ResourceLoader.LoadSprite("UniComedyAch", null, 32, null), "EP_UnicornComedy_ACH");
            unicomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);

            Unlocks.AddUnlock_ByID(unicomedyunlockData);




        }


    }
}
