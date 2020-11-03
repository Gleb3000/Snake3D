using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public GameObject snakeHead;
    public Transform UpCameraTransform;
    public Button button;

    public int cameraNum = 0;
    private int moveSpeed = 10;
    private int rotationSpeed = 20;

    public void CameraNumUpd()
    {
        if(cameraNum < 2)
        {
            cameraNum++;
        }
        else
        {
            cameraNum = 0;
        }
        OnChangeCameraPosClicked();
    }

    public void OnChangeCameraPosClicked()
    {
        if (cameraNum == 0)
        {
            StartCoroutine(ChangeCameraPos(UpCameraTransform, new Vector3(0,0,0), Quaternion.Euler(0,0,0)));
        }
        else if(cameraNum == 1)
        {
            StartCoroutine(ChangeCameraPos(snakeHead.transform, new Vector3(0,0,0), Quaternion.Euler(0,0,0)));
        }
        else
        {
            StartCoroutine(ChangeCameraPos(snakeHead.transform, new Vector3(0, 1, -1), Quaternion.Euler(27, 0, 0)));
        }
    }

    private IEnumerator ChangeCameraPos(Transform pos, Vector3 vector, Quaternion quaternion)
    {
        transform.SetParent(pos);

        while (Vector3.Distance(transform.localPosition, vector) > 0.1f)
        {
            button.interactable = false;

            transform.localPosition = Vector3.Lerp(transform.localPosition, vector, moveSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, quaternion, rotationSpeed * Time.deltaTime);

            yield return null;
        }

        transform.localPosition = vector;
        transform.localRotation = quaternion;

        button.interactable = true;
    }    
}
