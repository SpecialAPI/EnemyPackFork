using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Peon
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Tittering Peon", "TitteringPeon_EN");
            enemy.Health = 18;
            enemy.HealthColor = Pigments.Purple;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(-3);
            enemy.CombatSprite = ResourceLoader.LoadSprite("PeonIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("PeonOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("PeonCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Thype_CH").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Thype_CH").deathSound;
            enemy.UnitTypes = new List<string> { "Bird" };
            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.SkittishGenerator(5), Passives.SlipperyGenerator(5), Passives.Infantile });
            enemy.PrepareEnemyPrefab("assets/peon/coolpeon.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/peon/giblets_peon.prefab").GetComponent<ParticleSystem>());

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = Passives.Example_Parental_Vengeance.passiveIcon;
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("ParentalIntent", InfestIntent);

            Ability ability = new Ability("BroodParasite_A");
            ability.Name = "Brood Parasite";
            ability.Description = "Applies Parental to the Left or Right enemy.\n\"Sadist in the making.\"";
            ability.Rarity = Abil.Weight(40);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyParentalEffect>(), 1, Targeting.Slot_AllyLeft, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ApplyParentalEffect>(), 1, Targeting.Slot_AllyRight, Effects.CheckPreviousEffectCondition(true,1)),


            };
            ability.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { "ParentalIntent" });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").abilities[2].ability.visuals;

            Ability ability1 = new Ability("ChildrenareCruel_A");
            ability1.Name = "Children are Cruel";
            ability1.Description = "If the Opposing party member has less than 15 health, Reduce the Opposing party member to only 1 health.";
            ability1.Rarity = Abil.Weight(30);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ReduceHpUnder10HpEffect>(), 1, Targeting.Slot_Front),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("ManicMan_EN").abilities[1].ability.visuals;

            FieldEffect_Apply_Effect f1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            f1._Field = StatusField.Shield;

            FieldEffect_Apply_Effect f2 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            f2._Field = StatusField.OnFire;

            FieldEffect_Apply_Effect f3 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            f3._Field = StatusField.Constricted;

            StatusEffect_Apply_Effect s1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s1._Status = StatusField.Focused;

            StatusEffect_Apply_Effect s2 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s2._Status = StatusField.Ruptured;

            StatusEffect_Apply_Effect s3 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s3._Status = StatusField.Frail;

            StatusEffect_Apply_Effect s4 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s4._Status = StatusField.OilSlicked;

            StatusEffect_Apply_Effect s5 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s5._Status = StatusField.Cursed;

            StatusEffect_Apply_Effect s6 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s6._Status = StatusField.Linked;

            StatusEffect_Apply_Effect s7 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s7._Status = StatusField.DivineProtection;

            StatusEffect_Apply_Effect s8 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            s8._Status = StatusField.Scars;

            Ability ability11 = new Ability("ElaboratePrank_A");
            ability11.Name = "Elaborate Prank";
            ability11.Description = "Inflicts 1 of most Status and Field effects to the Opposing party member.";
            ability11.Rarity = Abil.Weight(30);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(s1, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s2, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s3, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s4, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s5, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s6, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s7, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(s8, 1, Targeting.Slot_Front),

                  Effects.GenerateEffect(f1, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(f2, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(f3, 1, Targeting.Slot_Front),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc_Hidden.ToString() });
            ability11.AnimationTarget = Targeting.Slot_Front;
            ability11.Visuals = LoadedAssetsHandler.GetCharacter("Rags_CH").rankedData[0].rankAbilities[1].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, true);

        }
    }
}
