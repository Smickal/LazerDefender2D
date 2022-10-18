using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimunFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    Coroutine coroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    private void Start()
    {
        if (useAI) isFiring = true;
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && coroutine == null)
        {
             coroutine =  StartCoroutine(FireContinuously());
        }
        else if(!isFiring && coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject newProj =  Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D rb = newProj.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(newProj, projectileLifeTime);

            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimunFiringRate, float.MaxValue);

            audioPlayer.PlayShootingSFX();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

}
