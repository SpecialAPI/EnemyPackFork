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
    internal class BossUnlocks
    {
        public static void Add()
        {

            RankChange_Wearable_SMS rankChange_Wearable_ = ScriptableObject.CreateInstance<RankChange_Wearable_SMS>();
            rankChange_Wearable_._rankAdditive = 1;

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_ = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_._extraPassiveAbility = LoadedAssetsHandler.GetCharacter("Gospel_CH").passiveAbilities[0];



            PerformEffect_Item intijarbeatunlock = new PerformEffect_Item();
            intijarbeatunlock.Item_ID = "CalciumSupplement_SW";
            intijarbeatunlock.Name = "Calcium Supplement";
            intijarbeatunlock.Flavour = "\"Bones like Titanium.\"";
            intijarbeatunlock.Description = "This party member is now one level higher.\nThis party member now has Inanimate as a passive.";
            intijarbeatunlock.IsShopItem = true;
            intijarbeatunlock.Icon = ResourceLoader.LoadSprite("IntijarUnlock");
            intijarbeatunlock.ShopPrice = 3;
            intijarbeatunlock.DoesPopUpInfo = true;
            intijarbeatunlock.StartsLocked = true;
            intijarbeatunlock.IsEffectImmediate = false;
            intijarbeatunlock.TriggerOn = TriggerCalls.Count;
            intijarbeatunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { rankChange_Wearable_, extraPassiveAbility_Wearable_ };
            intijarbeatunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToShopStatsCategoryAndGamePool(intijarbeatunlock.Item, new ItemModdedUnlockInfo(intijarbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked8", null, 32, null), "EP_Intijar_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Intijar_BossBeat_ACH", "CalciumSupplement_SW");

            UnlockableModData unlockData = new UnlockableModData("IntijarBoss");
            unlockData.hasModdedAchievementUnlock = true;
            unlockData.moddedAchievementID = "EP_Intijar_BossBeat_ACH";
            unlockData.hasItemUnlock = true;
            unlockData.items = new string[] { "CalciumSupplement_SW" };

            ListedUnlockCheck IntijarUnlockCheck = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            IntijarUnlockCheck.unlockID = "IntijarBoss";
            IntijarUnlockCheck.unlockData = unlockData;

            Unlocks.AddUnlock_BeatBoss(IntijarUnlockCheck);

            ModdedAchievements intijarbeatach = new ModdedAchievements("The Highbrow", "Murder Intijar.", ResourceLoader.LoadSprite("IntijarAch", null, 32, null), "EP_Intijar_BossBeat_ACH");
            intijarbeatach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);



            PerformEffect_Item unicornbeatunlock = new PerformEffect_Item();
            unicornbeatunlock.Item_ID = "TheInhumanSoul_TW";
            unicornbeatunlock.Name = "The Inhuman Soul";
            unicornbeatunlock.Flavour = "\"The missing screw.\"";
            unicornbeatunlock.Description = "On combat start, give this party member a random ability of any other party member as an additional ability.";
            unicornbeatunlock.IsShopItem = false;
            unicornbeatunlock.Icon = ResourceLoader.LoadSprite("UnicornUnlock");
            unicornbeatunlock.ShopPrice = 3;
            unicornbeatunlock.DoesPopUpInfo = true;
            unicornbeatunlock.StartsLocked = true;
            unicornbeatunlock.IsEffectImmediate = false;
            unicornbeatunlock.TriggerOn = TriggerCalls.OnCombatStart;
            unicornbeatunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<AddAbilityEffect>(), 1, Targeting.Slot_SelfSlot) };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(unicornbeatunlock.Item, new ItemModdedUnlockInfo(unicornbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked14", null, 32, null), "EP_Unicorn_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Unicorn_BossBeat_ACH", "TheInhumanSoul_TW");

            UnlockableModData unicornunlockData = new UnlockableModData("UnicornBoss");
            unicornunlockData.hasModdedAchievementUnlock = true;
            unicornunlockData.moddedAchievementID = "EP_Unicorn_BossBeat_ACH";
            unicornunlockData.hasItemUnlock = true;
            unicornunlockData.items = new string[] { "TheInhumanSoul_TW" };

            ListedUnlockCheck UnicornUnlockCheck = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            UnicornUnlockCheck.unlockID = "UnicornBoss";
            UnicornUnlockCheck.unlockData = unicornunlockData;

            Unlocks.AddUnlock_BeatBoss(UnicornUnlockCheck);

            ModdedAchievements Unicornbeatach = new ModdedAchievements("The Folly", "Slay the Malformed Unicorn.", ResourceLoader.LoadSprite("UnicornAch", null, 32, null), "EP_Unicorn_BossBeat_ACH");
           
            Unicornbeatach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);


            DamageAdditionModifierForeverAlone_Item squidbeatunlock = new DamageAdditionModifierForeverAlone_Item();
            squidbeatunlock.Item_ID = "ForeverAlone_TW";
            squidbeatunlock.Name = "Forever Alone";
            squidbeatunlock.Flavour = "\"Maybe it's better this way...\"";
            squidbeatunlock.Description = "This party member deals, 2 more damage per empty slot in your party.";
            squidbeatunlock.IsShopItem = false;
            squidbeatunlock.Icon = ResourceLoader.LoadSprite("SquidUnlock");
            squidbeatunlock.ShopPrice = 3;
            squidbeatunlock.DoesPopUpInfo = true;
            squidbeatunlock.StartsLocked = true;
            squidbeatunlock.ToAdd = 10;
            squidbeatunlock.TriggerOn = TriggerCalls.OnWillApplyDamage;
            squidbeatunlock.AffectDamageDealtInsteadOfReceived = true;

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(squidbeatunlock.Item, new ItemModdedUnlockInfo(squidbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked13", null, 32, null), "EP_Squid_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Squid_BossBeat_ACH", "ForeverAlone_TW");

            UnlockableModData squidunlockData = new UnlockableModData("SquidBoss");
            squidunlockData.hasModdedAchievementUnlock = true;
            squidunlockData.moddedAchievementID = "EP_Squid_BossBeat_ACH";
            squidunlockData.hasItemUnlock = true;
            squidunlockData.items = new string[] { "ForeverAlone_TW" };

            ListedUnlockCheck SquidUnlockCheck = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            SquidUnlockCheck.unlockID = "SquidBoss";
            SquidUnlockCheck.unlockData = squidunlockData;

            Unlocks.AddUnlock_BeatBoss(SquidUnlockCheck);

            ModdedAchievements Squidbeatach = new ModdedAchievements("The Loathsome", "Slay the Depression Squid.", ResourceLoader.LoadSprite("SquidAch", null, 32, null), "EP_Squid_BossBeat_ACH");
            Squidbeatach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);


            PercentageEffectorCondition percentageEffector = ScriptableObject.CreateInstance<PercentageEffectorCondition>();
            percentageEffector.triggerPercentage = 4;

            PerformEffect_Item doulabeatunlock = new PerformEffect_Item();
            doulabeatunlock.Item_ID = "Guilt_TW";
            doulabeatunlock.Name = "Guilt";
            doulabeatunlock.Flavour = "\"The unseen organ.\"";
            doulabeatunlock.Description = "Upon any party member performing an ability, very small chance to refresh this party member.";
            doulabeatunlock.IsShopItem = false;
            doulabeatunlock.Icon = ResourceLoader.LoadSprite("DoulaUnlock");
            doulabeatunlock.ShopPrice = 3;
            doulabeatunlock.DoesPopUpInfo = false;
            doulabeatunlock.StartsLocked = true;
            doulabeatunlock.IsEffectImmediate = false;
            doulabeatunlock.Conditions = new EffectorConditionSO[] { percentageEffector };
            doulabeatunlock.TriggerOn = TriggerCalls.OnAnyAbilityUsed;
            doulabeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckIsPlayerTurnEffect>(), 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<PopUpCasterItemInfoEffect>(), 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,1)),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,2)),
            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(doulabeatunlock.Item, new ItemModdedUnlockInfo(doulabeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked2", null, 32, null), "EP_Doula_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Doula_BossBeat_ACH", "Guilt_TW");

            UnlockableModData doulaunlockData = new UnlockableModData("DoulaBoss");
            doulaunlockData.hasModdedAchievementUnlock = true;
            doulaunlockData.moddedAchievementID = "EP_Doula_BossBeat_ACH";
            doulaunlockData.hasItemUnlock = true;
            doulaunlockData.items = new string[] { "Guilt_TW" };

            ListedUnlockCheck DoulaUnlockCheck = ScriptableObject.CreateInstance<ListedUnlockCheck>();
            DoulaUnlockCheck.unlockID = "DoulaBoss";
            DoulaUnlockCheck.unlockData = doulaunlockData;

            Unlocks.AddUnlock_BeatBoss(DoulaUnlockCheck);

            ModdedAchievements Doulabeatach = new ModdedAchievements("The Abstraction", "Abandon the Doula.", ResourceLoader.LoadSprite("DoulaAch", null, 32, null), "EP_Doula_BossBeat_ACH");
            Doulabeatach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);


            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_1 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_1._extraPassiveAbility = LoadedAssetsHandler.GetCharacter("Mordrake_CH").passiveAbilities[0];

            CopyAndSpawnCustomCharacterAnywhereEffect spawn = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            spawn._characterCopy = "FesteringPile_CH";
            spawn._rank = 0;
            spawn._extraModifiers = new WearableStaticModifierSetterSO[0];
            spawn._permanentSpawn = false;

            SpawnEnemyAnywhereEffect spawnEnemyAnywhere = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
            spawnEnemyAnywhere.enemy = LoadedAssetsHandler.GetEnemy("Keko_EN");
            spawnEnemyAnywhere.givesExperience = false;

            ExtraPassiveAbility_Wearable_SMS extraPassiveAbility_Wearable_SMS = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
            extraPassiveAbility_Wearable_SMS._extraPassiveAbility = Passives.Infestation2;

            PerformEffect_Item kekapexbeatunlock = new PerformEffect_Item();
            kekapexbeatunlock.Item_ID = "WormyCrown_TW";
            kekapexbeatunlock.Name = "Wormy Crown";
            kekapexbeatunlock.Flavour = "\"Lord of all things squirming.\"";
            kekapexbeatunlock.Description = "This party member now has Infestation (2) as a passive.\nOn combat start spawn as many Festring Piles and Kekos as possible.";
            kekapexbeatunlock.IsShopItem = false;
            kekapexbeatunlock.Icon = ResourceLoader.LoadSprite("KekapexUnlock");
            kekapexbeatunlock.ShopPrice = 6;
            kekapexbeatunlock.DoesPopUpInfo = true;
            kekapexbeatunlock.StartsLocked = true;
            kekapexbeatunlock.IsEffectImmediate = false;
            kekapexbeatunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraPassiveAbility_Wearable_SMS };
            kekapexbeatunlock.TriggerOn = TriggerCalls.OnCombatStart;
            kekapexbeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(spawn, 5, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(spawnEnemyAnywhere, 5, Targeting.Slot_SelfSlot),

            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(kekapexbeatunlock.Item, new ItemModdedUnlockInfo(kekapexbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked9", null, 32, null), "EP_Kekapex_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Kekapex_BossBeat_ACH", "WormyCrown_TW");

            UnlockableModData kekapexunlockData = new UnlockableModData("Kekapex_EN");
            kekapexunlockData.hasModdedAchievementUnlock = true;
            kekapexunlockData.moddedAchievementID = "EP_Kekapex_BossBeat_ACH";
            kekapexunlockData.hasItemUnlock = true;
            kekapexunlockData.items = new string[] { "WormyCrown_TW" };

            EnemyDeathUnlockCheck kekapexDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            kekapexDeathUnlock.usesSimpleDeathData = true;
            kekapexDeathUnlock.enemyID = "Kekapex_EN";
            kekapexDeathUnlock.simpleDeathData = kekapexunlockData;
            kekapexDeathUnlock.specialDeathData = new SerializableDictionary<string, UnlockableModData>();

            Unlocks.AddUnlock_EnemyDeath(kekapexDeathUnlock);

            ModdedAchievements kekapexach = new ModdedAchievements("The Early Bird Gets the Worm", "Uproot the Kekapex.", ResourceLoader.LoadSprite("KekapexAch", null, 32, null), "EP_Kekapex_BossBeat_ACH");
            kekapexach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);



            Ability cherubimbility = new Ability("ArtificialLycanthropy_A_0");
            cherubimbility.Name = "Artificial Lycanthropy";
            cherubimbility.Description = "Perform 5 random enemy moves back to back.";
            cherubimbility.AbilitySprite = ResourceLoader.LoadSprite("CherubimUnlockMove");
            cherubimbility.Cost = new ManaColorSO[] { Pigments.Red, Pigments.Yellow, Pigments.Purple, Pigments.Blue };
            cherubimbility.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityEnemyEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            cherubimbility.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });

            ExtraAbility_Wearable_SMS extraAbility_Wearable_ = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_._extraAbility = cherubimbility.GenerateCharacterAbility();


            PerformEffect_Item cherubimbeatunlock = new PerformEffect_Item();
            cherubimbeatunlock.Item_ID = "GeneticInjection_TW";
            cherubimbeatunlock.Name = "Genetic Injection";
            cherubimbeatunlock.Flavour = "\"It's not supposed to grow those...\"";
            cherubimbeatunlock.Description = "Gives this party member an additional ability \"Artificial Lycanthropy\" a chaotic maelstrom of enemy abilities.";
            cherubimbeatunlock.IsShopItem = false;
            cherubimbeatunlock.Icon = ResourceLoader.LoadSprite("CherubimUnlock");
            cherubimbeatunlock.ShopPrice = 3;
            cherubimbeatunlock.DoesPopUpInfo = false;
            cherubimbeatunlock.StartsLocked = true;
            cherubimbeatunlock.IsEffectImmediate = false;
            cherubimbeatunlock.TriggerOn = TriggerCalls.Count;
            cherubimbeatunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_ };
            cherubimbeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckIsPlayerTurnEffect>(), 1, Targeting.Slot_SelfSlot),

            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(cherubimbeatunlock.Item, new ItemModdedUnlockInfo(cherubimbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked1", null, 32, null), "EP_Cherubim_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Cherubim_BossBeat_ACH", "GeneticInjection_TW");

            UnlockableModData cherubimunlockData = new UnlockableModData("Cherubim_EN");
            cherubimunlockData.hasModdedAchievementUnlock = true;
            cherubimunlockData.moddedAchievementID = "EP_Cherubim_BossBeat_ACH";
            cherubimunlockData.hasItemUnlock = true;
            cherubimunlockData.items = new string[] { "GeneticInjection_TW" };

            EnemyDeathUnlockCheck cherubimDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            cherubimDeathUnlock.usesSimpleDeathData = true;
            cherubimDeathUnlock.enemyID = "Cherubim_EN";
            cherubimDeathUnlock.simpleDeathData = cherubimunlockData;
            cherubimDeathUnlock.specialDeathData = new SerializableDictionary<string, UnlockableModData>();


            Unlocks.AddUnlock_EnemyDeath(cherubimDeathUnlock);

            ModdedAchievements Cherubimach = new ModdedAchievements("Ezekiel 10:14", "Desecrate the Cherubim.", ResourceLoader.LoadSprite("CherubimAch", null, 32, null), "EP_Cherubim_BossBeat_ACH");
            Cherubimach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);



            ChangePigmentGeneratorPool_Effect ds = ScriptableObject.CreateInstance<ChangePigmentGeneratorPool_Effect>();
            ds._newPool = new ManaColorSO[6] { Pigments.SplitPigment(Pigments.Yellow, Pigments.Red), Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue), Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple), Pigments.Yellow, Pigments.Yellow, Pigments.Yellow };


            PerformEffect_Item Opisthotonusbeatunlock = new PerformEffect_Item();
            Opisthotonusbeatunlock.Item_ID = "SgilpsSkull_TW";
            Opisthotonusbeatunlock.Name = "Sgilps' Skull";
            Opisthotonusbeatunlock.Flavour = "\"Failed experiment.\"";
            Opisthotonusbeatunlock.Description = "The yellow pigment generator can now generate yellow pigment split with other random pigment.";
            Opisthotonusbeatunlock.IsShopItem = false;
            Opisthotonusbeatunlock.Icon = ResourceLoader.LoadSprite("SgilpsSkull");
            Opisthotonusbeatunlock.ShopPrice = 3;
            Opisthotonusbeatunlock.DoesPopUpInfo = true;
            Opisthotonusbeatunlock.StartsLocked = true;
            Opisthotonusbeatunlock.IsEffectImmediate = false;
            Opisthotonusbeatunlock.TriggerOn = TriggerCalls.OnCombatStart;
            Opisthotonusbeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(ds, 1, Targeting.Slot_SelfSlot),

            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(Opisthotonusbeatunlock.Item, new ItemModdedUnlockInfo(Opisthotonusbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked16", null, 32, null), "EP_Opisthotonus_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Opisthotonus_BossBeat_ACH", "SgilpsSkull_TW");

            UnlockableModData OpisthotonusunlockData = new UnlockableModData("Opisthotonus_EN");
            OpisthotonusunlockData.hasModdedAchievementUnlock = true;
            OpisthotonusunlockData.moddedAchievementID = "EP_Opisthotonus_BossBeat_ACH";
            OpisthotonusunlockData.hasItemUnlock = true;
            OpisthotonusunlockData.items = new string[] { "SgilpsSkull_TW" };

            EnemyDeathUnlockCheck OpisthotonusDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            OpisthotonusDeathUnlock.usesSimpleDeathData = true;
            OpisthotonusDeathUnlock.enemyID = "Opisthotonus_EN";
            OpisthotonusDeathUnlock.simpleDeathData = OpisthotonusunlockData;
            OpisthotonusDeathUnlock.specialDeathData = new SerializableDictionary<string, UnlockableModData>();


            Unlocks.AddUnlock_EnemyDeath(OpisthotonusDeathUnlock);

            ModdedAchievements Opisthotonusach = new ModdedAchievements("Thee I invoke, the Bornless one", "Exorcise the Opisthotonus.", ResourceLoader.LoadSprite("DemonAch", null, 32, null), "EP_Opisthotonus_BossBeat_ACH");
            Opisthotonusach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);


            HealEffect healEffect = ScriptableObject.CreateInstance<HealEffect>();
            healEffect.usePreviousExitValue = true;



            PerformEffectWithFalseSetter_Item Fountainbeatunlock = new PerformEffectWithFalseSetter_Item();
            Fountainbeatunlock.Item_ID = "GlassTube_TW";
            Fountainbeatunlock.Name = "Glass Tube";
            Fountainbeatunlock.Flavour = "\"What yours is mine.\"";
            Fountainbeatunlock.Description = "Prevent this party member's death, upon death kill a random other party member, and heal this party member for the amount of health they had.\nIf there are no other party members do not prevent this party member's death.";
            Fountainbeatunlock.IsShopItem = false;
            Fountainbeatunlock.Icon = ResourceLoader.LoadSprite("FountainUnlock");
            Fountainbeatunlock.ShopPrice = 3;
            Fountainbeatunlock.DoesPopUpInfo = true;
            Fountainbeatunlock.StartsLocked = true;
            Fountainbeatunlock.TriggerOn = TriggerCalls.CanDie;
            Fountainbeatunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathForTubeEffect>(), 1, Targeting.Unit_OtherAllies), Effects.GenerateEffect(healEffect, 1, Targeting.Unit_OtherAllies), };
            Fountainbeatunlock.Conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<OtherPartyMemberEffector>() };


            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(Fountainbeatunlock.Item, new ItemModdedUnlockInfo(Fountainbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked3", null, 32, null), "EP_Fountain_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Fountain_BossBeat_ACH", "GlassTube_TW");

            UnlockableModData FountainunlockData = new UnlockableModData("TheFountainofYouth_EN");
            FountainunlockData.hasModdedAchievementUnlock = true;
            FountainunlockData.moddedAchievementID = "EP_Fountain_BossBeat_ACH";
            FountainunlockData.hasItemUnlock = true;
            FountainunlockData.items = new string[] { "GlassTube_TW" };

            EnemyDeathUnlockCheck FountainDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            FountainDeathUnlock.usesSimpleDeathData = true;
            FountainDeathUnlock.enemyID = "TheFountainofYouth_EN";
            FountainDeathUnlock.simpleDeathData = FountainunlockData;
            FountainDeathUnlock.specialDeathData = new SerializableDictionary<string, UnlockableModData>();


            Unlocks.AddUnlock_EnemyDeath(FountainDeathUnlock);

            ModdedAchievements Fountainach = new ModdedAchievements("Mud Feaster", "Drink the Fountain of Youth.", ResourceLoader.LoadSprite("FountainAch", null, 32, null), "EP_Fountain_BossBeat_ACH");
            Fountainach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);




            Ability fleebility = new Ability("FuckThis_A_0");
            fleebility.Name = "F@#% This!";
            fleebility.Description = "Flee.";
            fleebility.AbilitySprite = ResourceLoader.LoadSprite("FuckAbility");
            fleebility.Cost = new ManaColorSO[] { };
            fleebility.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            fleebility.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });
            fleebility.AnimationTarget = Targeting.Slot_SelfSlot;
            fleebility.Visuals = LoadedAssetsHandler.GetCharacterAbility("Insult_1_A").visuals;

            ExtraAbility_Wearable_SMS extraAbility_Wearable_1 = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
            extraAbility_Wearable_1._extraAbility = fleebility.GenerateCharacterAbility();
          

            PerformEffect_Item Highnessbeatunlock = new PerformEffect_Item();
            Highnessbeatunlock.Item_ID = "PissOff_SW";
            Highnessbeatunlock.Name = "Piss Off";
            Highnessbeatunlock.Flavour = "\"What you think you'd get something good?\"";
            Highnessbeatunlock.Description = "Adds an ability \"F@#% This!\", which allows party members to flee.... coward.";
            Highnessbeatunlock.IsShopItem = true;
            Highnessbeatunlock.Icon = ResourceLoader.LoadSprite("HighnessUnlock");
            Highnessbeatunlock.ShopPrice = 1;
            Highnessbeatunlock.DoesPopUpInfo = true;
            Highnessbeatunlock.StartsLocked = true;
            Highnessbeatunlock.TriggerOn = TriggerCalls.Count;
            Highnessbeatunlock.EquippedModifiers = new WearableStaticModifierSetterSO[] { extraAbility_Wearable_1 };
            Highnessbeatunlock.Effects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Unit_OtherAllies) };



            ItemUtils.AddItemToShopStatsCategoryAndGamePool(Highnessbeatunlock.Item, new ItemModdedUnlockInfo(Highnessbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked6", null, 32, null), "EP_Highness_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Highness_BossBeat_ACH", "PissOff_SW");

            UnlockableModData HighnessunlockData = new UnlockableModData("HeinousHighness_EN");
            HighnessunlockData.hasModdedAchievementUnlock = true;
            HighnessunlockData.moddedAchievementID = "EP_Highness_BossBeat_ACH";
            HighnessunlockData.hasItemUnlock = true;
            HighnessunlockData.items = new string[] { "PissOff_SW" };

            EnemyDeathUnlockCheck HighnessDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            HighnessDeathUnlock.usesSimpleDeathData = true;
            HighnessDeathUnlock.enemyID = "HeinousHighness_EN";
            HighnessDeathUnlock.simpleDeathData = HighnessunlockData;
            HighnessDeathUnlock.specialDeathData = new SerializableDictionary<string, UnlockableModData>();

            

            Unlocks.AddUnlock_EnemyDeath(HighnessDeathUnlock);

            ModdedAchievements Highnessach = new ModdedAchievements("He Wasn't Really Trying You Know...", "Flip the bird on the Heinous Highness.", ResourceLoader.LoadSprite("HighnessAch", null, 32, null), "EP_Highness_BossBeat_ACH");
            Highnessach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);

            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._indirect = true;

            PerformEffect_Item Sachielbeatunlock = new PerformEffect_Item();
            Sachielbeatunlock.Item_ID = "CoinofAvarice_TW";
            Sachielbeatunlock.Name = "Coin of Avarice";
            Sachielbeatunlock.Flavour = "\"There's no cheating this.\"";
            Sachielbeatunlock.Description = "On combat start, deal 1 Indirect damage to all party members.\n50% chance to produce 20 coins. If unsuccessful, instantly kill this party member.\nDoes not work on Nowak or Mung.";
            Sachielbeatunlock.IsShopItem = false;
            Sachielbeatunlock.Icon = ResourceLoader.LoadSprite("SachielUnlock");
            Sachielbeatunlock.ShopPrice = 3;
            Sachielbeatunlock.DoesPopUpInfo = true;
            Sachielbeatunlock.StartsLocked = true;
            Sachielbeatunlock.Conditions = new EffectorConditionSO[] { ScriptableObject.CreateInstance<IsMainCharacterEffectororMungCondition>()};
            Sachielbeatunlock.IsEffectImmediate = false;
            Sachielbeatunlock.TriggerOn = TriggerCalls.OnCombatStart;
            Sachielbeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(damageEffect, 1, Targeting.Unit_AllAllies),
                Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraCurrencyEffect>(), 20, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_SelfSlot,Effects.CheckPreviousEffectCondition(false,1)),
            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(Sachielbeatunlock.Item, new ItemModdedUnlockInfo(Sachielbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked11", null, 32, null), "EP_Sachiel_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_Sachiel_BossBeat_ACH", "CoinofAvarice_TW");

            UnlockableModData SachielunlockData = new UnlockableModData("Sachiel_EN");
            SachielunlockData.hasModdedAchievementUnlock = true;
            SachielunlockData.moddedAchievementID = "EP_Sachiel_BossBeat_ACH";
            SachielunlockData.hasItemUnlock = true;
            SachielunlockData.items = new string[] { "CoinofAvarice_TW" };

            EnemyDeathUnlockCheck SachielDeathUnlock = ScriptableObject.CreateInstance<EnemyDeathUnlockCheck>();
            SachielDeathUnlock.usesSimpleDeathData = true;
            SachielDeathUnlock.enemyID = "Sachiel_EN";
            SachielDeathUnlock.simpleDeathData = SachielunlockData;
            SachielDeathUnlock.specialDeathData = new SerializableDictionary<string, UnlockableModData>();


            Unlocks.AddUnlock_EnemyDeath(SachielDeathUnlock);

            ModdedAchievements Sachielach = new ModdedAchievements("How Many Times do We Have to Teach You this Lesson, Old Man?", "Ransack Sachiel.", ResourceLoader.LoadSprite("SachielAch", null, 32, null), "EP_Sachiel_BossBeat_ACH");
            Sachielach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.ComediesTitleLabel);

            SwapToOneSideEffect swapToOneSideEffect = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapToOneSideEffect._swapRight = false;

            SwapToOneSideEffect swapToOneSideEffect1 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapToOneSideEffect1._swapRight = true;

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Spotlight;

            PerformEffect_Item Allbeatunlock = new PerformEffect_Item();
            Allbeatunlock.Item_ID = "BraggartsMouthpiece_TW";
            Allbeatunlock.Name = "Braggart’s Mouthpiece";
            Allbeatunlock.Flavour = "\"Toot your own horn.\"";
            Allbeatunlock.Description = "Upon killing an enemy gain spotlight, and Move all enemies closer to this party member.";
            Allbeatunlock.IsShopItem = false;
            Allbeatunlock.Icon = ResourceLoader.LoadSprite("BraggartsMouthpiece");
            Allbeatunlock.ShopPrice = 3;
            Allbeatunlock.DoesPopUpInfo = true;
            Allbeatunlock.StartsLocked = true;
            Allbeatunlock.IsEffectImmediate = false;
            Allbeatunlock.TriggerOn = TriggerCalls.OnKill;
            Allbeatunlock.Effects = new EffectInfo[] {

                Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Slot_SelfSlot),
                Effects.GenerateEffect(swapToOneSideEffect, 1, Targeting.Slot_OpponentAllRights),
                Effects.GenerateEffect(swapToOneSideEffect1, 1, Targeting.Slot_OpponentAllLefts),
            };

            ItemUtils.AddItemToTreasureStatsCategoryAndGamePool(Allbeatunlock.Item, new ItemModdedUnlockInfo(Allbeatunlock.Item_ID, ResourceLoader.LoadSprite("UnlocksLocked20", null, 32, null), "EP_AllBosses_BossBeat_ACH"));
            BrutalAPI.BackwardsUnlockCompatibility.TryLockItemBehindAchievement("EP_AllBosses_BossBeat_ACH", "BraggartsMouthpiece_TW");

            UnlockableModData AllBeatunlockData = new UnlockableModData("AllBossesBeaten");
            AllBeatunlockData.hasModdedAchievementUnlock = true;
            AllBeatunlockData.moddedAchievementID = "EP_AllBosses_BossBeat_ACH";
            AllBeatunlockData.hasItemUnlock = true;
            AllBeatunlockData.items = new string[] { "BraggartsMouthpiece_TW" };

            ModdedGroupBossUnlockCheck AllDeathUnlock = ScriptableObject.CreateInstance<ModdedGroupBossUnlockCheck>();
            AllDeathUnlock.unlockData = AllBeatunlockData;
            AllDeathUnlock.unlockID = "AllBossesBeaten";
    


            Unlocks.AddUnlock_PostCombat(AllDeathUnlock);

            ModdedAchievements Allach = new ModdedAchievements("Lord Butcherer", "Defeat all Bosses and Minibosses in the Enemy pack.", ResourceLoader.LoadSprite("BossButchererAch", null, 32, null), "EP_AllBosses_BossBeat_ACH");
            Allach.AddNewAchievementToInGameCategory(AchievementCategoryIDs.BossesTitleLabel);






        }

        
    }
}
