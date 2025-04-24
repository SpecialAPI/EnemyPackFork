using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class KleiverConductor
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Conductor", "ConductorEnemy_EN");
            enemy.Health = 70;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.Priority = LoadedAssetsHandler.GetEnemy("Conductor_EN").priority;
            enemy.CombatSprite = LoadedAssetsHandler.GetEnemy("Conductor_EN").enemySprite;
            enemy.OverworldAliveSprite = LoadedAssetsHandler.GetEnemy("Conductor_EN").enemyOverworldSprite;
            enemy.OverworldDeadSprite = LoadedAssetsHandler.GetEnemy("Conductor_EN").enemyOWCorpseSprite;
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Conductor_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Conductor_EN").deathSound;
            enemy.CombatEnterEffects = LoadedAssetsHandler.GetEnemy("Conductor_EN").enterEffects;
            enemy.CombatExitEffects = LoadedAssetsHandler.GetEnemy("Conductor_EN").exitEffects;
            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.MultiAttack2, Passives.Withering });

            CasterTransformationEffect casterTransformation = ScriptableObject.CreateInstance<CasterTransformationEffect>();
            casterTransformation._maintainMaxHealth = false;
            casterTransformation._currentToMaxHealth = false;
            casterTransformation._fullyHeal = true;
            casterTransformation._maintainTimelineAbilities = false;

            Ability ability = new Ability("ConductorFeelTheRhythmItem_A");
            ability.Name = "Feel the Rhythm";
            ability.Description = "\"Becomes the instrument of the Ungod.\"";
            ability.Rarity = Abil.Weight(7);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(casterTransformation, 1, Targeting.Slot_SelfSlot),


            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Transform_Instument.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("ConductorFeelTheRhythm_A").visuals;

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Bash_A");
            enemyAbilityInfo.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo1 = new EnemyAbilityInfo();
            enemyAbilityInfo1.ability = LoadedAssetsHandler.GetEnemyAbility("Weep_A");
            enemyAbilityInfo1.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo11 = new EnemyAbilityInfo();
            enemyAbilityInfo11.ability = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A");
            enemyAbilityInfo11.rarity = Abil.Weight(10);

            enemy.enemy.abilities.Add(enemyAbilityInfo);
            enemy.enemy.abilities.Add(enemyAbilityInfo1);
            enemy.enemy.abilities.Add(enemyAbilityInfo11);
            enemy.AddEnemyAbilities(new Ability[] { ability });
            enemy.AddEnemy(false, false, false);


            Enemy enemy1 = new Enemy("One Man Band", "OneManBandEnemy_EN");
            enemy1.Health = 60;
            enemy1.HealthColor = Pigments.Red;
            enemy1.Size = 1;
            enemy1.Priority = LoadedAssetsHandler.GetEnemy("Conductor_EN").priority;
            enemy1.CombatSprite = LoadedAssetsHandler.GetEnemy("OneManBand_EN").enemySprite;
            enemy1.OverworldAliveSprite = LoadedAssetsHandler.GetEnemy("OneManBand_EN").enemyOverworldSprite;
            enemy1.OverworldDeadSprite = LoadedAssetsHandler.GetEnemy("OneManBand_EN").enemyOWCorpseSprite;
            enemy1.DamageSound = LoadedAssetsHandler.GetEnemy("OneManBand_EN").damageSound;
            enemy1.DeathSound = LoadedAssetsHandler.GetEnemy("OneManBand_EN").deathSound;
            enemy1.CombatEnterEffects = LoadedAssetsHandler.GetEnemy("OneManBand_EN").enterEffects;
            enemy1.CombatExitEffects = LoadedAssetsHandler.GetEnemy("OneManBand_EN").exitEffects;
            enemy1.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.MultiAttack2, Passives.Withering, Passives.Abomination1 });

            EnemyAbilityInfo enemyAbilityInfo2 = new EnemyAbilityInfo();
            enemyAbilityInfo2.ability = LoadedAssetsHandler.GetEnemyAbility("StrikeAChord_A");
            enemyAbilityInfo2.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo21 = new EnemyAbilityInfo();
            enemyAbilityInfo21.ability = LoadedAssetsHandler.GetEnemyAbility("MelodicPassage_A");
            enemyAbilityInfo21.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo211 = new EnemyAbilityInfo();
            enemyAbilityInfo211.ability = LoadedAssetsHandler.GetEnemyAbility("MinorKey_A");
            enemyAbilityInfo211.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo2111 = new EnemyAbilityInfo();
            enemyAbilityInfo2111.ability = LoadedAssetsHandler.GetEnemyAbility("EarSplitter_A");
            enemyAbilityInfo2111.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo2121 = new EnemyAbilityInfo();
            enemyAbilityInfo2121.ability = LoadedAssetsHandler.GetEnemyAbility("Rupture_A");
            enemyAbilityInfo2121.rarity = Abil.Weight(10);


            EnemyAbilityInfo enemyAbilityInfo21211 = new EnemyAbilityInfo();
            enemyAbilityInfo21211.ability = LoadedAssetsHandler.GetEnemyAbility("FineTuning_A");
            enemyAbilityInfo21211.rarity = Abil.Weight(10);

            enemy1.enemy.abilities.Add(enemyAbilityInfo2);
            enemy1.enemy.abilities.Add(enemyAbilityInfo21);
            enemy1.enemy.abilities.Add(enemyAbilityInfo211);
            enemy1.enemy.abilities.Add(enemyAbilityInfo2121);
            enemy1.enemy.abilities.Add(enemyAbilityInfo2121);
            enemy1.enemy.abilities.Add(enemyAbilityInfo21211);
            enemy1.AddEnemy(false, false, false);

            casterTransformation._enemyTransformation = enemy1.enemy;

            LoadedAssetsHandler.GetEnemy("OneManBandEnemy_EN").enemyTemplate = LoadedAssetsHandler.GetEnemy("OneManBand_EN").enemyTemplate;
            LoadedAssetsHandler.GetEnemy("ConductorEnemy_EN").enemyTemplate = LoadedAssetsHandler.GetEnemy("Conductor_EN").enemyTemplate;
        }
    }
}
