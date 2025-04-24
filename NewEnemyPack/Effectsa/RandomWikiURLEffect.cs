using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NewEnemyPack.Effectsa
{
    public class RandomWikiURLEffect : EffectSO
    {
        // Token: 0x0600000D RID: 13 RVA: 0x00003C9C File Offset: 0x00001E9C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = entryVariable;
            int chance = Random.Range(0, 200);
            if (chance < 1)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Nycteribiidae");
            }
            else if (chance < 2)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Solifugae");
            }
            else if (chance < 3)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Doug_Walker_(comedian)");
            }
            else if (chance < 4)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Fantastic_Planet");
            }
            else if (chance < 5)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Fateful_Findings");
            }
            else if (chance < 6)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Rhinogradentia");
            }
            else if (chance < 7)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pacific_Northwest_tree_octopus");
            }
            else if (chance < 8)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/House_hippo");
            }
            else if (chance < 9)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Manatee");
            }
            else if (chance < 10)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Dugong");
            }
            else if (chance < 11)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Odobenocetops");
            }
            else if (chance < 12)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Eustreptospondylus");
            }
            else if (chance < 13)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Nigel_Marven");
            }
            else if (chance < 14)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Hotline_Miami_2:_Wrong_Number");
            }
            else if (chance < 15)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pikmin_(video_game)");
            }
            else if (chance < 16)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pikmin_2");
            }
            else if (chance < 17)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pikmin_3");
            }
            else if (chance < 18)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pikmin_4");
            }
            else if (chance < 19)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Hey!_Pikmin");
            }
            else if (chance < 20)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Armadillidiidae");
            }
            else if (chance < 21)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Armadillidae");
            }
            else if (chance < 22)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Binturong");
            }
            else if (chance < 23)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Chromosome");
            }
            else if (chance < 24)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Hippoidea");
            }
            else if (chance < 25)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Slipper_lobster");
            }
            else if (chance < 26)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Ranina_ranina");
            }
            else if (chance < 27)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Carnotaurus");
            }
            else if (chance < 28)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Majungasaurus");
            }
            else if (chance < 29)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Zoboomafoo");
            }
            else if (chance < 30)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Monster_Hunter");
            }
            else if (chance < 31)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Dougal_Dixon");
            }
            else if (chance < 32)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/After_Man");
            }
            else if (chance < 33)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_New_Dinosaurs");
            }
            else if (chance < 34)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Man_After_Man");
            }
            else if (chance < 35)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_Future_Is_Wild");
            }
            else if (chance < 36)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Barsoom");
            }
            else if (chance < 37)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Expedition_(book)");
            }
            else if (chance < 38)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Alien_Planet");
            }
            else if (chance < 39)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Wayne_Barlowe");
            }
            else if (chance < 40)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Transhuman");
            }
            else if (chance < 41)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Trans_woman");
            }
            else if (chance < 42)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Intersex");
            }
            else if (chance < 43)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/I_Have_No_Mouth,_and_I_Must_Scream");
            }
            else if (chance < 44)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Francis_Bacon_(artist)");
            }
            else if (chance < 45)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Hieronymus_Bosch");
            }
            else if (chance < 46)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_Garden_of_Earthly_Delights");
            }
            else if (chance < 47)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Triptych_of_the_Temptation_of_St._Anthony");
            }
            else if (chance < 48)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_Road");
            }
            else if (chance < 49)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/David_Lynch");
            }
            else if (chance < 50)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/David_Cronenberg");
            }
            else if (chance < 51)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Eraserhead");
            }
            else if (chance < 52)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Wild_at_Heart_(film)");
            }
            else if (chance < 53)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Twin_Peaks_(season_3)");
            }
            else if (chance < 54)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Videodrome");
            }
            else if (chance < 55)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Autism_spectrum");
            }
            else if (chance < 56)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cancer");
            }
            else if (chance < 57)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Death");
            }
            else if (chance < 58)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Consciousness_after_death");
            }
            else if (chance < 59)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Consciousness");
            }
            else if (chance < 60)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Sikhism");
            }
            else if (chance < 61)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Slug");
            }
            else if (chance < 62)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Snail");
            }
            else if (chance < 63)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Nautilus");
            }
            else if (chance < 64)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Argonaut_(animal)");
            }
            else if (chance < 65)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Canada");
            }
            else if (chance < 66)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/British_Columbia");
            }
            else if (chance < 67)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Portland,_Oregon");
            }
            else if (chance < 68)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Vancouver");
            }
            else if (chance < 69)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pakora");
            }
            else if (chance < 70)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Samosa");
            }
            else if (chance < 71)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Mango");
            }
            else if (chance < 72)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Toxodon");
            }
            else if (chance < 73)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Entelodon");
            }
            else if (chance < 74)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Gorgonopsia");
            }
            else if (chance < 75)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Dimetrodon");
            }
            else if (chance < 76)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Koolasuchus");
            }
            else if (chance < 77)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Estemmenosuchus");
            }
            else if (chance < 78)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Dunkleosteus");
            }
            else if (chance < 79)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cymothoa_exigua");
            }
            else if (chance < 80)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Yves_Tanguy");
            }
            else if (chance < 81)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Bigfoot");
            }
            else if (chance < 82)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Ogopogo");
            }
            else if (chance < 83)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Inuit");
            }
            else if (chance < 84)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Tomato_frog");
            }
            else if (chance < 85)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Jupiter");
            }
            else if (chance < 86)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Europa_(moon)");
            }
            else if (chance < 87)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/2001:_A_Space_Odyssey");
            }
            else if (chance < 88)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Gummo");
            }
            else if (chance < 89)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Harmony_Korine");
            }
            else if (chance < 90)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Neutral_Milk_Hotel");
            }
            else if (chance < 91)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Berserk_(manga)");
            }
            else if (chance < 92)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Kentaro_Miura");
            }
            else if (chance < 93)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Griffith_(Berserk)");
            }
            else if (chance < 94)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Eclipse");
            }
            else if (chance < 95)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Black_hole");
            }
            else if (chance < 96)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Kurt_G%C3%B6del");
            }
            else if (chance < 97)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Ludwig_Boltzmann");
            }
            else if (chance < 98)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Max_Ernst");
            }
            else if (chance < 99)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Salvador_Dal%C3%AD");
            }
            else if (chance < 100)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Fred_Figglehorn");
            }
            else if (chance < 101)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Carl_Jung");
            }
            else if (chance < 102)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Hard_problem_of_consciousness");
            }
            else if (chance < 103)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/David_Chalmers");
            }
            else if (chance < 104)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Marvin_Heemeyer");
            }
            else if (chance < 105)
            {
                Application.OpenURL("https://sonichu.com/cwcki");
            }
            else if (chance < 106)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Heat_death_paradox");
            }
            else if (chance < 107)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Heat_death_of_the_universe");
            }
            else if (chance < 108)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Big_Bang");
            }
            else if (chance < 109)
            {
                Application.OpenURL("https://en.m.wikipedia.org/wiki/Andres_Serrano");
            }
            else if (chance < 110)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Inflation_(cosmology)");
            }
            else if (chance < 111)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Another_World_(video_game)");
            }
            else if (chance < 112)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Alejandro_Jodorowsky");
            }
            else if (chance < 113)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Expedition_(book)");
            }
            else if (chance < 114)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_Holy_Mountain_(1973_film)");
            }
            else if (chance < 115)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Yayoi_Kusama");
            }
            else if (chance < 116)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Gal%C3%A1pagos_Islands");
            }
            else if (chance < 117)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Gal%C3%A1pagos_tortoise");
            }
            else if (chance < 118)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Marine_iguana");
            }
            else if (chance < 119)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cuckoo");
            }
            else if (chance < 120)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Clown");
            }
            else if (chance < 121)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Mime_artist");
            }
            else if (chance < 122)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Trash_Humpers");
            }
            else if (chance < 123)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cattle");
            }
            else if (chance < 124)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Zebu");
            }
            else if (chance < 125)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Indie_game");
            }
            else if (chance < 126)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Binding_of_Isaac");
            }
            else if (chance < 127)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Book_of_Revelation");
            }
            else if (chance < 128)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Edmund_McMillen");
            }
            else if (chance < 129)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Timoth%C3%A9e_Chalamet");
            }
            else if (chance < 130)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Walter_White_Jr.");
            }
            else if (chance < 131)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Dune_(franchise)");
            }
            else if (chance < 132)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Annihilation_(VanderMeer_novel)");
            }
            else if (chance < 133)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_Spiderwick_Chronicles");
            }
            else if (chance < 134)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/The_Search_for_WondLa#Adaptation");
            }
            else if (chance < 135)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Flanimals");
            }
            else if (chance < 136)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Moon");
            }
            else if (chance < 137)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pixel_art");
            }
            else if (chance < 138)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Disco_Elysium");
            }
            else if (chance < 139)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/World_of_Goo");
            }
            else if (chance < 140)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Rain_World");
            }
            else if (chance < 141)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Terry_A._Davis");
            }
            else if (chance < 142)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/TempleOS");
            }
            else if (chance < 143)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Wikipedia");
            }
            else if (chance < 144)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Panpsychism");
            }
            else if (chance < 145)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Sea_slug");
            }
            else if (chance < 146)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cuttlefish");
            }
            else if (chance < 147)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Octopus");
            }
            else if (chance < 148)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Giant_squid");
            }
            else if (chance < 149)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Yeti");
            }
            else if (chance < 150)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Iqaluit");
            }
            else if (chance < 151)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Half-Life_(series)");
            }
            else if (chance < 152)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Silent_Hill_2");
            }
            else if (chance < 153)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Silent_Hill_4:_The_Room");
            }
            else if (chance < 154)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cleaver");
            }
            else if (chance < 155)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Organism");
            }
            else if (chance < 156)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Flesh");
            }
            else if (chance < 157)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Amphisbaenia");
            }
            else if (chance < 158)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Tuatara");
            }
            else if (chance < 159)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Deprecation");
            }
            else if (chance < 160)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Acid");
            }
            else if (chance < 161)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Liminal_being");
            }
            else if (chance < 162)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Tulpa");
            }
            else if (chance < 163)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Homunculus");
            }
            else if (chance < 164)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Liminal_space_(aesthetic)");
            }
            else if (chance < 165)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Non-place");
            }
            else if (chance < 166)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/H._R._Giger");
            }
            else if (chance < 167)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Entropy");
            }
            else if (chance < 168)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Jack_Nance");
            }
            else if (chance < 169)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Causality");
            }
            else if (chance < 170)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Alopecia_(album)");
            }
            else if (chance < 171)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Death_Grips");
            }
            else if (chance < 172)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/In_the_Aeroplane_Over_the_Sea");
            }
            else if (chance < 173)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Exmilitary");
            }
            else if (chance < 174)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Cat");
            }
            else if (chance < 175)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Ecballium");
            }
            else if (chance < 176)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Peyote");
            }
            else if (chance < 177)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Maize");
            }
            else if (chance < 178)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pumpkin");
            }
            else if (chance < 179)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Over_the_Garden_Wall");
            }
            else if (chance < 180)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Hummus");
            }
            else if (chance < 181)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Punjab");
            }
            else if (chance < 182)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pallas%27s_cat");
            }
            else if (chance < 183)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Tibetan_fox");
            }
            else if (chance < 184)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pug");
            }
            else if (chance < 185)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Pejorative");
            }
            else if (chance < 186)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Saiga_antelope");
            }
            else if (chance < 187)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Chalicotheriinae");
            }
            else if (chance < 188)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Okapi");
            }
            else if (chance < 189)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/K%C4%81k%C4%81p%C5%8D");
            }
            else if (chance < 190)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Orangutan");
            }
            else if (chance < 191)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/God");
            }
            else if (chance < 192)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Chernobyl_disaster");
            }
            else if (chance < 193)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Narluga");
            }
            else if (chance < 194)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Humanzee");
            }
            else if (chance < 195)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Douglas_fir");
            }
            else if (chance < 196)
            {
                Application.OpenURL("https://brutalorchestra.wiki.gg/wiki/Brutal_Orchestra_Wiki");
            }
            else if (chance < 197)
            {
                Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            }
            else if (chance < 198)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Toilet_paper_orientation");
            }
            else if (chance < 199)
            {
                Application.OpenURL("https://en.wikipedia.org/wiki/Lisa:_The_Painful");
            }
            else
            {
                Application.OpenURL("https://hmpg.net/");
            }


            return exitAmount > 0;
        }
    }
}
