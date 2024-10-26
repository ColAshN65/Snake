using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Levels
{
    public class SecondLevelManager : LevelManager
    {
        protected override void ContinueLevel()
        {
            SceneManager.LoadScene("ThirdLevel");
        }

        protected override int SetLevelPassValue()
        {
            return 2;
        }
    }
}
