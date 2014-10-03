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

namespace Spider.View
{
	/// <summary>
	/// Interaction logic for CardControl.xaml
	/// </summary>
	public partial class CardControl : UserControl
	{
		// TODO
		private int Rank = 10;

		private List<Tuple<FrameworkElement, Point>> pips = new List<Tuple<FrameworkElement, Point>>();

		public CardControl()
		{
			InitializeComponent();
			pipCanvas.SizeChanged += pipCanvas_SizeChanged;

			if (Rank == 1 || Rank == 3 || Rank == 5 || Rank == 9)
			{
				AddPip(0.5, 0.5);
			}
			if (Rank == 2 || Rank == 3)
			{
				AddPip(0.5, 0.0);
				AddPip(0.5, 1.0);
			}
			if (Rank >= 4 && Rank <= 10)
			{
				AddPip(0.0, 0.0);
				AddPip(0.0, 1.0);
				AddPip(1.0, 0.0);
				AddPip(1.0, 1.0);
			}
			if (Rank >= 6 && Rank <= 8)
			{
				AddPip(0.0, 0.5);
				AddPip(1.0, 0.5);
			}
			if (Rank == 7 || Rank == 8)
			{
				AddPip(0.5, 0.25);
			}
			if (Rank == 8)
			{
				AddPip(0.5, 0.75);
			}
			if (Rank == 9 || Rank == 10)
			{
				AddPip(0.0, 0.333);
				AddPip(1.0, 0.333);
				AddPip(0.0, 0.667);
				AddPip(1.0, 0.667);
			}
			if (Rank == 10)
			{
				AddPip(0.5, 0.167);
				AddPip(0.5, 0.833);
			}
		}

		void pipCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			UpdatePipPositions();
		}

		private void AddPip(double rx, double ry)
		{
			// TEMP: Use a red rectangle
			var pip = new Rectangle();
			pip.Fill = System.Windows.Media.Brushes.Red;

			// TODO: relative to size of canvas
			pip.Width = 50.0;
			pip.Height = 50.0;

			pipCanvas.Children.Add(pip);
			pips.Add(Tuple.Create((FrameworkElement)pip, new Point(rx, ry)));
		}

		private void UpdatePipPositions()
		{
			foreach (var pip in pips)
			{
				Canvas.SetLeft(pip.Item1, pip.Item2.X * pipCanvas.ActualWidth - 0.5 * pip.Item1.Width);
				Canvas.SetTop(pip.Item1, pip.Item2.Y * pipCanvas.ActualHeight - 0.5 * pip.Item1.Height);
			}
		}
	}
}
