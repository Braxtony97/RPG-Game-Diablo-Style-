using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public GameObject opponent;
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.Play("attack");
            transform.LookAt(opponent.transform.position);
            ClickToMove.attack = true;
        }
        if (!anim.IsPlaying("attack")){
            ClickToMove.attack = false;
        }
    }

}

