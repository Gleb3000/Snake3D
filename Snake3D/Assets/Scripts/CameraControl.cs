using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mainCamera;
    public Camera firsPearsonCamera;
    public Camera thirdPearsonCamera;
    private int cameraNum = 0;

    public void CameraChange()
    {
        cameraNum++;
        if (cameraNum == 0)
        {
            mainCamera.enabled = true;
            thirdPearsonCamera.enabled = false;
        }
        else if(cameraNum == 1)
        {
            mainCamera.enabled = false;
            firsPearsonCamera.enabled = true;
        }
        else
        {
            firsPearsonCamera.enabled = false;
            thirdPearsonCamera.enabled = true;
            cameraNum = -1;
        }
    }
}
