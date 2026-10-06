using System;
using System.IO;
using System.Windows;
using Microsoft.Web.WebView2.Core;

namespace AplicatieChromium
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeBrowser();
        }
            // Permite mutarea ferestrei pe ecran dacă ții click pe bara de sus
private void BaraSus_TrageFereastra(object sender, System.Windows.Input.MouseButtonEventArgs e)
{
    if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
    {
        // Verificăm dacă utilizatorul a făcut dublu-click
        if (e.ClickCount == 2)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }
        else
        {
            // Dacă este un singur click, permitem mutarea ferestrei
            DragMove();
        }
    }
}

// Funcția butonului de minimizare
private void Minimizare_Click(object sender, RoutedEventArgs e)
{
    WindowState = WindowState.Minimized;
}

// Funcția butonului de maximizare/restaurare
private void Maximizare_Click(object sender, RoutedEventArgs e)
{
    if (WindowState == WindowState.Maximized)
        WindowState = WindowState.Normal;
    else
        WindowState = WindowState.Maximized;
}

// Funcția butonului de închidere
private void Inchidere_Click(object sender, RoutedEventArgs e)
{
    Close();
}
        

        private async void InitializeBrowser()
        {
            // 1. Așteptăm ca motorul Chromium să se inițializeze
            await webView.EnsureCoreWebView2Async(null);

            // 2. Construim calea exactă către fișierul index.html de pe disc
            string htmlPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "index.html");
            
            // 3. Îi spunem browser-ului să afișeze acel fișier
            webView.CoreWebView2.Navigate(htmlPath);
        }
    }
}