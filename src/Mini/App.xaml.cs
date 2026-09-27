using System.Configuration;
using System.Data;
using System.Windows;

namespace Mini;

public partial class App : Application
{
    public App()
    {
        // 프로그램 내에서 잡히지 않은 모든 런타임 에러를 팝업으로 출력
        this.DispatcherUnhandledException += (sender, e) =>
        {
            MessageBox.Show($"[런타임 자멸 에러]\n\n{e.Exception.Message}\n\n{e.Exception.StackTrace}", "프로세스 강제 종료 원인");
            e.Handled = true; // 강제 종료 방지
        };
    }
}