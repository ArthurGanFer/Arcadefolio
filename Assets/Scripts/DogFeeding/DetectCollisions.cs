using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private DogFeedingManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<DogFeedingManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bone") && gameManager.GetGameActive())
        {
            gameManager.AddScore(1);
            gameManager.AddLife(1);
            gameManager.gameAudio.PlayOneShot(gameManager.scoreAudio);
        }
        Destroy(gameObject);
        Destroy(other.gameObject);
    }


}
