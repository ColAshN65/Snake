using System;
using UnityEngine;

namespace Assets.Scripts.Snake
{
    //������ ������ ����
    public class HeadCell : SnakeCell
    {
        //����������� �������� ������, �� ��������� �������
        private Vector2 _direction = Vector2.right;


        private void OnTriggerEnter2D(Collider2D trigger)
        {
            OnSnakeCollision(trigger);
        }

        #region Events

        //������� ������� ������
        public event EventHandler<ObjectCollisionEventArgs> SnakeCollision;

        protected void OnSnakeCollision(Collider2D trigger)
        {
            SnakeCollision?.Invoke(this, new ObjectCollisionEventArgs(trigger));
        }

        #endregion


        //���������� ����������� ��������
        public void UpdatewDirection()
        {
            //���������� ������� ������ � ��������� ���������������� �����������
            if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
        }

        //������������ ������ � �������� �����������
        public override void Move()
        {
            gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + _direction.x / 2,   //������ ��� ���������� �� 0.5 
            gameObject.transform.position.y + _direction.y / 2,
            0.0f);
        }
    }
}
