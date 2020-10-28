using UnityEngine;

public class TailMovement : MonoBehaviour
{
    private float speed;
    private bool gap;
    public int indx;
    public bool isMoving;

    public SnakeMovement snakeHead;
    private Rigidbody rb;
    private Rigidbody targetRb;
    public GameObject tailTargetObj;
    public Transform snakeTransform;


    void Start()
    {
        isMoving = true;
        gap = false;

        snakeHead = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovement>();
        rb = GetComponent<Rigidbody>();

        snakeTransform = snakeHead.snakeTransform;
        tailTargetObj = snakeTransform.GetChild(snakeTransform.childCount-2).gameObject;
        targetRb = tailTargetObj.GetComponent<Rigidbody>();

        speed = snakeHead.speed / 20;
        indx = snakeTransform.childCount;
    }

    void FixedUpdate()
    {
        if (indx == 2 || tailTargetObj.GetComponent<TailMovement>().isMoving && isMoving)
        {
            rb.MovePosition(Vector3.Lerp(rb.position, targetRb.position, Time.deltaTime * speed));
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
        if (other.gameObject.GetComponent<SnakeMovement>())
        {
            if(indx > 3)
            {
                isMoving = false;
                gap = true;
            }
        }
    }
}

