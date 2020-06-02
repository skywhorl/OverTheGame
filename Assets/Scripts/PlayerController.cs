using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Xforce = 1.5f;
    [SerializeField] private float Yforce = 6;

    private Rigidbody2D objRigidbody;

    public GameObject TabToJump;
    public GameObject Result;

    public GameObject player;

    private AudioSource audio;
    public AudioClip jump;
    public AudioClip bump;
    [HideInInspector]
    public int bestscore = 0;
    [HideInInspector]
    public int timeScore;

    public Text currentScore;
    public Text finalScore;
    public Text best;
    public string bestname;


    private bool gamePlay = true;
    private bool scoreCheck = true;

    public bool die;
    public CompositeCollider2D coll;

    private Vector2 MousePos = Vector2.zero;


    void Awake()
    {
        objRigidbody = GetComponent<Rigidbody2D>();
        objRigidbody.isKinematic = true;
        GetBestscore();
    }

    public void SetBestscore(int score)
    {
        if (bestscore < score)
        {
            bestscore = score;
            PlayerPrefs.SetInt(bestname, bestscore);
        }
    }

    public int GetBestscore()
    {
        return bestscore = PlayerPrefs.GetInt(bestname);
    }

    void Start()
    {
        die = false;
        audio = GetComponent<AudioSource>();
        Result.SetActive(false);
        coll = FindObjectOfType<CompositeCollider2D>();
        timeScore = 0;
        currentScore.text = timeScore.ToString();
        finalScore.text = "Score : ";
        best.text = "Best : " + bestscore.ToString();
        currentScore.enabled = false;
        scoreCheck = true;
    }

    void Update()
    {
        if (!die)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 처음 눌렀을 때 플레이 설정
                if (gamePlay)
                {
                    // Tab To Jump 가리고 점수 보이게 하기
                    currentScore.enabled = true;
                    TabToJump.SetActive(false);
                    // 물리효과 활성화, 속력 0으로 초기화
                    objRigidbody.isKinematic = false;
                    objRigidbody.velocity = Vector2.zero;

                    gamePlay = false;
                }
                // 마우스가 점프하는 물체 기준에서 누른 위치에 따라 좌우로 점프, 점프 시 점프 효과음 재생
                MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (MousePos.x > 0)
                {
                    objRigidbody.velocity = new Vector2(Xforce, Yforce);
                }
                else
                {
                    objRigidbody.velocity = new Vector2(-Xforce, Yforce);
                }
                // 점프 효과음
                audio.PlayOneShot(jump, 1.0f);
                // 점수 계산
                if (scoreCheck)
                {
                    StartCoroutine(SetScore());
                    scoreCheck = false;
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽에 부딪힐 시
        if (collision.collider.tag != "Barrier")
        {
            objRigidbody.freezeRotation = false;
            // 죽는 효과와 딜레이를 둔 후 점수 계산
            DeadEffect();
            StartCoroutine(SetScore());

            Result.SetActive(true);
            die = true;
            coll.enabled = false;
        }
    }
    // 점수 계산
    IEnumerator SetScore()
    { 
        yield return new WaitForSeconds(1f);
        // 죽으면 점수 보여주고 최고 점수 비교
        if (die)
        {
            currentScore.enabled = false;
            finalScore.text = "Score : " + timeScore.ToString();
            SetBestscore(timeScore);
            best.text = "Best : " + bestscore.ToString();
        }
        // 안 죽었으면 점수 1점 더하기
        else
        {
            timeScore++;
            currentScore.text = timeScore.ToString();
            scoreCheck = true;
        }
    }

    void DeadEffect()
    {
        this.transform.GetComponent<BoxCollider2D>().isTrigger = true;
        // 현재의 움직임을 없앰
        objRigidbody.velocity = Vector2.zero;
        // 아래로 (강하게)떨어지게 함
        objRigidbody.velocity = -Vector2.up * Yforce * 3;
        // 회전을 강하게 함
        objRigidbody.AddTorque(1000f);
        // 죽는 효과음 재생
        audio.PlayOneShot(bump, 1.0f);
    }

    void Reset()
    {
        StartCoroutine(LevelReset());
    }

    IEnumerator LevelReset()
    {
        this.enabled = false;
        yield return new WaitForSeconds(1f);
        // 처음 시작했던 곳으로 돌아감
        Application.LoadLevel(0);
    }
}