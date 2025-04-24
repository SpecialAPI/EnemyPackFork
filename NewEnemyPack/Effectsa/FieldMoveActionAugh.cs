using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    public class SelfMoveFieldsAction : IImmediateAction
    {
        // Token: 0x0600045E RID: 1118 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
        public SelfMoveFieldsAction(FieldEffect_SO field, int oldSlot, int newSlot, int size, bool applyToCharacters)
        {
            this._oldSlot = oldSlot;
            this._newSlot = newSlot;
            this._size = size;
            this._applyToCharacters = applyToCharacters;
            this._Field = field;
        }

        // Token: 0x0600045F RID: 1119 RVA: 0x0000CC14 File Offset: 0x0000AE14
        public void Execute(CombatStats stats)
        {
            List<int[]> TargetTileAndAmounts = new List<int[]>();

            if (this._applyToCharacters)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (stats.combatSlots._characterSlots[_oldSlot + i].ContainsFieldEffect(_Field.FieldID))
                    {
                        int Amount = 0;

                        foreach (IFieldEffect a in stats.combatSlots._characterSlots[_oldSlot + i].FieldEffects)
                        {
                            Debug.Log(a.FieldID);
                            if (a.FieldID == _Field.FieldID) { Amount = a.FieldContent; }
                        }

                        stats.combatSlots._characterSlots[_oldSlot + i].RemoveFieldEffect(_Field.FieldID);

                        TargetTileAndAmounts.Add(new int[] { _newSlot + i, Amount });

                    }
                }
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    if (stats.combatSlots._enemySlots[_oldSlot + i].ContainsFieldEffect(_Field.FieldID))
                    {
                        int Amount = 0;

                        foreach (IFieldEffect a in stats.combatSlots._enemySlots[_oldSlot + i].FieldEffects)
                        {
                            Debug.Log(a.FieldID);
                            if (a.FieldID == _Field.FieldID) { Amount = a.FieldContent; }
                        }

                        stats.combatSlots._enemySlots[_oldSlot + i].RemoveFieldEffect(_Field.FieldID);

                        TargetTileAndAmounts.Add(new int[] { _newSlot + i, Amount });

                    }
                }
            }

            foreach (int[] a in TargetTileAndAmounts)
            {
                stats.combatSlots.ApplyFieldEffect(a[0], this._applyToCharacters, this._Field, a[1]);
            }
        }

        // Token: 0x040003CD RID: 973
        public int _oldSlot;

        // Token: 0x040003CE RID: 974
        public int _newSlot;

        // Token: 0x040003CF RID: 975
        public int _size;

        // Token: 0x040003D0 RID: 976
        public bool _applyToCharacters;

        // Token: 0x040003D1 RID: 977
        public FieldEffect_SO _Field;
    }
}


