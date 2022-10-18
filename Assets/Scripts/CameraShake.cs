using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;
    Vector3 initPos;
    private void Start()
    {
        initPos = transform.position;
    }

    public void PlayCameraShake()
    {
        StartCoroutine(ShakeCouroutine());
    }

    IEnumerator ShakeCouroutine()
    {
        for (float i = 0; i <= shakeDuration; i += Time.deltaTime)
        {
            transform.position = initPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        
        transform.position = initPos;
    }
}
