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
    public float carRotationSpeed;
    public int score;
	// Use this for initialization
	void Start () {
        flag = GameObject.Find("RegularFlag");
        sp = Mathf.Abs(flag.transform.position.x - transform.position.x);
    }
	
	// Update is called once per frame
	void Update () {
        flag = GameObject.Find("RegularFlag");
        dist = Mathf.Abs(flag.transform.position.x - transform.position.x);
        score = (int)((sp - dist) * 100.0/sp + 0.5);
        print("Distance " + score);

        if (Input.GetAxisRaw ("Vertical") > 0) {


			if (TractionFront) {
				motorFront.motorSpeed = speedF * -1;
				motorFront.maxMotorTorque = torqueF;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = speedF * -1;
				motorBack.maxMotorTorque = torqueF;
				backwheel.motor = motorBack;

			}

        } else if (Input.GetAxisRaw ("Vertical") < 0) {


			if (TractionFront) {
				motorFront.motorSpeed = speedB * -1;
				motorFront.maxMotorTorque = torqueB;
				frontwheel.motor = motorFront;
			}

			if (TractionBack) {
				motorBack.motorSpeed = speedB * -1;
				motorBack.maxMotorTorque = torqueB;
				backwheel.motor = motorBack;

			}

		} else {

			backwheel.useMotor = false;
			frontwheel.useMotor = false;

		}




		if (Input.GetAxisRaw ("Horizontal") != 0) {

			GetComponent<Rigidbody2D> ().AddTorque (carRotationSpeed * Input.GetAxisRaw ("Horizontal") * -1);

		}

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
