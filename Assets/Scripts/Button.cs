using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    public int index;

    float delay;

    private void Awake()
    {
        delay = 1.5f;
    }

    private void Update()
    {
        delay -= Time.deltaTime;
    }

    public void ButtonOnClick()
    {
        if (delay <= 0f && index == GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].levelIndex)
        {
            delay = 1.5f;

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects[index].SetActive(true);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects[index].transform.DOScale(2.1f, 1f).OnComplete(() => {
                
                if (GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].levelIndex == GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Count - 1)
                {
                    
                    GameManager.Instance.CheckLevelUp();
                }
                else
                {
                    GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].levelIndex += 1;
                }

                gameObject.SetActive(false);
            });
        }
    }
}
