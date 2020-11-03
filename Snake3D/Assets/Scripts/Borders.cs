using UnityEngine;
using UnityEngine.UI;

public class Borders : MonoBehaviour
{
    public GameObject panel;
    public Text recordText;
    private SnakeMovement snake;

    void Start()
    {
        panel.SetActive(false);
        recordText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SnakeMovement>() != null)
        {
            Time.timeScale = 0;
            snake = other.gameObject.GetComponent<SnakeMovement>();
            panel.SetActive(true);

            if (snake.score > PlayerPrefs.GetInt("Best Score"))
            {
                recordText.enabled = true;
                PlayerPrefs.SetInt("Best Score",snake.score);
            }
        }        
 
    }
   
}
