using Darli.Word.Pages;
using System.Diagnostics;
using System.Globalization;

namespace Darli.Word
{
    /// <summary>
    /// Converts the <see cref="AppliationPage"/> to an actual view/page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value) 
            {
                case ApplicationPage.Login:
                    return new LoginPage();
                
                    default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
