using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private ArcadeManager arcadeManager;
    private float playerSpeed = 5;
    public bool onArcadeRange;
    private float InputX;
    private float InputZ;
    private bool cameraOnPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraOnPlayer)
        {
            InputX = Input.GetAxis("Horizontal");
            InputZ = Input.GetAxis("Vertical");
            Interact();
        } else
        {
            InputX = 0;
            InputZ = 0;
            ExitArcade();
            ConfirmGame();
        }
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector3 move = new Vector3(InputX, 0, InputZ);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && onArcadeRange)
        {
            cameraOnPlayer = false;
            arcadeManager.FocusCamera();
        }
    }

    void ConfirmGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            arcadeManager.OpenGame();
        }
    }

    void ExitArcade()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            ExitButton();
        }
    }

    public void ExitButton()
    {
        Debug.Log("Exit Button");
        arcadeManager.ExitFocus();
        cameraOnPlayer = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ArcadeManager>() != null)
        {
            arcadeManager = other.gameObject.GetComponent<ArcadeManager>();
            onArcadeRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ArcadeManager>() != null)
        {
            onArcadeRange = false;
            arcadeManager = null;
        }
    }

}
