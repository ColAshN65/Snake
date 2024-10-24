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

namespace Assets.Scripts.Game
{
    public abstract class LevelManager : MonoBehaviour
    {
        private void Start()
        {
            InterfaceInit();
            FoodInit();
            PlayerInit();

            Debug.Log("LevelController Loaded");
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIManager.InterfaceSwitch();
            }
        }

        #region Interface

        [Header("User Interface")]
        [SerializeField] private UIManager UIManager;

        private void InterfaceInit()
        {
            if(UIManager == null)
                Debug.Log("Не назначен UIManager");

            UIManager.ActionBack += (obj, e) => { ActionBack(); };
            UIManager.ActionContinue += (obj, e) => { ActionContinue(); };
            UIManager.ActionRestart += (obj, e) => { ActionRestart(); };

            UIManager.ScoreUpdate(0);
        }



        public void ActionRestart()
        {
            UIManager.LevelMenuClose();
            RestartGame();
        }
        public void ActionBack()
        {
            BreakLevel();
        }
        public void ActionContinue()
        {
            GameProcessing.GeneralScore += Score;
            ContinueLevel();
        }




        #endregion

        #region Game

        [Header("Settings")]

        [SerializeField] private FoodManager FoodManager;
        protected int Score
        {
            get { return _score; }
            set { _score = value; UIManager.ScoreUpdate(value); }
        }
        private int _score = 0;

        
        //Прерывание уровня
        protected void BreakLevel()
        {
            SceneManager.LoadScene("MainMenu");
        }

        protected void RestartGame()
        {
            Score = 0;  
            FoodManager.RespawnAllFood();
            PlayerManager.SnakeRespawn();
        }

        protected abstract void ContinueLevel();

        #endregion

        #region Food

        private void FoodInit()
        {
            if (FoodManager == null)
                Debug.Log("Не назначен FoodManager");

            FoodManager.SomeFoodEated += SomeFoodEated;

        }

        private void SomeFoodEated(object sender, FoodEatedEventArgs e)
        {
            if (e.FoodArea is FoodAreaManager)
            {
                Score++;
            }
        }

        #endregion

        #region Player

        [SerializeField] private PlayerManager PlayerManager;

        private void PlayerInit()
        {
            if (PlayerManager == null)
                Debug.Log("Не назначен PlayerManager");

            PlayerManager.SnakeRespawn();

            PlayerManager.PlayerDied += (obj, e) => { PlayerDied(); };
        }

        private void PlayerDied()
        {
            UIManager.LevelMenuOpen();
        }

        #endregion

    }
}
