using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private float Speed;

    private int hp;

    public GameObject fxPrefab;

    public Vector3 Direction { get; set; }

    private void Start()
    {
        Speed = 10.0f;

        hp = 3;
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

        Destroy(collision.transform.gameObject);

        if (hp == 0)
            Destroy(this.gameObject);

    }
}
