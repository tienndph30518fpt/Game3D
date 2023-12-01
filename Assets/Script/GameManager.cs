using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score;
    public int blood = 100;
    public AudioSource death;
    [SerializeField]GameObject panelGameOver;
    [SerializeField]GameObject panelPause;
    [SerializeField]GameObject panelWin;
    public static GameManager inst;
    [SerializeField]Text textScore;
    [SerializeField] Robot robot;
    [SerializeField] Text textBlood;
    [SerializeField] Slider mau;
    [SerializeField]GameObject mauHienThi;
    
    
    public Gradient Gradient;// hiển thị màu theo lượng máu
    public Image fillcoler;// backgruond hiển thị máu
    private void Start()
    {
        // textBlood.text = "Blood: " + blood;
        mau.value = blood;
    }

    public void IncrementScore()
    {
        score++;
        textScore.text = "Score: " + score;
        robot.speed += robot.speedIncresePerPonit;
        if (score == 50)
        {
            Time.timeScale = 0;
            panelWin.SetActive(true);
        }
    }

    public void Health()
    {
        if (score >= 2)
        {
            score -= 2;
            textScore.text = "Score: " + score;
        }
        blood -= 20;
        mau.value = blood;
        textBlood.text = "Blood: " + blood;
        fillcoler.color = Gradient.Evaluate(mau.normalizedValue);// cập nhật hiển thị máu theo màu
        if (blood <= 0)
        {
            
            mauHienThi.SetActive(false);
            death.Play();
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
        }
    }
    public void Fall()
    {
        
        score = 0;
        textScore.text = "Score: " + score;
        blood = 0;
        textBlood.text = "Blood: " + blood;
        if (blood <= 0)
        {
         
            Debug.Log("Fall-gameMana");
            Time.timeScale = 0;
            panelGameOver.SetActive(true);
        }
    }
    
    private void Awake()
    {
        inst = this;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        Debug.Log("Restart()"+Time.timeScale);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    
    public void Continue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

}
