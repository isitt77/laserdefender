using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifeTime = 1f;
    [SerializeField] float fireRate = 0.2f;

    Coroutine firingCoroutine;
    public bool isFiring;

    void Start()
    {
        
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
            }

            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
