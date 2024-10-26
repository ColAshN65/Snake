using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Levels
{
    public class ThirdLevelManager : LevelManager
    {
        protected override void ContinueLevel()
        {
            GameProcessing.RecordScoring();
            SceneManager.LoadScene("MainMenu");
        }

        protected override int SetLevelPassValue()
        {
            return 30;
        }
    }
}
