using UnityEngine;


public class Fighter : MonoBehaviour
{
    public GameObject Opponent; 
    public int Rename;
    public double ImpactTime;
    public float Range;
    public int Health;
    public bool InAction;
    public int MaxHealth;
    public float CombatEscapeTime;
    public float CountDown;
    public bool SpecialAttack;

    private Animation _animation;
    private bool _impacted;
    private bool _starterd;
    private bool _ended;
 
    void Start()
    {
        Health = MaxHealth;
        _animation = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !SpecialAttack)
        {
            InAction = true;
        }
        if (InAction)
        {
            if (attackFunction(0, 1, KeyCode.Space, null, 0, true))
            {
                //������������� attackFunction(0, 1, KeyCode.Space)
                //����� �� ������ fasle - ���� ����
            }
            else
            {
                InAction = false;
            }
        }
        die();

    }

    public bool attackFunction(int stunSecond, double scaleDamage, KeyCode key, GameObject particleEffects, int projectile, bool opponentBased)
    {

        {
            if (opponentBased)
            //���� ���� true, ��  ������� �����
            {
                if (Input.GetKey(key) && inRange())
                {
                    _animation.Play("Attack");
                    //ClickToMove.Attack = true;
                    if (Opponent != null)
                    {
                        transform.LookAt(Opponent.transform.position);
                    }
                }
            }
            else
            {
                //���� ����� ���, �� � ������� inRange() �� �����
                if (Input.GetKey(key))
                {
                    _animation.Play("Attack");
                    //ClickToMove.Attack = true;

                       // transform.LookAt(ClickToMove.CursorPosition);
                }
            }
        }

        if (_animation["Attack"].time > 0.9 * _animation["Attack"].length)
        {
            //ClickToMove.Attack = false; // ��� ����, ��� �� ����� ����� ����� ���� ��������� ���������� ������
            _impacted = false;
            if (SpecialAttack)
            {
                SpecialAttack = false;
            }
            //���� ����� ����� �� �����, �� ����� ����, ��� ������ 1 ��� ���������, �� 
            //����� �� ������ ������������ ������� �����
            return false;
            // ����� ����� ����������� - false, 
        }
        impact(stunSecond, scaleDamage, particleEffects, projectile, opponentBased);
        //�������� ����� � ���������� ����� impact
        return true;
        //������ true, ���� �� � ������� ��� (inAction (specialAttack))
    }

    public void resetAttackFunction()
    {
        //ClickToMove.Attack = false;
        _impacted = false;
        _animation.Stop("Attack");

    }

    void impact(int stunSecond, double scaleDamage, GameObject particleEffects, int projectile, bool opponentBased)
    {
        if ((!opponentBased || Opponent != null) && _animation.IsPlaying("Attack") && !_impacted)
        {
            if ((_animation["Attack"].time > _animation["Attack"].length * ImpactTime) && (_animation["Attack"].time < _animation["Attack"].length * 0.9))
            {
                {
                    CountDown = CombatEscapeTime;
                    CancelInvoke("combatEscapeCountDown");
                    InvokeRepeating("combatEscapeCountDown", 0, 1);
                    Opponent.GetComponent<EnemyBehaviour>().GetHit(Rename * (int)scaleDamage);
                    Opponent.GetComponent<EnemyBehaviour>().getStun(stunSecond);
                    Quaternion rot = transform.rotation;
                    rot.x = 0;
                    rot.z = 0;
                    if (projectile > 0 )
                    {
                        //project projectiles
                        Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y * 2.5f, transform.position.z), rot);
                    }
                    //Instantiate(Resources.Load("attackOne"), opponent.transform._position, Quaternion.identity);
                    if (particleEffects != null)
                    {
                        Instantiate(particleEffects, new Vector3(Opponent.transform.position.x, Opponent.transform.position.y * 2.5f, Opponent.transform.position.z), Quaternion.identity);
                    } 
                    _impacted = true;
                }
            }
        }
    }

    void combatEscapeCountDown()
    {
        CountDown = CountDown - 1;
        if (CountDown == 0)
        {
            CancelInvoke("combatEscapeCountDown");
            //��������� �������� ����� 
        }
    }

    bool inRange()
    {
        if (Opponent != null & Vector3.Distance(transform.position, Opponent.transform.position) <= Range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void getHit(int damage)
    {
        Health = Health - damage;
        if (Health < 0)
        {
            Health = 0;
        }
        //���� �� �������� ���� � if, �� �������� ����� ����������� ������ ( � �����)

    }
    public bool isDead()
    {
        return (Health <= 0);
    }
    void die()
    {
        if (isDead() && !_ended)
        // ���� � ������ ����������� ��������
        {
            if (!_starterd)
            {
                _animation.Play("die");

                _starterd = true;
            }
            if (_starterd && _animation.IsPlaying("die"))
            {
                _ended = true;
            }
        }
    }
}
