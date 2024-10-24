using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        GameProcessing gameProcessing = new GameProcessing();


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
