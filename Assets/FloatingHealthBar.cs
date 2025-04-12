using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] UnitAction unitAction;
    [SerializeField] Image hpColor;

    private void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        slider.value = unitAction.health / unitAction.maxHealth;
        hpColor.color = new Color(0, 1, 0, unitAction.health / unitAction.maxHealth);
    }
}
