using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace NewEnemyPack
{
    internal class Unicorn
    {
        public static void Add()
        {

            CasterStoreValueSetterEffect casterStoreValueSetter = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            casterStoreValueSetter._ignoreIfContains = false;
            casterStoreValueSetter.m_unitStoredDataID = "UniComedyValue";

            TryUnlockAchievementIfValueEffect tryUnlockAchievementIfValue = ScriptableObject.CreateInstance<TryUnlockAchievementIfValueEffect>();
            tryUnlockAchievementIfValue._unlockID = "UnicornComedy";



            

            Enemy elemental = new Enemy("Human Elemental", "HumanElemental_EN");
            elemental.Health = 666;
            elemental.HealthColor = Pigments.Red;
            elemental.Size = 1;
            elemental.Priority = Priority.Weight(3);
            elemental.CombatSprite = ResourceLoader.LoadSprite("evisceratedsoul_icon", new Vector2?(new Vector2(0.5f, 0f)));
            elemental.OverworldAliveSprite = ResourceLoader.LoadSprite("evisceratedsoul_icon", new Vector2?(new Vector2(0.5f, 0f)));
            elemental.OverworldDeadSprite = ResourceLoader.LoadSprite("evisceratedsoul_icon", new Vector2?(new Vector2(0.5f, 0f)));
            elemental.DamageSound = LoadedAssetsHandler.GetEnemy("HeavensGateBlue_BOSS").damageSound;
            elemental.DeathSound = LoadedAssetsHandler.GetEnemy("HeavensGateBlue_BOSS").deathSound;
            elemental.CombatExitEffects = new EffectInfo[] { Effects.GenerateEffect(tryUnlockAchievementIfValue, 1, Targeting.Slot_SelfSlot) };
            elemental.AddPassives(new BasePassiveAbilitySO[] { Passives.Withering, Passives.Formless });
            elemental.PrepareEnemyPrefab("assets/humansoul/soul.prefab", Main.assetBundle);

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Ruptured;

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.OilSlicked;

            Ability basaltear = new Ability("BasalTear_A");
            basaltear.Name = "Basal Tear";
            basaltear.Description = "\"My guts lay splattered across the floor, and it feels like how they're meant to be arranged by nature.\"\nMove this enemy to the Left or Right.\nInflict 2 Ruptured to the Opposing party member.";
            basaltear.Rarity = Abil.Weight(6);
            basaltear.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(statusEffect_Apply_, 2, Targeting.Slot_Front),


            };
            basaltear.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            basaltear.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            basaltear.AnimationTarget = Targeting.Slot_SelfSlot;
            basaltear.Visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals;

            Ability screech = new Ability("OthersideScreech_A");
            screech.Name = "Otherside Screech";
            screech.Description = "\"I'm not my brain, I'm my eyes.\"\nMove this enemy to the Left or Right.\nInflict 2 Ruptured to the Left and Right party member.";
            screech.Rarity = Abil.Weight(6);
            screech.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(statusEffect_Apply_, 2, Targeting.Slot_OpponentSides),


            };
            screech.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            screech.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            screech.AnimationTarget = Targeting.Slot_SelfSlot;
            screech.Visuals = LoadedAssetsHandler.GetEnemyAbility("CryOut_A").visuals;

            Ability circuit = new Ability("DemonCircuit_A");
            circuit.Name = "Demon Circuit";
            circuit.Description = "\"Coding for reflexes of long-obsolete terrors claw and shred their way out of my cells.\"\nInflict 1 Oil-Slicked to the Left, Right, and Opposing party member.";
            circuit.Rarity = Abil.Weight(4);
            circuit.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(statusEffect_Apply_1, 1, Targeting.Slot_FrontAndSides),


            };
            circuit.AddIntentsToTarget(Targeting.Slot_FrontAndSides, new string[] { IntentType_GameIDs.Status_OilSlicked.ToString() });
            circuit.AnimationTarget = Targeting.Slot_SelfSlot;
            circuit.Visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;

            elemental.AddEnemyAbilities(new Ability[] { basaltear, screech, circuit });
            elemental.AddEnemy(true, false, false);

            SetCasterAnimationParameterEffect demerge = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge._parameterName = "IsClose";
            demerge._parameterValue = 1;

            SetCasterAnimationParameterEffect demerge1 = ScriptableObject.CreateInstance<SetCasterAnimationParameterEffect>();
            demerge1._parameterName = "IsClose";
            demerge1._parameterValue = 0;


            ChangeMusicParameterEffect close = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            close._parameter = (MusicParameter)7789334;

            ChangeMusicParameterEffect close1 = ScriptableObject.CreateInstance<ChangeMusicParameterEffect>();
            close1._parameter = (MusicParameter)7789334;
            close1._addition = false;

            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Combat/Attack/Boss/Signature/ATK_Boss_Charcarrion_Messiah";
            attackVisualsSO.isAnimationFullScreen = true;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/Unicorn/UnicornSpecialAttack.anim");

            AddPassiveIfSoulEffect addPassiveIfSoul = ScriptableObject.CreateInstance<AddPassiveIfSoulEffect>();
            addPassiveIfSoul._passiveToAdd = Passives.MultiAttack3;
            addPassiveIfSoul._enemyToAdd = elemental.enemy;

            AddPassiveIfSoulEffect addPassiveIfSoul1 = ScriptableObject.CreateInstance<AddPassiveIfSoulEffect>();
            addPassiveIfSoul1._passiveToAdd = Passives.Slippery;
            addPassiveIfSoul1._enemyToAdd = elemental.enemy;

            RemovePassiveIfSoulEffect removePassiveIfSoulEffect = ScriptableObject.CreateInstance<RemovePassiveIfSoulEffect>();
            removePassiveIfSoulEffect.m_PassiveID = Passives.MultiAttack3.m_PassiveID;
            removePassiveIfSoulEffect._enemy = elemental.enemy;

            RemovePassiveIfSoulEffect removePassiveIfSoulEffect1 = ScriptableObject.CreateInstance<RemovePassiveIfSoulEffect>();
            removePassiveIfSoulEffect1.m_PassiveID = Passives.Slippery.m_PassiveID;
            removePassiveIfSoulEffect1._enemy = elemental.enemy;

            SwapCasterPassivesEffect swapCasterPassives = ScriptableObject.CreateInstance<SwapCasterPassivesEffect>();
            swapCasterPassives._passivesToSwap = new BasePassiveAbilitySO[] { Passives.BoneSpursGenerator(0), Passives.Skittish };

            CasterStoreValueSetterEffect casterStoreValueSetterEffect = ScriptableObject.CreateInstance<CasterStoreValueSetterEffect>();
            casterStoreValueSetterEffect.m_unitStoredDataID = UnitStoredValueNames_GameIDs.BoneSpursPA.ToString();

            Ability transhuman = new Ability("TranshumanSubhuman_A");
            transhuman.Name = "Transhuman Subhuman";
            transhuman.Description = "The horrible mistake reveals itself.";
            transhuman.Rarity = Abil.Weight(0);
            transhuman.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(removePassiveIfSoulEffect, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(removePassiveIfSoulEffect1, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(demerge1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(close1, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterAbilitiesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ResetCasterPassivesToDefaultEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(casterStoreValueSetterEffect, 0, Targeting.Slot_SelfSlot),


            };
            transhuman.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_State_Stand.ToString() });
            transhuman.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;
            transhuman.AnimationTarget = Targeting.Slot_SelfSlot;
            transhuman.Visuals = attackVisualsSO;

            ExtraAbilityInfo extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.rarity = Abil.Weight(1);
            extraAbilityInfo.ability = transhuman.ability;

            SwapCasterAbilitiesEffect swapCasterAbilitiesEffect = new SwapCasterAbilitiesEffect();
            swapCasterAbilitiesEffect._abilitiesToSwap = new ExtraAbilityInfo[] { extraAbilityInfo };

           

            Ability inlapse = new Ability("Inlapse_A");
            inlapse.Name = "Inlapse";
            inlapse.Description = "The abomination hides into its ruined body.";
            inlapse.Rarity = Abil.Weight(0);
            inlapse.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(addPassiveIfSoul, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(addPassiveIfSoul1, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(demerge, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(close, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapCasterPassives, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(swapCasterAbilitiesEffect, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(casterStoreValueSetterEffect, 10, Targeting.Slot_SelfSlot),


            };
            inlapse.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Misc_State_Sit.ToString() });
            inlapse.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;

            ExtraAbilityInfo extraAbilityInfo1 = new ExtraAbilityInfo();
            extraAbilityInfo1.rarity = Abil.Weight(0);
            extraAbilityInfo1.ability = inlapse.ability;


            Enemy unicorn = new Enemy("Malformed Unicorn", "MalformedUnicorn_BOSS");
            unicorn.Health = 100;
            unicorn.HealthColor = Pigments.Purple;
            unicorn.Size = 1;

            unicorn.CombatSprite = ResourceLoader.LoadSprite("Unicorn_icon", new Vector2?(new Vector2(0.5f, 0f)));
            unicorn.OverworldAliveSprite = ResourceLoader.LoadSprite("Unicorn_icon", new Vector2?(new Vector2(0.5f, 0f)));
            unicorn.OverworldDeadSprite = ResourceLoader.LoadSprite("Unicorn_icon", new Vector2?(new Vector2(0.5f, 0f)));
            unicorn.DamageSound = "event:/Characters/NPC/DLC_02/CHR_NPC_DollMaster_Masked_Dx";
            unicorn.DeathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;

            unicorn.AddPassives(new BasePassiveAbilitySO[] { Passives.MultiAttack3, Passives.BonusAttackGenerator(extraAbilityInfo1)});
            unicorn.PrepareEnemyPrefab("Assets/Unicorn/Unicorn.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Unicorn/Giblets_Unicorn.prefab").GetComponent<ParticleSystem>());


            MoreDamageIfStatusEffect moreDamageIfStatusEffect = ScriptableObject.CreateInstance<MoreDamageIfStatusEffect>();
            moreDamageIfStatusEffect._status = StatusField.Ruptured.StatusID;
            moreDamageIfStatusEffect._increaseamount = 3;

            Ability decapitate = new Ability("Decapitate_A");
            decapitate.Name = "Decapitate";
            decapitate.Description = "Deal a Painful amount of Damage to the Opposing party member.\nIf the party member is Ruptured, deal an Agonizing amount of Damage instead.";
            decapitate.Rarity = Abil.Weight(5);
            decapitate.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(moreDamageIfStatusEffect, 4, Targeting.Slot_Front),


            };
            decapitate.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Damage_7_10.ToString() });
            decapitate.AnimationTarget = Targeting.Slot_Front;
            decapitate.Visuals = LoadedAssetsHandler.GetCharacter("Bimini_CH").rankedData[0].rankAbilities[1].ability.visuals;
            decapitate.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;

            Ability decapitate1 = new Ability("Quarter_A");
            decapitate1.Name = "Quarter";
            decapitate1.Description = "Deal a Painful amount of Damage to the Left and Right party members.\nIf the target party member is Ruptured, deal an Agonizing amount of Damage to them instead.\nMove this enemy to the Left or Right.";
            decapitate1.Rarity = Abil.Weight(5);
            decapitate1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(moreDamageIfStatusEffect, 4, Targeting.Slot_OpponentSides),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            decapitate1.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc.ToString(), IntentType_GameIDs.Damage_7_10.ToString() });
            decapitate1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), });
            decapitate1.AnimationTarget = Targeting.Slot_OpponentSides;
            decapitate1.Visuals = LoadedAssetsHandler.GetCharacter("Nowak_CH").rankedData[0].rankAbilities[2].ability.visuals;
            decapitate1.AbilitySprite = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.abilitySprite;

            unicorn.AddEnemyAbilities(new Ability[] { decapitate, decapitate1});
            unicorn.AddEnemy(true, false, false);

        }
    }
}
