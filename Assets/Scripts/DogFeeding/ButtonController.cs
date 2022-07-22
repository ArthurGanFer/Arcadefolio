using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource gameAudio;
    public AudioClip hoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameAudio.PlayOneShot(hoverAudio);
    }
}
