using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private InputManager InputManager;

        private static bool isFirstConfig = false;

        public void CloseMenu()
        {
            ControlSystem.Save();
            this.gameObject.SetActive(false);
        }
    }
}
