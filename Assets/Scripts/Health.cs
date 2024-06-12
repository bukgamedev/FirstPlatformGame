using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float StartingHealth; //Baþlangýçtaki saðlýk durumu
    public float CurrentHealth { get; private set; } //Þu anki saðlýk durumu
    public bool dead; //Karakter öldü mü durumu
    private void Awake()
    {
        CurrentHealth = StartingHealth;
    }
    public void takeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealth);
        if (CurrentHealth > 0)//karakterin caný 0dan büyük ise Karakterin caný azalacak
        {

        }
        else//Karakterin caný 0 olduðunda, Karakter ölecek.
        {
            if (!dead)
            {
                GetComponent<CharacterController>().enabled = false; //karakter öldüðünde hareket etmesin.
                dead= true;
            }

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            takeDamage(1);
        }
    }
}
