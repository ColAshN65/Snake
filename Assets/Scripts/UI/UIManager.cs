using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("User Interface")]
        //Меню внутри уровня
        [SerializeField] private Transform LevelMenu;

        //Игровой интерфейс
        [SerializeField] private Transform GameUI;

        //Вывод количества очков
        [SerializeField] private Text TextScore;

        //Вывод количества очков
        [SerializeField] private Text MenuTextScore;
        //Вывод количества очков
        [SerializeField] private Text MenuTextGeneralScore;

        //Кнопка продолжения
        [SerializeField] private Button ContinueButton; 
        //Кнопка продолжения
        [SerializeField] private Button BackButton; 
        //Кнопка продолжения
        [SerializeField] private Button RestartButton;

        private void Start()
        {
            InterfaceInit();
        }

        //Инициализация интерфейса
        private void InterfaceInit()
        {
            if (LevelMenu == null)
                Debug.LogError("Не назначено меню уровня");
            LevelMenu.gameObject.SetActive(false);

            if (GameUI == null)
                Debug.LogError("Не назначен интерфейс уровня");
            GameUI.gameObject.SetActive(true);

            if (TextScore == null)
                Debug.LogError("Текст для вывода очков не назначен");
            if (MenuTextScore == null)
                Debug.LogError("Текст для вывода очков в меню не назначен");
            if (MenuTextGeneralScore == null)
                Debug.LogError("Текст для вывода общих очков в меню не назначен");

            if (MenuTextGeneralScore == null)
                Debug.LogError("Кнопка продолжения не назначена не назначена");

            MenuTextGeneralScore.text = "General Score: " + GameProcessing.GeneralScore;

            ButtonInit();
        }

        //Инцииализация кнопок
        private void ButtonInit()
        {
            //Кнопка продолжения
            if (ContinueButton == null)
                Debug.LogError("Кнопка продолжения не назначена не назначена");
            ContinueButton.onClick.AddListener(OnActionContinue);
            ContinueButton.interactable = true;

            //Кнопка возврата
            if (BackButton == null)
                Debug.LogError("Кнопка возвращения не назначена не назначена");
            BackButton.onClick.AddListener(OnActionBack);

            if (RestartButton == null)
                Debug.LogError("Кнопка рестарта не назначена не назначена");
            RestartButton.onClick.AddListener(OnActionRestart);

        }


        //Переключение интерфейса уровня между игровым и меню
        public void InterfaceSwitch()
        {
            LevelMenu.gameObject.SetActive(!LevelMenu.gameObject.active);
            GameUI.gameObject.SetActive(!LevelMenu.gameObject.active);
        }

        public void LevelMenuOpen()
        {
            LevelMenu.gameObject.SetActive(true);
            GameUI.gameObject.SetActive(false);
        }
        public void LevelMenuClose()
        {
            LevelMenu.gameObject.SetActive(false);
            GameUI.gameObject.SetActive(true);
        }

        public void ScoreUpdate(int score)
        {
            TextScore.text = "Score: " + score;
            MenuTextScore.text = "Score: " + score;

            if(score >= 30 || GameProcessing.GeneralScore >= 20)
                ContinueButton.interactable = true;
        }

        public event EventHandler ActionRestart;
        public void OnActionRestart()
        {
            ActionRestart?.Invoke(this, EventArgs.Empty);
        }


        public event EventHandler ActionBack;
        public void OnActionBack()
        {
            ActionBack?.Invoke(this, EventArgs.Empty);
        }


        public event EventHandler ActionContinue;
        public void OnActionContinue()
        {
            ActionContinue?.Invoke(this, EventArgs.Empty);
        }
    }
}
