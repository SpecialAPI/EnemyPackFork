using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class SaveBoolSetterEffect : EffectSO
    {

        public string variablename;

        public bool settotrue = true;
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {

            LoadedDBsHandler.InfoHolder.Run.inGameData.SetBoolData(variablename, settotrue);
            exitAmount = entryVariable;
            return true;
        }
    }
}
