using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
