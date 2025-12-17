using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public int nextSceneNum;
    public GameObject needKey;
    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        needKey.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && gm.isHaveKey)
        {
            SceneManager.LoadScene(nextSceneNum);
        }
        if (gm.isHaveKey == false) needKey.SetActive(true);
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            needKey.SetActive(false);
        }
    }
}
