using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [Range(0f,1f)][SerializeField] float shootingVolume = 1f;

    [Header("Damage Taken")]
    [SerializeField] AudioClip explosionClip;
    [Range(0, 1)] [SerializeField] float explosionVolume = 1f;

    static AudioPlayer instance;

    //public AudioPlayer GetInstance()
    //{
    //    return instance;
    //}

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void PlayShootingSFX()
    {
        if (shootingClip)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayExplosionSFX()
    {
        if(explosionClip)
        {
            AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position, explosionVolume);
        }
    }
}
