using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    [SerializeField] ParticleSystem _WaterBallParticleSystem;
    [SerializeField] AnimationCurve _SpeedCurve;
    [SerializeField] float _Speed;
    [SerializeField] ParticleSystem _SplashPrefab;
    [SerializeField] ParticleSystem _SpillPrefab;
    public void Throw(Vector3 target)
    {
        StopAllCoroutines();
        StartCoroutine(Coroutine_Throw(target));
    }

    IEnumerator Coroutine_Throw(Vector3 target) 
    {
        float lerp = 0;
        Vector3 startPos = transform.position;
        while (lerp < 1)
        {
            transform.position = Vector3.Lerp(startPos, target, _SpeedCurve.Evaluate(lerp));
            float magnitude = (transform.position - target).magnitude;
            if (magnitude < 0.4f)
            {
                break;
            }
            lerp += Time.deltaTime * _Speed;
            yield return null;
        }
        _WaterBallParticleSystem.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        ParticleSystem splas = Instantiate(_SplashPrefab, target, Quaternion.identity);
        Vector3 forward = target - startPos;
        forward.y = 0;
        splas.transform.forward = forward;
        if (Vector3.Angle(startPos - target, Vector3.up) > 30)
        {
            ParticleSystem spill = Instantiate(_SpillPrefab, target, Quaternion.identity);
            spill.transform.forward = forward;
        }
        Destroy(gameObject, 0.5f);
    }
}
