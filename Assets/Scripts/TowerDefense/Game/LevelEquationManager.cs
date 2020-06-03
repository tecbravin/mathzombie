using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Utilities.LevelEquationManager
{

    public class Equation : MonoBehaviour{
        public List<int> numbers = new List<int>();
        public List<string> operations = new List<string>();
        public string fullEq;
        public int result; 
    }

    public class LevelEquationManager: Singleton<LevelEquationManager>
    {
        // Start is called before the first frame update
        public int startingEquationDifficulty = 3;
        public int startingOperations = 4;
        public int startingNumbersForEquations = 2;
        public int equationDifficulty;
        public int operationsForEquation;
        public int operationsAvailable;
        public int numbersForEquation;      

        void Start()
        {
            operationsForEquation = numbersForEquation-1;
            equationDifficulty = startingEquationDifficulty * 10;
            operationsAvailable = startingOperations;
            numbersForEquation = startingNumbersForEquations;
            //eq = GenerateEquation(numbersForEquation, operationsForEquation,equationDifficulty, eq);   
        }

        public Equation CallEquation()
        {           
            Equation eq = GenerateEquation(numbersForEquation, operationsForEquation, equationDifficulty);
            return eq;
        }

        protected Equation GenerateEquation(int numbersForEquation, int operationsForEquation, int eqDifficulty){
            Equation equation = new Equation();
            for(int i = 0; i<numbersForEquation;i++ ){
                equation.numbers.Add(Random.Range(2, eqDifficulty));
                //Debug.Log(equation.numbers[i]);
            }
            equation.fullEq = equation.numbers[0].ToString();
            
            for(int i = 0; i<operationsForEquation;i++ ){
                equation.operations.Add(Signal(Random.Range(0,operationsAvailable)));
                equation.fullEq+=" " + equation.operations[i].ToString() + " " + equation.numbers[i+1].ToString();
                switch(equation.operations[i]){
                    case "-": 
                        equation.result = equation.numbers[0] - equation.numbers[1];
                    break;
                    case "/": 
                        equation.result = equation.numbers[0] / equation.numbers[1];
                    break;
                        case "X": 
                        equation.result = equation.numbers[0] * equation.numbers[1];
                    break;
                    default:
                        equation.result = equation.numbers[0] + equation.numbers[1];
                    break;
                }
            }
            
            //Debug.Log((equation.fullEq));
            //Debug.Log((equation.result));
            return equation;
        }


        string Signal (int sign){
            switch (sign){
                case 1: return "-";
                case 2: return "X";
                case 3: return "/";
                default: return "+";
            }
        }
    }
}
