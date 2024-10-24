using UnityEngine;

public class Food : MonoBehaviour
{
    //Экзэмпляр BoxColider доступной площади появления
    public BoxCollider2D gridArea;


    private void Start()
    {
        RandomizePosition();
    }

    //Изменение положения на доступной площади
    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        //Запись случайных координат на основе границ площади появления
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);


        //Изменение параметра position компонента transform
        this.transform.position =  new Vector3(
            Mathf.Round(x), Mathf.Round(y), //Округление координат, чтобы они легли ровно в сетку
            0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
        else
            Debug.Log("WTF, dude???");
    }
}
