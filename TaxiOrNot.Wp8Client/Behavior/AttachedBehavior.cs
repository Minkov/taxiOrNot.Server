using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TaxiOrNot.Wp8Client.Behavior
{
    public class AttachedBehavior
    {


        private static void ExecuteLoadedCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element == null)
            {
                return;
            }

            if ((e.NewValue != null) && (e.OldValue == null))
            {
                element.Loaded += (snd, args) =>
                {
                    var command = (snd as FrameworkElement).GetValue(AttachedBehavior.LoadedProperty) as ICommand;
                    command.Execute(args);
                };
            }
        }

        public static ICommand GetLoaded(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(LoadedProperty);
        }

        public static void SetLoaded(DependencyObject obj, ICommand value)
        {
            obj.SetValue(LoadedProperty, value);
        }

        // Using a DependencyProperty as the backing store for Loaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadedProperty =
            DependencyProperty.RegisterAttached("Loaded", typeof(ICommand), typeof(AttachedBehavior), new PropertyMetadata(new PropertyChangedCallback(ExecuteLoadedCommand)));


    }
}
