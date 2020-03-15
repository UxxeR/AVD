using CreatorKitCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float pitch;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("BulletAudio").GetComponent<AudioSource>();
        pitch = Random.Range(-300, 300) / 100;
        audioSource.pitch = pitch;
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            
        }
    }
}
