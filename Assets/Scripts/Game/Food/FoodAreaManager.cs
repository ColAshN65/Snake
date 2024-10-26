using NUnit.Framework;
using System;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.Food
{
    //Менеджер поля появления еды
    //Поле всегда хранит в себе 1 единицу еды, которая после поедания меняет свое расположение
    public class FoodAreaManager : MonoBehaviour
    {
        //Задается boxColider объекта, содержащего компонент FoodAreaManager
        [SerializeField] private BoxCollider2D boxCollider;

        //Задается эталон создоваемой еды
        [SerializeField] private Transform foodRefab;

        //Задается или хранится заданная или созданная еда
        [SerializeField] private SimpleFoodUnit simpleFoodUnit;

        private void Start()
        {
            RandomizePosition();
            simpleFoodUnit.Collised += FoodUnitEated;
        }

        private void FoodUnitEated(object sender, ObjectCollisionEventArgs e)
        {
            //Коллизия с вспомогательным объектом игнорируется
            if (e.Trigger.tag == "Support")
                return;

            if (e.Trigger.tag == "Player")
            {
                OnFoodEated(e.Trigger);

            }

            //Еда меняет свою позицию
            RandomizePosition();
        }

        //Изменение положения на доступной площади
        public void RandomizePosition()
        {
            //Границы поля, доступного для появления еды
            Bounds bounds = boxCollider.bounds;
            float x, y;

            //Поиск подходящей позиции
            do
            {
                //Запись случайных координат на основе границ площади появления
                x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
                y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);

            }
            while (!ValidatePosition(new Vector2(PositionRoundong(x), PositionRoundong(y)))); //Проверка на наличие объектов по данным координатам

            Debug.Log("Еда установлена");
            //Изменение параметра position компонента transform
            simpleFoodUnit.transform.position = new Vector3(
                PositionRoundong(x), PositionRoundong(y), //Округление координат, чтобы они легли ровно в сетку
                0.0f);
        }

        // Возврщает false, если конфликтует с  хоть одной коллизией объекта без тега "Support"
        private bool ValidatePosition(Vector2 position)
        {
            Vector2 size = new Vector2(0.25f, 0.25f);

            return !Physics2D.OverlapBoxAll(position, size, 0.0f).Any(c => c.tag != "Support");
        }

        #region Events

        public event EventHandler<FoodEatedEventArgs> FoodEated;

        protected void OnFoodEated(Collider2D trigger)
        {
            FoodEated?.Invoke(this, new FoodEatedEventArgs(trigger, this));
        }

        #endregion

        //Округление числа с точностью до 0.5
        private float PositionRoundong(float value)
        {
            return (float)Math.Ceiling(value / 0.5) * 0.5f;

        }
    }
}
