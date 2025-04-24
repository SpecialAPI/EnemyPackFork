using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class TradeItemEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            OverworldCombatSharedDataSO combatData = LoadedDBsHandler.InfoHolder.CombatData;
            ItemUnlockDataBase itemUnlockDB = LoadedDBsHandler.ItemUnlocksDB;
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                //No Unit or an Enemy
                if (!targetSlotInfo.HasUnit || !targetSlotInfo.Unit.IsUnitCharacter)
                    continue;

                int index = (targetSlotInfo.Unit as CharacterCombat).ID;
                //ID is not from the active party
                if (index >= combatData.CharactersData.Length)
                    continue;

                CharacterInGameData chara = combatData.CharactersData[index];
                //character has no item
                if (!chara.HasWearable)
                    continue;

                //Get Random Item
                int itemIndex = Random.Range(0, itemUnlockDB.TreasureItems.Length);
                string itemID = itemUnlockDB.TreasureItems[itemIndex].itemName;
                BaseWearableSO newitem = LoadedAssetsHandler.GetWearable(itemID);

                targetSlotInfo.Unit.TrySetUpNewItem(newitem);
                //Create Item In Game Data
                ItemInGameData itemInGameData = new ItemInGameData(newitem);
                itemInGameData.SetHeldID(chara.CharacterSlot);


                //Swap Item
                LoadedDBsHandler.InfoHolder.Run.playerData._itemList[chara.ItemSlot] = itemInGameData;


              
                CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(targetSlotInfo.Unit.ID, targetSlotInfo.Unit.IsUnitCharacter, "Item Traded!"));
                exitAmount++;
            }

            return exitAmount > 0;
        }
    }
}
