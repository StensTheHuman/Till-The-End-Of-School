using UnityEngine;

public class UpgrateMenuSlides : MonoBehaviour
{
    [SerializeField] private UpgrateMenuMovement _upgrateMenuMovement;

    public void SlideNext()
    {
        var index = _upgrateMenuMovement.SelectedTabIndex;

        _upgrateMenuMovement.SelectTab(index + 1);
    }

    public void SlidePrevious()
    {
        var index = _upgrateMenuMovement.SelectedTabIndex;

        _upgrateMenuMovement.SelectTab(index - 1);
    }
}
