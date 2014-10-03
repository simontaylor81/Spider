using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Model
{
	/// <summary>
	/// The suit of a card.
	/// </summary>
	enum Suit
	{
		Spades,
		Hearts,
		Diamonds,
		Clubs
	}

	/// <summary>
	/// Rank of a card
	/// </summary>
	enum Rank
	{
		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}

	/// <summary>
	/// A card in a deck. Immutable.
	/// </summary>
	struct Card
	{
		private readonly Suit _suit;
		private readonly Rank _rank;

		public Suit Suit { get { return _suit; } }
		public Rank Rank { get { return _rank; } }

		public Card(Suit suit, Rank rank)
		{
			_suit = suit;
			_rank = rank;
		}

		/// <summary>
		/// Encode the card into a compact representation.
		/// </summary>
		/// <returns>Encoded byte</returns>
		public byte Encode()
		{
			return (byte)(((int)Suit) * 13 + (int)Rank);
		}

		/// <summary>
		/// Decode a compact card representation to return the original card.
		/// </summary>
		/// <param name="encoded">The encoded byte</param>
		/// <returns>The decoded card</returns>
		public static Card Decode(byte encoded)
		{
			return new Card((Suit)(encoded / 13), (Rank)(encoded % 13));
		}
	}
}
