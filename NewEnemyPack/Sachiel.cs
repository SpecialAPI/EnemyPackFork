using BrutalAPI;
using MonoMod.RuntimeDetour;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack
{
    internal class Sachiel
    {
        public static void Add()
        {

            

            IDetour detour2 = new Hook(typeof(CombatStats).GetMethod("PlayerTurnStart", (BindingFlags)(-1)), typeof(Sachiel).GetMethod("ForOnTurnStartForReal", (BindingFlags)(-1)));
            IDetour detour = new Hook(typeof(CombatStats).GetMethod("PlayerTurnEnd", (BindingFlags)(-1)), typeof(Sachiel).GetMethod("ForOnTurnStart", (BindingFlags)(-1)));
            IDetour detour4 = new Hook(typeof(CombatStats).GetMethod("CombatEndTriggered", (BindingFlags)(-1)), typeof(Sachiel).GetMethod("CombatEnd", (BindingFlags)(-1)));
            IDetour detour3 = new Hook(typeof(OverworldManagerBG).GetMethod("Awake", (BindingFlags)(-1)), typeof(Sachiel).GetMethod("GetOverworldBG", (BindingFlags)(-1)));

            SetCasterAnimationParameterEffect demerge = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge._parameterName = "IsClose";
            demerge._parameterValue = 1;

            SetCasterAnimationParameterEffect demerge1 = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge1._parameterName = "IsClose";
            demerge1._parameterValue = 0;


            RemovePassiveEffect removePassive = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            removePassive.m_PassiveID = Passives.Fleeting1.ToString();

            ParasitePassiveAbility parasitePassiveAbility = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
            parasitePassiveAbility.conditions = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.conditions;
            parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;

            parasitePassiveAbility.connectionEffects = new EffectInfo[]  { Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 3, Targeting.Slot_Front),  };

            parasitePassiveAbility.disconnectionEffects = new EffectInfo[] { Effects.GenerateEffect(demerge1, 3, Targeting.Slot_SelfSlot), Effects.GenerateEffect(removePassive, 3, Targeting.Slot_SelfSlot),};

            parasitePassiveAbility.connectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).connectionImmediateEffect;
            parasitePassiveAbility.disconnectionImmediateEffect = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).disconnectionImmediateEffect;
            parasitePassiveAbility.doesPassiveTriggerInformationPanel = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.doesPassiveTriggerInformationPanel;
            parasitePassiveAbility.effects = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).effects;
            parasitePassiveAbility.passiveIcon = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.passiveIcon;
            parasitePassiveAbility.specialStoredData = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd).specialStoredData;
            parasitePassiveAbility.m_PassiveID = Passives.ParasiteMutualism.m_PassiveID;
            parasitePassiveAbility._characterDescription = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._characterDescription;
            parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
            parasitePassiveAbility._enemyDescription = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._characterDescription;
            parasitePassiveAbility._isFriendly = true;
            parasitePassiveAbility._parasiteShield = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._parasiteShield;
            parasitePassiveAbility._passiveName = "Mutualism";
            parasitePassiveAbility._secondTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
            parasitePassiveAbility._thirdTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
            parasitePassiveAbility._triggerOn = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._triggerOn;

            AddPassiveEffect addPassiveEffect = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addPassiveEffect._passiveToAdd = parasitePassiveAbility;

            SwapToOneSideEffect swapToOneSide = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapToOneSide._swapRight = false;

            SwapToOneSideEffect swapToOneSide1 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapToOneSide1._swapRight = true;

            ExtraLootEffect extraLoot = ScriptableObject.CreateInstance<ExtraLootEffect>();
            extraLoot._isTreasure = true;
            extraLoot._getLocked = false;

            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.wasSuccessful = true;

            AnimationVisualsEffect animationVisuals = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisuals._animationTarget = Targeting.Slot_Front;
            animationVisuals._visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;

            MultiPreviousEffectCondition multiPreviousEffectCondition = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multiPreviousEffectCondition.wasSuccessful = new bool[] { true, false };
            multiPreviousEffectCondition.previousAmount = new int[] { 2, 1 };


            MultiPreviousEffectCondition multiPreviousEffectCondition1 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multiPreviousEffectCondition1.wasSuccessful = new bool[] { true, false };
            multiPreviousEffectCondition1.previousAmount = new int[] { 3, 2 };


            MultiPreviousEffectCondition multiPreviousEffectCondition2 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multiPreviousEffectCondition2.wasSuccessful = new bool[] { true, false };
            multiPreviousEffectCondition2.previousAmount = new int[] { 4, 3 };

            MultiPreviousEffectCondition multiPreviousEffectCondition3 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multiPreviousEffectCondition3.wasSuccessful = new bool[] { true, false };
            multiPreviousEffectCondition3.previousAmount = new int[] { 5, 4 };


            MultiPreviousEffectCondition multiPreviousEffectCondition4 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multiPreviousEffectCondition4.wasSuccessful = new bool[] { true, false };
            multiPreviousEffectCondition4.previousAmount = new int[] { 6, 5 };

            MultiPreviousEffectCondition multiPreviousEffectCondition5 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multiPreviousEffectCondition5.wasSuccessful = new bool[] { true, false };
            multiPreviousEffectCondition5.previousAmount = new int[] { 7, 6 };

            CheckIsAliveEffect checkIsAliveEffect = ScriptableObject.CreateInstance<CheckIsAliveEffect>();
            checkIsAliveEffect._checkByHealth = true;

            CasterStoredValueParasiteEffect storedValueParasiteEffect = ScriptableObject.CreateInstance<CasterStoredValueParasiteEffect>();
            storedValueParasiteEffect._usePreviousExitValue = ((StoredValueParasiteEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[4].effect)._usePreviousExitValue;
            storedValueParasiteEffect._initialize = true;

            CheckPassiveAbilityEffect checkPassiveAbilityEffect = ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>();
            checkPassiveAbilityEffect.m_PassiveID = Passives.ParasiteMutualism.m_PassiveID;

            TargetBoxingEffect targetBoxingEffect = ScriptableObject.CreateInstance<TargetBoxingEffect>();
            targetBoxingEffect._exitType = CombatType_GameIDs.Exit_Boxing.ToString();
            targetBoxingEffect._unboxHandler = ((CasterBoxingEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[6].effect)._unboxHandler;


            SachielFleetingPassiveAbility fleetingPassive = ScriptableObject.CreateInstance<SachielFleetingPassiveAbility>();
            fleetingPassive.conditions = Passives.Fleeting1.conditions;
            fleetingPassive.doesPassiveTriggerInformationPanel = Passives.Fleeting1.doesPassiveTriggerInformationPanel;
            fleetingPassive.passiveIcon = Passives.Fleeting1.passiveIcon;
            fleetingPassive.m_PassiveID = Passives.Fleeting1.m_PassiveID;
            fleetingPassive._ignoreFirstTurn = false;
            fleetingPassive._triggerOn = Passives.Fleeting1._triggerOn;
            fleetingPassive._turnsBeforeFleeting = 2;
            fleetingPassive._characterDescription = "";
            fleetingPassive._enemyDescription = "After 1 Round this enemy will Flee.";
            fleetingPassive._passiveName = "Fleeting(1)";

            SaveBoolSetterEffect saveBoolSetterEffect = ScriptableObject.CreateInstance<SaveBoolSetterEffect>();
            saveBoolSetterEffect.settotrue = false;
            saveBoolSetterEffect.variablename = "SachielEntered";

            DeathReferenceDetectionEffectorCondition deathReferenceDetectionEffectorCondition = ScriptableObject.CreateInstance<DeathReferenceDetectionEffectorCondition>();
            deathReferenceDetectionEffectorCondition._useWithering = true;
            deathReferenceDetectionEffectorCondition._witheringDeath = true;

            
            

            SachielFormless sachielFormless = ScriptableObject.CreateInstance<SachielFormless>();
            sachielFormless.conditions = Passives.Formless.conditions;
            sachielFormless.doesPassiveTriggerInformationPanel = Passives.Formless.doesPassiveTriggerInformationPanel;
            sachielFormless._secondDoesPerformPopUp = false;
            sachielFormless.m_PassiveID = Passives.Formless.m_PassiveID;
            sachielFormless._passiveName = Passives.Formless._passiveName;
            sachielFormless.passiveIcon = Passives.Formless.passiveIcon;
            sachielFormless._characterDescription = Passives.Formless._characterDescription;
            sachielFormless._enemyDescription = Passives.Formless._enemyDescription;
            sachielFormless._triggerOn = Passives.Formless._triggerOn;
            sachielFormless._secondPerformConditions = new EffectorConditionSO[] { deathReferenceDetectionEffectorCondition };
            sachielFormless._secondTriggerOn = new TriggerCalls[] { TriggerCalls.OnDeath};
            sachielFormless._secondEffects = new EffectInfo[] { Effects.GenerateEffect(saveBoolSetterEffect, 0, Targeting.Slot_SelfSlot) };




            Enemy enemy = new Enemy("Sachiel", "Sachiel_EN");
            enemy.Health = 52;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(3);
            enemy.CombatSprite = ResourceLoader.LoadSprite("SachielIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("SachielIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("SachielIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Sachiel/SachielHurt";
            enemy.DeathSound = "event:/Sachiel/SachielDeath";
            enemy.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(ScriptableObject.CreateInstance<SachielRoarEffect>(), 1, Targeting.Slot_Front), };
            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, sachielFormless, Passives.MultiAttack2 });
            enemy.PrepareEnemyPrefab("Assets/Sachiel/Sachiel.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Sachiel/SachielGibs.prefab").GetComponent<ParticleSystem>());

            AddPassiveEffect passiveEffect = ScriptableObject.CreateInstance<AddPassiveEffect>();
            passiveEffect._passiveToAdd = fleetingPassive;

            TryUnlockAchievementEffect tryUnlockAchievement = ScriptableObject.CreateInstance<TryUnlockAchievementEffect>();
            tryUnlockAchievement._unlockID = "SachielTragedy";

            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._indirect = true;

            SwapCasterPassivesEffect swapCasterPassives = ScriptableObject.CreateInstance<SwapCasterPassivesEffect>();
            swapCasterPassives._passivesToSwap = new BasePassiveAbilitySO[] { sachielFormless, Passives.MultiAttack2, fleetingPassive };

            Ability ability = new Ability("Barter_A");
            ability.Name = "Barter";
            ability.Description = "Move this enemy to the Left.\nDeal a Little Indirect damage to the Opposing party member.\nIf the Opposing party member has an item, permanetly change it to a random treasure item.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(swapToOneSide, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisuals, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<TradeItemEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SachielCustomCheckUnitEffect>(), 1, Targeting.Slot_Front, Effects.ChanceCondition(7)),
                  Effects.GenerateEffect(checkPassiveAbilityEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapCasterPassives, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition),
                  Effects.GenerateEffect(storedValueParasiteEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition1),
                  Effects.GenerateEffect(addPassiveEffect, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition2),
                  Effects.GenerateEffect(targetBoxingEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition3),
                  Effects.GenerateEffect(demerge, 1, Targeting.Slot_Front,multiPreviousEffectCondition4),
                  Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition5),
                  Effects.GenerateEffect(damageEffect, 2, Targeting.Slot_Front),

            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });

            Ability ability1 = new Ability("Trade_A");
            ability1.Name = "Trade";
            ability1.Description = "Move this enemy to the Right.\nDeal a Little Indirect damage to the Opposing party member.\nIf the Opposing party member has an item, permanetly change it to a random treasure item.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(swapToOneSide1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisuals, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<TradeItemEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SachielCustomCheckUnitEffect>(), 1, Targeting.Slot_Front, Effects.ChanceCondition(7)),
                  Effects.GenerateEffect(checkPassiveAbilityEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapCasterPassives, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition),
                  Effects.GenerateEffect(storedValueParasiteEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition1),
                  Effects.GenerateEffect(addPassiveEffect, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition2),
                  Effects.GenerateEffect(targetBoxingEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition3),
                  Effects.GenerateEffect(demerge, 1, Targeting.Slot_Front,multiPreviousEffectCondition4),
                  Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition5),
                  Effects.GenerateEffect(damageEffect, 2, Targeting.Slot_Front),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });



            Ability ability11 = new Ability("FairPrice_A");
            ability11.Name = "Fair Price";
            ability11.Description = "Move this enemy Left or Right.\nSteal 3 coins from the Opposing party member. If the Opposing party member has an item, produce 6 coins.";
            ability11.Rarity = Abil.Weight(5);
            ability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisuals, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<LosePlayerCurrencyEffect>(), 3, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ProduceCoinsIfUnitHasItemEffect>(), 6, Targeting.Slot_Front, Effects.CheckPreviousEffectCondition(true,2)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SachielCustomCheckUnitEffect>(), 1, Targeting.Slot_Front, Effects.ChanceCondition(7)),
                  Effects.GenerateEffect(checkPassiveAbilityEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapCasterPassives, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition),
                  Effects.GenerateEffect(storedValueParasiteEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition1),
                  Effects.GenerateEffect(addPassiveEffect, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition2),
                  Effects.GenerateEffect(targetBoxingEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition3),
                  Effects.GenerateEffect(demerge, 1, Targeting.Slot_Front,multiPreviousEffectCondition4),
                  Effects.GenerateEffect(tryUnlockAchievement, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition5),
             


            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Misc_Currency.ToString() });


            Ability ability111 = new Ability("SockLeft_A");
            ability111.Name = "Sock Left";
            ability111.Description = "Deal a Painful amount of damage to the Left party member.";
            ability111.Rarity = Abil.Weight(4);
            ability111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentLeft),


            };
            ability111.AddIntentsToTarget(Targeting.Slot_OpponentLeft, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability111.AnimationTarget = Targeting.Slot_OpponentLeft;
            ability111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;

            Ability ability1111 = new Ability("WallopRight_A");
            ability1111.Name = "Wallop Right";
            ability1111.Description = "Deal a Painful amount of damage to the Right party member.";
            ability1111.Rarity = Abil.Weight(4);
            ability1111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentRight),


            };
            ability1111.AddIntentsToTarget(Targeting.Slot_OpponentRight, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1111.AnimationTarget = Targeting.Slot_OpponentRight;
            ability1111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;


            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11, ability111, ability1111 });
            enemy.AddEnemy(false, false, false);


        }

        


        public static void GetOverworldBG(MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers.Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            Sachiel.overManager = self;

        }

        public static void ForOnTurnStartForReal(MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers.Action<CombatStats> orig, CombatStats self)
        {
            Debug.Log(LoadedDBsHandler.InfoHolder.Run.inGameData.GetIntData("SachielSplash"));

            int percent = 0;
            int numberofitems = 0;
            for (int i = 0; i < overManager._informationHolder.Run.playerData._itemList.Length; i++)
            {
                if (overManager._informationHolder.Run.playerData._itemList[i] != null)
                {
                    numberofitems++;
                }
            }
            percent = numberofitems - 8;
            percent = 1 + percent;

            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Sachiel/SachielWarning";
            attackVisualsSO.isAnimationFullScreen = true; ;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Sachiel/SachielSplash.anim");

            SachielAnimationVisualsEffect sachielAnimationVisuals = ScriptableObject.CreateInstance<SachielAnimationVisualsEffect>();
            sachielAnimationVisuals._animationTarget = Targeting.Slot_SelfSlot;
            sachielAnimationVisuals._visuals = attackVisualsSO;

            EffectInfo[] effect = new EffectInfo[] { Effects.GenerateEffect(sachielAnimationVisuals, 1, Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 })) };

            if (LoadedDBsHandler.InfoHolder.Run.inGameData.GetIntData("SachielSplash") == 1)
            {

                LoadedDBsHandler.InfoHolder.Run.inGameData.SetIntData("SachielSplash", 2);

            }
            

            if (UnityEngine.Random.Range(0, 100) < percent && numberofitems >= 8 && !LoadedDBsHandler.InfoHolder.Run.inGameData.GetBoolData("BronzoSpawn") && !LoadedDBsHandler.InfoHolder.Run.inGameData.GetBoolData("SachielEntered") && LoadedDBsHandler.InfoHolder.Run.inGameData.GetIntData("SachielSplash") < 1)
            {

                if (Random.Range(0, 100) >= 50)
                {
                    CombatManager.Instance.AddSubAction(new EffectAction(effect, CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value, 0));
          
                }
            }



            orig(self);
        }

        public static void CombatEnd(MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers.Action<CombatStats> orig, CombatStats self)
        {

            LoadedDBsHandler.InfoHolder.Run.inGameData.SetIntData("SachielSplash",0);
            orig(self);
        }

        public static void ForOnTurnStart(MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers.Action<CombatStats> orig, CombatStats self)
        {




            SpawnSachielEnemyAnywhereEffect spawnSachielEnemyAnywhereEffect = ScriptableObject.CreateInstance<SpawnSachielEnemyAnywhereEffect>();
            spawnSachielEnemyAnywhereEffect.enemy = LoadedAssetsHandler.GetEnemy("Sachiel_EN");
            spawnSachielEnemyAnywhereEffect.givesExperience = true;
            spawnSachielEnemyAnywhereEffect._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            EffectInfo[] effect = new EffectInfo[] { Effects.GenerateEffect(spawnSachielEnemyAnywhereEffect, 1, Targeting.GenerateSlotTarget(new int[] {-4,-3,-2,-1,0,1,2,3,4})) };

        

            if (!LoadedDBsHandler.InfoHolder.Run.inGameData.GetBoolData("BronzoSpawn") && !LoadedDBsHandler.InfoHolder.Run.inGameData.GetBoolData("SachielEntered") && LoadedDBsHandler.InfoHolder.Run.inGameData.GetIntData("SachielSplash") == 2)
            {
          
                CombatManager.Instance.AddSubAction(new EffectAction(effect, CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value, 0));

            }
            orig(self);

        }

        public static OverworldManagerBG overManager = null;
    }
}
