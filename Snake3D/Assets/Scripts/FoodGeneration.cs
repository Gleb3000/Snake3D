using UnityEngine;

public class FoodGeneration : MonoBehaviour
{
    private float xSize = 9f;
    private float zSize = 9f;

    public GameObject foodPrefab;
    public GameObject curFood;

    private Vector3 curPos;

    void RandomPos()
    {
        curPos = new Vector3(Random.Range(xSize*-1, xSize),0.25f, Random.Range(zSize * -1, zSize));
    }

    void AddNewFood()
    {
        RandomPos();
        curFood = Instantiate(foodPrefab, curPos, Quaternion.identity);
    }

    void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
    }
}
