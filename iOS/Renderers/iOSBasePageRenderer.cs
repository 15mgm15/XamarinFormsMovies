using System;
using Movies.iOS.Renderers;
using Movies.Views.Base;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseContentPage), typeof(iOSBasePageRenderer))]
namespace Movies.iOS.Renderers
{
    public class iOSBasePageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                    NavigationController.TopViewController.NavigationItem.LargeTitleDisplayMode =
                        UINavigationItemLargeTitleDisplayMode.Always;
            }
        }
    }
}
