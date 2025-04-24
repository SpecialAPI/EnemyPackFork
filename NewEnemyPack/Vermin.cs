using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Vermin
    {
        public static void Add()
        {

            PerformEffectPassiveAbility fourfaced = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fourfaced._passiveName = "Decay";
            fourfaced.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            fourfaced.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            fourfaced._enemyDescription = "This enemy doesn't deserve to live, kill it to restore 3 Health to all Party members.";
            fourfaced._characterDescription = "This enemy doesn't deserve to live, kill it to restore 3 Health to all Party members.";
            fourfaced.conditions = Passives.Example_Decay_MudLung.conditions;
            fourfaced.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 3, Targeting.Unit_AllOpponents),

            };
            fourfaced._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath };


            Enemy enemy = new Enemy("Vermin", "Vermin_EN");
            enemy.Health = 20;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("ArnoldItem", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("ArnoldItem", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("ArnoldItem", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Fleeting3, fourfaced });
            enemy.PrepareEnemyPrefab("Assets/Vermin/Vermin.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Vermin/VerminGib.prefab").GetComponent<ParticleSystem>());

            ChangeMaxHealthEffect changeMaxHealth = ScriptableObject.CreateInstance<ChangeMaxHealthEffect>();
            changeMaxHealth._increase = false;

            Ability ability = new Ability("Iteatsaway_A");
            ability.Name = "It eats away";
            ability.Description = "Decrease the Opposing party member's maximum health by 3.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(changeMaxHealth, 3, Targeting.Slot_Front),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Other_MaxHealth.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Siphon_A").visuals;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.Constricted;

            Ability ability1 = new Ability("NoEscape_A");
            ability1.Name = "No Escape";
            ability1.Description = "Deal a Little amount of damage to the Opposing party member.\nInflict 2 Constricted to the opposing position.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front),
                   Effects.GenerateEffect(fieldEffect_Apply_, 2, Targeting.Slot_Front),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Field_Constricted.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Weep_A").visuals;

            StatusEffect_Apply_Effect effect_Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            effect_Apply_Effect._Status = StatusField.Cursed;

            Ability ability11 = new Ability("CertainFate_A");
            ability11.Name = "Certain Fate";
            ability11.Description = "Curse the Opposing party member.";
            ability11.Rarity = Abil.Weight(5);
            ability11.Effects = new EffectInfo[]
            {

                   Effects.GenerateEffect(effect_Apply_Effect, 1, Targeting.Slot_Front),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Cursed.ToString()});
            ability11.AnimationTarget = Targeting.Slot_Front;
            ability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, false, false);


        }
    }
}
