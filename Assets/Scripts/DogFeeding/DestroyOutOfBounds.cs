using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 40;
    public float lowerBound = -10;
    private DogFeedingManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<DogFeedingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // If projectile goes past boundaries
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //if dog goes past boundaries
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            gameManager.AddLife(-3);
            gameManager.gameAudio.PlayOneShot(gameManager.lifeLoss);
        }

        if (!gameManager.GetGameActive())
        {
            Destroy(gameObject);
        }
    }
}
