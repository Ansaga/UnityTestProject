using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

  public int score = 0;
  public int count = 0;
  public Text textScore;
  public Text textCount;

  void Start() {
    textCount = GameObject.Find("TextCount").GetComponent<Text>();
    textScore = GameObject.Find("TextScore").GetComponent<Text>();
  }

  public void SetCollect(int cscore){
    count++;
    score += cscore;
    Debug.Log("count: " + count);
    Debug.Log("score: " + score);
    if(textCount != null)
      textScore.text = score.ToString();
    if(textCount != null)
      textCount.text = count.ToString();
  }
}
