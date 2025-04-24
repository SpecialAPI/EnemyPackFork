using BrutalAPI.Items;
using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using NewEnemyPack.Effectsa;

namespace NewEnemyPack
{
    internal class MasteryUnlock
    {
        public static void Add()
        {
            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.Constricted;

            PerformEffect_Item extra = new PerformEffect_Item();
            extra.Item_ID = "SkeletonBanana_EW";
            extra.Name = "Skeleton Banana";
            extra.Flavour = "\"I don't think that;s how it works.\"";
            extra.Description = "Upon moving this party member apply 1 Constricting to the opposing position.";
            extra.IsShopItem = false;
            extra.Icon = ResourceLoader.LoadSprite("FullUnlockExtra1");
            extra.ShopPrice = 6;
            extra.DoesPopUpInfo = true;
            extra.StartsLocked = true;
            extra.IsEffectImmediate = false;
            extra.TriggerOn = TriggerCalls.CanBeSwapped;
            extra.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            extra.Effects = new EffectInfo[] { Effects.GenerateEffect(fieldEffect_Apply_, 1, Targeting.Slot_Front) };
            ItemUtils.JustAddItemSoItCanBeLoaded(extra.Item);

            FieldEffect_Apply_Effect fieldEffect_Apply_1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_1._Field = StatusField.Shield;

            PerformEffect_Item extra1 = new PerformEffect_Item();
            extra1.Item_ID = "GizoEgg_EW";
            extra1.Name = "Gizo Egg";
            extra1.Flavour = "\"You can make a really terrible omelette with this.\"";
            extra1.Description = "Upon moving this party member apply 1 Constricting to the opposing position.";
            extra1.IsShopItem = false;
            extra1.Icon = ResourceLoader.LoadSprite("FullUnlockExtra2");
            extra1.ShopPrice = 6;
            extra1.DoesPopUpInfo = true;
            extra1.StartsLocked = true;
            extra1.IsEffectImmediate = false;
            extra1.TriggerOn = TriggerCalls.OnKill;
            extra1.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            extra1.Effects = new EffectInfo[] { Effects.GenerateEffect(fieldEffect_Apply_1, 6, Targeting.Slot_SelfSlot) };
            ItemUtils.JustAddItemSoItCanBeLoaded(extra1.Item);

            GenerateColorManaEffect generateColorManaEffect = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            generateColorManaEffect.mana = Pigments.SplitPigment(Pigments.Purple, Pigments.Blue);

            PerformEffect_Item extra11 = new PerformEffect_Item();
            extra11.Item_ID = "EctoplasmicEmesis_EW";
            extra11.Name = "Ectoplasmic Emesis";
            extra11.Flavour = "\"Barely even there.\"";
            extra11.Description = "50% chance Heal this party member 2 Health at the end of each turn, if this doesn't heal instead produce 1 Purple/Blue split pigment.";
            extra11.IsShopItem = false;
            extra11.Icon = ResourceLoader.LoadSprite("FullUnlockExtra3");
            extra11.ShopPrice = 6;
            extra11.DoesPopUpInfo = true;
            extra11.StartsLocked = true;
            extra11.IsEffectImmediate = false;
            extra11.TriggerOn = TriggerCalls.OnKill;
            extra11.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            extra11.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Targeting.Slot_SelfSlot), Effects.GenerateEffect(generateColorManaEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(false, 1)), };
            ItemUtils.JustAddItemSoItCanBeLoaded(extra11.Item);

            SpawnEnemyAnywhereEffect spawnEnemyAnywhere = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            spawnEnemyAnywhere.enemy = LoadedAssetsHandler.GetEnemy("CopperCougher_EN");
            spawnEnemyAnywhere.givesExperience = false;

            PerformEffect_Item extra111 = new PerformEffect_Item();
            extra111.Item_ID = "BronzeDroplet_EW";
            extra111.Name = "Bronze Droplet";
            extra111.Flavour = "\"Pathetic.\"";
            extra111.Description = "Spawn a Copper Cougher on combat start.";
            extra111.IsShopItem = false;
            extra111.Icon = ResourceLoader.LoadSprite("FullUnlockExtra5");
            extra111.ShopPrice = 6;
            extra111.DoesPopUpInfo = true;
            extra111.StartsLocked = true;
            extra111.IsEffectImmediate = false;
            extra111.TriggerOn = TriggerCalls.OnKill;
            extra111.EquippedModifiers = new WearableStaticModifierSetterSO[] { };
            extra111.Effects = new EffectInfo[] { Effects.GenerateEffect(spawnEnemyAnywhere, 1, Targeting.Slot_SelfSlot), };
            ItemUtils.JustAddItemSoItCanBeLoaded(extra111.Item);

