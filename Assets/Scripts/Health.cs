using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float StartingHealth; //Ba�lang��taki sa�l�k durumu
    public float CurrentHealth { get; private set; } //�u anki sa�l�k durumu
    public bool dead; //Karakter �ld� m� durumu
    private void Awake()
    {
        CurrentHealth = StartingHealth;
    }
    public void takeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealth);
        if (CurrentHealth > 0)//karakterin can� 0dan b�y�k ise Karakterin can� azalacak
        {

        }
        else//Karakterin can� 0 oldu�unda, Karakter �lecek.
        {
            if (!dead)
            {
                GetComponent<CharacterController>().enabled = false; //karakter �ld���nde hareket etmesin.
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
