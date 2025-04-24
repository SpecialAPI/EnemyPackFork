using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class DeadFlarb
    {
        public static void Add()
        {
            SetScreenFadeEffect set = ScriptableObject.CreateInstance<SetScreenFadeEffect>();
            set._fadeToBlack = true;            

            RefreshAbilityUseEffect refresh = ScriptableObject.CreateInstance<RefreshAbilityUseEffect>();
            refresh._doesExhaustInstead = true;


            SpawnEnemyInSlotFromEntryEffect move = ScriptableObject.CreateInstance<SpawnEnemyInSlotFromEntryEffect>();
            move.givesExperience = true;
            move.enemy = LoadedAssetsHandler.GetEnemy("Kekapex_EN");
            move._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();

            ChangeMusicParameterEffect changeMusicParameterEffect = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            changeMusicParameterEffect._parameter = (MusicParameter)778902;
            changeMusicParameterEffect._addition = true;

            PerformEffectPassiveAbility passive = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            passive._passiveName = "Decay";
            passive.passiveIcon = Passives.Example_Decay_MudLung.passiveIcon;
            passive.m_PassiveID = Passives.Example_Decay_MudLung.m_PassiveID;
            passive._enemyDescription = "Killing this enemy seems like a bad idea...";
            passive._characterDescription = "Upon this party member moving, Shields on their position move with them.";
            passive._triggerOn = new TriggerCalls[] { TriggerCalls.OnDeath};
            passive.doesPassiveTriggerInformationPanel = true;
            passive.effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(set, 5, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(refresh, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(changeMusicParameterEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllManaEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(move, 1, Targeting.Slot_SelfSlot),

            };

            Enemy enemy = new Enemy("Dying Flarb", "DyingFlarb_EN");
            enemy.Health = 15;
            enemy.HealthColor = Pigments.Purple;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("DeadFlarbOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("DeadFlarbOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("KekapexCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Flarb_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { passive, Passives.Anchored, Passives.Dying, Passives.Fleeting3 });
            enemy.PrepareEnemyPrefab("Assets/Kekapex/DeadFlarbBetter.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Kekapex/Giblets_DeadFlarb.prefab").GetComponent<ParticleSystem>());

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Struggle_A");
            enemyAbilityInfo.rarity = Abil.Weight(10);

            enemy.AddEnemyAbilities(new Ability[] {  });
            enemy.enemy.abilities.Add(enemyAbilityInfo);
            enemy.AddEnemy(false, false, false);

        }

    }
}
