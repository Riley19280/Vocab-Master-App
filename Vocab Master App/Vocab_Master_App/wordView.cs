using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Vocab_Master_App
{
	public class wordView : basePage
	{
		public wordView(wordInfo w)
		{
			Title = (char.ToUpper(w.word[0]) + w.word.Substring(1));

			#region labels
			Label lblWord = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
			};
			lblWord.Text = w.word;

			Label lblDefinition = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			lblDefinition.Text = w.definition;

			Label lblPartOfSpeech = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			lblPartOfSpeech.Text = w.partOfSpeech;

			Label lblPronuc = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			lblPronuc.Text = w.pronunciation;

			#endregion


			StackLayout synstack = new StackLayout { Padding = new Thickness(10), };
			foreach (string s in w.synonyms)
				synstack.Children.Add(new Label { Text = s });

			ScrollView synScrollview = new ScrollView { Content = synstack };

			StackLayout antstack = new StackLayout { Padding = new Thickness(10), };
			foreach (string s in w.antonyms)
				antstack.Children.Add(new Label { Text = s });

			ScrollView antScrollview = new ScrollView { Content = antstack };


			Content = new StackLayout
			{
				Padding = new Thickness(25),
				Children = {
				//	lblWord,
					lblPronuc,

					new ScrollView {
						Content = lblDefinition,
					},

					lblPartOfSpeech,
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						Children = {
							new StackLayout {
								VerticalOptions = LayoutOptions.StartAndExpand,
								HorizontalOptions = LayoutOptions.CenterAndExpand,
								Children = {
									new Label {Text = "Synonyms",FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)), },
									synScrollview
								}

							},
							new StackLayout {
								VerticalOptions = LayoutOptions.StartAndExpand,
								HorizontalOptions = LayoutOptions.CenterAndExpand,
								Children = {
									new Label {Text = "Antonyms",FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)), },
									antScrollview
								}
							}
						}
					}
				}

			};
		}
	}
}
