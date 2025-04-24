using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn;
using static UnityEngine.EventSystems.EventTrigger;

namespace NewEnemyPack
{
    internal class Neoplasms
    {
        public static void Add()
        {
            IsAliveEffectorCondition alive = ScriptableObject.CreateInstance<IsAliveEffectorCondition>();
            alive.checkByCurrentHealth = true;

            ChangeMusicParameterEffect heapMusicParameter = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            heapMusicParameter._parameter = (MusicParameter)778932;
            heapMusicParameter._addition = true;

            ChangeMusicParameterEffect heapMusicParameter1 = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            heapMusicParameter1._parameter = (MusicParameter)778932;
            heapMusicParameter1._addition = false;

            ChangeMusicParameterEffect lakeMusicParameter = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            lakeMusicParameter._parameter = (MusicParameter)778933;
            lakeMusicParameter._addition = true;

            ChangeMusicParameterEffect lakeMusicParameter1 = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            lakeMusicParameter1._parameter = (MusicParameter)778933;
            lakeMusicParameter1._addition = false;

            DeathReferenceSlimeCondition deathReference = ScriptableObject.CreateInstance<DeathReferenceSlimeCondition>();
            deathReference._witheringDeath = false;
            deathReference._useWithering = true;

            PerformEffectPassiveAbility twofaced = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();

            twofaced._passiveName = "Two-Faced";
            twofaced.passiveIcon = ResourceLoader.LoadSprite("TwoFaced4");
            twofaced.m_PassiveID = Passives.TwoFaced.m_PassiveID;
            twofaced._enemyDescription = "When this enemy receives direct damage, its health color changes between Red and Yellow.";
            twofaced._characterDescription = "When this party member receives direct damage, its health color changes between Red and Yellow.";
            twofaced.conditions = new EffectorConditionSO[] { alive };

            ChangeCasterHealthColorBetweenColorsEffect healthcolors = ScriptableObject.CreateInstance<ChangeCasterHealthColorBetweenColorsEffect>();
            healthcolors._color1 = Pigments.Red;
            healthcolors._color2 = Pigments.Yellow;
            twofaced.effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(healthcolors, 1, Targeting.Slot_SelfSlot),


            };
            twofaced._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };

            Marmo_CombineEnemies_Marmo_PassiveAbility_ByMarmo unmitosissmall = ScriptableObject.CreateInstance<Marmo_CombineEnemies_Marmo_PassiveAbility_ByMarmo>();

            unmitosissmall._passiveName = "Forbidden Fruit";
            unmitosissmall.passiveIcon = Passives.ForbiddenFruitInHerImage.passiveIcon;
            unmitosissmall.m_PassiveID = "Unmitosis_PA";
            unmitosissmall._enemyDescription = "If there is another of this enemy occupying the Left or Right tile, converge into a larger mass who's health is equal to both units combined.";
            unmitosissmall._characterDescription = "If there is another of this enemy occupying the Left or Right tile, converge into a larger mass who's health is equal to both units combined.";
            unmitosissmall.doesPassiveTriggerInformationPanel = false;
            unmitosissmall._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
            unmitosissmall.PassiveToRemove = Passives.Example_Decay_MudLung.m_PassiveID;
            unmitosissmall.conditions = new EffectorConditionSO[] {  }; 
          



            Enemy neoplasm = new Enemy("Neoplasm", "Neoplasm_EN");
            neoplasm.Health = 10;
            neoplasm.HealthColor = Pigments.Yellow;
            neoplasm.Size = 1;

