using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Maestro
    {
        public static void Add()
        {

            ChangeMusicParameterEffect changeMusicParameterEffect = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            changeMusicParameterEffect._parameter = (MusicParameter)778931;
            changeMusicParameterEffect._addition = false;


            ChangeMusicParameterEffect changeMusicParameterEffect1 = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            changeMusicParameterEffect1._parameter = (MusicParameter)778931;
            changeMusicParameterEffect1._addition = true;

            Targetting_BySlot_Index selfAllSlots = ScriptableObject.CreateInstance<Targetting_BySlot_Index>();
            selfAllSlots.getAllies = true;
            selfAllSlots.allSelfSlots = true;
            selfAllSlots.slotPointerDirections = new int[] { 0 };

            StatusEffect_Apply_Effect statusEffect_Apply_11 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_11._Status = StatusField.Scars;

            Ability ability11 = new Ability("VoiceCrack_A");
            ability11.Name = "Voice Crack";
            ability11.Description = "\"Ungoddamnit.\nInflict 1 Scars to this enemy.";
            ability11.Rarity = Abil.Weight(0);
            ability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_Apply_11, 1, Targeting.Slot_SelfSlot),


            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Scars.ToString() });
            ability11.AnimationTarget = selfAllSlots;
            ability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("CryOut_A").visuals;
            ability11.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("CryOut_A").abilitySprite;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = ability11.ability;
            extraAbilityInfo.rarity = Abil.Weight(0);


            Enemy enemy = new Enemy("Maestro", "Maestro_EN");
            enemy.Health = 90;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 3;
            enemy.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(changeMusicParameterEffect, 1, Targeting.Slot_SelfSlot),  };
            enemy.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(changeMusicParameterEffect1, 1, Targeting.Slot_SelfSlot), };
            enemy.CombatSprite = ResourceLoader.LoadSprite("Maestro_overworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("Maestro_overworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("SingingMountain_corpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("OneManBand_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("OneManBand_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Anchored, Passives.MultiAttack2, Passives.OverexertGenerator(14), Passives.BonusAttackGenerator(extraAbilityInfo)});
            enemy.PrepareEnemyPrefab("assets/maestro/maestro.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/maestro/mountmaestrogib.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.Ruptured;

            Ability ability = new Ability("Reverence_A");
            ability.Name = "Reverence";
            ability.Description = "Deal a Painful amount of Damage to the Opposing party members.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 6, Targeting.Slot_Front),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;

            Ability ability1 = new Ability("Travesty_A");
            ability1.Name = "Travesty";
            ability1.Description = "Inflict 1 Ruptured to All party members not opposing this enemy.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_Apply_1, 1, Targeting.Slot_OpponentAllLefts),
                  Effects.GenerateEffect(statusEffect_Apply_1, 1, Targeting.Slot_OpponentAllRights),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentAllLefts, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentAllRights, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            ability1.AnimationTarget = selfAllSlots;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals;


            enemy.AddEnemyAbilities(new Ability[] { ability, ability1 });
            enemy.AddEnemy(true, false, false);


        }
    }
}
