using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Snake
{
    //Ячейка тела змейки
    public class BodyCell : SnakeCell
    {
        public SnakeCell trackCell;

        public void Start()
        {
            if (trackCell == null)
                Debug.LogError("У клетки тела змеи не задана клетка следования");
        }

        public void CellInit(SnakeCell trackCell, Vector3 position)
        {
            this.trackCell = trackCell;
            this.transform.position = position;
        }

        //Клетка передвигается по координатам клетки, за которой следует.
        public override void Move()
        {
            gameObject.transform.position = trackCell.GetPosition();
        }

    }
}
