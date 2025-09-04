using UnityEngine;
using UnityEngine.SceneManagement;
public class UIFunctions : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
