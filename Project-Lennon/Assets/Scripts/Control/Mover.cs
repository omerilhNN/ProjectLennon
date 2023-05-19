using RPG.Core;
using RPG.Saving;
using RPG.Attributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    //You could inhterit more than 1 intrfc, whereas just 1 class
    public class Mover : MonoBehaviour,IAction,ISaveable 
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 6f;
        [SerializeField] float maxPathLength = 40f;


        NavMeshAgent navMeshAgent;
        Health health;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        void Update()
        {
            if (DialogManager.isActive == true)
                navMeshAgent.enabled = false;

            navMeshAgent.enabled = !health.IsDead();//If player is dead then disable NMAgent.

            UpdateAnimator();
        }
        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination,speedFraction);
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        public void Cancel()//MUST BE THE SAME METHOD NAME LIKE IN INTERFACE
        {
            navMeshAgent.isStopped = true;
        }
        public bool CanMoveTo(Vector3 destination)
        {
            NavMeshPath navMeshPath = new NavMeshPath();
            bool hasPath = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, navMeshPath);
            if (!hasPath) return false;
            if (navMeshPath.status != NavMeshPathStatus.PathComplete) return false;//In order to prevent path calculation to the ROOFTOPS.
            if (GetPathLength(navMeshPath) > maxPathLength) return false;//When the destination is way far off from our position.

            return true; // When every other conditions are not succeeded then return true;
        }
        private float GetPathLength(NavMeshPath navMeshPath)
        {//Summation of these path corners in the navMeshPath.
            float total = 0;
            if (navMeshPath.corners.Length < 2) return total; //When there is just 1 line with 2 corners return 0;.
            for (int i = 0; i < navMeshPath.corners.Length - 1; i++)
            {
                total += Vector3.Distance(navMeshPath.corners[i], navMeshPath.corners[i + 1]);//Sum of our path lines.
            }
            return total;
        }
        public void MoveTo(Vector3 destination,float speedFraction)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
        }

        public object CaptureState()
        {
            //Keep info's in Dictionary in order to RETURN THEM BOTH.
            Dictionary<string,object> data = new Dictionary<string,object>();
            data["position"] = new SerializableVector3(transform.position);
            data["rotation"] = new SerializableVector3(transform.eulerAngles);//vector representation of the rotation.
            return data;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = (Dictionary<string, object>)state;//This is OBJECT type so underneath we CAST it to SerializableVector3.
            navMeshAgent.enabled = false;
            transform.position = ((SerializableVector3)data["position"]).ToVector();
            transform.eulerAngles = ((SerializableVector3)data["rotation"]).ToVector();
            navMeshAgent.enabled = true;
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }

}