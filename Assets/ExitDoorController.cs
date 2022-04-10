using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorController : MonoBehaviour
{
    private string input;
    AudioSource audio;
    public UIControl uic;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        uic.Hide();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (!GameController.key6))
        {
            audio.Play();
        }
        else if (other.CompareTag("Player") && GameController.key6)
        {
            uic.Show();
        }
    }
    public void ReadInput(string password)
    {
        input = password;
        if(input == "952")
        {
            GameController.gameState = GameController.GameState.WIN;
            
        }
    }
}
