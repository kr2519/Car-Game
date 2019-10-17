using UnityEngine;
using System.Collections;
public class carController : MonoBehaviour {




	public WheelJoint2D frontwheel;
	public WheelJoint2D backwheel;


    JointMotor2D motorFront;

	JointMotor2D motorBack;

	public float speedF;
	public float speedB;

	public float torqueF;
	public float torqueB;

	public bool TractionFront = true;
	public bool TractionBack = true;
    public float dist,sp;
    public GameObject flag;
    public int poweron;
    public float power;
    private int power_flag;
    private int power_shift;
    public float carRotationSpeed;
    public int score, k;
	// Use this for initialization
	void Start () {
        flag = GameObject.Find("RegularFlag");
        sp = Mathf.Abs(flag.transform.position.x - transform.position.x);
        power_flag = 0;
        k = 0;
    }
	
	// Update is called once per frame
	void Update () {
        flag = GameObject.Find("RegularFlag");
        dist = Mathf.Abs(flag.transform.position.x - transform.position.x);
        score = (int)((sp - dist) * 100.0/sp + 0.5);
        poweron = GameObject.Find("Play").GetComponent<button>().poweron;

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

            if (TractionFront)
            {
                motorFront.motorSpeed = (float)1000 * -1;
                motorFront.maxMotorTorque = (float)10000;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = (float)1000 * -1;
                motorBack.maxMotorTorque = (float)10000;
                backwheel.motor = motorBack;
            }

        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {

            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * -1;
                print("Front speedF : " + speedF);
                motorFront.maxMotorTorque = torqueF;
                print("Front torqueF : " + torqueF);
                frontwheel.motor = motorFront;


            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * -1;
                print("Back speedF : " + speedF);
                motorBack.maxMotorTorque = torqueF;
                print("Back torqueF : " + torqueF);
                backwheel.motor = motorBack;
               
            }

        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            print("Ver<0");

            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * -1;
                motorFront.maxMotorTorque = torqueB;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * -1;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;

            }

        }
        else
        {

            backwheel.useMotor = false;
            frontwheel.useMotor = false;

        }




        //if (Input.GetAxisRaw ("Horizontal") != 0) {

        //	GetComponent<Rigidbody2D> ().AddTorque (carRotationSpeed * Input.GetAxisRaw ("Horizontal") * -1);

        //}

    }
}
