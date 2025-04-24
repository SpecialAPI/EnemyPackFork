using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class ChangeToRandomHealthDependingonCasterColorEffect : EffectSO
    {
        // Token: 0x060018EE RID: 6382 RVA: 0x0003FA44 File Offset: 0x0003DC44
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (caster.HealthColor == Pigments.Red)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        exitAmount = 0;
                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i].HasUnit && targets[i].Unit.ChangeHealthColor(caster.HealthColor))
                            {
                                exitAmount++;
                            }
                        }
                        caster.ChangeHealthColor(Pigments.Grey);
                        return exitAmount > 0;



                    }

                }
                if (caster.HealthColor != Pigments.Red)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        exitAmount = 0;
                        for (int i = 0; i < targets.Length; i++)
                        {
                            if (targets[i].HasUnit && targets[i].Unit.ChangeHealthColor(caster.HealthColor))
                            {
                                exitAmount++;
                            }
                        }
                        caster.ChangeHealthColor(Pigments.Red);
                        return exitAmount > 0;
                    }
                }
            }
            return exitAmount > 0;
        }

        // Token: 0x04000F7C RID: 3964
        [SerializeField]
        public ManaColorSO[] _healthColors;

        [SerializeField]
        public ManaColorSO[] _healthColors2;
    }
}
