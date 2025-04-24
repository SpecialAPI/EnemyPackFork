using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Unterling
    {
        public static void Add()
        {
            ClassicPassiveAbility classic = ScriptableObject.CreateInstance<ClassicPassiveAbility>();

            classic._passiveName = "Classic";
            classic.passiveIcon = ResourceLoader.LoadSprite("Classic");
            classic.m_PassiveID = "Classic_PA";
            classic._enemyDescription = "All damage this enemy receives is reduced to 1.";
            classic._characterDescription = "All damage this party member receives is reduced to 1";
            classic.doesPassiveTriggerInformationPanel = false;
            classic._triggerOn = new TriggerCalls[1] { TriggerCalls.OnBeingDamaged };

            Passives.AddCustomPassiveToPool("Classic_PA", "Classic", classic);
            GlossaryPassives passiveInfo = new GlossaryPassives("Classic", "All damage this enemy/party member receives is reduced to 1.", ResourceLoader.LoadSprite("Classic", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);

            Enemy enemy = new Enemy("Unterling", "Unterling_EN");
            enemy.Health = 5;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("WalkerIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("WalkerOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("WalkerCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Cranes_CH").dxSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Cranes_CH").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Forgetful, classic, Passives.Slippery, Passives.Overexert2 });
            enemy.PrepareEnemyPrefab("Assets/Walker/Walker.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Walker/Giblets_Walker.prefab").GetComponent<ParticleSystem>());

            SwapToOneSideEffect swapright = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapright._swapRight = true;

            SwapToOneSideEffect swapleft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapleft._swapRight = false;

            AnimationVisualsEffect slap = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            slap._animationTarget = Targeting.Slot_Front;
            slap._visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;

            RemoveFieldEffectsEffect removeFieldEffectsEffect = ScriptableObject.CreateInstance<RemoveFieldEffectsEffect>();
            removeFieldEffectsEffect.field = StatusField.Shield._FieldID;

            FieldEffect_Apply_Effect field = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            field._Field = StatusField.Shield;

            Ability ability = new Ability("Whimsy_A");
            ability.Name = "Whimsy";
            ability.Description = "Remove all Shield from this enemy position.\nApply 9 shield to this enemy's position.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(removeFieldEffectsEffect,1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(field,9, Targeting.Slot_SelfSlot),


            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Rem_Field_Shield.ToString(), IntentType_GameIDs.Field_Shield.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals;

            MultiPreviousEffectCondition multicon = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multicon.wasSuccessful = new bool[] { true, false };
            multicon.previousAmount = new int[] { 4, 6 };

            MultiPreviousEffectCondition multicon1 = ScriptableObject.CreateInstance<MultiPreviousEffectCondition>();
            multicon1.wasSuccessful = new bool[] { false, true, false };
            multicon1.previousAmount = new int[] { 5, 6, 7 };

            PreviousEffectCondition previousEffectfalseCondition1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectfalseCondition1.wasSuccessful = true;
            previousEffectfalseCondition1.previousAmount = 5;

            Ability ability1 = new Ability("Shoo_A");
            ability1.Name = "Shoo";
            ability1.Description = "Move this enemy to the Left or Right.\nDeal a Painful amount of damage to the Opposing party member.\nAttempt to move back to the previous position.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(swapleft,1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(swapright,1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(false,1)),
                  Effects.GenerateEffect(swapleft,1, Targeting.Slot_SelfSlot, Effects.CheckMultiplePreviousEffectsCondition(new bool[]{false,false}, new int[]{1,2})),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_Front),
                  Effects.GenerateEffect(swapright,1, Targeting.Slot_SelfSlot, previousEffectfalseCondition1),
                  Effects.GenerateEffect(swapright,1, Targeting.Slot_SelfSlot, multicon),
                  Effects.GenerateEffect(swapleft,1, Targeting.Slot_SelfSlot, multicon1),
            };
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString()});
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetCharacterAbility("Entrenched_1_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1 });
            enemy.AddEnemy(true, true, false);

        }

    }
}
