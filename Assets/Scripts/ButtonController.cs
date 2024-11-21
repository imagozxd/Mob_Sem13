using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Ease easeValue;
    [SerializeField] private GameObject playButton;
    [SerializeField] private Transform posMove;
    [SerializeField] private GameObject loadingCube;

    private void Start()
    {
        loadingCube.SetActive(false);
    }
    public async void LoadGameSceneAsync()
    {
        loadingCube.SetActive(true);
        Sequence buttonPlayAnim = DOTween.Sequence();
        buttonPlayAnim.Append(playButton.transform.DOMove(posMove.position, 2f).SetEase(easeValue));
        buttonPlayAnim.Join(playButton.transform.DOScale(Vector3.zero, 2f));//.SetEase(easeValue));
        loadingCube.transform.DORotate(new Vector3(300f, 300f, 300f), 3).SetEase(easeValue);
        await buttonPlayAnim.AsyncWaitForCompletion();

        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync("GameScene");
        asyncLoadScene.allowSceneActivation = false; //detenido

        

        while (!asyncLoadScene.isDone)
        {
            if(asyncLoadScene.progress >= 0.90f)  //funco con 90 y no 95
            {
                Debug.Log("la escena esta lista");
                break;
            }   
            await Task.Yield();
        }
        await Task.Delay(1000);

        asyncLoadScene.allowSceneActivation = true;
    }
}
