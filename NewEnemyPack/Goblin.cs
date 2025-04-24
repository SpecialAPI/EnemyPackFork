using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class Goblin
    {
        public static void Add()
        {

            Enemy enemy = new Enemy("The Goblin", "TheGoblin_EN");
            enemy.Health = 2;
            enemy.HealthColor = Pigments.Green;
            enemy.Size = 1;

            enemy.CombatSprite = ResourceLoader.LoadSprite("GoblinIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("GoblinIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("GoblinBeatIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = LoadedAssetsHandler.GetCharacter("Thype_CH").damageSound;
            enemy.DeathSound = LoadedAssetsHandler.GetCharacter("Thype_CH").damageSound;

            enemy.AddPassives(new BasePassiveAbilitySO[] {  });
            enemy.PrepareEnemyPrefab("Assets/Goblin/Goblin.prefab", Main.assetBundle);

            IntentInfoBasic InfestIntent = new IntentInfoBasic();
            InfestIntent._color = Color.white;
            InfestIntent._sprite = ResourceLoader.LoadSprite("GoblinIcon");
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("GoblinIntent", InfestIntent);

            IntentInfoBasic InfestIntent1 = new IntentInfoBasic();
            InfestIntent1._color = Color.white;
            InfestIntent1._sprite = ResourceLoader.LoadSprite("TalkIntent");
            LoadedDBsHandler.IntentDB.AddNewBasicIntent("TalkIntent", InfestIntent1);







            Ability a111111111111 = new Ability("Goblin13_A");
            a111111111111.Name = "hehehehehe";
            a111111111111.Description = "Chump";
            a111111111111.Rarity = Abil.Weight(1);
            a111111111111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            a111111111111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea11 = new ExtraAbilityInfo();
            ea11.ability = a111111111111.ability;
            ea11.rarity = Abil.Weight(1);




            SwapCasterAbilitiesEffect sw11 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw11._abilitiesToSwap = new ExtraAbilityInfo[] { ea11 };

            Ability a11111111111 = new Ability("Goblin12_A");
            a11111111111.Name = "GET OUTTA HERE";
            a11111111111.Description = "DUMB F*&^";
            a11111111111.Rarity = Abil.Weight(1);
            a11111111111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw11, 1, Targeting.Slot_SelfSlot),


            };
            a11111111111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea10 = new ExtraAbilityInfo();
            ea10.ability = a11111111111.ability;
            ea10.rarity = Abil.Weight(1);



            SwapCasterAbilitiesEffect sw10 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw10._abilitiesToSwap = new ExtraAbilityInfo[] { ea10 };

            Ability a1111111111 = new Ability("Goblin11_A");
            a1111111111.Name = "HAHA";
            a1111111111.Description = "TAKE THAT YOU JERK";
            a1111111111.Rarity = Abil.Weight(1);
            a1111111111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw10, 1, Targeting.Slot_SelfSlot),


            };
            a1111111111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea9 = new ExtraAbilityInfo();
            ea9.ability = a1111111111.ability;
            ea9.rarity = Abil.Weight(1);

            TryUnlockAchievementEffect tryUnlockAchievementEffect = ScriptableObject.CreateInstance<TryUnlockAchievementEffect>();
            tryUnlockAchievementEffect._unlockID = "GoblinTragedy";

            SwapCasterAbilitiesEffect sw9 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw9._abilitiesToSwap = new ExtraAbilityInfo[] { ea9 };

            Ability a111111111 = new Ability("Goblin10_A");
            a111111111.Name = "alright ready?";
            a111111111.Description = "Here goes…";
            a111111111.Rarity = Abil.Weight(1);
            a111111111.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, Targeting.Slot_Front),
                  Effects.GenerateEffect(sw9, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true, 1)),
                  Effects.GenerateEffect(tryUnlockAchievementEffect, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true, 2)),

            };
            a111111111.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "GoblinIntent" });
            ExtraAbilityInfo ea8 = new ExtraAbilityInfo();
            ea8.ability = a111111111.ability;
            ea8.rarity = Abil.Weight(1);



            Ability b3 = new Ability("Goblin13Alt_A");
            b3.Name = "GET OUT";
            b3.Description = "OUT";
            b3.Rarity = Abil.Weight(1);
            b3.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, Targeting.Slot_SelfSlot),


            };
            b3.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "TalkIntent" });
            ExtraAbilityInfo be3 = new ExtraAbilityInfo();
            be3.ability = b3.ability;
            be3.rarity = Abil.Weight(1);

            SwapCasterAbilitiesEffect bsw10 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            bsw10._abilitiesToSwap = new ExtraAbilityInfo[] { be3 };


            Ability b2 = new Ability("Goblin11Alt_A");
            b2.Name = "Yeah alright there you go";
            b2.Description = "Now GET OUT";
            b2.Rarity = Abil.Weight(1);
            b2.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(bsw10, 1, Targeting.Slot_SelfSlot),


            };
            b2.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "TalkIntent" });
            ExtraAbilityInfo be2 = new ExtraAbilityInfo();
            be2.ability = b2.ability;
            be2.rarity = Abil.Weight(1);

            SwapCasterAbilitiesEffect bsw9 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            bsw9._abilitiesToSwap = new ExtraAbilityInfo[] { be2 };


            Ability b = new Ability("Goblin10Alt_A");
            b.Name = "alright ready?";
            b.Description = "Here goes…";
            b.Rarity = Abil.Weight(1);
            b.Effects = new EffectInfo[]
            {

                  Effects.GenerateEffect(ScriptableObject.CreateInstance<ExtraCurrencyEffect>(), 20, Targeting.Slot_SelfSlot),
                  Effects.GenerateEffect(bsw9, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(true, 1)),


            };
            b.AddIntentsToTarget(Targeting.Slot_Front, new string[] { "GoblinIntent" });
            ExtraAbilityInfo be = new ExtraAbilityInfo();
            be.ability = b.ability;
            be.rarity = Abil.Weight(1);



            SwapCasterAbilitiesEffect sw8 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw8._abilitiesToSwap = new ExtraAbilityInfo[] { ea8 };

            SwapCasterAbilitiesEffect bsw8 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            bsw8._abilitiesToSwap = new ExtraAbilityInfo[] { be };

            Ability a11111111 = new Ability("Goblin9_A");
            a11111111.Name = "Come here";
            a11111111.Description = "Stand in front of me and let me do my magic";
            a11111111.Rarity = Abil.Weight(1);
            a11111111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw8, 1, Targeting.Slot_SelfSlot, Effects.ChanceCondition(50)),
                  Effects.GenerateEffect(bsw8, 1, Targeting.Slot_SelfSlot, Effects.CheckPreviousEffectCondition(false,1)),


            };
            a11111111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea7 = new ExtraAbilityInfo();
            ea7.ability = a11111111.ability;
            ea7.rarity = Abil.Weight(1);



            SwapCasterAbilitiesEffect sw7 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw7._abilitiesToSwap = new ExtraAbilityInfo[] { ea7 };

            Ability a1111111 = new Ability("Goblin8_A");
            a1111111.Name = "I was skeptical at first";
            a1111111.Description = "But you seem fine enough unlike other jerks that disturb me";
            a1111111.Rarity = Abil.Weight(1);
            a1111111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw7, 1, Targeting.Slot_SelfSlot),


            };
            a1111111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea6 = new ExtraAbilityInfo();
            ea6.ability = a1111111.ability;
            ea6.rarity = Abil.Weight(1);



            SwapCasterAbilitiesEffect sw6 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw6._abilitiesToSwap = new ExtraAbilityInfo[] { ea6 };

            Ability a111111 = new Ability("Goblin7_A");
            a111111.Name = "yeah thats right";
            a111111.Description = "I'm a MAGICAL goblin";
            a111111.Rarity = Abil.Weight(1);
            a111111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw6, 1, Targeting.Slot_SelfSlot),


            };
            a111111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea5 = new ExtraAbilityInfo();
            ea5.ability = a111111.ability;
            ea5.rarity = Abil.Weight(1);



            SwapCasterAbilitiesEffect sw5 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw5._abilitiesToSwap = new ExtraAbilityInfo[] { ea5 };

            Ability a11111 = new Ability("Goblin6_A");
            a11111.Name = "sigh";
            a11111.Description = "Alright sorry I got a bit aggressive there";
            a11111.Rarity = Abil.Weight(1);
            a11111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw5, 1, Targeting.Slot_SelfSlot),


            };
            a11111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea4 = new ExtraAbilityInfo();
            ea4.ability = a11111.ability;
            ea4.rarity = Abil.Weight(1);


            SwapCasterAbilitiesEffect sw4 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw4._abilitiesToSwap = new ExtraAbilityInfo[] { ea4 };

            Ability a1111 = new Ability("Goblin5_A");
            a1111.Name = "...";
            a1111.Description = "...";
            a1111.Rarity = Abil.Weight(1);
            a1111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw4, 1, Targeting.Slot_SelfSlot),


            };
            a1111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea3 = new ExtraAbilityInfo();
            ea3.ability = a1111.ability;
            ea3.rarity = Abil.Weight(1);





            SwapCasterAbilitiesEffect sw3 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw3._abilitiesToSwap = new ExtraAbilityInfo[] { ea3 };

            Ability a111 = new Ability("Goblin4_A");
            a111.Name = "never seen a goblin beat someone up?";
            a111.Description = "Well I'm gonna SHOW YOU";
            a111.Rarity = Abil.Weight(1);
            a111.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw3, 1, Targeting.Slot_SelfSlot),


            };
            a111.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea2 = new ExtraAbilityInfo();
            ea2.ability = a111.ability;
            ea2.rarity = Abil.Weight(1);





            SwapCasterAbilitiesEffect sw2 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw2._abilitiesToSwap = new ExtraAbilityInfo[] { ea2 };

            Ability a11 = new Ability("Goblin3_A");
            a11.Name = "how about I trample YOUR FACE";
            a11.Description = "HUH? how's THAT sound?";
            a11.Rarity = Abil.Weight(1);
            a11.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw2, 1, Targeting.Slot_SelfSlot),


            };
            a11.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea1 = new ExtraAbilityInfo();
            ea1.ability = a11.ability;
            ea1.rarity = Abil.Weight(1);





            SwapCasterAbilitiesEffect sw1 = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw1._abilitiesToSwap = new ExtraAbilityInfo[] { ea1 };

            Ability a1 = new Ability("Goblin2_A");
            a1.Name = "come to MY trampling grounds";
            a1.Description = "And give me that stupid look?";
            a1.Rarity = Abil.Weight(1);
            a1.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw1, 1, Targeting.Slot_SelfSlot),


            };
            a1.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });
            ExtraAbilityInfo ea = new ExtraAbilityInfo();
            ea.ability = a1.ability;
            ea.rarity = Abil.Weight(1);




            SwapCasterAbilitiesEffect sw = ScriptableObject.CreateInstance<SwapCasterAbilitiesEffect>();
            sw._abilitiesToSwap = new ExtraAbilityInfo[] { ea };

            Ability a = new Ability("Goblin1_A");
            a.Name = "What are you looking at?";
            a.Description = "Think you can just stroll up here?";
            a.Rarity = Abil.Weight(1);
            a.Effects = new EffectInfo[]
            {


                  Effects.GenerateEffect(sw, 1, Targeting.Slot_SelfSlot),


            };
            a.AddIntentsToTarget(Targeting.Slot_SelfSlot, new string[] { "TalkIntent" });

          


            enemy.AddEnemyAbilities(new Ability[] { a });
            enemy.AddEnemy(false, false, false);

        }

    }
}
