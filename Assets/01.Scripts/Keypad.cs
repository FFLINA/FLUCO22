using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour {

    //List<string> stringNumbers = new List<string>();
    //List<string> correctNumbers = new List<string>() { "1", "0", "1", "7" };

    public Text textMonitor;
    string computerCorrectNumbers;
    string doorCorrectNumbers;
    bool correctCheck = false;
    string myname;


    // Start is called before the first frame update
    void Start() {
        computerCorrectNumbers = "1012";
        doorCorrectNumbers = "0916";
        myname = transform.name;
    }

    // Update is called once per frame
    void Update() {

    }
    internal void InputNumber(string childname) {
        switch (childname) {
            case "keypad_0":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "0";
                }
                break;
            case "keypad_1":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "1";
                }
                break;
            case "keypad_2":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "2";
                }
                break;
            case "keypad_3":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "3";
                }
                break;
            case "keypad_4":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "4";
                }
                break;
            case "keypad_5":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "5";
                }
                break;
            case "keypad_6":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "6";
                }
                break;
            case "keypad_7":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "7";
                }
                break;
            case "keypad_8":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "8";
                }
                break;
            case "keypad_9":
                if (textMonitor.text.Length < 9 & correctCheck == false) {
                    textMonitor.text += "9";
                }
                break;

            case "keypad_clear":
                //clear는 그냥 다 지우고
                if (correctCheck == false) {
                    textMonitor.text = "";
                }
                break;
            case "keypad_enter":
                //내 이름에 Computer, Door중 어떤게 포함되어있는지 비교
                if (myname.Contains("Computer")) {
                    //enter는 정답과 값을 비교한다음
                    if (textMonitor.text == computerCorrectNumbers & correctCheck == false) {
                        //정답사운드를 내고 맞았다고 표시
                        //Resource~~~~
                        textMonitor.text = "정답";
                        print("Computer 정답");
                        PuzzleManager.Instance.room2_computerKeypadCheck = true;
                        correctCheck = true;
                    }
                    else {
                        //오답이면 오답사운드를 내고 지움
                        //Resource~~~
                        textMonitor.text = "";
                    }
                }
                if (myname.Contains("Door")) {
                    //enter는 정답과 값을 비교한다음
                    if (textMonitor.text == doorCorrectNumbers & correctCheck == false) {
                        //정답사운드를 내고 맞았다고 표시
                        //Resource~~~~
                        textMonitor.text = "정답";
                        print("Door 정답");
                        PuzzleManager.Instance.room2_doorKeypadCheck = true;
                        correctCheck = true;
                    }
                    else {
                        //오답이면 오답사운드를 내고 지움
                        //Resource~~~
                        textMonitor.text = "";
                    }
                }



                break;

            default:
                break;
        }


    }
}
