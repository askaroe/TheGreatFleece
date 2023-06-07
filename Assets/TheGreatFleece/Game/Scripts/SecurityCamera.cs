using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

    public GameObject gameOverCutscene;

    public Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            //                      154/255  29/255 29/255 10/255
            Color color = new Color(0.6f, 0.11f, 0.11f, 0.04f);
            render.material.SetColor("_TintColor", color);
            anim.enabled = false;
            StartCoroutine(AlertRoutine());
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true);
    }
}
