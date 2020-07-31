using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_Button : MonoBehaviour {
    string myname;
    // Start is called before the first frame update
    void Start() {
        myname = transform.name;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision other) {
    }

    private void OnTriggerEnter(Collider other) {
        //print("OnTriggerEnter ");
        if (other.transform.CompareTag("Hand")) {

            transform.parent.GetComponent<Keypad>().InputNumber(myname);

           // print("myname : " + myname);
        }

    }
}
