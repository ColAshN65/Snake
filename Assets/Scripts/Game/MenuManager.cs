using Assets.Scripts.Game.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class MenuManager : MonoBehaviour
    {

        [SerializeField] private Text generalScoreText;

        public void Start()
        {
            GameProcessing.ResetScoring();
            generalScoreText.text = "General Score: " + GameProcessing.GeneralScore;
        }

        public void OnApplicationQuit()
        {
            GameProcessing.SaveScore();
        }

        //Старт игры
        public void PlayGame()
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("FirstLevel");
        }

        //Конец игры
        public void EndGame()
        {
            SceneManager.LoadScene("MainMenu");
        }

        //Выход из игры
        public void ExitGame()
        {
            Application.Quit();
        }

    }
}
