using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Vocab_Master_App
{
	public class wordListView : basePage
	{

		ListView listView;

		public wordListView()
		{
			Title = "My Words";

			listView = new ListView
			{
				// Source of data items.


				RowHeight = 75,
				// Define template for displaying each item.
				// (Argument of DataTemplate constructor is called for 
				//      each item; it must return a Cell derivative.)
				ItemTemplate = new DataTemplate(() =>
				{
					// Create views with bindings for displaying each property.
					Label wordLabel = new Label {
						FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
					}, descLabel = new Label {
						FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
					};
					wordLabel.SetBinding(Label.TextProperty, "word");
					descLabel.SetBinding(Label.TextProperty, "definition");

					// Return an assembled ViewCell.
					return new ViewCell
					{
						View = new StackLayout
						{
							Padding = new Thickness(5, 5, 5, 0),
							Children =
								{
									new StackLayout
									{
										VerticalOptions = LayoutOptions.Center,
										Spacing = 0,
										Children =
										{
											wordLabel,
											descLabel,
										
										}
									}
								}
						}
					};
				})
			};

			listView.ItemSelected += OnItemSelected;

			Content = new StackLayout
			{
				Children = {
					listView
				}
			};
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (listView.SelectedItem != null)
			{
				var wordView = new wordView(listView.SelectedItem as wordInfo);
				listView.SelectedItem = null;
				await Navigation.PushAsync(wordView);
			}
		}


		protected async override void OnAppearing()
		{
			base.OnAppearing();
			{
				List<wordInfo> wordsInfo = new List<wordInfo>();
				
				try
				{
					//TODO:get words might want to get words in a diff part if the call is async dont want user to be waiting
					for(int i = 0; i < MANAGER.words.Count; i++) { 
						downloadMgr downloadMgr = new downloadMgr();

						wordInfo w = await downloadMgr.getWord(MANAGER.words[i]);
						wordsInfo.Add(w);				
					
					}
					listView.ItemsSource = wordsInfo;
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
					Debug.WriteLine(e.StackTrace);
				}
			}
		}
	}

}
