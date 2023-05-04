using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100f, followRange, turnSpeed, speed;
    private GameObject _player;
    private bool following = false;
    [SerializeField] private Animator _anim;
    private bool dead = false;

    // Start is called before the first frame update



    void Start()
    {
        _player = PlayerController.instance;
        //Animator _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead) 
        {
            var distance = Vector3.Distance(_player.transform.position, transform.position);
            if (distance < followRange && distance > 0.5f)
            {
                LookAtPlayer();
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);

                following = true;
            }
            else
            {
                following = false;

            }

            if (following) _anim.SetFloat("speed", 1);

            else _anim.SetFloat("speed", 0);

            if (health <= 0f)
            {
                dead = true;
                _anim.SetBool("death", true);
                Destroy(gameObject, 4f);

            }
        }


        

        
    }

    private void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(_player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
    }

    public void damage(float amount)
    {
        health -= amount;
    }
}
