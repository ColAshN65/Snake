using Assets.Scripts.Game.Settings;
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

        //������������ ������ � �������� �����������
        public override void Move()
        {
            gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + _direction.x / 2,   //������ ��� ���������� �� 0.5 
            gameObject.transform.position.y + _direction.y / 2,
            0.0f);
        }
        public void Move(Bounds area)
        {
            Vector3 newPos = new Vector3(
            gameObject.transform.position.x + _direction.x / 2,   //������ ��� ���������� �� 0.5 
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
