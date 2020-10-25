using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public GameObject penel;
    public Text recordText;
    public Camera mainCamera;

    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            penel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            penel.SetActive(false);
        }
    }

    public void CameraControl()
    {
        mainCamera.GetComponent<CameraMovement>().CameraNumUpd();
    }

    public void Disenebled()
    {
        if(recordText.enabled)
            recordText.enabled = false;
    }
}
