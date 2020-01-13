/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct UserId
{
    public string id;
    public string username;
}

struct UserScore
{
    public string id;
    public int score;
}

public class Network : MonoBehaviour
{
    

    public void GetServerID(string username, ParticleSystemOverlapAction success, Action )

    //서버에서 Server ID 받기
    IEnumerator GetServerIDCoroutine(string username, Action success, Action fail)
    {
        UnityWebRequest www = UnityWebRequest.Get("localhost:3000/users/new/" + username);
        if(www.isNetworkError || www.isHttpError)
        {
            //ID를 저장
            PlayerPrefs.SetString("id", resultobj.id);
            PlayerPrefs.SetString("username", )
        }
        else
        {

        }

    }

    public void UpdateBestScore(int bestscore)
    {
        StartCoroutine(UpdateBestScoreCoroutine(bestScore));
    }

    IEnumerator UpdateBestScoreCoroutine(string id, int bestScore)
    {
        UserScore userScore = new UserScore { id = id, score = bestScore };

        string postData = JsonUtility.ToJson(userScore);

        UnityWebRequest www = UnityWebRequest.Post("localhost:3000/score/add", postData);

        www.SetRequestHeader("Content-Type", "application/json");
        www.method = "POST";
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
*/