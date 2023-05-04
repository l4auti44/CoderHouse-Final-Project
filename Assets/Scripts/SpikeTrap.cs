using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private BoxCollider _boxColl;
    private Animator _anim;
    public float woodCost, stoneCost;
    // Start is called before the first frame update
    void Start()
    {
        _boxColl = GetComponent<BoxCollider>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            _anim.SetTrigger("Enemy");
            other.gameObject.GetComponent<Enemy>().damage(100f);
        }
    }
}
