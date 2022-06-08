using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{   
    public GameObject Sphere;
    public float RotationSpeed;
    public Vector3 _rotationX = new Vector3(1, 0, 0);
    public Vector3 _rotationZ = new Vector3(0, 0, 1);
    //1-top 2-bot 3-left 4-right 5-front 6-back
    public int cubeSide;

    void Start()
    {
    }

    void Update()
    {
        if(!Input.anyKey) transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 1.0f * Time.deltaTime);
        switch(cubeSide)
        {
            case 1:
            if(Input.GetKey(KeyCode.S))
            {
                if(transform.rotation.x > -0.07) transform.Rotate(-_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                if(transform.rotation.x < 0.07) transform.Rotate(_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(transform.rotation.z > -0.07) transform.Rotate(-_rotationZ * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                if(transform.rotation.z < 0.07) transform.Rotate(_rotationZ * RotationSpeed * Time.deltaTime);
            }
            break;
            case 2:
            if(Input.GetKey(KeyCode.S))
            {
                if(transform.rotation.x > -0.07) transform.Rotate(-_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                if(transform.rotation.x < 0.07) transform.Rotate(_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(transform.rotation.z < 0.07) transform.Rotate(_rotationZ * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                if(transform.rotation.z > -0.07) transform.Rotate(-_rotationZ * RotationSpeed * Time.deltaTime);
            }
            break;
            case 3:
            if(Input.GetKey(KeyCode.S))
            {
                if(transform.rotation.y > -0.07) transform.Rotate(-_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                if(transform.rotation.y < 0.07) transform.Rotate(_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(transform.rotation.z > -0.07) transform.Rotate(-_rotationZ * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                if(transform.rotation.z < 0.07) transform.Rotate(_rotationZ * RotationSpeed * Time.deltaTime);
            }
            break;
            case 4:
            if(Input.GetKey(KeyCode.S))
            {
                if(transform.rotation.y > -0.07) transform.Rotate(-_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                if(transform.rotation.y < 0.07) transform.Rotate(_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(transform.rotation.z < 0.07) transform.Rotate(_rotationZ * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                if(transform.rotation.z > -0.07) transform.Rotate(-_rotationZ * RotationSpeed * Time.deltaTime);
            }
            break;
            case 5:
            if(Input.GetKey(KeyCode.S))
            {
                if(transform.rotation.x > -0.07) transform.Rotate(-_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                if(transform.rotation.x < 0.07) transform.Rotate(_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(transform.rotation.y > -0.07) transform.Rotate(-_rotationZ * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                if(transform.rotation.y < 0.07) transform.Rotate(_rotationZ * RotationSpeed * Time.deltaTime);
            }
            break;
            case 6:
            if(Input.GetKey(KeyCode.S))
            {
                if(transform.rotation.x > -0.07) transform.Rotate(-_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.W))
            {
                if(transform.rotation.x < 0.07) transform.Rotate(_rotationX * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                if(transform.rotation.y < 0.07) transform.Rotate(_rotationZ * RotationSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.A))
            {
                if(transform.rotation.y > -0.07) transform.Rotate(-_rotationZ * RotationSpeed * Time.deltaTime);
            }
            break;
        }        
    }
}
