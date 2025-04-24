using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Lipbug
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Lipbug", "Lipbug_EN");
            enemy.Health = 12;
            enemy.HealthColor = Pigments.Purple;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("LipBugIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("LipBugOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("LipBugCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").dxSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("LongLiver_CH").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Slippery });
            enemy.PrepareEnemyPrefab("Assets/LipBug/LipBug.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/LipBug/LipBug_Gibs.prefab").GetComponent<ParticleSystem>());

            RandomDamageBetweenPreviousAndEntryEffect daamge = ScriptableObject.CreateInstance<RandomDamageBetweenPreviousAndEntryEffect>();
            daamge._indirect = true;

            StoredValueParasiteEffect storedValueParasite = ScriptableObject.CreateInstance<StoredValueParasiteEffect>();
            storedValueParasite._initialize = true;
            storedValueParasite._usePreviousExitValue = true;

            CasterStoredValueChangeExitValueEffect increaseparasite = ScriptableObject.CreateInstance<CasterStoredValueChangeExitValueEffect>();
            increaseparasite._minimumValue = 0;
            increaseparasite._increase = true;
            increaseparasite.m_unitStoredDataID = UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString();

            CasterCheckStoredValueCondition checkparasite = ScriptableObject.CreateInstance<CasterCheckStoredValueCondition>();
            checkparasite._valueName = UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString();
            checkparasite.maximumAmount = 0;
            checkparasite.minimumAmount = -9999;

            PreviousEffectCondition fp1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            fp1.wasSuccessful = false;


            PreviousEffectCondition fp2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            fp2.wasSuccessful = false;
            fp2.previousAmount = 2;

            RemovePassiveEffect removePassiveEffect = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            removePassiveEffect.m_PassiveID = Passives.ParasiteParasitism.m_PassiveID;

            ParasitePassiveAbility harmful = ScriptableObject.CreateInstance<ParasitePassiveAbility>();
            harmful.doesPassiveTriggerInformationPanel = true;
            harmful.m_PassiveID = Passives.ParasiteParasitism.m_PassiveID;
            harmful._characterDescription = "Increases the damage received by 5% per point of Parasite. Parasite will decrease by the original unmutliplied damage amount. Parasite will remove 0-3 health from this Party Member at the start of every turn and convert it into more Parasite.";
            harmful._enemyDescription = "";
            harmful._isFriendly = false;
            harmful._passiveName = "Parasitism";
            harmful._damagePercentage = 5;
            harmful.passiveIcon = ResourceLoader.LoadSprite("ParasiteIcon");
            harmful._triggerOn = new TriggerCalls[] { TriggerCalls.OnTurnStart };
            harmful._secondTriggerOn = TriggerCalls.OnBeingDamaged;
            harmful._thirdTriggerOn = TriggerCalls.OnCombatEnd;
            harmful.effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(removePassiveEffect, 1, Targeting.Slot_SelfSlot, checkparasite),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot, fp1),
                  Effects.GenerateEffect(daamge, 3, Targeting.Slot_SelfSlot, fp2),
                  Effects.GenerateEffect(increaseparasite, 1, Targeting.Slot_SelfSlot),
            };
            harmful.connectionEffects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot),
            };
            harmful.disconnectionEffects = new EffectInfo[]
{
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot),
            };


            AddPassiveEffect addparasite = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addparasite._passiveToAdd = harmful;

            TargetStoredValueChangeEffect targetStoredValueChangeEffect = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            targetStoredValueChangeEffect._minimumValue = 0;
            targetStoredValueChangeEffect._valueName = UnitStoredValueNames_GameIDs.ParasiteCurrentHealthPA.ToString();
            targetStoredValueChangeEffect._increase = true;

            PreviousEffectCondition p1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            p1.wasSuccessful = true;


            PreviousEffectCondition p2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            p2.wasSuccessful = true;
            p2.previousAmount = 2;

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = Passives.ParasiteParasitism.passiveIcon;
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("ParasiteIntent", InfestIntent);

            Ability ability = new Ability("TongueBite_A");
            ability.Name = "Tongue Bite";
            ability.Description = "Apply 3 Parasitism to the opposing party member.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<CheckHasUnitEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(addparasite, 1, Targeting.Slot_Front, p1),
                  Effects.GenerateEffect(targetStoredValueChangeEffect, 3, Targeting.Slot_Front, p2),

            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "ParasiteIntent" });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Keko_EN").abilities[0].ability.visuals;

            EnemyAbilityInfo enemyAbilityInfo = new EnemyAbilityInfo();
            enemyAbilityInfo.ability = LoadedAssetsHandler.GetEnemyAbility("Sob_A");
            enemyAbilityInfo.rarity = Abil.Weight(5);

            enemy.AddEnemyAbilities(new Ability[] { ability });
            enemy.enemy.abilities.Add(enemyAbilityInfo);
            enemy.AddEnemy(true, true, false);

        }
    }
}
