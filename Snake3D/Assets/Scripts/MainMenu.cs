using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("Best Score").ToString();
    }
}
