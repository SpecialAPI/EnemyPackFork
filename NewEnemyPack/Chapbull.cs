using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Chapbull
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Chapbull", "Chapbull_EN");
            enemy.Health = 70;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 2;

            enemy.CombatSprite = ResourceLoader.LoadSprite("ChapbullOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("ChapbullOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("ChapbullCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/ChapBull/BullHurt";
            enemy.DeathSound = "event:/ChapBull/BullDeath";

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.InfestationGenerator(1), Passives.MultiAttackGenerator(4), Passives.OverexertGenerator(10) });
            enemy.PrepareEnemyPrefab("Assets/Chapman/ChapBull.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Chapman/Giblets_Chapbull.prefab").GetComponent<ParticleSystem>());

            InfestationRandomSetEffect infestationRandomSet = ScriptableObject.CreateInstance<InfestationRandomSetEffect>();
            infestationRandomSet._infestationPassive = (InfestationPassiveAbility)Passives.InfestationGenerator(1);

            InfestationRandomSetWithExitEffect infestationRandomSet1 = ScriptableObject.CreateInstance<InfestationRandomSetWithExitEffect>();
            infestationRandomSet1._infestationPassive = (InfestationPassiveAbility)Passives.InfestationGenerator(1);

            SwapToOneSideEffect swapright = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapright._swapRight = true;

            SwapToOneSideEffect swapleft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapleft._swapRight = false;

            CustomOpponentTargetting_BySlot_Index DBtargetAllRight = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllRight._frontOffsets = new int[] { 1, };
            DBtargetAllRight._slotPointerDirections = new int[] { 0 };


            CustomOpponentTargetting_BySlot_Index DBtargetAllLeft = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllLeft._frontOffsets = new int[] { 0 };
            DBtargetAllLeft._slotPointerDirections = new int[] { 0 };


            Ability ability = new Ability("RamtheRight_A");
            ability.Name = "Ram the Right";
            ability.Description = "Deals a Painful amount of damage to the Right Opposing party member.\nApply 1 Infestation to the Left Opposing party member.\nMoves this enemy to the Right.";
            ability.Rarity = Abil.Weight(6);
            ability.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, DBtargetAllRight),
                  Effects.GenerateEffect(infestationRandomSet, 1, DBtargetAllLeft),
                  Effects.GenerateEffect(swapright, 1, Targeting.Slot_SelfSlot),
            };
            ability.AddIntentsToTarget(DBtargetAllRight, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AddIntentsToTarget(DBtargetAllLeft, new string[] { "InfestationIntent" });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability.AnimationTarget = DBtargetAllRight;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;

            Ability ability1 = new Ability("CrushtheLeft_A");
            ability1.Name = "Crush the Left";
            ability1.Description = "Deals a Painful amount of damage to the Left Opposing party member.\nApply 1 Infestation to the Right Opposing party member.\nMoves this enemy to the Left.";
            ability1.Rarity = Abil.Weight(6);
            ability1.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, DBtargetAllLeft),
                  Effects.GenerateEffect(infestationRandomSet, 1, DBtargetAllRight),
                  Effects.GenerateEffect(swapleft, 1, Targeting.Slot_SelfSlot),
            };
            ability1.AddIntentsToTarget(DBtargetAllLeft, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AddIntentsToTarget(DBtargetAllRight, new string[] { "InfestationIntent" });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability1.AnimationTarget = DBtargetAllLeft;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[0].ability.visuals;

            RemovePassiveEffect removePassive = ScriptableObject.CreateInstance<RemovePassiveEffect>();
            removePassive.m_PassiveID = Passives.Infestation1.m_PassiveID;

            TargetStoredValueChangeEffect targetStoredValueChange = ScriptableObject.CreateInstance<TargetStoredValueChangeEffect>();
            targetStoredValueChange._minimumValue = 0;
            targetStoredValueChange._increase = false;
            targetStoredValueChange._valueName = UnitStoredValueNames_GameIDs.InfestationPA.ToString();

            TargetStoredValueCheckerEffect targetStoredValueCheckerEffect = ScriptableObject.CreateInstance<TargetStoredValueCheckerEffect>();
            targetStoredValueCheckerEffect._valueName = UnitStoredValueNames_GameIDs.InfestationPA.ToString();


            Ability ability111 = new Ability("Herbivore_A");
            ability111.Name = "Herbivore";
            ability111.Description = "Removes all Infestation from the Opposing party members and distributes it evenly among all other enemies.\nDeal a Little amount of Damage to the Opposing party members.";
            ability111.Rarity = Abil.Weight(3);
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(targetStoredValueCheckerEffect, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(infestationRandomSet1, 1, Targeting.Unit_OtherAllies),
                  Effects.GenerateEffect(removePassive, 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(targetStoredValueChange, 999, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, Targeting.Slot_Front),

            };
            ability111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Misc.ToString() });
            ability111.AddIntentsToTarget(Targeting.Unit_OtherAllies, new string[] { "InfestationIntent" });
            ability111.AnimationTarget = Targeting.Slot_Front;
            ability111.Visuals = LoadedAssetsHandler.GetEnemy("Flarb_EN").abilities[1].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability111 });
            enemy.AddEnemy(true, true, false);




        }

    }
}
