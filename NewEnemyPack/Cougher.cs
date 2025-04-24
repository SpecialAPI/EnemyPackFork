using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Cougher
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Copper Cougher", "CopperCougher_EN");
            enemy.Health = 1;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("Cough", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").enemySprite;
            enemy.OverworldDeadSprite = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").enemySprite;
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering });
            enemy.PrepareEnemyPrefab("Assets/Cougher/Cougher.prefab", Main.assetBundle);

            Ability ability = new Ability("CopperCough_A");
            ability.Name = "Copper Cough";
            ability.Description = "Produce 1 Coin and Die unceremoniously.";
            ability.Rarity = Abil.Weight(6);
            ability.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraCurrencyEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_Currency.ToString(), IntentType_GameIDs.Damage_Death.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Nibble_A").visuals;

            List<EnemySO> list = new List<EnemySO>();
            list = ((SpawnRandomEnemyAnywhereEffect)LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").abilities[1].ability.effects[1].effect)._enemies;
            list.Add(enemy.enemy);

            enemy.AddEnemyAbilities(new Ability[] { ability});
            enemy.AddEnemy(true, false, true);


            SpawnRandomEnemyAnywhereEffect spawnRandom = ScriptableObject.CreateInstance<SpawnRandomEnemyAnywhereEffect>();
            spawnRandom._givesExperience = false;
            spawnRandom._spawnTypeID = CombatType_GameIDs.Spawn_Basic.ToString();
            spawnRandom._enemies = list;

            LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").abilities[1].ability.effects[1].effect = spawnRandom;
            LoadedAssetsHandler.GetEnemy("SilverSuckle_EN").abilities[0].ability.effects[2].effect = spawnRandom;

        }

    }
}
