using Microsoft.Extensions.Logging;

namespace ToDo.Controllers
{
    public class SettingsController
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            this._logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }
    }
}