using System;
using Xamarin.Forms;
namespace HelloWorldForms
{
    public class CustomEntry : Entry
    {
        public const string ReturnKeyPropertyName = "ReturnKeyType";
        public new event EventHandler Completed;

        public CustomEntry()
        {

        }

        public static readonly BindableProperty ReturnKeyTypeProperty = BindableProperty.Create(
            propertyName: ReturnKeyPropertyName,
            returnType: typeof(ReturnKeyTypes),
            declaringType: typeof(CustomEntry),
            defaultValue: ReturnKeyTypes.Done);

        public ReturnKeyTypes ReturnKeyType
        {
            get { return (ReturnKeyTypes)GetValue(ReturnKeyTypeProperty); }
            set { SetValue(ReturnKeyTypeProperty, value); }
        }

        public enum ReturnKeyTypes : int
        {
            Next,
            Send,
            Done,
            Continue
        }

        public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
        }
    }
}
