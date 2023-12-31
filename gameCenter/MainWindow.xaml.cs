﻿using gameCenter.Projects;
using gameCenter.Projects.Project1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace gameCenter
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DateLabel.Content = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            DispatcherTimer clock = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            clock.Tick += Tick!;
            clock.Start();

        }

        private void Tick(object sender, EventArgs e)
        {
            DateLabel.Content = DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;
            GameText.Content = (image.Name) switch
            {
                "Image1" => "a User Management System",
                "Image2" => "Memory Game",
                "Image3" => "Hanging Man",
                "Image4" => "Trivia",
                "Image5" => "Calculator",
                "Image6" => "Task Manegement Software",
                _ => "please pick an app"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "please pick a game";
        }

        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProjectPresentation page = new();
            Project1 project = new();
            page.OnStartUp("bla bla bla", Image1.Source, project);
            Hide();
            page.ShowDialog();
            ShowDialog();
            project.Close();
        }
    }
}
