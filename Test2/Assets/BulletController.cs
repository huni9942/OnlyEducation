using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private float Speed;
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
        Back = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyObject(this.gameObject);
    }
}
