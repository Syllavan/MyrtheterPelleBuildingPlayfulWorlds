using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSpell : MonoBehaviour
{
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target!= null)
        {
            Vector3 targetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z);
            this.transform.LookAt(targetPosition);

            float distance2 = Vector3.Distance(Target.transform.position, this.transform.position);

            if (distance2 > 2.0f)
            {
                transform.Translate(Vector3.forward * 30.0f * Time.deltaTime);
            }
            else
            {
                HitTarget();
            }
        }

    }
    void HitTarget()
    {
        Destroy(this.gameObject);
    }
}
