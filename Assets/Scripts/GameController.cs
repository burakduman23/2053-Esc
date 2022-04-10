using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static bool key1, key2, key3, key4, key5, key6;
    public static int lastDirection;
    
    public enum GameState { MENU, LEVEL0, LEVEL1, LEVEL2, LEVEL3, LEVEL4, LEVEL5, LEVEL6, LOSE, WIN };

    public static GameState gameState = GameController.GameState.MENU;
    public static GameState previousgameState = GameController.GameState.MENU;

    public Text title;

    // Start is called before the first frame update
    void Start()
    {

        title = GameObject.Find("Title").GetComponent<Text>();
        if (title != null)
        {
            if (gameState == GameController.GameState.MENU)
                title.text = "ESCAPE!";
        }
        lastDirection = 2;

       
    }

    public void StartGame()
    {
        gameState = GameController.GameState.LEVEL0;
        SceneManager.LoadScene("EntranceLevel");
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
