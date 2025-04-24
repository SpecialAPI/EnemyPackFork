using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class IsMainCharacterEffectororMungCondition : EffectorConditionSO
    {
        // Token: 0x060017A9 RID: 6057 RVA: 0x0003CB24 File Offset: 0x0003AD24
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {

            if (effector.Name != "Mung" && !effector.IsMainCharacter)
            {
                return true;
            }
            return false;
        }

        // Token: 0x04000F1E RID: 3870

    }
}
