using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArcadeManager : MonoBehaviour
{
    private CameraController cameraController;
    public Transform focusPoint;
    public TextMeshProUGUI confirmText;
    public GameObject exitArcadeButton;
    public GameObject arcadeOn;
    public GameObject tooltip;
    public AudioClip interactionSound;
    public AudioSource mainAudio;

    public enum ArcadeGame
    {
        DogFeeding,
        CountryRunner,
        SkyDomeRoll,
        FoodSplash
    }
    public ArcadeGame arcadeGame;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        mainAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FocusCamera()
    {
        cameraController.ChangeCameraPos(focusPoint);
        StartCoroutine(ShowConfirmScreen());
    }

    public void ExitFocus()
    {
        cameraController.AttachToPlayer();
        exitArcadeButton.SetActive(false);
        confirmText.gameObject.SetActive(false);
    }

    public void OpenGame()
    {
        SceneManager.LoadScene(arcadeGame.ToString());
    }

    IEnumerator ShowConfirmScreen()
    {
        yield return new WaitForSeconds(2);
        if (!cameraController.attachedToPlayer)
        {
            exitArcadeButton.SetActive(true);
            confirmText.text = "Press Enter to play " + arcadeGame;
            confirmText.gameObject.SetActive(true);
        }
    }

}
