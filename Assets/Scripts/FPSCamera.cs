using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public Camera fpscamera;

    public float horizontalSpeed;
    public float verticalSpeed;

    float h;
    float v;

    public float rotationSpeed = 10f;
    public float movementSpeed = 10f;
    public float devaluator = 0.1f;
    private float hmove = 0f;
    private float vmove = 0f;
   
    float speedUp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        fpscamera.transform.Rotate(-v, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0, 0, 0.1f);
            transform.Translate(Camera.main.transform.forward* devaluator * Time.deltaTime * (speedUp+10f));
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -0.1f);
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(-0.1f, 0, 0);
                }
                else
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        transform.Translate(0.1f, 0, 0);
                    }
                }
            }
        }


    }
}
