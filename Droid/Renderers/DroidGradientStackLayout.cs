using System;
using Android.Content;
using Movies.Controls;
using Movies.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientStackLayout), typeof(DroidGradientStackLayout))]
namespace Movies.Droid.Renderers
{
    public class DroidGradientStackLayout : VisualElementRenderer<StackLayout>
    {
        Color StartColor { get; set; }
        Color EndColor { get; set; }

        public DroidGradientStackLayout(Context context) : base(context)
        {
        }

        protected override void DispatchDraw(Android.Graphics.Canvas canvas)
        {
            var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
                StartColor.ToAndroid(),
                EndColor.ToAndroid(),
                Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientStackLayout;
                StartColor = stack.StartColor;
                EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("{0} {1} {2}", nameof(DroidGradientStackLayout), nameof(OnElementChanged), ex.Message);
            }
        }

    }
}
