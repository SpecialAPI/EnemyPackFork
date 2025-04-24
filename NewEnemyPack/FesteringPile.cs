using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class FesteringPile
    {
        public static void Add()
        {

            Character character = new Character("Festering Pile", "FesteringPile_CH");
            character.Name = "Festering Pile";
            character.HealthColor = Pigments.Grey;
            character.UsesBasicAbility = false;
            character.UsesAllAbilities = true;
            character.FrontSprite = ResourceLoader.LoadSprite("PileFront");
            character.BackSprite = ResourceLoader.LoadSprite("PileBack");
            character.OverworldSprite = ResourceLoader.LoadSprite("PileOW", new Vector2?(new Vector2(0.5f, 0f)), 32, null);
            character.DamageSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound;
            character.DeathSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").deathSound;
            character.DialogueSound = LoadedAssetsHandler.GetEnemy("TaintedYolk_EN").damageSound;
            character.MovesOnOverworld = false;
            character.AddPassives(new BasePassiveAbilitySO[] { Passives.Infestation1, Passives.Dying, Passives.Withering });

            StatusEffect_Apply_Effect effect_Apply_Effect = ScriptableObject.CreateInstance<StatusEffect_Apply_Effect>();
            effect_Apply_Effect._Status = StatusField.Scars;

            Ability ability = new Ability("FallApart_A_0");
            ability.Name = "Fall Apart";
            ability.Description = "Inflict 1 Scar to this party member.";
            ability.AbilitySprite = ResourceLoader.LoadSprite("Fall");
            ability.Cost = new ManaColorSO[] { Pigments.Grey };
            ability.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(effect_Apply_Effect, 1, Targeting.Slot_SelfSlot)


            };
            ability.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { IntentType_GameIDs.Status_Scars.ToString()});


            character.AddLevelData(10, new Ability[] { ability });

            character.AddCharacter(true, true);


        }
    }
}
