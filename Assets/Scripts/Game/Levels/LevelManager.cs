using Assets.Scripts.Food;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.Game
{
    //Абстрактный менеджер уровня, который содержит все базовые функции для менеджеров уровней.
    public abstract class LevelManager : MonoBehaviour
    {

        //Внутренние функции MonoBeh
        #region External

        //Инициализация
        private void Start()
        {
            InterfaceInit();
            FoodInit();
            PlayerInit();

            //Установить необходимый уровень очков для интерфейса
            UIManager.LevelPass = SetLevelPassValue();

            //Очки копируются из статического счетчика очков
            Score = GameProcessing.LocalScore;
        }

        private void Update()
        {
            //Проверка на нажатый ESC
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Переключение интерфейса
                UIManager.InterfaceSwitch();
            }
        }

        #endregion


        [Header("User Interface")]
        //Описание интерфейса
        #region Interface

        //Менеджер интерфейса
        //В нем происходит вся работа с UI
        [SerializeField] protected UIManager UIManager;

        private void InterfaceInit()
        {
            if(UIManager == null)
                Debug.Log("Не назначен UIManager");

            //Подписка на события менеджера интерфейса
            //В основном это события нажатых кнопок
            UIManager.ActionBack += (obj, e) => { ActionBack(); };
            UIManager.ActionContinue += (obj, e) => { ActionContinue(); };
            UIManager.ActionRestart += (obj, e) => { ActionRestart(); };
        }


        //Действие "Рестарт".
        //Начинает уровень с начала
        public void ActionRestart()
        {
            UIManager.LevelMenuClose();
            RestartGame();
        }

        //Действие "Назад"
        //Возвращает игрока в главное меню
        public void ActionBack()
        {
            BreakLevel();
        }

        //Действие "Продолжить"
        //Отправяет игрока на следующий уровень
        public void ActionContinue()
        {
            GameProcessing.SetScoring(Score);
            ContinueLevel();
        }

        #endregion


        [Header("Settings")]
        //Описание логики уровня
        #region Game

        //Счетчик очков уровня
        protected int Score
        {
            get { return _score; }
            set { _score = value; UIManager.ScoreUpdate(value); } //После смены значения заставляет UI Manager обновить все элементы, связанные с отображением счетчика
        }
        private int _score = 0;

        
        //Прерывание уровня
        protected void BreakLevel()
        {
            //Просто загружает сцену главного меню
            SceneManager.LoadScene("MainMenu");
        }

        //Рестарт уровня
        protected void RestartGame()
        {
            //Откатывает счетчик очков к прежнему занчению(на момент начала уровня)
            Score = GameProcessing.LocalScore;  

            //Пересоздает еду и игрока на уровне
            FoodManager.RespawnAllFood();
            PlayerManager.SnakeRespawn();
        }

        //Продолжение игры
        protected abstract void ContinueLevel(); //Абстрактный метод, который подразумевает реализацию перехода от уровня-наследника к следущей сцене.

        protected abstract int SetLevelPassValue(); //Абстрактный метод, который подразумевает указание наследником нужного количества очков для его завершения

        #endregion


        //Описание "Еды" на уровне
        #region Food

        //Менеджер еды на уровне
        [SerializeField] protected FoodManager FoodManager;

        //Инциализация еды на уровне
        private void FoodInit()
        {
            if (FoodManager == null)
                Debug.Log("Не назначен FoodManager");

            //Подписка на событие менеджера
            FoodManager.SomeFoodEated += SomeFoodEated;
        }

        //В случае, если какая-либо еда посчитала себя съеденой, счетчик очков инкримируется.
        private void SomeFoodEated(object sender, FoodEatedEventArgs e)
        {
            if (e.FoodArea is FoodAreaManager)
            {
                Score++;
            }
        }

        #endregion


        //Описание игрока на уровне
        #region Player

        //Менеджер игрока
        [SerializeField] protected PlayerManager PlayerManager;

        //Инициализация игрока
        private void PlayerInit()
        {
            if (PlayerManager == null)
                Debug.Log("Не назначен PlayerManager");

            //Заставить менеджер пересоздать игрока
            PlayerManager.SnakeRespawn();

            //Подписка на события менеджера
            PlayerManager.PlayerDied += (obj, e) => { PlayerDied(); };
        }

        //В случе смерти игрока открывается меню уровня, где он может продолжить, выйти или начать уровень заново
        private void PlayerDied()
        {
            UIManager.LevelMenuOpen();
        }

        #endregion

    }
}
