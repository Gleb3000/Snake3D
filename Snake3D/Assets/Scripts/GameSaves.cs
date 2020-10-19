using UnityEngine;

public class GameSaves : MonoBehaviour
{
    public void PPrefs()
    {
        #region PlayerPrefs.Set***

        int bestScore = 0;
        PlayerPrefs.SetInt("Best Score", bestScore);

        #endregion  
    }
}
