﻿using SophiAppCE.Controls;
using SophiAppCE.Models;
using SophiAppCE.ViewModels;
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

namespace SophiAppCE.Views
{
    /// <summary>
    /// Логика взаимодействия для PrivacyPanelView.xaml
    /// </summary>
    public partial class PrivacyPanelView : UserControl
    {
        public PrivacyPanelView()
        {
            InitializeComponent();
        }

        public bool PanelControlsCounter
        {
            get { return (bool)GetValue(PanelControlsCounterProperty); }
            private set { SetValue(PanelControlsCounterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PanelControlsCounter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PanelControlsCounterProperty =
            DependencyProperty.Register("PanelControlsCounter", typeof(bool), typeof(PrivacyPanelView), new PropertyMetadata(default(bool)));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(PrivacyPanelView), new PropertyMetadata(default(string)));

        private void Odd_Filter(object sender, FilterEventArgs e)
        {
            SwitchBarModel switchBarModel = e.Item as SwitchBarModel;
            e.Accepted = switchBarModel.Tag == Convert.ToString(Tag) && Convert.ToInt32(switchBarModel.Id.Split('x')[1]) % 2 == 1
                       ? true : false;

            SetPanelControlsCounter(e.Accepted);
        }

        private void SetPanelControlsCounter(bool value)
        {
            if (PanelControlsCounter != value && value == true)
                PanelControlsCounter = value;           
        }

        private void Even_Filter(object sender, FilterEventArgs e)
        {
            SwitchBarModel switchBarModel = e.Item as SwitchBarModel;
            e.Accepted = switchBarModel.Tag == Convert.ToString(Tag) && Convert.ToInt32(switchBarModel.Id.Split('x')[1]) % 2 == 0
                       ? true : false;
        }

        private void SelectAllSwitch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LeftStateSwitchBar stateSwitchBar = sender as LeftStateSwitchBar;
            (DataContext as AppViewModel).SelectAllCommand.Execute(new string[] { Convert.ToString(stateSwitchBar.Tag), Convert.ToString(stateSwitchBar.State) });
        }      

        public bool ScrollToUpper
        {
            get { return (bool)GetValue(ScrollToUpperProperty); }
            set { SetValue(ScrollToUpperProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollToUpper.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollToUpperProperty =
            DependencyProperty.Register("ScrollToUpper", typeof(bool), typeof(PrivacyPanelView), new PropertyMetadata(OnScrollToUpperChanged));

        private static void OnScrollToUpperChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as PrivacyPanelView).ContentPanelScrollViewer.ScrollToHome();
    }
}
