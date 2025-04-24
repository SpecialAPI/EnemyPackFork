using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Revolting
    {
        public static void Add()
        {
            ChangeMusicParameterEffect close1 = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            close1._parameter = MusicParameter.RevolaStand;
            close1._addition = false;




            Enemy enemy = new Enemy("Revolting Revola", "RevoltingRevola_EN");
            enemy.Health = 65;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 2;
            enemy.UnitTypes = new List<string> { "Bird" };
            enemy.CombatSprite = ResourceLoader.LoadSprite("RevoltingIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("RevoltingIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("RevoltingCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Revola_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Revola_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Forgetful, Passives.Formless, Passives.Dying });
            enemy.PrepareEnemyPrefab("Assets/Revolting/Revolting.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Revolting/Giblets_Revolting.prefab").GetComponent<ParticleSystem>());
            enemy.CombatExitEffects = new EffectInfo[]
            {


                  Effects.GenerateEffect(close1, 1, Targeting.Slot_SelfSlot),


            };

            SetCasterAnimationParameterEffect demerge = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge._parameterName = "IsClose";
            demerge._parameterValue = 1;

            SetCasterAnimationParameterEffect demerge1 = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge1._parameterName = "IsClose";
            demerge1._parameterValue = 0;


            ChangeMusicParameterEffect close = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            close._parameter = MusicParameter.RevolaStand;


            SwapCasterPassivesEffect swapp1 = ScriptableObject.CreateInstance<SwapCasterPassivesEffect>();
            swapp1._passivesToSwap = new BasePassiveAbilitySO[] { Passives.Forgetful, Passives.Dying, Passives.Formless };
    
            StatusEffect_Apply_Effect _Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            _Apply_Effect._Status = StatusField.Scars;

            Ability standability = new Ability("PulledaMuscle_A");
            standability.Name = "Pulled a Muscle";
            standability.Description = "\"Strained too hard, pulled a muscle\"\nInflict 1 Scar to this enemy.";
            standability.Rarity = Abil.Weight(1);
            standability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(_Apply_Effect, 1, Targeting.Slot_SelfSlot),


            };
            standability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Scars.ToString() });
            standability.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;

            Ability standability1 = new Ability("TrumpetsoftheApocalypse_A");
            standability1.Name = "Trumpets of the Apocalypse";
            standability1.Description = "Inflicts 1 Scar to All party members.\nDeal an Agonizing amount of damage to All party members.\nObliterate this enemy.";
            standability1.Rarity = Abil.Weight(10);
            standability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(_Apply_Effect, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 9, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(demerge1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(close1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterPassivesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            standability1.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Status_Scars.ToString(), IntentType_GameIDs.Damage_7_10.ToString() });
            standability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Damage_Death.ToString() });
            standability1.AnimationTarget = Targeting.Unit_AllOpponents;
            standability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("FallingSkies_A").visuals;
            standability1.AbilitySprite = LoadedAssetsHandler.GetEnemyAbility("Crush_A").abilitySprite;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = standability.ability;
            extraAbilityInfo.rarity = Abil.Weight(1);

            ExtraAbilityInfo extraAbilityInfo1 = new ExtraAbilityInfo();
            extraAbilityInfo1.ability = standability1.ability;
            extraAbilityInfo1.rarity = Abil.Weight(10);

            SwapCasterAbilitiesEffect swapa = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            swapa._abilitiesToSwap = new ExtraAbilityInfo[] { extraAbilityInfo, extraAbilityInfo1 };

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.Shield;

            StatusEffect_Apply_Effect _Apply_Effect1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            _Apply_Effect1._Status = StatusField.Ruptured;

            StatusEffect_Apply_Effect _Apply_Effect11 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            _Apply_Effect11._Status = StatusField.OilSlicked;

            DamageEffect damage = ScriptableObject.CreateInstance<DamageEffect>();
            damage._indirect = true;

            Ability ability = new Ability("BellowingWail_A");
            ability.Name = "Bellowing Wail";
            ability.Description = "Deals an Agonizing amount of damage to the Opposing party members.\nApplies 10 Shield to this enemies position.\nInflict 2 Scars to this enemy.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 8, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_Apply_, 10, LoadedAssetsHandler.GetEnemyAbility("Bellow_A").effects[1].targets),
                  Effects.GenerateEffect(_Apply_Effect, 2, Targeting.Slot_SelfSlot),


            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_7_10.ToString() });
            ability.AddIntentsToTarget(LoadedAssetsHandler.GetEnemyAbility("Bellow_A").effects[1].targets, new string[] { IntentType_GameIDs.Field_Shield.ToString(), IntentType_GameIDs.Status_Scars.ToString() });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("Bellow_A").visuals;

            Ability ability1 = new Ability("InternalFluids_A");
            ability1.Name = "Internal Fluids";
            ability1.Description = "Inflicts 3 Oil-Slicked to All party members.\nInflicts 2 Ruptured to Opposing party members.\nDeals almost no Indirect damage to all party members.\nApply 2 Scars to this enemy.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(_Apply_Effect11, 3, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(_Apply_Effect1, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(damage, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(_Apply_Effect, 2, Targeting.Slot_SelfSlot),

            };
            ability1.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Status_OilSlicked.ToString(), IntentType_GameIDs.Damage_1_2.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Ruptured.ToString()});
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Scars.ToString() });
            ability1.AnimationTarget = Targeting.Unit_AllOpponents;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("FoulFluids_A").visuals;

            Ability ability11 = new Ability("LastStand_A");
            ability11.Name = "Last Stand";
            ability11.Description = "\"I'll see you in Hell.\"";
            ability11.Rarity = Abil.Weight(10);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(demerge, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(close, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapp1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapa, 1, Targeting.Slot_SelfSlot),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_State_Stand.ToString() });

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, false);

        }

    }
}
