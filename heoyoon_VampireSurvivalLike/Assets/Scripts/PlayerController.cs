using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;                 //�̵� �ӵ�
    public float rotationSpeed;             //ȸ�� �ӵ�

    Animator anim;


    private void Awake()
    {
        instance = this;                    //�������ڸ��� �ν��Ͻ�
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = PlayerStatContoller.nstance.moveSpeed[0].value; //TODO : ���߿� �ڵ�
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        //�̵� ���� ���͸� ������� ȸ�� ������ ���
        if(moveInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInput);

            //ȸ���� �ε巴�� �����ϱ� ���� Slerp�� ���

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed*Time.deltaTime);
        }
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if(moveInput != Vector3.zero) 
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);

        }
    }
}
