using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class OtherPartyMemberEffector : EffectorConditionSO
    {
        // Token: 0x06001799 RID: 6041 RVA: 0x0003C9B8 File Offset: 0x0003ABB8
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            int count = CombatManager._instance._stats.CharactersOnField.Values.Count;
            bool flag = true;
            if (count <= 1)
            {
                return !flag;
            }
            return flag;
        }

        // Token: 0x04000F18 RID: 3864

    }
}
