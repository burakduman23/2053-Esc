using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpinController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rend.transform.Rotate(new Vector3(0,0,speed)* Time.deltaTime);

        if(GameController.gameState == GameController.GameState.LEVEL6)
        {
                      
                rend.transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
            
        }

    }
}
