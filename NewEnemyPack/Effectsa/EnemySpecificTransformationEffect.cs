using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace NewEnemyPack.Effectsa
{
    public class EnemySpecificTransformationEffect : EffectSO
    {
        // Token: 0x060018FF RID: 6399 RVA: 0x0003FC00 File Offset: 0x0003DE00
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            
            foreach (TargetSlotInfo targetSlotInfo in targets)
            {
                if (targetSlotInfo.HasUnit && targetSlotInfo.Unit is EnemyCombat)
                {
                    if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Mung_EN"))
                    {
                        
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Goa_EN"), true, true, false, false);
          

                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Goa_EN"))
                    {
                        
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Mung_EN"), true, true, false, false);
                     

                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("MudLung_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Lipbug_EN"), true, true, false, false);
                

                    }

                    else if(((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Lipbug_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("MudLung_EN"), true, true, false, false);
                       

                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("MunglingMudLung_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN"), true, true, false, false);
                     

                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("FlaMinGoa_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("MunglingMudLung_EN"), true, true, false, false);
                        

                    }



                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Flarb_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Unflarb_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Unflarb_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Flarb_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Flarblet_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Flarbleft_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Flarbleft_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Flarblet_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("JumbleGuts_Clotted_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Spoggle_Writhing_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Spoggle_Writhing_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("JumbleGuts_Clotted_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Spoggle_Spitfire_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Spoggle_Spitfire_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("JumbleGuts_Waning_EN"), true, true, false, false);


                    }



                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Spoggle_Ruminating_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Spoggle_Resonant_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("JumbleGuts_Flummoxing_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("YellowSandbank_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Sandbank_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Sandbank_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("YellowSandbank_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("GoldRoadie_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Roadie_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Roadie_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("GoldRoadie_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("DrySimian_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Nephilim_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Nephilim_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("DrySimian_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Cherubim_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Opisthotonus_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Opisthotonus_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Cherubim_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Wringle_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Keko_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Keko_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Wringle_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Kekapex_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Voboola_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Voboola_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Kekapex_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("TaMaGoa_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("DyingFlarb_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("DyingFlarb_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("TaMaGoa_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("SilverSuckle_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("GildedGulper_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("GildedGulper_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("SilverSuckle_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Neoplasm_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("SingingStone_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("SingingStone_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Neoplasm_EN"), true, true, false, false);


                    }



                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Chapman_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Scrungie_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Scrungie_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Chapman_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("MusicMan_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Gizo_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Gizo_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("MusicMan_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("SingingMountain_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Maestro_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Unterling_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("TitteringPeon_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("TitteringPeon_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Unterling_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("NextOfKin_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("NextOfKin_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("SterileBud_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("SterileBud_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("GigglingMinister_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("ChoirBoy_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("ChoirBoy_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("GigglingMinister_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("InHerImage_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("InHisImage_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("InHisImage_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("InHerImage_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Sepulchre_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Xiphactinus_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Xiphactinus_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Sepulchre_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Conductor_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("WrigglingSacrifice_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Conductor_EN"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("HickoryFire_BOSS"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("HickoryFuel_BOSS"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("HickoryFuel_BOSS"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("HickoryFire_BOSS"), true, true, false, false);


                    }


                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Psychopomp_EN"))
                    {
                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Metatron_EN"), true, true, false, false);


                    }

                    else if (((EnemyCombat)targetSlotInfo.Unit).Enemy == LoadedAssetsHandler.GetEnemy("Metatron_EN"))
                    {

                        EnemyCombat unit = stats.TryGetEnemyOnField(targetSlotInfo.Unit.ID);
                        stats.TryTransformEnemy(unit.ID, LoadedAssetsHandler.GetEnemy("Psychopomp_EN"), true, true, false, false);


                    }





                }
            }


            return false;

        }
    }
}
