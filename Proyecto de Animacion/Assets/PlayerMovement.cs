using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform camPivot;
    float heading = 0;
    public Transform cam;
    public Animator anim;

    Vector2 input;
    void Update()

    {
        //movement
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
        
        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;

        //rotation
       transform.rotation= Quaternion.LookRotation((camF * input.y + camR * input.x));
        //animator Control

        anim.SetFloat("Magnitude", new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude);
        anim.SetFloat("Xvel", Input.GetAxis("Horizontal"));
        anim.SetFloat("Yvel", Input.GetAxis("Vertical"));
    }
}
