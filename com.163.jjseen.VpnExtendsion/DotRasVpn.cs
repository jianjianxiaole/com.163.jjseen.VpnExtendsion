using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotRas;

namespace com._163.jjseen.VpnExtendsion
{
    /// <summary>
    /// DotRas shortcut for VPN
    /// </summary>
    public static class DotRasVpn
    {
        /// <summary>
        /// Created an pptp protocol vpn entry。When it be created , it will be store in phonebook (RasPhoneBookType.User) entries collection.
        /// </summary>
        /// <param name="pkb"></param>
        /// <param name="entryName"></param>
        /// <returns>Created Vpn RasEntry instance</returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.ArgumentException"/>
        public static RasEntry CreatePptpVpnEntry(string entryName)
        {
            var pptpdDevice = RasDevice.GetDevices().First(dev => dev.DeviceType == RasDeviceType.Vpn
                                                            &&
                                                            (dev.Name.Contains(@"PPTP") || dev.Name.Contains(@"pptp")));
            using (var pbk = new RasPhoneBook())
            {
                pbk.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
                var entry = RasEntry.CreateVpnEntry(entryName, "", RasVpnStrategy.PptpOnly, pptpdDevice);
                entry.IdleDisconnectSeconds = RasIdleDisconnectTimeout.Disabled;
                entry.EncryptionType = RasEncryptionType.Require;
                var option = entry.Options;
                option.PreviewUserPassword = false;
                option.RemoteDefaultGateway = true;
                option.RequireMSChap = false;
                option.RequireMSChap2 = true;
                option.TerminalBeforeDial = false;
                pbk.Entries.Add(entry);
                return entry;
            }
        }



    }
}
