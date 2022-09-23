﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Camera : MonoBehaviour {
	
	public Player player;
	public GameObject Background;
	public GameObject overReset;
	
	// Use this for initialization
	void Start () {
		overReset = GameObject.Find("Background");
		overReset.SetActive(false);
	}
		
	
	// Update is called once per frame
	void Update () {
		if (!player.gameOver) 
		{
			transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
			
		}
		else	
		{
			
			GameEnd();
			
		}
	}
	 
	void GameEnd(){
		// GameObject.Find("Background").SetActive(true);
		overReset.SetActive(true);
	}
	public void Reset()
	{
		
		Debug.Log("Reset");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

