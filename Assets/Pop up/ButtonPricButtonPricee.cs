using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonPricButtonPricee : MonoBehaviour
{
    public GameObject After_610_Baht;
    public GameObject Question;
    
    bool active;
    public void ButtonPricee610(){
        if(active == false){
            
             After_610_Baht.SetActive(true); //After_610_Baht.transform.gameObject.SetActive(true);
            Question.transform.gameObject.SetActive(false);
            active = true;
        }
        else
        {
            After_610_Baht.transform.gameObject.SetActive(true);
             active = false;
             Question.transform.gameObject.SetActive(true);

        }
    }
    public void ButtonPricee890(){

    }
    public void ButtonPricee1120(){

    }

}
