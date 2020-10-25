using UnityEngine;

public class TailMovement : MonoBehaviour
{
    private float speed;
    private bool gap;
    public int indx;
    public bool isMoving;

    public SnakeMovement snakeHead;
    private Vector3 tailTarget;
    public GameObject tailTargetObj;
    public Transform snakeTransform;

    void Start()
    {
        isMoving = true;
        gap = false;

        snakeHead = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovement>();

        snakeTransform = snakeHead.snakeTransform;
        tailTargetObj = snakeTransform.GetChild(snakeTransform.childCount-2).gameObject;

        speed = snakeHead.speed / 20;
        indx = snakeTransform.childCount;
    }

    void Update()
    {
        if (indx == 2 || tailTargetObj.GetComponent<TailMovement>().isMoving && isMoving)
        {
            tailTarget = tailTargetObj.transform.position;
            transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * speed);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            if(indx > 3)
            {
                isMoving = false;
                gap = true;
            }
        }
    }
}

