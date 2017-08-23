using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX,
        MouseY,
        MouseXY
    }

    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;
    public float minX, maxX;

    public RotationAxis axis = RotationAxis.MouseX;

    private float rotationX;
	
	void Update ()
    {
		if (axis == RotationAxis.MouseX)
        {
            float rotationY = Input.GetAxis("Mouse X") * sensitivityHor * Time.deltaTime;
            transform.Rotate(0, rotationY, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityHor * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, minX, maxX);
            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0);
        }
        else if (axis == RotationAxis.MouseXY)
        {
            float rotationY = Input.GetAxis("Mouse X") * sensitivityHor * Time.deltaTime;
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityHor * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, minX, maxX);
            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y + rotationY, 0);
        }

    }
}
