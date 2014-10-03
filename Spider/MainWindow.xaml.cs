using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Spider
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();


			// TEMP
			var deck = new Model.Deck();
			foreach (var card in deck.Cards)
			{
				System.Diagnostics.Debug.WriteLine("{0} of {1}", card.Rank, card.Suit);

				var test = Model.Card.Decode(card.Encode());
				System.Diagnostics.Debug.Assert(test.Rank == card.Rank);
				System.Diagnostics.Debug.Assert(test.Suit == card.Suit);
			}
		}
	}
}
