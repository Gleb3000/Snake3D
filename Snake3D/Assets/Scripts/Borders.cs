using UnityEngine;

public class Borders : MonoBehaviour
{
    public Canvas canvas;
    public GameObject snakeHead;

    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            canvas.gameObject.SetActive(true);
            snakeHead.GetComponent<SnakeMovement>().speed = 0;
            try
            {
                snakeHead.GetComponent<SnakeMovement>().taileObjects[1].GetComponent<TailMovement>().isMoving = false;
                snakeHead.GetComponent<SnakeMovement>().taileObjects[1].GetComponent<TailMovement>().indx = -2;
            }
            catch { }
        }        
 
    }
   
}
