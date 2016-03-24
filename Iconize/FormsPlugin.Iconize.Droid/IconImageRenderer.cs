using System;
using System.ComponentModel;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Plugin.Iconize.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconImage), typeof(IconImageRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconImageRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.ImageRenderer" />
    public class IconImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Image}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            UpdateImage();
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == nameof(IconImage.Icon) ||
                e.PropertyName == nameof(IconImage.IconColor))
            {
                UpdateImage();
            }
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        private void UpdateImage()
        {
            var iconImage = Element as IconImage;
            var drawable = new IconDrawable(Context, Plugin.Iconize.Iconize.FindIconForKey(iconImage.Icon))
                                     .Color(iconImage.IconColor.ToAndroid())
                                     .SizeDp((Int32)Element.HeightRequest);
            Control.SetImageDrawable(drawable);
        }
    }
}