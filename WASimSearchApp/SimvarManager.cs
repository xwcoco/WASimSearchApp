using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Added for File operations

namespace WASimSearchApp
{
    /// <summary>
    /// Sim变量信息类
    /// </summary>
    public class SimvarInfo
    {
        /// <summary>
        /// 变量名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 变量单位
        /// </summary>
        public string Unit { get; set; } = string.Empty;

        /// <summary>
        /// 变量类型
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 变量描述
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 是否可写
        /// </summary>
        public bool IsWritable { get; set; } = false;

        public SimvarInfo()
        {
        }

        public SimvarInfo(string name, string unit = "", string type = "", string description = "", bool isWritable = false)
        {
            Name = name;
            Unit = unit;
            Type = type;
            Description = description;
            IsWritable = isWritable;
        }

        public override string ToString()
        {
            return $"{Name} ({Unit})";
        }
    }

    /// <summary>
    /// Sim变量管理器
    /// </summary>
    public class SimvarManager
    {
        private readonly Dictionary<string, SimvarInfo> _simvars = new Dictionary<string, SimvarInfo>();
        private readonly object _lockObject = new object();

        /// <summary>
        /// 获取所有Sim变量
        /// </summary>
        public IReadOnlyDictionary<string, SimvarInfo> Simvars => _simvars;

        public SimvarManager()
        {
            InitializeFromFile("simvar.txt");
        }

        /// <summary>
        /// Sim变量数量
        /// </summary>
        public int Count
        {
            get
            {
                lock (_lockObject)
                {
                    return _simvars.Count;
                }
            }
        }

        /// <summary>
        /// 添加Sim变量
        /// </summary>
        /// <param name="simvar">Sim变量信息</param>
        public void AddSimvar(SimvarInfo simvar)
        {
            if (simvar == null || string.IsNullOrEmpty(simvar.Name))
                return;

            lock (_lockObject)
            {
                _simvars[simvar.Name] = simvar;
            }
        }

        /// <summary>
        /// 批量添加Sim变量
        /// </summary>
        /// <param name="simvars">Sim变量列表</param>
        public void AddSimvars(IEnumerable<SimvarInfo> simvars)
        {
            if (simvars == null)
                return;

            lock (_lockObject)
            {
                foreach (var simvar in simvars)
                {
                    if (simvar != null && !string.IsNullOrEmpty(simvar.Name))
                    {
                        _simvars[simvar.Name] = simvar;
                    }
                }
            }
        }

        /// <summary>
        /// 获取Sim变量
        /// </summary>
        /// <param name="name">变量名</param>
        /// <returns>Sim变量信息，如果不存在则返回null</returns>
        public SimvarInfo? GetSimvar(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            lock (_lockObject)
            {
                return _simvars.TryGetValue(name, out var simvar) ? simvar : null;
            }
        }

        /// <summary>
        /// 移除Sim变量
        /// </summary>
        /// <param name="name">变量名</param>
        /// <returns>是否成功移除</returns>
        public bool RemoveSimvar(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            lock (_lockObject)
            {
                return _simvars.Remove(name);
            }
        }

        /// <summary>
        /// 清空所有Sim变量
        /// </summary>
        public void Clear()
        {
            lock (_lockObject)
            {
                _simvars.Clear();
            }
        }

        /// <summary>
        /// 检查Sim变量是否存在
        /// </summary>
        /// <param name="name">变量名</param>
        /// <returns>是否存在</returns>
        public bool Contains(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            lock (_lockObject)
            {
                return _simvars.ContainsKey(name);
            }
        }

