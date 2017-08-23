using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPShoot : MonoBehaviour 
{

    public float fireRate = 0.5F;

    private Ray ray;
    private AudioSource source;
    private float nextFire;

    private void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        source = GetComponent<AudioSource>();
    }

    void Update ()
	{
		if (Input.GetButtonDown("Fire1") && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate;
            RaycastHit hit;
            ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            source.Play();
            if (Physics.Raycast(ray, out hit))
            {  
                //Debug.Log(hit.transform.gameObject.name);
                //Destroy(hit.transform.gameObject);
                Rigidbody myBody = hit.transform.gameObject.GetComponent<Rigidbody>();
                if (myBody != null)
                {
                    myBody.AddForce(transform.forward * 1000f);
                    hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
	}
}
