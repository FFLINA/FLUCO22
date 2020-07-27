using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class Controller : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources rightHand;
    private SteamVR_Input_Sources leftHand;
    private SteamVR_Input_Sources any;
    private LineRenderer line;

    public SteamVR_Action_Boolean trigger;
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean grab;

    public float maxDistance = 30.0f;

    // 라인의 색상
    public Color color = Color.blue;
    public Color clickedColor = Color.red;

    public RaycastHit hit;
    private Transform tr;

    bool isTrigger;
    GameObject item;
    public GameObject TriggerPoint;
    Vector3 originPosition;
    float dist;
    Vector3 dir;

    public GameObject pet;
    // 화면을 어둡게 지속하는 시간
    public float fadeOutTime = 0.15f;

    public Transform cameraRigTransform;
    //public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;



    GameObject pointer;
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
    void Start()
    {
        //reticle = Instantiate(teleportReticlePrefab);
        //teleportReticleTransform = reticle.transform;
        
        trigger = SteamVR_Actions.default_Trigger;
        teleport = SteamVR_Actions.default_Teleport;
        grab = SteamVR_Actions.default_Grab;
        tr = GetComponent<Transform>();
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        if (pose != null)
        {
            any = pose.inputSource;
            rightHand = SteamVR_Input_Sources.RightHand;
            leftHand = SteamVR_Input_Sources.LeftHand;
        }

        CreateLineRenderer();

        // 프리팹을 Resources 폴더에서 로드해 동적으로 생성
        GameObject _pointer = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(_pointer);
        pointer.SetActive(false);
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
        line.startWidth = 0.03f;
        line.endWidth = 0.005f;

        // 라인의 머티리얼 및 색상 설정 
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            // 라인의 끝점의 위치를 레이캐스팅한 지점의 좌표로 변경
            line.SetPosition(1, new Vector3(0, 0, hit.distance));

            if (teleport.GetStateDown(any))
            {
                pointer.SetActive(true);
            }
            else if (teleport.GetState(any))
            {
                line.enabled = true;
                pointer.transform.position = hit.point + (hit.normal * 0.01f);
                pointer.transform.rotation = Quaternion.LookRotation(hit.normal);
            }
            else if (teleport.GetStateUp(any))
            {
                line.enabled = false;
                pointer.SetActive(false);
                if (hit.transform.gameObject.layer == 8) //ground
                {
                    SteamVR_Fade.Start(Color.black, 0);
                    StartCoroutine(this.Teleport(hit.point));
                }
            }
            else if (hit.transform.CompareTag("Item"))
            {
                item = hit.transform.gameObject;
                // 왼손 트리거 - 펫한테 아이템가져오라고 명령
                if (trigger.GetStateDown(leftHand))
                {
                    line.enabled = true;
                }
                else if (trigger.GetStateUp(leftHand))
                {
                    print("펫 작동");
                    line.enabled = false;
                    pet.transform.GetComponent<Pet>().GoToItem(hit.transform.gameObject);
                }
                else if (trigger.GetState(rightHand)) // 오른손 트리거 - 직접 아이템을 끌어 옴
                {
                    line.enabled = true;
                    item.transform.position = Vector3.Lerp(item.transform.position, transform.position, Time.deltaTime * 2);
                    dist = Vector3.Distance(item.transform.position, TriggerPoint.transform.position);
                    if (dist <= 1.5f)
                    {
                        item.transform.position = TriggerPoint.transform.position;
                        isTrigger = true;
                        item.GetComponent<Item>().IsGrabed = true;
                    }
                }
            }
        }
        if (isTrigger == true)
        {
            TriggerItem();
        }

    }
    float currentTime;
    float savePositionTime = 0.2f;
    Vector3 savedPosition;
    private void TriggerItem()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= savePositionTime)
        {
            savedPosition = item.transform.position;
            currentTime = 0;
        }
        // trigger을 뗀 순간 현재 위치-저장된 위치
        if (trigger.GetStateUp(rightHand))
        {
            line.enabled = false;
            float dist = Vector3.Distance(savedPosition, item.transform.position);
            dir = item.transform.position - savedPosition;
            print("dir : " + dir);
            print("dist : " + dist);
            item.GetComponent<Item>().Shoot(dir, dist);
            item.GetComponent<Item>().IsGrabed = false;
            isTrigger = false;
        }
    }
}
