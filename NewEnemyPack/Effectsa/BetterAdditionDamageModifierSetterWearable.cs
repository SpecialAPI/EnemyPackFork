using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class BetterAdditionDamageModifierSetterWearable : BaseWearableSO
    {
        
       

        public override bool IsItemImmediate
        {
            get
            {
                return true;
            }
        }

        // Token: 0x17000345 RID: 837
        // (get) Token: 0x06000D83 RID: 3459 RVA: 0x00007428 File Offset: 0x00005628
        public override bool DoesItemTrigger
        {
            get
            {
                return true;
            }
        }

        // Token: 0x06000D84 RID: 3460 RVA: 0x000215A0 File Offset: 0x0001F7A0
        public override void TriggerPassive(object sender, object args)
        {

            if (this._useDealt)
            {

                DamageDealtValueChangeException ex = args as DamageDealtValueChangeException;


                if (ex != null && !ex.Equals(null))
                {
                    ex.AddModifier(new BetterAdditionValueModifier(true, this._toAdd));
                    return;
                }
            }
            else
            {
                DamageReceivedValueChangeException ex2 = args as DamageReceivedValueChangeException;
                if (ex2 != null && !ex2.Equals(null))
                {
                    ex2.AddModifier(new BetterAdditionValueModifier(false, this._toAdd));

                }
            }
        }

        // Token: 0x04000901 RID: 2305
        [Header("Addition Data")]
        [SerializeField]
        public bool _useDealt;

        // Token: 0x04000902 RID: 2306
        [SerializeField]
        public int _toAdd;
    }
}
