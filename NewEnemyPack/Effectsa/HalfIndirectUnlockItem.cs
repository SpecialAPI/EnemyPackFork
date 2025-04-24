using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public static class HalfIndirectUnlockItem
    {
        public static int WillApplyDamage(Func<CharacterCombat, int, IUnit, int> orig, CharacterCombat self, int amount, IUnit targetUnit)
        {
            int newAmount = orig(self, amount, targetUnit);
            if (LoadedAssetsHandler.LoadedWearables.Keys.Contains("BurntLetter_SW"))
            {
                if (self.HasUsableItem && self.HeldItem == LoadedAssetsHandler.GetWearable("BurntLetter_SW"))
                {
                    int old = newAmount;
                    float gap = newAmount;
                    gap /= 2;
                    int gruh = (int)Math.Ceiling(gap);
                    newAmount = gruh;
                    int half = old - newAmount;
                    targetUnit.Damage(half, null, DeathType_GameIDs.Basic.ToString(), -1, false, false, true, CombatType_GameIDs.Dmg_Fire.ToString());
                }
            }
            return newAmount;
        }

        public static void Setup()
        {
            IDetour funnyy = new Hook(typeof(CharacterCombat).GetMethod(nameof(CharacterCombat.WillApplyDamage), ~BindingFlags.Default), typeof(HalfIndirectUnlockItem).GetMethod(nameof(HalfIndirectUnlockItem.WillApplyDamage), ~BindingFlags.Default));
        }
    }
}
