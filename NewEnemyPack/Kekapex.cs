using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Kekapex
    {
        public static void Add()
        {


            ExtraLootEffect extra = ScriptableObject.CreateInstance<ExtraLootEffect>();
            extra._getLocked = true;
            extra._isTreasure = true;

            ExtraLootEffect extra1 = ScriptableObject.CreateInstance<ExtraLootEffect>();
            extra1._getLocked = true;
            extra1._isTreasure = true;

            Enemy enemy = new Enemy("Kekapex", "Kekapex_EN");
            enemy.Health = 120;
            enemy.HealthColor = Pigments.Red;
            enemy.Size = 5;

            enemy.CombatSprite = ResourceLoader.LoadSprite("KekapexIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("KekapexIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("UnflarbCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetEnemyBundle("H_Zone01_Kekastle_Hard_EnemyBundle")._roarReference.roarEvent;
            enemy.DeathSound = LoadedAssetsHandler.GetEnemy("Kekastle_EN").deathSound;
  
            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Infestation1, Passives.MultiAttackGenerator(10), Passives.OverexertGenerator(8)  });
            enemy.PrepareEnemyPrefab("Assets/Kekapex/Kekapex.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Kekapex/KekapexGibs.prefab").GetComponent<ParticleSystem>());

            enemy.CombatEnterEffects = new EffectInfo[] { 
                
                Effects.GenerateEffect(ScriptableObject.CreateInstance<SetScreenFadeEffect>(), 20, Targeting.Slot_SelfSlot),
                 

            };
            enemy.AddLootData(new EnemyLootItemProbability[]{
                new EnemyLootItemProbability
                {
                    isItemTreasure = true,
                    amount = 2,
                    probability = 100
                },
                   new EnemyLootItemProbability
                {
                    isItemTreasure = false,
                    amount = 2,
                    probability = 100
                },});

            SwapToOneSideEffect swapright = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapright._swapRight = true;

            SwapToOneSideEffect swapleft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapleft._swapRight = false;

            GenericTargetting_BySlot_Index leftmost = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            leftmost.slotPointerDirections = new int[1] { 0 };
            leftmost.getAllies = false;

            GenericTargetting_BySlot_Index left = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            left.slotPointerDirections = new int[1] { 1 };
            left.getAllies = false;

            GenericTargetting_BySlot_Index middle = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            middle.slotPointerDirections = new int[1] { 2 };
            middle.getAllies = false;

            GenericTargetting_BySlot_Index right = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            right.slotPointerDirections = new int[1] { 3 };
            right.getAllies = false;

            GenericTargetting_BySlot_Index rightmost = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            rightmost.slotPointerDirections = new int[1] { 4 };
            rightmost.getAllies = false;

            GenericTargetting_BySlot_Index middleanim = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            middleanim.slotPointerDirections = new int[1] { 2 };
            middleanim.getAllies = true;


            GenericTargetting_BySlot_Index leftanim = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            leftanim.slotPointerDirections = new int[] { 0, 1 };
            leftanim.getAllies = false;

            GenericTargetting_BySlot_Index rightanim = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            rightanim.slotPointerDirections = new int[] { 4, 3 };
            rightanim.getAllies = false;

            Ability ability = new Ability("LeftMandible_A");
            ability.Name = "Left Mandible";
            ability.Description = "Deals a Little amount of damage to the Far Left Opposing party member.\nDeals Barely any damage to the Left Opposing party member, and move that party member to the Right.\nConsume 1 pigment.";
            ability.Rarity = Abil.Weight(50);
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, leftmost),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, left),
                  Effects.GenerateEffect(swapright, 1, left),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            ability.AddIntentsToTarget(leftmost, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability.AddIntentsToTarget(left, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Swap_Right.ToString() });
            ability.AddIntentsToTarget(middleanim, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability.AnimationTarget = leftanim;
            ability.Visuals = LoadedAssetsHandler.GetEnemy("Keko_EN").abilities[0].ability.visuals;

            Ability ability1 = new Ability("RightMandible_A");
            ability1.Name = "Right Mandible";
            ability1.Description = "Deals a Little amount of damage to the Far Right Opposing party member.\nDeals Barely any damage to the Right Opposing party member, and move that party member to the Left.\nConsume 1 pigment.";
            ability1.Rarity = Abil.Weight(50);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, rightmost),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 1, right),
                  Effects.GenerateEffect(swapleft, 1, right),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 1, Targeting.Slot_SelfSlot),

            };
            ability1.AddIntentsToTarget(rightmost, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability1.AddIntentsToTarget(right, new string[] { IntentType_GameIDs.Damage_1_2.ToString(), IntentType_GameIDs.Swap_Left.ToString() });
            ability1.AddIntentsToTarget(middleanim, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability1.AnimationTarget = rightanim;
            ability1.Visuals = LoadedAssetsHandler.GetEnemy("Keko_EN").abilities[0].ability.visuals;

            Ability ability11 = new Ability("MiddleMouthparts_A");
            ability11.Name = "Middle Mouthparts";
            ability11.Description = "Deals a little amount of damage to the Middlemost Opposing party member, move that party member to the Left or Right.\n\"Weirdly?\"";
            ability11.Rarity = Abil.Weight(50);
            ability11.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DamageEffect>(), 2, middle),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, middle),

            };
            ability11.AddIntentsToTarget(middle, new string[] { IntentType_GameIDs.Damage_1_2.ToString() });
            ability11.AddIntentsToTarget(middle, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability11.AnimationTarget = middle;
            ability11.Visuals = LoadedAssetsHandler.GetEnemy("Keko_EN").abilities[0].ability.visuals;

            CopyAndSpawnCustomCharacterAnywhereEffect spawn = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
            spawn._characterCopy = "FesteringPile_CH";
            spawn._rank = 0;
            spawn._extraModifiers = new WearableStaticModifierSetterSO[0];
            spawn._permanentSpawn = true;

            PreviousEffectCondition previousEffectCondition = ScriptableObject.CreateInstance<PreviousEffectCondition>();
            previousEffectCondition.wasSuccessful = false;

            Ability ability111 = new Ability("Hurk_A");
            ability111.Name = "Hurk";
            ability111.Description = "Spawn a Festering Pile on the party member side. If unsuccessful, cure all Status effects on this enemy.";
            ability111.Rarity = Abil.Weight(30);
            ability111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(spawn, 1, Targeting.Unit_AllOpponentSlots),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, Targeting.Slot_SelfSlot, previousEffectCondition),

            };
            ability111.AddIntentsToTarget(Targeting.Unit_AllOpponentSlots, new string[] { IntentType_GameIDs.Other_Spawn.ToString() });
            ability111.AddIntentsToTarget(middleanim, new string[] { IntentType_GameIDs.Misc.ToString() });
            ability111.AnimationTarget = middle;
            ability111.Visuals = LoadedAssetsHandler.GetEnemyAbility("Flood_A").visuals;

            RemoveFieldEffectsEffect removeFieldEffectsEffect = ScriptableObject.CreateInstance<RemoveFieldEffectsEffect>();
            removeFieldEffectsEffect.field = StatusField.OnFire._FieldID;

            FieldEffect_Apply_Effect fieldEffect_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_._Field = StatusField.Shield;
            fieldEffect_._UseRandomBetweenPrevious = true;

            GenericTargetting_BySlot_Index allselfslots = ScriptableObject.CreateInstance<GenericTargetting_BySlot_Index>();
            allselfslots.slotPointerDirections = new int[] { 0, 1, 2, 3, 4 };
            allselfslots.getAllies = true;

            Ability ability1111 = new Ability("FreshShed_A");
            ability1111.Name = "Fresh Shed";
            ability1111.Description = "Applies 0-2 Shield to All positions.\nConsume 2 pigment.\nRemove all Fire from Self positions.";
            ability1111.Rarity = Abil.Weight(30);
            ability1111.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, allselfslots),
                  Effects.GenerateEffect(fieldEffect_, 2, allselfslots),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, allselfslots),
                  Effects.GenerateEffect(fieldEffect_, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ConsumeRandomManaEffect>(), 2, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(removeFieldEffectsEffect, 1, allselfslots),

            };
            ability1111.AddIntentsToTarget(Targeting.Unit_AllOpponentSlots, new string[] { IntentType_GameIDs.Field_Shield.ToString() });
            ability1111.AddIntentsToTarget(allselfslots, new string[] { IntentType_GameIDs.Field_Shield.ToString(), IntentType_GameIDs.Rem_Field_Fire.ToString() });
            ability1111.AddIntentsToTarget(middleanim, new string[] { IntentType_GameIDs.Mana_Consume.ToString() });
            ability1111.AnimationTarget = middle;
            ability1111.Visuals = LoadedAssetsHandler.GetEnemyAbility("RevoltingRevolution_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1, ability11, ability111,ability1111 });
            enemy.AddEnemy(true, false, false);

        }

    }
}
