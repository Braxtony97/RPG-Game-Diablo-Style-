using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    private Vector3 position;
    public float speed;
    public CharacterController controller;
    public AnimationClip run;
    public AnimationClip idle;
    private Animation anim;
    public LayerMask layerWithoutEnemy;
    public static bool attack;
    public Collider cold;
    public EnemyBehaviour enemy;

    public static Vector3 cursorPosition;
    //содержит позицию курсора

    public static Vector3 currentPosition;

    //public GameObject NPC;


    void Start()
    {
        transform.position = DataBase.readPlayerPosition();
        anim = GetComponent<Animation>();
        LayerMask NotMask = ~ layerWithoutEnemy;
        cold = GetComponent<Collider>();


    }

    void Update ()
    {
        locateCursor();
        //Debug.Log(attack);
        if (!attack)
        {
            if (Input.GetMouseButton(0))
            {
                locatePosition();
                moveToPosition();
            }
            else
            {
                anim.CrossFade(idle.name);
            }
        }
        else
        {

        }
        currentPosition = transform.position;
        

    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy")  
                    { 
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    }
            if (hit.collider.tag =="Enemy")
            {
                transform.LookAt(enemy.transform.position);
            }
        }
    }

    void locateCursor()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            cursorPosition = hit.point;
        }
    }

    void moveToPosition() {
        if (Vector3.Distance(transform.position, position) > 0.5) { 
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position); // высчитали новый угол
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10); //transform.rotation - текущий поворт.
            //поворачиваем игрока
            controller.SimpleMove(transform.forward * speed);

            //anim.CrossFade(run.name);
            anim.CrossFade("run");
        }
        
    }
}
