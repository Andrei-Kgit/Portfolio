using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawn : MonoBehaviour
{
    //Объекты, содержащие значения для реализации механики кубов
    public InputField SpawnRateField;
    public InputField SpeedField;
    public InputField DistanceField;
    //Значения для спавна и передвижения куба
    public float StartSpawnRate = 2;
    public float CurrSpawnRate;
    public float CubeSpeed;
    public float Distance = 10;
    //Массив из префабов кубов разного цвета
    public GameObject[] Cube;
    //Место спавна и финиша
    public GameObject SpawnPoint;
    public GameObject FinishPoint;

    void Start()
    {
        CurrSpawnRate = StartSpawnRate;
    }

    void Update()
    {
        //спавн кубов
        if(CurrSpawnRate <= 0)
        {
            Instantiate(Cube[Random.Range(0, Cube.Length-1)], SpawnPoint.transform.position, Quaternion.identity);
            CurrSpawnRate = StartSpawnRate;
        }
        CurrSpawnRate -= Time.deltaTime;
    }

    //применение изменений
    public void ApplyValues()
    {
        if(!string.IsNullOrEmpty(SpawnRateField.text)) 
        {
            StartSpawnRate = float.Parse(SpawnRateField.text);
        }
        if(!string.IsNullOrEmpty(SpeedField.text)) 
        {
            CubeSpeed = float.Parse(SpeedField.text);
        }
        if(!string.IsNullOrEmpty(DistanceField.text)) 
        {
            FinishPoint.transform.position = new Vector3(FinishPoint.transform.position.x, FinishPoint.transform.position.y, float.Parse(DistanceField.text));
        }
    }
}
