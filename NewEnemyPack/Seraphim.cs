using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Seraphim
    {
        public static void Add()
        {
            Enemy enemy = new Enemy("Seraphim", "Seraphim_EN");
            enemy.Health = 20;
            enemy.HealthColor = Pigments.Grey;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("SeraphimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("SeraphimOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("SeraphimCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Dimitri_CH").dxSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Dimitri_CH").deathSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.SkittishGenerator(2) });
            enemy.PrepareEnemyPrefab("Assets/Seraphim/Seraphim.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("Assets/Seraphim/SeraphimGibs.prefab").GetComponent<ParticleSystem>());

            FieldEffectSeraphimOne_Apply_Effect fieldEffectSeraphimOne_Apply_Effect = ScriptableObject.CreateInstance<FieldEffectSeraphimOne_Apply_Effect>();
            fieldEffectSeraphimOne_Apply_Effect._Field = StatusField.Constricted;

            FieldEffectSeraphimTwo_Apply_Effect fieldEffectSeraphimOne_Apply_Effect1 = ScriptableObject.CreateInstance<FieldEffectSeraphimTwo_Apply_Effect>();
            fieldEffectSeraphimOne_Apply_Effect1._Field = StatusField.OnFire;

            

            Ability ability = new Ability("DrivethemDown_A");
            ability.Name = "Drive them Down";
            ability.Description = "Force the opposing party member into a tile with fire on it.\nApply 1 Constricted and 1 Fire to that party member's tile.";
            ability.Rarity = Abil.Weight(5);
            ability.Effects = new EffectInfo[]
            {
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<SwapToFireZoneEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffectSeraphimOne_Apply_Effect, 1, Targeting.Unit_AllOpponents),
                  Effects.GenerateEffect(fieldEffectSeraphimOne_Apply_Effect1, 1, Targeting.Unit_AllOpponents),

            };
            ability.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Swap_Sides.ToString() });
            ability.AddIntentsToTarget(Targeting.Unit_AllOpponents, new string[] { IntentType_GameIDs.Field_Constricted.ToString(), IntentType_GameIDs.Field_Fire.ToString() });

            GenerateColorManaEffect generateColorManaEffect = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
            generateColorManaEffect.mana = Pigments.Red;

            SwapToOneSideEffect swapright = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapright._swapRight = true;

            SwapToOneSideEffect swapleft = ScriptableObject.CreateInstance<SwapToOneSideEffect>();
            swapleft._swapRight = false;

            FieldEffect_Apply_Effect fieldEffect_Apply_ = ScriptableObject.CreateInstance<FieldEffect_Apply_Effect>();
            fieldEffect_Apply_._Field = StatusField.OnFire;
            fieldEffect_Apply_._UseRandomBetweenPrevious = true;


            Ability ability1 = new Ability("Pyromancy_A");
            ability1.Name = "Pyromancy";
            ability1.Description = "Moves all party members away from this enemy.\nApplies 0-2 fire to the opposing tile 3 times.\nProduce 1 Red pigment.";
            ability1.Rarity = Abil.Weight(5);
            ability1.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(swapleft, 1, Targeting.GenerateSlotTarget(new int[] { -4,-3,-2,-1,0 }, false)),
                  Effects.GenerateEffect(swapright, 1, Targeting.GenerateSlotTarget(new int[] { 4,3,2,1,0 }, false)),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_Apply_, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_Apply_, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 0, Targeting.Slot_Front),
                  Effects.GenerateEffect(fieldEffect_Apply_, 2, Targeting.Slot_Front),
                  Effects.GenerateEffect(generateColorManaEffect, 1, Targeting.Slot_SelfSlot),

            };
            ability1.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { 4, 3, 2, 1, 0 }, false), new string[] { IntentType_GameIDs.Swap_Right.ToString() });
            ability1.AddIntentsToTarget(Targeting.GenerateSlotTarget(new int[] { -4, -3, -2, -1, 0 }, false), new string[] { IntentType_GameIDs.Swap_Left.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_Front, new string[] { IntentType_GameIDs.Field_Fire.ToString() });
            ability1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Mana_Generate.ToString() });
            ability1.AnimationTarget = Targeting.Slot_Front;
            ability1.Visuals = LoadedAssetsHandler.GetEnemyAbility("Pyre_A").visuals;

            enemy.AddEnemyAbilities(new Ability[] { ability, ability1 });
            enemy.AddEnemy(true, true, false);

        }
    }
}
