using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerpot : MonoBehaviour
{
    // StartRoom Item
    // 하단의 Collider는 감지 안함
    // 상단의 Trigger만 오브젝트 감지
    // 꽃병은 이름이 Syringe인 오브젝트만 체크
    // Syringe와 닿을 시 자기 자식인 꽃에게 신호를 보냄


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Sylinge")
        {
            GameObject sylinge = other.gameObject;
            sylinge.transform.GetComponent<Rigidbody>().isKinematic = true;
            sylinge.transform.GetComponent<Collider>().enabled = false;
            sylinge.transform.GetComponent<Item>().IsGrabed = false;
            sylinge.transform.parent = sylinge.transform.GetComponent<Item>().originParent;


            // 자신의 자식인 Flower한테 신호를 보냄
            GameObject flower = transform.Find("Flower").gameObject;
            flower.transform.GetComponent<Flower>().Blossom();
        }
    }
}
