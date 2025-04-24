using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class SingingMountain
    {
        public static void Add()
        {
            AttackVisualsSO attackVisualsSO = ScriptableObject.CreateInstance<AttackVisualsSO>();
            attackVisualsSO.audioReference = "event:/Combat/Attack/G3/ATK_FeelTheRhythm";
            attackVisualsSO.isAnimationFullScreen = false;
            attackVisualsSO.animation = Main.assetBundle.LoadAsset<AnimationClip>("Assets/SinMoun/BecomeRhythm.anim");

            CustomOpponentTargetting_BySlot_Index DBtarget1 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtarget1._frontOffsets = new int[2] { 0, 2 };
            DBtarget1._slotPointerDirections = new int[1] { 0 };

            CustomOpponentTargetting_BySlot_Index DBtarget2 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtarget2._frontOffsets = new int[1] { 1 };
            DBtarget2._slotPointerDirections = new int[1] { 0 };



            GenericTargetting_BySlot_Index DBtarget3 = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            DBtarget3.slotPointerDirections = new int[1] { 1 };
            DBtarget3.getAllies = true;


            CustomOpponentTargetting_BySlot_Index DBtargetAllRight = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllRight._frontOffsets = new int[4] { 2, 3, 4, 5 };
            DBtargetAllRight._slotPointerDirections = new int[1] { 0 };


            CustomOpponentTargetting_BySlot_Index DBtargetAllLeft = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtargetAllLeft._frontOffsets = new int[4] { 0, -1, -2, -3 };
            DBtargetAllLeft._slotPointerDirections = new int[1] { 0 };


            Targetting_BySlot_Index selfAllSlots = ScriptableObject.CreateInstance<Targetting_BySlot_Index>();
            selfAllSlots.getAllies = true;
            selfAllSlots.allSelfSlots = true;
            selfAllSlots.slotPointerDirections = new int[] { 0 };

            Enemy enemy = new Enemy("Singing Mountain", "SingingMountain_EN");
            enemy.Health = 70;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 3;

            enemy.CombatSprite = ResourceLoader.LoadSprite("SingingMountain_overworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("SingingMountain_overworld", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("SingingMountain_corpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("Conductor_EN").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Conductor_EN").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Constricting, Passives.Forgetful, Passives.Anchored });
            enemy.PrepareEnemyPrefab("assets/sinmoun/mount.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/sinmoun/mountgib.prefab").GetComponent<ParticleSystem>());

            StatusEffect_Apply_Effect statusEffect_Apply_ = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_._Status = StatusField.Frail;

            Ability ability = new Ability("DeepBeat_A");
            ability.Name = "Deep Beat";
            ability.Description = "Apply 2 Frail to the Left and Right Opposing party members, and move them Left or Right.\nDeal a Painful amount of damage to the Middle opposing party member.";
            ability.Rarity = Abil.Weight(40);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(statusEffect_Apply_, 2, DBtarget1),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, DBtarget1),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 3, DBtarget2),

            };
            ability.AddIntentsToTarget(DBtarget1, new string[] { IntentType_GameIDs.Status_Frail.ToString(), IntentType_GameIDs.Swap_Sides.ToString() });
            ability.AddIntentsToTarget(DBtarget2, new string[] { IntentType_GameIDs.Damage_3_6.ToString(),  });
            ability.AnimationTarget = DBtarget2;
            ability.Visuals = LoadedAssetsHandler.GetCharacter("Hans_CH").rankedData[0].rankAbilities[0].ability.visuals;

            StatusEffect_Apply_Effect statusEffect_Apply_1 = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            statusEffect_Apply_1._Status = StatusField.Ruptured;

            Ability ability1 = new Ability("Seethe_A");
            ability1.Name = "Seethe";
            ability1.Description = "Apply 4 Ruptured to the Middle opposing party member, and move them Left or Right.";
            ability1.Rarity = Abil.Weight(40);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(statusEffect_Apply_1, 4, DBtarget2),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, DBtarget2),

            };
            ability1.AddIntentsToTarget(DBtarget2, new string[] { IntentType_GameIDs.Status_Ruptured.ToString(), IntentType_GameIDs.Swap_Sides.ToString(), });
            ability1.AnimationTarget = DBtarget2;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Flarblet_EN").abilities[2].ability.visuals;

            PreviousEffectCondition c1 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            c1.wasSuccessful = true;

            SwapToOneSideEffect right = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            right._swapRight = true;

            SwapToOneSideEffect left = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            left._swapRight = false;

            Ability ability11 = new Ability("BellowingBallad_A");
            ability11.Name = "Bellowing Ballad";
            ability11.Description = "Move all party members to the Middle opposing slot.\nApply 2 Frail to the Middle opposing party member, and 2 Ruptured to the Left and Right opposing party members.";
            ability11.Rarity = Abil.Weight(40);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(right, 1, DBtargetAllLeft),
                  Effects.GenerateEffect(right, 1, Targeting.GenerateSlotTarget(new int[]{ -1,-2,-3})),
                  Effects.GenerateEffect(left, 1, DBtargetAllRight),
                  Effects.GenerateEffect(left, 1, Targeting.GenerateSlotTarget(new int[]{ 1,2,3})),
                  Effects.GenerateEffect(statusEffect_Apply_, 2, DBtarget2),
                  Effects.GenerateEffect(statusEffect_Apply_1, 2, DBtarget1),

            };
            ability11.AddIntentsToTarget(DBtargetAllLeft, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability11.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -1, -2, -3 }), new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability11.AddIntentsToTarget(DBtargetAllRight, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability11.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { 1, 2, 3 }), new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability11.AddIntentsToTarget(DBtarget2, new string[] { IntentType_GameIDs.Status_Frail.ToString() });
            ability11.AddIntentsToTarget(DBtarget1, new string[] { IntentType_GameIDs.Status_Ruptured.ToString() });
            ability11.AnimationTarget = selfAllSlots;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Revola_EN").abilities[1].ability.visuals;

            CasterTransformationEffect rhythm = ScriptableObject.CreateInstance<CasterTransformationEffect>();
            rhythm._maintainMaxHealth = false;
            rhythm._currentToMaxHealth = false;
            rhythm._fullyHeal = true;
            rhythm._enemyTransformation = LoadedAssetsHandler.GetEnemy("Maestro_EN");
            rhythm._maintainTimelineAbilities = false;


            Ability ability111 = new Ability("BecometheRhythm_A");
            ability111.Name = "Become the Rhythm";
            ability111.Description = "Transforms into a performance of the Ungod.";
            ability111.Rarity = Abil.Weight(20);
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(rhythm, 1, Targeting.Slot_SelfSlot),


            };
            ability111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Other_Transform_Instument.ToString(), });
            ability111.AnimationTarget = Targeting.Slot_SelfSlot;
            ability111.Visuals = attackVisualsSO;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11, ability111 });
            enemy.AddEnemy(true, false, false);

        }
    }
}
