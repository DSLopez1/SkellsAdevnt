using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Menues")]
    private GameObject _menuActive;
    public GameObject pauseMenu;

    [Header("Player Components")] 

    public GameObject player;
    public PlayerMovement playerMovementScript;
    public PlayerAttack playerAttackScript;

    private bool _isPaused;


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
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            StatePaused();
            _menuActive = pauseMenu;
            _menuActive.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
        {
            StateUnpaused();
        }
    }

    public void StatePaused()
    {
        _isPaused = !_isPaused;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StateUnpaused()
    {
        _isPaused = !_isPaused;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _menuActive.SetActive(false);
        _menuActive = null;
    }

}
