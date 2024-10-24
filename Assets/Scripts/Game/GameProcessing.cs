using Assets.Scripts.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameProcessing : MonoBehaviour
    {
        internal static int GeneralScore {  get; set; }

        [SerializeField] private FoodManager foodManager;

        static GameProcessing()
        {
            GeneralScore = 0;
        }
    }
}
