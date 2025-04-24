using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Usurper
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Giggling Usurper", "GigglingUsurper_EN");
            enemy.Health = 50;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;
            enemy.Priority = Priority.Weight(-3);
            enemy.CombatSprite = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").enemySprite;
            enemy.OverworldAliveSprite = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").enemyOverworldSprite;
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("FlarbleftCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.OverexertGenerator(6), Passives.Formless, Passives.Slippery, Passives.Withering });

            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._ignoreShield = true;

            Ability ability = new Ability("WretchedTraitor_A");
            ability.Name = "Wretched Traitor";
            ability.Description = "Deal a Mortal amount of Shield-piercing damage to the Left and Right enemies.";
            ability.Rarity = Abil.Weight(50);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(damageEffect, 30, Targeting.Slot_AllySides),


            };
            ability.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_21.ToString() });
            ability.AnimationTarget = Targeting.Slot_AllySides;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;


            Ability ability2 = new Ability("WretchedTraitorAlt_A");
            ability2.Name = "Wretched Traitor";
            ability2.Description = "Deal a Mortal amount of Shield-piercing damage to the Left and Right enemies.";
            ability2.Rarity = Abil.Weight(50);
            ability2.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(damageEffect, 30, Targeting.Slot_AllySides),


            };
            ability2.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_21.ToString() });
            ability2.AnimationTarget = Targeting.Slot_AllySides;
            ability2.Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;

            Ability ability1 = new Ability("MarrowProber_A");
            ability1.Name = "Marrow Prober";
            ability1.Description = "Move this enemy to the Left or Right. Deal an Agonizing amount of Shield-piercing damage to the Left and Right enemies.";
            ability1.Rarity = Abil.Weight(70);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 10, Targeting.Slot_AllySides),
                  Effects.GenerateEffect(damageEffect, 10, Targeting.Slot_AllySides),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            ability1.AnimationTarget = Targeting.Slot_AllySides;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;

            Ability ability12 = new Ability("MarrowProberAlt_A");
            ability12.Name = "Marrow Prober";
            ability12.Description = "Move this enemy to the Left or Right. Deal an Agonizing amount of Shield-piercing damage to the Left and Right enemies.";
            ability12.Rarity = Abil.Weight(70);
            ability12.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 10, Targeting.Slot_AllySides),
                  Effects.GenerateEffect(damageEffect, 10, Targeting.Slot_AllySides),


            };
            ability12.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability12.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            ability12.AnimationTarget = Targeting.Slot_AllySides;
            ability12.Visuals = LoadedAssetsHandler.GetEnemyAbility("Talons_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability2, ability12 });
            enemy.AddEnemy(false,false, false);

            LoadedAssetsHandler.GetEnemy("GigglingUsurper_EN").enemyTemplate = LoadedAssetsHandler.GetEnemy("GigglingMinister_EN").enemyTemplate;
        }

    }
}
