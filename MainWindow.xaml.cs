using System.Diagnostics;
using System.Diagnostics.Metrics;
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

using BasicUIProject.Converter;

namespace BasicUIProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    // ドラッグ移動用フィールド
    private bool _isDragging;
    private Point _mouseStartInCanvas;
    private double _rectStartLeft;
    private double _rectStartTop;


    // ----------------------------------------------
    // Contructor and Event Handlers
    public MainWindow()
    {
        InitializeComponent();

    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });

        // e.Handled = true; を付けたくなる典型例
        // 親要素（Grid / Window など）でも同じ入力イベントを拾っていて、二重に動くのを止めたい
        // 例：親で PreviewMouseDown や MouseDown を見ていて、ボタン操作でも親が反応して困る
        // 同じ要素に複数ハンドラが付いていて、後続を動かしたくない
        // 特定のキー入力（Enter / Escなど）を自分の処理で完結させて、他に渡したくない（KeyDown系でよくある）
        
        e.Handled = true;
    }



    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        textBoxWillChangeLater.Text = "Textがボタンによって変わりました！";

    }


    private void checkableBox_Checked(object sender, RoutedEventArgs e)
    {

        checkableLabel.Background = Brushes.LightGreen;

    }

    private void checkableBox_Unchecked(object sender, RoutedEventArgs e)
    {
        checkableLabel.Background = Brushes.White;
    }


    private void clickableImage_MouseUp(object sender, MouseButtonEventArgs e)
    {
        clickableImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/img03.png"));
    }

    private void clickableImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
        clickableImage.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/img02.png"));
    }

    private void sliderTickSnapped_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (sliderValue != null && sliderTickSnapped.Value > 0d)
        {
            sliderValue.Text = $"Value: {sliderTickSnapped.Value}";
            sliderValue.FontSize = sliderTickSnapped.Value;
        }
    }

    private void sampleCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
    {
        if(selectedDateTextBlock != null)
        {
            if (sampleCalendar.SelectedDate.HasValue)
            {
                selectedDateTextBlock.Text = $"選択された日時: {sampleCalendar.SelectedDate.Value.ToShortDateString()}";
            }
            else
            {
                selectedDateTextBlock.Text = "日時が選択されていません";
            }
        }
    }


    // ----------------------------------------------
    // Rectangleのドラッグ移動イベントハンドラ

    private void dragRect_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // イベント発生元のRectangleとその親Canvasを取得
        var rect = (Rectangle)sender;
        var canvas = (Canvas)rect.Parent;

        // ドラッグ移動開始の準備
        _isDragging = true;

        // マウス位置とRectangleの位置を記録
        _mouseStartInCanvas = e.GetPosition(canvas);

        // RectangleのCanvas上の位置を取得
        _rectStartLeft = Canvas.GetLeft(rect);
        _rectStartTop = Canvas.GetTop(rect);

        // NaN対策（初期状態ではLeft/TopがNaNのため）
        if (double.IsNaN(_rectStartLeft)) _rectStartLeft = 0;
        if (double.IsNaN(_rectStartTop)) _rectStartTop = 0;

        // マウスキャプチャを開始して、他の要素にマウスイベントが行かないようにする
        rect.CaptureMouse();

        // イベントを処理済みにする
        e.Handled = true;
    }

    private void dragRect_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        // ドラッグ移動中でなければ何もしない
        if (!_isDragging) return;

        // イベント発生元のRectangleとその親Canvasを取得
        var rect = (Rectangle)sender;
        var canvas = (Canvas)rect.Parent;

        // 現在のマウス位置を取得し、移動量を計算
        var now = e.GetPosition(canvas);
        var dx = now.X - _mouseStartInCanvas.X;
        var dy = now.Y - _mouseStartInCanvas.Y;

        // Rectangleの位置を更新
        Canvas.SetLeft(rect, _rectStartLeft + dx);
        Canvas.SetTop(rect, _rectStartTop + dy);
    }

    private void dragRect_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        // ドラッグ移動中でなければ何もしない
        if (!_isDragging) return;

        // イベント発生元のRectangleを取得
        var rect = (Rectangle)sender;
        _isDragging = false;

        // マウスキャプチャを解除
        rect.ReleaseMouseCapture();
        
        // イベントを処理済みにする
        e.Handled = true;
    }
}