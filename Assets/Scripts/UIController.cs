using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Skibidi");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
