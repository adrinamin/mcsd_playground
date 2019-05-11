using System;
using System.Linq;

namespace algorithms
{
    public class NameDetector
    {
        public event EventHandler DetectName;

        public string GetName()
        {
            var name = "Adrin";
            if (name.Length > 1)
            {
                OnNameDetection(EventArgs.Empty);
            }
            return name;
        }

        private void OnNameDetection(EventArgs e)
        {
            EventHandler handler = DetectName;
            handler?.Invoke(this, e);
        }
    }
}