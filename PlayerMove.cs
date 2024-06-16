using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float mouseSpeed = 8f;
    private float gravity;
    GameObject chair1;
    GameObject chair2;
    GameObject sofa1;
    GameObject textMash;
    public GameObject Man;
    private CharacterController controller;
    private Vector3 mov;
    public bool interactive = false;
    public bool activative = false;
    bool didPlayerSit;
    private float mouseY = 0f;
    public int activeCounter;
    private float mouseX;
    public bool mouseLock;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        activeCounter = 0;
        chair1 = GameObject.Find("Chair");
        chair2 = GameObject.Find("Chair2");
        sofa1 = GameObject.Find("sofa");
        controller = GetComponent<CharacterController>();
        Man = GameObject.Find("Man");
        mov = Vector3.zero;
        mouseLock = false;
        gravity = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        interactiveOn();

        if (playerSit() == true)
        {
            return;
        }
        if (playerSleep() == true)
        {
            return;
        }
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -50f, 30f);

        this.transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);


        if (controller.isGrounded)
        {
            mov = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            mov = controller.transform.TransformDirection(mov);
            
        }
        else
        {
            mov.y -= gravity * Time.deltaTime;
        }

        controller.Move(mov * Time.deltaTime * speed);

        howManyInteract();






    }
    public void OnTriggerStay(Collider other)
    {
       
        if (other.transform.tag == "Object")
        {

            Debug.Log("Ãæµ¹Áß");
            activative = true;
           
        }
    }
    public void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "Object")
        {

            Debug.Log("ºüÁ®³ª¿È");
            activative = false;
           

        }
    }
    void interactiveOn()
    {
        if (activative == true)
        {
            GameObject.Find("Canvas").transform.Find("textMash").gameObject.SetActive(true);
            if (interactive == false)
            {


                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactive = true;
                    if (interactive == true)
                    {
                        activeCounter++;
                        Debug.Log("´©·²¤¶À½");
                    }

                }
                return;
            }
            if (interactive == true)
            {


                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactive = false;
                    if (interactive == false)
                    {
                        Debug.Log("²¯À½");
                    }

                }
                return;
            }
        }
        else if (activative == false)
        {
            GameObject.Find("Canvas").transform.Find("textMash").gameObject.SetActive(false);
            return;
        }
    }

    bool playerSit()
    {
        
        if (chair1.GetComponent<chair>().sit == true ) return true;
        if (chair2.GetComponent<chair2>().sit == true) return true;
        mouseLock = true;
        return false;
    }
    bool playerSleep()
    {

        if (sofa1.GetComponent<sofa>().sit == true) return true;
        mouseLock = true;
        return false;
    }
    void howManyInteract()
    {
       
        if (activeCounter == 10)
        {
            GameObject.Find("everyBoss").transform.Find("every").gameObject.SetActive(true);
        }
        else if (activeCounter == 20)
        {
            GameObject.Find("everyBoss").transform.Find("every").gameObject.SetActive(false);
        }
        else if (activeCounter == 30)
        {
            GameObject.Find("man").transform.Find("Man").gameObject.SetActive(true);
           
        }
        return;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Finish")
        {
            Debug.Log("µÇ±²¤µÀ½");
            GameObject.Find("man").transform.Find("Man").gameObject.SetActive(false);
            GameObject.Find("wall").transform.Find("door").gameObject.SetActive(false);
            GameObject.Find("lightsBoss").transform.Find("lights").gameObject.SetActive(true);

        }

    }
}
