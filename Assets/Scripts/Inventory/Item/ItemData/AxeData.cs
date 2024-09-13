using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Axe", menuName = "ScriptableObjects/Axe", order = 2)]
public class AxeData : ToolData
{
    private RaycastHit _hit;

    public override void UseItem(Transform user){
        if (Physics.Raycast(user.position, user.TransformDirection(Vector3.forward), out _hit, 7.5f, LayerMask.GetMask("Interactable"))){      
            _hit.collider.transform.gameObject.GetComponentInParent<IChopable>().TakeAxeDamage(ToolDamage, _hit);
        }
    }
    

}
