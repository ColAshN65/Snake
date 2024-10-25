using Assets.Scripts.Game.Settings;
using System;
using UnityEngine;

namespace Assets.Scripts.Snake
{
    //Ячейка головы змеи
    public class HeadCell : SnakeCell
    {
        //Направление движения головы, по умолчанию направо
        private Vector2 _direction = Vector2.right;


        private void OnTriggerEnter2D(Collider2D trigger)
        {
            OnSnakeCollision(trigger);
        }

        #region Events

        //Событие трапезы змейки
        public event EventHandler<ObjectCollisionEventArgs> SnakeCollision;

        protected void OnSnakeCollision(Collider2D trigger)
        {
            SnakeCollision?.Invoke(this, new ObjectCollisionEventArgs(trigger));
        }

        #endregion


        //Обновление направления движения
        public void UpdatewDirection()
        {
            //Считывание нажатий клавиш и установка соответствующего направления
            if (Input.GetKeyDown(ControlSystem.Up) && _direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKeyDown(ControlSystem.Down) && _direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
            else if (Input.GetKeyDown(ControlSystem.Left) && _direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
            else if (Input.GetKeyDown(ControlSystem.Right) && _direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
        }

        //Передвижение головы в заданном напрвалении
        public override void Move()
        {
            gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + _direction.x / 2,   //Каждый шаг происходит на 0.5 
            gameObject.transform.position.y + _direction.y / 2,
            0.0f);
        }
        public void Move(Bounds area)
        {
            Vector3 newPos = new Vector3(
            gameObject.transform.position.x + _direction.x / 2,   //Каждый шаг происходит на 0.5 
            gameObject.transform.position.y + _direction.y / 2,
            0.0f);

            if (newPos.x > area.max.x)
                newPos.x = newPos.x * -1 + 0.5f;

            if (newPos.x < area.min.x)
                newPos.x = newPos.x * -1 - 0.5f;

            if (newPos.y > area.max.y)
                newPos.y = newPos.y * -1 + 0.5f;

            if (newPos.y < area.min.y)
                newPos.y = newPos.y * -1 - 0.5f;

            gameObject.transform.position = newPos;
        }
    }
}
