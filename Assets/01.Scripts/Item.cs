using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static AudioManager;

public class Item : MonoBehaviour
{
    internal Transform originParent;
    protected Rigidbody rb;

    public bool IsGrabed { get; internal set; }


    float dist;
    public void Shoot(Vector3 dir, float dist)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector3 distTest = dir * Mathf.Cos(angle);
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(distTest * 100f);
        rb.AddForce(dir * dist * 20f, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        originParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float power = transform.GetComponent<Rigidbody>().velocity.magnitude;
        if(power >= 0.1f)
        {
            print("power : " + power);
            // 이 아이템이 가지고 있는 재질 속성에 맞는
            // 충돌 사운드 플레이
            AudioManager.Instance.PlayEffect(EffectClipsEnum.SFX_ItemCollision, power);
        }
    }
}
