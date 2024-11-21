using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI tittle;
    [SerializeField] private Transform transformTittle;
    [SerializeField] private Transform posMove;

    [SerializeField] private Button playButton;

    private void Start()
    {
        //panel.DOLocalMoveX(moveDistance,moveTime);
        //ScaleTittle();
        MoveTittle();
    }
    private void ScaleTittle()
    {
        DOTween.To(() => tittle.fontSize, x => tittle.fontSize = x, 250f, 2f).SetEase(Ease.OutBack);
    }
    private void MoveTittle()
    {
        Sequence moveTittleSqnc = DOTween.Sequence();

        moveTittleSqnc.Append(DOTween.To(() => tittle.fontSize, x => tittle.fontSize = x, 250f, 3.5f).SetEase(Ease.OutBack));
        //moveTittleSqnc.Append(transformTittle.DOMove(posMove.position, 2));
        moveTittleSqnc.Join(transformTittle.DOMove(posMove.position, 2f).SetEase(Ease.OutCirc));
        moveTittleSqnc.Join(tittle.DOBlendableColor(new Color(2f, 0f, 0.3f, 1f), 3f));



    }
}
