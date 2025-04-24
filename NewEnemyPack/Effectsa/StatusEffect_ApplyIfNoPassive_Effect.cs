﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;
using BrutalAPI;

namespace NewEnemyPack.Effectsa
{
    public class StatusEffect_ApplyIfNoPassive_Effect : EffectSO
    {
        [Header("Status")]
        public StatusEffect_SO _Status;

        [Header("Data")]
        public bool _ApplyToFirstUnit;

        public bool _JustOneRandomTarget;

        public bool _RandomBetweenPrevious;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            if (_Status == null)
            {
                return false;
            }

            if (_ApplyToFirstUnit || _JustOneRandomTarget)
            {
                List<TargetSlotInfo> list = new List<TargetSlotInfo>(targets);
                foreach (TargetSlotInfo targetSlotInfo in targets)
                {
                    if (targetSlotInfo.HasUnit)
                    {
                        list.Add(targetSlotInfo);
                        if (_ApplyToFirstUnit)
                        {
                            break;
                        }
                    }
                }

                if (list.Count > 0)
                {
                    int index = Random.Range(0, list.Count);
                    exitAmount += ApplyStatusEffect(list[index].Unit, entryVariable);
                }
            }
            else
            {
                for (int j = 0; j < targets.Length; j++)
                {
                    if (targets[j].HasUnit && !targets[j].Unit.ContainsPassiveAbility(Passives.MultiAttack2.m_PassiveID.ToString()))
                    {
                        exitAmount += ApplyStatusEffect(targets[j].Unit, entryVariable);
                    }
                }
            }

            return exitAmount > 0;
        }

        public int ApplyStatusEffect(IUnit unit, int entryVariable)
        {
            int num = (_RandomBetweenPrevious ? Random.Range(base.PreviousExitValue, entryVariable + 1) : entryVariable);
            if (num < _Status.MinimumRequiredToApply)
            {
                return 0;
            }

            if (!unit.ApplyStatusEffect(_Status, num))
            {
                return 0;
            }

            return Mathf.Max(1, num);
        }
    }
}
