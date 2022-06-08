using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Duck : MonoBehaviour
{
    //Contains waterLily
    public GameObject waterLily;
    //Array 0f fruits
    public GameObject[] fruits;
    //New fruit position
    private Vector3 fruitPos;
    //Contains duck that will add to joint
    public GameObject newDuck;
    public GameObject startDuck;
    //Contains list of ducks in joint
    private List<GameObject> jointParts = new List<GameObject>();
    //Contains History of main duck`s moves
    private List<Vector3> PositionHistory = new List<Vector3>();
    //Distance between ducks
    public int gap = 10;
    //Ducks move stats
    public float moveSpeed = 50f;
    public float tailDuckSpeed = 50f;
    public float rotationSpeed = 200f;
    //Contains bonus objects
    public GameObject[] bonus;
    //shield bonus
    private bool shield = false;
    private float shieldDur;
    public Text shieldBonusText;
    public GameObject shieldBonusIcon;
    //Endgame stats
    public GameObject endGameStats;
    public Text highScoreText;
    //Contains UI text for score and hightscore
    public Text scoreText;
    private int score;
    //x2 bonus
    private bool x2bonus = false;
    private float x2bonusDur;
    public Text x2BonusText;
    public GameObject x2BonusIcon;

    private void Awake()
    {
        shieldBonusIcon.SetActive(false);
        x2BonusIcon.SetActive(false);
    }
    void Start()
    {
        AddStartDuck();
        AddStartDuck();
        AddStartDuck();
        SpawnNewFruit();
        StartCoroutine(SpawnWaterLily());
        StartCoroutine(SpawnBonus());
    }

    void Update()
    {
        X2bonusAction();
        ShieldAction();
        scoreText.text = score.ToString();
        //Movint forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        //Rotation
        float rotationDirection = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * rotationDirection * rotationSpeed * Time.deltaTime);

        //Position history
        PositionHistory.Insert(0, transform.position);

        //Move for ducks in tail
        int index = 1;
        foreach(var duck in jointParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];
            Vector3 moveDirection = point - duck.transform.position;
            duck.transform.position += moveDirection * tailDuckSpeed * Time.deltaTime;
            duck.transform.LookAt(point);
            index++;
        }
        X2BonusUIIcon();
        ShieldBonusUIIcon();
    }

    //bonus icons
    private void ShieldBonusUIIcon()
    {
        if(shield)
        {
            shieldBonusIcon.SetActive(true);
            shieldBonusText.text = Mathf.RoundToInt(shieldDur).ToString();
        }
        else
        {
            shieldBonusIcon.SetActive(false);
        }
    }
    private void X2BonusUIIcon()
    {
        if(x2bonus)
        {
            x2BonusIcon.SetActive(true);
            x2BonusText.text = Mathf.RoundToInt(x2bonusDur).ToString();
        }
        else
        {
            x2BonusIcon.SetActive(false);
        }
    }

    //Add duck in tail
    private void AddDuck()
    {
        GameObject duck = Instantiate(newDuck);
        jointParts.Add(duck);
    }
    //Add start duck in tail
    private void AddStartDuck()
    {
        GameObject duck = Instantiate(startDuck);
        jointParts.Add(duck);
    }

    //Eat fruit and add duck or check collision with an wall, duck or waterlily
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Shield"))
        {
            Destroy(other.gameObject);
            shieldDur += 10;
        }
        if(other.CompareTag("X2"))
        {
            Destroy(other.gameObject);
            x2bonusDur += 5;
        }
        if(other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            AddDuck();
            SpawnNewFruit();
            ScoreCount(1);
        }
        if(other.CompareTag("Wall") || other.CompareTag("Tail"))
        {
            GetComponent<Pause>().PauseGame();
            endGameStats.SetActive(true);
            scoreText.gameObject.SetActive(false);
            highScoreText.text = score.ToString();

        }
        if(other.CompareTag("WaterLily"))
        {
            if(jointParts.Count!=0 && !shield)
            {
                int lastDuck = jointParts.Count;
                Destroy(jointParts[lastDuck-1]);
                jointParts.Remove(jointParts[lastDuck-1]);
                Destroy(other.gameObject);
                ScoreCount(-2);
            }
        }
    }

    private void ShieldAction()
    {
        if(shieldDur < 0) shieldDur = 0;
        if(shieldDur > 0) shield = true;
        else shield = false;
        shieldDur -= Time.deltaTime;
    }

    //Get random position for new fruit
    private void GetFruitPos()
    {
        fruitPos = new Vector3(Random.Range(-27,27), 0f, Random.Range(-27,27));
    }
    //Spawn new fruit in random position
    private void SpawnNewFruit()
    {
        GetFruitPos();
        Instantiate(fruits[Random.Range(0, fruits.Length)], fruitPos, Quaternion.identity);
    }
    //Spawn waterlily
    IEnumerator SpawnWaterLily()
    {
        GetFruitPos();
        Instantiate(waterLily, fruitPos, Quaternion.identity);
        yield return new WaitForSeconds(7f);
        StartCoroutine(SpawnWaterLily());
    }
    //Spawn bonus
    IEnumerator SpawnBonus()
    {
        GetFruitPos();
        Instantiate(bonus[Random.Range(0, bonus.Length)], fruitPos, Quaternion.identity);
        yield return new WaitForSeconds(18f);
        StartCoroutine(SpawnBonus());
    }
    //Count score
    public void ScoreCount(int mod)
    {
        if(x2bonus && mod > 0) mod *= 2;
        score += mod;
    }

    //x2 bonus action
    private void X2bonusAction()
    {
        if(x2bonusDur < 0) x2bonusDur = 0;
        if(x2bonusDur > 0) x2bonus = true;
        else x2bonus = false;
        x2bonusDur -= Time.deltaTime;
    }

    public void RestartGame()
    {
        GetComponent<Pause>().ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}