            CasterStoreValueSetterEffect casterSetStoredValueEffect = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            casterSetStoredValueEffect.m_unitStoredDataID = "TeaCup";

            RefreshMoveIfStoredValueNotZero refreshIfStoredValueNotZero = ScriptableObject.CreateInstance<RefreshMoveIfStoredValueNotZero>();
            refreshIfStoredValueNotZero._valueName = "TeaCup";

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_ = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_._extraPassiveAbility = Passives.Skittish;

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_1 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_1._extraPassiveAbility = Passives.Slippery;

            DoublePerformEffect_Item teacup = new DoublePerformEffect_Item();
            teacup.Item_ID = "AdorableTeacup_EW";
            teacup.Name = "Adorable Teacup";
            teacup.Flavour = "\"Aw how heartburning.\"";
            teacup.Description = "This party member can move twice per turn.\nThis party member now has Slippery and Skittish as passives.";
            teacup.IsShopItem = false;
            teacup.Icon = ResourceLoader.LoadSprite("FullUnlockExtra6");
            teacup.ShopPrice = 8;
            teacup.DoesPopUpInfo = false;
            teacup.SecondaryDoesPopUpInfo = true;
            teacup.StartsLocked = true;
            teacup.IsEffectImmediate = false;
            teacup.TriggerOn = TriggerCalls.OnTurnStart;
            teacup.SecondaryTriggerOn = new TriggerCalls[] { TriggerCalls.OnSwapTo };
            teacup.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraPassiveAbility_Wearable_, extraPassiveAbility_Wearable_1 };
            teacup.Effects = new EffectInfo[] { Effects.GenerateEffect(casterSetStoredValueEffect, 1, Targeting.Slot_SelfSlot) };
            teacup.SecondaryEffects = new EffectInfo[] { Effects.GenerateEffect(refreshIfStoredValueNotZero, 1, Targeting.Slot_SelfSlot) };
            ItemUtils.JustAddItemSoItCanBeLoaded(teacup.Item);


            MaxHealthChange_Wearable_SMS maxHealthChange_Wearable_ = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
            maxHealthChange_Wearable_.isChangePercentage = true;
            maxHealthChange_Wearable_.maxHealthChange = -70;

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_3 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_3._extraPassiveAbility = LoadedAssetsHandler.GetEnemy("Unterling_EN").passiveAbilities[1];


            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_4 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_4._extraPassiveAbility = Passives.Immortal;

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_41 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_41._extraPassiveAbility = Passives.Inferno;

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_42 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_42._extraPassiveAbility = LoadedAssetsHandler.GetEnemy("Ophanim_EN").passiveAbilities[2];

            PerformEffect_Item extra1111 = new PerformEffect_Item();
            extra1111.Item_ID = "SweatyCloth_EW";
            extra1111.Name = "Sweaty Cloth";
            extra1111.Flavour = "\"Look at you go!\"";
            extra1111.Description = "This party member now has 70% less Maximum health.\nThis party member now has Classic as a passive.";
            extra1111.IsShopItem = false;
            extra1111.Icon = ResourceLoader.LoadSprite("FullUnlockExtra7");
            extra1111.ShopPrice = 6;
            extra1111.DoesPopUpInfo = true;
            extra1111.StartsLocked = true;
            extra1111.IsEffectImmediate = false;
            extra1111.TriggerOn = TriggerCalls.Count;
            extra1111.EquippedModifiers = new WearableStaticModifierSetterSO[] { maxHealthChange_Wearable_, extraPassiveAbility_Wearable_3 };
            extra1111.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot), };
            ItemUtils.JustAddItemSoItCanBeLoaded(extra1111.Item);


            PerformEffect_Item extra11111 = new PerformEffect_Item();
            extra11111.Item_ID = "BoneHalo_EW";
            extra11111.Name = "Bone Halo";
            extra11111.Flavour = "\"These are NOT angels...\"";
            extra11111.Description = "his party member now Inferno, Blazing and Immortal as passives.";
            extra11111.IsShopItem = false;
            extra11111.Icon = ResourceLoader.LoadSprite("FullUnlockExtra8");
            extra11111.ShopPrice = 6;
            extra11111.DoesPopUpInfo = true;
            extra11111.StartsLocked = true;
            extra11111.IsEffectImmediate = false;
            extra11111.TriggerOn = TriggerCalls.Count;
            extra11111.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraPassiveAbility_Wearable_4, extraPassiveAbility_Wearable_41, extraPassiveAbility_Wearable_42 };
            extra11111.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot), };
            ItemUtils.JustAddItemSoItCanBeLoaded(extra11111.Item);

            LootItemProbability lootitem = new LootItemProbability();
            lootitem.probability = 10;
            lootitem.itemName = "SkeletonBanana_EW";

            LootItemProbability lootitem1 = new LootItemProbability();
            lootitem1.probability = 10;
            lootitem1.itemName = "GizoEgg_EW";

            LootItemProbability lootitem2 = new LootItemProbability();
            lootitem2.probability = 10;
            lootitem2.itemName = "EctoplasmicEmesis_EW";

            LootItemProbability lootitem3 = new LootItemProbability();
            lootitem3.probability = 10;
            lootitem3.itemName = "BronzeDroplet_EW";

            LootItemProbability lootitem4 = new LootItemProbability();
            lootitem4.probability = 10;
            lootitem4.itemName = "AdorableTeacup_EW";

            LootItemProbability lootitem5 = new LootItemProbability();
            lootitem5.probability = 10;
            lootitem5.itemName = "SweatyCloth_EW";

            LootItemProbability lootitem6 = new LootItemProbability();
            lootitem6.probability = 10;
            lootitem6.itemName = "BoneHalo_EW";

            ExtraLootListEffect extraLootListEffect = ScriptableObject.CreateInstance<ExtraLootListEffect>();
            extraLootListEffect._lockedLootableItems = new List<LootItemProbability> { };
            extraLootListEffect._lootableItems = new List<LootItemProbability> { lootitem, lootitem1, lootitem2, lootitem3, lootitem4, lootitem5, lootitem6 };
            extraLootListEffect._nothingPercentage = 0;
            extraLootListEffect._shopPercentage = 0;
            extraLootListEffect._treasurePercentage = 0;

            ExtraLootOptionsEffect silverdagger = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            silverdagger._changeOption = true;
            silverdagger._itemName = "TheEnemyPack_TW";



            PerformEffect_Item Allbeatunlock = new PerformEffect_Item();
            Allbeatunlock.Item_ID = "TheEnemyPack_TW";
            Allbeatunlock.Name = "The Enemy Pack";
            Allbeatunlock.Flavour = "\"Who made this sh$%!?\"";
            Allbeatunlock.Description = "On combat start produce several helpful items and consume this item.";
            Allbeatunlock.IsShopItem = false;
            Allbeatunlock.Icon = ResourceLoader.LoadSprite("FullUnlock");
            Allbeatunlock.ShopPrice = 3;
            Allbeatunlock.ConsumeOnUse = true;
            Allbeatunlock.DoesPopUpInfo = true;
            Allbeatunlock.StartsLocked = true;
            Allbeatunlock.IsEffectImmediate = false;
            Allbeatunlock.TriggerOn = TriggerCalls.OnCombatStart;
            Allbeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(extraLootListEffect, 2, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(extraLootListEffect, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(silverdagger, 1, Targeting.Slot_SelfSlot),
            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(Allbeatunlock.Item, new ItemModdedUnlockInfo(Allbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked4", null, 32, null), "EP_Mastery_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Mastery_ACH", "TheEnemyPack_TW");

            UnlockableModData AllBeatunlockData = new UnlockableModData("MasteryUnlock");
            AllBeatunlockData.hasModdedAchievementUnlock = true;
            AllBeatunlockData.moddedAchievementID = "EP_Mastery_ACH";
            AllBeatunlockData.hasItemUnlock = true;
            AllBeatunlockData.items = new string[] { "TheEnemyPack_TW" };

            MasteryUnlockCheck AllDeathUnlock = ScriptableObject.CreateInstance<MasteryUnlockCheck>();
            AllDeathUnlock.unlockData = AllBeatunlockData;
            AllDeathUnlock.unlockID = "MasteryUnlock";



            Unlocks.AddUnlock_PostCombat(AllDeathUnlock);

            ModdedAchievements Allach = new ModdedAchievements("Time Un-well Spent", "Achieve every Non-Abstraction achievement in the Enemy Pack.\nTairbaz and Peep think you are pretty cool :)", ResourceLoader.LoadSprite("MasteryAch", null, 32, null), "EP_Mastery_ACH");
            Allach.IsSecret = true;
            Allach.SecretDescription = "Achieve every Non-Abstraction achievement in the Enemy Pack.";
            Allach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.NarrativeTitleLabel);



        }
    }
}
