using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{
    public GameObject Player;
    public GameObject finish;
    public float gap, timer;
    public int enable;
    private int start;
    // Start is called before the first frame update
    void Start()
    {
        start = 0;
        enable = 0;
        float timer = 0;
        Player = GameObject.Find("CarB");
        finish = GameObject.Find("RegularFlag");
        transform.position = new Vector3(Player.transform.position.x + 69.46f, Player.transform.position.y + 52.55f, -10.0f);
        gap = finish.transform.position.x - (transform.position.x);
        print(gap);
        //print(gap);
        //StartCoroutine(Example());
        //transform.Translate(new Vector3(gap, 0.0f,0.0f));
        //StartCoroutine(Example());
        //transform.Translate(new Vector3(-gap, 0.0f, 0.0f));
        while (true)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                print("DFdf");
                this.transform.Translate(new Vector3(gap * Time.deltaTime, 0.0f,0.0f));
                break;
            }
        }
    }
    void Example()
    {

    }
    void delay(int second)
    {
        float timer = 0;
        timer += Time.deltaTime;

        if (timer > second)
        {
            
        }
    }
    void Update()
    {
        finish = GameObject.Find("RegularFlag");
        Player = GameObject.Find("CarB");
        if (finish.transform.position.x > this.transform.position.x + 30 && start == 0)
        {
            this.transform.Translate(new Vector3(100 * Time.deltaTime, 0.0f, 0.0f));
            if (finish.transform.position.x <= this.transform.position.x + 30)
                start = 1;
        }
        else if(start == 1 && this.transform.position.x > Player.transform.position.x + 69.46f)
        {
            this.transform.Translate(new Vector3(-200 * Time.deltaTime, 0.0f, 0.0f));
            if (this.transform.position.x <= Player.transform.position.x + 69.46f)
                start = 2;
        }
        else 
        {
            transform.position = new Vector3(Player.transform.position.x + 69.46f, Player.transform.position.y + 52.55f, -10.0f);
            enable = 1;
        }

        //if(start == 0)
        //{
        //    start = 1;
        //    //Invoke("Example", 10);
        //    print("dd");
        //    this.transform.Translate(new Vector3(gap* Time.deltaTime, 0.0f, 0.0f));

        //}
        //new WaitForSeconds(10.0f);
        //Player = GameObject.Find("CarB");

        //transform.Translate(new Vector3(Player.transform.position.x, Player.transform.position.y,0.0f));
        //transform.position = new Vector3(Player.transform.position.x + 79.46f, Player.transform.position.y + 52.55f, -10.0f);
    }
}
