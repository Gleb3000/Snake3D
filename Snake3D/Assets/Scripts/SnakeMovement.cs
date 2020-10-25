using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public GameObject tailPrefab;
    public Text scoreText;
    public Transform snakeTransform;
    public Transform delitedTailsTransform;
    private Rigidbody myRigidbody;

    public float speed;
    public int score = 0;

    void Start()
    {
        gameObject.transform.SetParent(snakeTransform);
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            myRigidbody.AddTorque(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.AddTorque(Vector3.down);
        }
        else
        {
            myRigidbody.angularVelocity = new Vector3(0, 0, 0);
        }
    }

    public void AddTail()
    {
        scoreText.text = (score+=1).ToString();

        Vector3 newTailPos = snakeTransform.GetChild(snakeTransform.childCount - 1).position;
 
        Instantiate(tailPrefab, newTailPos, Quaternion.identity, snakeTransform);
    }

    public void DeleteTail(int indx)
    {
        for (int i = snakeTransform.childCount-1; i >= indx-1; i--)
        {
            snakeTransform.GetChild(i).SetParent(delitedTailsTransform);
        }
        score = snakeTransform.childCount - 1;
        scoreText.text = score.ToString();
    }
}
