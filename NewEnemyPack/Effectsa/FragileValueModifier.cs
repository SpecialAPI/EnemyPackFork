using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class FragileValueModifier : IntValueModifier
    {
        public readonly int FVAL;

        public FragileValueModifier(int exitVal)
            : base(999)
        {
            FVAL = exitVal;
        }

        public override int Modify(int value)
        {
            if (value > 0 && value >= FVAL)
            {
                value = FVAL;
            }

            return value;
        }
    }
}
