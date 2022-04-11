using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Controller : MonoBehaviour
{
    public GameObject key5;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.key5)
        {
            Destroy(key5.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
