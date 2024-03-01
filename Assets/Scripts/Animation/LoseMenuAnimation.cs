using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenuAnimation : MonoBehaviour
{
    [SerializeField] private GameObject restartButton, exitButton;
    [SerializeField] private Image panelImage;

    private void OnEnable()
    {
        panelImage.DOFade(100, 0.5f).SetEase(Ease.OutCubic);
        restartButton.transform.DOLocalMoveY(0, 1.2f).SetEase(Ease.OutElastic).OnComplete(() =>
            {
                restartButton.transform.DOScale(Vector2.one, 0.6f).SetEase(Ease.OutBack);
            });
        exitButton.transform.DOLocalMoveY(-130, 0.3f).SetDelay(0.6f).SetEase(Ease.OutQuint);
    }
}
