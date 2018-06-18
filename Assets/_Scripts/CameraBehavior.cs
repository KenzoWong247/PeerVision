using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public Camera overheadCamera;
    public Camera studentCamera;
    public Camera teacherCamera;

    private float mZoomSpeed;
    private Vector3 m_MoveVelocity;
    public float speed = 500.0f;
    // Use this for initialization
    void Start () {
        overheadCamera.gameObject.SetActive(true);
        studentCamera.gameObject.SetActive(false);
        teacherCamera.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            toggleView();
        }
        if (overheadCamera.isActiveAndEnabled)
        {
            moveCamera(overheadCamera);
        }
        else if (studentCamera.isActiveAndEnabled)
        {
            moveCamera(studentCamera);
        }
        else if (teacherCamera.isActiveAndEnabled)
        {
            moveCamera(teacherCamera);   
        }
        if (overheadCamera.isActiveAndEnabled)
        {
            zoomCamera(overheadCamera);
        }
        else if (studentCamera.isActiveAndEnabled)
        {
            zoomCamera(studentCamera);
        }
        else if (teacherCamera.isActiveAndEnabled)
        {
            zoomCamera(teacherCamera);
        }

    }

    public void zoomCamera(Camera camera)
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (camera.fieldOfView <= 125)
                camera.fieldOfView += 2;
            if (camera.orthographicSize <= 20)
                camera.orthographicSize += 0.5f;

        }
        // ---------------Code for Zooming In------------------------
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (camera.fieldOfView > 2)
                camera.fieldOfView -= 2;
            if (camera.orthographicSize >= 1)
                camera.orthographicSize -= 0.5f;
        }
    }

    public void moveCamera(Camera camera)
    {
        float moveHorizontal = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(-moveVertical * speed, moveHorizontal * speed, 0.0f);
        camera.gameObject.transform.Rotate(rotation * speed * Time.deltaTime);
        
    }

    public void toggleView()
    {
        if (overheadCamera.isActiveAndEnabled)
        {
            overheadCamera.gameObject.SetActive(false);
            studentCamera.gameObject.SetActive(true);
            teacherCamera.gameObject.SetActive(false);
        }
        else if (studentCamera.isActiveAndEnabled)
        {
            overheadCamera.gameObject.SetActive(false);
            studentCamera.gameObject.SetActive(false);
            teacherCamera.gameObject.SetActive(true);
        }
        else if (teacherCamera.isActiveAndEnabled)
        {
            overheadCamera.gameObject.SetActive(true);
            studentCamera.gameObject.SetActive(false);
            teacherCamera.gameObject.SetActive(false);
        }
        else
        {
            overheadCamera.gameObject.SetActive(true);
            studentCamera.gameObject.SetActive(false);
            teacherCamera.gameObject.SetActive(false);
        }
    }
}
