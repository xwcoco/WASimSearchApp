using System;
using System.Windows.Forms;
using System.Linq; // Added for .Take()

namespace WASimSearchApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 测试SimvarManager
            TestSimvarManager();
            
            // 演示SimvarManager功能
            SimvarManagerExample.DemonstrateSimvarManager();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        /// <summary>
        /// 测试SimvarManager功能
        /// </summary>
        static void TestSimvarManager()
        {
            try
            {
                Console.WriteLine("开始测试SimvarManager...");
                
                var simvarManager = new SimvarManager();
                
                // 从文件初始化Sim变量
                simvarManager.InitializeFromFile("simvar.txt");
                
                Console.WriteLine($"SimvarManager中总共有 {simvarManager.Count} 个变量");
                
                // 测试搜索功能
                var cameraResults = simvarManager.SearchSimvars("CAMERA");
                Console.WriteLine($"搜索'CAMERA'找到 {cameraResults.Count} 个结果");
                
                // 测试按单位筛选
                var boolResults = simvarManager.GetSimvarsByUnit("Bool");
                Console.WriteLine($"Bool类型的变量有 {boolResults.Count} 个");
                
                // 测试获取数值类型变量
                var numericResults = simvarManager.GetNumericSimvars();
                Console.WriteLine($"数值类型的变量有 {numericResults.Count} 个");
                
                // 显示前几个数值类型变量的示例
                Console.WriteLine("数值类型变量示例:");
                foreach (var simvar in numericResults.Take(5))
                {
                    Console.WriteLine($"  - {simvar.Name} ({simvar.Unit})");
                }
                
                // 测试获取所有单位
                var allUnits = simvarManager.GetAllUnits();
                Console.WriteLine($"所有单位类型: {string.Join(", ", allUnits.Take(10))}...");
                
                // 测试获取特定变量
                var altitudeVar = simvarManager.GetSimvar("PLANE ALTITUDE");
                if (altitudeVar != null)
                {
                    Console.WriteLine($"找到变量: {altitudeVar}");
                }
                
                Console.WriteLine("SimvarManager测试完成！");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"测试SimvarManager时出错: {ex.Message}");
            }
        }
    }
}