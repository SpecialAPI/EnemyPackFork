using System;
using System.Collections.Generic;
using System.Text;

namespace NewEnemyPack.Effectsa
{
    public class CheckAndCombineEnemiesAction : IImmediateAction
    {
        // Token: 0x0600045E RID: 1118 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
        public CheckAndCombineEnemiesAction(IUnit Caster, EnemySO Spawned_Enemy, BasePassiveAbilitySO Passive, string PassiveToRemove)
        {
            this.Caster = Caster;
            this.Spawned_Enemy = Spawned_Enemy;
            this.Passive = Passive;
            this.PassiveToRemove = PassiveToRemove;
        }

        public IUnit Caster;
        public EnemySO Spawned_Enemy;
        public BasePassiveAbilitySO Passive;
        public string PassiveToRemove;

        // Token: 0x0600045F RID: 1119 RVA: 0x0000CC14 File Offset: 0x0000AE14
        public void Execute(CombatStats stats)
        {
            int RightSide = Caster.SlotID + Caster.Size;
            if (stats.combatSlots._enemySlots.Length > RightSide)
            {
                if (stats.combatSlots._enemySlots[RightSide].HasUnit)
                {
                    if (stats.combatSlots._enemySlots[RightSide].Unit.Name == Caster.Name)
                    {
                       
                        IUnit Wife = stats.combatSlots._enemySlots[RightSide].Unit;
                        int newhealth = Wife.CurrentHealth + Caster.CurrentHealth;
                        CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(Caster.ID, Caster.IsUnitCharacter, this.Passive._passiveName, this.Passive.passiveIcon));
                        Caster.DirectDeath(null);

                       
                        if (Wife.ContainsPassiveAbility(this.Passive.m_PassiveID))
                        {
                            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(Wife.ID, Wife.IsUnitCharacter, this.Passive._passiveName, this.Passive.passiveIcon));
                        }
                        Wife.DirectDeath(null);

                        

                        CombatManager.Instance.AddSubAction(new SpawnEnemyAction(Spawned_Enemy, Caster.SlotID, true, false, "Spawn_Basic", newhealth));

                        return;
                    }
                }
            }

            if (Caster.SlotID != 0)
            {
                if (stats.combatSlots._enemySlots[Caster.SlotID - 1].HasUnit)
                {
                    if (stats.combatSlots._enemySlots[Caster.SlotID - 1].Unit.Name == Caster.Name)
                    {

                        IUnit Wife = stats.combatSlots._enemySlots[Caster.SlotID - 1].Unit;
                        int newhealth = Wife.CurrentHealth + Caster.CurrentHealth;
                        int SpawnSlot = Wife.SlotID;
                        if (Wife.ContainsPassiveAbility(this.Passive.m_PassiveID))
                        {
                            CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(Wife.ID, Wife.IsUnitCharacter, this.Passive._passiveName, this.Passive.passiveIcon));
                        }
                        Wife.DirectDeath(null);

                        CombatManager.Instance.AddUIAction(new ShowPassiveInformationUIAction(Caster.ID, Caster.IsUnitCharacter, this.Passive._passiveName, this.Passive.passiveIcon));
                        Caster.DirectDeath(null);

                        CombatManager.Instance.AddSubAction(new SpawnEnemyAction(Spawned_Enemy, SpawnSlot, true, false, "Spawn_Basic", newhealth));

                        return;
                    }
                }
            }
        }
    }
}
