using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject square;
    public Text timeTxt;
    float time = 0f;
    public GameObject endPanel;
    public Text NowScore;
   
    bool isPlay = true;
    
    public static GameManager Instance;
    public Text bestScore;

    string key = "bestScore";

   public Animator anim;
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("MakeSquare", .0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }
    void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        anim.SetBool("isDie", true);
        // Time.timeScale = 0.0f;

        Invoke("timeStop", .5f);
        endPanel.SetActive(true);
       
        NowScore.text = time.ToString("N2");
        
        
        //if (PlayerPrefs.HasKey("bestscore") == false)
        //{
        //    PlayerPrefs.SetFloat("bestscore", time);

        //}
        //else
        //{
        //    if (time > PlayerPrefs.GetFloat("bestscore"))
        //    {
        //        PlayerPrefs.SetFloat("bestscore", time);
        //    }
        //}

        //�ְ� ������ �ִٸ�
        if(PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);

            // �ְ�����< ���� ����
            if(best < time)
            {
                // ���� ������ �ְ� ������ �����Ѵ�.
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = time.ToString("N2");
            }
            else
            {
                bestScore.text = time.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScore.text = time.ToString("N2");
        }


        float maxScore = PlayerPrefs.GetFloat(key);
        bestScore.text = maxScore.ToString("N2");
    }

    //public void retry()
    //{ SceneManager.LoadScene("MainScene"); }




    void timeStop()
    { Time.timeScale = 0f; }



}




