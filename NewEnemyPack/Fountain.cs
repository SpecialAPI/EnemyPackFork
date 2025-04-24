using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Fountain
    {
        public static void Add()
        {
            
            SpawnRandomEnemyAnywhereEffect spawnRandomEnemyAnywhereEffect = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
            spawnRandomEnemyAnywhereEffect._enemies = ((SpawnMassivelyEverywhereUsingHealthEffect)LoadedAssetsHandler.GetEnemyAbility("Repent_A").effects[2].effect)._possibleEnemies;
            spawnRandomEnemyAnywhereEffect._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            SpawnRandomEnemyIfTheresSpaceAnywhereEffect spawnRandomEnemyAnywhereEffect1 = ScriptableObject.CreateInstance<SpawnRandomEnemyIfTheresSpaceAnywhereEffect>();
            spawnRandomEnemyAnywhereEffect1._enemies = ((SpawnMassivelyEverywhereUsingHealthEffect)LoadedAssetsHandler.GetEnemyAbility("Repent_A").effects[2].effect)._possibleEnemies;
            spawnRandomEnemyAnywhereEffect1._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();


            Ability bonusability = new Ability("AllureofEternity_A");
            bonusability.Name = "Allure of Eternity";
            bonusability.Description = "Attract an Enemy for assistance. If there are no Enemies attract 2 Instead.\n\"Too good to be true...\"";
            bonusability.Rarity = Abil.Weight(0);
            bonusability.Effects = new EffectInfo[]
            {             
                  Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(spawnRandomEnemyAnywhereEffect1, 1, Targeting.Slot_SelfSlot),

            };
            bonusability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Spawn.ToString() });
            bonusability.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = bonusability.ability;
            extraAbilityInfo.rarity = Abil.Weight(0);

            ExtraLootOptionsEffect extraLootOptionsEffect = ScriptableObject.CreateInstance<ExtraLootOptionsEffect>();
            extraLootOptionsEffect._itemName = "DivineMud_TW";

            Enemy enemy = new Enemy("The Fountain of Youth", "TheFountainofYouth_EN");
            enemy.Health = 100;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(-5);
            enemy.CombatSprite = ResourceLoader.LoadSprite("FounIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("FounOverWorld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("FounDeath", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("TaMaGoa_EN").deathSound;
            enemy.AddLootData(new EnemyLootItemProbability[]{
                new EnemyLootItemProbability
                {
                    isItemTreasure = true,
                    amount = 1,
                    probability = 100
                },
                   new EnemyLootItemProbability
                {
                    isItemTreasure = false,
                    amount = 1,
                    probability = 100
                },});
            enemy.CombatExitEffects = new EffectInfo[]
            {


                  Effects.GenerateEffect(extraLootOptionsEffect, 1, Targeting.Slot_AllySides), Effects.GenerateEffect(extraLootOptionsEffect, 1, Targeting.Slot_AllySides),Effects.GenerateEffect(extraLootOptionsEffect, 1, Targeting.Slot_AllySides),Effects.GenerateEffect(extraLootOptionsEffect, 1, Targeting.Slot_AllySides),Effects.GenerateEffect(extraLootOptionsEffect, 1, Targeting.Slot_AllySides),


            };


            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Anchored, Passives.Inanimate, Passives.BonusAttackGenerator(extraAbilityInfo) });
            enemy.PrepareEnemyPrefab("assets/fountain/fountain.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/fountain/foungibs.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.DivineProtection;

            Ability ability = new Ability("OnewiththeDivine_A");
            ability.Name = "One with the Divine";
            ability.Description = "Apply 3 Divine protection to the Left and Right enemies.";
            ability.Rarity = Abil.Weight(2);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_Apply_, 3, Targeting.Slot_AllySides),


            };
            ability.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Status_DivineProtection.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals;

            ConsumeColorManaEffect consumeColorMana = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana.mana = Pigments.Yellow;

            ConsumeColorManaEffect consumeColorMana1 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana1.mana = Pigments.Purple;

            ConsumeColorManaEffect consumeColorMana11 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana11.mana = Pigments.Red;

            ConsumeColorManaEffect consumeColorMana111 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana111.mana = Pigments.Blue;

            Ability ability1 = new Ability("PrismaticParasite_A");
            ability1.Name = "Prismatic Parasite";
            ability1.Description = "Consume 1 Pigment of each colour.\n\"The little that's left...\"";
            ability1.Rarity = Abil.Weight(2);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(consumeColorMana, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(consumeColorMana1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(consumeColorMana11, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(consumeColorMana111, 1, Targeting.Slot_SelfSlot),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Devour_A").visuals;

            Ability ability11 = new Ability("MudFever_A");
            ability11.Name = "Mud Fever";
            ability11.Description = "Grant the far Left and the Far right enemy a Bonus action.";
            ability11.Rarity = Abil.Weight(2);
            ability11.Effects = new EffectInfo[]
            {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, Targeting.Slot_AllyFarSides),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_AllyFarSides, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability11.AnimationTarget = Targeting.Slot_AllyFarSides;
            ability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("Devour_A").visuals;

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.Frail;

            Ability ability111 = new Ability("Salvation_A");
            ability111.Name = "Salvation";
            ability111.Description = "Fully heal the Left and Right enemy.\nInflict 2 Frail to the Left and Right enemy.";
            ability111.Rarity = Abil.Weight(2);
            ability111.Effects = new EffectInfo[]
            {

                Effects.GenerateEffect(ScriptableObject.CreateInstance<FullHealEffect>(), 1, Targeting.Slot_AllySides),
                  Effects.GenerateEffect(statusEffect_Apply_1, 2, Targeting.Slot_AllySides),


            };
            ability111.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Heal_11_20.ToString(), IntentType_GameIDs.Status_Frail.ToString() });
            ability111.AnimationTarget = Targeting.Slot_AllySides;
            ability111.Visuals = LoadedAssetsHandler.GetEnemyAbility("RapturousReverberation_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11, ability111 });
            enemy.AddEnemy(false, false, false);


        }

    }
}
