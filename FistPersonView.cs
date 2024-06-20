using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiarstPerosnView : MonoBehaviour
{
    [SerializeField] private float mouseSpeed = 8f; //ȸ���ӵ�
    private float mouseX = 0f; //�¿� ȸ������ ���� ����
    private float mouseY = 0f; //���Ʒ� ȸ������ ���� ����
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMove>().mouseLock == true) return;
        
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseY += Input.GetAxis("Mouse Y") * mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -50f, 30f);

        this.transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}