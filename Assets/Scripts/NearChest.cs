using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearChest : MonoBehaviour
{
    public GameObject chestSprite;

    private void Update()
    {
        Transform closestChest = null;
        float closestChestDistance = Mathf.Infinity;
        Collider2D[] chests = Physics2D.OverlapCircleAll(transform.position, 1500, LayerMask.GetMask("Chest"));
        if (chests.Length > 0)
        {
            foreach (Collider2D chest in chests)
            {
                if ((chest.transform.position - transform.position).sqrMagnitude < closestChestDistance)
                {
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
