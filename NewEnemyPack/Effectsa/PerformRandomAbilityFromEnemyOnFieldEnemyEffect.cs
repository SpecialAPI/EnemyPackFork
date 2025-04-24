using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class PerformRandomAbilityFromEnemyOnFieldEnemyEffect : EffectSO
    {
        // Token: 0x060001AA RID: 426 RVA: 0x0000E4EC File Offset: 0x0000C6EC
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            List<TargetSlotInfo> list = new List<TargetSlotInfo>();
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit)
                {
                    list.Add(targetSlotInfo);
                }
            }
            if (list.Count <= 0)
            {
                return false;
            }
            int index1 = Random.Range(0, list.Count);
            TargetSlotInfo targetSlotInfo2 = list[index1];
            EnemyCombat enemyCombat = caster as EnemyCombat;
            bool result;


            EnemyCombat enemycombat2 = targetSlotInfo2.Unit as EnemyCombat;
            if (enemycombat2 != null)
            {
                if (enemycombat2.Abilities == null || enemycombat2.Abilities.Count <= 0)
                {
                    result = false;
                }
                else
                {
                    int index = Random.Range(0, enemycombat2.Abilities.Count);
                    AbilitySO ability = enemycombat2.Abilities[index].ability;
                    CombatManager.Instance.AddSubAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, ability.GetAbilityLocData().text));
                    CombatManager.Instance.AddSubAction(new PlayAbilityAnimationAction(ability.visuals, ability.animationTarget, enemyCombat));
                    CombatManager.Instance.AddSubAction(new EffectAction(ability.effects, enemyCombat, 0));
                    result = true;
                }
            }
            else
            {
                result = (exitAmount > 0);
            }

            return result;
        }

        // Token: 0x04000061 RID: 97
        [SerializeField]
        public bool _increase = true;

        // Token: 0x04000062 RID: 98
        [SerializeField]
        public bool _entryAsPercentage;
    }
}
