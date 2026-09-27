using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Mini.Setting;

namespace Mini
{
    public partial class SettingView : UserControl
    {
        private bool _isDragging = false;
        private Point _startPoint;

        private readonly string _path = "./settings";

        public SettingView()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                if (SettingManager.HaveSetting() && TxtTargetHost != null)
                {
                    TxtTargetHost.Text = SettingManager.SettingList.GetValueOrDefault("TargetHost") ?? "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[SettingView Load Error] {ex.Message}");
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var TargetHost = TxtTargetHost.Text.Trim();
                // 저장 요소들을 하나씩 작성
                await Task.Run(() => SettingManager.SaveAsync("TargetHost", TargetHost));

                // 파일에 저장
                _ = Task.Run(() => SettingManager.WriteAsync(_path));

                MessageBox.Show("설정이 저장되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"저장 실패: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            // 부모 컨테이너(Canvas, Grid 등)에서 제거하거나 숨김 처리
            if (this.Parent is Panel parentPanel)
            {
                parentPanel.Children.Remove(this);
            }
            else if (this.Parent is ContentControl parentContent)
            {
                parentContent.Content = null;
            }
        }

        #region 드래그 이동 로직 (VirtualWindow 동일)

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _startPoint = e.GetPosition(this);
            HeaderBorder.CaptureMouse();
        }

        private void Header_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                HeaderBorder.ReleaseMouseCapture();
            }
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && this.Parent is Canvas canvas)
            {
                Point currentPoint = e.GetPosition(canvas);
                Canvas.SetLeft(this, currentPoint.X - _startPoint.X);
                Canvas.SetTop(this, currentPoint.Y - _startPoint.Y);
            }
        }

        #endregion
    }
}