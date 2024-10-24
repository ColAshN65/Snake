using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectCollisionEventArgs : EventArgs
    {
        public Collider2D Trigger;

        public ObjectCollisionEventArgs(Collider2D trigger)
        {
            Trigger = trigger;
        }
    }
}
