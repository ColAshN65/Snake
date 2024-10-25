using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Settings
{
    internal class ControlSystem
    {
        public static KeyCode Up { get => _up; set => _up = value; }
        public static KeyCode Down { get => _down; set => _down = value; }

        public static KeyCode Left { get => _left; set => _left = value; }
        public static KeyCode Right { get => _right; set => _right = value; }


        private static KeyCode _up = KeyCode.W;
        private static KeyCode _down = KeyCode.S;

        private static KeyCode _left = KeyCode.A;
        private static KeyCode _right = KeyCode.D;

        static ControlSystem()
        {
            if(PlayerPrefs.GetInt("ControlUp") != 0)
                Up = (KeyCode)PlayerPrefs.GetInt("ControlUp");

            if(PlayerPrefs.GetInt("ControlDown") != 0)
                Down = (KeyCode)PlayerPrefs.GetInt("ControlDown");

            if (PlayerPrefs.GetInt("ControlLeft") != 0)
                Left = (KeyCode)PlayerPrefs.GetInt("ControlLeft");

            if (PlayerPrefs.GetInt("ControlRight") != 0)
                Right = (KeyCode)PlayerPrefs.GetInt("ControlRight");
        }

        public static void Save()
        {
            PlayerPrefs.SetInt("ControlUp", Convert.ToInt32(Up));
            PlayerPrefs.SetInt("ControlDown", Convert.ToInt32(Down));
            PlayerPrefs.SetInt("ControlLeft", Convert.ToInt32(Left));
            PlayerPrefs.SetInt("ControlRight", Convert.ToInt32(Right));
        }
    }
}
