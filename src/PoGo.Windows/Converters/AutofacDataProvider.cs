using Autofac;
using System.Reflection;
using Windows.UI.Xaml;

namespace PoGo.Windows.Converters
{

    /// <summary>
    /// http://deanchalk.com/wpf-automatic-viewmodel-resolution-with-autofac-2/
    /// </summary>
    public class AutofacDataProvider : DependencyObject
    {

        #region DependencyProperties

        public static readonly DependencyProperty AutofacContainerProperty =
            DependencyProperty.Register("AutofacContainer",
                typeof(IContainer),
                typeof(AutofacDataProvider),
                new PropertyMetadata(null, AutofacValuesChanged));

        public static readonly DependencyProperty DataTypeNameProperty =
            DependencyProperty.Register("DataTypeName",
                typeof(string),
                typeof(AutofacDataProvider),
                new PropertyMetadata(null, AutofacValuesChanged));

        private static readonly DependencyProperty DataPropertyKey =
            DependencyProperty.Register("Data",
            typeof(object),
            typeof(AutofacDataProvider),
            new PropertyMetadata(null));

        #endregion

        #region Properties

        public IContainer AutofacContainer
        {
            get { return (IContainer)GetValue(AutofacContainerProperty); }
            set { SetValue(AutofacContainerProperty, value); }
        }


        public string DataTypeName
        {
            get { return (string)GetValue(DataTypeNameProperty); }
            set { SetValue(DataTypeNameProperty, value); }
        }

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            private set { SetValue(DataProperty, value); }
        }

        #endregion


        public static readonly DependencyProperty DataProperty = DataPropertyKey;



        private static void AutofacValuesChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var container = d.GetValue(AutofacContainerProperty) as IContainer;
            var typeName = d.GetValue(DataTypeNameProperty) as string;
            if (container == null || string.IsNullOrEmpty(typeName))
                return;
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var type = assembly.GetType(typeName, false, true);
            if (type == null)
                return;
            var data = container.Resolve(type);
            d.SetValue(DataPropertyKey, data);
        }
    }
}
