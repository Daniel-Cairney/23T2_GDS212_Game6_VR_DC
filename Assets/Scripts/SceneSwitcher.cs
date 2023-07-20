using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DanielCairney
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void MainScene()
        {
            SceneManager.LoadScene("Main Scene");
        }

        public void GameOverScene()
        {
            SceneManager.LoadScene("Game Over Scene");
        }

        public void StartingScene()
        {
            SceneManager.LoadScene("Start Scene");
        }
    }

}