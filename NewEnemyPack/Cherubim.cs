using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Cherubim
    {
        public static void Add()
        {

            ChangeToRandomHealthColorEffect changeToRandomHealthColor = ScriptableObject.CreateInstance<ChangeToRandomHealthColorEffect>();
            changeToRandomHealthColor._healthColors = new ManaColorSO[] { Pigments.Red, Pigments.Yellow, Pigments.Blue, Pigments.Purple };

            PerformEffectPassiveAbility fourfaced = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            fourfaced._passiveName = "Four-Faced";
            fourfaced.m_PassiveID = "FourFaced_PA";
            fourfaced.passiveIcon = ResourceLoader.LoadSprite("FourFaced");
            fourfaced._enemyDescription = "Upon being damaged, randomize this enemy's health colour.";
            fourfaced._characterDescription = "Upon being damaged, randomize this party member's health colour.";
            fourfaced.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(changeToRandomHealthColor, 1, Targeting.Slot_SelfSlot),

            };
            fourfaced._triggerOn = new TriggerCalls[] { TriggerCalls.OnDirectDamaged };


            Passives.AddCustomPassiveToPool("FourFaced_PA", "Four-Faced", fourfaced);
            GlossaryPassives passiveInfo = new GlossaryPassives("Four-Faced", "Upon being damaged, randomize this enemy/party member's health colour.", ResourceLoader.LoadSprite("FourFaced", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);

            PerformImmediateEffectPassiveAbility fourfaced1 = ScriptableObject.CreateInstance<PerformImmediateEffectPassiveAbility>();
            fourfaced1._passiveName = "Leaky (1)";
            fourfaced1.passiveIcon = LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").passiveAbilities[0].passiveIcon;
            fourfaced1._enemyDescription = LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").passiveAbilities[0]._enemyDescription;
            fourfaced1._characterDescription = LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").passiveAbilities[0]._characterDescription;
            fourfaced1.effects = ((PerformEffectPassiveAbility)LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").passiveAbilities[0]).effects;
            fourfaced1._triggerOn = LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").passiveAbilities[0]._triggerOn;
            fourfaced1.m_PassiveID = LoadedAssetsHandler.GetCharacter("SmokeStacks_CH").passiveAbilities[0].m_PassiveID;

            Enemy enemy = new Enemy("Cherubim", "Cherubim_EN");
            enemy.Health = 80;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("CherubimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("CherubimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("CherubimCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Wringle_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish, Passives.Absorb, fourfaced1, fourfaced, Passives.MultiAttack4 });
            enemy.PrepareEnemyPrefab("Assets/Cherubim/Cherubim.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Cherubim/Giblets_MudLung.prefab").GetComponent<ParticleSystem>());
            enemy.AddLootData(new EnemyLootItemProbability[]{
                new EnemyLootItemProbability
                {
                    isItemTreasure = true,
                    amount = 1,
                    probability = 100
                },
                   new EnemyLootItemProbability
                {
                    isItemTreasure = false,
                    amount = 1,
                    probability = 100
                },});

            

            

            ConsumeColorManaEffect consumeColorMana = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana.mana = Pigments.Purple;

            PreviousExitValueChecker previousExitValue = ScriptableObject.CreateInstance<PreviousExitValueChecker>();
            previousExitValue.howmuch = 3;

            PreviousEffectCondition previousEffect = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffect.wasSuccessful = true;
            previousEffect.previousAmount = 1;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.Shield;
            fieldEffect_Apply_._UseRandomBetweenPrevious = true;

            StatusEffect_ApplyWeakest_Effect statusEffect_Apply = ScriptableObject.CreateInstance<StatusEffect_ApplyWeakest_Effect>();
            statusEffect_Apply._Status = StatusField.Cursed;

            Ability ability = new Ability("FloodsFromTheGarden_A");
            ability.Name = "Floods from the Garden";
            ability.Description = "Apply 0-3 shield to every enemy position besides own.\nConsume 3 Purple pigment.\nIf 3 pigment have been consumed, Curse the party member with the highest health. Ignores already Cursed party members.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(fieldEffect_Apply_, 3, Targeting.GenerateSlotTarget(new int[]{-4,-3,-2,-1,1,2,3,4}, true)),
                  Effects.GenerateEffect(consumeColorMana, 3, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(previousExitValue, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(statusEffect_Apply, 1, Targeting.Unit_AllOpponents,previousEffect),

            };
            ability.AddIntentsToTarget(Targeting.Unit_OtherAlliesSlots, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Status_Cursed.ToString() });
            ability.AnimationTarget = Targeting.Slot_SelfSlot;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("DrippingsOfTheGarden_A").visuals;

            ConsumeColorManaEffect consumeColorMana1 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana1.mana = Pigments.Red;

            AnimationVisualsEffect animationVisuals = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisuals._animationTarget = Targeting.Slot_Front;
            animationVisuals._visuals = ((AnimationVisualsEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("DemonCore_SW")).effects[0].effect)._visuals;

            PreviousEffectCondition previousEffect1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffect1.wasSuccessful = true;
            previousEffect1.previousAmount = 2;

            PreviousEffectCondition previousEffect2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffect2.wasSuccessful = true;
            previousEffect2.previousAmount = 3;

            PreviousEffectCondition previousEffect3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffect3.wasSuccessful = true;
            previousEffect3.previousAmount = 4;         

            Ability ability1 = new Ability("AbandonAllHope_A");
            ability1.Name = "Abandon All Hope";
            ability1.Description = "Deal a Painful amount of damage to the Left and Right party members.\nConsume 3 Red pigment.\nIf 3 pigment have been consumed, deal a Lethal amount of Damage to all party members and destroy this enemy.";
            ability1.Rarity = Abil.Weight(4);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, Targeting.Slot_OpponentSides),
                  Effects.GenerateEffect(consumeColorMana1, 3, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(previousExitValue, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(animationVisuals, 1, Targeting.Slot_SelfSlot, previousEffect),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 15, Targeting.Unit_AllOpponents, previousEffect1),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_SelfSlot, previousEffect2),

            };
            ability1.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Consume.ToString(), IntentType_GameIDs.Damage_Death.ToString() });
            ability1.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Damage_11_15.ToString()});
            ability1.AnimationTarget = Targeting.Slot_OpponentSides;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals;
                
            FieldEffect_ApplyRandomTarget_Effect fieldEffect_ApplyRandomTarget_ = ScriptableObject.CreateInstance<FieldEffect_ApplyRandomTarget_Effect>();
            fieldEffect_ApplyRandomTarget_._Field = StatusField.OnFire;

            FieldEffect_Apply_Effect fieldEffect_Apply_1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_1._Field = StatusField.OnFire;   

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._JustOneRandomTarget = true;
            statusEffect_Apply_1._Status = StatusField.OilSlicked;

            ConsumeColorManaEffect consumeColorMana11 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana11.mana = Pigments.Yellow;

            Ability ability11 = new Ability("BowlsOfFire_A");
            ability11.Name = "Bowls of Fire";
            ability11.Description = "Inflict 1 Fire to 1-2 Random party member positions.\nConsume 3 Yellow pigment.\nIf 3 pigment have been consumed, inflict 1 Fire to all party member positions, and 1 Oil-slicked to 3 random party members.";
            ability11.Rarity = Abil.Weight(10);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(fieldEffect_ApplyRandomTarget_, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(fieldEffect_ApplyRandomTarget_, 1, Targeting.Unit_AllOpponents, Conditions.Chance(50)),
                  Effects.GenerateEffect(consumeColorMana11, 3, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(previousExitValue, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(fieldEffect_Apply_1 , 1, Targeting.Unit_AllOpponents, previousEffect),
                  Effects.GenerateEffect(statusEffect_Apply_1 , 1, Targeting.Unit_AllOpponents, previousEffect1),
                  Effects.GenerateEffect(statusEffect_Apply_1 , 1, Targeting.Unit_AllOpponents, previousEffect2),
                  Effects.GenerateEffect(statusEffect_Apply_1 , 1, Targeting.Unit_AllOpponents, previousEffect3),
            };
            ability11.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Field_Fire.ToString(), IntentType_GameIDs.Status_OilSlicked.ToString() });
            ability11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability11.AnimationTarget = Targeting.Unit_AllOpponents;
            ability11.Visuals = LoadedAssetsHandler.GetEnemyAbility("Pyre_A").visuals;

            ConsumeColorManaEffect consumeColorMana111 = ScriptableObject.CreateInstance<ConsumeColorManaEffect>();
            consumeColorMana111.mana = Pigments.Blue;

            StatusEffect_Apply_Effect effect_Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            effect_Apply_Effect._Status = StatusField.Ruptured;

            Ability ability111 = new Ability("RapturousRupture_A");
            ability111.Name = "Rapturous Rupture";
            ability111.Description = "Move Left or Right and inflict 2 Ruptured to the Opposing party member.\nConsume 3 Blue pigment.\nIf 3 pigment have been consumed, inflict 1 Ruptured to all party members.";
            ability111.Rarity = Abil.Weight(10);
            ability111.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(effect_Apply_Effect, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(consumeColorMana111, 3, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(previousExitValue, 1, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(effect_Apply_Effect, 1, Targeting.Unit_AllOpponents, previousEffect),

            };         
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Mana_Consume.ToString() });
            ability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            ability111.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            ability111.AnimationTarget = Targeting.Slot_SelfSlot;
            ability111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Exsanguinate_A").visuals;

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A");
            enemyAbilityInfo.rarity = Abil.Weight(10);


            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11, ability111 });

            enemy.enemy.abilities.Add(enemyAbilityInfo);

            enemy.AddEnemy(true, false, false);

   

         



        }

    }
}
