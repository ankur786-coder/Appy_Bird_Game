using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float force = 100;
    private Rigidbody2D prigi;
    public float health = 3f;
    //public float speed = 10;
    private Animator anim;
    public TMPro.TextMeshProUGUI HealthText;
    public TMPro.TextMeshProUGUI GoldText;
    public float Gold = 0;
    public AudioClip[] Audios;
    public string prefsHighScore = "TheHighScore";
    public float Score;
    public float HighScore;
    public TMPro.TextMeshProUGUI ScoreText;
    public TMPro.TextMeshProUGUI HighScoreText;
    public float scoreSpeed=1f;
    public GameObject loosePanel;
    private void Awake()
    {
        instance = this;
        prigi = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        HealthText.text = health + "";
        GoldText.text = Gold + "";
        loosePanel.SetActive(false);
    }

    void Start()
    {
        Score = 0f;
        health = 3f;
        Gold = 0;
        HighScore = PlayerPrefs.GetInt(prefsHighScore, 0);
        Time.timeScale = 1;
        HighScoreText.text = "Your High Score is "+HighScore ;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = (int)Score + "";
        GoldText.text = Gold + "";
        HealthText.text = health + "";
        Score += Time.deltaTime * 10f*scoreSpeed;
        //prigi.velocity = transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.anyKey)
        {
            prigi.velocity = transform.up*force;
        }
        if(health <= 0f)
        {
            anim.SetInteger("Animation",1);
            Debug.Log("You dead!");
            loosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddHeart()
    {
        health += 1f;
    }

    public void AddGold()
    {
        Gold += 1f;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gold")
        {
            AddGold();
            PlayPickupSound();
            Debug.Log("Our Gold is " + Gold);
            Destroy(collision.gameObject);
        }
    }

    public void PlayhitSound()
    {
        AudioSource.PlayClipAtPoint(Audios[0], new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }

    public void PlayPickupSound()
    {
        AudioSource.PlayClipAtPoint(Audios[1], new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }

    private void OnDisable()
    {
        if(Score > HighScore)
        {
            PlayerPrefs.SetInt(prefsHighScore, (int)Score);
        }
    }


}
