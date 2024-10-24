using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Food
{
    [Serializable]
    public class SimpleFoodUnit : MonoBehaviour
    {
        public void Start()
        {
            BoxCollider2D boxCollider =  this.GetComponent<BoxCollider2D>(); 
        }

        private void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.tag == "Wall")
            {
                Debug.Log("Коллизия со стеной");
            }
            OnCollised(trigger);
        }

        #region Events

        public event EventHandler<ObjectCollisionEventArgs> Collised;

        protected void OnCollised(Collider2D trigger)
        {
            Collised?.Invoke(this, new ObjectCollisionEventArgs(trigger));
        }

        #endregion
    }
}
