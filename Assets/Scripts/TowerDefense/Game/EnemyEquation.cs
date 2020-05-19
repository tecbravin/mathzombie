using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities.LevelEquationManager;

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
    public TextMesh textlabel;
   // public LevelEquationManager instance;

     public int startingEquationDifficulty = 3;
        public int startingOperations = 2;
        public int startingNumbersForEquations = 2;
        public int equationDifficulty;
        public int operationsForEquation;
        public int operationsAvailable;
        public int numbersForEquation;
      void Awake ()
  {
        numbersForEquation = startingNumbersForEquations;
        operationsForEquation = numbersForEquation-1;
        equationDifficulty = startingEquationDifficulty * 10;
        operationsAvailable = startingOperations;
        
      //if (instance == null) { instance = LevelEquationManager.instance; }
      equation = GenerateEquation(numbersForEquation, operationsForEquation, equationDifficulty);
  } 
    void Start()
    {

       
       textlabel = GetComponentInChildren<TextMesh>();
        textlabel.text = equation.fullEq;
    }

    protected Equation GenerateEquation(int numbersForEquation, int operationsForEquation, int eqDifficulty){
            Equation eq = new Equation();
            for(int i = 0; i<numbersForEquation;i++ ){
                eq.numbers.Add(Random.Range(2, eqDifficulty));
                //Debug.Log(equation.numbers[i]);
            }
            eq.fullEq = eq.numbers[0].ToString();
            
            for(int i = 0; i<operationsForEquation;i++ ){
                eq.operations.Add(Signal(Random.Range(0,operationsAvailable)));
                eq.fullEq+=" " + eq.operations[i].ToString() + " " + eq.numbers[i+1].ToString();
                switch(eq.operations[i]){
                    case "-": 
                        eq.result = eq.numbers[0] - eq.numbers[1];
                    break;
                    default:
                        eq.result = eq.numbers[0] + eq.numbers[1];
                    break;
                }
            }
            
            //Debug.Log((equation.fullEq));
            //Debug.Log((equation.result));
            return eq;
        }


        string Signal (int sign){
            switch (sign){
                case 1: return "-";
                case 2: return "*";
                case 3: return "/";
                default: return "+";
            }
        }
    
}
