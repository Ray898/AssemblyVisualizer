﻿using System;
using System.Collections.Generic;
using System.Linq;
// Copyright 2011 Denis Markelov
// This code is distributed under Apache 2.0 license 
// (for details please see \docs\LICENSE, \docs\NOTICE)

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using WPFExtensions.Controls;

namespace ILSpyVisualizer.AssemblyBrowser.Screens
{
	/// <summary>
	/// Interaction logic for GraphScreen.xaml
	/// </summary>
	internal partial class GraphScreenView : UserControl
	{
		public GraphScreenView()
		{
			InitializeComponent();

			Loaded += LoadedHandler;
		}

		private GraphScreen ViewModel
		{
			get { return DataContext as GraphScreen; }
		}

		private void GraphChangedHandler()
		{
			zoomControl.ZoomToFill();
		}

		private void LoadedHandler(object sender, RoutedEventArgs e)
		{
			ViewModel.GraphChanged += GraphChangedHandler;
			ViewModel.ShowDetailsRequest += ShowDetailsRequestHandler;
			ViewModel.FillGraphRequest += FillGraphRequestHandler;
			ViewModel.OriginalSizeRequest += OriginalSizeRequestHandler;
		}

		private void ShowDetailsRequestHandler()
		{
			detailsPopup.MaxHeight = ActualHeight - 30;
			detailsPopup.IsOpen = true;
		}

		private void FillGraphRequestHandler()
		{
			zoomControl.ZoomToFill();
		}

		private void OriginalSizeRequestHandler()
		{
			var animation = new DoubleAnimation(1, TimeSpan.FromSeconds(1));
			zoomControl.BeginAnimation(ZoomControl.ZoomProperty, animation);
		}
	}
}
