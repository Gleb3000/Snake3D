using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsFunctions : MonoBehaviour
{
    public Canvas canvas;
    public Text recordText;

    public void ChangScene(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
        recordText.enabled = false;
    }

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            canvas.enabled = false;
        }
    }
}
