using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float rotationSpeed = 10f;
    public float movementSpeed = 10f;
    public float devaluator = 0.1f;
    private float hmove = 0f;
    private float vmove = 0f;
    private Rigidbody rigidbody;
    float speedUp = 0f;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        // Rotate (keyboard arrows)
        hmove = Input.GetAxis("MoveX");
        vmove = Input.GetAxis("MoveZ");
        Rotate();
        speedUp = Input.GetAxis("TriggerLeft")*movementSpeed;
        // Move (keyboard keys)
       // Move();

    }

    void Rotate(){
        if (vmove > 0)
        {
            transform.Translate(Camera.main.transform.forward* devaluator * Time.deltaTime * (speedUp+10f));
        }
        if (vmove < 0)
        {
            transform.Translate(Camera.main.transform.forward * -devaluator * Time.deltaTime * (speedUp + 10f));
        }
        if (hmove > 0)
        {
            transform.Translate(Camera.main.transform.right * devaluator * Time.deltaTime * (speedUp + 10f));
        }
        if (hmove < 0)
        {
            transform.Translate(Camera.main.transform.right * -devaluator * Time.deltaTime * (speedUp + 10f));
        }
    }

    void OnCollision(Collision col)
    {
        rigidbody.isKinematic = true;
    }
    
    void OnColliderEnter(Collider col)
    {
        if (col.gameObject.tag.CompareTo("NPC")==0 )
        {
            //show tienda
           
            GameObject canvas = GameObject.FindGameObjectWithTag("Tienda");
            canvas.SetActive(true);

        }
    }

    void OnColliderExit(Collider col)
    {
        if (col.gameObject.tag.CompareTo("NPC") == 0)
        {
            //no tienda
            GameObject canvas = GameObject.FindGameObjectWithTag("Tienda");
            canvas.SetActive(false);
        }
    }
}
