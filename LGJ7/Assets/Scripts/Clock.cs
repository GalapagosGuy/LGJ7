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
            if ((int)time % 60 == 0)
                fillImage.color = new Color(154.0f, 17, 0, 255.0f);
            if ((int)time % 75 == 0)
                fillImage.color = new Color(58.0f, 125.0f, 51.0f, 255.0f);
            fillImage.fillAmount = value;
            yield return null;
        }


    }
}
