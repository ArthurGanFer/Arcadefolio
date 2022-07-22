using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DogFeedingManager : MonoBehaviour
{
    private bool isGameActive = false;
    private int lifes = 5;
    private int score;
    private float spawnRate = 1.5f;
    private SpawnManager spawnManager;

    public TextMeshProUGUI gameTitle;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI scoreText;
    private int difficulty = 0;//0 = easy; 1 = medium; 2 = hard
    public GameObject exitButton;

    public AudioSource gameAudio;
    public AudioClip btnHover;
    public AudioClip scoreAudio;
    public AudioClip lifeLoss;
    public AudioSource backgroundMusic;

    public GameObject[] lifeUi;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        UpdateLifeUI();
        exitButton = GameObject.Find("ExitButton");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(int difficulty)
    {
        AddScore(0);
        this.difficulty = difficulty;
        SetGameStatus(true);
        StartCoroutine(SpawnTargets());
        gameTitle.gameObject.SetActive(false);
        exitButton.SetActive(false);
        backgroundMusic.Play(0);
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }

    public void AddLife(int lifes)
    {
        this.lifes += lifes;
        if (this.lifes < 0)
        {
            this.lifes = -1;
            GameOver();
        }
        if (this.lifes > 5)
            this.lifes = 5;

        UpdateLifeUI();
    }

    private void UpdateLifeUI()
    {
        for (int i = 0; i < lifeUi.Length; i++)
        {
            lifeUi[i].gameObject.SetActive(i <= lifes);
        }
    }

    public void GameOver()
    {
        SetGameStatus(false);
        gameOver.gameObject.SetActive(true);
        backgroundMusic.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate / (difficulty+1));
            spawnManager.SpawnRandomDog();
        }
    }

    public void SetGameStatus(bool gameStatus)
    {
        isGameActive = gameStatus;
    }

    public bool GetGameActive()
    {
        return isGameActive;
    }

    public void ExitToArcade()
    {
        SceneManager.LoadScene("Arcade");
    }

}
