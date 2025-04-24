using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace NewEnemyPack
{
    internal class DepressionSquid
    {
        public static void Add()
        {

            PerformEffectPassiveAbility depression = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            depression._passiveName = "Depression";
            depression.m_PassiveID = "Depression_PA";
            depression.passiveIcon = ResourceLoader.LoadSprite("Depression");
            depression._enemyDescription = "This enemy is Sad :(.";
            depression._characterDescription = "This party member is Sad :(.";
            depression.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            depression._triggerOn = new TriggerCalls[] { TriggerCalls.Count };


            Passives.AddCustomPassiveToPool("Depression_PA", "Depression", depression);
            GlossaryPassives passiveInfo = new GlossaryPassives("Depression", "This enemy is Sad :(.", ResourceLoader.LoadSprite("Depression", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);

            StatusEffect_ApplyIfPassive_Effect statusEffect_ApplyIfPassive_Effect = ScriptableObject.CreateInstance<StatusEffect_ApplyIfPassive_Effect>();
            statusEffect_ApplyIfPassive_Effect._Status = StatusField.Frail;
            statusEffect_ApplyIfPassive_Effect.passive = depression.m_PassiveID;

            PerformEffectPassiveAbility decay = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            decay._passiveName = "Decay";
            decay.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            decay.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            decay._enemyDescription = "When this enemy is dead inflict Frail to the Depression Squid.";
            decay._characterDescription = "ough.";
            decay.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(statusEffect_ApplyIfPassive_Effect, 1, Targeting.Unit_AllAllies),

            };
            decay._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Enemy baretent = new Enemy("Gripping Tentacle", "GrippingTentacle_EN");
            baretent.Health = 12;
            baretent.HealthColor = Pigments.Red;
            baretent.Size = 1;

            baretent.CombatSprite = ResourceLoader.LoadSprite("NakedTentacleIcon", new Vector2?(new Vector2(0.5f, 0f)));
            baretent.OverworldAliveSprite = ResourceLoader.LoadSprite("NakedTentacleIcon", new Vector2?(new Vector2(0.5f, 0f)));
            baretent.OverworldDeadSprite = ResourceLoader.LoadSprite("NakedTentacleIcon", new Vector2?(new Vector2(0.5f, 0f)));
            baretent.DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound;
            baretent.DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;

            baretent.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, decay, Passives.Withering });
            baretent.PrepareEnemyPrefab("Assets/Pequod/Tentacles/BaseTentacle.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Pequod/Tentacles/GibTentacle.prefab").GetComponent<ParticleSystem>());

            Ability squidslap = new Ability("SquidSlap_A");
            squidslap.Name = "Squid Slap";
            squidslap.Description = "Deals a Painful amount of damage to the Opposing party member.\nMoves the Opposing party member to the Left or Right.";
            squidslap.Rarity = Abil.Weight(5);
            squidslap.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_Front),

            };
            squidslap.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Swap_Sides.ToString() });
            squidslap.AnimationTarget = Targeting.Slot_Front;
            squidslap.Visuals = LoadedAssetsHandler.GetCharacter("Arnold_CH").rankedData[0].rankAbilities[1].ability.visuals;

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Ruptured;

            Ability mishandle = new Ability("Mishandle_A");
            mishandle.Name = "Mishandle";
            mishandle.Description = "Deals a Little amount of damage to the Opposing party member.\nInflict 2 Ruptured to the Opposing party member.";
            mishandle.Rarity = Abil.Weight(7);
            mishandle.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(statusEffect_Apply_, 2, Targeting.Slot_Front),

            };
            mishandle.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Status_Ruptured.ToString() });
            mishandle.AnimationTarget = Targeting.Slot_Front;
            mishandle.Visuals = LoadedAssetsHandler.GetCharacter("Arnold_CH").rankedData[0].rankAbilities[1].ability.visuals;

            baretent.AddEnemyAbilities(new Ability[] { squidslap, mishandle });
            baretent.AddEnemy(true, false, false);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Enemy scrungietent = new Enemy("Squeezing Tentacle", "SqueezingTentacle_EN");
            scrungietent.Health = 13;
            scrungietent.HealthColor = Pigments.Red;
            scrungietent.Size = 1;

            scrungietent.CombatSprite = ResourceLoader.LoadSprite("ScrungieTentIcon", new Vector2?(new Vector2(0.5f, 0f)));
            scrungietent.OverworldAliveSprite = ResourceLoader.LoadSprite("ScrungieTentIcon", new Vector2?(new Vector2(0.5f, 0f)));
            scrungietent.OverworldDeadSprite = ResourceLoader.LoadSprite("ScrungieTentIcon", new Vector2?(new Vector2(0.5f, 0f)));
            scrungietent.DamageSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").damageSound;
            scrungietent.DeathSound = LoadedAssetsHandler.GetEnemy("Scrungie_EN").deathSound;

            scrungietent.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, decay, Passives.Withering });
            scrungietent.PrepareEnemyPrefab("Assets/Pequod/Tentacles/ScrungieTentacle.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Pequod/Tentacles/GibTentacle.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.OilSlicked;

            Ability embrace = new Ability("SlipperyEmbrace_A");
            embrace.Name = "Slippery Embrace";
            embrace.Description = "Inflict 2 Oil-Slicked to the Opposing party Member.\nDeal a Painful amount of damage to the Opposing party member.";
            embrace.Rarity = Abil.Weight(6);
            embrace.Effects = new EffectInfo[]
            {

                 Effects.GenerateEffect(statusEffect_Apply_1, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_Front),
                 

            };
            embrace.AddIntentsToTarget(Targeting.Slot_Front, new string[] {  IntentType_GameIDs.Status_OilSlicked.ToString(), IntentType_GameIDs.Damage_3_6.ToString(), });
            embrace.AnimationTarget = Targeting.Slot_Front;
            embrace.Visuals = LoadedAssetsHandler.GetCharacterAbility("Oil_1_A").visuals;

            scrungietent.AddEnemyAbilities(new Ability[] { squidslap, embrace });
            scrungietent.AddEnemy(true, false, false);


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            Enemy innertent = new Enemy("Careful Tentacle", "CarefulTentacle_EN");
            innertent.Health = 8;
            innertent.HealthColor = Pigments.Red;
            innertent.Size = 1;

            innertent.CombatSprite = ResourceLoader.LoadSprite("ChildIcon", new Vector2?(new Vector2(0.5f, 0f)));
            innertent.OverworldAliveSprite = ResourceLoader.LoadSprite("ChildIcon", new Vector2?(new Vector2(0.5f, 0f)));
            innertent.OverworldDeadSprite = ResourceLoader.LoadSprite("ChildIcon", new Vector2?(new Vector2(0.5f, 0f)));
            innertent.DamageSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound;
            innertent.DeathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound;

            innertent.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, decay, Passives.Withering, Passives.Confusion });
            innertent.PrepareEnemyPrefab("Assets/Pequod/Tentacles/InnerTent.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Pequod/Tentacles/GibTentacle.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_11 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_11._Status = StatusField.Linked;

            Ability together = new Ability("Together_A");
            together.Name = "Together";
            together.Description = "Inflict 2 Linked to the Opposing party member and 2 Linked to this enemy.";
            together.Rarity = Abil.Weight(8);
            together.Effects = new EffectInfo[]
            {

                 Effects.GenerateEffect(statusEffect_Apply_11, 2, Targeting.Slot_Front),
                 Effects.GenerateEffect(statusEffect_Apply_11, 2, Targeting.Slot_SelfSlot),


            };
            together.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Linked.ToString(),});
            together.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Linked.ToString(), });
            together.AnimationTarget = Targeting.Slot_Front;
            together.Visuals = LoadedAssetsHandler.GetCharacter("Rags_CH").rankedData[0].rankAbilities[1].ability.visuals;

            innertent.AddEnemyAbilities(new Ability[] { squidslap, together });
            innertent.AddEnemy(true, false, false);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Enemy desperatetent = new Enemy("Desperate Tentacle", "DesperateTentacle_EN");
            desperatetent.Health = 11;
            desperatetent.HealthColor = Pigments.Red;
            desperatetent.Size = 1;

            desperatetent.CombatSprite = ResourceLoader.LoadSprite("MusicTentIcon", new Vector2?(new Vector2(0.5f, 0f)));
            desperatetent.OverworldAliveSprite = ResourceLoader.LoadSprite("MusicTentIcon", new Vector2?(new Vector2(0.5f, 0f)));
            desperatetent.OverworldDeadSprite = ResourceLoader.LoadSprite("MusicTentIcon", new Vector2?(new Vector2(0.5f, 0f)));
            desperatetent.DamageSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").damageSound;
            desperatetent.DeathSound = LoadedAssetsHandler.GetEnemy("MusicMan_EN").deathSound;

            desperatetent.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, decay, Passives.Withering });
            desperatetent.PrepareEnemyPrefab("Assets/Pequod/Tentacles/MusicTentacle.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Pequod/Tentacles/GibTentacle.prefab").GetComponent<ParticleSystem>());


            ChangeMaxHealthEffect changeMaxHealthEffect = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealthEffect._increase = false;

            IncreaseStatusEffectsEffect increaseStatusEffectsEffect = ScriptableObject.CreateInstance<IncreaseStatusEffectsEffect>();
            increaseStatusEffectsEffect._increasePositives = false;

            Ability pressure = new Ability("Pressure_A");
            pressure.Name = "Pressure";
            pressure.Description = "Increases the duration of all negative status effects inflicted to All party members by 2.\nDecreases All party member's maximum health by 1.";
            pressure.Rarity = Abil.Weight(5);
            pressure.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(increaseStatusEffectsEffect, 2, Targeting.Unit_AllOpponents),
                     Effects.GenerateEffect(changeMaxHealthEffect, 1, Targeting.Unit_AllOpponents),


            };
            pressure.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Other_MaxHealth.ToString(), });
            pressure.AnimationTarget = Targeting.Unit_AllOpponents;
            pressure.Visuals = LoadedAssetsHandler.GetCharacterAbility("Scream_1_A").visuals;

            desperatetent.AddEnemyAbilities(new Ability[] { squidslap, pressure });
            desperatetent.AddEnemy(true, false, false);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            SpawnRandomEnemyAnywhereEffect spawnRandomForSquidAnywhereEffect = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
            spawnRandomForSquidAnywhereEffect._givesExperience = false;
            spawnRandomForSquidAnywhereEffect._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            spawnRandomForSquidAnywhereEffect._enemies = new List<EnemySO> { baretent.enemy, scrungietent.enemy, desperatetent.enemy, innertent.enemy };


            Ability wave = new Ability("Wave_A");
            wave.Name = "Wave";
            wave.Description = "Spawn 2 Tentacles.";
            wave.Rarity = Abil.Weight(0);
            wave.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot),

            };
            wave.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Spawn.ToString(), IntentType_GameIDs.Other_Spawn.ToString() });
            wave.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = wave.ability;
            extraAbilityInfo.rarity = Abil.Weight(0);

            TryUnlockAchievementEffect tryUnlockAchievementEffect = ScriptableObject.CreateInstance<TryUnlockAchievementEffect>();
            tryUnlockAchievementEffect._unlockID = "SquidTragedy";



            Enemy squid = new Enemy("Depression Squid", "DepressionSquid_BOSS");
            squid.Health = 190;
            squid.HealthColor = Pigments.Red;
            squid.Size = 1;
            squid.Priority = Priority.Weight(-3);
            squid.CombatSprite = ResourceLoader.LoadSprite("SquidIcon", new Vector2?(new Vector2(0.5f, 0f)));
            squid.OverworldAliveSprite = ResourceLoader.LoadSprite("SquidIcon", new Vector2?(new Vector2(0.5f, 0f)));
            squid.OverworldDeadSprite = ResourceLoader.LoadSprite("SquidIcon", new Vector2?(new Vector2(0.5f, 0f)));
            squid.DamageSound = LoadedAssetsHandler.GetEnemy("Ouroboros_Head_BOSS").damageSound;
            squid.DeathSound = LoadedAssetsHandler.GetEnemy("Ouroboros_Head_BOSS").deathSound;
            squid.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(tryUnlockAchievementEffect, 1, Targeting.Slot_SelfSlot), };
            squid.AddPassives(new BasePassiveAbilitySO[] { Passives.BonusAttackGenerator(extraAbilityInfo), depression });
            squid.PrepareEnemyPrefab("Assets/Pequod/squid.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Pequod/GibSquid.prefab").GetComponent<ParticleSystem>());

            GenerateColorManaEffect blue = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            blue.mana = Pigments.Blue;

            Ability squidcry = new Ability("SquidCry_A");
            squidcry.Name = "Cry";
            squidcry.Description = "This enemy cries and produces 1 Blue Pigment.\n\"It ain't easy being greasy.\"";
            squidcry.Rarity = Abil.Weight(1);
            squidcry.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(blue, 1, Targeting.Slot_SelfSlot),


            };
            squidcry.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            squidcry.AnimationTarget = Targeting.Slot_SelfSlot;
            squidcry.Visuals = LoadedAssetsHandler.GetEnemy("Mung_EN").abilities[1].ability.visuals;


            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Combat/Attack/Boss/Signature/ATK_Boss_Orro_Starve";
            attackVisualsSO.isAnimationFullScreen = true;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Pequod/SquareUpAnim.anim");

            Ability ability = new Ability("SquareUp_A");
            ability.Name = "Square Up";
            ability.Description = "Retracts all current tentacles and summons new ones equal to the amount retracted.\nIf there are no Tentacles present produce 1 Blue Pigment.";
            ability.Rarity = Abil.Weight(2);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-4}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-3}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-2}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{-1}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{1}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{2}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{3}, true)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FleeTargetEffect>(), 1, Targeting.GenerateSlotTarget(new int[]{4}, true)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(spawnRandomForSquidAnywhereEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true,8)),
                  Effects.GenerateEffect(blue, 1, Targeting.Slot_SelfSlot, Effects.CheckMultiplePreviousEffectsCondition(new bool[] {false,false,false,false,false,false,false,false },new int[] { 9,10,11,12,13,14,15,16 })),


            };
            ability.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Other_Spawn.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = attackVisualsSO;

            squid.AddEnemyAbilities(new Ability[] { squidslap,squidcry,ability });
            squid.AddEnemy(true, false, false);


        }
    }
}
