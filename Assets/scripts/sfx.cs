using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfx : MonoBehaviour
{
    [Header("audio")]
    public AudioSource AudioSource;
    public AudioClip explosion;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !AudioSource.isPlaying) 
        {
            AudioSource.PlayOneShot(explosion);
        }
    }
}
