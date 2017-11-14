using System;
using Xamarin.Forms;

namespace Movies.Controls
{
    public class CustomListView : ListView
    {
        public CustomListView(ListViewCachingStrategy strategy) : base(strategy)
        {
        }
    }
}
