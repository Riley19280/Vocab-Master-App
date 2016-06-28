using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Vocab_Master_App
{
	public class basePage : ContentPage
	{
		public basePage()
		{
			Style = (Style)Application.Current.Resources["contentPageStyle"];
		}
	}
}
