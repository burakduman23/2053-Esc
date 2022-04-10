using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Controller : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (!GameController.key2))
        {
            audio.Play();
        }
    }
}
