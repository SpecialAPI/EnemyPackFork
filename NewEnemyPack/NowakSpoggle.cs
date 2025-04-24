using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class NowakSpoggle
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Familiar Spoggle", "FamiliarSpoggle_EN");
            enemy.Health = 25;
            enemy.HealthColor = Pigments.Purple;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("NowakSpogOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("NowakSpogIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("NowakSpogCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Nowak_CH").deathSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Spoggle_Writhing_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Pure, Passives.Absorb});
            enemy.PrepareEnemyPrefab("Assets/Nowak Spoggle/NowakSpoggle.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Nowak Spoggle/Giblets_NowakSpoggle.prefab").GetComponent<ParticleSystem>());

            StatusEffect_ApplyIfPassive_Effect statusEffect_ApplyIfPassive_ = ScriptableObject.CreateInstance<StatusEffect_ApplyIfPassive_Effect>();
            statusEffect_ApplyIfPassive_._Status = StatusField.Stunned;
            statusEffect_ApplyIfPassive_.passive = Passives.Focus.m_PassiveID;

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Focused;

            Ability ability = new Ability("Recollection_A");
            ability.Name = "Recollection";
            ability.Description = "Inflict Stun to every party member with the Focus passive.\nApply Focused to this enemy.";
            ability.Rarity = Abil.Weight(7);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_ApplyIfPassive_, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(statusEffect_Apply_, 1, Targeting.Slot_SelfSlot),

            };
            ability.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Status_Stunned.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Focused.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A");
            enemyAbilityInfo.rarity = Abil.Weight(10);

            EnemyAbilityInfo enemyAbilityInfo1 = new EnemyAbilityInfo();
            enemyAbilityInfo1.ability = LoadedAssetsHandler.GetEnemyAbility("Siphon_A");
            enemyAbilityInfo1.rarity = Abil.Weight(10);

            enemy.enemy.abilities.Add(enemyAbilityInfo);
            enemy.enemy.abilities.Add(enemyAbilityInfo1);
            enemy.AddEnemyAbilities(new Ability[] { ability,  });
            enemy.AddEnemy(true, false, false);

        }

    }
}
