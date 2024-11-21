using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Ease easeValue;
    [SerializeField] private GameObject playButton;
    [SerializeField] private Transform posMove;
    public async void LoadGameSceneAsync()
    {
        Sequence buttonPlayAnim = DOTween.Sequence();
        buttonPlayAnim.Append(playButton.transform.DOMove(posMove.position, 2f).SetEase(easeValue));
        buttonPlayAnim.Join(playButton.transform.DOScale(Vector3.zero, 2f));//.SetEase(easeValue));
        await buttonPlayAnim.AsyncWaitForCompletion();

        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync("GameScene");
        //asyncLoadScene.allowSceneActivation = false; 
    }
}
