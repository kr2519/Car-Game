using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Car : MonoBehaviour
{
    public float dist,sp, s_x;
    private GameObject flag;
    private int poweron;
    public float power;
    private int power_flag;
    private int power_shift, k;
    public int score;
    public Text settext;
    // Start is called before the first frame update
    void Start()
    {
        
        flag = GameObject.Find("RegularFlag");
        s_x = transform.position.x;
        sp = Mathf.Abs(flag.transform.position.x - s_x);
        power_flag = 0;
        //settext.text = "거리 : ";
        k = 0;
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300 * Time.deltaTime * 50);
    }
    // Update is called once per frame

    public void restart()
    {
        print("restart");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.transform.position = new Vector3(s_x, -40f, 0f);
    }
    void Update()
    {
        flag = GameObject.Find("RegularFlag");
        dist = Mathf.Abs(flag.transform.position.x - this.transform.position.x);
        dist = (int)dist;
        if(settext != null)
            settext.text = "거리 : " + dist.ToString();
        score = (int)((sp - dist) * 100.0 / sp + 0.5);
        poweron = GameObject.Find("PowerUp").GetComponent<button>().poweron;
        //print(score);
        //if(score >=95)
        //    GetComponent<Rigidbody2D>().drag = 3;
        if (poweron == 1 && power_flag == 0)
        {
            power_flag = 1;
            power = 1;
            power_shift = 1;
        }
        else if (power_flag == 1 && poweron == 1)
        {
            if (power < 100 && power > 0)
                power += power_shift;
            else
            {
                power_shift *= -1;
                power += power_shift;
            }
        }
        else if (power_flag == 1 && poweron == 0)
        {
            power_flag = 0;
            print("G0!!!!!");
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300 * Time.deltaTime * power);
        }
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    print("Rignt");
        //    GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300 * Time.deltaTime*50);
        //}
    }
}
