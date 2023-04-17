using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot
{
    public SpecialAttack skill;
    public KeyCode key;
    //когда будем нажимать на key - активируется skill
    public Rect position;
    
    public void setKey(KeyCode keyCode)
    {
        if (skill != null)
        {
            
            skill.key = keyCode;
            key = keyCode;
            Debug.Log("пекредали keyCode");
        }
    }
}
