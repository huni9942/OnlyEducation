using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [2�� ����]
// 0 0000000 
//    0 0000001 = 1
// - 0 0000010 = 2
//--------------
// 1 - 2 = 1 + (-2)
// 1 + (-2)

//    0 0000001 = 1
// + 11111110 = (-2)
//--------------
//    11111111 = (-1)
//    00000001 = 1


// 0 0000100 = 4
// 0 0001000 = 8
// 0 0010000 = 16
// 0 0100000 = 32
// 0 1000000 = 64
// 1 1111111 =  128


public class PlayerController : MonoBehaviour
{
    //  �����̴� �ӵ�
    private float Speed;
    private Vector3 Movement;

    private Animator animator;

    private bool onAttack;
    private bool onHit;
    private bool onRoll;
    private bool onJump;
    private bool onDive;


    //  ����Ƽ �⺻ ���� �Լ�
    //  �ʱⰪ�� ������ �� ���
    void Start()
    {
        //  �ӵ��� �ʱ�ȭ.
        Speed = 5.0f;

        //  player �� Animator�� �޾ƿ´�.
        animator = this.GetComponent<Animator>();

        onAttack = false;

        onHit = false;

        onRoll = false;

        onJump = false;

        onDive = false;
    }

    //  ����Ƽ �⺻ ���� �Լ�
    //  �����Ӹ��� �ݺ������� ����Ǵ� �Լ�.
    void Update()
    {
        //  [�Ǽ� ���� IEEE754]

        // **  Input.GetAxis =     -1 ~ 1 ������ ���� ��ȯ��. 
        float Hor = Input.GetAxisRaw("Horizontal"); // -1 or 0 or 1 ���߿� �ϳ��� ��ȯ.
        float Ver = Input.GetAxis("Vertical"); // -1 ~ 1 ���� �Ǽ��� ��ȯ.

        Movement = new Vector3(
            Hor * Time.deltaTime * Speed,
            Ver * Time.deltaTime * Speed,
            0.0f);

        if (Input.GetKey(KeyCode.LeftControl))
            OnAttack();

        if (Input.GetKey(KeyCode.LeftShift))
            OnHit();

        if (Input.GetKey(KeyCode.RightShift))
            OnRoll();

        if (Input.GetKey(KeyCode.Space))
            OnJump();

        if (Input.GetKey(KeyCode.LeftAlt))
            OnDive();

        animator.SetFloat("Speed", Hor);
        transform.position += Movement;
    }


    private void OnAttack()
    {
        if (onAttack)
            return;

        onAttack = true;
        animator.SetTrigger("Attack");
    }

    private void SetAttack()
    {
        onAttack = false;
    }


    private void OnHit()
    {
        if (onHit)
            return;

        onHit = true;
        animator.SetTrigger("Hit");
    }

    private void SetHit()
    {
        onHit = false;
    }


    private void OnRoll()
    {
        if (onRoll)
            return;

        onRoll = true;
        animator.SetTrigger("Roll");
    }


    private void SetRoll()
    {
        onRoll = false;
    }

    private void OnJump()
    {
        if (onJump)
            return;

        onJump = true;
        animator.SetTrigger("Jump");
    }


    private void SetJump()
    {
        onJump = false;
    }

    private void OnDive()
    {
        if (onDive)
            return;

        onJump = true;
        animator.SetTrigger("Dive");
    }


    private void SetDive()
    {
        onDive = false;
    }
}

