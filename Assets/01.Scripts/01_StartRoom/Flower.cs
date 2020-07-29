using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    /// <summary>
    /// 부모인 FlowerPot한테서 신호를 받아
    /// 그래픽 연출 실행, 자신의 상단부에 열쇠를 생성
    /// </summary>
    /// 
    public GameObject firstPuzzleKey;

    public void Blossom()
    {
        // 그래픽 연출
        transform.GetComponent<Renderer>().material.color = Color.red;

        Invoke("CreateKey", 2f);
        // 자신의 상단부에 키 생성
    }

    void CreateKey()
    {
        firstPuzzleKey.transform.position = transform.position + Vector3.up;
        //firstPuzzleKey.GetComponent<Rigidbody>().isKinematic = false;
        firstPuzzleKey.SetActive(true);
    }
}
