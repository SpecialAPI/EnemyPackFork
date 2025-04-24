using BrutalAPI;
using MarmoItems;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class ClassicPassiveAbility : BasePassiveAbilitySO
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x0600000A RID: 10 RVA: 0x000032D8 File Offset: 0x000014D8
        public override bool IsPassiveImmediate
        {
            get
            {
                return true;
            }
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x0600000B RID: 11 RVA: 0x000032DB File Offset: 0x000014DB
        public override bool DoesPassiveTrigger
        {
            get
            {
                return true;
            }
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000032E0 File Offset: 0x000014E0
        public override void TriggerPassive(object sender, object args)
        {
            IUnit unit = sender as IUnit;

            DamageReceivedValueChangeException ex = args as DamageReceivedValueChangeException;
            bool flag2 = ex != null && ex.amount > 0;
            if (flag2)
            {
                bool flag3 = args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals(null);
                if (flag3)
                {
                    (args as DamageReceivedValueChangeException).AddModifier(new FragileValueModifier(this._modifyVal));
                    CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction((sender as IPassiveEffector).ID, (sender as IPassiveEffector).IsUnitCharacter, base.GetPassiveLocData().text, ResourceLoader.LoadSprite("Classic")));
                }
            }
            CanHealReference canHealReference = args as CanHealReference;
            if (canHealReference != null)
            {
                CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(unit.ID, unit.IsUnitCharacter, base.GetPassiveLocData().text, ResourceLoader.LoadSprite("Classic")));
                canHealReference.value = false;
            }
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00003494 File Offset: 0x00001694
        public override void OnPassiveConnected(IUnit unit)
        {
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00003497 File Offset: 0x00001697
        public override void OnPassiveDisconnected(IUnit unit)
        {
        }

        // Token: 0x04000002 RID: 2
        [Header("Multiplier Data")]
        [SerializeField]
        [Min(0f)]
        private int _modifyVal = 1;
    }
}
