using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    public Texture2D actionBar;
    public Rect position;
    //позиция actionBar

    public SkillSlot[] skill;

    public float skillX;
    public float skillY;
    public float skillWidth;
    public float skillHeight;
    public float skillDistance;
    
    void Start()
    {
        initialize();
    }

    void initialize()
    {
        SpecialAttack[] attacks  = GameObject.FindGameObjectWithTag("Player").GetComponents<SpecialAttack>();
        skill = new SkillSlot[attacks.Length];
        for (int count = 0; count < attacks.Length; count++)
        {
            skill[count] = new SkillSlot();
            skill[count].skill= attacks[count];
        }
        skill[0].setKey(KeyCode.Q);
        skill[1].setKey(KeyCode.W);
        skill[2].setKey(KeyCode.E);
    }
    // Update is called once per frame
    void Update()
    {
        updateSkillSlots();
    }

    void updateSkillSlots()
    {
        for ( int count = 0; count < skill.Length; count++)
        {
            skill[count].position.Set((skillX + count * (skillWidth + skillDistance)), skillY, skillWidth, skillHeight);
        }
    }

    private void OnGUI()
    {
        drawActionBar();
        drawSkillSlot();
    }

    public void drawActionBar()
    {
        GUI.DrawTexture(getScreenRect(position), actionBar);
    }

    public void drawSkillSlot()
    {
        for (int count = 0; count < skill.Length; count++)
        {
            GUI.DrawTexture(getScreenRect(skill[count].position), skill[count].skill.picture);
        }
    }

    Rect getScreenRect(Rect position)
    {
        return new Rect(Screen.width * position.x, Screen.height * position.y, Screen.width * position.width, Screen.height * position.height);
    }
}
