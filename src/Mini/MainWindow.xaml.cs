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
using Wpf.Ui.Controls;

namespace Mini
{
    public partial class MainWindow : FluentWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // 메인 화면 로드 완료 후 가상 창 테스트 생성
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // 첫 번째 가상 창 생성
            var win1 = new VirtualWindow { Title = "시스템 프로세스 감시" };
            Canvas.SetLeft(win1, 100);
            Canvas.SetTop(win1, 100);
            DesktopCanvas.Children.Add(win1);

            // 두 번째 가상 창 생성
            var win2 = new VirtualWindow { Title = "네트워크 핑 모니터" };
            Canvas.SetLeft(win2, 550);
            Canvas.SetTop(win2, 100);
            DesktopCanvas.Children.Add(win2);

            // 두 번째 가상 창 생성
            var win3 = new SettingView {};
            Canvas.SetLeft(win3, 120);
            Canvas.SetTop(win3, 100);
            DesktopCanvas.Children.Add(win3);
        }

        // 비상 종료용 키 (개발 중 Alt+F4 외에 Esc 키로 빠른 테스트 종료를 원할 경우)
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            
            // 필요 시 주석 해제하여 Esc 키로 빠르게 앱 종료
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }
    }
}