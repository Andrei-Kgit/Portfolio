using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIdeChange : MonoBehaviour
{
    public GameObject cube;
    public Transform cameraPos;
    private CubeControl scriptCubeControl;
    public GameObject winText;

    public int side;
    void Start()
    {
        scriptCubeControl = cube.GetComponent<CubeControl>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TOPCollider"))
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
            cameraPos.position = new Vector3(0, 15, -7);
            cameraPos.rotation = Quaternion.Euler(60, 0, 0);
            scriptCubeControl._rotationX = new Vector3(1, 0, 0);
            scriptCubeControl._rotationZ = new Vector3(0, 0, 1);
            scriptCubeControl.cubeSide = 1;
        }
        if(other.CompareTag("BOTCollider"))
        {
            Physics.gravity = new Vector3(0, 9.8f, 0);
            cameraPos.position = new Vector3(0, -15, 7);
            cameraPos.rotation = Quaternion.Euler(-120, 0, 0);
            scriptCubeControl._rotationX = new Vector3(1, 0, 0);
            scriptCubeControl._rotationZ = new Vector3(0, 0, 1);
            scriptCubeControl.cubeSide = 2;
        }
        if(other.CompareTag("LEFTCollider"))
        {
            Physics.gravity = new Vector3(9.8f, 0, 0);
            cameraPos.position = new Vector3(-15, 0, -7);
            cameraPos.rotation = Quaternion.Euler(0, 60, 90);
            scriptCubeControl._rotationX = new Vector3(0, 1, 0);
            scriptCubeControl._rotationZ = new Vector3(0, 0, 1);
            scriptCubeControl.cubeSide = 3;
        }
        if(other.CompareTag("RIGHTCollider"))
        {
            Physics.gravity = new Vector3(-9.8f, 0, 0);
            cameraPos.position = new Vector3(15, 0, 7);
            cameraPos.rotation = Quaternion.Euler(0, -120, 90);
            scriptCubeControl._rotationX = new Vector3(0, 1, 0);
            scriptCubeControl._rotationZ = new Vector3(0, 0, 1);
            scriptCubeControl.cubeSide = 4;
        }
        if(other.CompareTag("FRONTCollider"))
        {
            Physics.gravity = new Vector3(0, 0, 9.8f);
            cameraPos.position = new Vector3(0, -7, -15);
            cameraPos.rotation = Quaternion.Euler(-30, 0, 0);
            scriptCubeControl._rotationX = new Vector3(1, 0, 0);
            scriptCubeControl._rotationZ = new Vector3(0, 1, 0);
            scriptCubeControl.cubeSide = 5;
        }
        if(other.CompareTag("BACKCollider"))
        {
            Physics.gravity = new Vector3(0, 0, -9.8f);
            cameraPos.position = new Vector3(0, 7, 15);
            cameraPos.rotation = Quaternion.Euler(30, 180, 180);
            scriptCubeControl._rotationX = new Vector3(1, 0, 0);
            scriptCubeControl._rotationZ = new Vector3(0, 1, 0);
            scriptCubeControl.cubeSide = 6;
        }
        if(other.CompareTag("Finish"))
        {
            winText.SetActive(true);
        }
    }
}