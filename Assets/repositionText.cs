using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repositionText : MonoBehaviour
{
    void Update()
    {
         //Vector3 look =new Vector3(-140,+90,(go.transform.rotation.z+270));
        //this.transform.LookAt(go.transform,look);
        //this.transform.LookAt(
        //    new Vector3(-go.transform.position.x+90, go.transform.position.y-30, -go.transform.position.z+120)
        //    );
        this.transform.LookAt(this.transform.position - (Camera.main.transform.position - this.transform.position));
    }
}
