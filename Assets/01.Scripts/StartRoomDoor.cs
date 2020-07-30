using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

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
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -100f), Time.deltaTime * 0.5f);
            transform.position = Vector3.Lerp(transform.position, Vector3.down * 5f, Time.deltaTime * 0.5f);
        }
    }

    bool keyTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Key"))
        {
            AudioManager.Instance.PlayEffect(EffectClipsEnum.SFX_KeyUsing);
            Invoke("DoorOpen", 1f);
        }
    }

    void DoorOpen()
    {
        keyTrigger = true;
        AudioManager.Instance.PlayEffect(EffectClipsEnum.SFX_DoorOpen);
        warp.SetActive(true);
    }
}
