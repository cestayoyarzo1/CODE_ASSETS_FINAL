using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject sender, target, source, hit;


	void Start ()
    {
        sender = GameObject.FindGameObjectWithTag("Player");
        source = GameObject.FindGameObjectWithTag("Ring");
        target = sender.GetComponent<UnitController>().GetTarget();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate((target.GetComponentInChildren<Collider>().bounds.center - transform.position).normalized * speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(hit, transform.position, transform.rotation);
        //print("direct hit");
        Transform hitEnemy = collision.transform.root;
        if (hitEnemy.tag.Equals("Enemy"))
        {
            print("enemy taking damage");
            float damage = Random.Range(100, 500);
            hitEnemy.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
        }
        Instantiate(hit, collision.collider.bounds.center, transform.rotation);
        Destroy(gameObject);  
    }
}
