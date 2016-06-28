using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Vocab_Master_App
{
	public class mainPage : basePage
	{


		public mainPage()
		{
			Title = "VOCAB MASTER";

			string editorText = "Enter Words, one per line";
			Editor editor = new Editor
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Text = editorText,
				Style = (Style)Application.Current.Resources["editorStyle"]

		};
			editor.Focused += (sender, eventArgs) =>
			{				
				editor.Text = editor.Text.Replace("Enter Words, one per line", string.Empty);
			};


			Button btnNext = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "NEXT >"
			};

			btnNext.Clicked += (sender, eventArgs) =>
			{
				//TODO: get words from editor
				List<string> words = new List<string>();
				words = editor.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
				for (int i = 0; i < words.Count; i++)
				{
					if (string.IsNullOrWhiteSpace(words[i]))
					{
						words.RemoveAt(i);
					}
				}
				MANAGER.words = words;
				Navigation.PushAsync(new options());
			};


			Content = new StackLayout
			{
				Padding = new Thickness(25),
				Children = {
					editor,
					btnNext

				}
			};
		}
	}
}
