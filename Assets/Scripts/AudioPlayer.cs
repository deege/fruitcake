using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] AudioClip shooting;

    [Header("Spawning")]
    [SerializeField] AudioClip spawning;

    [Header("Health")]
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip dying;

    [Header("Controls")]
    [SerializeField] float volume = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayShotClip() {
        if (shooting != null) {
            AudioSource.PlayClipAtPoint(shooting, transform.position, volume * 0.55f);
        }
    }

    public void PlaySpawnClip() {
        if (spawning != null) {
            AudioSource.PlayClipAtPoint(spawning, transform.position, volume);
        }
    }

    public void PlayDeathClip() {
        if (dying != null) {
            AudioSource.PlayClipAtPoint(dying, transform.position, volume);
        }
    }

    public void PlayHitClip() {
        if (hit != null) {
            AudioSource.PlayClipAtPoint(hit, transform.position, volume);
        }
    }
}
