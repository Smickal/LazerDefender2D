using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int healthValue = 50;
    [SerializeField] ParticleSystem explosionFX;

    CameraShake cameraShake;
    [SerializeField] bool applyCameraShake;
    [SerializeField] float enemyScore = 50f;
    [SerializeField] bool isPlayer;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer)
        {
            TakeDamage(damageDealer.GetDamageValue());
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayExplosionSFX();
            damageDealer.Hit();
        }
    }

    void ShakeCamera()
    {
        if(applyCameraShake)
        {
            cameraShake.PlayCameraShake();
        }
    }

    void TakeDamage(int damageValue)
    {
        if (healthValue <= damageValue)
        {
            Destroy(gameObject);
            if(!isPlayer)
            {
                scoreKeeper.AddToCurrentScore(enemyScore);
            }
            else
            {
                levelManager.LoadGameOverScreen();
            }
        }
        else
        {
            healthValue -= damageValue;

        }
    }

    void PlayHitEffect()
    {
        if(explosionFX != null)
        {
            ParticleSystem instance = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    public int GetCurrentHP()
    {
        return healthValue;
    }
}
