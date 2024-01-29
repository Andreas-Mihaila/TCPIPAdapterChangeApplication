/*-------------------------------------------------------------------------------------------------------------------------------------*/

using System.Net.NetworkInformation;
using TCIPChangeClassStandard;
using TCPIPChangeClassAdvanced;
using System.Management;

/*-------------------------------------------------------------------------------------------------------------------------------------*/

string strMACAddress = "";
int iNetworkAdapterNumber;
string strDCHPDecision;
string strAdapterIPAddress;
string strAdapterSubnetMask;
string strAdapterGateway;
string strDNSName;

NetworkInterface NetworkAdapter;

NetworkConfigurator NetworkConfigurator = new NetworkConfigurator();

/*-------------------------------------------------------------------------------------------------------------------------------------*/

Console.WriteLine("---------------------------------------------");
Console.WriteLine("-------Network Configurator Appication-------\r");
Console.WriteLine("---------------------------------------------\n");

Console.WriteLine("Select Network Adapter: \n");
Console.WriteLine("1 - Built-In Ethernet Adapter \n");
Console.WriteLine("2 - Lenovo USB Ethernet Adapter \n");
Console.WriteLine("3 - Amazon Gigabit Ethernet Adapter \n");
Console.WriteLine("4 - WiFi Ethernet Adapter \n");
Console.WriteLine("---------------------------------------------\n");

Console.WriteLine("Select Network Adapter: ");

iNetworkAdapterNumber = Convert.ToInt32(Console.ReadLine());

switch (iNetworkAdapterNumber)
    {

        case 1:
        strMACAddress = "38F3ABD97226";
        break;

        case 2:
        strMACAddress = "083A886158F9";
        break;

        case 3:
        strMACAddress = "A0CEC85D607F";
        break;

        case 4:
        strMACAddress = "5414F3241729";
        break;

}

Console.WriteLine("---------------------------------------------\n");

NetworkAdapter = NetworkConfiguratorAdvanced.GetNetworkInterface(strMACAddress);

Console.WriteLine($"Your current Ethernet Network Adapter: {NetworkAdapter.Name}");
Console.WriteLine("---------------------------------------------\n");

Console.WriteLine("Do you want to use DHCP? y/n");

strDCHPDecision = Console.ReadLine();

if (strDCHPDecision == "y")
    {
 
        try
        {
            NetworkConfigurator.SetDHCP(NetworkAdapter.Name);

            Console.Write("TCP - Configuration successfully changed ..\n");
            Console.WriteLine("---------------------------------------------\n");

        }

        catch (Exception e)
        {

            Console.Write("TCP - Configuration successfully changed ..\n");
            Console.WriteLine("---------------------------------------------\n");

            //Console.Write("TCP - Configuration not changed - check following error message\n");
            //Console.Write("Exception Message: " + e.Message);

        }
    }

else
    {

        Console.WriteLine("---------------------------------------------\n");
        Console.WriteLine("New IP Address: ");
        strAdapterIPAddress = Console.ReadLine();
        Console.WriteLine("---------------------------------------------\n");


        Console.WriteLine("New SubnetMask: ");
        strAdapterSubnetMask = Console.ReadLine();
        Console.WriteLine("---------------------------------------------\n");


        Console.WriteLine("New Gateway: ");
        strAdapterGateway = Console.ReadLine();
        Console.WriteLine("---------------------------------------------\n");


        Console.WriteLine("New DNS: ");
        strDNSName = Console.ReadLine();
        Console.WriteLine("---------------------------------------------\n");

        try
        {

            NetworkConfiguratorAdvanced.SetupNIC(strMACAddress, strAdapterIPAddress, strAdapterSubnetMask, strAdapterGateway, strDNSName);

            Console.Write("TCP - Configuration successfully changed ..\n");
            Console.WriteLine("---------------------------------------------\n");

        }

        catch (Exception e)
        {

            Console.Write("TCP - Configuration not changed - check following error message .. \n");
            Console.Write("Exception Message: " + e.Message);
            Console.WriteLine("---------------------------------------------\n");

        } 
}