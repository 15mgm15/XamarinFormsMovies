using System;
using CoreAnimation;
using CoreGraphics;
using Movies.Controls;
using Movies.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientStackLayout), typeof(iOSGradientStackLayout))]
namespace Movies.iOS.Renderers
{
    public class iOSGradientStackLayout : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientStackLayout stack = (GradientStackLayout)Element;

            CGColor startColor = stack.StartColor.ToCGColor();
            CGColor endColor = stack.EndColor.ToCGColor();
            var gradientLayer = new CAGradientLayer
            {
                Frame = rect,
                Colors = new CGColor[] { startColor, endColor }
            };
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}
