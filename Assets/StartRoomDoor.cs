using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        warp.SetActive(false);
    }

    public GameObject warp;
    // Update is called once per frame
    void Update()
    {
        if(keyTrigger)
        {
            // rotation 이 0에서 -120까지 lerp
            transform.rotation = Quaternion.Lerp(transform.rotation
                , Quaternion.Euler(0, 0, -100f)
                , Time.deltaTime * 0.5f);
        }
    }

    bool keyTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Key"))
        {
            keyTrigger = true;
            warp.SetActive(true);
        }
    }
}
