using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NewEnemyPack
{
    internal class Zygote
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Bastard Zygote", "BastardZygote_EN");
            enemy.Health = 125;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 3;

            enemy.CombatSprite = ResourceLoader.LoadSprite("ZygoteIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("ZygoteIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("ZygoteCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("UnfinishedHeir_BOSS").deathSound;
            enemy.UnitTypes = new List<string> { "Bird" };

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Inferno, Passives.MultiAttack5, Passives.Infantile });
            enemy.PrepareEnemyPrefab("Assets/Zygote/NewZygote.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Zygote/Giblets_Zygote.prefab").GetComponent<ParticleSystem>());

            CustomOpponentTargetting_BySlot_Index DBtarget1 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtarget1._frontOffsets = new int[] { 0 };
            DBtarget1._slotPointerDirections = new int[1] { 0 };

            CustomOpponentTargetting_BySlot_Index DBtarget = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtarget._frontOffsets = new int[] { 2 };
            DBtarget._slotPointerDirections = new int[1] { 0 };

            CustomOpponentTargetting_BySlot_Index DBtarget2 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtarget2._frontOffsets = new int[] { 1 };
            DBtarget2._slotPointerDirections = new int[1] { 0 };

            CustomOpponentTargetting_BySlot_Index DBtarget3 = ScriptableObject.CreateInstance<CustomOpponentTargetting_BySlot_Index>();
            DBtarget3._frontOffsets = new int[] { 0, 2 };
            DBtarget3._slotPointerDirections = new int[1] { 0 };

            SwapToOneSideEffect swap = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swap._swapRight = true;

            SwapToOneSideEffect swap1 = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swap1._swapRight = false;

            Ability ability = new Ability("Realize_A");
            ability.Name = "Realize";
            ability.Description = "Deals a Painful amount damage to the Left opposing party member.\nMove this enemy to the Left.";
            ability.Rarity = Abil.Weight(10);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, DBtarget1),
                  Effects.GenerateEffect(swap1, 1, Targeting.Slot_SelfSlot),


            };
            ability.AddIntentsToTarget(DBtarget1, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability.AnimationTarget = DBtarget1;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[0].ability.visuals;

            Ability ability1 = new Ability("Harrow_A");
            ability1.Name = "Harrow";
            ability1.Description = "Deals a Painful amount damage to the Right opposing party member.\nMove this enemy to the Right.";
            ability1.Rarity = Abil.Weight(10);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 4, DBtarget),
                  Effects.GenerateEffect(swap, 1, Targeting.Slot_SelfSlot),


            };
            ability1.AddIntentsToTarget(DBtarget, new string[] { IntentType_GameIDs.Damage_3_6.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability1.AnimationTarget = DBtarget;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[0].ability.visuals;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.OnFire;

            StatusEffect_Apply_Effect effect_Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            effect_Apply_Effect._Status = StatusField.Scars;

            Ability ability11 = new Ability("MetabolicHellfire_A");
            ability11.Name = "Metabolic Hellfire";
            ability11.Description = "Inflicts 4 Fire to the Opposing party member.\nInflicts 1 Scar to the Opposing party member.";
            ability11.Rarity = Abil.Weight(4);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(fieldEffect_Apply_, 4, DBtarget2),
                  Effects.GenerateEffect(effect_Apply_Effect, 1, DBtarget2),


            };
            ability11.AddIntentsToTarget(DBtarget2, new string[] { IntentType_GameIDs.Field_Fire.ToString(), IntentType_GameIDs.Status_Scars.ToString() });
            ability11.AnimationTarget = DBtarget2;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[2].ability.visuals;

            Ability ability111 = new Ability("IntestinalSinge_A");
            ability111.Name = "Intestinal Singe";
            ability111.Description = "Inflicts 2 Fire to the Left and Right Opposing party members.";
            ability111.Rarity = Abil.Weight(3);
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(fieldEffect_Apply_, 2, DBtarget3),



            };
            ability111.AddIntentsToTarget(DBtarget3, new string[] { IntentType_GameIDs.Field_Fire.ToString() });
            ability111.AnimationTarget = DBtarget3;
            ability111.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[3].ability.visuals;

            FieldEffect_Apply_Effect fieldEffect_Apply_1 = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_1._Field = StatusField.OnFire;
            fieldEffect_Apply_1._UseRandomBetweenPrevious = true;

            Ability ability1111 = new Ability("OrganShutDown_A");
            ability1111.Name = "Organ Shut-Down";
            ability1111.Description = "\"Actually reduces heat\"\nGreatly Heal this enemy.\nInflict 0-1 Fire to the Opposing party members.";
            ability1111.Rarity = Abil.Weight(3);
            ability1111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<HealEffect>(), 15, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(fieldEffect_Apply_1, 1, Targeting.Slot_Front),

            };
            ability1111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Heal_11_20.ToString() });
            ability1111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Field_Fire.ToString() });
            ability1111.AnimationTarget = Targeting.Slot_SelfSlot;
            ability1111.Visuals = LoadedAssetsHandler.GetEnemy("Charcarrion_Alive_BOSS").abilities[3].ability.visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1,ability11,ability111,ability1111 });
            enemy.AddEnemy(true, false, false);

            LoadedAssetsHandler.GetEnemy("BastardZygote_EN").passiveAbilities[0] = Object.Instantiate<BasePassiveAbilitySO>(LoadedAssetsHandler.GetEnemy("BastardZygote_EN").passiveAbilities[0]);
            LoadedAssetsHandler.GetEnemy("BastardZygote_EN").passiveAbilities[0]._triggerOn = new TriggerCalls[] { TriggerCalls.OnPlayerTurnEnd_ForEnemy };

        }

    }
}
