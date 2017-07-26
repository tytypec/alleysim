using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//Allows us to use UI.
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public float Speed;
    public Animator playerAnimator;
    public Slider HP;
    public Color FullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color ZeroHealthColor = Color.red;
    public Color MidHealthColor = Color.yellow;
    public int StartingHP = 120;
    public Image FillImage;
    public int HPDrainSpeed;
    public Text yumYuck;
    public float periodReset = 1.5f;
    // public Color yum = Color.green;
    // public Color yuck;
    // public Color meh;



    private Rigidbody2D rb;
    private int hitPoints;
    private bool Dead;
    private int appleScore;
    private int PnutScore;
    private float nextActionTime = 0.0f;
    // private int foodEaten;
    //private int InTummy = 1;
    //private float nextFire;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        StartCoroutine(Hunger());

        // foodEaten = InTummy;





        hitPoints = StartingHP;
        Dead = false;

        // Update the health slider's value and color.
        SetHealthUI();
        AllergyAssign();




    }

    IEnumerator Hunger()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            hitPoints = hitPoints - HPDrainSpeed;
            Debug.Log(hitPoints);
            SetHealthUI();
        }
    }


    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(-moveHorizontal, moveVertical);
        rb.velocity = movement * Speed;
        SetHealthUI();




        if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > .1) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > .1))
        {
            playerAnimator.Play("PlayerWalk");


        }

        else
        {
            playerAnimator.Play("PlayerBlink");
        }




        /*if (hitPoints <= 0f && !Dead)
        {
            OnDeath();
        }*/
    }

    public void AllergyAssign()
    {
        //GameManager.appleScore;
        //appleScore = GameManager.appleScoreADJ;
        //PnutScore = -10;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Apple")
        {


            hitPoints += GameManager.appleScoreADJ;
            // hitPoints += appleScore;

            SetHealthUI();
            DidILikeThatFood();

            // SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);


            other.gameObject.SetActive(false);
            Debug.Log("Apple value of" + GameManager.appleScoreADJ);


        }

        if (other.tag == "Pnut")
        {



            hitPoints += GameManager.pnutScoreADJ;

            SetHealthUI();
            DidILikeThatFood();

            // SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);


            other.gameObject.SetActive(false);
        }

        if (other.tag == "Egg")
        {



            hitPoints += GameManager.eggScoreADJ;

            SetHealthUI();
            DidILikeThatFood();

            // SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);


            other.gameObject.SetActive(false);
        }

        if (other.tag == "Milk")
        {



            hitPoints += GameManager.milkScoreADJ;

            SetHealthUI();
            DidILikeThatFood();

            // SoundManager.instance.RandomizeSfx(eatSound1, eatSound2);


            other.gameObject.SetActive(false);
        }
    }

    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        HP.value = hitPoints;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        //FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, hitPoints / StartingHP);

        if (hitPoints > 90f)
            FillImage.color = Color.green;

        if (hitPoints > 40f && hitPoints < 90f)
            FillImage.color = Color.yellow;

        if (hitPoints < 40f)
            FillImage.color = Color.red;
        if (hitPoints < 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        Player.gameObject.SetActive(false);
    }

    public void DidILikeThatFood() { }
    /*{

        if (GameManager.appleScoreADJ >= 3 || GameManager.pnutScoreADJ >= 3 || GameManager.eggScoreADJ >= 3 || GameManager.milkScoreADJ >= 3)
        {
            yumYuck.color = Color.green;
            yumYuck.text = "Yummy";

        }

        if (GameManager.appleScoreADJ > 15 || GameManager.pnutScoreADJ > 15 || GameManager.eggScoreADJ > 15 || GameManager.milkScoreADJ > 15)
        {
            yumYuck.color = Color.green;
            yumYuck.text = "DELISH!";

        }

        if ((GameManager.appleScoreADJ < 3 && GameManager.appleScoreADJ > -3) || (GameManager.pnutScoreADJ < 3 && GameManager.pnutScoreADJ > -3) || (GameManager.eggScoreADJ < 3 && GameManager.eggScoreADJ > -3) || (GameManager.milkScoreADJ < 3 && GameManager.milkScoreADJ > -3))
        {
            yumYuck.color = Color.yellow;
            yumYuck.text = "meh";
        }

        if (GameManager.appleScoreADJ < -3 || GameManager.pnutScoreADJ < -3 || GameManager.eggScoreADJ < -3 || GameManager.milkScoreADJ < -3)
        {
            yumYuck.color = Color.red;
            yumYuck.text = "ew";
        }

        if (GameManager.appleScoreADJ < -15 || GameManager.pnutScoreADJ < -15 || GameManager.eggScoreADJ < -15 || GameManager.milkScoreADJ < -15)
        {
            yumYuck.color = Color.red;
            yumYuck.text = "yuck!";
        }

        if (GameManager.appleScoreADJ < -30 || GameManager.pnutScoreADJ < -30 || GameManager.eggScoreADJ < -30 || GameManager.milkScoreADJ < -30)
        {
            yumYuck.color = Color.red;
            yumYuck.text = "BARFFFF!";
        }

        else
            yumYuck.text = "";
    }


    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += periodReset;

            yumYuck.color = Color.black;
            yumYuck.text = "";

        }
    }*/
}