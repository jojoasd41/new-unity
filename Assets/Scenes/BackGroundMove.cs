using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float camAndBkFactor = 0.1f;
    public float bkAndBkFactor = 0.4f;
    public Transform[] backGround;

    private Transform cam;
    private Vector3 camPrePos;
    private float XSmooth = 4;
    private float camAndBk;
    private float bkAndBk;
    void Start()
    {
        cam = Camera.main.transform;
        camPrePos = cam.position;
    }
    public void BGMove()
    {
       camAndBk = (camPrePos.x - cam.position.x) * camAndBkFactor;
       for(int i = 0;i<backGround.Length;i++)
        {
            bkAndBk = backGround[i].position.x + camAndBk + camAndBk*(backGround.Length - i) * bkAndBkFactor;
            Vector3 NewPosition = new Vector3(bkAndBk, backGround[i].position.y, backGround[i].position.z);
            backGround[i].position = Vector3.Lerp(backGround[i].position, NewPosition, XSmooth * Time.deltaTime);
        }

       camPrePos = cam.position;
    }
    // Update is called once per frame
    void Update()
    {
        BGMove();
    }
}
