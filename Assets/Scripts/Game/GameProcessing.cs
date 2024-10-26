using Assets.Scripts.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public static class GameProcessing
    {
        public static int GeneralScore
        {
            get => _generalScore;
            private set
            {
                _generalScore = value;
                SaveScore();
            }
        }

        public static int LocalScore
        {
            get => _localScore;
            private set => _localScore = value;
        }


        private static int _localScore = 0;
        private static int _generalScore = 0;

        static GameProcessing()
        {
            GeneralScore = PlayerPrefs.GetInt("score");

        }
        /*private void Start()
        {
            GeneralScore = PlayerPrefs.GetInt("score");
        }*/

        public static void RecordScoring()
        {
            GeneralScore += LocalScore;
            ResetScoring();
        }

        public static void ResetScoring()
        {
            LocalScore = 0;
        }

        public static void SetScoring(int value)
        {
            LocalScore = value;
        }

        public static void SaveScore()
        {
            PlayerPrefs.SetInt("score", GeneralScore);
        }
    }
}
