using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Vocab_Master_App
{
	public class options : basePage
	{
		public options()
		{
			Title = "OPTIONS";

			#region picker
			Picker picker = new Picker
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Title = "Select search type",

			};

			picker.Items.Add("Goolge");//index 0
			picker.Items.Add("Dictionary.com");//index 1
			picker.Items.Add("Thesarus.com");//index 2
			picker.Items.Add("Wikipedia.com");//index 3

			picker.SelectedIndex = 0;

			picker.SelectedIndexChanged += (sender, eventArgs) =>
			{
				switch (picker.SelectedIndex)
				{
					case 0:
						MANAGER.SearchType = MANAGER.SEARCHTYPE.GOOGLE;
						break;
					case 1:
						MANAGER.SearchType = MANAGER.SEARCHTYPE.DICTIONARY;
						break;
					case 2:
						MANAGER.SearchType = MANAGER.SEARCHTYPE.THESARUS;
						break;
					case 3:
						MANAGER.SearchType = MANAGER.SEARCHTYPE.WIKIPEDIA;
						break;
				}
			};

			#endregion

			#region switch
			Switch sw = new Switch
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,

			};
			sw.Toggled += (sender, eventArgs) =>
			{
				if (eventArgs.Value)//is true
					MANAGER.GetSynonyms = true;
				else
					MANAGER.GetSynonyms = false;

			};

			#endregion

			Content = new StackLayout
			{
				Children = {

					picker,

						new StackLayout {
							Orientation = StackOrientation.Horizontal,
							Children = {
								new Label {
									HorizontalOptions = LayoutOptions.StartAndExpand,
									Text = "Find synonyms and antynoms: "
								},
								sw,
							}
						},

						new Button {
								HorizontalOptions = LayoutOptions.CenterAndExpand,
								VerticalOptions = LayoutOptions.EndAndExpand,
								Text = "NEXT >",
								Command = new Command(() => {
									Navigation.PushAsync(new wordListView());

								})
						}

				}
			};
		}
	}
}
