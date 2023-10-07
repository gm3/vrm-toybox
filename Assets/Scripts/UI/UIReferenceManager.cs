using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIReferenceManager : MonoBehaviour
{
    public GameObject playerRef;
    public PlayerHealthBar playerHealthBarReference;
    public GameObject scoreKeepingObect;
    public Scorekeeping scoreKeepingRef;
    public TextMeshProUGUI scoreUItext;
    public TextMeshProUGUI healthUItext;
    public GameObject uiMenu;
    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
        {

                // get a reference to the player and healthbar script
                playerRef = GameObject.Find("Player"); // Find the "_Scorekeeping" gameObject
                
                if (playerRef != null)
                {
                    playerHealthBarReference = playerRef.GetComponent<PlayerHealthBar>(); // Get the script from the "_Scorekeeping" gameObject
                }

                // get a reference to the Scorekeeping object and script
                scoreKeepingObect = GameObject.Find("_Scorekeeping"); // Find the "_Scorekeeping" gameObject
                
                if (scoreKeepingObect != null)
                {
                    scoreKeepingRef = scoreKeepingObect.GetComponent<Scorekeeping>(); // Get the script from the "_Scorekeeping" gameObject
                }
        
        
        }

    // Update is called once per frame
    void Update()
    {
       UpdateUI();

      

        // Check for the ` key press
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            // Toggle the active state of the GameObject
            uiMenu.SetActive(!uiMenu.activeSelf);
            TogglePauseGame();
        }




    }

    void UpdateUI()
    {
        UpdateHealthUI();
        UpdateScoreUI();
    }

    void UpdateHealthUI()
    {
        healthUItext.text = playerHealthBarReference.currentHealth.ToString();
    }

    void UpdateScoreUI()
    {
        scoreUItext.text = scoreKeepingRef.score.ToString();
    }

    void TogglePauseGame()
    {
        if (isGamePaused)
        {
            //cursor lock and state
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ThirdPersonOrbitCamBasic.Instance.enabled = true;
            // If the game is paused, unpause it
            AudioListener.volume = 0;
            Time.timeScale = 1;
            
            uiMenu.SetActive(false);
        }
        else
        {
            //cursor lock and state
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            ThirdPersonOrbitCamBasic.Instance.enabled = false;
            // If the game is running, pause it
            AudioListener.volume = 1;
            Time.timeScale = 0;
            
            uiMenu.SetActive(true);
        }

        // Toggle the state
        isGamePaused = !isGamePaused;
    }
}
