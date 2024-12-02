using System.Runtime.InteropServices.JavaScript;
using VirtualLabAPI.Controllers;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Handler
{
    public interface IGradingHandler
    {
        int Update(Diagram subject, int TaskId);
    }
}
