using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Vector3 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed = 4.0f;
    public AudioClip lockedDoor;
    //  public Sprite leftStart;
    
    public Text storyText;

    AudioSource  audio;

<<<<<<< Updated upstream
    private bool[] storyCompleted = new bool[17];

    // Start is called before the first frame update
    void Start()
    {

=======
    public Text storyText;
    private bool[] storyCompleted = new bool[17];


    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    { 
>>>>>>> Stashed changes

        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        audio = GetComponent<AudioSource>();

<<<<<<< Updated upstream
        for(int i = 0; i < storyCompleted.Length; i++)
=======
        for (int i = 0; i < storyCompleted.Length; i++)
>>>>>>> Stashed changes
        {
            storyCompleted[i] = false;
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL2 && GameController.gameState == GameController.GameState.LEVEL1)
        {
            rend.transform.position = new Vector2(-6.57f, -4.1f);
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL3 && GameController.gameState == GameController.GameState.LEVEL0)
        {
            rend.transform.position = new Vector2(7.35f, 1.921743f);
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL4 && GameController.gameState == GameController.GameState.LEVEL3)
        {
            rend.transform.position = new Vector2(7.19f, -4.06f);
        }

        if (GameController.previousgameState == GameController.GameState.LEVEL6 && GameController.gameState == GameController.GameState.LEVEL5)
        {
            rend.transform.position = new Vector2(7.34f, 0.8f);
        }
        if (GameController.previousgameState == GameController.GameState.LEVEL5 && GameController.gameState == GameController.GameState.LEVEL0)
        {
            rend.transform.position = new Vector2(7.53f, -3.4f);
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
        HandleStory();

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
        else if (other.CompareTag("Door3") && GameController.gameState == GameController.GameState.LEVEL0 && GameController.key2)
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

        if (other.CompareTag("Door4") && GameController.gameState == GameController.GameState.LEVEL3 && GameController.key5)
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

        if (other.CompareTag("Door5") && GameController.gameState == GameController.GameState.LEVEL0 && GameController.key3)
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

        if (other.CompareTag("Door6") && GameController.gameState == GameController.GameState.LEVEL5 && GameController.key4)
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

        if (other.CompareTag("Exit") && GameController.key6)
        {
            SceneManager.UnloadSceneAsync("Level1");
            GameController.gameState = GameController.GameState.WIN;
        }

/*        if (other.CompareTag("Fire") || other.CompareTag("Trap"))
        {
            Destroy(gameObject);
            GameController.gameState = GameController.GameState.LOSE;
        }*/
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
                audio.Play();
            }

        }

    }

<<<<<<< Updated upstream
        private void HandleStory() {
=======
    private void HandleStory()
    {
>>>>>>> Stashed changes
        if (storyText != null)
        {
            if (GameController.key1 == false)
            {
                if (!storyCompleted[0])
                {
                    storyText.text = "*You wake up in a strange room* \n (press 'SPACEBAR' to skip)";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[0] = true;
                    }
                }
                else if (storyCompleted[0] == true && !storyCompleted[1])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: HAHHA! You are finally awake.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[1] = true;
                    }
                }
                else if (storyCompleted[1] == true && !storyCompleted[2])
                {
                    storyText.color = Color.white;
                    storyText.text = "You: Where am I?";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[2] = true;
                    }
                }
                else if (storyCompleted[2] == true && !storyCompleted[3])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: You are in my dungeon. I kidnapped you!";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[3] = true;
                    }
                }
                else if (storyCompleted[3] == true && !storyCompleted[4])
                {
                    storyText.color = Color.white;
                    storyText.text = "You: Uhhh... Why did you kidnap me?";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[4] = true;
                    }
                }
                else if (storyCompleted[4] == true && !storyCompleted[5])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: I don't really know. The storyline is not that great.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[5] = true;
                    }
                }
                else if (storyCompleted[5] == true && !storyCompleted[6])
                {
                    storyText.text = "Voice: But I kidnapped you!!!";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[6] = true;
                    }
                }
                else if (storyCompleted[6] == true && !storyCompleted[7])
                {
                    storyText.color = Color.white;
                    storyText.text = "You: Okay, what do I do now?";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[7] = true;
                    }
                }
                else if (storyCompleted[7] == true && !storyCompleted[8])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: There are some keys and some locked doors around the dungeon. Go find them and open locked doors. And solve the dungeon's puzzle to leave";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[8] = true;
                    }
                }
                else if (storyCompleted[8] == true && !storyCompleted[9])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: So get going. Good luck.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[9] = true;
                        storyText.text = "";
                    }
                }

            }


<<<<<<< Updated upstream
            if (GameController.key1 == true && GameController.key2 == false) {
=======
            if (GameController.key1 == true && GameController.key2 == false)
            {
>>>>>>> Stashed changes

                if (!storyCompleted[9])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: Oh so you found a key? Keep up the hard work. You will be out soon. heheheh...";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[9] = true;
                    }
                }
                else if (storyCompleted[9] == true && !storyCompleted[10])
                {
                    storyText.color = Color.white;
                    storyText.text = "You: So is that all? And where are you? How do I hear you? There is nothing in this room.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[10] = true;
                    }
                }
                else if (storyCompleted[10] == true && !storyCompleted[11])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: Yeah, that's all. I told you the storyline wasn't good. ";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[11] = true;
                    }
                }
                else if (storyCompleted[11] == true && !storyCompleted[12])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: And devs couldn't find an asset for me so I am invisible. Stop talking and find some keys!";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[12] = true;
                        storyText.text = "";
                    }
                }

            }


<<<<<<< Updated upstream
            if (GameController.key2 == true && GameController.key3 == false) {
=======
            if (GameController.key2 == true && GameController.key3 == false)
            {
>>>>>>> Stashed changes

                if (!storyCompleted[13])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: Get the first clue? Don't forget it. It will help you solve the last puzzle.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[13] = true;
                    }
                }
                else if (storyCompleted[13] == true && !storyCompleted[14])
                {
                    storyText.color = Color.white;
                    storyText.text = "You: *silence* ";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[14] = true;
                        storyText.text = "";
                    }
                }
            }

<<<<<<< Updated upstream
            if (GameController.key4) {
=======
            if (GameController.key4)
            {
>>>>>>> Stashed changes
                if (!storyCompleted[15])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: You only have one left? Good job buddy.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[15] = true;
                        storyText.text = "";
                    }
                }
            }

            if (GameController.key6)
            {
                if (!storyCompleted[16])
                {
                    storyText.color = Color.red;
                    storyText.text = "Voice: Let's go! You got all the clues to get out of here now.";
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        storyCompleted[16] = true;
                        storyText.text = "";
                    }
                }
            }
        }
    }

}
