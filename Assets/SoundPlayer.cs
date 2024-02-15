using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
