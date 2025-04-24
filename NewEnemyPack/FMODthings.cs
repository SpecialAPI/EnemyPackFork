using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NewEnemyPack
{
    internal class FMODthings
    {

      

        public static void TrySetCombatParameterID(Action<AudioControllerSO, MusicParameter, int, bool> orig, AudioControllerSO self, MusicParameter parameter, int ID, bool addition)
        {
            if (parameter == (MusicParameter)778902)
            {
                TreatCustomParameter(ID, addition, self);
                return;
            }

            if (parameter == (MusicParameter)778931)
            {
                TreatCustomParameter1(ID, addition, self);
                return;
            }

            if (parameter == (MusicParameter)778932)
            {
                TreatSlimeParameter(ID, addition, self);
                return;
            }

            if (parameter == (MusicParameter)778933)
            {
                TreatSlimeLakeParameter(ID, addition, self);
                return;
            }


            if (parameter == (MusicParameter)7789334)
            {
                TreatUnicornParameter(ID, addition, self);
                return;
            }
            orig(self, parameter, ID, addition);
        }
        public static HashSet<int> customHash;
        public static void TreatCustomParameter(int id, bool addition, AudioControllerSO self)
        {

            self.MusicCombatEvent.setParameterByName("KekapexSpawn", addition ? 1f : 0.0f, false);

        }

        public static void TreatCustomParameter1(int id, bool addition, AudioControllerSO self)
        {

            self.MusicCombatEvent.setParameterByName("MaestroSpawn", addition ? 1f : 0.0f, false);

        }

        public static void TreatSlimeParameter(int id, bool addition, AudioControllerSO self)
        {
            bool num = _slimeheapsIDs.Count > 0;
            if (addition)
            {
                _slimeheapsIDs.Add(id);
            }
            else
            {
                _slimeheapsIDs.Remove(id);
            }

            bool flag = _slimeheapsIDs.Count > 0;
            if (num != flag)
            {
                self.MusicCombatEvent.setParameterByName("SlimeParam", flag ? (float)0.5 : 0);
            }
        }

        public static void TreatSlimeLakeParameter(int id, bool addition, AudioControllerSO self)
        {
            bool num = _slimelakesIDs.Count > 0;
            if (addition)
            {
                _slimelakesIDs.Add(id);
            }
            else
            {
                _slimelakesIDs.Remove(id);
            }

            bool flag = _slimelakesIDs.Count > 0;
            if (num != flag)
            {
                self.MusicCombatEvent.setParameterByName("SlimeParam", flag ? (float)1 : 0);
            }
        }
        public static void TreatUnicornParameter(int id, bool addition, AudioControllerSO self)
        {
            bool num = _hiddenunicornIDs.Count > 0;
            if (addition)
            {
                _hiddenunicornIDs.Add(id);
            }
            else
            {
                _hiddenunicornIDs.Remove(id);
            }

            bool flag = _hiddenunicornIDs.Count > 0;
            if (num != flag)
            {
                self.MusicCombatEvent.setParameterByName("UnicornEmerge", flag ? 1 : 0);
            }
        }


        public static HashSet<int> _slimeheapsIDs = new HashSet<int>();

        public static HashSet<int> _hiddenunicornIDs = new HashSet<int>();

        public static HashSet<int> _slimelakesIDs = new HashSet<int>();
        public static void Add()
        {
            IDetour GrahGrabbleGroh = (IDetour)new Hook((MethodBase)typeof(AudioControllerSO).GetMethod(nameof(AudioControllerSO.TrySetCombatParameterID), ~BindingFlags.Default), typeof(FMODthings).GetMethod(nameof(TrySetCombatParameterID), ~BindingFlags.Default));
        }

        
    }
}
