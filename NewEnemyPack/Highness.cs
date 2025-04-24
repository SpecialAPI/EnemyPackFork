using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Highness
    {
        public static void Add()
        {

            Enemy enemy = new Enemy("Heinous Highness", "HeinousHighness_EN");
            enemy.Health = 200;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("HighnessOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("HighnessOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("HighnessCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound;
            enemy.UnitTypes = new List<string> { "Bird" };
            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Anchored });
            enemy.PrepareEnemyPrefab("Assets/Highness/Highness.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Highness/Giblets_Revolting.prefab").GetComponent<ParticleSystem>());
            enemy.AddLootData(new EnemyLootItemProbability[]
{
                new EnemyLootItemProbability
                {
                    isItemTreasure = true,
                    amount = 3,
                    probability = 100
                },
                   new EnemyLootItemProbability
                {
                    isItemTreasure = true,
                    amount = 1,
                    probability = 50
                },

});

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Ruptured;

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.Scars;

            Ability ability = new Ability("ChaosDance_A");
            ability.Name = "Chaos Dance";
            ability.Description = "\"*clap, clap!*\"\n50% chance to inflict 1 Ruptured to each party member, and then shuffle all party members.\nInflict 1 Scar and 1 Ruptured to all other enemies.";
            ability.Rarity = Abil.Weight(7);
            ability.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Unit_AllOpponents, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(statusEffect_Apply_1, 1, Targeting.Unit_OtherAllies),

            };
            ability.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Swap_Mass.ToString() });
            ability.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Status_Scars.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Fandango_A").visuals;

            FieldEffect_Apply_Effect fieldEffect_Apply_Effect = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_Effect._Field = StatusField.Shield;

            Ability ability1 = new Ability("ViolentManipulation_A");
            ability1.Name = "Violent Manipulation";
            ability1.Description = "\"Stand your GROOOOUND WHILE FIGHTING ME!\"\nDeal a Painful amount of damage to the Left and Right party member, and a Painful amount of damage to the Left and Right enemy.\nApply 10 Shield to this enemy's position.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {         
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_OpponentSides),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_AllySides),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 10, Targeting.Slot_SelfSlot),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            ability1.AnimationTarget = Targeting.Slot_OpponentSides;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[0].ability.visuals;

            Ability ability11 = new Ability("ViolentAlteration_A");
            ability11.Name = "Violent Alteration";
            ability11.Description = "\"Am I being USURPED BY P#!$*ES!?\"\nDeal a Painful amount of damage to the Far Left and Far Right party member and a Painful amount of damage to the Far Left and Far Right enemy.\nApply 10 Shield to this enemy's position.";
            ability11.Rarity = Abil.Weight(10);
            ability11.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_OpponentFarSides),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_AllyFarSides),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 10, Targeting.Slot_SelfSlot),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_OpponentFarSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability11.AddIntentsToTarget(Targeting.Slot_AllyFarSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            ability11.AnimationTarget = Targeting.Slot_OpponentFarSides;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[0].ability.visuals;

            Ability ability111 = new Ability("DaggerTongue_A");
            ability111.Name = "Dagger Tongue";
            ability111.Description = "\"Impression and hatred are FAR from synonyms, you goddamn-\"\nDeal an Agonizing amount of damage to the Opposing party member, Move all other enemies to the Left or Right.\nApply 7 shield to this enemy's position.";
            ability111.Rarity = Abil.Weight(10);
            ability111.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(fieldEffect_Apply_Effect, 7, Targeting.Slot_SelfSlot),

            };
            ability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            ability111.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            ability111.AnimationTarget = Targeting.Slot_Front;
            ability111.Visuals = LoadedAssetsHandler.GetEnemy("Flarblet_EN").abilities[2].ability.visuals;


            Ability ability1111 = new Ability("PlayAlong_A");
            ability1111.Name = "Play Along";
            ability1111.Description = "\"I do not use buzzwords, trust-you-me.\"\nThis enemy performs a random one of its abilities.";
            ability1111.Rarity = Abil.Weight(5);
            ability1111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<PerformRandomAbilityFromEnemyOnFieldEnemyEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            ability1111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability1111.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1111.Visuals = LoadedAssetsHandler.GetCharacter("Anton_CH").rankedData[0].rankAbilities[2].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11,ability111,ability1111 });
            enemy.AddEnemy(true, false, false);


        }
    }
}
