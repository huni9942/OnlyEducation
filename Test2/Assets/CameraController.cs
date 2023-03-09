using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //private Camera camera;

    private float shakeTime = 0.15f;

    private Vector3 offset = new Vector3(0.15f, 0.15f, 0.0f);
    private Vector3 OldPosition;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        OldPosition = Camera.main.transform.position;

        while(shakeTime > 0.0f)
        {
            shakeTime -= Time.deltaTime;
            yield return null;

            Camera.main.transform.position = new Vector3(
            Random.Range(OldPosition.x - offset.x, OldPosition.x + offset.x),
            Random.Range(OldPosition.y - offset.y, OldPosition.y + offset.y),
            -10.0f);
        }
        Camera.main.transform.position = OldPosition;
        Destroy(this.gameObject);
       

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
