using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
}
