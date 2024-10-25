using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game.Settings
{
    internal class InputManager : MonoBehaviour
    {
        private KeyCode pressedKey;

        [SerializeField] private List<Transform> ControlButtons;

        private void OnGUI()
        {
            if(Event.current.keyCode != KeyCode.None)
                pressedKey = Event.current.keyCode;
        }

        private void Start()
        {
            if (ControlButtons == null)
                Debug.LogError("Не назначены кнопки смены управления");

            ButtonContentUpdate();
        }

        public void ButtonContentUpdate()
        {
            ControlButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = ControlSystem.Up.ToString();
            ControlButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = ControlSystem.Down.ToString();
            ControlButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = ControlSystem.Left.ToString();
            ControlButtons[3].GetComponentInChildren<TextMeshProUGUI>().text = ControlSystem.Right.ToString();
        }

        public IEnumerator SetButton(GameObject button)
        {
            yield return new WaitUntil(() =>
            {
                if (Input.anyKeyDown)
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                        return true;

                    typeof(ControlSystem).GetProperty(button.name).SetValue(null, pressedKey, null);

                    button.GetComponentInChildren<TextMeshProUGUI>().text = pressedKey.ToString();

                    return true;

                }
                return false;
            }
            );
        }
    }
}
