using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public int poweron;
    public Vector3 mousePos;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        poweron = 0;
        Camera = GameObject.Find("Main Camera");
        transform.position = new Vector3(Camera.transform.position.x - 77.2f, Camera.transform.position.y + 21.4f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Camera = GameObject.Find("Main Camera");
        transform.position = new Vector3((Camera.transform.position.x - 77.2f), (Camera.transform.position.y + 21.4f), 0.0f);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    mousePos = Input.mousePosition;
        //    Debug.Log("Clicked on!");
        //}

    }
   
    public void OnClickExit()
    {
       
    }
    void OnMouseDown()
    {
        if(GameObject.Find("Main Camera").GetComponent<FreeLookCamera>().enable == 1)
            poweron = 1;
        Debug.Log("Clicked Down!!!");
    }
    void OnMouseUp()
    {
        if (GameObject.Find("Main Camera").GetComponent<FreeLookCamera>().enable == 1)
            poweron = 0;
        Debug.Log("Clicked Up!!!");
    }
}
