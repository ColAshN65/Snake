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
    //Менеджер интерфейса с пользователем
    public class UIManager : MonoBehaviour
    {
        //Для работы всех функций в unity должны быть заданы все графические элементы


        [Header("UI Levels")]
        //Меню внутри уровня
        [SerializeField] private Transform LevelMenu;

        //Игровой интерфейс
        [SerializeField] private Transform GameUI;


        [Header("UI Elements")]
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

        //Порог очков, при котором UIManager сделает кнопку "Continue" кликабельной
        public int LevelPass = 0;

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

            //Всегда подтягивает общее количество очков самостоятельно
            MenuTextGeneralScore.text = "General Score: " + GameProcessing.GeneralScore;

            ButtonInit();
        }

        //Инцииализация кнопок с подпиской на событие нажатия
        private void ButtonInit()
        {
            //Кнопка продолжения
            if (ContinueButton == null)
                Debug.LogError("Кнопка продолжения не назначена не назначена");
            //Подписка на событие нажатия
            ContinueButton.onClick.AddListener(OnActionContinue);

            //Кнопка возврата
            if (BackButton == null)
                Debug.LogError("Кнопка возвращения не назначена не назначена");
            //Подписка на событие нажатия
            BackButton.onClick.AddListener(OnActionBack);

            //Кнопка выхода
            if (RestartButton == null)
                Debug.LogError("Кнопка рестарта не назначена не назначена");
            //Подписка на событие нажатия
            RestartButton.onClick.AddListener(OnActionRestart);

        }


        //Переключение интерфейса уровня между игровым и меню
        public void InterfaceSwitch()
        {
            LevelMenu.gameObject.SetActive(!LevelMenu.gameObject.active);
            GameUI.gameObject.SetActive(!LevelMenu.gameObject.active);
        }

        //Принудительное открытие меню уровня
        public void LevelMenuOpen()
        {
            LevelMenu.gameObject.SetActive(true);
            GameUI.gameObject.SetActive(false);
        }

        //Принудительное сокрытие меню уровня
        public void LevelMenuClose()
        {
            LevelMenu.gameObject.SetActive(false);
            GameUI.gameObject.SetActive(true);
        }

        //Метод обновления всех элементов, связанных с отображением очков.
        public void ScoreUpdate(int score)
        {
            TextScore.text = "Score: " + score;
            MenuTextScore.text = "Score: " + score;

            //В случае набора необходимого количества очков - кнопка продолжения становится активной
            if(score >= LevelPass)
                ContinueButton.interactable = true;
        }

        //Описания событий
        //В основном это события кнопок, дабы основная модель могла обрабатывать нажатия
        #region Events

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
        #endregion
    }
}
