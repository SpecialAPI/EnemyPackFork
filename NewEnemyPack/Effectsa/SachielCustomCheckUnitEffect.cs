using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BrutalAPI;

namespace NewEnemyPack.Effectsa
{
    public class WasteTimeUIAction : CombatAction
    {
        // Token: 0x060003D0 RID: 976 RVA: 0x0002C3A2 File Offset: 0x0002A5A2
        public WasteTimeUIAction(int id, bool isUnitCharacter, string attackName)
        {
            this._id = id;
            this._isUnitCharacter = isUnitCharacter;
            this._attackName = attackName;
        }

        // Token: 0x060003D1 RID: 977 RVA: 0x0002C3C1 File Offset: 0x0002A5C1
        public override IEnumerator Execute(CombatStats stats)
        {
            yield return stats.combatUI.ShowAttackInformation(this._id, this._isUnitCharacter, "", "");
            yield break;
        }

        // Token: 0x04000171 RID: 369
        public int _id;

        // Token: 0x04000172 RID: 370
        public bool _isUnitCharacter;

        // Token: 0x04000173 RID: 371
        public string _attackName;

        // Token: 0x04000174 RID: 372
        public int _miliseconds;
    }
    public class SachielCustomCheckUnitEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (!targets[i].HasUnit || caster.ContainsPassiveAbility(Passives.ParasiteMutualism.m_PassiveID))
                {
                    return false;
                }
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Hmm... How about..."));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "I'll take this instead!"));
                CombatManager.Instance.AddUIAction(new WasteTimeUIAction(caster.ID, caster.IsUnitCharacter, ""));

                exitAmount++;
            }
            return exitAmount > 0;
        }
    }
}
