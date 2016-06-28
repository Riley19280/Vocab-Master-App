using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocab_Master_App
{
	static class MANAGER
	{
		public enum SEARCHTYPE
		{
			GOOGLE,DICTIONARY,THESARUS,WIKIPEDIA

		}
		public static SEARCHTYPE SearchType = SEARCHTYPE.GOOGLE;

		public static bool GetSynonyms = false;

		public static List<string> words = new List<string>();
	}
}
