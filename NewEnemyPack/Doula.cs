using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace NewEnemyPack
{
    internal class Doula
    {
        public static void Add()
        {

            CasterStoredValueChangeEffect casterStoredValueChangeEffect1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect1.m_unitStoredDataID = "DoulaAnim";
            casterStoredValueChangeEffect1._minimumValue = 0;
            casterStoredValueChangeEffect1._increase = true;

            CasterStoredValueChangeEffect casterStoredValueChangeEffect11 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect11.m_unitStoredDataID = "DoulaAnim";
            casterStoredValueChangeEffect11._minimumValue = 0;
            casterStoredValueChangeEffect11._increase = false;

            PerformDoubleEffectPassiveAbility skittish = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
            skittish._passiveName = Passives.Skittish._passiveName;
            skittish.m_PassiveID = Passives.Skittish.m_PassiveID;
            skittish.passiveIcon = Passives.Skittish.passiveIcon;
            skittish._enemyDescription = Passives.Skittish._enemyDescription;
            skittish._characterDescription = Passives.Skittish._characterDescription;
            skittish.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            skittish._triggerOn = Passives.Skittish._triggerOn;
            skittish._secondDoesPerformPopUp = false;
            skittish._secondTriggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy };
            skittish._secondEffects = new EffectInfo[]
            {
                  Effects.GenerateEffect(casterStoredValueChangeEffect1, 1, Targeting.Slot_SelfSlot),

            };

            SpecialSceneEndingSetUpEffect endingSetUpEffect = ScriptableObject.CreateInstance<SpecialSceneEndingSetUpEffect>();
            endingSetUpEffect._shouldCombatEnd = false;
            endingSetUpEffect._specialScene = SpecialSceneType.HardEnding;


            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Attacks/DoulaAttack";
            attackVisualsSO.isAnimationFullScreen = true; ;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Doula/DoulaAttackAnim.anim");

            IntegerSetterByStoredValuePassiveAbility integerSetterByStoredValuePassiveAbility = ScriptableObject.CreateInstance<IntegerSetterByStoredValuePassiveAbility>();
            integerSetterByStoredValuePassiveAbility.doesPassiveTriggerInformationPanel = false;
            integerSetterByStoredValuePassiveAbility.passiveIcon = LoadedAssetsHandler.GetEnemy("Conductor_EN").passiveAbilities[1].passiveIcon;
            integerSetterByStoredValuePassiveAbility._enemyDescription = "This enemy will perform a specific number actions each turn.";
            integerSetterByStoredValuePassiveAbility._characterDescription = "This enemy will perform a specific number actions each turn.";
            integerSetterByStoredValuePassiveAbility.postIncreaseValue = 0;
            integerSetterByStoredValuePassiveAbility.unitStoredDataID = "DoulaMultiAttack";
            integerSetterByStoredValuePassiveAbility._triggerOn = new TriggerCalls[] { TriggerCalls.AttacksPerTurn };
            integerSetterByStoredValuePassiveAbility._postIncreaseStored = true;
            integerSetterByStoredValuePassiveAbility._passiveName = "MultiAttack";
            integerSetterByStoredValuePassiveAbility.m_PassiveID = Passives.MultiAttack2.m_PassiveID;

            CasterStoredValueChangeEffect casterStoredValueChangeEffect = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect.m_unitStoredDataID = "DoulaMultiAttack";
            casterStoredValueChangeEffect._minimumValue = 0;
            casterStoredValueChangeEffect._increase = true;

            UnitStoreData_ModIntSO dogfoodvalue = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            dogfoodvalue.m_Text = "Multi-Attack: {0}";
            dogfoodvalue._UnitStoreDataID = "DoulaMultiAttack";
            dogfoodvalue.m_TextColor = new Color32(221, 0, 55, 255);
            dogfoodvalue.m_CompareDataToThis = 0;
            dogfoodvalue.m_ShowIfDataIsOver = true;
            LoadedDBsHandler.MiscDB.AddNewUnitStoreData("DoulaMultiAttack", dogfoodvalue);

            UnitStoreData_ModIntSO dogfoodvalue1 = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            dogfoodvalue1.m_Text = "Damage: {0}";
            dogfoodvalue1._UnitStoreDataID = "DoulaAttack";
            dogfoodvalue1.m_TextColor = new Color32(221, 0, 55, 255);
            dogfoodvalue1.m_CompareDataToThis = 0;
            dogfoodvalue1.m_ShowIfDataIsOver = true;
            LoadedDBsHandler.MiscDB.AddNewUnitStoreData("DoulaAttack", dogfoodvalue1);

            Enemy doula = new Enemy("Doula", "Doula_BOSS");
            doula.Health = 175;
            doula.HealthColor = Pigments.Purple;
            doula.Size = 1;
            doula.Priority = Priority.Weight(-5);
            doula.CombatEnterEffects = new EffectInfo[]
            {
                  Effects.GenerateEffect(casterStoredValueChangeEffect, 1, Targeting.Slot_SelfSlot),Effects.GenerateEffect(endingSetUpEffect, 1, Targeting.Slot_SelfSlot),

            };
            doula.CombatSprite = ResourceLoader.LoadSprite("DoulaIcon", new Vector2?(new Vector2(0.5f, 0f)));
            doula.OverworldAliveSprite = ResourceLoader.LoadSprite("DoulaIcon", new Vector2?(new Vector2(0.5f, 0f)));
            doula.OverworldDeadSprite = ResourceLoader.LoadSprite("DoulaIcon", new Vector2?(new Vector2(0.5f, 0f)));
            doula.DamageSound = LoadedAssetsHandler.GetEnemy("Visage_Father_EN").damageSound;
            doula.DeathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;

            doula.AddPassives(new BasePassiveAbilitySO[] { skittish, integerSetterByStoredValuePassiveAbility });
            doula.PrepareEnemyPrefab("Assets/Doula/Doula.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Doula/DoulaGib.prefab").GetComponent<ParticleSystem>());


            DamageByStoredValueEffect damageByStoredValueEffect = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
            damageByStoredValueEffect.m_unitStoredDataID = "DoulaAttack";

            

            AnimationVisualsIfStoredValueEffect doulanaim = ScriptableObject.CreateInstance<AnimationVisualsIfStoredValueEffect>();
            doulanaim.valueName = "DoulaAnim";
            doulanaim._animationTarget = Targeting.Slot_Front;
            doulanaim._visuals = attackVisualsSO;


            TargetStoredValueChangeIfPassiveEffect effectattack11 = ScriptableObject.CreateInstance<TargetStoredValueChangeIfPassiveEffect>();
            effectattack11._minimumValue = 3;
            effectattack11._valueName = "DoulaAttack";
            effectattack11._increase = false;
            effectattack11.passiveAbilitytype = Passives.MultiAttack3.m_PassiveID;
            effectattack11._randomBetweenPrevious = true;

            SpawnRandomEnemyAnywhereEffect move = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();

            TargetStoredValueChangeIfPassiveEffect effectturn1 = ScriptableObject.CreateInstance<TargetStoredValueChangeIfPassiveEffect>();
            effectturn1._minimumValue = 1;
            effectturn1._valueName = "DoulaMultiAttack";
            effectturn1._increase = false;
            effectturn1.passiveAbilitytype = Passives.MultiAttack2.m_PassiveID;

            

            Ability violator = new Ability("Violator_A");
            violator.Name = "Violator";
            violator.Description = "Deals a Painful amount of damage to the Opposing party member.\nSpawn as many Deer as possible.\nIf spawning was successful lower the Doula's damage by 1-2, 50% chance to lower the Multi-Attack by 1 as well.";
            violator.Rarity = Abil.Weight(6);
            violator.Effects = new EffectInfo[]
            {


                  //Effects.GenerateEffect(doulanaim, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(move, 4, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(damageByStoredValueEffect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(casterStoredValueChangeEffect11, 2, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DoulaDeerChecker>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(effectattack11, 2, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,2)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(effectturn1, 1, Targeting.Slot_SelfSlot, Effects.CheckMultiplePreviousEffectsCondition(new bool[]{true, true}, new int[]{1, 4})),


            };
            violator.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            violator.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Misc.ToString() });
            violator.AnimationTarget = Targeting.Slot_Front;
            violator.Visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;

            doula.AddEnemyAbilities(new Ability[] { violator});
            doula.AddEnemy(true, false, false);

            TargetStoredValueChangeIfPassiveEffect effectturn = ScriptableObject.CreateInstance<TargetStoredValueChangeIfPassiveEffect>();
            effectturn._minimumValue = 1;
            effectturn._valueName = "DoulaMultiAttack";
            effectturn._increase = true;
            effectturn.passiveAbilitytype = Passives.MultiAttack3.m_PassiveID;

            TargetStoredValueChangeIfPassiveEffect effectattack = ScriptableObject.CreateInstance<TargetStoredValueChangeIfPassiveEffect>();
            effectattack._minimumValue = 3;
            effectattack._valueName = "DoulaAttack";
            effectattack._increase = true;
            effectattack.passiveAbilitytype = Passives.MultiAttack3.m_PassiveID;

            StatusEffect_ApplyIfNoPassive_Effect status = ScriptableObject.CreateInstance<StatusEffect_ApplyIfNoPassive_Effect>();
            status._Status = StatusField.Scars;

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = Passives.MultiAttack2.passiveIcon;
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("MultiIntent", InfestIntent);


            Enemy deer = new Enemy("Deer", "Deer_EN");
            deer.Health = 25;
            deer.HealthColor = Pigments.Red;
            deer.Size = 1;

            deer.CombatSprite = ResourceLoader.LoadSprite("DeerProperIcon", new Vector2?(new Vector2(0.5f, 0f)));
            deer.OverworldAliveSprite = ResourceLoader.LoadSprite("DeerProperIcon", new Vector2?(new Vector2(0.5f, 0f)));
            deer.OverworldDeadSprite = ResourceLoader.LoadSprite("DeerProperIcon", new Vector2?(new Vector2(0.5f, 0f)));
            deer.DamageSound = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").damageSound;
            deer.DeathSound = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").deathSound;

            deer.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Formless });
            deer.PrepareEnemyPrefab("Assets/Doula/Deer.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Doula/DeerGibs.prefab").GetComponent<ParticleSystem>());

            Ability deerability = new Ability("NoBruises_A");
            deerability.Name = "No Bruises";
            deerability.Description = "Increase the Doula's Attack damage by 2.";
            deerability.Rarity = Abil.Weight(70);
            deerability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(effectattack,2, Targeting.Unit_OtherAllies),


            };
            deerability.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Misc.ToString() });
            deerability.AnimationTarget = Targeting.Slot_SelfSlot;
            deerability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;

            Ability deerability1 = new Ability("NoWords_A");
            deerability1.Name = "No Words";
            deerability1.Description = "Increase the Doula's MultiAttack by 1.";
            deerability1.Rarity = Abil.Weight(45);
            deerability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(effectturn,1, Targeting.Unit_OtherAllies),


            };
            deerability1.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { "MultiIntent" });
            deerability1.AnimationTarget = Targeting.Slot_SelfSlot;
            deerability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;

            Ability deerability11 = new Ability("Gestate_A");
            deerability11.Name = "Gestate";
            deerability11.Description = "Apply 3 Scars to every deer.\n\"It shouldn't have been you\"";
            deerability11.Rarity = Abil.Weight(20);
            deerability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(status,3, Targeting.Unit_AllAllies),


            };
            deerability11.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { IntentType_GameIDs.Status_Scars.ToString() });
            deerability11.AnimationTarget = Targeting.Slot_SelfSlot;
            deerability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;

            deer.AddEnemyAbilities(new Ability[] { deerability, deerability1, deerability11 });
            deer.AddEnemy(true, false, false);

            Enemy stag = new Enemy("Stag", "Stag_EN");
            stag.Health = 25;
            stag.HealthColor = Pigments.Red;
            stag.Size = 1;

            stag.CombatSprite = ResourceLoader.LoadSprite("StagIcon", new Vector2?(new Vector2(0.5f, 0f)));
            stag.OverworldAliveSprite = ResourceLoader.LoadSprite("StagIcon", new Vector2?(new Vector2(0.5f, 0f)));
            stag.OverworldDeadSprite = ResourceLoader.LoadSprite("StagIcon", new Vector2?(new Vector2(0.5f, 0f)));
            stag.DamageSound = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").damageSound;
            stag.DeathSound = LoadedAssetsHandler.GetEnemy("HeavensGateRed_BOSS").deathSound;

            stag.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Formless, Passives.Forgetful });
            stag.PrepareEnemyPrefab("Assets/Doula/Stag.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Doula/HornedDeerGibs.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_Effect._Status = StatusField.Ruptured;


            TargetStoredValueChangeIfPassiveEffect effectattack1 = ScriptableObject.CreateInstance<TargetStoredValueChangeIfPassiveEffect>();
            effectattack1._minimumValue = 3;
            effectattack1._valueName = "DoulaAttack";
            effectattack1._increase = false;
            effectattack1.passiveAbilitytype = Passives.MultiAttack3.m_PassiveID;

            Ability ability = new Ability("Regret_A");
            ability.Name = "Regret";
            ability.Description = "Instantly kill the Opposing party member.\nIf succesful reset all of Doula's values.";
            ability.Rarity = Abil.Weight(20);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(effectturn1, 999, Targeting.Unit_OtherAllies, Effects.CheckPreviousEffectCondition(true,1)),
                  Effects.GenerateEffect(effectattack1, 999, Targeting.Unit_OtherAllies, Effects.CheckPreviousEffectCondition(true,2)),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_Death.ToString(), });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_State_Sit.ToString(), });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = attackVisualsSO;


            Ability ability1 = new Ability("IntrudingOsteophagy_A");
            ability1.Name = "Intruding Osteophagy";
            ability1.Description = "Deal a Painful amount of Damage to the Opposing enemy.\nInflict 2 Ruptured to the Opposing enemy.\nDecrease Doula's damage by 1, 50% chance to decrease Doula's MultiAttack by 1 as well.";
            ability1.Rarity = Abil.Weight(35);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_Front),
                    Effects.GenerateEffect(statusEffect_Apply_Effect, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(effectturn1, 1, Targeting.Unit_OtherAllies,Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(effectattack1, 1, Targeting.Unit_OtherAllies),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_State_Sit.ToString(), });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Osteophagy_A").visuals;

            Ability ability11 = new Ability("IntheHeadlights_A");
            ability11.Name = "In the Headlights";
            ability11.Description = "This enemy forfeits it's turn.\n\"Got caught\"";
            ability11.Rarity = Abil.Weight(20);
            ability11.Effects = new EffectInfo[]
            {

                    Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Unit_OtherAllies),


            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });

            stag.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            stag.AddEnemy(true, false, false);

            move._enemies = new List<EnemySO> { deer.enemy, deer.enemy, deer.enemy, deer.enemy, stag.enemy };
            move._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

        }

    }
}
