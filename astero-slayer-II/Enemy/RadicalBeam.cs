using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadicalBeam : MonoBehaviour
{   
    AudioSource audioSource;
    public AudioClip beamClip;
    private float beamDuration = 3.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(BeamStopper());
        audioSource.PlayOneShot(beamClip);
    }

    IEnumerator BeamStopper()
    {
        yield return new WaitForSeconds(beamDuration);
        Destroy(this.gameObject);
    }
}
