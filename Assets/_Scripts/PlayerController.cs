using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int speed;

    [SerializeField]
    public int rotationSpeed;
    void Start()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal*speed*Time.deltaTime, 0.0f, moveVertical*speed*Time.deltaTime);

        transform.position += movement * Time.fixedDeltaTime;
        transform.Rotate(0, Input.GetAxis("Rotate")*rotationSpeed*Time.deltaTime, 0); 
        
    }
}
