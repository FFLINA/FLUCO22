using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, (transform.localScale.y / 2), 0);
    }
    // 카메라 포지션 - 자신의 y스케일의 1/2
    // Update is called once per frame
    void Update()
    {
        
        transform.position = Camera.main.transform.position - offset;
    }
}
