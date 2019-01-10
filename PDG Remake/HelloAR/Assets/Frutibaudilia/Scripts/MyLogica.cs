﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sample { 
public class MyLogica : MonoBehaviour {
        public OnClick[] myButtons;
        public List<int> colorList;

        public float showTime = 0.5f;
        public float pauseTime =2f;

        bool maquina = false;
        public bool player = false;
        bool gameO = false;

        private int myRandom;
        public int level = 1;
        private int playerLevel;

        public Text scoreT;
        public Text lifeT;
        int score = 0;
        int life = 3;
        public GameObject mCanvas;
        public GameObject maquinaU;
        public GameObject turnoP;
        public GameObject mVictoria;
        bool showUI = false;

	// Use this for initialization
	void Start () {
            playerLevel = 0;
            turnoP.SetActive(false);
            mCanvas.SetActive(false);
            mVictoria.SetActive(false);
            maquina = true;
            for(int i=0; i<myButtons.Length; i++)
            {
                myButtons[i].onClick += ButtonClicked;
                myButtons[i].myNumber = i;
            }

	}
        void ButtonClicked(int _number)
        {
            if (player == true)
            {
                if (_number == colorList[playerLevel])
                {
                    playerLevel += 1;
                }
                else
                {
                    life -= 1;
                    if(life == 0)
                    {
                        FindObjectOfType<GameManager>().GameOver();
                        player = false;
                        maquina = false;
                    }
                }
                if(playerLevel == level)
                {
                    level += 1;
                    playerLevel = 0;
                    maquina = true;
                    if(level == 5)
                    {
                        maquina = false;
                        player = false;
                        FindObjectOfType<GameManager>().Win();
                    }
                }
            }
        }
	
	// Update is called once per frame
	void Update () {
            scoreT.text = level.ToString();
            lifeT.text = life.ToString();
            if (maquina)
            {
                player = false;
                maquina = false;
                StartCoroutine(Robot());
            }
            if(showUI == false)
            {
                maquinaU.SetActive(true);
                turnoP.SetActive(false);
            }
            else
            {
                maquinaU.SetActive(false);
                turnoP.SetActive(true);
            }
            if(player == true)
            {
                showUI = true;
            }
        }
        IEnumerator Robot()
        {
            showUI = false;
            for(int i =0; i<level; i++)
            {
                if( colorList.Count < level)
                {
                    myRandom = Random.Range(0, myButtons.Length);
                    colorList.Add(myRandom);
                }
                yield return new WaitForSeconds(1f);
                myButtons[colorList[i]].ClickedColor();
                myButtons[colorList[i]].mySound.Play();
                yield return new WaitForSeconds(showTime);
                myButtons[colorList[i]].UnclickedColor();
                yield return new WaitForSeconds(pauseTime);
            }
            player = true;
        }
}
}