using Assets.Scripts.Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private Transform SnakeRefab;
        [SerializeField] private SnakeEntity snake;

        [Header("Start Position")]
        [SerializeField] private int X = 0;
        [SerializeField] private int Y = 0;


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

        public void SnakeRespawn()
        {
            if (snake != null)
                snake.Kill();

            snake = Instantiate(SnakeRefab).GetComponent<SnakeEntity>();
            snake.transform.position = new Vector3(X, Y, 0);
            snake.SnakeHeadCollision += SnakeCollision;
            SnakeSpawn();

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
