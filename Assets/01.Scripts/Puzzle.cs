using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    Vector3 startPosition;
    Rigidbody rb;
    //부모가 기존 CuttingPuzzle에서 다른걸로 바뀌면 퍼즐이 맞다는거니까 더이상 바꿀필요가 없으므로 체크
    string parentName;

    // Start is called before the first frame update
    void Start() {
        //시작하자마자 현재 나의 위치를 기록, Update에서 계속 체크
        startPosition = transform.position;
        rb = transform.GetComponent<Rigidbody>();
        //checkParent의 이름을 체크
        parentName = transform.parent.name;

    }

    // Update is called once per frame
    void Update() {
        //위치가 바뀌는 순간 Rigidbody에 Gravity를 적용
        if (startPosition != transform.position) {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        //if(parentName != "CuttingPuzzle") {
        //    rb.useGravity = false;
        //    rb.isKinematic = true;
        //}

    }
}
