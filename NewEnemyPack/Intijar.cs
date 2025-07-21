using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace NewEnemyPack
{
    internal class Intijar
    {
        public static void Add()
        {
            TargetStoredValueSetEffect casterStoreValueSetterEffect1 = ScriptableObject.CreateInstance<TargetStoredValueSetEffect>();
            casterStoreValueSetterEffect1._valueName = "IntijarValue";

            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Combat/Attack/DLC_01/ATK_DemonCore";
            attackVisualsSO.isAnimationFullScreen = true;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Intijar/IntijarAttackAnim.anim");

            Enemy selfish = new Enemy("Selfish Rock", "RockSelfish_EN");
            selfish.Health = 8;
            selfish.HealthColor = Pigments.Grey;
            selfish.Size = 1;

            selfish.CombatSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            selfish.OverworldAliveSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            selfish.OverworldDeadSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            selfish.DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound;
            selfish.DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;
            selfish.Priority = Priority.Weight(-3);
            selfish.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Inanimate });
            selfish.PrepareEnemyPrefab("Assets/Intijar/Selfish.prefab", Main.assetBundle);


            AddTurnTargetToTimelineIfPassiveEffect addTurnTargetToTimelineIfPassive = ScriptableObject.CreateInstance<AddTurnTargetToTimelineIfPassiveEffect>();
            addTurnTargetToTimelineIfPassive.passive = "Reactive_PA";

            Ability rockability = new Ability("SmugSuperiority_A");
            rockability.Name = "Smug Superiority";
            rockability.Description = "Make Intijar perform an additional move. This move cannot be \"Brainstorm\".\n\"These illogical actions of yours...well, I find them amusing\".";
            rockability.Rarity = Abil.Weight(5);
            rockability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(casterStoreValueSetterEffect1, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(addTurnTargetToTimelineIfPassive, 1, Targeting.Unit_OtherAllies),


            };
            rockability.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Other_Refresh.ToString() });
            rockability.AnimationTarget = Targeting.Slot_SelfSlot;
            rockability.Visuals = ((ExtraAttackPassiveAbility)LoadedAssetsHandler.GetEnemy("Roids_BOSS").passiveAbilities[1])._extraAbility.ability.visuals;

            selfish.AddEnemyAbilities(new Ability[] { rockability });
            selfish.AddEnemy(true, false, false);

            Enemy divine = new Enemy("\"Divine\" Rock", "RockDivine_EN");
            divine.Health = 7;
            divine.HealthColor = Pigments.Grey;
            divine.Size = 1;
            divine.Priority = Priority.Weight(-5);
            divine.CombatSprite = ResourceLoader.LoadSprite("IntijarCrossIcon", new Vector2?(new Vector2(0.5f, 0f)));
            divine.OverworldAliveSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            divine.OverworldDeadSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            divine.DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound;
            divine.DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;

            divine.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Inanimate });
            divine.PrepareEnemyPrefab("Assets/Intijar/Divine.prefab", Main.assetBundle);

            StatusEffect_ApplyIfPassive_Effect statusEffect_ApplyIfPassive_Effect = ScriptableObject.CreateInstance<StatusEffect_ApplyIfPassive_Effect>();
            statusEffect_ApplyIfPassive_Effect.passive = "Reactive_PA";
            statusEffect_ApplyIfPassive_Effect._Status = StatusField.DivineProtection;

            StatusEffect_ApplyIfPassive_Effect statusEffect_ApplyIfPassive_Effect1 = ScriptableObject.CreateInstance<StatusEffect_ApplyIfPassive_Effect>();
            statusEffect_ApplyIfPassive_Effect1.passive = "Reactive_PA";
            statusEffect_ApplyIfPassive_Effect1._Status = StatusField.Focused;

            Ability rockability1 = new Ability("DivineImitation_A");
            rockability1.Name = "Imitation";
            rockability1.Description = "Apply Focus and 2 Divine Protection to Intijar.";
            rockability1.Rarity = Abil.Weight(5);
            rockability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_ApplyIfPassive_Effect, 2, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(statusEffect_ApplyIfPassive_Effect1, 1, Targeting.Unit_OtherAllies),


            };
            rockability1.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Status_DivineProtection.ToString(), IntentType_GameIDs.Status_Focused.ToString() });
            rockability1.AnimationTarget = Targeting.Slot_SelfSlot;
            rockability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;

            divine.AddEnemyAbilities(new Ability[] { rockability1 });
            divine.AddEnemy(true, false, false);

            Enemy trapping = new Enemy("Trapping Rock", "RockTrapping_EN");
            trapping.Health = 8;
            trapping.HealthColor = Pigments.Grey;
            trapping.Size = 1;

            trapping.CombatSprite = ResourceLoader.LoadSprite("IntijarJagIcon", new Vector2?(new Vector2(0.5f, 0f)));
            trapping.OverworldAliveSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            trapping.OverworldDeadSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            trapping.DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound;
            trapping.DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;
            trapping.Priority = Priority.Weight(-3);

            trapping.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Inanimate, Passives.Constricting });
            trapping.PrepareEnemyPrefab("Assets/Intijar/Trapping.prefab", Main.assetBundle);

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Ruptured;

            Ability rockability11 = new Ability("Jag_A");
            rockability11.Name = "Jag";
            rockability11.Description = "Inflict 2 Rupture to the Left and Right party members.";
            rockability11.Rarity = Abil.Weight(5);
            rockability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_Apply_, 2, Targeting.Slot_OpponentSides),
             


            };
            rockability11.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            rockability11.AnimationTarget = Targeting.Slot_OpponentSides;
            rockability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals;

            trapping.AddEnemyAbilities(new Ability[] { rockability11 });
            trapping.AddEnemy(true, false, false);

            Enemy pouring = new Enemy("Pouring Rock", "RockPouring_EN");
            pouring.Health = 10;
            pouring.HealthColor = Pigments.Red;
            pouring.Size = 1;

            pouring.CombatSprite = ResourceLoader.LoadSprite("IntijarLeakingIcon", new Vector2?(new Vector2(0.5f, 0f)));
            pouring.OverworldAliveSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            pouring.OverworldDeadSprite = ResourceLoader.LoadSprite("IntijarRockIcon", new Vector2?(new Vector2(0.5f, 0f)));
            pouring.DamageSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").damageSound;
            pouring.DeathSound = LoadedAssetsHandler.GetCharacter("Gospel_CH").deathSound;
            pouring.Priority = Priority.Weight(-3);

            pouring.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Inanimate});
            pouring.PrepareEnemyPrefab("Assets/Intijar/Pouring.prefab", Main.assetBundle);



            Ability rockability111 = new Ability("Spill_A");
            rockability111.Name = "Spill";
            rockability111.Description = "Produces 1 Pigment of this enemy's health colour.\nDeals a Little amount of damage to this enemy.";
            rockability111.Rarity = Abil.Weight(5);
            rockability111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<GenerateCasterHealthManaEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_SelfSlot),



            };
            rockability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });
            rockability111.AnimationTarget = Targeting.Slot_SelfSlot;
            rockability111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Struggle_A").visuals;

            pouring.AddEnemyAbilities(new Ability[] { rockability111 });
            pouring.AddEnemy(true, false, false);


            PerformDoubleEffectPassiveAbility reactive = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();

            reactive._passiveName = "Reactive";
            reactive.passiveIcon = ResourceLoader.LoadSprite("Reactive");
            reactive.m_PassiveID = "Reactive_PA";
            reactive._enemyDescription = "Upon receiving Damage, this enemy will summon an enemy in retaliation.";
            reactive._characterDescription = "Upon receiving Damage, this enemy will summon an enemy in retaliation.";
            reactive._secondDoesPerformPopUp = false;


            SpawnRandomEnemyAnywhereEffect spawnRandomEnemyAnywhereEffect = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
            spawnRandomEnemyAnywhereEffect._enemies = new List<EnemySO>() { pouring.enemy, trapping.enemy, divine.enemy, selfish.enemy };
            spawnRandomEnemyAnywhereEffect._givesExperience = false;
            spawnRandomEnemyAnywhereEffect._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            CasterStoreValueSetterEffect casterStoreValueSetterEffect = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            casterStoreValueSetterEffect.m_unitStoredDataID = "IntijarValue";

            reactive._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };
            reactive._secondTriggerOn = new TriggerCalls[] { TriggerCalls.OnTurnFinished };
            reactive.effects = new EffectInfo[] { Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect, 1, Targeting.Slot_SelfSlot), };
            reactive._secondEffects = new EffectInfo[] { Effects.GenerateEffect(casterStoreValueSetterEffect, 0, Targeting.Slot_SelfSlot), };

            Passives.AddCustomPassiveToPool("Reactive_PA", "Reactive", reactive);
            GlossaryPassives passiveInfo = new GlossaryPassives("Reactive", "Upon receiving Damage, this enemy will summon an enemy in retaliation.", ResourceLoader.LoadSprite("Reactive", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);


            Enemy enemy = new Enemy("Intijar", "Intijar_BOSS");
            enemy.Health = 60;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.AbilitySelector = ScriptableObject.CreateInstance<CustomAbilitySelector_Intijar>();
            enemy.CombatSprite = ResourceLoader.LoadSprite("IntijarIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("ChapmanOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("ChapmanCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Bronzo4_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Bronzo4_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.MultiAttack2, reactive });
            enemy.PrepareEnemyPrefab("Assets/Intijar/Intijar.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Intijar/Giblets_Intijar.prefab").GetComponent<ParticleSystem>());

            DamageOnDoubleCascadeEffect damage = ScriptableObject.CreateInstance<DamageOnDoubleCascadeEffect>();
            damage._consistentCascade = true;
            damage._cascadeIsIndirect = true;
            damage._decreaseAsPercentage = true;
            damage._cascadeDecrease = 50;

            Ability ability = new Ability("Castigate_A");
            ability.Name = "Castigate";
            ability.Description = "Deals a Painful amount of damage to the Opposing party member.\nDamage spreads indirectly to the Party members on the Left or Right.";
            ability.Rarity = Abil.Weight(7);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(damage, 4, Targeting.GenerateSlotTarget(new int[]{0,1,-1}, false)),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Flarblet_EN").abilities[2].ability.visuals;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.Shield;

            Ability ability1 = new Ability("Centralize_A");
            ability1.Name = "Centralize";
            ability1.Description = "Summon a random rock.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect, 1, Targeting.Slot_SelfSlot),
            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Spawn.ToString() });


            DamageEqualSpreadEffect damageEqualSpreadEffect = ScriptableObject.CreateInstance<DamageEqualSpreadEffect>();
            damageEqualSpreadEffect._indirect = true;
            damageEqualSpreadEffect._usePreviousExitValue = true;

            DamageIfPassiveEffect damageIfPassiveEffect = ScriptableObject.CreateInstance<DamageIfPassiveEffect>();
            damageIfPassiveEffect.passive = Passives.Inanimate.m_PassiveID;
            damageIfPassiveEffect._indirect = true;

            TryUnlockAchievementEffect tryUnlockAchievementEffect = ScriptableObject.CreateInstance<TryUnlockAchievementEffect>();
            tryUnlockAchievementEffect._unlockID = "IntijarComedy";

            FieldEffect_Apply_Effect fieldEffect_Apply_1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_1._Field = StatusField.Shield;

            Ability ability11 = new Ability("Brainstorm_A");
            ability11.Name = "Brainstorm";
            ability11.Description = "Destroy every current Inanimate enemy.\nDeals damage equivalent to how much health the enemies had, the damage spreads equally among every party member.";
            ability11.Rarity = Abil.Weight(4);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(damageIfPassiveEffect, 999, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(damageEqualSpreadEffect, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(tryUnlockAchievementEffect, 1, Targeting.Slot_SelfAll, Effects.CheckPreviousEffectCondition(false,2)),

            };
            ability11.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Damage_Death.ToString() });
            ability11.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability11.AnimationTarget = Targeting.Slot_SelfSlot;
            ability11.Visuals = attackVisualsSO;

            Ability ability111 = new Ability("Maneuver_A");
            ability111.Name = "Maneuver";
            ability111.Description = "Apply 2 Shields to the Left and Right Enemy position.\nMove this enemy to the Left or Right.";
            ability111.Rarity = Abil.Weight(5);
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(fieldEffect_Apply_1, 2, Targeting.Slot_AllySides),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            ability111.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });


            enemy.AddEnemyAbilities(new Ability[] { ability, ability111,ability1, ability11 });
            enemy.AddEnemy(true, false, false);

            


        }

    }
}
