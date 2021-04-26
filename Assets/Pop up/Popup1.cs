using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Popup1 : MonoBehaviour
{

    public GameObject Image;
    
     void OnTriggerEnter(Collider other) {
        
            Image.SetActive(true);
        
    }
      void OnTriggerExit(Collider other) {
         Image.SetActive(false);
     }

     
}
