using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class BetterAdditionValueModifier : IntValueModifier
    {
        // Token: 0x0600282A RID: 10282 RVA: 0x0007392F File Offset: 0x00071B2F
        public BetterAdditionValueModifier(bool dmgDealt, int toAdd) : base(dmgDealt ? 10 : 66)
        {
            this.toAdd = toAdd;
        }

        // Token: 0x0600282B RID: 10283 RVA: 0x00073947 File Offset: 0x00071B47
        public override int Modify(int value)
        {
            value = value + this.toAdd;
            return Math.Max(0, value);
        }

        // Token: 0x04001FAA RID: 8106
        public readonly int toAdd;
    }
}
