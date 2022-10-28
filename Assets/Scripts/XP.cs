using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour{
    public int xpAmount;
    public float attackRadius;

    private void Start(){
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, PlayerPrefs.GetFloat("xpmagnet", 0.5f), LayerMask.GetMask("Player"));
        if (player is not null)
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 2f * Time.deltaTime);
    }
}
