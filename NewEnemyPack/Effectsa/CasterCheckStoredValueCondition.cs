using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class CasterCheckStoredValueCondition : EffectConditionSO
    {
        // Token: 0x0600000A RID: 10 RVA: 0x00002E64 File Offset: 0x00001064
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            int storedValue = caster.SimpleGetStoredValue(this._valueName);
            return storedValue <= this.maximumAmount && storedValue >= this.minimumAmount;
        }

        // Token: 0x04000001 RID: 1
        public string _valueName;

        // Token: 0x04000002 RID: 2
        public int minimumAmount = 1;

        // Token: 0x04000003 RID: 3
        public int maximumAmount = 2;
    }
}
