using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPos;
    float shakeTime = 0f;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void Shake(float duration)
    {
        shakeTime = duration;
    }

    void Update()
    {
        if (shakeTime > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * 0.05f;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPos;
        }
    }
}