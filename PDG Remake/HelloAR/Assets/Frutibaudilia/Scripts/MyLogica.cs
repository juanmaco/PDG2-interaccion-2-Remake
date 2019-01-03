using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample { 
public class MyLogica : MonoBehaviour {
        public OnClick[] myButtons;
        public List<int> colorList;

        public float showTime = 0.5f;
        public float pauseTime =0.2f;

        bool maquina = false;
        public bool player = false;
        bool gameO = false;

        private int myRandom;
        public int level = 1;
        private int playerLevel;
        

	// Use this for initialization
	void Start () {
            playerLevel = 0;
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
                if(playerLevel == level)
                {
                    level += 1;
                    playerLevel = 0;
                    maquina = true;
                }
            }
        }
	
	// Update is called once per frame
	void Update () {
            if (maquina)
            {
                player = false;
                maquina = false;
                StartCoroutine(Robot());
            }
            if(player == false && gameO == false)
            {
               //vacio legal 
            }
            if(player== true)
            {
                //vacio legal2
            }
	}
        IEnumerator Robot()
        {
            for(int i =0; i<level; i++)
            {
                if( colorList.Count < level)
                {
                    myRandom = Random.Range(0, myButtons.Length);
                    colorList.Add(myRandom);
                }
                yield return new WaitForSeconds(0.3f);
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