using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class DrySimian
    {
        public static void Add()
        {

            Ability ability = new Ability("GorillaSprint_A");
            ability.Name = "Gorilla Sprint";
            ability.Description = "Move to the Left or Right as far as possible.\nDeal an Agonizing amount damage to the Opposing party member.";
            ability.Rarity = Abil.Weight(0);
            ability.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Bash_A").abilitySprite;
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<GorillaMovementEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Mass.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = ability.GenerateEnemyAbility().ability;
            extraAbilityInfo.rarity = Abil.Weight(0);


            Enemy enemy = new Enemy("Dry Simian", "DrySimian_EN");
            enemy.Health = 20;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(3);
            enemy.CombatSprite = ResourceLoader.LoadSprite("DrySimian_icon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("DrySimian_Overworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("DrySimian_corpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Voboola_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Voboola_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.BonusAttackGenerator(extraAbilityInfo) });
            enemy.PrepareEnemyPrefab("Assets/Gorilla/Gorilla.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/gorilla/giblets_gorilla.prefab").GetComponent<ParticleSystem>());

            FieldEffect_ApplyIfUnit_Effect fieldEffect_ApplyIfUnit_Effect = ScriptableObject.CreateInstance<FieldEffect_ApplyIfUnit_Effect>();
            fieldEffect_ApplyIfUnit_Effect._Field = StatusField.Constricted;

            FieldEffect_Apply_Effect fieldEffect_ApplyIfUnit_Effect1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_ApplyIfUnit_Effect1._Field = StatusField.Constricted;

            MultiPreviousEffectCondition mc1 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            mc1.wasSuccessful = new bool[] { true, false, false };
            mc1.previousAmount = new int[3] { 1, 0, 0 };

            MultiPreviousEffectCondition mc2 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            mc2.wasSuccessful = new bool[] { true, false, false };
            mc2.previousAmount = new int[3] { 3, 2, 1 };


            MultiPreviousEffectCondition mc3 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            mc3.wasSuccessful = new bool[] { false, false, false };
            mc3.previousAmount = new int[] { 1, 2, 3 };


            MultiPreviousEffectCondition mc4 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            mc4.wasSuccessful = new bool[] { false, false, false };
            mc4.previousAmount = new int[] { 2, 3, 4 };


            PreviousEffectCondition c1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            c1.wasSuccessful = false;


            PreviousEffectCondition c2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            c2.wasSuccessful = true;

            PreviousEffectCondition c3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            c3.wasSuccessful = false;
            c3.previousAmount = 4;

            PreviousEffectCondition c4 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            c4.wasSuccessful = false;
            c4.previousAmount = 2;

            Ability ability1 = new Ability("Mortify_A");
            ability1.Name = "Mortify";
            ability1.Description = "Inflict 2 Constricted to the Farthest enemy(s) positions.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyConstrictedToFurthestEffect>(), 2, Targeting.GenerateSlotTarget(new int[]{-4,4},true)),


            };
            ability1.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Field_Constricted.ToString() });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] {  ability1 });
            enemy.AddEnemy(true, true, false);


     



        }
    }
}
