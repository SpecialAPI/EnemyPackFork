using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Screaming
    {
        public static void Add()
        {
            FieldEffect_Apply_Effect fieldEffect_Apply_Effect = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_Effect._Field = StatusField.Constricted;

            Ability parental = new Ability("WhiteNoise_A");
            parental.Name = "White Noise";
            parental.Description = "25% chance to Inflict 2 Constriced to each party member and enemy tile.";
            parental.Rarity = Abil.Weight(0);
            parental.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{4},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{3},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{2},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{1},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{0},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-1},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-2},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-3},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-4},true), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{4}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{3}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{2}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{1}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{0}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-1}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-2}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-3}), Effects.ChanceCondition(25)),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 2, Targeting.GenerateSlotTarget(new int[]{-4}), Effects.ChanceCondition(25)),


            };
            parental.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }), new string[] { IntentType_GameIDs.Field_Constricted.ToString() });
            parental.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4,-3,-2,-1,0,1,2,3,4 }, true), new string[] { IntentType_GameIDs.Field_Constricted.ToString() });
            parental.AnimationTarget = Targeting.Slot_SelfSlot;
            parental.Visuals = LoadedAssetsHandler.GetCharacter("Splig_CH").rankedData[1].rankAbilities[0].ability.visuals;
            parental.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = parental.ability;
            extraAbilityInfo.rarity = Abil.Weight(0);

            Enemy enemy = new Enemy("Screaming Homunculus", "ScreamingHomunculus_EN");
            enemy.Health = 35;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(3);
            enemy.CombatSprite = ResourceLoader.LoadSprite("ScreamingIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("ScreamingOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("ScreamingCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Screaming/ScreamingHurt";
            enemy.DeathSound = "event:/Screaming/ScreamingDeath";

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Overexert10, Passives.ParentalGenerator(extraAbilityInfo), Passives.Withering });
            enemy.PrepareEnemyPrefab("assets/screaming/screamingh.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/screaming/giblets_screaming.prefab").GetComponent<ParticleSystem>());

            Ability ability = new Ability("BabyMonitor_A");
            ability.Name = "Baby Monitor";
            ability.Description = "Deal a Painful amount of damage to the enemy(s) with the lowest health.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageWeakestEffect>(), 3, Targeting.Unit_OtherAllies),


            };
            ability.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Flarblet_EN").abilities[2].ability.visuals;

            Ability ability1 = new Ability("NewOrders_A");
            ability1.Name = "New Orders";
            ability1.Description = "Deal a Painful amount of damage to the enemy(s) with the highest health.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageStrongestEffect>(), 5, Targeting.Unit_OtherAllies),


            };
            ability1.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;


            enemy.AddEnemyAbilities(new Ability[] { ability, ability1 });
            enemy.AddEnemy(true, true, false);
        }

    }
}
