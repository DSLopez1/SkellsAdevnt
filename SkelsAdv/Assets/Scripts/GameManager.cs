using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Menues")]
    public GameObject activeMenu;
    public GameObject pauseMenu;

    [Header("Player Components")] 

    public GameObject player;
    public PlayerMovement playerMovementScript;
    public PlayerAttack playerAttackScript;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        player = GameObject.FindWithTag("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        playerAttackScript = player.GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }

    //create a function that will pause the game
    public void PauseGame()
    {
        Time.timeScale = 0;
        activeMenu = pauseMenu;
        activeMenu.SetActive(true);
    }

    //create a function that will resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1;
        activeMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

}
