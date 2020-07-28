using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RightController : MonoBehaviour
{
    /// <summary>
    /// 텔레포트, 펫 명령, 아이템 그랩
    /// 텔레포트 - 트랙패드 위 아래 클릭
    /// 펫 명령 - 아이템 조준 그랩버튼
    /// 아이템 그랩 - 트리거 버튼
    /// </summary>
    /// 
    // Input
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources rightHand;
    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean grab;

    // 라인의 색상
    private LineRenderer line;
    public Color color = Color.blue;
    public Color clickedColor = Color.red;
    public float maxDistance = 30.0f;

    // Teleport
    public Transform cameraRigTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    GameObject pointer;

    // 화면을 어둡게 지속하는 시간
    public float fadeOutTime = 0.15f;

    // 속성
    public RaycastHit hitInfo;
    public GameObject pet;
    bool isTriggeredItem;
    GameObject triggeredItem;

    void Start()
    {
        trigger = SteamVR_Actions.default_Trigger;
        teleport = SteamVR_Actions.default_Teleport;
        grab = SteamVR_Actions.default_Grab;
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        if (pose != null)
        {
            rightHand = SteamVR_Input_Sources.RightHand;
        }

        CreateLineRenderer();

        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(_pointer);
        pointer.SetActive(false);

        line.enabled = false;
    }


    void Update()
    {
        if (isTriggeredItem)
        {
            TriggerButtonUpdate();
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hitInfo, maxDistance))
        {
            line.SetPosition(1, new Vector3(0, 0, hitInfo.distance));

            if (hitInfo.transform.gameObject.layer == 8) //ground
            {
                TeleportButtonUpdate();
            }
            else if (hitInfo.transform.CompareTag("Item"))
            {
                GrabButtonUpdate();
            }
        }
    }

    
    private void OnTriggerEnter(Collider item)
    {
        if (item.transform.CompareTag("Item"))
        {
            isTriggeredItem = true;
            triggeredItem = item.gameObject;
        }
        if(isTriggeredItem)
        {
            // 
        }
    }

    Transform itemOriginParent;
    float currentTime;
    float savePositionTime = 0.2f;
    Vector3 savedPosition;

    private void TriggerButtonUpdate()
    {
        if (trigger.GetStateDown(rightHand) && isTriggeredItem)
        {
            itemOriginParent = triggeredItem.transform.GetComponent<Item>().originParent;
            triggeredItem.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
            triggeredItem.transform.GetComponent<Rigidbody>().useGravity = false;
            triggeredItem.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            triggeredItem.transform.GetComponent<Item>().IsGrabed = true;
            triggeredItem.transform.parent = transform;

        }
        else if (trigger.GetState(rightHand) && isTriggeredItem)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= savePositionTime)
            {
                savedPosition = triggeredItem.transform.position;
                currentTime = 0;
            }
        }
        // trigger을 뗀 순간 현재 위치-저장된 위치
        else if (trigger.GetStateUp(rightHand) && isTriggeredItem)
        {
            float dist = Vector3.Distance(savedPosition, triggeredItem.transform.position);
            Vector3 dir = triggeredItem.transform.position - savedPosition;

            isTriggeredItem = false;
            triggeredItem.transform.parent = itemOriginParent;
            triggeredItem.GetComponent<Item>().IsGrabed = false;
            triggeredItem.transform.GetComponent<Rigidbody>().useGravity = true;
            triggeredItem.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            triggeredItem.GetComponent<Item>().Shoot(dir, dist);
        }
    }
    private void GrabButtonUpdate()
    {
        // 그랩버튼 - 펫한테 아이템가져오라고 명령
        if (grab.GetStateDown(rightHand))
        {
            line.enabled = true;
            line.material.color = clickedColor;
        }
        else if (grab.GetStateUp(rightHand))
        {
            line.enabled = false;
            line.material.color = color;
            print("펫 작동");
            pet.transform.GetComponent<Pet>().GoToItem(hitInfo.transform.gameObject);
        }
    }
    private void TeleportButtonUpdate()
    {
        if (teleport.GetStateDown(rightHand))
        {
            pointer.SetActive(true);
            line.enabled = true;
            line.material.color = clickedColor;
        }
        else if (teleport.GetState(rightHand))
        {
            pointer.transform.position = hitInfo.point + (hitInfo.normal * 0.01f);
            pointer.transform.rotation = Quaternion.LookRotation(hitInfo.normal);
        }
        else if (teleport.GetStateUp(rightHand))
        {
            line.enabled = false;
            line.material.color = color;
            pointer.SetActive(false);
            SteamVR_Fade.Start(Color.black, 0);
            StartCoroutine(this.Teleport(hitInfo.point));
        }
    }

    IEnumerator Teleport(Vector3 point)
    {
        // 포인터 위치로 순간 이동 
        //transform.parent.position = point;

        //shouldTeleport = false;
        //reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        cameraRigTransform.position = point + difference;


        yield return new WaitForSeconds(fadeOutTime);
        // 화면을 다시 밝게 변경 
        SteamVR_Fade.Start(Color.clear, 0.3f);
    }

    private void CreateLineRenderer()
    {
        // line Renderer 생성 
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;

        // 시작점과 끝점의 위치 설정
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));
        line.enabled = false;

        // 라인의 너비 설정
        line.startWidth = 0.01f;
        line.endWidth = 0.002f;

        // 라인의 머티리얼 및 색상 설정 
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

}
