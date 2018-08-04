using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raisehand : MonoBehaviour {
    Animator anim;

    bool m_handRaised;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        m_handRaised = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(m_handRaised == false)
            {
                anim.ResetTrigger("DropHand");
                anim.SetTrigger("RaiseHand");
                m_handRaised = true;
            } else {
                anim.ResetTrigger("RaiseHand");
                anim.SetTrigger("DropHand");
                m_handRaised = false;
            }        
        }
       
        //if(m_handRaised == true){
        //    anim.SetBool("isHandRaised", true);
        //}

        //if(m_handRaised == false){
        //    anim.SetBool("isHandRaised", false);
        //}
    }
}
