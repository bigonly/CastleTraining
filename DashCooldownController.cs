using UnityEngine;
using UnityEngine.UI;

public class DashCooldownController : MonoBehaviour
{
    public GameObject DashCooldownUI;

    public Slider slider;
    public Image fill;

    public DashController dashController;

    public void IsDashActive()
    {
        //slider.value = stamina;
        DashCooldownUI.SetActive(true);
    }

    public void IsDashCooldown(float stamina)
    {
        slider.value = stamina;
        if (slider.value == 0) DashCooldownUI.SetActive(false);
    }
}
