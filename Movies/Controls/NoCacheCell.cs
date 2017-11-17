using System;
using FFImageLoading.Forms;
using Movies.Models;
using Xamarin.Forms;

namespace Movies.Controls
{
    public class NoCacheCell : ViewCell
    {
        CachedImage CachedImage;

        protected override void OnBindingContextChanged()
        {
            if (CachedImage == null)
            {
                foreach (var child in ((Grid)View).Children)
                {
                    if (child is CachedImage)
                    {
                        CachedImage = (CachedImage)child;
                        break;
                    }
                }
            }

            CachedImage.Source = null;

            var item = BindingContext as Movie;

            if (item == null)
                return;

            CachedImage.HeightRequest = !string.IsNullOrEmpty(item.BackdropPath) ? 210 : 0;

            CachedImage.Source = item.HighResBackdropPath;

            base.OnBindingContextChanged();
        }
    }
}
