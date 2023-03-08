using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [2의 보수]
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
    //  움직이는 속도
    private float Speed;
    private Vector3 Movement;

    private Animator animator;
    private SpriteRenderer playerRenderer;

    private bool onAttack;
    private bool onHit;
    private bool onRoll;
    private bool onJump;
    private bool onDive;
    private float Direction;

    public GameObject BulletPrefab;

    private List<GameObject> Bullets = new List<GameObject>();

    //  유니티 기본 제공 함수
    //  초기값을 설정할 때 사용
    void Start()
    {
        //  속도를 초기화.
        Speed = 5.0f;

        //  player 의 Animator를 받아온다.
        animator = this.GetComponent<Animator>();
        playerRenderer = this.GetComponent<SpriteRenderer>();

        onAttack = false;

        onHit = false;

        onRoll = false;

        onJump = false;

        onDive = false;

        Direction = 1.0f;
    }

    //  유니티 기본 제공 함수
    //  프레임마다 반복적으로 실행되는 함수.
    void Update()
    {
        //  [실수 연산 IEEE754]

        // **  Input.GetAxis =     -1 ~ 1 사이의 값을 반환함. 
        float Hor = Input.GetAxisRaw("Horizontal"); // -1 or 0 or 1 셋중에 하나를 반환.

        if (Hor != 0)
            Direction = Hor;

        if(Direction < 0)
        {
            playerRenderer.flipX = true;
        }
        else if (Direction > 0)
        {
            playerRenderer.flipX = false;
        }

        playerRenderer.flipX = (Hor < 0) ? true : false;

        Movement = new Vector3(
            Hor * Time.deltaTime * Speed,
            0.0f,
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject Obj = Instantiate(BulletPrefab);
            //Obj.transform.name = "";
            Obj.transform.position = transform.position;
            BulletController controller = Obj.AddComponent<BulletController>();

            controller.Direction = new Vector3(Direction, 0.0f, 0.0f) ;
            SpriteRenderer bulletRenderer = Obj.GetComponent<SpriteRenderer>();
            bulletRenderer.flipY = playerRenderer.flipX;


            Bullets.Add(Obj);
        }

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

