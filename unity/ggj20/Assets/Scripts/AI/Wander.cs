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
 
	void Awake ()
	{
		controller = GetComponent<CharacterController>(); 
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
 
		StartCoroutine(NewHeading());
	}
 
    GameObject getClosestIsland() {
        GameObject ret = null;
        float minDist = 9999999f;
        GameObject[] islands = GameObject.FindGameObjectsWithTag("Floor"); 
        foreach (GameObject island in islands)
        {
            float currentDistance = Vector3.Distance(island.transform.position, transform.position);
            if(currentDistance < minDist) {
                minDist = currentDistance;
                ret = island;
            }
        }
        return ret;
    }

	void FixedUpdate ()
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

        if (Physics.Raycast(transform.position, directionFrontDown, out hit, 50.0f) && Physics.Raycast(transform.position, directionFrontDown, out hit2, 50.0f))
        {
            if(hit.collider.tag == "Floor" && hit2.collider.tag == "Floor") {
                forward = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(forward * speed);
                return;
            }
        }

        //Turn 180° and calculate new angle to approach
        transform.RotateAround(transform.position, transform.up, 180f);
        heading -= 180;
        if(heading < 0)
            heading = 360 - heading;

        NewHeadingRoutine();
	}
 
	IEnumerator NewHeading ()
	{
		while (true) {
            if(m_enabled)
			    NewHeadingRoutine();
			
            yield return new WaitForSeconds(directionChangeInterval);
		}
	} 

    private bool m_enabled = true;

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
}