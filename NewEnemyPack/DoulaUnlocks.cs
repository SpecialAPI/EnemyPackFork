using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using NewEnemyPack.Effectsa;
using PercentHealMod_PerformEffect_Item = NewEnemyPack.Effectsa.PercentHealMod_PerformEffect_Item;

namespace NewEnemyPack
{
    internal class DoulaUnlocks
    {
        public static void Add()
        {

             

            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Attacks/PanHit";
            attackVisualsSO.isAnimationFullScreen = false;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Mods_Ability/Pan.anim");

            AttackVisualsSO attackVisualsSO1 = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO1.audioReference = "event:/Attacks/PanCrit";
            attackVisualsSO1.isAnimationFullScreen = false;
            attackVisualsSO1.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Mods_Ability/CritPan.anim");

            AnimationVisualsEffect animationVisualsEffect = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisualsEffect._animationTarget = Targeting.Slot_Front;
            animationVisualsEffect._visuals = attackVisualsSO;

            AnimationVisualsEffect animationVisualsEffect1 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisualsEffect1._animationTarget = Targeting.Slot_Front;
            animationVisualsEffect1._visuals = attackVisualsSO1;

            Ability boyleability = new Ability("MeleeSwing_A_0");
            boyleability.Name = "Melee Swing";
            boyleability.Description = "Deal 5 Damage to the Opposing enemy.\nSmall chance to Randomly crit and deal 20 Damage instead.";
            boyleability.AbilitySprite = ResourceLoader.LoadSprite("BoyleItemMove");
            boyleability.Cost = new ManaColorSO[] { Pigments.Red, Pigments.Yellow };
            boyleability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(85)),
                  Effects.GenerateEffect(animationVisualsEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true, 1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true, 2)),
                  Effects.GenerateEffect(animationVisualsEffect1, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(false, 3)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 20, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(false, 4))

            };
            boyleability.AddIntentsToTarget(Targeting.Slot_Front, new string[] {IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Damage_16_20.ToString(), });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS._extraAbility = boyleability.GenerateCharacterAbility();


            PerformEffect_Item boyleunlock = new PerformEffect_Item();
            boyleunlock.Item_ID = "FryingPan_SW";
            boyleunlock.Name = "Frying Pan";
            boyleunlock.Flavour = "\"Fair and Balanced.\"";
            boyleunlock.Description = "Adds an additional ability to this party member \"Melee Swing\" a weak attack that has a chance to deal large damage.";
            boyleunlock.IsShopItem = true;
            boyleunlock.Icon = ResourceLoader.LoadSprite("BoyleItem");
            boyleunlock.ShopPrice = 6;
            boyleunlock.DoesPopUpInfo = true;
            boyleunlock.StartsLocked = true;
            boyleunlock.IsEffectImmediate = false;
            boyleunlock.TriggerOn = TriggerCalls.Count;
            boyleunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS };
            boyleunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.AddItemToShopStatsCategoryAndGamePool(boyleunlock.Item, new ItemModdedUnlockInfo(boyleunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked1", null, 32, null), "EP_Boyle_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Boyle_Abstraction_ACH", "FryingPan_SW");

            ModdedAchievements boylemoddedAchievements = new ModdedAchievements("Frying Pan", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch1", null, 32, null), "EP_Boyle_Abstraction_ACH");
            boylemoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_BoyleDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_BoyleDoulaFinalBoss.AddUnlockData("Boyle", Unlocks.GenerateUnlockData("EP_Boyle_Abstraction_Unlock", "EP_Boyle_Abstraction_ACH", "", "", new string[] { "FryingPan_SW" }));

            LoadedAssetsHandler.GetCharacter("Boyle_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Boyle_Abstraction_ACH"));

            MaxHealthChange_Wearable_SMS maxHealthChange_Wearable_SMS = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            maxHealthChange_Wearable_SMS.isChangePercentage = true;
            maxHealthChange_Wearable_SMS.maxHealthChange = -50;

            AbilitiesUsageChange_Wearable_SMS abilitiesUsageChange_Wearable_SMS = ScriptableObject.CreateInstance<AbilitiesUsageChange_Wearable_SMS>();
            abilitiesUsageChange_Wearable_SMS._usesBasicAbility = false;
            abilitiesUsageChange_Wearable_SMS._usesAllAbilities = true;

            CopyCasterAndSpawnCharacterAnywhereEffect copyCasterAndSpawn = ScriptableObject.CreateInstance<CopyCasterAndSpawnCharacterAnywhereEffect>();
            copyCasterAndSpawn._extraModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_SMS, abilitiesUsageChange_Wearable_SMS };
            copyCasterAndSpawn._maximizeHealth = false;
            copyCasterAndSpawn._permanentSpawn = false;
            copyCasterAndSpawn._rankIsAdditive = true;
            copyCasterAndSpawn._rank = 0;
            copyCasterAndSpawn._nameAddition = NameAdditionLocID.NameAdditionNot;


            PerformEffect_Item fennecunlock = new PerformEffect_Item();
            fennecunlock.Item_ID = "CagedBeast_TW";
            fennecunlock.Name = "Caged Beast";
            fennecunlock.Flavour = "\"The Lizard Brain.\"";
            fennecunlock.Description = "On combat start, spawn a clone of this party member. The clone has this party member's missing ability instead of Slap.\nThis party member and the clone has 50% less max health than usual.";
            fennecunlock.IsShopItem = false;
            fennecunlock.Icon = ResourceLoader.LoadSprite("FennecItem");
            fennecunlock.ShopPrice = 8;
            fennecunlock.DoesPopUpInfo = true;
            fennecunlock.StartsLocked = true;
            fennecunlock.IsEffectImmediate = false;
            fennecunlock.TriggerOn = TriggerCalls.OnCombatStart;
            fennecunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_SMS };

            fennecunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(copyCasterAndSpawn, 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(fennecunlock.Item, new ItemModdedUnlockInfo(fennecunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked4", null, 32, null), "EP_Fennec_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Fennec_Abstraction_ACH", "CagedBeast_TW");

            ModdedAchievements fennecmoddedAchievements = new ModdedAchievements("Caged Beast", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch4", null, 32, null), "EP_Fennec_Abstraction_ACH");
            fennecmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_FennecDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_FennecDoulaFinalBoss.AddUnlockData("Fennec", Unlocks.GenerateUnlockData("EP_Fennec_Abstraction_Unlock", "EP_Fennec_Abstraction_ACH", "", "", new string[] { "CagedBeast_TW" }));

            LoadedAssetsHandler.GetCharacter("Fennec_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Fennec_Abstraction_ACH"));

            CopyAndSpawnCustomCharacterAnywhereEffect copyAndSpawnCustomCharacterAnywhereEffect = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            copyAndSpawnCustomCharacterAnywhereEffect._characterCopy = "MiniMordrake_CH";
            copyAndSpawnCustomCharacterAnywhereEffect._permanentSpawn = false;
            copyAndSpawnCustomCharacterAnywhereEffect._rank = 0;
            copyAndSpawnCustomCharacterAnywhereEffect._nameAddition = NameAdditionLocID.NameAdditionNone;
            copyAndSpawnCustomCharacterAnywhereEffect._usePreviousAsHealth = false;
            copyAndSpawnCustomCharacterAnywhereEffect._extraModifiers = new WearableStaticModifierSetterSO[0];

            PerformEffect_Item mordyunlock = new PerformEffect_Item();
            mordyunlock.Item_ID = "Clonion_TW";
            mordyunlock.Name = "Clonion";
            mordyunlock.Flavour = "\"Dandori.\"";
            mordyunlock.Description = "Upon killing an enemy, spawn a Mordrake clone.";
            mordyunlock.IsShopItem = false;
            mordyunlock.Icon = ResourceLoader.LoadSprite("MordrakeItem");
            mordyunlock.ShopPrice = 5;
            mordyunlock.DoesPopUpInfo = true;
            mordyunlock.StartsLocked = true;
            mordyunlock.IsEffectImmediate = false;
            mordyunlock.TriggerOn = TriggerCalls.OnKill;
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };

            mordyunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(copyAndSpawnCustomCharacterAnywhereEffect, 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(mordyunlock.Item, new ItemModdedUnlockInfo(mordyunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked23", null, 32, null), "EP_Mordrake_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Mordrake_Abstraction_ACH", "Clonion_TW");

            ModdedAchievements mordymoddedAchievements = new ModdedAchievements("Clonion", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch23", null, 32, null), "EP_Mordrake_Abstraction_ACH");
            mordymoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_MordyDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_MordyDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Mordrake_CH").entityID, Unlocks.GenerateUnlockData("EP_Mordrake_Abstraction_Unlock", "EP_Mordrake_Abstraction_ACH", "", "", new string[] { "Clonion_TW" }));

            LoadedAssetsHandler.GetCharacter("Mordrake_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Mordrake_Abstraction_ACH"));

            PercentageEffectorCondition percentageEffector = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            percentageEffector.triggerPercentage = 50;

            

            PerformEffect_Item griffinunlock = new PerformEffect_Item();
            griffinunlock.Item_ID = "DecapitatedRooster_TW";
            griffinunlock.Name = "Decapitated Rooster";
            griffinunlock.Flavour = "\"I do enjoy hurting other people.\"";
            griffinunlock.Description = "Upon killing an enemy, 50% chance to Refresh this party member's abilities and movement.";
            griffinunlock.IsShopItem = false;
            griffinunlock.Icon = ResourceLoader.LoadSprite("GriffinItem");
            griffinunlock.ShopPrice = 5;
            griffinunlock.DoesPopUpInfo = true;
            griffinunlock.StartsLocked = true;
            griffinunlock.IsEffectImmediate = false;
            griffinunlock.TriggerOn = TriggerCalls.OnKill;
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            griffinunlock.Conditions = new EffectorConditionSO[] { percentageEffector };

            griffinunlock.Effects = new EffectInfo[] { 
                
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, Targeting.Slot_SelfSlot)

            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(griffinunlock.Item, new ItemModdedUnlockInfo(griffinunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked9", null, 32, null), "EP_Griffin_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Griffin_Abstraction_ACH", "DecapitatedRooster_TW");

            ModdedAchievements griffinmoddedAchievements = new ModdedAchievements("Decapitated Rooster", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch9", null, 32, null), "EP_Griffin_Abstraction_ACH");
            griffinmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_GriffinDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_GriffinDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Griffin_CH").entityID, Unlocks.GenerateUnlockData("EP_Griffin_Abstraction_Unlock", "EP_Griffin_Abstraction_ACH", "", "", new string[] { "DecapitatedRooster_TW" }));

            LoadedAssetsHandler.GetCharacter("Griffin_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Griffin_Abstraction_ACH"));

            RankChange_Wearable_SMS morelvl = ScriptableObject.CreateInstance<RankChange_Wearable_SMS>();
            morelvl._rankAdditive = 1;

            MaxHealthChange_Wearable_SMS lesshp = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            lesshp.maxHealthChange = -5;


            BetterDamageAdditionModifier_Item spligunlock = new BetterDamageAdditionModifier_Item();
            spligunlock.Item_ID = "ArchaicMedicine_SW";
            spligunlock.Name = "Scalpel";
            spligunlock.Flavour = "\"You can call me doctor practice.\"";
            spligunlock.Description = "This party member's maximum health is decreased by 5 and deals 5 damage less than they would otherwise.\nThis party member is 1 level higher than they would be otherwise.";
            spligunlock.IsShopItem = true;
            spligunlock.Icon = ResourceLoader.LoadSprite("SpligItem");
            spligunlock.ShopPrice = 6;
            spligunlock.DoesPopUpInfo = true;
            spligunlock.StartsLocked = true;
            spligunlock.TriggerOn = TriggerCalls.OnWillApplyDamage;
            spligunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { morelvl, lesshp };
            //spligunlock.Conditions = new EffectorConditionSO[] { percentageEffector };
            spligunlock.AffectDamageDealtInsteadOfReceived = true;
            spligunlock.ToAdd = -5;

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(spligunlock.Item, new ItemModdedUnlockInfo(spligunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked6", null, 32, null), "EP_Splig_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Splig_Abstraction_ACH", "ArchaicMedicine_SW");

            ModdedAchievements spligmoddedAchievements = new ModdedAchievements("Scalpel", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch6", null, 32, null), "EP_Splig_Abstraction_ACH");
            spligmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_SpligDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_SpligDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Splig_CH").entityID, Unlocks.GenerateUnlockData("EP_Splig_Abstraction_Unlock", "EP_Splig_Abstraction_ACH", "", "", new string[] { "ArchaicMedicine_SW" }));

            LoadedAssetsHandler.GetCharacter("Splig_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Splig_Abstraction_ACH"));

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_ = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_._extraPassiveAbility = Passives.Dying;

            PercentHealMod_PerformEffect_Item agonunlock = new PercentHealMod_PerformEffect_Item();
            agonunlock.Item_ID = "CandleffLife_TW";
            agonunlock.Name = "Candle of Life";
            agonunlock.Flavour = "\"Slow and insidious killer.\"";
            agonunlock.Description = "This party member heals for 50% more than they otherwise would have.\nThis party member has Dying as a passive.";
            agonunlock.IsShopItem = true;
            agonunlock.Icon = ResourceLoader.LoadSprite("AgonItem");
            agonunlock.ShopPrice = 5;
            agonunlock.DoesPopUpInfo = false;
            agonunlock.StartsLocked = true;
            agonunlock.IncreaseHealing = true;
            agonunlock.percentToModify = 50;
            agonunlock.TriggerOn = TriggerCalls.OnWillApplyHeal;
            agonunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] {extraPassiveAbility_Wearable_ };
            //agonunlock.Conditions = new EffectorConditionSO[] { percentageEffector };

            agonunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot),


            };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(agonunlock.Item, new ItemModdedUnlockInfo(agonunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked17", null, 32, null), "EP_Agon_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Agon_Abstraction_ACH", "CandleffLife_TW");

            ModdedAchievements agonmoddedAchievements = new ModdedAchievements("Candle of Life", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch17", null, 32, null), "EP_Agon_Abstraction_ACH");
            agonmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_AgonDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_AgonDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Agon_CH").entityID, Unlocks.GenerateUnlockData("EP_Agon_Abstraction_Unlock", "EP_Agon_Abstraction_ACH", "", "", new string[] { "CandleffLife_TW" }));

            LoadedAssetsHandler.GetCharacter("Agon_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Agon_Abstraction_ACH"));



            PerformEffect_Item hansunlock = new PerformEffect_Item();
            hansunlock.Item_ID = "LightSwitch_TW";
            hansunlock.Name = "Light Switch";
            hansunlock.Flavour = "\"1/64.\"";
            hansunlock.Description = "On combat start, certain enemy types and factions will be swapped for an alternative but similar enemy faction.";
            hansunlock.IsShopItem = false;
            hansunlock.Icon = ResourceLoader.LoadSprite("HansItem");
            hansunlock.ShopPrice = 5;
            hansunlock.DoesPopUpInfo = true;
            hansunlock.StartsLocked = true;
            hansunlock.IsEffectImmediate = false;
            hansunlock.TriggerOn = TriggerCalls.OnCombatStart;
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            //agonunlock.Conditions = new EffectorConditionSO[] { percentageEffector };

            hansunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<EnemySpecificTransformationEffect>(), 1, Targeting.Unit_AllOpponents),


            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(hansunlock.Item, new ItemModdedUnlockInfo(hansunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked2", null, 32, null), "EP_Hans_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Hans_Abstraction_ACH", "LightSwitch_TW");

            ModdedAchievements hansmoddedAchievements = new ModdedAchievements("Light Switch", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch2", null, 32, null), "EP_Hans_Abstraction_ACH");
            hansmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_HansDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_HansDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Hans_CH").entityID, Unlocks.GenerateUnlockData("EP_Hans_Abstraction_Unlock", "EP_Hans_Abstraction_ACH", "", "", new string[] { "LightSwitch_TW" }));

            LoadedAssetsHandler.GetCharacter("Hans_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Hans_Abstraction_ACH"));


            CheckPassiveAbilityEffect checkPassiveAbilityEffect = ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>();
            checkPassiveAbilityEffect.m_PassiveID = Passives.ParasiteParasitism.m_PassiveID;

            CheckIsAliveEffect checkIsAliveEffect = ScriptableObject.CreateInstance<CheckIsAliveEffect>();
            checkIsAliveEffect._checkByHealth = true;

            StoredValueParasiteEffect storedValueParasiteEffect = ScriptableObject.CreateInstance<StoredValueParasiteEffect>();
            storedValueParasiteEffect._usePreviousExitValue = ((StoredValueParasiteEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[4].effect)._usePreviousExitValue;
            storedValueParasiteEffect._initialize = ((StoredValueParasiteEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[4].effect)._initialize;

            AddPassiveEffect addPassiveEffect1 = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addPassiveEffect1._passiveToAdd = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].effect)._passiveToAdd;

            CasterBoxingEffect casterBoxingEffect = ScriptableObject.CreateInstance<CasterBoxingEffect>();
            casterBoxingEffect._exitTypeID = ((CasterBoxingEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[6].effect)._exitTypeID;
            casterBoxingEffect._unboxHandler = ((CasterBoxingEffect)LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[6].effect)._unboxHandler;





            Ability leviatability = new Ability("Ascension_A_0");
            leviatability.Name = "Ascension";
            leviatability.Description = "This party member enters the opposing enemy. Adds an amount of Parasitism equal to this party member's current health to the Opposing enemy.";
            leviatability.AbilitySprite = ResourceLoader.LoadSprite("LeviatMove");
            leviatability.Cost = new ManaColorSO[] { Pigments.Blue, Pigments.Red, Pigments.Red };
            leviatability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[0].condition),
                  Effects.GenerateEffect(checkPassiveAbilityEffect, 1, Targeting.Slot_Front, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[1].condition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageByCostEffect>(), 1, Targeting.Slot_SelfSlot, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[2].condition),
                  Effects.GenerateEffect(checkIsAliveEffect, 1, Targeting.Slot_SelfSlot, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[3].condition),
                  Effects.GenerateEffect(storedValueParasiteEffect, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[4].entryVariable, Targeting.Slot_Front, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[4].condition),
                  Effects.GenerateEffect(addPassiveEffect1, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].entryVariable, Targeting.Slot_Front, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[5].condition),
                  Effects.GenerateEffect(casterBoxingEffect, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[6].entryVariable, Targeting.Slot_SelfSlot, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[6].condition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CasterChibiSpriteJumpEffect>(), LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[7].entryVariable, Targeting.Slot_Front, LoadedAssetsHandler.GetCharacterAbility("Eviscerate_1_A").effects[7].condition),

            };
            leviatability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS1 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS1._extraAbility = leviatability.GenerateCharacterAbility();


            PerformEffect_Item leviatunlock = new PerformEffect_Item();
            leviatunlock.Item_ID = "Transference_TW";
            leviatunlock.Name = "Transference";
            leviatunlock.Flavour = "\"Ascension through sensation.\"";
            leviatunlock.Description = "Gives this party member an additional ability that allows them to enter enemies.";
            leviatunlock.IsShopItem = false;
            leviatunlock.Icon = ResourceLoader.LoadSprite("LeviatItem");
            leviatunlock.ShopPrice = 6;
            leviatunlock.DoesPopUpInfo = true;
            leviatunlock.StartsLocked = true;
            leviatunlock.IsEffectImmediate = false;
            leviatunlock.TriggerOn = TriggerCalls.Count;
            leviatunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            leviatunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(leviatunlock.Item, new ItemModdedUnlockInfo(leviatunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked20", null, 32, null), "EP_Leviat_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Leviat_Abstraction_ACH", "Transference_TW");

            ModdedAchievements leviatmoddedAchievements = new ModdedAchievements("Transference", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch20", null, 32, null), "EP_Leviat_Abstraction_ACH");
            leviatmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_LeviatDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_LeviatDoulaFinalBoss.AddUnlockData("Leviat", Unlocks.GenerateUnlockData("EP_Leviat_Abstraction_Unlock", "EP_Leviat_Abstraction_ACH", "", "", new string[] { "Transference_TW" }));

            LoadedAssetsHandler.GetCharacter("Leviat_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Leviat_Abstraction_ACH"));








            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Stunned;

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.Stunned;
            statusEffect_Apply_1._JustOneRandomTarget = true;

            Ability smokeextrability = new Ability("SameRoutine_A_0");
            smokeextrability.Name = "Same Routine";
            smokeextrability.Description = "Cancel one of the Opposing enemy's moves.\nStun this party member.\n20% chance to stun another random party member as well.";
            smokeextrability.AbilitySprite = ResourceLoader.LoadSprite("SmokeStacksItemMove2");
            smokeextrability.Cost = new ManaColorSO[] { Pigments.Red, Pigments.Blue };
            smokeextrability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(statusEffect_Apply_1, 1, Targeting.Unit_OtherAllies, Effects.ChanceCondition(20)),

            };
            smokeextrability.AnimationTarget = Targeting.Slot_SelfSlot;
            smokeextrability.Visuals = LoadedAssetsHandler.GetEnemyAbility("CryOut_A").visuals;
            smokeextrability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), });
            smokeextrability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Stunned.ToString(), });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS3 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS3._extraAbility = smokeextrability.GenerateCharacterAbility();

            

            PerformEffect_Item smokeextraunlock = new PerformEffect_Item();
            smokeextraunlock.Item_ID = "BrokenRecord_EW";
            smokeextraunlock.Name = "Broken Record";
            smokeextraunlock.Flavour = "\"It's getting old.\"";
            smokeextraunlock.Description = "Adds an ability \"Same Routine\" a controllable(?) way to cancel enemy moves.";
            smokeextraunlock.IsShopItem = false;
            smokeextraunlock.Icon = ResourceLoader.LoadSprite("SmokeStacksItemExtra");
            smokeextraunlock.ShopPrice = 6;
            smokeextraunlock.DoesPopUpInfo = true;
            smokeextraunlock.StartsLocked = true;
            smokeextraunlock.IsEffectImmediate = false;
            smokeextraunlock.TriggerOn = TriggerCalls.Count;
            smokeextraunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS3 };
            smokeextraunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.JustAddItemSoItCanBeLoaded(smokeextraunlock.Item);


            ExtraLootOptionsEffect extraLootOptionsEffect = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            extraLootOptionsEffect._itemName = "BrokenRecord_EW";

            CasterAddOrRemoveExtraAbilityEffect casterAddOrRemoveExtraAbility = ScriptableObject.CreateInstance<CasterAddOrRemoveExtraAbilityEffect>();
            casterAddOrRemoveExtraAbility._removeExtraAbility = true;
          

            Ability smokebility = new Ability("RecordScratch_A_0");
            smokebility.Name = "Record Scratch";
            smokebility.Description = "Cancel one of the Opposing enemy's moves.\n50% chance to Refresh this party member.\n20% chance to scratch the record.";
            smokebility.AbilitySprite = ResourceLoader.LoadSprite("SmokeStacksItemMove1");
            smokebility.Cost = new ManaColorSO[] { Pigments.Blue, Pigments.Blue };
            smokebility.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(20)),
                  Effects.GenerateEffect(extraLootOptionsEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,1)),
                  Effects.GenerateEffect(casterAddOrRemoveExtraAbility, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,2)),
            };
            smokebility.AnimationTarget = Targeting.Slot_SelfSlot;
            smokebility.Visuals = LoadedAssetsHandler.GetEnemy("Chordophone_EN").abilities[0].ability.visuals;
            smokebility.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), });
            smokebility.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Refresh.ToString(), });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS2 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS2._extraAbility = smokebility.GenerateCharacterAbility();
            casterAddOrRemoveExtraAbility._extraAbility = extraAbility_Wearable_SMS2;

            PerformEffect_Item smokeunlock = new PerformEffect_Item();
            smokeunlock.Item_ID = "AbstruseRelic_SW";
            smokeunlock.Name = "Abstruse Relic";
            smokeunlock.Flavour = "\"Fair and Balanced.\"";
            smokeunlock.Description = "Adds an ability \"Record Scratch\" a controllable way to cancel enemy moves.";
            smokeunlock.IsShopItem = true;
            smokeunlock.Icon = ResourceLoader.LoadSprite("SmokeStacksItem");
            smokeunlock.ShopPrice = 7;
            smokeunlock.DoesPopUpInfo = true;
            smokeunlock.StartsLocked = true;
            smokeunlock.IsEffectImmediate = false;
            smokeunlock.TriggerOn = TriggerCalls.Count;
            smokeunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS2 };
            smokeunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.AddItemToShopStatsCategoryAndGamePool(smokeunlock.Item, new ItemModdedUnlockInfo(smokeunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked19", null, 32, null), "EP_SmokeStacks_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_SmokeStacks_Abstraction_ACH", "AbstruseRelic_SW");

            ModdedAchievements smokemoddedAchievements = new ModdedAchievements("Abstruse Relic", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch19", null, 32, null), "EP_SmokeStacks_Abstraction_ACH");
            smokemoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_SmokeDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_SmokeDoulaFinalBoss.AddUnlockData("SmokeStacks", Unlocks.GenerateUnlockData("EP_SmokeStacks_Abstraction_Unlock", "EP_SmokeStacks_Abstraction_ACH", "", "", new string[] { "AbstruseRelic_SW" }));

            LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").m_BossAchData.Add(new("DoulaBoss", "EP_SmokeStacks_Abstraction_ACH"));

            TargetStoredValueChangeEffect targetStoredValueChange = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            targetStoredValueChange._minimumValue = 0;
            targetStoredValueChange._valueName = "Exorcism";
            targetStoredValueChange._increase = true;

            DirectDeathIfStoredValueEffect directDeathIfStoredValueEffect = ScriptableObject.CreateInstance<DirectDeathIfStoredValueEffect>();
            directDeathIfStoredValueEffect._storedvalue = "Exorcism";

            UnitStoreData_ModIntSO dogfoodvalue = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            dogfoodvalue.m_Text = "Exorcism: {0}";
            dogfoodvalue._UnitStoreDataID = "Exorcism";
            dogfoodvalue.m_TextColor = new Color32(0, 152, 221, 255);
            dogfoodvalue.m_CompareDataToThis = 0;
            dogfoodvalue.m_ShowIfDataIsOver = true;
            LoadedDBsHandler.MiscDB.AddNewUnitStoreData("Exorcism", dogfoodvalue);

            Ability cranesability = new Ability("LenghtyExcommunication_A_0");
            cranesability.Name = "Lenghty Excommunication";
            cranesability.Description = "Increases the opposing enemy's \"Exorcism\" counter by 1.\nOnce the counter reaches how much maximum health the enemy has divided by 10, instantly kill it.";
            cranesability.AbilitySprite = ResourceLoader.LoadSprite("CranesItemMove");
            cranesability.Cost = new ManaColorSO[] { Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue), Pigments.Yellow };
            cranesability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(targetStoredValueChange, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(directDeathIfStoredValueEffect, 1, Targeting.Slot_Front),

            };
            cranesability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Damage_Death.ToString(), });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_SMS4 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_SMS4._extraAbility = cranesability.GenerateCharacterAbility();


            PerformEffect_Item cranesunlock = new PerformEffect_Item();
            cranesunlock.Item_ID = "DiscardedCross_TW";
            cranesunlock.Name = "Discarded Cross";
            cranesunlock.Flavour = "\"So be it.\"";
            cranesunlock.Description = "Adds an additional ability to this party member \"Lenghty Excommunication\" a slow but powerful ability.";
            cranesunlock.IsShopItem = false;
            cranesunlock.Icon = ResourceLoader.LoadSprite("CranesItem");
            cranesunlock.ShopPrice = 6;
            cranesunlock.DoesPopUpInfo = true;
            cranesunlock.StartsLocked = true;
            cranesunlock.IsEffectImmediate = false;
            cranesunlock.TriggerOn = TriggerCalls.Count;
            cranesunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS4 };
            cranesunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(cranesunlock.Item, new ItemModdedUnlockInfo(cranesunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked16", null, 32, null), "EP_Cranes_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Cranes_Abstraction_ACH", "DiscardedCross_TW");

            ModdedAchievements cranesmoddedAchievements = new ModdedAchievements("Discarded Cross", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch16", null, 32, null), "EP_Cranes_Abstraction_ACH");
            cranesmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_CranesDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_CranesDoulaFinalBoss.AddUnlockData("Cranes", Unlocks.GenerateUnlockData("EP_Cranes_Abstraction_Unlock", "EP_Cranes_Abstraction_ACH", "", "", new string[] { "DiscardedCross_TW" }));

            LoadedAssetsHandler.GetCharacter("Cranes_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Cranes_Abstraction_ACH"));




            PerformEffect_Item thypeunlock = new PerformEffect_Item();
            thypeunlock.Item_ID = "Person_EW";
            thypeunlock.Name = "Person";
            thypeunlock.Flavour = "\"These are all over the place.\"";
            thypeunlock.Description = "On combat start, produce 1 coin.\n10% chance to be consumed on use.";
            thypeunlock.IsShopItem = false;
            thypeunlock.Icon = ResourceLoader.LoadSprite("ThypeItem");
            thypeunlock.ShopPrice = 5;
            thypeunlock.DoesPopUpInfo = true;
            thypeunlock.StartsLocked = true;
            thypeunlock.IsEffectImmediate = false;
            thypeunlock.UsesSpecialUnlockText = true;
            thypeunlock.TriggerOn = TriggerCalls.OnCombatStart;
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            //agonunlock.Conditions = new EffectorConditionSO[] { percentageEffector };

            thypeunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraCurrencyEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChancePerEnemyCondition(10)),

            };
            ItemUtils.JustAddItemSoItCanBeLoaded(thypeunlock.Item);
            ItemUtils.AddItemFishingRodPool(thypeunlock.Item,15,true);
            ItemUtils.AddItemCanOfWormsPool(thypeunlock.Item, 15, true);
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Thype_Abstraction_ACH", "Person_EW");

            ModdedAchievements thypemoddedAchievements = new ModdedAchievements("Person", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch8", null, 32, null), "EP_Thype_Abstraction_ACH");
            thypemoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_ThypeDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_ThypeDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Thype_CH").entityID, Unlocks.GenerateUnlockData("EP_Thype_Abstraction_Unlock", "EP_Thype_Abstraction_ACH", "", "", new string[] { "Person_EW" }));

            LoadedAssetsHandler.GetCharacter("Thype_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Thype_Abstraction_ACH"));

            PercentageEffectorCondition percentageEffect = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            percentageEffect.triggerPercentage = 5;

            BetterDamageAdditionModifier_Item mungunlock = new BetterDamageAdditionModifier_Item();
            mungunlock.Item_ID = "CeramicArmor_EW";
            mungunlock.Name = "Ceramic Armor";
            mungunlock.Flavour = "\"Like tapping on the side of a porcelain cup.\"";
            mungunlock.Description = "Lowers all direct damage taken by 3.\n5% chance to be consumed on use.";
            mungunlock.IsShopItem = false;
            mungunlock.Icon = ResourceLoader.LoadSprite("MungItem");
            mungunlock.ShopPrice = 5;
            mungunlock.DoesPopUpInfo = true;
            mungunlock.StartsLocked = true;
            mungunlock.ConsumeOnUse = true;
            mungunlock.UsesSpecialUnlockText = true;
            mungunlock.TriggerOn = TriggerCalls.OnBeingDamaged;
            mungunlock.AffectDamageDealtInsteadOfReceived = false;
            mungunlock.ToAdd = -3;
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            //agonunlock.Conditions = new EffectorConditionSO[] { percentageEffector };
            mungunlock.ConsumeConditions = new EffectorConditionSO[] { percentageEffect };

            ItemUtils.JustAddItemSoItCanBeLoaded(mungunlock.Item);
            ItemUtils.AddItemFishingRodPool(mungunlock.Item, 4, true);
            ItemUtils.AddItemCanOfWormsPool(mungunlock.Item, 4, true);
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Mung_Abstraction_ACH", "CeramicArmor_EW");

            ModdedAchievements mungmoddedAchievements = new ModdedAchievements("Ceramic Armor", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch12", null, 32, null), "EP_Mung_Abstraction_ACH");
            mungmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_MungDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_MungDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Mung_CH").entityID, Unlocks.GenerateUnlockData("EP_Mung_Abstraction_Unlock", "EP_Mung_Abstraction_ACH", "", "", new string[] { "CeramicArmor_EW" }));

            LoadedAssetsHandler.GetCharacter("Mung_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Mung_Abstraction_ACH"));

            SpawnRandomEnemyAnywhereIfEmptyEffect spawnRandomEnemyAnywhereIfEmpty = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereIfEmptyEffect>();
            spawnRandomEnemyAnywhereIfEmpty._enemies = new List<EnemySO> { LoadedAssetsHandler.GetEnemy("ConductorEnemy_EN") };
            spawnRandomEnemyAnywhereIfEmpty._givesExperience = false;
            spawnRandomEnemyAnywhereIfEmpty._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            CasterStoredValueChangeEffect casterStoredValueChange = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChange.m_unitStoredDataID = "BleedingEarsValue";
            casterStoredValueChange._minimumValue = 0;
            casterStoredValueChange._increase = true;

            MainCharacter_Wearable_SMS mainCharacter_Wearable_SMS = ScriptableObject.CreateInstance<MainCharacter_Wearable_SMS>();

            PercentageEffectorCondition percentageEffectorCondition = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            percentageEffectorCondition.triggerPercentage = 1;

            PerformEffect_Item kleiverunlock = new PerformEffect_Item();
            kleiverunlock.Item_ID = "BleedingEars_TW";
            kleiverunlock.Name = "Bleeding Ears";
            kleiverunlock.Flavour = "\"Godly sigil.\"";
            kleiverunlock.Description = "This party member is now considered a \"Main Character\".";
            kleiverunlock.IsShopItem = false;
            kleiverunlock.Icon = ResourceLoader.LoadSprite("KleiverItem");
            kleiverunlock.ShopPrice = 5;
            kleiverunlock.DoesPopUpInfo = true;
            kleiverunlock.StartsLocked = true;
            kleiverunlock.TriggerOn = TriggerCalls.OnRoundFinished;
            kleiverunlock.Conditions = new EffectorConditionSO[]{ percentageEffectorCondition };
            kleiverunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { mainCharacter_Wearable_SMS };

            kleiverunlock.Effects= new EffectInfo[] { Effects.GenerateEffect(spawnRandomEnemyAnywhereIfEmpty, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(casterStoredValueChange, 4, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,1)) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(kleiverunlock.Item, new ItemModdedUnlockInfo(kleiverunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked15", null, 32, null), "EP_Kleiver_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Kleiver_Abstraction_ACH", "BleedingEars_TW");

            ModdedAchievements kleivermoddedAchievements = new ModdedAchievements("Bleeding Ears", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch15", null, 32, null), "EP_Kleiver_Abstraction_ACH");
            kleivermoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_KleiverDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_KleiverDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Kleiver_CH").entityID, Unlocks.GenerateUnlockData("EP_Kleiver_Abstraction_Unlock", "EP_Kleiver_Abstraction_ACH", "", "", new string[] { "BleedingEars_TW" }));

            LoadedAssetsHandler.GetCharacter("Kleiver_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Kleiver_Abstraction_ACH"));


            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._indirect = true;

            UnitStoreData_ModIntSO burnoutvalue = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            burnoutvalue.m_Text = "Your Fault: {0}";
            burnoutvalue._UnitStoreDataID = "FaultItem";
            burnoutvalue.m_TextColor = new Color32(0, 152, 221, 255);
            burnoutvalue.m_CompareDataToThis = 0;
            burnoutvalue.m_ShowIfDataIsOver = true;
            LoadedDBsHandler.MiscDB.AddNewUnitStoreData("FaultItem", burnoutvalue);

            CasterStoredValueChangeEffect casterStoredValueChange1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChange1.m_unitStoredDataID = "FaultItem";
            casterStoredValueChange1._minimumValue = 0;
            casterStoredValueChange1._increase = true;

            AdditionDamageModifierWithStoredValueSetterWearable_Item burnoutunlock = new AdditionDamageModifierWithStoredValueSetterWearable_Item();
            burnoutunlock.Item_ID = "YourFault_TW";
            burnoutunlock.Name = "Your Fault";
            burnoutunlock.Flavour = "\"That is not the sun rising.\"";
            burnoutunlock.Description = "Upon this party member performing an ability, deal 2 indirect damage to them and increase their attack damage by 1.";
            burnoutunlock.IsShopItem = false;
            burnoutunlock.Icon = ResourceLoader.LoadSprite("BurnoutItem");
            burnoutunlock.ShopPrice = 5;
            burnoutunlock.DoesPopUpInfo = true;
            burnoutunlock.StartsLocked = true;
            burnoutunlock.StoreValue = "FaultItem";
            burnoutunlock.ToAdd = 0;
            burnoutunlock.Usedealt = true;
            burnoutunlock.TriggerOn = TriggerCalls.OnWillApplyDamage;
            burnoutunlock.SecondaryDoesPopUpInfo = true;
            burnoutunlock.SecondaryTriggerOn = new TriggerCalls[] { TriggerCalls.OnAbilityUsed };
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };

            burnoutunlock.SecondaryEffects = new EffectInfo[] { Effects.GenerateEffect(damageEffect, 2, Targeting.Slot_SelfSlot), Effects.GenerateEffect(casterStoredValueChange1, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true, 1)) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(burnoutunlock.Item, new ItemModdedUnlockInfo(burnoutunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked3", null, 32, null), "EP_Burnout_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Burnout_Abstraction_ACH", "YourFault_TW");

            ModdedAchievements burnoutmoddedAchievements = new ModdedAchievements("Your Fault", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch3", null, 32, null), "EP_Burnout_Abstraction_ACH");
            burnoutmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_BurnoutDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_BurnoutDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Burnout_CH").entityID, Unlocks.GenerateUnlockData("EP_Burnout_Abstraction_Unlock", "EP_Burnout_Abstraction_ACH", "", "", new string[] { "YourFault_TW" }));

            LoadedAssetsHandler.GetCharacter("Burnout_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Burnout_Abstraction_ACH"));

            CasterStoreValueDependingOnturnAndHealSetterEffect healSetterEffect = ScriptableObject.CreateInstance<CasterStoreValueDependingOnturnAndHealSetterEffect>();
            healSetterEffect.m_unitStoredDataID = "JoyItem";

            AdditionDamageModifierWithStoredValueSetterWearable_Item antonunlock = new AdditionDamageModifierWithStoredValueSetterWearable_Item();
            antonunlock.Item_ID = "HappyPills_SW";
            antonunlock.Name = "Happy Pills";
            antonunlock.Flavour = "\"Down in your heart.\"";
            antonunlock.Description = "Every even turn, this party member deals 3 more Damage, and heals 3 health.\nEvery odd turn this party member deals 3 less damage.";
            antonunlock.IsShopItem = true;
            antonunlock.Icon = ResourceLoader.LoadSprite("AntonItem");
            antonunlock.ShopPrice = 7;
            antonunlock.DoesPopUpInfo = true;
            antonunlock.StartsLocked = true;
            antonunlock.StoreValue = "JoyItem";
            antonunlock.ToAdd = 0;
            antonunlock.Usedealt = true;
            antonunlock.TriggerOn = TriggerCalls.OnWillApplyDamage;
            antonunlock.SecondaryDoesPopUpInfo = false;
            antonunlock.SecondaryTriggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };
            //mordyunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { };

            antonunlock.SecondaryEffects = new EffectInfo[] { Effects.GenerateEffect(healSetterEffect, 3, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(antonunlock.Item, new ItemModdedUnlockInfo(antonunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked5", null, 32, null), "EP_Anton_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Anton_Abstraction_ACH", "HappyPills_SW");

            ModdedAchievements antonmoddedAchievements = new ModdedAchievements("Happy Pills", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch5", null, 32, null), "EP_Anton_Abstraction_ACH");
            antonmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_AntonDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_AntonDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Anton_CH").entityID, Unlocks.GenerateUnlockData("EP_Anton_Abstraction_Unlock", "EP_Anton_Abstraction_ACH", "", "", new string[] { "HappyPills_SW" }));

            LoadedAssetsHandler.GetCharacter("Anton_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Anton_Abstraction_ACH"));

            SpawnEnemyAnywhereEffect spawnEnemyAnywhere = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            spawnEnemyAnywhere.enemy = LoadedAssetsHandler.GetEnemy("Vermin_EN");
            spawnEnemyAnywhere.givesExperience = false;
            spawnEnemyAnywhere._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            PerformEffect_Item arnoldunlock = new PerformEffect_Item();
            arnoldunlock.Item_ID = "Vermin_TW";
            arnoldunlock.Name = "Vermin";
            arnoldunlock.Flavour = "\"They hide poorly.\"";
            arnoldunlock.Description = "On combat start attempt to spawn an annoying Vermin on the enemy side, upon killing said Vermin heal all party members 3 Health.";
            arnoldunlock.IsShopItem = false;
            arnoldunlock.Icon = ResourceLoader.LoadSprite("ArnoldItem");
            arnoldunlock.ShopPrice = 6;
            arnoldunlock.DoesPopUpInfo = true;
            arnoldunlock.StartsLocked = true;
            arnoldunlock.IsEffectImmediate = false;
            arnoldunlock.TriggerOn = TriggerCalls.OnCombatStart;
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            arnoldunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(spawnEnemyAnywhere, 1, Targeting.Slot_SelfSlot) };
            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(arnoldunlock.Item, new ItemModdedUnlockInfo(arnoldunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked10", null, 32, null), "EP_Arnold_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Arnold_Abstraction_ACH", "Vermin_TW");

            ModdedAchievements arnoldmoddedAchievements = new ModdedAchievements("Vermin", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch10", null, 32, null), "EP_Arnold_Abstraction_ACH");
            arnoldmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_ArnoldDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_ArnoldDoulaFinalBoss.AddUnlockData("Arnold", Unlocks.GenerateUnlockData("EP_Arnold_Abstraction_Unlock", "EP_Arnold_Abstraction_ACH", "", "", new string[] { "Vermin_TW" }));

            LoadedAssetsHandler.GetCharacter("Arnold_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Arnold_Abstraction_ACH"));



            ExtraLootListEffect extraLootList = ScriptableObject.CreateInstance<ExtraLootListEffect>();
            extraLootList._nothingPercentage = 0;
            extraLootList._shopPercentage = 1;
            extraLootList._treasurePercentage = 1;
            extraLootList._lootableItems = ((ExtraLootListEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("CanOfWorms_SW")).effects[0].effect)._lootableItems;
            extraLootList._lockedLootableItems = ((ExtraLootListEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("CanOfWorms_SW")).effects[0].effect)._lockedLootableItems;


            PerformEffectBloodyValve_Item liverunlock = new PerformEffectBloodyValve_Item();
            liverunlock.Item_ID = "BloodyValve_SW";
            liverunlock.Name = "Bloody Valve";
            liverunlock.Flavour = "\"This is a piece of garbage, and you're a piece of s&%$.\"";
            liverunlock.Description = "Lose the ability to see Enemy and Party member health.\nProduce 3-4 \"Fish\" on combat end.";
            liverunlock.IsShopItem = true;
            liverunlock.Icon = ResourceLoader.LoadSprite("LongLiverItem");
            liverunlock.ShopPrice = 4;
            liverunlock.DoesPopUpInfo = true;
            liverunlock.StartsLocked = true;
            liverunlock.IsEffectImmediate = false;
            liverunlock.TriggerOn = TriggerCalls.OnCombatEnd;
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            liverunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(extraLootList, 3, Targeting.Slot_SelfSlot), Effects.GenerateEffect(extraLootList, 1, Targeting.Slot_SelfSlot, Effects.ChancePerEnemyCondition(50)) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(liverunlock.Item, new ItemModdedUnlockInfo(liverunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked13", null, 32, null), "EP_LongLiver_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_LongLiver_Abstraction_ACH", "BloodyValve_SW");

            ModdedAchievements livermoddedAchievements = new ModdedAchievements("Bloody Valve", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch13", null, 32, null), "EP_LongLiver_Abstraction_ACH");
            livermoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_LiverDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_LiverDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("LongLiver_CH").entityID, Unlocks.GenerateUnlockData("EP_LongLiver_Abstraction_Unlock", "EP_LongLiver_Abstraction_ACH", "", "", new string[] { "BloodyValve_SW" }));

            LoadedAssetsHandler.GetCharacter("LongLiver_CH").m_BossAchData.Add(new("DoulaBoss", "EP_LongLiver_Abstraction_ACH"));

            MaxHealthChange_Wearable_SMS maxHealthChange_Wearable_SMS1 = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            maxHealthChange_Wearable_SMS1.isChangePercentage = true;
            maxHealthChange_Wearable_SMS1.maxHealthChange = -75;

            IncreaseOthersDamage_Item ragsextra3 = new IncreaseOthersDamage_Item();
            ragsextra3.Item_ID = "DemonDagger_EW";
            ragsextra3.Name = "Demon Dagger";
            ragsextra3.Flavour = "\"DISCARNATED\"";
            ragsextra3.Description = "Decrease this Party member's Max Health by 75%. Increase all party member's damage by 4.\nFull Potential.";
            ragsextra3.IsShopItem = false;
            ragsextra3.Icon = ResourceLoader.LoadSprite("RagsItemExtra3");
            ragsextra3.ShopPrice = 9;
            ragsextra3.DoesPopUpInfo = true;
            ragsextra3.StartsLocked = true;
            ragsextra3.damageincrease = 4;
            ragsextra3.IsEffectImmediate = false;
            ragsextra3.TriggerOn = TriggerCalls.OnCombatEnd;
            ragsextra3.EquippedModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_SMS1 };
            ragsextra3.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, Targeting.Slot_SelfSlot) };
            ItemUtils.JustAddItemSoItCanBeLoaded(ragsextra3.Item);

            ExtraLootOptionsEffect demondagger = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            demondagger._changeOption = true;
            demondagger._itemName = "DemonDagger_EW";

            IncreaseOthersDamage_Item ragsextra2 = new IncreaseOthersDamage_Item();
            ragsextra2.Item_ID = "GoldDagger_EW";
            ragsextra2.Name = "Gold Dagger";
            ragsextra2.Flavour = "\"EVISCERATED\"";
            ragsextra2.Description = "Decrease this Party member's Max Health by 75%. Increase all party member's damage by 3.\nAt the end of combat, Convert a future item into a better Dagger and consume this item.";
            ragsextra2.IsShopItem = false;
            ragsextra2.Icon = ResourceLoader.LoadSprite("RagsItemExtra2");
            ragsextra2.ShopPrice = 7;
            ragsextra2.damageincrease = 3;
            ragsextra2.DoesPopUpInfo = true;
            ragsextra2.StartsLocked = true;
            ragsextra2.IsEffectImmediate = false;
            ragsextra2.TriggerOn = TriggerCalls.OnCombatEnd;
            ragsextra2.EquippedModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_SMS1 };
            ragsextra2.Effects = new EffectInfo[] { Effects.GenerateEffect(demondagger, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.JustAddItemSoItCanBeLoaded(ragsextra2.Item);

            ExtraLootOptionsEffect golddagger = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            golddagger._changeOption = true;
            golddagger._itemName = "GoldDagger_EW";

            IncreaseOthersDamage_Item ragsextra1 = new IncreaseOthersDamage_Item();
            ragsextra1.Item_ID = "SilverDagger_EW";
            ragsextra1.Name = "Silver Dagger";
            ragsextra1.Flavour = "\"INTOXICATED\"";
            ragsextra1.Description = "Decrease this Party member's Max Health by 75%. Increase all party member's damage by 2.\nAt the end of combat, Convert a future item into a better Dagger and consume this item.";
            ragsextra1.IsShopItem = false;
            ragsextra1.Icon = ResourceLoader.LoadSprite("RagsItemExtra1");
            ragsextra1.ShopPrice = 4;
            ragsextra1.damageincrease = 2;
            ragsextra1.DoesPopUpInfo = true;
            ragsextra1.StartsLocked = true;
            ragsextra1.IsEffectImmediate = false;
            ragsextra1.TriggerOn = TriggerCalls.OnCombatEnd;
            ragsextra1.EquippedModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_SMS1 };
            ragsextra1.Effects = new EffectInfo[] { Effects.GenerateEffect(golddagger, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_SelfSlot) };
            ItemUtils.JustAddItemSoItCanBeLoaded(ragsextra1.Item);

            ExtraLootOptionsEffect silverdagger = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            silverdagger._changeOption = true;
            silverdagger._itemName = "SilverDagger_EW";


            IncreaseOthersDamage_Item ragsunlock = new IncreaseOthersDamage_Item();
            ragsunlock.Item_ID = "CopperDagger_TW";
            ragsunlock.Name = "Copper Dagger";
            ragsunlock.Flavour = "\"SWARMED\"";
            ragsunlock.damageincrease = 1;
            ragsunlock.Description = "Decrease this Party member's Max Health by 75%. Increase all party member's damage by 1.\nAt the end of combat, Convert a future item into a better Dagger and consume this item.";
            ragsunlock.IsShopItem = false;
            ragsunlock.Icon = ResourceLoader.LoadSprite("RagsItem");
            ragsunlock.ShopPrice = 2;
            ragsunlock.DoesPopUpInfo = true;
            ragsunlock.StartsLocked = true;
            ragsunlock.IsEffectImmediate = false;
            ragsunlock.TriggerOn = TriggerCalls.OnCombatEnd;
            ragsunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_SMS1 };
            ragsunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(silverdagger, 1, Targeting.Slot_SelfSlot), Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(ragsunlock.Item, new ItemModdedUnlockInfo(ragsunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked18", null, 32, null), "EP_Rags_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Rags_Abstraction_ACH", "CopperDagger_TW");

            ModdedAchievements ragsmoddedAchievements = new ModdedAchievements("Copper Dagger", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch18", null, 32, null), "EP_Rags_Abstraction_ACH");
            ragsmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_RagsDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_RagsDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Rags_CH").entityID, Unlocks.GenerateUnlockData("EP_Rags_Abstraction_Unlock", "EP_Rags_Abstraction_ACH", "", "", new string[] { "CopperDagger_TW" }));

            LoadedAssetsHandler.GetCharacter("Rags_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Rags_Abstraction_ACH"));

            DamageEffect damage = ScriptableObject.CreateInstance<DamageEffect>();
            damage._indirect = true;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.OnFire;
            fieldEffect_Apply_._UseRandomBetweenPrevious = true;

            PerformEffect_Item pearlextra1 = new PerformEffect_Item();
            pearlextra1.Item_ID = "Chloroform_EW";
            pearlextra1.Name = "Chloroform";
            pearlextra1.Flavour = "\"Napsack.\"";
            pearlextra1.Description = "On combat start, deal 3 Indirect damage to all enemies.\nInflict 0-1 fire on each enemy position.\nDestroy this item upon use.";
            pearlextra1.IsShopItem = false;
            pearlextra1.Icon = ResourceLoader.LoadSprite("PearlItemExtra1");
            pearlextra1.ShopPrice = 1;
            pearlextra1.DoesPopUpInfo = true;
            pearlextra1.StartsLocked = true;
            pearlextra1.IsEffectImmediate = false;
            pearlextra1.TriggerOn = TriggerCalls.OnCombatStart;
            pearlextra1.ConsumeOnUse = true;
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            pearlextra1.Effects = new EffectInfo[] { Effects.GenerateEffect(damage, 3, Targeting.Unit_AllOpponents), Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_OpponentAllSlots), Effects.GenerateEffect(fieldEffect_Apply_, 1, Targeting.Slot_OpponentAllSlots) };
            ItemUtils.JustAddItemSoItCanBeLoaded(pearlextra1.Item);

            PerformEffect_Item pearlextra11 = new PerformEffect_Item();
            pearlextra11.Item_ID = "GasGrenade_EW";
            pearlextra11.Name = "Gas Grenade";
            pearlextra11.Flavour = "\"A sober person would throw it.\"";
            pearlextra11.Description = "On combat start, deal 6 Indirect damage to all enemies.\nInflict 0-3 fire on each enemy position.\nDestroy this item upon use.";
            pearlextra11.IsShopItem = false;
            pearlextra11.Icon = ResourceLoader.LoadSprite("PearlItemExtra2");
            pearlextra11.ShopPrice = 1;
            pearlextra11.DoesPopUpInfo = true;
            pearlextra11.StartsLocked = true;
            pearlextra11.IsEffectImmediate = false;
            pearlextra11.ConsumeOnUse = true;
            pearlextra11.TriggerOn = TriggerCalls.OnCombatStart;
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            pearlextra11.Effects = new EffectInfo[] { Effects.GenerateEffect(damage, 6, Targeting.Unit_AllOpponents), Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_OpponentAllSlots), Effects.GenerateEffect(fieldEffect_Apply_, 3, Targeting.Slot_OpponentAllSlots) };
            ItemUtils.JustAddItemSoItCanBeLoaded(pearlextra11.Item);

            CheckBundleDifficultyEffectorCondition checkBundleDifficultyEffector = ScriptableObject.CreateInstance<CheckBundleDifficultyEffectorCondition>();
            checkBundleDifficultyEffector._isEqual = true;
            checkBundleDifficultyEffector._bundleDifficulty = BundleDifficulty.Boss;

            LootItemProbability lootItem = new LootItemProbability();
            lootItem.probability = 75;
            lootItem.itemName = "Chloroform_EW";

            LootItemProbability lootItem1 = new LootItemProbability();
            lootItem1.probability = 25;
            lootItem1.itemName = "GasGrenade_EW";

            ExtraLootListEffect extraLootListEffect = ScriptableObject.CreateInstance<ExtraLootListEffect>();
            extraLootListEffect._nothingPercentage = 0;
            extraLootListEffect._shopPercentage = 0;
            extraLootListEffect._treasurePercentage = 0;
            extraLootListEffect._lockedLootableItems = new List<LootItemProbability> { };
            extraLootListEffect._lootableItems = new List<LootItemProbability> { lootItem, lootItem1 };

            ChangeMaxHealthEffect changeMaxHealth = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealth._entryAsPercentage = true;
            changeMaxHealth._increase = true;

            PerformEffect_Item pearlunlock = new PerformEffect_Item();
            pearlunlock.Item_ID = "DeadCanary_SW";
            pearlunlock.Name = "Dead Canary";
            pearlunlock.Flavour = "\"Miserable.\"";
            pearlunlock.Description = "On combat start, increase the health of bosses by 25%.\nUpon defeating the boss, gain a number of unique helpful items..";
            pearlunlock.IsShopItem = true;
            pearlunlock.Icon = ResourceLoader.LoadSprite("PearlItem");
            pearlunlock.ShopPrice = 5;
            pearlunlock.DoesPopUpInfo = true;
            pearlunlock.StartsLocked = true;
            pearlunlock.IsEffectImmediate = false;
            pearlunlock.TriggerOn = TriggerCalls.OnCombatStart;
            pearlunlock.Conditions = new EffectorConditionSO[] { checkBundleDifficultyEffector };
            pearlunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(changeMaxHealth, 25, Targeting.Unit_AllOpponents), Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeCurrentHealthtToMaxHealthEffect>(), 1, Targeting.Unit_AllOpponents), Effects.GenerateEffect(extraLootListEffect, 3, Targeting.Slot_SelfSlot), Effects.GenerateEffect(extraLootListEffect,1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(pearlunlock.Item, new ItemModdedUnlockInfo(pearlunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked7", null, 32, null), "EP_Pearl_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Pearl_Abstraction_ACH", "DeadCanary_SW");

            ModdedAchievements pearlmoddedAchievements = new ModdedAchievements("Dead Canary", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch7", null, 32, null), "EP_Pearl_Abstraction_ACH");
            pearlmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_PearlDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_PearlDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Pearl_CH").entityID, Unlocks.GenerateUnlockData("EP_Pearl_Abstraction_Unlock", "EP_Pearl_Abstraction_ACH", "", "", new string[] { "DeadCanary_SW" }));

            LoadedAssetsHandler.GetCharacter("Pearl_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Pearl_Abstraction_ACH"));


            PerformEffect_Item dimitriunlock = new PerformEffect_Item();
            dimitriunlock.Item_ID = "BurntLetter_SW";
            dimitriunlock.Name = "Burnt Letter";
            dimitriunlock.Flavour = "\"Just for me-e-e.\"";
            dimitriunlock.Description = "This party member now deals half their Direct damage as Fire damage.";
            dimitriunlock.IsShopItem = true;
            dimitriunlock.Icon = ResourceLoader.LoadSprite("DimitriItem");
            dimitriunlock.ShopPrice = 3;
            dimitriunlock.DoesPopUpInfo = true;
            dimitriunlock.StartsLocked = true;
            dimitriunlock.IsEffectImmediate = false;
            dimitriunlock.TriggerOn = TriggerCalls.OnWillApplyDamage;
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            dimitriunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(dimitriunlock.Item, new ItemModdedUnlockInfo(dimitriunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked11", null, 32, null), "EP_Dimitri_CH_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Dimitri_CH_Abstraction_ACH", "BurntLetter_SW");

            ModdedAchievements dimitrimoddedAchievements = new ModdedAchievements("Burnt Letter", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch11", null, 32, null), "EP_Dimitri_CH_Abstraction_ACH");
            dimitrimoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_DimitriDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_DimitriDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Dimitri_CH").entityID, Unlocks.GenerateUnlockData("EP_Dimitri_Abstraction_Unlock", "EP_Dimitri_CH_Abstraction_ACH", "", "", new string[] { "BurntLetter_SW" }));

            LoadedAssetsHandler.GetCharacter("Dimitri_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Dimitri_CH_Abstraction_ACH"));


            CasterStoreValueSetterEffect casterSetStoredValueEffect = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            casterSetStoredValueEffect.m_unitStoredDataID = "Loose Scarf";

            RefreshMoveIfStoredValueNotZero refreshIfStoredValueNotZero = ScriptableObject.CreateInstance<RefreshMoveIfStoredValueNotZero>();
            refreshIfStoredValueNotZero._valueName = "Loose Scarf";

            DoublePerformEffect_Item cliveunlock = new DoublePerformEffect_Item();
            cliveunlock.Item_ID = "LooseScarf_SW";
            cliveunlock.Name = "Loose Scarf";
            cliveunlock.Flavour = "\"Friends made along the way.\"";
            cliveunlock.Description = "This party member can move twice per turn.";
            cliveunlock.IsShopItem = true;
            cliveunlock.Icon = ResourceLoader.LoadSprite("CliveItem");
            cliveunlock.ShopPrice = 8;
            cliveunlock.DoesPopUpInfo = false;
            cliveunlock.SecondaryDoesPopUpInfo = true;
            cliveunlock.StartsLocked = true;
            cliveunlock.IsEffectImmediate = false;
            cliveunlock.TriggerOn = TriggerCalls.OnTurnStart;
            cliveunlock.SecondaryTriggerOn = new TriggerCalls[] { TriggerCalls.OnSwapTo };
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            cliveunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(casterSetStoredValueEffect, 1, Targeting.Slot_SelfSlot) };
            cliveunlock.SecondaryEffects = new EffectInfo[] { Effects.GenerateEffect(refreshIfStoredValueNotZero, 1, Targeting.Slot_SelfSlot) };


            ItemUtils.AddItemToShopStatsCategoryAndGamePool(cliveunlock.Item, new ItemModdedUnlockInfo(cliveunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked14", null, 32, null), "EP_Clive_CH_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Clive_CH_Abstraction_ACH", "LooseScarf_SW");

            ModdedAchievements clivemoddedAchievements = new ModdedAchievements("Loose Scarf", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch14", null, 32, null), "EP_Clive_CH_Abstraction_ACH");
            clivemoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_CliveDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_CliveDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Clive_CH").entityID, Unlocks.GenerateUnlockData("EP_Clive_Abstraction_Unlock", "EP_Clive_CH_Abstraction_ACH", "", "", new string[] { "LooseScarf_SW" }));

            LoadedAssetsHandler.GetCharacter("Clive_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Clive_CH_Abstraction_ACH"));




            CasterStoreValueSetterEffect casterSetStoredValueEffect1 = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            casterSetStoredValueEffect1.m_unitStoredDataID = "SugarValue";


            HealIfStoredValueNotZero healIfStoredValueNot = ScriptableObject.CreateInstance<HealIfStoredValueNotZero>();
            healIfStoredValueNot._valueName = "SugarValue";


            DoublePerformEffect_Item biminiunlock = new DoublePerformEffect_Item();
            biminiunlock.Item_ID = "Sugar_SW";
            biminiunlock.Name = "Sugar";
            biminiunlock.Flavour = "\"The most important element.\"";
            biminiunlock.Description = "If this party member received damage, heal this party member 1-3 Health at the end of the turn.";
            biminiunlock.IsShopItem = true;
            biminiunlock.Icon = ResourceLoader.LoadSprite("BiminiItem");
            biminiunlock.ShopPrice = 3;
            biminiunlock.DoesPopUpInfo = false;
            biminiunlock.SecondaryDoesPopUpInfo = false;
            biminiunlock.StartsLocked = true;
            biminiunlock.IsEffectImmediate = false;
            biminiunlock.TriggerOn = TriggerCalls.OnDamaged;
            biminiunlock.SecondaryTriggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            biminiunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(casterSetStoredValueEffect1, 1, Targeting.Slot_SelfSlot) };
            biminiunlock.SecondaryEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot),Effects.GenerateEffect(healIfStoredValueNot, 3, Targeting.Slot_SelfSlot) };


            ItemUtils.AddItemToShopStatsCategoryAndGamePool(biminiunlock.Item, new ItemModdedUnlockInfo(biminiunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked21", null, 32, null), "EP_Bimini_CH_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Bimini_CH_Abstraction_ACH", "Sugar_SW");

            ModdedAchievements biminimoddedAchievements = new ModdedAchievements("Sugar", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch21", null, 32, null), "EP_Bimini_CH_Abstraction_ACH");
            biminimoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_BiminiDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_BiminiDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Bimini_CH").entityID, Unlocks.GenerateUnlockData("EP_Bimini_Abstraction_Unlock", "EP_Bimini_CH_Abstraction_ACH", "", "", new string[] { "Sugar_SW" }));

            LoadedAssetsHandler.GetCharacter("Bimini_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Bimini_CH_Abstraction_ACH"));



            DoublePerformEffect_Item gospelunlock = new DoublePerformEffect_Item();
            gospelunlock.Item_ID = "TaliasSeveredHead_TW";
            gospelunlock.Name = "Talia's Severed Head";
            gospelunlock.Flavour = "\"Like God, but less impressive.\"";
            gospelunlock.Description = "Heal this party member 3 health at the end of each turn.\nUpon taking any kind of damage, grant alien information.";
            gospelunlock.IsShopItem = false;
            gospelunlock.Icon = ResourceLoader.LoadSprite("GospelItem");
            gospelunlock.ShopPrice = 3;
            gospelunlock.DoesPopUpInfo = true;
            gospelunlock.SecondaryDoesPopUpInfo = true;
            gospelunlock.StartsLocked = true;
            gospelunlock.IsEffectImmediate = false;
            gospelunlock.TriggerOn = TriggerCalls.OnDamaged;
            gospelunlock.SecondaryTriggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
            //arnoldunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_SMS1 };
            gospelunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<RandomWikiURLEffect>(), 1, Targeting.Slot_SelfSlot) };
            gospelunlock.SecondaryEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 3, Targeting.Slot_SelfSlot) };


            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(gospelunlock.Item, new ItemModdedUnlockInfo(gospelunlock.Item_ID, ResourceLoader.LoadSprite("DoulaLocked22", null, 32, null), "EP_Gospel_CH_Abstraction_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Gospel_CH_Abstraction_ACH", "TaliasSeveredHead_TW");

            ModdedAchievements gospelmoddedAchievements = new ModdedAchievements("Talia's Severed Head", "Unlocked a new item.", ResourceLoader.LoadSprite("DoulaAch22", null, 32, null), "EP_Gospel_CH_Abstraction_ACH");
            gospelmoddedAchievements.AddNewAchievementToCUSTOMCategory("AbstractionTitleLabel", "The Abstraction");

            FinalBossCharUnlockCheck unlock_GospelDoulaFinalBoss = Unlocks.GetOrCreateUnlock_CustomFinalBoss("DoulaBoss", ResourceLoader.LoadSprite("DoulaPearl"));
            unlock_GospelDoulaFinalBoss.AddUnlockData(LoadedAssetsHandler.GetCharacter("Gospel_CH").entityID, Unlocks.GenerateUnlockData("EP_Gospel_Abstraction_Unlock", "EP_Gospel_CH_Abstraction_ACH", "", "", new string[] { "TaliasSeveredHead_TW" }));

            LoadedAssetsHandler.GetCharacter("Gospel_CH").m_BossAchData.Add(new("DoulaBoss", "EP_Gospel_CH_Abstraction_ACH"));




        }

    }
}
