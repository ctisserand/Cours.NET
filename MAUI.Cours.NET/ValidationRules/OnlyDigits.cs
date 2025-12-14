using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace MAUI.Cours.NET.ValidationRules
{
    public class OnlyDigitsBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            if (entry == null)
                return;

            // Autorise uniquement les chiffres
            if (!Regex.IsMatch(e.NewTextValue ?? "", @"^\d*$"))
            {
                entry.TextColor = Colors.Red;
            }
            else
            {
                entry.TextColor = null;
            }
        }
    }
}