using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mini
{
    public partial class VirtualWindow : UserControl
    {
        private bool _isDragging = false;
        private Point _clickPosition;

        public VirtualWindow()
        {
            InitializeComponent();
        }

        // 창 제목 변경 프로퍼티
        public string Title
        {
            get => TxtTitle.Text;
            set => TxtTitle.Text = value;
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _clickPosition = e.GetPosition(this);
            
            // 드래그 시 마우스 포인터 캡처
            HeaderBorder.CaptureMouse();

            // 클릭한 창을 가장 위로 올리기 (Z-Index)
            if (this.Parent is Canvas parentCanvas)
            {
                int maxZ = 0;
                foreach (UIElement child in parentCanvas.Children)
                {
                    int z = Canvas.GetZIndex(child);
                    if (z > maxZ) maxZ = z;
                }
                Canvas.SetZIndex(this, maxZ + 1);
            }
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && this.Parent is Canvas parentCanvas)
            {
                Point currentPos = e.GetPosition(parentCanvas);

                // 새로운 Canvas 위치 계산
                double newLeft = currentPos.X - _clickPosition.X;
                double newTop = currentPos.Y - _clickPosition.Y;

                // 캔버스 범위를 벗어나지 않도록 보정 (선택 사항)
                if (newLeft < 0) newLeft = 0;
                if (newTop < 0) newTop = 0;
                if (newLeft + this.ActualWidth > parentCanvas.ActualWidth) 
                    newLeft = parentCanvas.ActualWidth - this.ActualWidth;
                if (newTop + this.ActualHeight > parentCanvas.ActualHeight) 
                    newTop = parentCanvas.ActualHeight - this.ActualHeight;

                Canvas.SetLeft(this, newLeft);
                Canvas.SetTop(this, newTop);
            }
        }

        private void Header_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            HeaderBorder.ReleaseMouseCapture();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            // 캔버스에서 해당 창 제거
            if (this.Parent is Canvas parentCanvas)
            {
                parentCanvas.Children.Remove(this);
            }
        }
    }
}