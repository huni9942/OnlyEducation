using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //  �����̴� �ӵ�
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

    public bool DirLeft;
    public bool DirRight;

    public GameObject BulletPrefab;

    public GameObject fxPrefab;

    public GameObject[] stageBack = new GameObject[7];

    private List<GameObject> Bullets = new List<GameObject>();

    //  ����Ƽ �⺻ ���� �Լ�
    //  �ʱⰪ�� ������ �� ���
    void Start()
    {
        //  �ӵ��� �ʱ�ȭ.
        Speed = 5.0f;

        //  player �� Animator�� �޾ƿ´�.
        animator = this.GetComponent<Animator>();
        playerRenderer = this.GetComponent<SpriteRenderer>();

        onAttack = false;

        onHit = false;

        onRoll = false;

        onJump = false;

        onDive = false;

        Direction = 1.0f;


        for (int i = 0; i < 7; ++i)
            stageBack[i] = GameObject.Find(i.ToString());
    }

    //  ����Ƽ �⺻ ���� �Լ�
    //  �����Ӹ��� �ݺ������� ����Ǵ� �Լ�.
    void Update()
    {
        //  [�Ǽ� ���� IEEE754]

        // **  Input.GetAxis =     -1 ~ 1 ������ ���� ��ȯ��. 
        float Hor = Input.GetAxisRaw("Horizontal"); // -1 or 0 or 1 ���߿� �ϳ��� ��ȯ.

        if (Hor != 0)
            Direction = Hor;
        else
        {
            DirLeft = false;
            DirRight = false;
        }

        if(Direction < 0)
        {
            playerRenderer.flipX = DirLeft = true;
            transform.position += Movement;
        }
        else if (Direction > 0)
        {
            playerRenderer.flipX = false;
            DirRight = true;
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

            controller.fxPrefab = fxPrefab;

            SpriteRenderer bulletRenderer = Obj.GetComponent<SpriteRenderer>();
            bulletRenderer.flipY = playerRenderer.flipX;


            Bullets.Add(Obj);
        }

        animator.SetFloat("Speed", Hor);



        //transform.position += Movement;
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

