using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game.Levels
{
    //Менеджер первого уровня
    public class FirstLevelManager : LevelManager
    {
        protected override void ContinueLevel()
        {
            SceneManager.LoadScene("SecondLevel");
        }

        protected override int SetLevelPassValue()
        {
            return 10;
        }
    }
}
