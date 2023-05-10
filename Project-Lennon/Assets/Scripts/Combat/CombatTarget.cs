using UnityEngine;
using RPG.Attributes;
using RPG.Control;

namespace RPG.Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour, IRaycastable
    {
        public CursorType GetCursorType()
        {
            return CursorType.Combat;
        }

        public bool HandleRaycast(PlayerController callingController)
        {
            if (!callingController.GetComponent<Fighter>().CanAttack(gameObject)) 
            {
                return false; //Means we cannot handle attack.
            }
            if (Input.GetMouseButton(0))
            {
               callingController.GetComponent<Fighter>().Attack(gameObject); // for this particular target.
            }
            return true;
        }
    }
}
