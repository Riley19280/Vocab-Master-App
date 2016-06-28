using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Master_App
{
	public class wordInfo
	{
		public wordInfo(string word, string def, string POS, string pronounc) {
			this.word = word;
			this.definition = def;
			this.partOfSpeech = POS;
			this.pronunciation = pronounc;

		}
		public wordInfo() { }

		public string word {  get; set;}
		public string definition { get; set; }
		public string partOfSpeech { get; set; }
		public string pronunciation { get; set; }
		public List<string> synonyms { get; set; } = new List<string>();
		public List<string> antonyms { get; set; } = new List<string>();


	}
}
