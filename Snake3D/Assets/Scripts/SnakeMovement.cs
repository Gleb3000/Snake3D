using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public List<GameObject> taileObjects = new List<GameObject>();
    public GameObject tailPrefab;

    public float speed = 4;
    private float rotationSpeed = 300f;
    public Text scoreText;
    public int score = 0;

    void Start()
    {
        taileObjects.Add(gameObject); 
    }


    void Update()
    {
        scoreText.text = score.ToString();

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
    }

    public void AddTail()
    {
        score++;
        Vector3 newTailPos = taileObjects[taileObjects.Count-1].transform.position;
        taileObjects.Add(Instantiate(tailPrefab, newTailPos, Quaternion.identity));
    }

    public void DeleteTail(int indx)
    {
        if (indx <= taileObjects.Count)
        {
            taileObjects = taileObjects.GetRange(0, indx);
            taileObjects[indx - 1].GetComponent<TailMovement>().isMoving = true;
            score = taileObjects.Count;
        }
    }
}
