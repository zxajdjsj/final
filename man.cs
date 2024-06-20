using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class man : MonoBehaviour
{
    bool alive = false;
    GameObject Man;


    // Start is called before the first frame update
    void Start()
    {
      
        Man = GameObject.Find("Man");
        Man.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            Debug.Log("µÇ±²¤µÀ½");
            Man.SetActive(false);
           
        }

    }
   
}
