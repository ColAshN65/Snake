using Assets.Scripts.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    //Менеджер игрока на уровне
    public class PlayerManager : MonoBehaviour
    {
        //Задается эталон земи для создания
        [SerializeField] private Transform SnakeRefab;

        //Задается или создается и хранится змея
        [SerializeField] private SnakeEntity snake;

        //Задется игровая зона из компонента BoxCollider2D
        [SerializeField] private BoxCollider2D GameArea;

        //Задаются стартовые координаты, если это необходимо
        [Header("Start Position")]
        [SerializeField] private int X = 0;
        [SerializeField] private int Y = 0;


        //Пересоздает змею
        public void SnakeRespawn()
        {
            if (snake != null)
                snake.Kill();

            snake = Instantiate(SnakeRefab).GetComponent<SnakeEntity>();
            snake.GameArea = GameArea.bounds;
            snake.transform.position = new Vector3(X, Y, 0);
            snake.SnakeHeadCollision += SnakeCollision;
            SnakeSpawn();

        }

        //Обработка коллизии змеи
        private void SnakeCollision(object sender, ObjectCollisionEventArgs e)
        {
            if (e.Trigger.tag == "Wall")
            {
                snake.Kill();
                OnPlayerDies();
            }
            else if (e.Trigger.tag == "Food")
            {
                snake.SnakeGrow();
            }
        }

        private void SnakeSpawn()
        {
            snake.Spawn();
        }

        #region Events

        public event EventHandler PlayerDied;

        private void OnPlayerDies()
        {
            PlayerDied?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
