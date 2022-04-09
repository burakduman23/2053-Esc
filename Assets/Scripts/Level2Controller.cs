using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    public GameObject key2;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.key2)
        {
            Destroy(key2.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
