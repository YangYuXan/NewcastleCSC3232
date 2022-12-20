using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    public Text score;
    GameObject obj;
    PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("player");
        playerState = obj.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        SetText(playerState.GetScore());
    }

    public void SetText(string text)
    {
        score.text = "Score: "+text;
    }
}
