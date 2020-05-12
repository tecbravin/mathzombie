using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities.LevelEquationManager;

public class EnemyEquation : MonoBehaviour
{
    // Start is called before the first frame update
    public Equation equation;
    public TextMesh textlabel;
    void Start()
    {
       equation = LevelEquationManager.instance.CallEquation();
       textlabel = GetComponentInChildren<TextMesh>();
       textlabel.text = equation.fullEq;
    }
}
