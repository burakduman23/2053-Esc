using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitDoorController : MonoBehaviour
{
    private string input;
    AudioSource audio;
    public UIControl uic;
    public Text cText;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        uic.Hide();
        cText.text = "Enter Code"; 
        
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
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("WLRScene");
            
        }

        else
        {
            cText.text = "Try Again";
        }
    }
}
