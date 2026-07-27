using DG.Tweening;

namespace Assets._Progect.Develop.Runtime.UI.Core
{
    public interface IShowableView : IView
    {
        Tween Show();

        Tween Hide();
    }

}
