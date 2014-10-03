using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Model
{
	/// <summary>
	/// A double-deck of 104 cards, in a specific order.
	/// </summary>
	class Deck
	{
		private Card[] _cards;

		public Card[] Cards { get { return _cards; } }

		/// <summary>
		/// Create a new shuffled deck.
		/// </summary>
		public Deck()
		{
			// RNG
			var rand = new Random();

			// Construct ordered deck.
			var singleDeck = from suit in Util.GetEnumValues<Suit>()
							 from rank in Util.GetEnumValues<Rank>()
							 select new Card(suit, rank);
			_cards = singleDeck.Concat(singleDeck).ToArray();

			// Shuffle
			for (int i = _cards.Length - 1; i >= 0; i--)
			{
				var j = rand.Next(i + 1);

				// Exchange values
				var tmp = _cards[j];
				_cards[j] = _cards[i];
				_cards[i] = tmp;
			}
		}
	}
}