        /// <summary>
        /// 根据单位筛选Sim变量
        /// </summary>
        /// <param name="unit">单位</param>
        /// <returns>匹配的Sim变量列表</returns>
        public List<SimvarInfo> GetSimvarsByUnit(string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return new List<SimvarInfo>();

            lock (_lockObject)
            {
                return _simvars.Values
                    .Where(s => string.Equals(s.Unit, unit, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        /// <summary>
        /// 根据类型筛选Sim变量
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>匹配的Sim变量列表</returns>
        public List<SimvarInfo> GetSimvarsByType(string type)
        {
            if (string.IsNullOrEmpty(type))
                return new List<SimvarInfo>();

            lock (_lockObject)
            {
                return _simvars.Values
                    .Where(s => string.Equals(s.Type, type, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        /// <summary>
        /// 搜索Sim变量
        /// </summary>
        /// <param name="searchTerm">搜索关键词</param>
        /// <returns>匹配的Sim变量列表</returns>
        public List<SimvarInfo> SearchSimvars(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return new List<SimvarInfo>();

            lock (_lockObject)
            {
                return _simvars.Values
                    .Where(s => s.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                               s.Unit.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }

        /// <summary>
        /// 获取所有单位列表
        /// </summary>
        /// <returns>单位列表</returns>
        public List<string> GetAllUnits()
        {
            lock (_lockObject)
            {
                return _simvars.Values
                    .Select(s => s.Unit)
                    .Where(u => !string.IsNullOrEmpty(u))
                    .Distinct()
                    .OrderBy(u => u)
                    .ToList();
            }
        }

        /// <summary>
        /// 获取所有数值类型的Sim变量
        /// </summary>
        /// <returns>数值类型的Sim变量列表</returns>
        public List<SimvarInfo> GetNumericSimvars()
        {
            lock (_lockObject)
            {
                return _simvars.Values
                    .Where(s => IsNumericUnit(s.Unit))
                    .ToList();
            }
        }

        /// <summary>
        /// 判断单位是否为数值类型
        /// </summary>
        /// <param name="unit">单位</param>
        /// <returns>是否为数值类型</returns>
        private bool IsNumericUnit(string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return false;

            // 数值类型的单位列表
            var numericUnits = new[]
            {
                "Number", "Float", "Integer", "Percent", 
                "Degrees", "Radians", "Feet", "Meters", "Knots", "Mach", "Feet per second", 
                "Meters per second", "Feet per minute", "Meters per minute", "Feet per second squared",
                "Meters per second squared", "Radians per second", "Radians per second squared",
                "Pounds", "Kilograms", "Gallons", "Liters", "Pounds per square foot", 
                "Pounds per square inch", "Millibars", "Inches of mercury", "InHg", "psi",
                "Celsius", "Fahrenheit", "Rankine", "Kelvin", "RPM", "Amperes", "Volts",
                "Watts", "Hertz", "Hz", "Seconds", "Minutes", "Hours", "Nautical miles",
                "Miles", "Kilometers", "Square feet", "Square meters", "Cubic feet", 
                "Cubic meters", "Slugs per cubic feet", "Slugs per feet squared",
                "GForce", "Gforce", "Position", 
                // "SIMCONNECT_DATA_XYZ", "SIMCONNECT_DATA_LATLONALT", "SIMCONNECT_DATA_WAYPOINT",
                // "PID_STRUCT", "Mask", "Flags", "Enum", "Boolean", "Bool", "String",
                // "Frequency BCD16", "Struct", "SIMCONNECT_DATA_LATLONALTPBH"
            };

            return numericUnits.Contains(unit, StringComparer.OrdinalIgnoreCase);
        }



        /// <summary>
        /// 从simvar.txt文件初始化Sim变量
        /// </summary>
        /// <param name="filePath">文件路径，默认为"simvar.txt"</param>
        public void InitializeFromFile(string filePath = "simvar.txt")
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Sim vars file not found: {filePath}");
                }

                var simvars = new List<SimvarInfo>();
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // 解析格式: 'VARIABLE_NAME','UNIT'
                    var trimmedLine = line.Trim();
                    if (trimmedLine.StartsWith("'") && trimmedLine.Contains("','"))
                    {
                        var parts = trimmedLine.Split("','");
                        if (parts.Length == 2)
                        {
                            var name = parts[0].TrimStart('\'').Trim();
                            var unit = parts[1].TrimEnd('\'').Trim();
                            
                            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(unit))
                            {
                                simvars.Add(new SimvarInfo(name, unit));
                            }
                        }
                    }
                }

                AddSimvars(simvars);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
