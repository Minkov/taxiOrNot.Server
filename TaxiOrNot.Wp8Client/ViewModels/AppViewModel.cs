using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxiOrNot.Wp8Client.Behavior;
using TaxiOrNot.Wp8Client.Models;

namespace TaxiOrNot.Wp8Client.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        private ICommand appLoadedCommand;
        private string message;
        private string username;

        public AppViewModel()      
        {
        }

        public string ServerBaseUrl { get; set; }

        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    this.OnPropertyChanged("Message");
                }
            }
        }


        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (this.username != value)
                {
                    this.username = value;
                    this.OnPropertyChanged("Username");
                }
            }
        }

        public ICommand AppLoaded
        {
            get
            {
                if (this.appLoadedCommand == null)
                {
                    this.appLoadedCommand =
                        new DelegateCommand<object>(this.HandleAppLoadCommand);
                }
                return this.appLoadedCommand;
            }
        }

        private async void HandleAppLoadCommand(object parameter)
        {
            var deviceId = this.GetDeviceId();
            //request user data
            var headers = new Dictionary<string, string>();
            //headers["x-phoneId"] = deviceId;
            //UserModel userdata = await HttpRequester.GetJson<UserModel>(this.ServerBaseUrl + "users",headers);
            //this.Username = userdata.Username;
            await HttpRequester.GetJson<object>("http://google.com");

        }

        private string GetDeviceId()
        {
            var deviceIdBytes = (byte[])Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("DeviceUniqueId");
            var deviceId = Convert.ToBase64String(deviceIdBytes);
            return deviceId;
        }
    }
}