using UnityEngine;
using System;

public class Crystal : MonoBehaviour
{
  Game game = null;

  void Start() {
    try{
      game = GameObject.Find("Game").GetComponent<Game>();
    }catch(Exception ex){
      //donothing
    } 
  }

	void OnCollisionEnter(Collision collision) {
    if(game != null)
      game.SetCollect(20);
		Destroy(gameObject);
	}
}
