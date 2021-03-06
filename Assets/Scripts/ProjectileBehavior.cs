using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifeTime = 1f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireRateVariance = 0.5f;
    [SerializeField] float minFiringRate = 0.1f;
    [SerializeField] bool useAI;

    Coroutine firingCoroutine;
    [HideInInspector] public bool isFiring;

    AudioPlayer audioPlayer;



    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }


    void Update()
    {
        Fire();
    }


    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(NowFiring());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator NowFiring()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = instance.GetComponent<Rigidbody2D>();
            if(rb2d != null)
            {
                rb2d.velocity = -transform.up * projectileSpeed;
                audioPlayer.PlayShootingClip();
            }
            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(RandomizeFireRate());
        }
    }

    float RandomizeFireRate()
    {
        float randomRireRate = Random.Range(fireRate - fireRateVariance,
                                            fireRate + fireRateVariance);
        return Mathf.Clamp(randomRireRate, minFiringRate, float.MaxValue);
    }
}
