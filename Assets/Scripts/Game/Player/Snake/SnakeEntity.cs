using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.HableCurve;

namespace Assets.Scripts.Snake
{
    public class SnakeEntity : MonoBehaviour
    {
        public int InitSnakeLength = 4;



        [Header("Elements")]
        //Эталон сегмента змеи
        [SerializeField]private Transform SegmentRefab;

        //Голова змеи
        [SerializeField]protected HeadCell Head;

        //Список элементов тела змеи
        protected List<BodyCell> body;

        //Работа непосредственно с движком Unity
        #region External

        private void Update()
        {
            Head.UpdatewDirection();
        }

        private void FixedUpdate()
        {
            SnakeMove();
        }

  

        #endregion

        //Появление змеи
        public void Spawn()
        {
            //Инициализация полей
            body = new List<BodyCell>();

            Head.SnakeCollision += OnSnakeHeadCollision;

            //Цикл, в котором создаются дополнительные элементы тела змеи,
            //в котором каждый новый элемент запоминает предыдущий и принимает координаты
            //левее предыдущего на 0.5
            float posX = this.transform.position.x - 0.5f;
            SnakeCell currentTrack = Head;
            for (int i = 0; i < InitSnakeLength; i++, posX -= 0.5f)
            {
                //Создать подобие игрового объекта
                Transform segment = Instantiate(SegmentRefab);

                BodyCell newCell = segment.GetComponent<BodyCell>();

                newCell.CellInit(currentTrack,
                    new Vector3(posX, Head.transform.position.y, Head.transform.position.z));

                body.Add(newCell);

                currentTrack = newCell;
            }
        }

        //Увеличение змеи
        public void SnakeGrow()
        {
            //Создать подобие игрового объекта
            Transform segment = Instantiate(SegmentRefab);


            //Создать новую ячейку тела

            segment.transform.position = body.Last().transform.position;

            BodyCell newCell = segment.GetComponent<BodyCell>();

            newCell.trackCell = body.Last();


            body.Add(newCell);

        }

        //Передвижение змеи
        private void SnakeMove()
        {
            if (body != null)
            {
                //Передвижение всего тела в порядке от конца до головы
                for (int i = body.Count - 1; i >= 0; i--)
                {
                    body[i].Move();
                }

                //Передвижение головы
                Head.Move();

            }

        }

        //Смерть змеи
        public void Kill()
        {

            foreach (BodyCell cell in body)
            {
                cell.Die();
            }

            Destroy(this.gameObject);
        }


        #region Events

        //Событие трапезы змейки
        public event EventHandler<ObjectCollisionEventArgs> SnakeHeadCollision;
        private void OnSnakeHeadCollision(object sender, ObjectCollisionEventArgs e)
        {
            SnakeHeadCollision?.Invoke(sender, e);
        }

        #endregion
    }

    public class ValueEventArgs : EventArgs
    {
        public int Value { get; private set; }

        public ValueEventArgs(int value) { Value = value; }
    }
}
