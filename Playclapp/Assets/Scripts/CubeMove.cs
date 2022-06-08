using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMove : MonoBehaviour
{
    //Значения передвижения куба
    private float speed = 10;
    
    //Место финиша
    public GameObject Finish;

    public GameObject plane;

    void Start()
    {
        //получение значений и ссылок
        plane = GameObject.Find("plane");
        speed = plane.GetComponent<CubeSpawn>().CubeSpeed;
        Finish = plane.GetComponent<CubeSpawn>().FinishPoint;
    }

    void Update()
    {
        //перемещение
        transform.position = Vector3.MoveTowards(transform.position, Finish.transform.position, speed * Time.deltaTime);
        //уничтожение в конце пути
        if(transform.position == Finish.transform.position) Destroy(gameObject);
    }
}
