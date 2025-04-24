using BrutalAPI;
using BrutalAPI.Items;
using MonoMod.RuntimeDetour;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class TragedyUnlocks
    {
        public static void Add()
        {
          

            IDetour EnemyUnlockDetour = (IDetour)new Hook((MethodBase)typeof(CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof(TragedyUnlocks).GetMethod("UseAbilityForSlap", ~BindingFlags.Default));

            PerformEffect_Item doulacomedyunlock = new PerformEffect_Item();
            doulacomedyunlock.Item_ID = "RubberGloves_SW";
            doulacomedyunlock.Name = "Rubber Gloves";
            doulacomedyunlock.Flavour = "\"The crunchiest slap there is.\"";
            doulacomedyunlock.Description = "Upon this party member performing Slap, refresh their movement and abilities.";
            doulacomedyunlock.IsShopItem =true;
            doulacomedyunlock.Icon = ResourceLoader.LoadSprite("RubberGloves");
            doulacomedyunlock.ShopPrice = 2;
            doulacomedyunlock.DoesPopUpInfo = false;
            doulacomedyunlock.StartsLocked = true;
            doulacomedyunlock.IsEffectImmediate = false;
            doulacomedyunlock.TriggerOn = TriggerCalls.Count;
            doulacomedyunlock.Effects = new EffectInfo[] {  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckIsPlayerTurnEffect>(), 1, Targeting.Slot_SelfSlot),};

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(doulacomedyunlock.Item, new ItemModdedUnlockInfo(doulacomedyunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked10", null, 32, null), "EP_Doula_Tragedy_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Doula_Tragedy_ACH", "RubberGloves_SW");

            UnlockableModData doulacomedyunlockData = new UnlockableModData("DoulaTragedy");
            doulacomedyunlockData.hasModdedAchievementUnlock = true;
            doulacomedyunlockData.moddedAchievementID = "EP_Doula_Tragedy_ACH";
            doulacomedyunlockData.hasItemUnlock = true;
            doulacomedyunlockData.items = new string[] { "RubberGloves_SW" };

            ModdedAchievements doulacomedyach = new ModdedAchievements("Animal Cruelty", "In an encounter with the Abstraction,\nLet the Doula grow to 10+ Multi-Attack", ResourceLoader.LoadSprite("DeerAch", null, 32, null), "EP_Doula_Tragedy_ACH");
            doulacomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.TragediesTitleLabel);

            Unlocks.AddUnlock_ByID(doulacomedyunlockData);

            

            Ability coinbility = new Ability("CoinGun_A_0");
            coinbility.Name = "Coin Gun";
            coinbility.Description = "Consumes 1 coin, if successful. Deals 3 damage to the opposing enemy, and Refreshes this party member's abilities.";
            coinbility.AbilitySprite = ResourceLoader.LoadSprite("CoinGunAbility");
            coinbility.Cost = new ManaColorSO[] { };
            coinbility.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,2)),

            };
            coinbility.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_Currency.ToString() });
            coinbility.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS._extraAbility = coinbility.GenerateCharacterAbility();

        
            PerformEffect_Item mimicunlock = new PerformEffect_Item();
            mimicunlock.Item_ID = "CoinGun_SW";
            mimicunlock.Name = "Coin Gun";
            mimicunlock.Flavour = "\"Videogame cliche.\"";
            mimicunlock.Description = "Add an extra ability to this party member, \"Coin gun\", a powerful endlessly repeatable attack that drains you of money.";
            mimicunlock.IsShopItem = true;
            mimicunlock.Icon = ResourceLoader.LoadSprite("CoinGun");
            mimicunlock.ShopPrice = 6;
            mimicunlock.DoesPopUpInfo = true;
            mimicunlock.StartsLocked = true;
            mimicunlock.IsEffectImmediate = false;
            mimicunlock.TriggerOn = TriggerCalls.Count;
            mimicunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS };
            mimicunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };
            
            ItemUtils.AddItemToShopStatsCategoryAndGamePool(mimicunlock.Item, new ItemModdedUnlockInfo(mimicunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked15", null, 32, null), "EP_Mimic_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Mimic_ACH", "CoinGun_SW");

            UnlockableModData mimiccomedyunlockData = new UnlockableModData("MimicTragedy");
            mimiccomedyunlockData.hasModdedAchievementUnlock = true;
            mimiccomedyunlockData.moddedAchievementID = "EP_Mimic_ACH";
            mimiccomedyunlockData.hasItemUnlock = true;
            mimiccomedyunlockData.items = new string[] { "CoinGun_SW" };

            ModdedAchievements mimiccomedyach = new ModdedAchievements("Whoops!", "Encounter a Sandbank or a Roadie.", ResourceLoader.LoadSprite("MimicAch", null, 32, null), "EP_Mimic_ACH");
            mimiccomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.TragediesTitleLabel);

            Unlocks.AddUnlock_ByID(mimiccomedyunlockData);

            StatusEffect_ApplyRestrictor_Effect statusEffect_ApplyRestrictor_ = ScriptableObject.CreateInstance<StatusEffect_ApplyRestrictor_Effect>();
            statusEffect_ApplyRestrictor_._Status = StatusField.Gutted;

            PerformEffect_Item squidunlock = new PerformEffect_Item();
            squidunlock.Item_ID = "RadiationJar_SW";
            squidunlock.Name = "Radiation Jar";
            squidunlock.Flavour = "\"I hope you weren't carrying this around in your pocket.\"";
            squidunlock.Description = "Apply permanent Gutted to this party member at the start of Combat.";
            squidunlock.IsShopItem = true;
            squidunlock.Icon = ResourceLoader.LoadSprite("RadiationJar");
            squidunlock.ShopPrice = 5;
            squidunlock.DoesPopUpInfo = true;
            squidunlock.StartsLocked = true;
            squidunlock.IsEffectImmediate = false;
            squidunlock.TriggerOn = TriggerCalls.OnCombatStart;
            squidunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(statusEffect_ApplyRestrictor_, 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(squidunlock.Item, new ItemModdedUnlockInfo(squidunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked19", null, 32, null), "EP_SquidTragedy_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_SquidTragedy_ACH", "RadiationJar_SW");

            UnlockableModData squidcomedyunlockData = new UnlockableModData("SquidTragedy");
            squidcomedyunlockData.hasModdedAchievementUnlock = true;
            squidcomedyunlockData.moddedAchievementID = "EP_SquidTragedy_ACH";
            squidcomedyunlockData.hasItemUnlock = true;
            squidcomedyunlockData.items = new string[] { "RadiationJar_SW" };

            ModdedAchievements squidcomedyach = new ModdedAchievements("Punchline", "Witness the Depression Squid.", ResourceLoader.LoadSprite("PunchlineAch", null, 32, null), "EP_SquidTragedy_ACH");
            squidcomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.TragediesTitleLabel);

            Unlocks.AddUnlock_ByID(squidcomedyunlockData);


            PercentageEffectorCondition percentageEffector = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            percentageEffector.triggerPercentage = 20;

            PercentageEffectorCondition percentageEffector1 = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            percentageEffector1.triggerPercentage = 70;

            CurrencyMultiplierChange_Wearable_SMS currencyMultiplierChange_Wearable_ = ScriptableObject.CreateInstance<CurrencyMultiplierChange_Wearable_SMS>();
            currencyMultiplierChange_Wearable_._currencyMultiplier = 2;

            PerformEffect_Item snakeoilunlock = new PerformEffect_Item();
            snakeoilunlock.Item_ID = "SnakeOil_SW";
            snakeoilunlock.Name = "Snake Oil";
            snakeoilunlock.Flavour = "\"A hundred percent proven to cure the cold. And rabies. And cancer. Also makes you immortal.\"";
            snakeoilunlock.Description = "70% chance to lose 1 coin at the start of each turn.\nGain 2x more money at the end of combat.\n20% chance to be destroyed at the end of combat.";
            snakeoilunlock.IsShopItem = true;
            snakeoilunlock.Icon = ResourceLoader.LoadSprite("SnakeOil");
            snakeoilunlock.ShopPrice = 5;
            snakeoilunlock.DoesPopUpInfo = true;
            snakeoilunlock.StartsLocked = true;
            snakeoilunlock.IsEffectImmediate = false;
            snakeoilunlock.TriggerOn = TriggerCalls.OnTurnStart;
            snakeoilunlock.ConsumeOnTrigger = TriggerCalls.OnCombatEnd;
            snakeoilunlock.ConsumeConditions = new EffectorConditionSO[] { percentageEffector };
            snakeoilunlock.Conditions = new EffectorConditionSO[] { percentageEffector1 };
            snakeoilunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { currencyMultiplierChange_Wearable_ };
            snakeoilunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(snakeoilunlock.Item, new ItemModdedUnlockInfo(snakeoilunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked12", null, 32, null), "EP_SachielTragedy_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_SachielTragedy_ACH", "SnakeOil_SW");

            UnlockableModData sachielcomedyunlockData = new UnlockableModData("SachielTragedy");
            sachielcomedyunlockData.hasModdedAchievementUnlock = true;
            sachielcomedyunlockData.moddedAchievementID = "EP_SachielTragedy_ACH";
            sachielcomedyunlockData.hasItemUnlock = true;
            sachielcomedyunlockData.items = new string[] { "SnakeOil_SW" };

            ModdedAchievements sachielcomedyach = new ModdedAchievements("Deal Gone Wrong", "Witness a mysterious stranger attempt to Fool-nap one of your fools.", ResourceLoader.LoadSprite("StolenAch", null, 32, null), "EP_SachielTragedy_ACH");
            sachielcomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.TragediesTitleLabel);

            Unlocks.AddUnlock_ByID(sachielcomedyunlockData);




            UnitTypePercMod unitTypePercMod = new UnitTypePercMod();
            unitTypePercMod.percentageToModify = 100;
            unitTypePercMod.doesIncrease = true;
            unitTypePercMod.unitType = "AmphibianID";

            //DamageDealtPercentageModifierByUnitType_Item

            DamageDealtPercentageModifierByUnitType_Item goblinunlock = new DamageDealtPercentageModifierByUnitType_Item();
            goblinunlock.Item_ID = "EffigyofaBastard_TW";
            goblinunlock.Name = "Effigy of a Bastard";
            goblinunlock.Flavour = "\"Never again...\"";
            goblinunlock.Description = "This party member now deals 15% more damage to enemies.\nThis party member now deals 100% more damage if the attacked enemy is an amphibian.";
            goblinunlock.IsShopItem = false;
            goblinunlock.Icon = ResourceLoader.LoadSprite("GoblinUnlock");
            goblinunlock.ShopPrice = 6;
            goblinunlock.DoesPopUpInfo = true;
            goblinunlock.StartsLocked = true;
            goblinunlock.TriggerOn = TriggerCalls.OnWillApplyDamage;
            goblinunlock.DefaultDoesIncreaseDamage = true;
            goblinunlock.DefaultPercentageToModify = 15;
            goblinunlock.UnitTypeData = new UnitTypePercMod[] { unitTypePercMod };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(goblinunlock.Item, new ItemModdedUnlockInfo(goblinunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked5", null, 32, null), "EP_Goblin_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Goblin_ACH", "EffigyofaBastard_TW");

            UnlockableModData goblincomedyunlockData = new UnlockableModData("GoblinTragedy");
            goblincomedyunlockData.hasModdedAchievementUnlock = true;
            goblincomedyunlockData.moddedAchievementID = "EP_Goblin_ACH";
            goblincomedyunlockData.hasItemUnlock = true;
            goblincomedyunlockData.items = new string[] { "EffigyofaBastard_TW" };

            ModdedAchievements goblincomedyach = new ModdedAchievements("Punk'd", "Become a victim to a horrible joke.", ResourceLoader.LoadSprite("GoblinAch", null, 32, null), "EP_Goblin_ACH");
            goblincomedyach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.TragediesTitleLabel);

            

            Unlocks.AddUnlock_ByID(goblincomedyunlockData);


        }

        public static void UseAbilityForSlap(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            orig(self, abilityID, filledCost);
            AbilitySO ability = self.CombatAbilities[abilityID].ability;
            if (LoadedAssetsHandler.LoadedWearables.Keys.Contains("RubberGloves_SW") && self.HasUsableItem && self.HeldItem == LoadedAssetsHandler.GetWearable("RubberGloves_SW"))
            {
                if (ability._abilityName == "Slap")
                {
                    CombatManager.Instance.AddUIAction(new ShowItemInformationUIAction(self.ID, "Rubber Gloves", false, ResourceLoader.LoadSprite("RubberGloves")));
                    EffectInfo[] effect = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, Targeting.Slot_SelfSlot) };



                    CombatManager.Instance.AddSubAction(new EffectAction(effect, self));


                }
            }
        }
    }

}

