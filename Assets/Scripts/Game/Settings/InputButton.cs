using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Settings
{
    internal class InputButton : MonoBehaviour
    {
        public void StartInput()
        {
            GameObject.Find("InputManager").GetComponent<InputManager>().StartCoroutine("SetButton", gameObject);
        }
    }
}
