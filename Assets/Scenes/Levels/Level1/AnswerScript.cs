using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Utilities.LevelEquationManager;
using TowerDefense.Towers.Projectiles;
using ActionGameFramework.Health;
using TowerDefense.Agents;
using Core.Health;

public class AnswerScript : MonoBehaviour
{
    public InputField answer;
    public Button button;
    public GameObject waveContainer;
    void Start()
    {
        Button btn = GetComponentInChildren<Button>();
        answer = GetComponentInChildren<InputField>();
		btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick(){
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
            Debug.Log("errou");
        }else{
            Debug.Log("acertou pelo menos 1, faz alguma coisa");
        }
        answer.text = "";
    }

    bool validateAnswer(Transform go){
        Equation eq = go.GetComponent<EnemyEquation>().equation;
        Debug.Log(eq.result);
        if(int.Parse(answer.text) == eq.result){
            Debug.Log("morreu");
            Vector3 ponto = new Vector3(0,0,0);
            
            go.gameObject.GetComponent<AttackingAgent>().TakeDamage(100.0f, ponto, go.gameObject.GetComponent<Damager>().alignmentProvider);
            
            return true;
        }
        return false;
    }
}