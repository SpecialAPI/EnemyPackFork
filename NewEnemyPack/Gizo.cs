using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace NewEnemyPack
{
    internal class Gizo
    {
        public static void Add()
        {
            DamageWeakestEffect damageWeakestEffect = ScriptableObject.CreateInstance<DamageWeakestEffect>();
            damageWeakestEffect._returnKillAsSuccess = true;
            damageWeakestEffect._deathType = "Skinned";

            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.previousAmount = 1;
            previousEffectCondition.wasSuccessful = true;

            CasterTransformationEffect move3 = ScriptableObject.CreateInstance<CasterTransformationEffect>();
            move3._maintainMaxHealth = false;
            move3._currentToMaxHealth = false;
            move3._fullyHeal = true;
            move3._maintainTimelineAbilities = false;


            Ability flay = new Ability("Flay_A");
            flay.Name = "Flay";
            flay.Description = "Deal an Agonizing amount of damage to the enemy(s) with the lowest health. If an enemy is killed, become cozy.";
            flay.Rarity = Abil.Weight(0);
            flay.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(damageWeakestEffect, 7, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(move3, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true, 1)),


            };
            flay.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            flay.AnimationTarget = Targeting.Unit_OtherAllies;
            flay.Visuals = LoadedAssetsHandler.GetEnemy("ManicMan_EN").abilities[1].ability.visuals;
            flay.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = flay.ability;
            extraAbilityInfo.rarity = Abil.Weight(0);


            Enemy naked = new Enemy("Gizo", "NakedGizo_EN");
            naked.Health = 12;
            naked.HealthColor = Pigments.Red;
            naked.Size = 1;
            naked.UnitTypes = new List<string> { "Bird" };
            naked.CombatSprite = ResourceLoader.LoadSprite("NakedGizoIcon", new Vector2?(new Vector2(0.5f, 0f)));
            naked.OverworldAliveSprite = ResourceLoader.LoadSprite("NakedGizoOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            naked.OverworldDeadSprite = ResourceLoader.LoadSprite("GizoCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            naked.DamageSound = "event:/Gizo/GizoDmg";
            naked.DeathSound = "event:/Gizo/GizoDeath";

            naked.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery, Passives.BonusAttackGenerator(extraAbilityInfo) });
            naked.PrepareEnemyPrefab("assets/gizo/nakedgizo.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/gizo/giblets_nakedgizo.prefab").GetComponent<ParticleSystem>());

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Sob_A");
            enemyAbilityInfo.rarity = Abil.Weight(5);

            EnemyAbilityInfo enemyAbilityInfo1 = new EnemyAbilityInfo();
            enemyAbilityInfo1.ability = LoadedAssetsHandler.GetEnemyAbility("Nibble_A");
            enemyAbilityInfo1.rarity = Abil.Weight(5);

            naked.enemy.abilities.Add(enemyAbilityInfo);
            naked.enemy.abilities.Add(enemyAbilityInfo1);
            naked.AddEnemyAbilities(new Ability[] {  });
            naked.AddEnemy(true, true, true);

            Enemy enemy = new Enemy("Gizo", "Gizo_EN");
            enemy.Health = 25;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("GizoIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("GizoOverworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("GizoCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Gizo/GizoDmg";
            enemy.DeathSound = "event:/Gizo/GizoDeath";
            enemy.UnitTypes = new List<string> { "Bird" };
            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.DecayGenerator(naked.enemy, 60) });
            enemy.enemy.passiveAbilities[1]._enemyDescription = "Upon death this enemy has a 60% chance of being stripped naked.";
            enemy.PrepareEnemyPrefab("Assets/Gizo/Gizo.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Gizo/Giblets_SkinnedGizo.prefab").GetComponent<ParticleSystem>());

            AnimationVisualsEffect animationVisualsEffect = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisualsEffect._animationTarget = Targeting.Slot_Front;
            animationVisualsEffect._visuals = LoadedAssetsHandler.GetEnemy("Scrungie_EN").abilities[0].ability.visuals;

            Ability ability = new Ability("Lunge_A");
            ability.Name = "Lunge";
            ability.Description = "This enemy moves to the Left or Right.\nDeal an Agonizing amount of damage to the Opposing party member.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisualsEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Targeting.Slot_Front),
            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });

            RemoveFieldEffectsEffect removeFieldEffectsEffect = ScriptableObject.CreateInstance<RemoveFieldEffectsEffect>();
            removeFieldEffectsEffect.field = StatusField.Shield._FieldID;

            Ability ability1 = new Ability("StomachAcids_A");
            ability1.Name = "Stomach Acids";
            ability1.Description = "Remove all shield from the Opposing position.\nDeal a Painful amount of damage to the Opposing party member.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(removeFieldEffectsEffect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, Targeting.Slot_Front),
            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Rem_Field_Shield.ToString(), IntentType_GameIDs.Damage_3_6.ToString() });

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1 });
            enemy.AddEnemy(true, true, false);
            move3._enemyTransformation = enemy.enemy;



        }

    }
}
