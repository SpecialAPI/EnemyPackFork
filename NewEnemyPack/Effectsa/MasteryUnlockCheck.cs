using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class MasteryUnlockCheck : ListedUnlockCheck
    {
        [EnemyRef] public static List<string> bossEntities = null;

        string[] achievemenIDs = new string[]  {
        "EP_Intijar_BossBeat_ACH", "EP_Unicorn_BossBeat_ACH", "EP_Squid_BossBeat_ACH", "EP_Doula_BossBeat_ACH",
                "EP_Kekapex_BossBeat_ACH", "EP_Cherubim_BossBeat_ACH", "EP_Opisthotonus_BossBeat_ACH", "EP_Fountain_BossBeat_ACH","EP_Highness_BossBeat_ACH", "EP_Sachiel_BossBeat_ACH", "EP_AllBosses_BossBeat_ACH",
                 "EP_Doula_Tragedy_ACH", "EP_Mimic_ACH", "EP_SquidTragedy_ACH","EP_Goblin_ACH", "EP_SachielTragedy_ACH",
                   "EP_IntijarComedy_ACH","EP_Gizo_Skinned_ACH","EP_UnicornComedy_ACH"
                };

        


        public override void GetUnlockData(List<UnlockableModData> dataList, IInformationCheckData checkData)
        {
            AchievementDataBase db = LoadedDBsHandler.AchievementDB;
            AchievementBase_t ach;
            foreach (string item in achievemenIDs)
            {
                ach = db.GetModdedAchievementInfo(item);
                if (!ach.m_offlinebAchieved)
                    return;
            }

            dataList.Add(unlockData);
        }



    }
}
