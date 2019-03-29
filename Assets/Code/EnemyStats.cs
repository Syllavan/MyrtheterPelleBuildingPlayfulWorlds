using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float curHP;
    public float maxHP;

    public bool isSelected;

    public bool isDead;
    public float respawnTime;
    public GameObject RespawnPointLoc;

    public int value;


   //public bool inCombat;
    //public float wanderTime;
    //public float movementSpeed;

    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       //if (!isDead)
        //{
            //if (Target == null)
            //{
              //  SearchForTarget();

                //if (wanderTime > 0)
                //{
                  //  transform.Translate(Vector3.forward * movementSpeed);
                  //  wanderTime -= Time.deltaTime;
                //}
                //else
                //{
                  //  wanderTime = Random.Range (5.0f, 15.0f);
                  //  Wander();
                //}
           // }
           // else
           // {
           //     FollowTarget();
           // }
       // }


        if (curHP <= 0 && !isDead)
        {
            isDead = true;
            curHP = 0;
            StartCoroutine (Death());
        }

    }

    //void Wander()
    //{
      //  transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
  // }

    //void SearchForTarget()
    //{
      //  Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //Collider[] hitColliders = Physics.OverlapSphere(center, 100);
        //int i = 0;
        //while (i < hitColliders.Length)
       // {
          //  if (hitColliders[i].transform.tag == "Player")
            //{
              //  Target = hitColliders[i].transform.gameObject;
            //}
            //i++;
        //}
    //}

  // void FollowTarget()
    //{
      //  Vector3 targetPosition = Target.transform.position;
      //  targetPosition.y = transform.position.y;
      //  transform.LookAt(targetPosition);

      //  float distance = Vector3.Distance (transform.position, this.transform.position);
      //  if(distance > 30)
      //  {
      //      transform.Translate(Vector3.forward * movementSpeed);
      //  }
   // } 


    public void ReceiveDamage (float dmg)
    {
        curHP -= dmg;

    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(respawnTime);
        FindObjectOfType<ManagerGame>().AddSoul(value);
        Destroy(this.gameObject);
    }

}
