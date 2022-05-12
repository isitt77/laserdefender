using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitExplosion;

    [SerializeField] bool doCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;


    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            PlayHitEffect();
            damageDealer.DiedByCollision();
        }
    }

    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if(hitExplosion != null)
        {
            ParticleSystem instance = Instantiate(hitExplosion, transform.position, Quaternion.identity);
            //Destroys instance of particle system after the duration of effect.
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && doCameraShake)
        {
            cameraShake.PlayShake();
        }
    }

}
