using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animation Animation;

    private void Start()
    {
        Animation = GameObject.Find("Player").GetComponent<Animation>();
    }
    public void PlayerAttack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Animation.Play("attack");
        }
    }
}
