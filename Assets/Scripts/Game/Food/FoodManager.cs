using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Food
{
    //Менеджер всей еды на уровне
    public class FoodManager : MonoBehaviour
    {
        //Задается эталон создаваемой еды
        //Подразумевается, что эталоном должен быть префаб с компонентом FoodAreaManager
        //[SerializeField] private Transform FoodRefab;

        //Задаются все FoodAreaManager, зоны, в которых появляется еда
        [SerializeField] private List<FoodAreaManager> FoodFields;

        private void Start()
        {
            InitAllFoodAreas();
        }

        public void InitAllFoodAreas()
        {
            //Подписка на сбытия всех полей
            foreach (FoodAreaManager f in FoodFields)
            {
                f.FoodEated += OnSomeFoodEated;
            }
        }

        public event EventHandler<FoodEatedEventArgs> SomeFoodEated;

        private void OnSomeFoodEated(object sender, FoodEatedEventArgs e)
        {
            SomeFoodEated?.Invoke(sender, e);
        }

        //Пересоздает еду во всех своих зонах
        public void RespawnAllFood()
        {
            foreach (FoodAreaManager foodAreaManager in FoodFields)
            {
                foodAreaManager.RandomizePosition();
            }
        }
    }
}
