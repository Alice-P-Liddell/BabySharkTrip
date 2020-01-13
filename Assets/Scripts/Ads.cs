using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{

    string gameId = "1234567";
    bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
}