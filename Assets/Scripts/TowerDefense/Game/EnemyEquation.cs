using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities.LevelEquationManager;
using TMPro;
    public class Equation : MonoBehaviour{
        public List<int> numbers = new List<int>();
        public List<string> operations = new List<string>();
        public string fullEq;
        public int result; 
    }
public class EnemyEquation : MonoBehaviour
{


    // Start is called before the first frame update
    public Equation equation;
    public TMP_Text textlabel;
   // public LevelEquationManager instance;

     public int startingEquationDifficulty = 3;
        public int startingOperations = 4;
        public int startingNumbersForEquations = 2;
        public int equationDifficulty;
        public int operationsForEquation;
        public int operationsAvailable;
        public int numbersForEquation;
    void Awake ()
    {
        numbersForEquation = startingNumbersForEquations;
        operationsForEquation = numbersForEquation-1;
        equationDifficulty = startingEquationDifficulty;
    } 

    public Equation GenerateEquation(){
        if(!textlabel){
            textlabel = GetComponentInChildren<TMP_Text>();
        }
        Equation eq = new Equation();
        for(int i = 0; i<numbersForEquation;i++ ){
            eq.numbers.Add(Random.Range(2, equationDifficulty));
        }
        eq.fullEq = eq.numbers[0].ToString();
        
        for(int i = 0; i<operationsForEquation;i++ ){
            eq.operations.Add(Signal(operationsAvailable));
            eq.fullEq+=" " + eq.operations[i].ToString() + " " + eq.numbers[i+1].ToString();
            switch(eq.operations[i]){
                case "-":
                    eq.result = eq.numbers[0] - eq.numbers[1];
                break;
                case "X": 
                    eq.result = eq.numbers[0] * eq.numbers[1];
                break;
                case "/": 
                    if(eq.numbers[0] > eq.numbers[1]){
                    eq.result = eq.numbers[0] / eq.numbers[1];
                    }else{
                        eq.result = eq.numbers[1] / eq.numbers[0];
                        eq.fullEq=eq.numbers[1].ToString() + eq.operations[i].ToString() + " " + eq.numbers[0].ToString();
                    }
                break;
                default:
                    eq.result = eq.numbers[0] + eq.numbers[1];
                break;
            }
        }

        textlabel.text = eq.fullEq;
        equation = eq;
        return eq;
    }


    string Signal (int sign){
        if(sign == 5){
            sign = Random.Range(0,3);
        }
        switch (sign){
            case 1: return "-";
            case 2: return "X";
            case 3: return "/";
            default: return "+";
        }
    }
}
