using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class streetLight : MonoBehaviour
{
    bool playeIn = false;
    GameObject player;
    [SerializeField] private Light PointLight;
    [SerializeField] private Light SpotLight;
    bool didLightOn = false;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playeIn == true)
        {
            
                if (player.GetComponent<PlayerMove>().interactive == true)
                {
                    PointLight.intensity = 3;
                    SpotLight.intensity = 3;
                    didLightOn = true;

                }          
                if (player.GetComponent<PlayerMove>().interactive == false)
                {
                    this.PointLight.intensity = 0;
                    this.SpotLight.intensity = 0;
                    didLightOn = false;

                }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playeIn = true;
            
        }
  
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playeIn = false;

        }


    }
}
