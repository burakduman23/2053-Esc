using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WLController : MonoBehaviour
{
    public Text winLossText;
    // Start is called before the first frame update
    void Start()
    {
        winLossText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        WLText();
    }

    public void WLText()
    {
        if (GameController.gameState == GameController.GameState.WIN)
        {
            winLossText.text = "You have Escaped!";
        }
        if (GameController.gameState == GameController.GameState.LOSE)
        {
            winLossText.text = "You are not worthy!";
        }
    }

    public void Restart() {
        GameController.key1 = false;
        GameController.key2 = false;
        GameController.key3 = false;
        GameController.key4 = false;
        GameController.key5 = false;
        GameController.key6 = false;
        GameController.gameState = GameController.GameState.LEVEL0;
        CameraController.zoomed1 = false;
        CameraController.zoomed2 = false;
        CameraController.zoomed3 = false;
        SceneManager.LoadScene("EntranceLevel");
    }
}
