using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotRas;

namespace com._163.jjseen.VpnExtendsion
{
    /// <summary>
    /// Extendsion based on RasEntry.
    /// Used extendsion function to create Vpn (PPTP,L2TP) entries.
    /// </summary>
    public static class RasEntryExtendsion
    {

        public static bool UpdateDestinationHost(this RasEntry entry, string server)
        {
            //using (var pbk = new RasPhoneBook())
            //{
            //    pbk.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
            //    var me = pbk.Entries[entry.ent];
            //    me.PhoneNumber = server;
            //    return me.Update();
            //}
            entry.PhoneNumber = server;
            return entry.Update();
        }
    }
}
