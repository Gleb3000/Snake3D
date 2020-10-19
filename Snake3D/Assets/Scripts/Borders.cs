using UnityEngine;
using UnityEngine.UI;

public class Borders : MonoBehaviour
{
    public Canvas canvas;
    public GameObject snakeHead;
    public Text recordText;

    void Start()
    {
        canvas.enabled = false;
        recordText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            canvas.enabled = true;
            snakeHead.GetComponent<SnakeMovement>().speed = 0;
            try
            {
                snakeHead.GetComponent<SnakeMovement>().taileObjects[1].GetComponent<TailMovement>().isMoving = false;
                snakeHead.GetComponent<SnakeMovement>().taileObjects[1].GetComponent<TailMovement>().indx = -2;
            }
            catch { }
            if(snakeHead.GetComponent<SnakeMovement>().score > PlayerPrefs.GetInt("Best Score"))
            {
                recordText.enabled = true;
                PlayerPrefs.SetInt("Best Score", snakeHead.GetComponent<SnakeMovement>().score);
            }
        }        
 
    }
   
}
