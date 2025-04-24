using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Metatron
    {
        public static void Add()
        {

            UnitStoreData_ModIntSO dogfoodvalue = ScriptableObject.CreateInstance<UnitStoreData_ModIntSO>();
            dogfoodvalue.m_Text = "Fleeting: {0}";
            dogfoodvalue._UnitStoreDataID = "CustomFleeting";
            dogfoodvalue.m_TextColor = new Color32(221, 0, 55, 255);
            dogfoodvalue.m_CompareDataToThis = 0;
            dogfoodvalue.m_ShowIfDataIsOver = true;
            LoadedDBsHandler.MiscDB.AddNewUnitStoreData("CustomFleeting", dogfoodvalue);

            CustomFleetingPassiveAbility fleetingPassive = ScriptableObject.CreateInstance<CustomFleetingPassiveAbility>();
            fleetingPassive.conditions = Passives.Fleeting1.conditions;
            fleetingPassive.doesPassiveTriggerInformationPanel = Passives.Fleeting1.doesPassiveTriggerInformationPanel;
            fleetingPassive.passiveIcon = Passives.Fleeting1.passiveIcon;
            fleetingPassive.specialStoredData = dogfoodvalue;
            fleetingPassive._ignoreFirstTurn = false;
            fleetingPassive._triggerOn = Passives.Fleeting1._triggerOn;
            fleetingPassive._turnsBeforeFleeting = 0;
            fleetingPassive._characterDescription = "";
            fleetingPassive._enemyDescription = "After a certain amount of Rounds this enemy will Flee.";
            fleetingPassive._characterDescription = "After a certain amount of Rounds this party member will Flee... Coward.";
            fleetingPassive._passiveName = "Fleeting";
            fleetingPassive.m_PassiveID = Passives.Fleeting1.m_PassiveID;

            Enemy enemy = new Enemy("Metatron", "Metatron_EN");
            enemy.Health = 10;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 2;

            enemy.CombatSprite = ResourceLoader.LoadSprite("Metatron", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("Metatron", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("MetatronCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Metatron/MetatronHurt";
            enemy.DeathSound = "event:/Metatron/MetatronDeath";

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Immortal });
            enemy.PrepareEnemyPrefab("Assets/Metatron/Metatron.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Metatron/MetatronGibs.prefab").GetComponent<ParticleSystem>());

            AddPassiveEffect addPassiveEffect = ScriptableObject.CreateInstance<AddPassiveEffect>();
            addPassiveEffect._passiveToAdd = fleetingPassive;

            TargetStoredValueChangeEffect targetStoredValueChange = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            targetStoredValueChange._minimumValue = 0;
            targetStoredValueChange._valueName = "CustomFleeting";
            targetStoredValueChange._increase = true;

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

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = Passives.Fleeting1.passiveIcon;
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("FleetingYay", InfestIntent);

            Ability ability = new Ability("CountlessEyes_A");
            ability.Name = "Countless Eyes";
            ability.Description = "Move all party members away from this enemy.\nApply 3 Fleeting to the Opposing party members, if they already have Fleeting increase it by 3.\nMove this enemy Left or Right twice.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(left, 1, DBtargetAllLeft),
                  Effects.GenerateEffect(right, 1, DBtargetAllRight),
                  Effects.GenerateEffect(addPassiveEffect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(targetStoredValueChange, 3, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),
                   Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            ability.AddIntentsToTarget(DBtargetAllLeft, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability.AddIntentsToTarget(DBtargetAllRight, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "FleetingYay" });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Sides.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), });
            ability.AnimationTarget = Targeting.Slot_Front;
            ability.Visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;

            CustomOpponentTargetting_BySlot_Index DBtargetAllRight1 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllRight1._frontOffsets = new int[] { 1, };
            DBtargetAllRight1._slotPointerDirections = new int[] { 0 };


            CustomOpponentTargetting_BySlot_Index DBtargetAllLeft1 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllLeft1._frontOffsets = new int[] { 0 };
            DBtargetAllLeft1._slotPointerDirections = new int[] { 0 };

            AnimationVisualsEffect animationVisuals = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisuals._visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            animationVisuals._animationTarget = DBtargetAllRight1;


            AnimationVisualsEffect animationVisuals1 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            animationVisuals1._visuals = LoadedAssetsHandler.GetEnemyAbility("InhumanRoar_A").visuals;
            animationVisuals1._animationTarget = DBtargetAllLeft1;


            TargetStoredValueChangeEffect targetStoredValueChange1 = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            targetStoredValueChange1._minimumValue = 0;
            targetStoredValueChange1._valueName = "CustomFleeting";
            targetStoredValueChange1._increase = false;

            PreviousEffectCondition previousEffect = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffect.wasSuccessful = true;


            PreviousEffectCondition previousEffect1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffect1.wasSuccessful = false;
            previousEffect1.previousAmount = 2;

            Ability ability1 = new Ability("CountlessTongues_A");
            ability1.Name = "Countless Tongues";
            ability1.Description = "Apply 2 Fleeting to the Opposing party members.\nIf an Opposing party member already has Fleeting, Decrease their Fleeting by 1 instead.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(animationVisuals, 1, DBtargetAllRight1),
                  Effects.GenerateEffect(addPassiveEffect, 1, DBtargetAllRight1),
                  Effects.GenerateEffect(targetStoredValueChange, 2, DBtargetAllRight1, previousEffect),
                  Effects.GenerateEffect(targetStoredValueChange1, 1, DBtargetAllRight1, previousEffect1),

                  Effects.GenerateEffect(animationVisuals1, 1, DBtargetAllLeft1),
                  Effects.GenerateEffect(addPassiveEffect, 1, DBtargetAllLeft1),
                  Effects.GenerateEffect(targetStoredValueChange, 2, DBtargetAllLeft1, previousEffect),
                  Effects.GenerateEffect(targetStoredValueChange1, 1, DBtargetAllLeft1, previousEffect1),


            };
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "FleetingYay" });

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1});
            enemy.AddEnemy(true, false, false);



        }
    }
}
