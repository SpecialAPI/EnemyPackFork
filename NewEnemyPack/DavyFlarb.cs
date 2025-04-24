using BrutalAPI;
using NewEnemyPack.Effectsa;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace NewEnemyPack
{
    internal class DavyFlarb
    {
        public static void Add()
        {


            ExtraAbilityInfo  extraAbilityInfo = new ExtraAbilityInfo();
            extraAbilityInfo.ability = Unflarb.parental.GenerateEnemyAbility().ability;
            extraAbilityInfo.rarity = Abil.Weight(0);

            Enemy enemy = new Enemy("Davy Flarb", "DavyFlarb_EN");
            enemy.Health = 25;
            enemy.HealthColor = Pigments.Yellow;
            enemy.Size = 2;

            enemy.CombatSprite = ResourceLoader.LoadSprite("DavyIcon", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldAliveSprite = ResourceLoader.LoadSprite("DavyOW", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.OverworldDeadSprite = ResourceLoader.LoadSprite("DavyCorpse", new Vector2?(new Vector2(0.5f, 0f)));
            enemy.DamageSound = "event:/Unflarb/UnflarbHurt";
            enemy.DeathSound = "event:/Unflarb/UnflarbDth";
            enemy.UnitTypes = new List<string> { "AmphibianID" };

            enemy.AddPassives(new BasePassiveAbilitySO[] { Passives.Skittish,Passives.ParentalGenerator(extraAbilityInfo)});
            enemy.PrepareEnemyPrefab("assets/unflarb/davy.prefab", Main.assetBundle, Main.assetBundle.LoadAsset<GameObject>("assets/unflarb/giblets_davy.prefab").GetComponent<ParticleSystem>());




            enemy.AddEnemyAbilities(new Ability[] { Unflarb.bonecrush, Unflarb.souldevour });
            enemy.AddEnemy(true, false, false);


        }

    }
}
