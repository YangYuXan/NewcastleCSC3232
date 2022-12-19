using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int score;
    public UI_Score ui_score;
    public Canvas ui;

    // Start is called before the first frame update
    void Start()
    {
        //ui_score = GetComponent<UI_Score>();
        ui = GetComponentInChildren<Canvas>();
        ui_score = ui.GetComponent<UI_Score>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ui);
        ui_score.SetText(score.ToString());
    }

    public void UpdateScore(int value)
    {
        score += value;
    }
}
