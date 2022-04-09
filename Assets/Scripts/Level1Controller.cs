using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public GameObject key1;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.key1)
        {
            Destroy(key1.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
