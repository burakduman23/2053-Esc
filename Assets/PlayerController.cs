using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Vector3 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed = 4.0f;
   
  //  public Sprite leftStart;
    
    

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        


        if(GameController.previousgameState == GameController.GameState.LEVEL2 && GameController.gameState == GameController.GameState.LEVEL1)
        {
            rend.transform.position = new Vector2(-6.57f, -4.1f);
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL3 && GameController.gameState == GameController.GameState.LEVEL0)
        {
            rend.transform.position = new Vector2(7.35f, -0.97f);
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL4 && GameController.gameState == GameController.GameState.LEVEL3)
        {
            rend.transform.position = new Vector2(7.19f, -4.06f);
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL6 && GameController.gameState == GameController.GameState.LEVEL5)
        {
            rend.transform.position = new Vector2(7.34f, 0.8f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(.025f, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(.97f, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, .75f, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, -.025f, dist)).y;

        //get the width of the object
        float width = rend.bounds.size.x;
        float height = rend.bounds.size.y;
        velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
     

        //make sure the obect is inside the borders
        if ((transform.position.x <= leftBorder + width / 2.0) && velocity.x < 0f)
        {
            velocity = new Vector3(0f, 0f, 0f);
        }
        if ((transform.position.x >= rightBorder - width / 2.0) && velocity.x > 0f)
        {
            velocity = new Vector3(0f, 0f, 0f);
        }
        if ((transform.position.y <= bottomBorder + height / 2.0) && velocity.y < 0f)
        {
            velocity = new Vector3(0f, 0f, 0f);
        }
        if ((transform.position.y >= topBorder + height / 2.0) && velocity.y > 0f)
        {
            velocity = new Vector3(0f, 0f, 0f);
        }

       

        if (velocity.x > 0)
        {
            GameController.lastDirection = 2;
            anim.Play("WalkRight");

        }
        else if (velocity.x < 0)
        {
            GameController.lastDirection = 1;
            anim.Play("WalkLeft");

        }
        else if ((velocity.y > 0 || velocity.y < 0) && GameController.lastDirection == 2)
        {
            anim.Play("WalkRight");
        }
        else if ((velocity.y > 0 || velocity.y < 0) && GameController.lastDirection == 1)
        {
            anim.Play("WalkLeft");

        }
        else
        {
            if (GameController.lastDirection != 2)
            {
                anim.Play("IdleLeft");
            }
            else
            {
                anim.Play("Idle");
            }
        }
        transform.Translate(velocity * Time.deltaTime * speed);
            

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door1") && GameController.gameState == GameController.GameState.LEVEL1)
        {
            SceneManager.LoadScene("EntranceLevel");
            SceneManager.UnloadSceneAsync("LEVEL1");
            GameController.gameState = GameController.GameState.LEVEL0;
            GameController.previousgameState = GameController.GameState.LEVEL1;
        }
        else if (other.CompareTag("Door1") && GameController.gameState == GameController.GameState.LEVEL0)
        {
            SceneManager.LoadScene("Level1");
            SceneManager.UnloadSceneAsync("EntranceLevel");
            GameController.gameState = GameController.GameState.LEVEL1;
            GameController.previousgameState = GameController.GameState.LEVEL0;
        }

        if (other.CompareTag("Door3") && GameController.gameState == GameController.GameState.LEVEL3)
        {
            GameController.gameState = GameController.GameState.LEVEL0;
            SceneManager.LoadScene("EntranceLevel");
            SceneManager.UnloadSceneAsync("Level3");
            GameController.previousgameState = GameController.GameState.LEVEL3;
        }
        else if (other.CompareTag("Door3") && GameController.gameState == GameController.GameState.LEVEL0 )
        {
            SceneManager.LoadScene("Level3");
            SceneManager.UnloadSceneAsync("EntranceLevel");
            GameController.gameState = GameController.GameState.LEVEL3;
            GameController.previousgameState = GameController.GameState.LEVEL0;
        }

        if (other.CompareTag("Door2") && GameController.gameState == GameController.GameState.LEVEL1 && GameController.key1)
        {
            SceneManager.LoadScene("Level2");
            SceneManager.UnloadSceneAsync("Level1");
            GameController.gameState = GameController.GameState.LEVEL2;
            GameController.previousgameState = GameController.GameState.LEVEL1;
        }
        else if (other.CompareTag("Door2") && GameController.gameState == GameController.GameState.LEVEL2)
        {
            SceneManager.LoadScene("Level1");
            SceneManager.UnloadSceneAsync("Level2");
            GameController.gameState = GameController.GameState.LEVEL1;
            GameController.previousgameState = GameController.GameState.LEVEL2;

        }

        if (other.CompareTag("Door4") && GameController.gameState == GameController.GameState.LEVEL3 && GameController.key3)
        {
            SceneManager.LoadScene("Level4");
            SceneManager.UnloadSceneAsync("Level3");
            GameController.gameState = GameController.GameState.LEVEL4;
            GameController.previousgameState = GameController.GameState.LEVEL3;
        }
        else if (other.CompareTag("Door4") && GameController.gameState == GameController.GameState.LEVEL4)
        {
            SceneManager.LoadScene("Level3");
            SceneManager.UnloadSceneAsync("Level4");
            GameController.gameState = GameController.GameState.LEVEL3;
            GameController.previousgameState = GameController.GameState.LEVEL4;

        }

        if (other.CompareTag("Door5") && GameController.gameState == GameController.GameState.LEVEL0 )
        {
            SceneManager.LoadScene("Level5");
            SceneManager.UnloadSceneAsync("EntranceLevel");
            GameController.gameState = GameController.GameState.LEVEL5;
            GameController.previousgameState = GameController.GameState.LEVEL0;
        }
        else if (other.CompareTag("Door5") && GameController.gameState == GameController.GameState.LEVEL5)
        {
            SceneManager.LoadScene("EntranceLevel");
            SceneManager.UnloadSceneAsync("Level5");
            GameController.gameState = GameController.GameState.LEVEL0;
            GameController.previousgameState = GameController.GameState.LEVEL5;

        }

        if (other.CompareTag("Door6") && GameController.gameState == GameController.GameState.LEVEL5)
        {
            SceneManager.LoadScene("Level6");
            SceneManager.UnloadSceneAsync("Level5");
            GameController.gameState = GameController.GameState.LEVEL6;
            GameController.previousgameState = GameController.GameState.LEVEL5;
        }
        else if (other.CompareTag("Door6") && GameController.gameState == GameController.GameState.LEVEL6)
        {
            SceneManager.LoadScene("Level5");
            SceneManager.UnloadSceneAsync("Level6");
            GameController.gameState = GameController.GameState.LEVEL5;
            GameController.previousgameState = GameController.GameState.LEVEL6;

        }

        if (other.CompareTag("Fire"))
        {
            Destroy(gameObject);
            GameController.gameState = GameController.GameState.LOSE;
        }
        if (other.CompareTag("Trap"))
        {
            Destroy(gameObject);
            GameController.gameState = GameController.GameState.LOSE;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(other.gameObject);
                if(GameController.gameState == GameController.GameState.LEVEL1)
                    GameController.key1 = true;
                if (GameController.gameState == GameController.GameState.LEVEL2)
                    GameController.key2 = true;
                if (GameController.gameState == GameController.GameState.LEVEL3)
                    GameController.key3 = true;
                if (GameController.gameState == GameController.GameState.LEVEL4)
                    GameController.key4 = true;
                if (GameController.gameState == GameController.GameState.LEVEL5)
                    GameController.key5 = true;
                if (GameController.gameState == GameController.GameState.LEVEL6)
                    GameController.key6 = true;
            }
        }
    }

}
