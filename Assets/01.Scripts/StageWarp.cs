using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageWarp : MonoBehaviour {
    int roomNumber;
    string myname;
    // Start is called before the first frame update
    void Start() {
        myname = transform.name;
        roomNumber = GameManager.Instance.roomNumberCheck;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
            if (myname.Contains("Next")) {
                print(roomNumber+"에서넘어간다");
                GameManager.Instance.StageChange(++roomNumber);
            }
            if (myname.Contains("Prev")) {
                print(roomNumber+"에서돌아간다");
                GameManager.Instance.StageChange(--roomNumber);
            }

        }
    }
}