            neoplasm.CombatSprite = ResourceLoader.LoadSprite("NeoplasmOW", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasm.OverworldAliveSprite = ResourceLoader.LoadSprite("NeoplasmOW", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasm.OverworldDeadSprite = ResourceLoader.LoadSprite("NeoplasmCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasm.DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound;
            neoplasm.DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;

            neoplasm.AddPassives(new BasePassiveAbilitySO[] { twofaced,Passives.Slippery, Passives.Absorb, unmitosissmall });
            neoplasm.PrepareEnemyPrefab("Assets/Slimes/SmallNeoplasm.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Slimes/SmallNeoGibs.prefab").GetComponent<ParticleSystem>());

            ChangeMaxHealthEffect changeMaxHealth = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealth._increase = false;

            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._indirect = true;

            Ability slobber = new Ability("Slobber_A");
            slobber.Name = "Slobber";
            slobber.Description = "Decreases the maximum health of the Opposing party members by 4.";
            slobber.Rarity = Abil.Weight(5);
            slobber.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(changeMaxHealth, 4, Targeting.Slot_Front),
                

            };
            slobber.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Other_MaxHealth.ToString(), IntentType_GameIDs.Damage_3_6.ToString() });
            slobber.AnimationTarget = Targeting.Slot_Front;
            slobber.Visuals = LoadedAssetsHandler.GetEnemyAbility("EarWorm_A").visuals;

            Ability churn = new Ability("NauseatingChurn_A");
            churn.Name = "Nauseating Churn";
            churn.Description = "Slightly heal the nearest Left or Right enemy.";
            churn.Rarity = Abil.Weight(5);
            churn.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_AllyRight),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 3, Targeting.Slot_AllyRight,Effects.CheckPreviousEffectCondition(true,1)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 3, Targeting.Slot_AllyLeft,Effects.CheckPreviousEffectCondition(false,2)),

            };
            churn.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Heal_1_4.ToString() });
            churn.AnimationTarget = Targeting.Slot_SelfSlot;
            churn.Visuals = LoadedAssetsHandler.GetEnemyAbility("Exsanguinate_A").visuals;

            neoplasm.AddEnemyAbilities(new Ability[] { slobber, churn }) ;
            neoplasm.AddEnemy(true, true, true);



            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();

            decay._passiveName = Passives.Example_Decay_MudLung._passiveName;
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            decay._enemyDescription = "Upon death this enemy spawns 2 Neoplasms.";
            decay._characterDescription = "Upon death this party member spawns 2 Neoplasms.";
            decay.conditions = new EffectorConditionSO[] { deathReference };


            SpawnEnemyInSpecificSlotEffect spawnRandomEnemyAnywhereEffect = ScriptableObject.CreateInstance<SpawnEnemyInSpecificSlotEffect>();
            spawnRandomEnemyAnywhereEffect.enemy = neoplasm.enemy;
            spawnRandomEnemyAnywhereEffect.givesExperience = false;
            spawnRandomEnemyAnywhereEffect._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            spawnRandomEnemyAnywhereEffect.trySpawnAnywhereIfFail = true;


            GenericTargetting_BySlot_Index DBtargetAllRight = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            DBtargetAllRight.getAllies = true;
            DBtargetAllRight.slotPointerDirections= new int[] { 0 };


            GenericTargetting_BySlot_Index DBtargetAllRight1 = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            DBtargetAllRight1.getAllies = true;
            DBtargetAllRight1.slotPointerDirections = new int[] { 1 };

            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            decay.effects = new EffectInfo[] { Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect, 1, DBtargetAllRight), Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect, 1, DBtargetAllRight1), };


            Marmo_CombineEnemies_Marmo_PassiveAbility_ByMarmo unmitosismed = ScriptableObject.CreateInstance<Marmo_CombineEnemies_Marmo_PassiveAbility_ByMarmo>();

            unmitosismed._passiveName = "Forbidden Fruit";
            unmitosismed.passiveIcon = Passives.ForbiddenFruitInHerImage.passiveIcon;
            unmitosismed.m_PassiveID = "Unmitosis_PA";
            unmitosismed._enemyDescription = "If there is another of this enemy occupying the Left or Right tile, converge into a larger mass who's health is equal to both units combined.";
            unmitosismed._characterDescription = "If there is another of this enemy occupying the left or right tile, converge into a larger who's health is equal to both units combined.";
            unmitosismed.doesPassiveTriggerInformationPanel = false;
            unmitosismed._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
            unmitosismed.PassiveToRemove = Passives.Example_Decay_MudLung.m_PassiveID;
            unmitosismed.conditions = new EffectorConditionSO[] {  };

            Enemy neoplasmheap = new Enemy("Neoplasm Heap", "NeoplasmHeap_EN");
            neoplasmheap.Health = 30;
            neoplasmheap.HealthColor = Pigments.Yellow;
            neoplasmheap.Size = 2;
            neoplasmheap.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(heapMusicParameter1, 1, Targeting.Slot_SelfSlot), };
            neoplasmheap.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(heapMusicParameter, 1, Targeting.Slot_SelfSlot), };
            neoplasmheap.CombatSprite = ResourceLoader.LoadSprite("HeapOW", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasmheap.OverworldAliveSprite = ResourceLoader.LoadSprite("HeapOW", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasmheap.OverworldDeadSprite = ResourceLoader.LoadSprite("HeapCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasmheap.DamageSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").damageSound;
            neoplasmheap.DeathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;

            neoplasmheap.AddPassives(new BasePassiveAbilitySO[] { twofaced, Passives.Slippery, Passives.Absorb, decay, unmitosismed });
            neoplasmheap.PrepareEnemyPrefab("Assets/Slimes/MedNeoplasm.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Slimes/MedNeoGibs.prefab").GetComponent<ParticleSystem>());

            Ability gurgle = new Ability("SnappingGurgle_A");
            gurgle.Name = "Snapping Gurgle";
            gurgle.Description = "Produce 3-4 Pigment of this enemy's health colour.";
            gurgle.Rarity = Abil.Weight(5);
            gurgle.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 3, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                 

            };
            gurgle.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            gurgle.AnimationTarget = Targeting.Slot_SelfSlot;
            gurgle.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;

            neoplasmheap.AddEnemyAbilities(new Ability[] { slobber, gurgle });
            neoplasmheap.AddEnemy(true, true, false);
           


            PerformEffectPassiveAbility decay1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();

            decay1._passiveName = Passives.Example_Decay_MudLung._passiveName;
            decay1.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay1.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            decay1._enemyDescription = "Upon death this enemy spawns 2 Neoplasm heaps.";
            decay1._characterDescription = "Upon death this party member spawns 4 Neoplasms.";


            SpawnEnemyInSpecificSlotEffect spawnRandomEnemyAnywhereEffect1 = ScriptableObject.CreateInstance<SpawnEnemyInSpecificSlotEffect>();
            spawnRandomEnemyAnywhereEffect1.enemy = neoplasmheap.enemy;
            spawnRandomEnemyAnywhereEffect1.givesExperience = false;
            spawnRandomEnemyAnywhereEffect1._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            spawnRandomEnemyAnywhereEffect1.trySpawnAnywhereIfFail = true;


            GenericTargetting_BySlot_Index DBtargetAllRight11 = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            DBtargetAllRight11.getAllies = true;
            DBtargetAllRight11.slotPointerDirections = new int[] { 0 };



            GenericTargetting_BySlot_Index DBtargetAllRight111 = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            DBtargetAllRight111.getAllies = true;
            DBtargetAllRight111.slotPointerDirections = new int[] { 2 };


            decay1._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };
            decay1.effects = new EffectInfo[] { Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect1, 1, DBtargetAllRight11), Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect1, 1, DBtargetAllRight111) };


            Enemy neoplasmlake = new Enemy("Neoplasm Lake", "NeoplasmLake_EN");
            neoplasmlake.Health = 35;
            neoplasmlake.HealthColor = Pigments.Yellow;
            neoplasmlake.Size = 4;
            neoplasmlake.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(lakeMusicParameter1, 1, Targeting.Slot_SelfSlot), };
            neoplasmlake.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(lakeMusicParameter, 1, Targeting.Slot_SelfSlot), };
            neoplasmlake.CombatSprite = ResourceLoader.LoadSprite("LakeIcon", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasmlake.OverworldAliveSprite = ResourceLoader.LoadSprite("LakeOW", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasmlake.OverworldDeadSprite = ResourceLoader.LoadSprite("LakeCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            neoplasmlake.DamageSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").damageSound;
            neoplasmlake.DeathSound = LoadedAssetsHandler.GetEnemy("SingingStone_EN").deathSound;

            neoplasmlake.AddPassives(new BasePassiveAbilitySO[] { twofaced, Passives.Slippery, Passives.Absorb, decay1 });
            neoplasmlake.PrepareEnemyPrefab("Assets/Slimes/BigNeoplasm.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Slimes/BigNeoGibs.prefab").GetComponent<ParticleSystem>());

            FieldEffect_ApplyRandomTarget_Effect fieldEffect_ApplyRandomTarget_Effect = ScriptableObject.CreateInstance<FieldEffect_ApplyRandomTarget_Effect>();
            fieldEffect_ApplyRandomTarget_Effect._Field = StatusField.Constricted;

            ChangeMaxHealthEffect changeMaxHealth1 = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealth1._increase = true;

            Ability silence = new Ability("DeafeningSilence_A");
            silence.Name = "Deafening Silence";
            silence.Description = "Inflict 1 Constricted to three random opposing tiles.\nIncrease all the Opposing party member's health by 2 and Slightly heal them.";
            silence.Rarity = Abil.Weight(5);
            silence.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(fieldEffect_ApplyRandomTarget_Effect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_ApplyRandomTarget_Effect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_ApplyRandomTarget_Effect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(changeMaxHealth1, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 2, Targeting.Slot_Front),


            };
            silence.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Heal_1_4.ToString() });

            neoplasmlake.AddEnemyAbilities(new Ability[] { slobber, silence });
            neoplasmlake.AddEnemy(true, false, false);

            unmitosismed._EnemyToSpawn = neoplasmlake.enemy;
            unmitosissmall._EnemyToSpawn = neoplasmheap.enemy;



        }
    }
}
