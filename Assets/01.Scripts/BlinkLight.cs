using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    // 포인트라이트 깜빡임
    // 켜져있다가 2~4회 랜덤으로 점등 을 반복

    public Light roomLight;

    // Start is called before the first frame update
    void Start()
    {
        roomLight.enabled = true;
        blinkTime = Random.Range(5f, 10f);
        blinkMaxCount = Random.Range(1, 3);
    }

    float blinkTime; // 한 세트를 실행할 시간
    int blinkMaxCount; // 한 세트에서 몇번 깜빡일지
    public float blinkInterval; // 한 깜빡임의 간격

    float curTimeLoop;
    float curTime;
    int count;
    // Update is called once per frame
    void Update()
    {
        curTimeLoop += Time.deltaTime;

        if (curTimeLoop >= blinkTime)
        {
            curTime += Time.deltaTime;
            if (curTime >= blinkInterval)
            {
                StartCoroutine(flashNow());
                count++;
                curTime = 0;
            }
            if (count >= blinkMaxCount)
            {
                curTimeLoop = 0;
                count = 0;
                blinkTime = Random.Range(3f, 5f);
                blinkMaxCount = Random.Range(4, 7);
            }
        }
    }



    public float totalSeconds;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach

    public IEnumerator flashNow()
    {
        float waitTime = blinkInterval / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)
        while (roomLight.intensity > 0)
        {
            roomLight.intensity -= Time.deltaTime / waitTime;        //Decrease intensity
            yield return null;
        }
        while (roomLight.intensity < maxIntensity)
        {
            roomLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
            yield return null;
        }
        yield return null;
    }
}
