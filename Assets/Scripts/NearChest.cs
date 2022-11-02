using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearChest : MonoBehaviour{
    public GameObject chestSprite;

    private void Update(){
        Collider2D[] chests = Physics2D.OverlapCircleAll(transform.position, 200, LayerMask.GetMask("Chest"));
        if (chests.Length > 0){
            Transform closestChest = null;
            float closestChestDistance = Mathf.Infinity;
            foreach (Collider2D chest in chests){
                if ((chest.transform.position - transform.position).sqrMagnitude < closestChestDistance){
                    closestChestDistance = (chest.transform.position - transform.position).sqrMagnitude;
                    closestChest = chest.transform;
                }
            }
            RaycastHit2D hit = Physics2D.Linecast(transform.position, closestChest.position, LayerMask.GetMask("Bounds"));

            if (hit.collider != null) {
                chestSprite.SetActive(true);
                chestSprite.transform.position = hit.point;
            }else
                chestSprite.SetActive(false);
        }
    }
}
