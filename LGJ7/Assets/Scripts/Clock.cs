using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private float dayTime;
    [SerializeField]
    private Image fillImage;

    private void Start()
    {
        fillImage.fillAmount = 1f;
        StartCoroutine(Timer(dayTime));
       
    }
    public IEnumerator Timer(float dayTime)
    {
        float startTime = Time.time;
        float time = dayTime;

        float value = 0;

        while(Time.time - startTime < dayTime)
        {
            time -= Time.deltaTime;
            value = time / dayTime;
            fillImage.fillAmount = value;
            yield return null;
        }


    }
}
