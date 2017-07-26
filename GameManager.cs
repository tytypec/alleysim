using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int appleScoreADJ;
    public static int pnutScoreADJ;
    public static int eggScoreADJ;
    public static int milkScoreADJ;
    public static float oddsMaker;
    public float periodReset = 2f;
    public Vector3 spawnValues;
    //public Vector3 spawnValuesY;
    public GameObject applePre;
    public GameObject nutPre;
    public GameObject milkPre;
    public GameObject eggPre;

    private int allergicValue;
    private int allergicValueA;
    private int allergicValueB;
    private int allergicValueC;
    private float nextActionTime = 0.0f;


    // Use this for initialization
    void Start()
    {

        oddsMaker = Random.value;
        //Debug.Log("oddsMarker" + oddsMaker);

        AllergyOdds();
        AllergyAssignment();



    }



    public void AllergyAssignment()
    {
        appleScoreADJ = allergicValue * (int)Mathf.Round((25 * (Random.value)));

        pnutScoreADJ = allergicValueA * (int)Mathf.Round(50 * (Random.value));

        eggScoreADJ = allergicValueB * (int)Mathf.Round(30 * (Random.value));

        milkScoreADJ = allergicValueC * (int)Mathf.Round(30 * (Random.value));
    }

    private void AllergyOdds()
    {

        oddsMaker = Random.value;
        Debug.Log("oddsMarker" + oddsMaker);

        // apple and pnut allergy
        if (oddsMaker < .3f)
        {
            allergicValue = -1;
            allergicValueA = 1;
        }

        else
        {
            allergicValue = 1;
            allergicValueA = 1;
        }

        //Egg Allergy
        if (oddsMaker < .5f && oddsMaker > .9f)
            allergicValueB = 1;

        else
            allergicValueB = -1;

        //Milk Allergy
        if (oddsMaker < .8f)
            allergicValueC = -1;

        else
            allergicValueC = 1;

        //if (oddsMaker > .3f)
        //allergicValue = 1;
    }


    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime += periodReset;
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 1);
            //Vector3 spawnPosition = new Vector3(1f, 1f, 1f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(applePre, (spawnPosition), spawnRotation);

            Vector3 spawnPositionA = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 1);
            Instantiate(nutPre, (spawnPositionA), spawnRotation);

            Vector3 spawnPositionB = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 1);
            Instantiate(eggPre, (spawnPositionB), spawnRotation);

            Vector3 spawnPositionC = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 1);
            Instantiate(milkPre, (spawnPositionC), spawnRotation);


            //Instantiate(nutPre, (spawnPosition), spawnRotation);
            //Instantiate(eggPre, (spawnPosition), spawnRotation);
            //Instantiate(milkPre, (spawnPosition), spawnRotation);
            //Debug.Log("allergicValue" + allergicValue);
        }


    }
}
