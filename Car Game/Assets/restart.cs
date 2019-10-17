using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick(int value)
    {
        GameObject.Find("CarB").GetComponent<Car>().restart();
    }
}
