using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CatchCollider : MonoBehaviour {

    //cuttingImage의 자식이 없으면 퍼즐이 완료된걸로 판단, 맞는위치가 아니면 다시 cuttingImage한테 자식으로 돌려주기위한 용도
    public GameObject Cutting_Image;
    public SteamVR_Input_Sources any;
    //public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    public SteamVR_Action_Boolean trigger;

    string myName;
    string urName = "x";
    bool rightPiece;
    GameObject puzzlePices;
    //맞으면 맞았다고 이펙트 알려주는거, 사운드로 교체할수도있음 우선 비활성화
    //public GameObject collectFactory;
    int collectCheck = 0;

    // Start is called before the first frame update
    void Start() {
        //내 오브젝트 이름과 맞닿은 오브젝트 이름을 비교하기 위한 용도
        myName = gameObject.name;
        any = SteamVR_Input_Sources.Any;
        trigger = SteamVR_Actions.default_Trigger;
    }

    // Update is called once per frame
    void Update() {
        //print(rightPiece);

        //if (rightPiece) {
        //누르는중이 아니고 위치에 맞는 조각이면
        if (trigger.GetStateUp(any) && rightPiece) {
            puzzlePices.transform.GetComponent<Rigidbody>().isKinematic = true;
            puzzlePices.transform.GetComponent<Rigidbody>().useGravity = false;
            puzzlePices.transform.parent = transform;
            puzzlePices.transform.localPosition = new Vector3(0.0f, 0.0f, -0.3f);
            puzzlePices.transform.localRotation = Quaternion.Euler(Vector3.zero);
            puzzlePices.transform.localScale = new Vector3(1.08f, 1.47f, 0.41f);
            if (collectCheck == 1) {
                collectCheck = 2;
                //맞으면 맞았다고 이펙트 알려주는거, 사운드로 교체할수도있음 우선 비활성화
                //GameObject collect = Instantiate(collectFactory);
                //collect.transform.position = transform.position;
                //Destroy(collect, 0.25f);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        //닿은 오브젝트의 레이어가 Layer 11(PUZZLE) 이면
        if (other.gameObject.layer == 11) {
            urName = other.gameObject.name;
            //닿은 오브젝트의 이름에 나의 이름이 포함되어 있으면 ex) cube_puzzle5와 puzzle5는 o, cube_puzzle2와 puzzle1은 x
            if (urName.Contains(myName)) {
                puzzlePices = other.gameObject;
                rightPiece = true;
                collectCheck = 1;
            }
            else {
                puzzlePices = null;
                rightPiece = false;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        puzzlePices = null;
        urName = "x";
        rightPiece = false;
        other.transform.parent = Cutting_Image.transform;
        //other.transform.parent = transform;
    }
}
