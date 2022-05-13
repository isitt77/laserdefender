using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool isPlayer;
    [SerializeField] int pointValue;
    [SerializeField] ParticleSystem hitExplosion;

    [SerializeField] bool doCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    ScoreKeeper scoreKeeper;


    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
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


    public int GetHealth()
    {
        return health;
    }


    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if(health <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        if (!isPlayer)
        {
            scoreKeeper.UpdateScore(pointValue);
        }
        Destroy(gameObject);
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
