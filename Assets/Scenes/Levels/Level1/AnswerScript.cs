using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Utilities.LevelEquationManager;
using TowerDefense.Towers.Projectiles;
using ActionGameFramework.Health;
using TowerDefense.Agents;
using Core.Health;
using UnityInput = UnityEngine.Input;
using UnityEngine.EventSystems;

public class AnswerScript : MonoBehaviour
{
    public InputField answer;
    public Button button;
    public GameObject waveContainer;
    private TouchScreenKeyboard keyboard;
    void Start()
    {
        Button btn = GetComponentInChildren<Button>();
        answer = GetComponentInChildren<InputField>();
		btn.onClick.AddListener(EvaluateAnswer);
        SetSelected(answer.gameObject);
    }

    void EvaluateAnswer(){
        GetActiveChildren(waveContainer);
	}

    void GetActiveChildren(GameObject go){
        bool hit = false;
        int score = 0;
        Transform[] allChildren = go.transform.GetComponentsInChildren<Transform>();
        for(int i = 0; i < allChildren.Length; i++){
            if(allChildren[i].GetComponent(typeof(EnemyEquation))){
                hit = validateAnswer(allChildren[i]);
            }
            if(hit){
                score++;
            }
        }
        if (score == 0){
            //Debug.Log("errou");
        }else{
            //Debug.Log("acertou pelo menos 1, faz alguma coisa");
        }
        answer.text = "";
        SetSelected(answer.gameObject);
        SetSelected(answer.gameObject);
    }

    bool validateAnswer(Transform go){
        Equation eq = go.GetComponent<EnemyEquation>().equation;
        if(int.Parse(answer.text) == eq.result){
            Vector3 ponto = new Vector3(0,0,0);
            if(go.gameObject.GetComponent<AttackingAgent>()){
                go.gameObject.GetComponent<AttackingAgent>().TakeDamage(100.0f, ponto, go.gameObject.GetComponent<Damager>().alignmentProvider);
            }else{
                go.gameObject.GetComponent<FlyingAgent>().TakeDamage(100.0f, ponto, go.gameObject.GetComponent<Damager>().alignmentProvider);
            }
            return true;
        }
        return false;
    }

    protected void Update(){
        if(Application.isMobilePlatform){
            if(keyboard == null){
            SetSelected(answer.gameObject);
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad, false, false, true);
            }
            return;
        }
		if (UnityInput.GetKeyDown(KeyCode.Return)  || UnityInput.GetKeyDown("enter")){
            EvaluateAnswer();      
		}

        if (UnityInput.GetKeyDown("space")){
            SetSelected(answer.gameObject);
		}

        if( EventSystem.current.currentSelectedGameObject != answer.gameObject){
            if(UnityInput.GetKeyDown("1") || UnityInput.GetKeyDown(KeyCode.Keypad1)){
                answer.text+="1";
            }else if(UnityInput.GetKeyDown("2") || UnityInput.GetKeyDown(KeyCode.Keypad2)){
                answer.text+="2";
            }else if(UnityInput.GetKeyDown("3") || UnityInput.GetKeyDown(KeyCode.Keypad3)){
                answer.text+="3";
            }else if(UnityInput.GetKeyDown("4") || UnityInput.GetKeyDown(KeyCode.Keypad4)){
                answer.text+="4";
            }else if(UnityInput.GetKeyDown("5") || UnityInput.GetKeyDown(KeyCode.Keypad5)){
                answer.text+="5";
            }else if(UnityInput.GetKeyDown("6") || UnityInput.GetKeyDown(KeyCode.Keypad6)){
                answer.text+="6";
            }else if(UnityInput.GetKeyDown("7") || UnityInput.GetKeyDown(KeyCode.Keypad7)){
                answer.text+="7";
            }else if(UnityInput.GetKeyDown("8") || UnityInput.GetKeyDown(KeyCode.Keypad8)){
                answer.text+="8";
            }else if(UnityInput.GetKeyDown("9") || UnityInput.GetKeyDown(KeyCode.Keypad9)){
                answer.text+="9";
            }else if(UnityInput.GetKeyDown("0") || UnityInput.GetKeyDown(KeyCode.Keypad0)){
                answer.text+="0";
            }
            SetSelected(answer.gameObject);
        }
	}

     private void SetSelected(GameObject go)
    {
        //Select the GameObject.
        EventSystem.current.SetSelectedGameObject(go);

        //If we are using the keyboard right now, that's all we need to do.
        var standaloneInputModule = EventSystem.current.currentInputModule as StandaloneInputModule;
        if (standaloneInputModule != null && standaloneInputModule.inputMode == StandaloneInputModule.InputMode.Buttons)
            return;

        //Since we are using a pointer device, we don't want anything selected. 
        //But if the user switches to the keyboard, we want to start the navigation from the provided game object.
        //So here we set the current Selected to null, so the provided gameObject becomes the Last Selected in the EventSystem.
        EventSystem.current.SetSelectedGameObject(null);
    }

}