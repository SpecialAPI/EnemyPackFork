using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Nephilim
    {
        public static void Add()
        {
            SetCasterAnimationParameterEffect demerge = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge._parameterName = "IsClose";
            demerge._parameterValue = 1;

            SetCasterAnimationParameterEffect demerge1 = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge1._parameterName = "IsClose";
            demerge1._parameterValue = 0;


            ParasitePassiveAbility parasitePassiveAbility = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
            parasitePassiveAbility.conditions = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd.conditions;
            parasitePassiveAbility._damagePercentage = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._damagePercentage;
            
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
            parasitePassiveAbility._passiveName = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._passiveName;
            parasitePassiveAbility._secondTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._secondTriggerOn;
            parasitePassiveAbility._thirdTriggerOn = ((ParasitePassiveAbility)((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd)._thirdTriggerOn;
            parasitePassiveAbility._triggerOn = ((AddPassiveEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[5].effect)._passiveToAdd._triggerOn;
            parasitePassiveAbility.connectionEffects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot),
            };
            parasitePassiveAbility.disconnectionEffects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 99, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 99, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(demerge1, 1, Targeting.Slot_SelfSlot),
            };


            AddPassiveEffect addPassiveEffect = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addPassiveEffect._passiveToAdd = parasitePassiveAbility;

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

            CheckIsAliveEffect checkIsAliveEffect = ScriptableObject.CreateInstance<CheckIsAliveEffect>();
            checkIsAliveEffect._checkByHealth = true;

            CasterStoredValueParasiteEffect storedValueParasiteEffect = ScriptableObject.CreateInstance<CasterStoredValueParasiteEffect>();
            storedValueParasiteEffect._usePreviousExitValue = ((StoredValueParasiteEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[4].effect)._usePreviousExitValue;
            storedValueParasiteEffect._initialize = true;

            CheckPassiveAbilityEffect checkPassiveAbilityEffect = ScriptableObject.CreateInstance<CheckPassiveAbilityEffect>();
            checkPassiveAbilityEffect.m_PassiveID = Passives.ParasiteParasitism.m_PassiveID;

           
            TargetBoxingEffect targetBoxingEffect = ScriptableObject.CreateInstance<TargetBoxingEffect>();
            targetBoxingEffect._exitType = CombatType_GameIDs.Exit_Boxing.ToString();
            targetBoxingEffect._unboxHandler = ((CasterBoxingEffect)LoadedAssetsHandler.GetCharacterAbility("Symbiosis_1_A").effects[6].effect)._unboxHandler;

            SwapCasterAbilitiesEffect swapCaster = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = Passives.ParasiteMutualism.passiveIcon;
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("MutualismIntent", InfestIntent);

            RemovePassiveEffect removePassiveEffect = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            removePassiveEffect.m_PassiveID = Passives.ParasiteMutualism.m_PassiveID;

            Enemy enemy = new Enemy("Nephilim", "Nephilim_EN");
            enemy.Health = 25;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("NephelimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("NephelimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("NephelimCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Ungod_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Ungod_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Forgetful, Passives.Formless });
            enemy.PrepareEnemyPrefab("Assets/Nephelim/Nephelim.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Nephelim/NephilimGibs.prefab").GetComponent<ParticleSystem>());




            Ability ability = new Ability("Thwart_A");
            ability.Name = "Thwart";
            ability.Description = "This enemy attempts to grasp the Opposing party member between its fingers and applies an amount of Mutualism to itself equal to the party member's current health.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(checkPassiveAbilityEffect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(storedValueParasiteEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition),
                  Effects.GenerateEffect(addPassiveEffect, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition1),
                  Effects.GenerateEffect(targetBoxingEffect, 1, Targeting.Slot_Front,multiPreviousEffectCondition2),
                  Effects.GenerateEffect(demerge, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition3),
                  Effects.GenerateEffect(swapCaster, 1, Targeting.Slot_SelfSlot,multiPreviousEffectCondition4),

            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "MutualismIntent" });
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;

            Ability ability1 = new Ability("Lob_A");
            ability1.Name = "Lob";
            ability1.Description = "Deal an Agonizing amount of damage to the Opposing party member.\nRelease the currently grasped party member.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 10, Targeting.Slot_Front),
                  Effects.GenerateEffect(removePassiveEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability1.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Stunned;

            Ability ability11 = new Ability("SlapofGod_A");
            ability11.Name = "Slap of God";
            ability11.Description = "\"*deep Inhale*\"\nDeals almost no damage to the Opposing party member. Inflict 1 Stun to the Opposing party member.";
            ability11.Rarity = Abil.Weight(10);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Slot_Front),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Stunned.ToString() });
            ability11.AnimationTarget = Targeting.Slot_Front;
            ability11.Visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            ability11.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;


            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.rarity = Abil.Weight(10);
            extraAbilityInfo.ability = ability1.ability;

            ExtraAbilityInfo extraAbilityInfo1 = new ExtraAbilityInfo();
            extraAbilityInfo1.rarity = Abil.Weight(10);
            extraAbilityInfo1.ability = ability11.ability;

            ExtraAbilityInfo extraAbilityInfo11 = new ExtraAbilityInfo();
            extraAbilityInfo11.rarity = Abil.Weight(10);
            extraAbilityInfo11.ability = LoadedAssetsHandler.GetEnemyAbility("Bash_A");

            swapCaster._abilitiesToSwap = new ExtraAbilityInfo[] { extraAbilityInfo, extraAbilityInfo1, extraAbilityInfo11 };

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Bash_A");
            enemyAbilityInfo.rarity = Abil.Weight(10);

            enemy.AddEnemyAbilities(new Ability[] { ability, ability11 });
            enemy.enemy.abilities.Add(enemyAbilityInfo);
            enemy.AddEnemy(true, true, false);

           

        }
    }
}
