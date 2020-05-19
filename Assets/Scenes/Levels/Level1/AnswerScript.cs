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
    void Start()
    {
        Button btn = GetComponentInChildren<Button>();
        answer = GetComponentInChildren<InputField>();
		btn.onClick.AddListener(EvaluateAnswer);
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
        Debug.Log(eq.result);
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
		if (UnityInput.GetKeyDown(KeyCode.Return)  || UnityInput.GetKeyDown("enter")){
            EvaluateAnswer();      
		}

        if (UnityInput.GetKeyDown("space")){
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