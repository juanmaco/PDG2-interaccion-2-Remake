using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample { 
public class OnClick : MonoBehaviour {
    public Material lMaterial;
    public Material nMaterial;
    private Renderer mReneder;
    private Vector3 myTp;
    public int myNumber = 99;
    public delegate void ClickEv(int number);
    public MyLogica gameLog;
    public AudioSource mySound;
    public SampleImageTargetBehaviour myTarget;
        bool seeActivo;
        public Animator anim;
        public int numeroAnim;

        public event ClickEv onClick;
      
        // Use this for initialization
        void Start () {
            mReneder = GetComponent<Renderer>();
            mReneder.enabled=true;
            myTp = transform.position;
            seeActivo = false;
            anim.SetInteger("Cauca", 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
        public void OnMouseDown()
        {
           if(gameLog.player == true)
            {
                ClickedColor();
                transform.position = new Vector3(myTp.x, myTp.y, myTp.z);
                onClick.Invoke(myNumber);
                StartCoroutine(Sound());
                StartCoroutine(Animacion());
            }
        }
        public void OnMouseUp()
        {
            UnclickedColor();
            transform.position = new Vector3(myTp.x, myTp.y, myTp.z);
        }
        public void ClickedColor()
        {
            mReneder.sharedMaterial = lMaterial;
            transform.position = new Vector3(myTp.x, myTp.y , myTp.z);
        }
        public void UnclickedColor()
        {
            mReneder.sharedMaterial = nMaterial;
            transform.position = new Vector3(myTp.x, myTp.y, myTp.z);
        }
        IEnumerator Sound()
        {
            mySound.Play();
            yield return new WaitForSeconds(.5f);
        }
        IEnumerator Animacion()
        {
            anim.SetInteger("Cauca", numeroAnim);
            yield return new WaitForSeconds(0.6f);
            anim.SetInteger("Cauca", 0);
            yield return new WaitForSeconds(0.2f);
        }
    }
}