using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Master_App
{
	public class downloadMgr
	{
		public async Task<wordInfo> getWord(string word)
		{
			wordInfo WI = new wordInfo();

			var c = await new HttpClient().GetStringAsync(Constants.GoogleGetWord + word);

			GoogleParser gp = new GoogleParser(c, word);
			WI.word = word;
			WI.definition = gp.OUTPUT.definition;
			WI.partOfSpeech = gp.OUTPUT.partOfSpeech;
			WI.pronunciation = gp.OUTPUT.pronunciation;
			
			if (MANAGER.GetSynonyms)
			{
				var t = await new HttpClient().GetStringAsync(Constants.ThesarusGetSynAnt + word);
				ThesaurusParser tp = new ThesaurusParser(t);
				WI.synonyms = tp.syns;
				WI.antonyms = tp.ants;
			}

			return WI;
		}

	}
}
