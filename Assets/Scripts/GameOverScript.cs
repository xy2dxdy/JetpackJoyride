using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Начать сначала!"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "Назад в меню")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
