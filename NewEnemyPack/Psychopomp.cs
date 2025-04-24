using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Psychopomp
    {
        public static void Add()
        {

            ChangeMaxHealthEffect move = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            move._increase = true;
            move._entryAsPercentage = true;

            PerformEffectPassiveAbility fourfaced = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fourfaced._passiveName = "The Garden";
            fourfaced.m_PassiveID = "TheGarden_PA";
            fourfaced.passiveIcon = ResourceLoader.LoadSprite("GardenPassive");
            fourfaced._enemyDescription = "At the start of combat, increase the maximum health of all other enemies by 20%.";
            fourfaced._characterDescription = "At the start of combat, increase the maximum health of all other party members by 20%.";
            fourfaced.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(move, 20, Targeting.Unit_OtherAllies), Effects.GenerateEffect(ScriptableObject.CreateInstance<ChangeCurrentHealthtToMaxHealthEffect>(), 1, Targeting.Unit_OtherAllies),

            };
            fourfaced._triggerOn = new TriggerCalls[] { TriggerCalls.OnCombatStart};


            Passives.AddCustomPassiveToPool("TheGarden_PA", "The Garden", fourfaced);
            GlossaryPassives passiveInfo = new GlossaryPassives("The Garden", "At the start of combat, increase the maximum health of all other enemies by 20%.", ResourceLoader.LoadSprite("GardenPassive", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);


            Enemy enemy = new Enemy("Psychopomp", "Psychopomp_EN");
            enemy.Health = 70;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 2;
            enemy.Priority = Priority.Weight(3);
            enemy.CombatSprite = ResourceLoader.LoadSprite("pompicon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("pompoverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("pompcorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("HeavensGatePurple_BOSS").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Doll_CH").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, fourfaced });
            enemy.PrepareEnemyPrefab("assets/pomp/pomp.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/pomp/giblets_pomp.prefab").GetComponent<ParticleSystem>());

            ChangeToRandomHealthDependingonCasterColorEffect change = ScriptableObject.CreateInstance<ChangeToRandomHealthDependingonCasterColorEffect>();
            change._healthColors = new ManaColorSO[] { Pigments.Red };
            change._healthColors2 = new ManaColorSO[] { Pigments.Grey };

            DamageEffect ds = ScriptableObject.CreateInstance<DamageEffect>();
            ds._usePreviousExitValue = true;

            Targetting_BySlot_Index targetting_BySlot_Index3 = ScriptableObject.CreateInstance<Targetting_BySlot_Index>();
            targetting_BySlot_Index3.getAllies = true;
            targetting_BySlot_Index3.allSelfSlots = true;
            targetting_BySlot_Index3.slotPointerDirections = new int[2];

            Ability ability = new Ability("WarisDeception_A");
            ability.Name = "War is Deception";
            ability.Description = "Perform a random ability from one of the other enemies in combat.";
            ability.Rarity = Abil.Weight(50);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityFromEnemyOnFieldEnemyEffect>(), 3, Targeting.Unit_OtherAllies),


            };
            ability.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });

            Ability ability1 = new Ability("FromtheGarden_A");
            ability1.Name = "From the Garden";
            ability1.Description = "Fully Heal all other enemies, deal damage to this enemy equal to amount healed.";
            ability1.Rarity = Abil.Weight(40);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<FullHealEffect>(), 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(ds, 1, Targeting.Slot_SelfSlot),


            };
            ability1.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Heal_5_10.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            ability1.AnimationTarget = targetting_BySlot_Index3;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN").abilities[2].ability.visuals;

            Ability ability11 = new Ability("WithintheGrid_A");
            ability11.Name = "Within the Grid";
            ability11.Description = "If this enemy's health color is Grey, change the health color of all other enemies to Grey and change this enemy's health color to Red.\nIf this enemy's health color isn't Grey, change the health color of all other enemies to this enemy's health color and change this enemy's health color to Grey.";
            ability11.Rarity = Abil.Weight(50);
            ability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(change, 1, Targeting.Unit_OtherAllies),


            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Modify.ToString() });
            ability11.AnimationTarget = Targeting.Slot_SelfSlot;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Sepulchre_EN").abilities[0].ability.visuals;

            StatusEffect_Apply_Effect statusEffectIfInField_Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffectIfInField_Apply_Effect._Status = StatusField.DivineProtection;

            Ability ability111 = new Ability("CradleofAffliction_A");
            ability111.Name = "Cradle of Affliction";
            ability111.Description = "Applies 1 Divine protection to either this enemy or 2 Divine protection to all other enemies.";
            ability111.Rarity = Abil.Weight(35);
            ability111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffectIfInField_Apply_Effect, 2, Targeting.Unit_OtherAllies, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(statusEffectIfInField_Apply_Effect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(false,1)),

            };
            ability111.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Status_DivineProtection.ToString() });
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_DivineProtection.ToString() });
            ability111.AnimationTarget = targetting_BySlot_Index3;
            ability111.Visuals = LoadedAssetsHandler.GetEnemy("ChoirBoy_EN").abilities[3].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11, ability111 });
            enemy.AddEnemy(true, true, false);


        }
    }
}
