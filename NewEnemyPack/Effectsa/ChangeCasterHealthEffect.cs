using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class ChangeCasterHealthEffect : EffectSO
    {
        public ManaColorSO _color1;

        public ManaColorSO _color2;

        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            caster.SetHealthTo(caster.CurrentHealth / 2);
            return false;
        }
    }
}
