using UnityEngine;


namespace Assets.Scripts.Snake
{
    //����������� ������ ����
    public abstract class SnakeCell : MonoBehaviour
    {
        public abstract void Move();

        public Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }
        public void Die()
        {
            Destroy(this.gameObject);  
        }
    }
}
