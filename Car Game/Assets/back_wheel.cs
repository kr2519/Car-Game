using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_wheel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTRiggerEnter");
        if (other.gameObject.CompareTag("TargetBall"))
        {
            other.gameObject.SetActive(false);
            //other.gameObject.GetComponent<BallScript>().DoInitPos();
            Debug.Log("TargetBall false");
        }
    }
}
