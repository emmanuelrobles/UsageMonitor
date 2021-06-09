using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

namespace Application.Models
{
    public class Temperature
    {
        private Computer _computer;

        public Temperature()
        {
            _computer = new Computer() {CPUEnabled = true};
        }
        
        public IEnumerable<float> CpuTemp()
        {
            SystemVisitor
            _computer.Open();
            var toReturn = new List<float>();
            var cpuHardware = _computer.Hardware.Where(c => c.HardwareType == HardwareType.CPU);

            Parallel.ForEach(cpuHardware, h =>
            {
                Parallel.ForEach(h.Sensors.Where(s =>s.SensorType == SensorType.Temperature), s =>
                {
                    toReturn.Add(s.Value.GetValueOrDefault(0));
                });
            });
            _computer.Close();
            return toReturn;
        }
        
    }
}