using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctions : MonoBehaviour
{
    public Canvas canvas;

    public void ChangScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            canvas.gameObject.SetActive(false);
        }
    }
}
