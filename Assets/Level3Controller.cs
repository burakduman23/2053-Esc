using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{
    public GameObject key3;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.key3)
        {
            Destroy(key3.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
