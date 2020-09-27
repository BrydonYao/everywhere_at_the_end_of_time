using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_isGrounded : MonoBehaviour
{
    public bool isGrounded;

    void OnTriggerStay2D(Collider2D other){
        //print("grounded rn");
        isGrounded = true;
    }

    void OnTriggerExit2D(){
        isGrounded = false;
    }
}
