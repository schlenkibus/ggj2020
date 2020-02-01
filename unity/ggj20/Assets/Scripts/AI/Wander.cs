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
 
	void Update ()
	{
        RaycastHit hit;

        var forward = transform.TransformDirection(Vector3.forward);
        var down = transform.TransformDirection(Vector3.down);
        Vector3 direction = forward + down;

        if (Physics.Raycast(transform.position, direction, out hit, 200.0f))
        {
            if(hit.collider.tag == "Floor") {
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
                forward = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(forward * speed);
                return;
            }
        }

        transform.RotateAround(transform.position, transform.up, 180f);
        NewHeadingRoutine();
	}
 
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	} 

	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        var forward = transform.TransformDirection(Vector3.forward);
        var down = transform.TransformDirection(Vector3.down);
        Vector3 direction = forward + down;
        Gizmos.DrawLine(transform.position, direction);
    }
}