using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class sofa : MonoBehaviour
{
    bool playerIn = false;
    public bool sit = false;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (playerIn == true)
        {

            if (player.GetComponent<PlayerMove>().interactive == true)
            {
                player.transform.position = new Vector3((float)3.099, (float)3.328, (float)17.573);
                player.transform.rotation = Quaternion.Euler((float)-5.667, (float)234.768, (float)-88.321);
                sit = true;
            }
            if (player.GetComponent<PlayerMove>().interactive == false)
            {
                sit = false;
                return;
                
                

            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerIn = true;

        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerIn = false;

        }


    }
}
