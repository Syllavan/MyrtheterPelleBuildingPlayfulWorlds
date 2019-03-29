using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour
{

    public float baseAttack;
    public float curAttack;

    public bool isDead;

    public GameObject selectedUnit;
    public EnemyStats enemyStatsScripts;

    public bool behindEnemy;
    public bool canAttack;

    public GameObject RangedSpellPrefab;

    //public ManagerGame ManagerGame;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectTarget();
        }

        if (selectedUnit != null)
        {
            Vector3 toTarget = (selectedUnit.transform.position - transform.position).normalized;
            //Check if player is behind enemy 
            if (Vector3.Dot(toTarget, selectedUnit.transform.forward) < 0)
            {
                behindEnemy = false;
            }
            else
            {
                behindEnemy = true;
            }

            //calculate if player is facing enemy and is within attacking distance
            float distance = Vector3.Distance(this.transform.position, selectedUnit.transform.position);
            Vector3 targetDir = selectedUnit.transform.position - transform.position;
            Vector3 foward = transform.forward;
            float angle = Vector3.Angle(targetDir, foward);

            if (angle > 60.0)
            {
                canAttack = true;
            }
            else
            {
                if (distance < 60)
                {
                    canAttack = false;
                }
                else {
                    canAttack = false;
                }
            }
        }

        if (Input.GetKeyDown("2"))
            RangedAttack();
    

    if (Input.GetKeyDown("1"))
        {
            if (selectedUnit != null && canAttack)
                BasicAttack();
               
        }



    }




    void SelectTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);         RaycastHit hit;          if (Physics.Raycast(ray, out hit, 10000))
        {              if (hit.transform.tag == "enemy")             {                 selectedUnit = hit.transform.gameObject;

                enemyStatsScripts = selectedUnit.transform.gameObject.transform.GetComponent<EnemyStats>();             }         }
    }

    void BasicAttack()
    {
        enemyStatsScripts.ReceiveDamage(10);
    }



    void RangedAttack()
    {
        enemyStatsScripts.ReceiveDamage(10);
        Vector3 SpawnSpellLoc = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);

        GameObject clone;
        clone = Instantiate (RangedSpellPrefab, SpawnSpellLoc, Quaternion.identity);
        clone.transform.GetComponent<RangedSpell>().Target = selectedUnit;
    }




}
