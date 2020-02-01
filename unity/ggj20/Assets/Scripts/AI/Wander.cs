using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;
 
	CharacterController controller;
	float heading;
	Vector3 targetRotation;
 
    Vector3 startPosition;

	void Awake ()
	{
		controller = GetComponent<CharacterController>(); 
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
        startPosition = transform.position;

		StartCoroutine(NewHeading());
	}
 
    bool onBorder = false;

	void Update ()
	{
        if(!m_enabled)
            return;

        RaycastHit hit;
        RaycastHit hit2;

        var forward = transform.TransformDirection(Vector3.forward);
        var down = transform.TransformDirection(Vector3.down);
        var down3 = transform.TransformDirection(Vector3.down * 3);
        Vector3 directionFrontDown = forward + down;
        Vector3 directionFrontDowner = forward + down3;

        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);

        Vector3 fromPos = transform.position + transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(fromPos, directionFrontDown, out hit, 50.0f) && Physics.Raycast(fromPos, directionFrontDown, out hit2, 50.0f))
        {
            if(hit.collider.tag == "Floor" && hit2.collider.tag == "Floor") {
                forward = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(forward * speed);
                onBorder = false;
                wasReset = false;
                return;
            }
        }

        if(!onBorder) {
            transform.RotateAround(transform.position, transform.up, 180f);
            heading -= 180;
            if(heading < 0)
                heading = 360 - heading;

            NewHeadingRoutine();
            onBorder = true;
        }        

        if(!wasReset)
            controller.SimpleMove(Vector3.down * speed * 5);
	}
 
	IEnumerator NewHeading ()
	{
		while (true) {
            if(m_enabled)
			    NewHeadingRoutine();
			
            yield return new WaitForSeconds(directionChangeInterval);
		}
	} 

    private bool m_enabled = false;
    private bool wasReset = false;

    public void setEnabled(bool enabled)
    {
        m_enabled = enabled;
    }

    public void toggleEnable()
    {
        m_enabled = !m_enabled;
    }

	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}

    public void resetPosition() {
        transform.position = startPosition;
        heading = 0;
        targetRotation = new Vector3(0, 0, 0);
        onBorder = false;
        wasReset = true;
    }
}