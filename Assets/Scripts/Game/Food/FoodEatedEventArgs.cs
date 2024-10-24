using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class FoodEatedEventArgs : ObjectCollisionEventArgs
    {
        public FoodAreaManager FoodArea;

        public FoodEatedEventArgs(Collider2D trigger, FoodAreaManager foodArea) : base(trigger)
        {
            FoodArea = foodArea;
        }
    }
}
