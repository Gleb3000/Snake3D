using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public GameObject snakeHead;
    public Button button;

    public int cameraNum = 0;
    private int moveSpeed = 10;
    private int rotationSpeed = 20;
    private int flag = 1;
    private Vector3 cameraThirdPos = new Vector3(0, 1, -1);


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
    }

    void LateUpdate()
    {
        if (cameraNum == 0 && flag == 0)
        {
            if (Vector3.Distance(transform.position, new Vector3(0, 18, -6)) > 0.1f)
            {
                button.interactable = false;
                transform.SetParent(null);

                transform.position = Vector3.Lerp(transform.position, new Vector3(0, 18, -6), moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(75, 0, 0), rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Euler(75, 0, 0);
                transform.position = new Vector3(0, 18, -6);

                flag = 1;
                button.interactable = true;
            }
        }
        else if(cameraNum == 1 && flag == 1)
        {
            if (Vector3.Distance(transform.position, snakeHead.transform.position) > 0.35f)
            {
                button.interactable = false;

                transform.position = Vector3.Lerp(transform.position, snakeHead.transform.position, moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, snakeHead.transform.rotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                gameObject.transform.SetParent(snakeHead.transform);

                transform.localRotation = Quaternion.Euler(0,0,0);
                transform.localPosition = new Vector3(0,0,0);

                flag = 2;
                button.interactable = true;
            }
        }
        else if(cameraNum == 2 && flag == 2)
        {
            if (Vector3.Distance(transform.localPosition, cameraThirdPos) > 0.35f)
            {
                button.interactable = false;

                transform.localPosition = Vector3.Lerp(transform.localPosition, cameraThirdPos, moveSpeed/2 * Time.deltaTime);
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(45,0,0), rotationSpeed/2 * Time.deltaTime);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(27, 0, 0);
                transform.localPosition = cameraThirdPos;

                flag = 0;
                button.interactable = true;
            }
        }
    }
}
