using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Unflarb
    {
        public static void Add()
        {
            HealIfPassiveEffect healIfPassive = ScriptableObject.CreateInstance<HealIfPassiveEffect>();
            healIfPassive.passiveid = Passives.Infantile.m_PassiveID;

            AnimationVisualsEffect animationVisualsEffect = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisualsEffect._animationTarget = Targeting.Slot_Front;
            animationVisualsEffect._visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;

            Ability pability = new Ability("PostMotermGuardian_A");
            pability.Name = "Post-mortem Guardian";
            pability.Description = "Retribution for violence against infants(?).\nMoves this enemy to the Left or Right.\nDeals a Painful amount of damage to Opposing party members.\nHeals all infantile enemies 1 health.";
            pability.Rarity = Abil.Weight(0);
            pability.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;
            pability.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisualsEffect, 1, Targeting.Slot_Front),
                   Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_Front),

            };
            pability.AddIntentsToTarget(Targeting.Unit_AllAllies, new string[] { IntentType_GameIDs.Heal_1_4.ToString() });
            pability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            pability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });


            ExtraAbilityInfo  extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = pability.GenerateEnemyAbility().ability;
            extraAbilityInfo.rarity = Abil.Weight(0);

            Enemy enemy = new Enemy("Unflarb", "Unflarb_EN");
            enemy.Health = 25;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 2;

            enemy.CombatSprite = ResourceLoader.LoadSprite("UnflarbIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("UnflarbOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("UnflarbCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Unflarb/UnflarbHurt";
            enemy.DeathSound = "event:/Unflarb/UnflarbDth";
            enemy.UnitTypes = new List<string> { "AmphibianID" };

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish,Passives.ParentalGenerator(extraAbilityInfo)});
            enemy.PrepareEnemyPrefab("assets/unflarb/unflarb.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/unflarb/giblets_unflarb.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Frail;

            Ability ability = new Ability("BoneCrush_A");
            ability.Name = "Bone Crush";
            ability.Description = "Inflict 2 Frail to the Opposing party members. Deals a Painful amount of damage to Opposing party members.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_Apply_, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, Targeting.Slot_Front),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;

            DamageEqualSpreadEffect damageEqualSpreadEffect = ScriptableObject.CreateInstance<DamageEqualSpreadEffect>();
            damageEqualSpreadEffect._indirect = true;
            damageEqualSpreadEffect._usePreviousExitValue = true;
            

            Ability ability1 = new Ability("SoulDevour_A");
            ability1.Name = "Soul Devour";
            ability1.Description = "Consumes all pigment.\nDeal Indirect damage equal to how much pigment was consumed to the Opposing party members, the damage will be spread equally among them.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeAllManaEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(damageEqualSpreadEffect, 1, Targeting.Slot_Front),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;



            enemy.AddEnemyAbilities(new Ability[] { ability, ability1 });
            enemy.AddEnemy(true, true, false);

            parental = pability;
            bonecrush = ability;
            souldevour = ability1;

        }
        public static BrutalAPI.Ability parental;
        public static BrutalAPI.Ability bonecrush;
        public static BrutalAPI.Ability souldevour;

    }
}
