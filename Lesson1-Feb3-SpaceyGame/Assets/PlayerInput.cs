using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public Rigidbody2D bulletPreFab;
    public float bulletSpeed;

	void Start () {
		
	}
	
	void Update () {
		float xInput = Input.GetAxis ("Horizontal");
		float yInput = Input.GetAxis ("Vertical");

		Vector2 mousePos = Input.mousePosition;
		Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint (mousePos);

		Vector3 input = new Vector3 (xInput, yInput, 0);
		transform.position += input * 2 * Time.deltaTime;
	
		Debug.Log (worldMousePosition);
		//transform.LookAt (worldMousePosition);

		// get direction you want to point at
		Vector2 direction = (worldMousePosition - (Vector2) transform.position).normalized;

		// set vector of transform directly
		transform.up = direction;


        // fire
        if(Input.GetMouseButtonDown(0))
        {
            //create bullet
            Rigidbody2D instantiatedBullet = Instantiate(bulletPreFab, transform.position, transform.rotation) as Rigidbody2D;
            //instantiatedBullet.velocity = new Vector2(10, 0);
            instantiatedBullet.velocity = transform.up * bulletSpeed;
            Destroy(instantiatedBullet.gameObject, 1);
        } 
	}
}
