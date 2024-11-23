using System;
using VirtualLabAPI.Handler;
using VirtualLabAPI.Models;

namespace VirtualLabAPI.Controllers
{
    public interface IDiagramController
    {
        void Attach(IGradingHandler observer);

        // Detach an observer from the subject.
        void Detach(IGradingHandler observer);

        // Notify all observers about an event.
        void Notify(Diagram diagram);
    }
}
