using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    
    public float Speed;
    public CharacterController Controller;
    public AnimationClip Run;
    public AnimationClip Idle;
    public LayerMask LayerWithoutEnemy;
    public static bool Attack;
    public Collider Cold;
    public EnemyBehaviour Enemy;
    public static Vector3 CursorPosition;
    public static Vector3 CurrentPosition;
    public GetMousePosition getMousePosition;

    private Vector3 _position;
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        Cold = GetComponent<Collider>();
        
    }
    private void Start()
    {
        transform.position = DataBase.readPlayerPosition();  
        LayerMask NotMask = ~ LayerWithoutEnemy;
        getMousePosition = new GetMousePosition();
        
    }

    void Update ()
    {
        //locateCursor();
        //Debug.Log(Attack);
        if (!Attack)
        {
            if (Input.GetMouseButton(0))
            {
                //locatePosition();
                //_position = getMousePosition.MousePosition();
                moveToPosition();
            }
            else
            {
                _animation.CrossFade(Idle.name);
            }
        }
        else
        {

        }
        CurrentPosition = transform.position;
        

    }

    /*void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player" && hit.collider.tag != "Enemy")  
                    { 
            _position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    }
            if (hit.collider.tag =="Enemy")
            {
                transform.LookAt(Enemy.transform.position);
            }
        }
    }*/

    /*void locateCursor()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            CursorPosition = hit.point;
        } 
    }*/

    void moveToPosition() {
        if (Vector3.Distance(transform.position, _position) > 0.5) { 
            Quaternion newRotation = Quaternion.LookRotation(_position - transform.position); // высчитали новый угол
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10); //transform.rotation - текущий поворт.
            //поворачиваем игрока
            Controller.SimpleMove(transform.forward * Speed);

            //_animation.CrossFade(Run.name);
            _animation.CrossFade(Run.name);
        }
        
    }
}
