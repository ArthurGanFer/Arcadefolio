using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeManager : MonoBehaviour
{
    private CameraController cameraController;
    public Transform focusPoint;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FocusCamera()
    {
        cameraController.ChangeCameraPos(focusPoint);
    }

    public void ExitFocus()
    {
        cameraController.AttachToPlayer();
    }

    public void OpenGame()
    {
        //SceneManager.LoadScene(arcadeGame.ToString());
    }

}
