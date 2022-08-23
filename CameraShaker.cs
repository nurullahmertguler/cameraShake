using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] float duration = 1;

    public static CameraShaker Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(CameraShake());
        }
    }
    public void Shaker()
    {
        StartCoroutine(CameraShake());
    }

    IEnumerator CameraShake()
    {
        Vector3 startPos = transform.position;

        float elapsedTime=0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPos;
    }
}
