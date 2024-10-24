using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Food
{
    public class FoodManager : MonoBehaviour
    {
        [SerializeField] private Transform FoodRefab;
        [SerializeField] private List<FoodAreaManager> FoodFields;


        private void Start()
        {
            InitAllFoodAreas();
        }

        public void InitAllFoodAreas()
        {
            foreach (FoodAreaManager f in FoodFields)
            {
                f.FoodEated += OnSomeFoodEated;
            }
        }


        private void DeleteItem(FoodAreaManager foodArea)
        {
            if (foodArea != null)
            {
                Destroy(foodArea.gameObject);
            }
        }

        public event EventHandler<FoodEatedEventArgs> SomeFoodEated;

        private void OnSomeFoodEated(object sender, FoodEatedEventArgs e)
        {
            SomeFoodEated?.Invoke(sender, e);
        }

        public void RespawnAllFood()
        {
            foreach (FoodAreaManager foodAreaManager in FoodFields)
            {
                foodAreaManager.RandomizePosition();
            }
        }
    }
}
