using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Bud
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Sterile Bud", "SterileBud_EN");
            enemy.Health = 30;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("BudOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("BudOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("BudCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Leviat_CH").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Leviat_CH").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery });
            enemy.PrepareEnemyPrefab("Assets/Bud/Bud.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Bud/BudGibs.prefab").GetComponent<ParticleSystem>());

            DamageOnDoubleCascadeEffect damage = ScriptableObject.CreateInstance<DamageOnDoubleCascadeEffect>();
            damage._consistentCascade = true;
            damage._cascadeIsIndirect = true;
            damage._decreaseAsPercentage = true;
            damage._cascadeDecrease = 50;


            Ability ability = new Ability("EnemyDiscipline_A");
            ability.Name = "Discipline";
            ability.Description = "Deal an Agonizing amount of damage to the opposing party member. Damage will spread indirectly to the party members left and right.\nDeal a Painful amount of damage to the left and right enemy";
            ability.Rarity = Abil.Weight(14);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(damage, 10, Targeting.GenerateSlotTarget(new int[]{0,1,2,3,4,-1,-2,-3,-4}, false)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_AllySides),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Swap_Left.ToString(), IntentType_GameIDs.Damage_7_10.ToString(), IntentType_GameIDs.Swap_Right.ToString(), });
            ability.AddIntentsToTarget(Targeting.Slot_AllySides, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;


            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Frail;

            Ability ability1 = new Ability("Whip_A");
            ability1.Name = "Whip";
            ability1.Description = "Move this enemy left or right.\nInflict 2 Frail to the opposing party member.";
            ability1.Rarity = Abil.Weight(8);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(statusEffect_Apply_, 2, Targeting.Slot_Front),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Frail.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals;

            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._usePreviousExitValue = true;


            Ability ability11 = new Ability("UnravelThem_A");
            ability11.Name = "Unravel Them";
            ability11.Description = "Deal a Painful amount of damage to the Left and Right party members.\nDeal Damage equal to how much damage the Left and Right party member took, to the Opposing party member.";
            ability11.Rarity = Abil.Weight(10);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_OpponentSides),
                  Effects.GenerateEffect(damageEffect, 1, Targeting.Slot_Front),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability11.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability11.AnimationTarget = Targeting.Slot_FrontAndSides;
            ability11.Visuals = LoadedAssetsHandler.GetCharacterAbility("Malpractice_1_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, false);


        }

    }
}
