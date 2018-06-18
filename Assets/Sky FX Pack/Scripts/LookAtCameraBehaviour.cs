using UnityEngine;
using System.Collections;

public class LookAtCameraBehaviour : MonoBehaviour
{
    public Camera overheadCamera;
    public Camera studentCamera;
    public Camera teacherCamera;

    public void toggleView()
    {
        if (overheadCamera.isActiveAndEnabled)
        {
            overheadCamera.enabled = false;
            studentCamera.enabled = true;
            teacherCamera.enabled = false;
        }
        else if (studentCamera.isActiveAndEnabled)
        {
            overheadCamera.enabled = false;
            studentCamera.enabled = false;
            teacherCamera.enabled = true;
        }
        else if (teacherCamera.isActiveAndEnabled)
        {
            overheadCamera.enabled = true;
            studentCamera.enabled = false;
            teacherCamera.enabled = false;
        }
        else
        {
            overheadCamera.enabled = true;
            studentCamera.enabled = false;
            teacherCamera.enabled = false;
        }
    }
	// Use this for initialization
	void Start () 
    {
       
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (Camera.current == null) return;
        transform.LookAt( new Vector3( Camera.current.transform.position.x, transform.position.y, Camera.current.transform.position.z ) ); 
	}
}
