using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private Transform parent;

    private SpriteRenderer spriteRenderer;
    private Sprite sprite;

    private float endPoint;
    private float exitPoint;

    public float Speed;

    private GameObject player;
    SpriteRenderer playerRenderer;

    private Vector3 movemane;
    private Vector3 offset = new Vector3(0.0f, 7.5f, 0.0f);


    private void Awake()
    {
        player = GameObject.Find("Player").gameObject;
        parent = GameObject.Find("BackGround").transform;

        spriteRenderer = GetComponent<SpriteRenderer>();
       
        playerRenderer = player.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update

    void Start()
    {
        sprite = spriteRenderer.sprite;

        endPoint = sprite.bounds.size.x * 0.5f + transform.position.x;
        exitPoint = -(sprite.bounds.size.x * 0.5f) + player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerRenderer.flipX)
        {
            movemane = new Vector3(
               Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed + offset.x,
               player.transform.position.y + offset.y,
               0.0f + offset.z);
        }
        else
        {
            
        }

        


        transform.position -= movemane;
        endPoint -= movemane.x;

        if (player.transform.position.x + (sprite.bounds.size.x*0.5f) + 1 > endPoint)
        {
            GameObject Obj = Instantiate(this.gameObject);

            Obj.transform.parent = transform;
            Obj.transform.name = transform.name;
            Obj.transform.position = new Vector3(
                endPoint + 25.0f,0.0f,0.0f);

            endPoint += endPoint + 25.0f;
        }
        if(transform.position.x + (sprite.bounds.size.x * 0.5f) -2 < exitPoint)
        {
            Destroy(this.gameObject);
        }
    }
}
