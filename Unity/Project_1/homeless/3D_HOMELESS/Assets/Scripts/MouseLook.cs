using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public enum RotationAxes {			//селект лист для Инспектора
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor  = 9.0f;		//скорость вращения по горизонтали
	public float sensitivityVert = 9.0f;		//скорость вращения по вертикали

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0; //угол поворота

	void Start() {
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
		body.freezeRotation = true;
	}

    void Update()
    {
		if (axes == RotationAxes.MouseX) {	      //поворот по горизонтали
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {   //поворот по вертикали		//Стр.54
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
		else {									  //комбинированный поворот		//Стр.56
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
    }
}
