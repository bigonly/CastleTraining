using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolBarLogic : MonoBehaviour
{
    public float maxCooldown;
    float cooldown;

    public Image SwordBar;
    public Image BowBar;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldown = maxCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCooldown();

        if (Input.GetKey("1")) //для оптимизаций или же удобочитаемости можно будет использовать enum
        {
            UseSwordBar();
        }
        else if(Input.GetKey("2"))
        {
            UseBowBar();
        }
    }

    void CheckCooldown()
    {
        if(cooldown < maxCooldown)
        {
            cooldown += Time.deltaTime;
            float newScale = cooldown / maxCooldown;
            SwordBar.fillAmount = newScale;
            BowBar.fillAmount = newScale;
        }
    }

    //в дальнейшем можно будет создать радительский класс для этих классов
    void UseSwordBar()
    {
        if (cooldown < maxCooldown) return;
        cooldown = 0;
    }
    void UseBowBar()
    {
        if (cooldown < maxCooldown) return;
        cooldown = 0;
    }

}
