using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
