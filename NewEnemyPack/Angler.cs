using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Angler
    {
        public static void Add()
        {
            

            ShieldingPassiveAbility passive = ScriptableObject.CreateInstance<ShieldingPassiveAbility>();

            passive._passiveName = "Aegis";
            passive.passiveIcon = ResourceLoader.LoadSprite("PermaShieldIcon");
            passive.m_PassiveID = "Aegis_PA";
            passive._enemyDescription = "Upon this enemy moving, Shields on their position move with them.";
            passive._characterDescription = "Upon this party member moving, Shields on their position move with them.";
            passive._triggerOn = new TriggerCalls[] { TriggerCalls.OnMoved };
            passive._Field = StatusField.Shield;

            Passives.AddCustomPassiveToPool("Aegis_PA", "Aegis", passive);
            GlossaryPassives passiveInfo = new GlossaryPassives("Aegis", "Upon this enemy/party member moving, Shields on their position move with them.", ResourceLoader.LoadSprite("PermaShieldIcon", null, 32, null));
            LoadedDBsHandler.GlossaryDB.AddNewPassive(passiveInfo);


            FieldEffect_Apply_Effect fieldEffect_Apply_Effect = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_Effect._Field = StatusField.Shield;

            Targetting_BySlot_Index targetting_BySlot_Index3 = ScriptableObject.CreateInstance<Targetting_BySlot_Index>();
            targetting_BySlot_Index3.getAllies = true;
            targetting_BySlot_Index3.allSelfSlots = true;
            targetting_BySlot_Index3.slotPointerDirections = new int[1];

            Enemy enemy = new Enemy("Impenetrable Angler", "ImpenetrableAngler_EN");
            enemy.Health = 35;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 2;

            enemy.CombatSprite = ResourceLoader.LoadSprite("AnglerIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("AnglerOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("AnglerCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Kleiver_CH").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Kleiver_CH").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { passive });
            enemy.PrepareEnemyPrefab("Assets/Angler/Angler.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Angler/Giblets_Angler.prefab").GetComponent<ParticleSystem>());
            enemy.CombatEnterEffects = new EffectInfo[] { Effects.GenerateEffect(fieldEffect_Apply_Effect, 100, targetting_BySlot_Index3) };
            enemy.UnitTypes = new List<string> { UnitType_GameIDs.Fish.ToString() };



            Ability ability = new Ability("Pike_A");
            ability.Name = "Pike";
            ability.Description = "Deal an Agonizing amount of Damage to the Left and Right party members not Opposing this enemy.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 7, Targeting.Slot_OpponentSides),
                


            };
            ability.AddIntentsToTarget(Targeting.Slot_OpponentSides, new string[] { IntentType_GameIDs.Damage_7_10.ToString()});
            ability.AnimationTarget = Targeting.Slot_OpponentSides;
            ability.Visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;


            CustomOpponentTargetting_BySlot_Index DBtargetAllRight = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllRight._frontOffsets = new int[4] { 1, 2, 3, 4 };
            DBtargetAllRight._slotPointerDirections = new int[] { 4, 3, 2, 1, 0 };


            CustomOpponentTargetting_BySlot_Index DBtargetAllLeft = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllLeft._frontOffsets = new int[4] { 0, -1, -2, -3 };
            DBtargetAllLeft._slotPointerDirections = new int[] { -4, -3, -2, -1, 0 };

            SwapToOneSideEffect right = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            right._swapRight = true;

            SwapToOneSideEffect left = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            left._swapRight = false;

            DamageEffect indi = ScriptableObject.CreateInstance<DamageEffect>();
            indi._indirect = true;

            Ability ability1 = new Ability("Torrent_A");
            ability1.Name = "Torrent";
            ability1.Description = "Moves all Party members away from this enemy.\nDeals a Little amount of Indirect damage to the Opposing Party members.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(left, 1, DBtargetAllLeft),
                  Effects.GenerateEffect(right, 1, DBtargetAllRight),
                  Effects.GenerateEffect(indi, 2, Targeting.Slot_Front),

            };
            ability1.AddIntentsToTarget(DBtargetAllLeft, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability1.AddIntentsToTarget(DBtargetAllRight, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability1.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("RevoltingRevolution_A").visuals;

            PercentageEffectCondition percentageEffectCondition = ScriptableObject.CreateInstance<PercentageEffectCondition>();
            percentageEffectCondition.percentage = 50;

            CustomOpponentTargetting_BySlot_Index DBtargetRight = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetRight._frontOffsets = new int[4] { 1, 2, 3, 4 };
            DBtargetRight._slotPointerDirections = new int[] { 0 };

            CustomOpponentTargetting_BySlot_Index DBtargetLeft = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetLeft._frontOffsets = new int[4] { 0, -1, -2, -3 };
            DBtargetLeft._slotPointerDirections = new int[] { 0 };

            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.previousAmount = 1;
            previousEffectCondition.wasSuccessful = true;

            PreviousEffectCondition previousEffectCondition1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition1.previousAmount = 2;
            previousEffectCondition1.wasSuccessful = true;

            PreviousEffectCondition previousEffectCondition2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition2.previousAmount = 3;
            previousEffectCondition2.wasSuccessful = true;

            PreviousEffectCondition previousEffectFalseCondition2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectFalseCondition2.previousAmount = 5;
            previousEffectFalseCondition2.wasSuccessful = false;

            PreviousEffectCondition previousEffectFalseCondition3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectFalseCondition3.previousAmount = 6;
            previousEffectFalseCondition3.wasSuccessful = false;

            PreviousEffectCondition previousEffectFalseCondition4 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectFalseCondition4.previousAmount = 7;
            previousEffectFalseCondition4.wasSuccessful = false;

            AnimationVisualsEffect Rfish = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            Rfish._animationTarget = DBtargetRight;
            Rfish._visuals = LoadedAssetsHandler.GetEnemyAbility("Mungle_A").visuals;

            AnimationVisualsEffect Lfish = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            Lfish._animationTarget = DBtargetLeft;
            Lfish._visuals = LoadedAssetsHandler.GetEnemyAbility("Mungle_A").visuals;


            ExtraLootListEffect e = ScriptableObject.CreateInstance<ExtraLootListEffect>();
            e._treasurePercentage = 1;
            e._nothingPercentage = 0;
            e._shopPercentage = 2;

            e._lootableItems = ((ExtraLootListEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("CanOfWorms_SW")).effects[0].effect)._lootableItems;
            e._lockedLootableItems = ((ExtraLootListEffect)((PerformEffectWearable)LoadedAssetsHandler.GetWearable("CanOfWorms_SW")).effects[0].effect)._lootableItems;


            Ability ability11 = new Ability("GoFish_A");
            ability11.Name = "Go Fish";
            ability11.Description = "Deal a Painful amount of Damage to a random Opposing party member, and destroy their held item.\nIf successful produce a random \"fish\" on combat end.";
            ability11.Rarity = Abil.Weight(6);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot, percentageEffectCondition),
                  Effects.GenerateEffect(Lfish, 1, DBtargetLeft, previousEffectCondition),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, DBtargetLeft, previousEffectCondition1),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, DBtargetLeft, previousEffectCondition2),
                  Effects.GenerateEffect(e, 1, DBtargetLeft, previousEffectCondition),
                  Effects.GenerateEffect(Rfish, 1, DBtargetRight, previousEffectFalseCondition2),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 5, DBtargetRight, previousEffectFalseCondition3),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeItemEffect>(), 1, DBtargetRight, previousEffectFalseCondition4),
                   Effects.GenerateEffect(e, 1, DBtargetRight, previousEffectCondition),

            };
            ability11.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_3_6.ToString(), IntentType_GameIDs.Misc.ToString() });




            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11 });
            enemy.AddEnemy(true, true, false);


        }
    }
}
