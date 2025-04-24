using NewEnemyPack.Encounters.NewEncounters;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack.Effectsa
{
    public class ModdedGroupBossUnlockCheck : ListedUnlockCheck
    {
        [EnemyRef] public static List<string> bossEntities = null;


        public override void GetUnlockData(List<UnlockableModData> dataList, IInformationCheckData checkData)
        {
            bossEntities = new List<string> { "Sachiel_EN", "HeinousHighness_EN", "TheFountainofYouth_EN", "Opisthotonus_EN", "Cherubim_EN", "Kekapex_EN", "Intijar_BOSS", "MalformedUnicorn_BOSS", "DepressionSquid_BOSS", "Doula_BOSS" };
            int bossesKilled = 0;
           
            IGameCheckData gameData = checkData.GameChecks;
            foreach (string item in bossEntities)
            {
                Enemy_SD2024 enemyData = gameData.GetEnemyKilledData(item);
                if (enemyData != null)
                {
                    bossesKilled++;
                }


            }

            if (bossesKilled == bossEntities.Count)
                dataList.Add(unlockData);
        }



    }
}
