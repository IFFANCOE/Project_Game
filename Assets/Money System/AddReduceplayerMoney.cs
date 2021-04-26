using System.Collections;
using UnityEngine;

public class AddReduceplayerMoney : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       //รับอินพุตเมื่อคลิกซ้าย
        if(Input.GetButtonDown ("Fire1")) {
            
            cam.GetComponent <playerMoney> ().addMoney (5);
        }
    }
}
