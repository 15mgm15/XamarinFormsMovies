using Movies.iOS.Renderers;
using Movies.Views.Base;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseNavigationPage), typeof(iOSNavigationPageRenderer))]
namespace Movies.iOS.Renderers
{
    public class iOSNavigationPageRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                NavigationBar.PrefersLargeTitles = true;
                UINavigationBar.Appearance.LargeTitleTextAttributes =
                    new UIStringAttributes { ForegroundColor = (Element as NavigationPage)?.BarTextColor.ToUIColor() };
            }

        }
    }
}
