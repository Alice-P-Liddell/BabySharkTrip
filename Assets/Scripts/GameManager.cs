using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Fish fish;
    [SerializeField] GameObject pipes;
    [SerializeField] GameObject title;
    [SerializeField] GameObject overPanel;
    [SerializeField] GameObject touchText;
    [SerializeField] FlashImage flashImage;
    [SerializeField] Text bestRecordText;
    [SerializeField] Text scoreResultText;
    public int score;
    public static GameManager gameManager;

    enum State
    {
        TITLE, READY, PLAY, OVER
    }
    State state;

    void Start()
    {
        state = State.TITLE;

        fish.SetKinematic(true);
        pipes.SetActive(false);
        title.SetActive(true);
        touchText.SetActive(true);
        scoreText.text = null;
    }

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                bestRecordText.text = PlayerPrefs.GetInt("Score").ToString();
                if (Input.GetButtonDown("Fire1")) GameReady();
                break;
            case State.READY:
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.PLAY:
                if (fish.IsDead) GameOver();
                break;
            case State.OVER:
                break;
            default:
                break;
        }

        if (score > PlayerPrefs.GetInt("Score"))
        {
            bestRecordText.text = score.ToString();
        }
    }

    public void GameReady()
    {
        state = State.READY;

        pipes.SetActive(false);
        title.SetActive(false);
        touchText.SetActive(false);
        fish.SetKinematic(true);
        scoreText.text = "Ready?";
        score = 0;
    }

    void GameStart()
    {
        state = State.PLAY;

        fish.SetKinematic(false);
        pipes.SetActive(true);
        scoreText.text = "Go!";
    }

    void GameOver()
    {
        state = State.OVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }

        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
        }

        scoreResultText.text = score.ToString();

        StartCoroutine(SetOverPanel());
    }

    public void IncreaseScore()
    {
        //score++;
        scoreText.text = (++score).ToString();

        if (score > PlayerPrefs.GetInt("Score"))
        {
            bestRecordText.text = score.ToString();
        }
    }

    IEnumerator SetOverPanel()
    {
        Camera.main.SendMessage("Shake");   //메인카메라는 Camera.main 찍어서 접근 가능하다.
        flashImage.StartFlash();
        
        yield return new WaitForSeconds(2f);
        overPanel.SetActive(true);
    }

    public void ClickRetryButton()
    {
        SceneManager.LoadScene("Game");
    }
}
