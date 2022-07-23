using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public static class MySceneManager
    {
        public static void reload()
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public static void nextLevel()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}