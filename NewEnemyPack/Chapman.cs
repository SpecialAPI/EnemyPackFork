using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Chapman
    {
        public static void Add()
        {



            Enemy enemy = new Enemy("Chapman", "Chapman_EN");
            enemy.Health = 22;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("ChapmanOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("ChapmanOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("ChapmanCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Chapman/ChapHurt";
            enemy.DeathSound = "event:/Chapman/ChapDeath";

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.InfestationGenerator(1) });
            enemy.PrepareEnemyPrefab("Assets/Chapman/Chapman.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Chapman/Giblets_Chapman.prefab").GetComponent<ParticleSystem>());

          

            InfestationRandomSetEffect infestationRandomSet = ScriptableObject.CreateInstance<InfestationRandomSetEffect>();
            infestationRandomSet._infestationPassive = (InfestationPassiveAbility)Passives.InfestationGenerator(1);

            Ability ability = new Ability("Headbutt_A");
            ability.Name = "Headbutt";
            ability.Description = "Deal a Painful amount of Damage to the Opposing party member.";
            ability.Rarity = Abil.Weight(6);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_Front),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = Passives.InfestationGenerator(1).passiveIcon;
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("InfestationIntent", InfestIntent);


            Ability ability1 = new Ability("ChapmanInfest_A");
            ability1.Name = "Infest";
            ability1.Description = "Apply 3 infestation spread randomly throughout every enemy.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(infestationRandomSet, 3, Targeting.Unit_AllAllies),


            };
            ability1.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { "InfestationIntent" });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;


            HealEffect healEffect = ScriptableObject.CreateInstance<HealEffect>();
            healEffect.usePreviousExitValue = true;

            Ability ability11 = new Ability("FruitsthatFeast_A");
            ability11.Name = "Fruits that Feast";
            ability11.Description = "Deals almost no damage to this enemy. Heals all other enemies an amount equal to the damage dealt.";
            ability11.Rarity = Abil.Weight(3);
            ability11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(healEffect, 1, Targeting.Unit_OtherAllies),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability11.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { IntentType_GameIDs.Heal_1_4.ToString() });
            ability11.AnimationTarget = Targeting.Slot_SelfSlot;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, false);




        }
    }
}

