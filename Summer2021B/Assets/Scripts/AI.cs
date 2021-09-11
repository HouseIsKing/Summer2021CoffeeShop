using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent navMeshAgent;
    public GameObject chairTarget;
    Animator animationController;
    float timePassed = 0;
    public int behaviourNum;
    Vector3 startPos;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animationController = GetComponent<Animator>();
        animationController.SetBool("SitDown", false);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(behaviourNum == 0)
        {
            animationController.SetFloat("Speed", navMeshAgent.velocity.magnitude);
            if (chairTarget != null)
            {
                navMeshAgent.SetDestination(chairTarget.transform.position + chairTarget.transform.forward);
                if (timePassed > 2 && Vector3.Distance(chairTarget.transform.position + chairTarget.transform.forward, transform.position) < 0.3)
                {
                    animationController.SetBool("SitDown", true);
                    RotateTowards(chairTarget.transform);
                }
            }
            if (timePassed > 10)
            {
                animationController.SetBool("SitDown", false);
                timePassed = 0;
            }
            timePassed += Time.deltaTime;
        }
        if(behaviourNum == 1)
        {
            animationController.SetFloat("Speed", navMeshAgent.velocity.magnitude);
            Vector3 target;
            if(timePassed < 13)
            {
                target = chairTarget.transform.position + chairTarget.transform.forward;
            }
            else
            {
                target = startPos;
            }
            navMeshAgent.SetDestination(target);
            if (timePassed > 2 && Vector3.Distance(chairTarget.transform.position + chairTarget.transform.forward, transform.position) < 0.3)
            {
                animationController.SetBool("SitDown", true);
                RotateTowards(chairTarget.transform);
            }
            if (timePassed > 10)
            {
                animationController.SetBool("SitDown", false);
            }
            if(timePassed > 25)
            {
                timePassed = 0;
            }
            timePassed += Time.deltaTime;
        }
    }
    private void RotateTowards(Transform target)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * 3);
    }
}
