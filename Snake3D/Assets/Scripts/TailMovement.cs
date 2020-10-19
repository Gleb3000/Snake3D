using UnityEngine;

public class TailMovement : MonoBehaviour
{
    private float speed;
    public int indx;
    public bool isMoving;
    private bool gap;

    public SnakeMovement snakeHead;
    private Vector3 tailTarget;
    private GameObject tailTargetObj;

    void Start()
    {
        isMoving = true;
        gap = false;
        snakeHead = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovement>();
        speed = snakeHead.speed*2;
        tailTargetObj = snakeHead.taileObjects[snakeHead.taileObjects.Count - 2];
        indx = snakeHead.taileObjects.IndexOf(gameObject);
    }

    void Update()
    {
        try
        {
            if (indx == 1 || tailTargetObj.GetComponent<TailMovement>().isMoving && isMoving)
            {
                tailTarget = tailTargetObj.transform.position;
                transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
                transform.LookAt(tailTarget);
            }
            else
            {
                isMoving = false;
                if (gap)
                {
                    snakeHead.DeleteTail(indx);
                    gap = false;
                }
                indx = -1;
            }
        }
        catch { }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            if(indx > 2)
            {
                isMoving = false;
                gap = true;
            }
        }
    }
}
