﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace osu_Player
{
    /// <summary>
    /// SplashWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SplashWindow : Window
    {
        private bool _isAnimationCompleted;
        private MainWindow _instance;

        public SplashWindow()
        {
            _instance = MainWindow.GetInstance();

            InitializeComponent();
        }

        private void Init(object sender, RoutedEventArgs e)
        {
            if (_instance.settings.UseAnimation)
            {
                Storyboard sb = FindResource("StartAnimation") as Storyboard;
                Storyboard.SetTarget(sb, this);
                sb.Begin();
            }
            else
            {
                Opacity = 1f;
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (!_isAnimationCompleted && _instance.settings.UseAnimation)
            {
                e.Cancel = true;
                Storyboard sb = FindResource("CloseAnimation") as Storyboard;
                Storyboard.SetTarget(sb, this);
                sb.Begin();
            }
        }

        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            _isAnimationCompleted = true;
            Close();
        }
    }
}