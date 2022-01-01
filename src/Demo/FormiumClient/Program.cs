using NetDimension.NanUI;
using System.Windows.Forms;
using Xilium.CefGlue;

namespace FormiumClient;

public static class Program
{
    public static void Main()
    {

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#if NETCOREAPP3_1_OR_GREATER
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
        
        // *************** DO NOT WRITE ANY CODES HERE ***************

        // Warning: Do not write business-related code before or after CreateRuntimeBuilder. Writing business logic here due to the multi-process architecture of CEF will cause your business logic to be executed multiple times.
        // ����: ������ CreateRuntimeBuilder ֮ǰ��֮���дҵ����صĴ��룬���� CEF �Ķ���̼ܹ��ڴ˴���дҵ���߼�����������ҵ���߼������ִ�С�

        WinFormium.CreateRuntimeBuilder(buildChromiumEnvironment: env =>
        {
            env.CustomCefCommandLineArguments(args =>
            {
                // Configure CEF command line switches arugments here.
                // �ڴ����� CEF ��������ָ��Ͳ���

                args.AppendSwitch("ignore-certificate-errors");
                args.AppendSwitch("disable-web-security");
                args.AppendSwitch("enable-media-stream");
                args.AppendSwitch("enable-print-preview");
                args.AppendSwitch("autoplay-policy", "no-user-gesture-required");

            });

            env.CustomCefSettings(settings =>
            {
                // Configure default Cef settings here.
                // �ڴ����� CEF Ĭ������

            });

            env.CustomDefaultBrowserSettings(cefSettings =>
            {
                // Configure default browser settings here.
                // �ڴ����������Ĭ������
            });

        }, buildApplicationConfiguration: app =>
        {
            app.UseEmbeddedFileResource("http", "resources.app.local", "EmbeddedFiles", url =>
            {
                if (url.StartsWith("http://resources.app.local/window-styles"))
                {
                    return "window-styles/index.html";
                }
                return null;
            });

            // Register LocalFileResource handler which can handle the file resources in local folder.
            // ʹ�� LocalFileResource ע�᱾���ļ���Դ�����������ļ����ڵ��ļ���Ŀ¼�ṹӳ�䵽 http://static.app.local �����¡�
            app.UseLocalFileResource("http", "static.app.local", System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));

            // Register DataServiceResource handler which can process http request and return data to response. It will find all DataServices in current assembly automatically or you can indicate where to find the DataServices by using the third parameter.
            // ע��������Դ�����������ܴ���ǰ�˵�http���󲢷�����Ӧ�����DataServiceResource���Զ�ɨ�貢ע������ڵ����ݷ�����Ҳ�����ֶ�ָ�����ݷ������ڵ�λ�á�
            app.UseDataServiceResource("http", "api.app.local"); ;

#if DEBUG
            // Specify whether to enable debugging mode.
            // ָ���Ƿ�������ģʽ��
            app.UseDebuggingMode();
#endif

            app.RegisterJavaScriptWindowBinding(() => new DemoWindowBinding());


            // Open the main form and start the message loop.
            // �������岢��ʼ��Ϣѭ����
            app.UseMainWindow(context =>
            {
                var startupWin = new StartupWindow();
                if (startupWin.ShowDialog() == DialogResult.OK)
                {
                    return new MainWindow();
                }

                return null;
            });

            //app.UseMainWindow(_ => new MainWindow());

        })
        .Build()
        .Run();

        // Warning: Do not write business-related code before or after CreateRuntimeBuilder. Writing business logic here due to the multi-process architecture of CEF will cause your business logic to be executed multiple times.
        // ����: ������ CreateRuntimeBuilder ֮ǰ��֮���дҵ����صĴ��룬���� CEF �Ķ���̼ܹ��ڴ˴���дҵ���߼�����������ҵ���߼������ִ�С�

        // *************** DO NOT WRITE ANY CODES HERE ***************
    }
}
