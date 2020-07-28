using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pet : MonoBehaviour
{

    /** 펫은 플레이어의 자식으로 있다
     * 
     * 
     * 펫이 목적지가 있으면 목적지로 이동
         * 마우스가 클릭되면 펫이 자신 위치에서 클릭된 좌표의 방향으로 레이를 쏨
         * 닿은 놈이 아이템이라면
         * 아이템의 포지션을 목적지로 저장, 이동, 아이템과 닿았다면 그 아이템을 자신의 자식으로
         * (아이템과 닿았다면) 그 후 다시 원래 펫의 포지션으로 이동
         */

    // 펫은 대기 상태일 때 위아래로 둥둥 떠있다
    // 플레이어가 부르면 플레이어 좌상단에 위치한 petPosition 에 온다
    // 플레이어가 움직여도 따라 움직이지 않고 제자리에 떠있다
    // 펫한테 명령을 내리면 아이템을 가져오고 갱신된 petPosition에 놓고 대기
    //


    // BUG : 펫이 벽을 뚫고 이동하는 버그

    public float speed = 3f;
    Vector3 direction;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moving = false;
    }
    bool moving;
    bool returning;
    Vector3 destination;

    public Transform petPosition;
    float changeTime;

    float idlePositionTime = 5f;
    float idleTempTime;
    // Update is called once per frame
    void Update()
    {
        // 펫의 목적지가 없으면
        if (moving == false)
        {
            idleTempTime += Time.deltaTime;
            if(idleTempTime >= idlePositionTime)
            {
                rb.velocity = Vector3.zero;
                // 일정시간이 되면 자기 위치로 감
                destination = petPosition.position; // 목적지
                direction = destination - transform.position; // 방향
                moving = true;
                returning = true;
                idleTempTime = 0;
            }
            // 대기상태
            // 제자리에서 위아래로 둥둥 떠 있다
            transform.Translate(Vector3.up * Time.deltaTime * changeTime);
        }
        else
        {
            rb.velocity = Vector3.zero;
            transform.position += direction * speed * Time.deltaTime;
            // 목적지를 향해 날라가고 있다
            // 날라가다가 목표 아이템과 온콜리더엔터가 되면
            // 온콜리더 엔터 함수 안에서 아이템을 자신의 자식으로 만들고
            // dest 와 dir 를 petPosition 로 설정
            if (returning == true)
            {
                // 돌아 올 때 펫 포지션의 위치를 계속해서 업데이트
                // 왜나면 장애물에 부딪쳐서 방향이 틀어졌어도 다시 돌아올 수 있게
                destination = petPosition.transform.position;
                direction = destination - transform.position;
                //목적지와의 거리
                print("달려");
                float distance = Vector3.Distance(transform.position, petPosition.transform.position);
                if (distance <= 0.3f)
                {
                    print("멈춰");
                    moving = false;
                    returning = false;
                    if(selectedItem != null)
                    {
                        selectedItem.transform.parent = selectedItem.GetComponent<Item>().originParent;
                        selectedItem.transform.GetComponent<Rigidbody>().useGravity = true;
                        selectedItem.transform.GetComponent<Item>().IsGrabed = false;
                    }
                }
            }
            else
            {
                // 아이템을 향해 가고 있을 때 아이템의 위치를 계속해서 업데이트 한다
                destination = selectedItem.transform.position;
                direction = destination - transform.position;
            }

        }
    }

    private void OnCollisionEnter(Collision item)
    {//닿은 아이템들은 자식으로 만들고 싶다.\
        if (item.gameObject == selectedItem)
        {
            if(moving == true)
            {
                print("컴온");
                selectedItem.transform.parent = transform;
                selectedItem.transform.GetComponent<Rigidbody>().useGravity = false;
                selectedItem.transform.GetComponent<Item>().IsGrabed = true;

                // 복귀하고싶다 - 펫포지션을 목적지로
                destination = petPosition.position; // 목적지
                direction = destination - transform.position; // 방향
                returning = true;
            }
        }

    }

    GameObject selectedItem;
    // 이 함수가 플레이어에 의해 불리면
    // 전달받은 게임오브젝트(아이템)을 향해 이동, 그립, 복귀한다
    internal void GoToItem(GameObject item)
    {
        selectedItem = item;

        destination = item.transform.position; // 목적지
        direction = destination - transform.position; // 방향
        moving = true;
    }
}


