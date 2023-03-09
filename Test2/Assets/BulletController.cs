using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private float Speed;

    private int hp;

    public GameObject fxPrefab;

    private SpriteRenderer Back;
    // public Vector3 Direction {
    //    get 
    //    { 
    //        return Direction; 
    //    }
    //    set
    //    {
    //        Direction = value;
    //    }
    //}

    public Vector3 Direction { get; set; }

    private void Start()
    {
        Speed = 10.0f;

        hp = 3;

        Back = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        --hp;

        GameObject Obj = Instantiate(fxPrefab);

        GameObject camera = new GameObject("Camera Test");
        camera.AddComponent<CameraController>();

        Obj.transform.position = transform.position;

        print("ENTER");
        DestroyObject(collision.transform.gameObject);

        if (hp == 0)
            DestroyObject(this.gameObject);

    }

  /*  private void OnTriggerStay2D(Collider2D collision)
    {
        print("STAY");
    }

  /  private void OnTriggerExit2D(Collider2D collision)
    {
        print("EXIT");
    }*/
}
