using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider healthSlider;

    public Text healthText;

    public Text AmmoText;

    public Text Name;
    public Text Message;

    public GameObject Nameobject;
    public GameObject MessageObject;

    public GameObject TextToSetActive;

    public Image DamageEffect;
    public float DamageAlpha = .25f, DamageFadeSpeed = 2f;

    public GameObject PauseScreen;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DamageEffect.color.a != 0)
        {
            DamageEffect.color = new Color(DamageEffect.color.r, DamageEffect.color.g, DamageEffect.color.b, Mathf.MoveTowards(DamageEffect.color.a, 0f, DamageFadeSpeed * Time.deltaTime));
        }
    }
    public void ShowDamage()
    {
        DamageEffect.color = new Color(DamageEffect.color.r, DamageEffect.color.g, DamageEffect.color.b, .25f);
    }
}
