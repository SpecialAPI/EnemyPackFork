using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class ApplyParentalEffect : EffectSO
    {
        // Token: 0x06000005 RID: 5 RVA: 0x00003938 File Offset: 0x00001B38
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            int chance = Random.Range(0, 100);
            exitAmount = 0;
            if (chance < 33)
            {
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    bool flag2 = targetSlotInfo.HasUnit && !targetSlotInfo.IsTargetCharacterSlot;
                    if (flag2)
                    {
                        bool flag9 = targetSlotInfo.Unit.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Flarb_EN").passiveAbilities[1]);
                        if (flag9)
                        {
                            exitAmount++;
                        }
                        break;
                    }
                }
            }
            else if (chance < 66)
            {
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit && !targetSlotInfo.IsTargetCharacterSlot)
                    {
                        bool flag91 = targetSlotInfo.Unit.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").passiveAbilities[0]);
                        if (flag91)
                        {
                            exitAmount++;
                        }
                        break;
                    }
                }
            }
            else
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit && !targetSlotInfo.IsTargetCharacterSlot)
                    {
                        bool flag91 = targetSlotInfo.Unit.AddPassiveAbility(LoadedAssetsHandler.GetEnemy("Unflarb_EN").passiveAbilities[1]);
                        if (flag91)
                        {
                            exitAmount++;
                        }
                        break;
                    }
                }
            return exitAmount > 0;
        }
    }
}
